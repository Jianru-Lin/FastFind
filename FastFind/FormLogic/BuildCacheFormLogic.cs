using System;
using Bonnie.AsyncX;
using Bonnie.Debug;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace FastFind
{
    class BuildCacheFormLogic
    {
        public BuildCacheFormLogic(BuildCacheForm buildCacheForm)
        {
            Constrain.NotNull(buildCacheForm);
            this.buildCacheForm = buildCacheForm;
            initListener();
            initAction();
        }

        #region buildCacheAction 事件
        void buildCacheAction_Started(BuildCacheAction sender)
        {
            if (buildCacheForm.startBT.InvokeRequired)
            {
                CrossThreadDelegate ctd = buildCacheAction_Started;
                buildCacheForm.startBT.Invoke(ctd, sender);
                return;
            }

            fileCount = 0;
            buildCacheForm.ToRunState();
        }

        void buildCacheAction_Stopped(BuildCacheAction sender)
        {
            if (buildCacheForm.startBT.InvokeRequired)
            {
                CrossThreadDelegate ctd = buildCacheAction_Stopped;
                buildCacheForm.startBT.Invoke(ctd, sender);
                return;
            }
            long filesize = 0;
            double filesizeMB = 0;
            try
            {
                filesize = new FileInfo(ConstValue.CacheFilename).Length;
                filesizeMB = filesize / (1024.0 * 1024.0);
            }
            catch (System.Exception ex)
            {
            	Trace.WriteLine(ex.Message);
            }
            string displayInfo = string.Format("缓存构建完成，共收录{0}条记录{1}", 
                fileCount,
                filesizeMB > 0 ? string.Format("，消耗磁盘空间{0:N}MB", filesizeMB) : ""
                );
            MessageBox.Show(displayInfo);

            buildCacheForm.ToStopState();

            // 关闭当前窗口
            buildCacheForm.DialogResult = DialogResult.OK;
        }

        void buildCacheAction_Canceled(BuildCacheAction sender)
        {
            if (buildCacheForm.startBT.InvokeRequired)
            {
                CrossThreadDelegate ctd = buildCacheAction_Canceled;
                buildCacheForm.startBT.Invoke(ctd, sender);
                return;
            }

            MessageBox.Show("成功取消！");

            buildCacheForm.ToStopState();
        }

        int fileCount = 0;
        void buildCacheAction_Progress(BuildCacheAction sender)
        {
            if (buildCacheForm.startBT.InvokeRequired)
            {
                CrossThreadDelegate ctd = buildCacheAction_Progress;
                buildCacheForm.startBT.Invoke(ctd, sender);
                return;
            }

            // 将当前搜索目录显示在标题栏上
            buildCacheForm.Text = string.Format("{0} {1}", ++fileCount, sender.CurrentWorkingDirectory);
        }

        void buildCacheAction_Error(BuildCacheAction sender)
        {
            if (buildCacheForm.startBT.InvokeRequired)
            {
                CrossThreadDelegate ctd = buildCacheAction_Error;
                buildCacheForm.startBT.Invoke(ctd, sender);
                return;
            }

            MessageBox.Show("错误：" + sender.ErrorInfo);

            buildCacheForm.ToStopState();
        }
        #endregion

        void initListener()
        {
            if (buildCacheForm == null)
            {
                return;
            }

            buildCacheForm.startBT.Click += new EventHandler(startBT_Click);
            buildCacheForm.stopBT.Click += new EventHandler(stopBT_Click);
        }

        void initAction()
        {
            buildCacheAction = new BuildCacheAction();

            buildCacheAction.Started += new EventHandlerX<BuildCacheAction>(buildCacheAction_Started);
            buildCacheAction.Stopped += new EventHandlerX<BuildCacheAction>(buildCacheAction_Stopped);
            buildCacheAction.Canceled += new EventHandlerX<BuildCacheAction>(buildCacheAction_Canceled);
            buildCacheAction.Progress += new EventHandlerX<BuildCacheAction>(buildCacheAction_Progress);
            buildCacheAction.Error += new EventHandlerX<BuildCacheAction>(buildCacheAction_Error);
        }

        #region 事件处理
        // 点击“开始”按钮
        void startBT_Click(object sender, EventArgs e)
        {
            buildCacheAction.SaveFilename = ConstValue.CacheFilename;
            buildCacheAction.RootPath = buildCacheForm.rootPathTB.Text;
            Constrain.NotEmptyString(buildCacheAction.RootPath);
            buildCacheAction.Start();
        }

        // 点击“停止”按钮
        void stopBT_Click(object sender, EventArgs e)
        {
            buildCacheAction.Cancel();
        }
        #endregion

        BuildCacheForm buildCacheForm;
        BuildCacheAction buildCacheAction;
        delegate void CrossThreadDelegate(BuildCacheAction sender);
    }
}
