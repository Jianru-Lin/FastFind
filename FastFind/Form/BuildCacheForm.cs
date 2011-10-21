using System;
using System.Windows.Forms;

namespace FastFind
{
    public partial class BuildCacheForm : Form
    {
        public BuildCacheForm()
        {
            InitializeComponent();
        }
        public void ToRunState()
        {
            // 禁用“路径”文本框，禁用“浏览”按钮
            rootPathTB.Enabled = false;
            browseBT.Enabled = false;

            // 禁用“开始”按钮，启用“停止”按钮
            startBT.Enabled = false;
            stopBT.Enabled = true;

            // 让进度条开始走
            progressBar.Style = ProgressBarStyle.Marquee;
        }

        public void ToStopState()
        {
            // 启用“路径”文本框，启用“浏览”按钮
            rootPathTB.Enabled = true;
            browseBT.Enabled = true;

            // 启用“开始”按钮，禁用“停止”按钮
            startBT.Enabled = true;
            stopBT.Enabled = false;

            // 让进度条停止
            progressBar.Style = ProgressBarStyle.Blocks;
        }

        private void browseBT_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            rootPathTB.Text = folderBrowserDialog.SelectedPath;
        }

        private void rootPathTB_TextChanged(object sender, EventArgs e)
        {
            actionPanel.Enabled = rootPathTB.Text.Length > 0;
        }

        private void BuildCacheForm_Load(object sender, EventArgs e)
        {
            actionPanel.Enabled = rootPathTB.Text.Length > 0;
        }

        private void BuildCacheForm_Shown(object sender, EventArgs e)
        {
            this.Text = ConstValue.BuildCacheFormTitle;
        }
    }
}
