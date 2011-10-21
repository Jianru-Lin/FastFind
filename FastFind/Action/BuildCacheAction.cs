using System.Collections.Generic;
using System.Text;
using Bonnie.AsyncX;
using Bonnie.Debug;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace FastFind
{
    class BuildCacheAction : ProgressAction<BuildCacheAction, string>
    {
        public string RootPath
        {
            get;
            set;
        }

        public string SaveFilename
        {
            get;
            set;
        }

        public string CurrentWorkingDirectory
        {
            get;
            private set;
        }

        public override void Start()
        {
            Constrain.NotEmptyString(this.RootPath);
            Constrain.NotEmptyString(this.SaveFilename);

            if (thread != null && thread.IsAlive)
            {
                Trace.WriteLine("本 Action 已经启动，但是又尝试重入，已经忽略该请求");
                return;
            }

            // 清除之前残留的信息
            ErrorInfo = null;
            CurrentWorkingDirectory = null;

            // 开始新的征程 :)
            thread = new Thread(_start);
            thread.Start();
            fireStarted(this);
        }

        public override void Cancel()
        {
            if (thread != null)
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                    fireCanceled(this);
                }
            }
        }

        void _start()
        {
            try
            {
                if (!Directory.Exists(this.RootPath))
                {
                    this.ErrorInfo = "路径不存在";
                    fireError(this);
                    return;
                }

                string tmpFilename = this.SaveFilename + ".tmp";

                if (File.Exists(tmpFilename))
                {
                    File.Delete(tmpFilename);
                }

                using (StreamWriter writer = new StreamWriter(tmpFilename, false, Encoding.UTF8))
                {
                    Stack<string> dirStack = new Stack<string>();
                    dirStack.Push(this.RootPath);
                    while (dirStack.Count > 0)
                    {
                        string dir = dirStack.Pop();

                        // 通知一下进度情况
                        this.CurrentWorkingDirectory = dir;
                        fireProgress(this);

                        try
                        {
                            // 记忆下当前子目录
                            foreach (string subDir in Directory.GetDirectories(dir))
                            {
                                dirStack.Push(subDir);
                            }

                            // 获得文件列表，然后保存起来
                            foreach (string filename in Directory.GetFiles(dir))
                            {
                                writer.WriteLine(Path.GetFileName(filename));
                                writer.WriteLine(filename);
                            }
                        }
                        catch (System.Exception ex)
                        {
                            Trace.WriteLine(ex.Message);
                        }
                    }
                }

                if (File.Exists(this.SaveFilename))
                {
                    File.Delete(this.SaveFilename);
                }

                File.Move(tmpFilename, this.SaveFilename);
            }
            catch (ThreadAbortException)
            {
                // 保持沉默
            }
            catch (System.Exception ex)
            {
                this.ErrorInfo = ex.Message;
                fireError(this);
                return;
            }

            // 如果能到达这里，那就是胜利了 :)
            fireStopped(this);
        }

        Thread thread;
    }
}
