using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Bonnie.Debug;
using System.Text.RegularExpressions;

namespace FastFind
{
    class MainFormLogic
    {
        public MainFormLogic(MainForm targetForm)
        {
            Constrain.NotNull(targetForm);
            this.targetForm = targetForm;

            // 订阅整个窗体的 Shown 事件和 searchBT 点击事件
            targetForm.Shown += new EventHandler(targetForm_Shown);
            targetForm.searchBT.Click += new EventHandler(searchBT_Click);

            // 订阅窗体中 clearCacheLL 的点击事件
            targetForm.clearCacheLL.Click += new EventHandler(clearCacheLL_Click);

            // 将 BuildCacheFormLogic 类的对象附加到缓存生成窗体上
            BuildCacheFormLogic buildCacheFormLogic = new BuildCacheFormLogic(targetForm.BuildCacheForm);

            // 订阅 BuildCacheForm 窗体的 Shown 和 FormClosed 事件
            // 用于判断用户是否又重新构建了缓存，以便重新加载
            targetForm.BuildCacheForm.Shown += new EventHandler(BuildCacheForm_Shown);
            targetForm.BuildCacheForm.FormClosed += new FormClosedEventHandler(BuildCacheForm_FormClosed);
        }

        #region BuildCacheForm 事件处理
        long cacheFileLastWriteTick = -1;
        void BuildCacheForm_Shown(object sender, EventArgs e)
        {
            try
            {
                cacheFileLastWriteTick = File.GetLastWriteTime(ConstValue.CacheFilename).Ticks;
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        void BuildCacheForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                long now = File.GetLastWriteTime(ConstValue.CacheFilename).Ticks;
                if (now - cacheFileLastWriteTick > 0)
                {
                    // 重新加载
                    loadData();
                }
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        #endregion


        #region MainForm (targetForm) 事件处理
        // Shown 事件处理
        // 主要检查缓存文件是否存在，如果不存在，说明尚未建立缓存
        // 需要提示用户建立缓存
        void targetForm_Shown(object sender, EventArgs e)
        {
            if (!File.Exists(ConstValue.CacheFilename))
            {
                // 更改标题栏
                targetForm.CacheInfo = " （无数据）";

                // 显示生成缓存窗体，让用户生成
                targetForm.BuildCacheForm.ShowDialog();
            }
            else
            {
                loadData();
            }
        }

        // 用户点击“查找”按钮
        void searchBT_Click(object sender, EventArgs e)
        {
            // 记录下单选框的信息
            same = targetForm.sameCB.Checked;
            startWith = targetForm.startWithCB.Checked;
            exist = targetForm.existCB.Checked;
            endWith = targetForm.endWithCB.Checked;
            regex = targetForm.regexCB.Checked;
            // 记录下正则表达式选项信息
            regexOptions = targetForm.RegexConfigForm.RegexOptions;

            string filename = targetForm.filenameTB.Text;
            targetForm.resultLV.Items.Clear(); // 清空上一次的搜索结果

            const int maxCount = 1000; // 限制最多向用户显示的搜索结果数目
            int count = 0;
            try
            {
                searchData(filename, delegate(int i, FileEntry fileEntry, GroupEnum groupEnum)
                {
                    ListViewItem lvi = new ListViewItem(new string[] {
                    fileEntry.Filename,
                    fileEntry.FilePath
                    });

                    ListViewGroup group = null;
                    switch (groupEnum)
                    {
                        case GroupEnum.Same:
                            group = targetForm.resultLV.Groups["Same"];
                            break;
                        case GroupEnum.StartWith:
                            group = targetForm.resultLV.Groups["StartWith"];
                            break;
                        case GroupEnum.Exist:
                            group = targetForm.resultLV.Groups["Exist"];
                            break;
                        case GroupEnum.EndWith:
                            group = targetForm.resultLV.Groups["EndWith"];
                            break;
                        case GroupEnum.Regex:
                            group = targetForm.resultLV.Groups["Regex"];
                            break;
                        default:
                            Constrain.UnreachableCode("难道你添加了新的 GroupEnum 却没有修改这里的代码？");
                        break;
                    }
                    if (group != null)
                    {
                        lvi.Group = group;
                        targetForm.resultLV.Items.Add(lvi);
                    }
                    else
                    {
                        Constrain.UnreachableCode("怎么 group 会为 null？存在 BUG ！");
                    }
                    return ++count < maxCount;
                });
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 用户点击“清除”按钮
        void clearCacheLL_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("清除缓存数据？", "清除", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                File.Delete(ConstValue.CacheFilename);
                
                // 清空记录，更改标题栏
                fileEntries.Clear();
                targetForm.CacheInfo = "（无数据）";

                // 把搜索列表也清空（如果有的话）
                targetForm.resultLV.Items.Clear();

                // 如果有临时文件，也删除掉
                string tmpFile = ConstValue.CacheFilename + ".tmp";
                if (File.Exists(tmpFile))
                {
                    File.Delete(tmpFile);
                }
            }
        }
        #endregion

        #region 核心功能实现
        void loadData()
        {
            try
            {
                // 首先清空之前的记录（如果有的话）
                fileEntries.Clear();

                Trace.WriteLine("开始加载缓存数据...");
                DateTime dt = DateTime.Now;
                if (!CacheIO.Load(fileEntries, ConstValue.CacheFilename))
                {
                    MessageBox.Show("加载缓存数据失败");
                }
                else
                {
                    TimeSpan ts = DateTime.Now - dt;
                    Trace.WriteLine(string.Format("加载缓存数据成功，共加载 {0} 条记录，耗时 {1}s", fileEntries.Count, ts.TotalSeconds));
                    targetForm.CacheInfo = string.Format("（含{0}条记录，加载耗时{1}s）", fileEntries.Count, ts.TotalSeconds);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool searchData(string filename, SearchDataDelegate sdd)
        {
            // sdd 不能为 null
            // 但是 filename 可以随意
            if (sdd == null)
            {
                throw new ArgumentNullException();
            }

            if (fileEntries == null || fileEntries.Count == 0)
            {
                return false;
            }

            // 预先编译好正则表达式
            // 用得着用不着得后面判断
            Regex regexEngine = null;
            if (regex)
            {
                try
                {
                    string pattern = filename;
                    regexEngine = new Regex(pattern, regexOptions);
                }
                catch (System.Exception ex)
                {
                	// 出错，很可能是正则表达式有误
                    // 把异常向上传递
                    throw new Exception("正则表达式不正确：" + ex.Message);
                }
            }

            // 将文件名转为小写，方便快速匹配
            // 注意这一操作必须放在前一句——
            // 构造正则表达式引擎之后
            if (!string.IsNullOrEmpty(filename))
            {
                filename = filename.ToLower();
            }

            DateTime dt = DateTime.Now;
            bool success = false;
            int count = 0;
            for (int i = 0; i < fileEntries.Count; i++)
            {
                FileEntry fileEntry = fileEntries[i];
                // 根据用户的要求，采用不同的匹配规则进行匹配
                if (same) // 要求精确匹配（但是大小写不敏感）
                {
                    if (fileEntry.FilenameLC == filename)
                    {
                        ++count;
                        // sdd 返回 false 说明不需要再继续
                        // 向下寻找了，所以直接跳出
                        if (sdd(i, fileEntry, GroupEnum.Same) == false)
                        {
                            success = true;
                            break;
                        }
                    }
                }
                else
                {
                    // 要求正则匹配
                    if (regex)
                    {
                        Constrain.NotNull(regexEngine);
                        Match match = regexEngine.Match(fileEntry.Filename);
                        if (match.Success 
                            && match.Index == 0 
                            && match.Length == fileEntry.Filename.Length)
                        {
                            ++count;
                            if (sdd(i, fileEntry, GroupEnum.Regex) == false)
                            {
                                success = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        // 注意下面三种匹配不是互斥的
                        // 用户如果多选，则都会进行匹配检查
                        // 如果匹配，都会添加到最终结果中

                        // 要求开头匹配
                        if (startWith)
                        {
                            if (fileEntry.FilenameLC.StartsWith(filename))
                            {
                                ++count;
                                if (sdd(i, fileEntry, GroupEnum.StartWith) == false)
                                {
                                    success = true;
                                    break;
                                }
                            }
                        }
                        // 要求中间匹配
                        if (exist)
                        {
                            if (fileEntry.FilenameLC.IndexOf(filename) > -1)
                            {
                                ++count;
                                if (sdd(i, fileEntry, GroupEnum.Exist) == false)
                                {
                                    success = true;
                                    break;
                                }
                            }
                        }
                        // 要求结尾匹配
                        if (endWith)
                        {
                            if (fileEntry.FilenameLC.EndsWith(filename))
                            {
                                ++count;
                                if (sdd(i, fileEntry, GroupEnum.EndWith) == false)
                                {
                                    success = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            TimeSpan ts = DateTime.Now - dt;
            string tip = string.Format("搜索得{0}条记录 共耗时{1}s", count, ts.TotalSeconds);
            Trace.WriteLine(tip);
            targetForm.SearchInfo = tip;
            return success;
        }
        #endregion

        MainForm targetForm;
        List<FileEntry> fileEntries = new List<FileEntry>();
        delegate bool SearchDataDelegate(int i, FileEntry fileEntry, GroupEnum groupEnum);

        bool same;
        bool startWith;
        bool exist;
        bool endWith;
        bool regex;
        RegexOptions regexOptions;
    }
}
