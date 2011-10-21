using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Bonnie.Debug;
using System.Diagnostics;

namespace FastFind
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            BuildCacheForm = new BuildCacheForm();
            RegexConfigForm = new RegexConfigForm();
        }

        public BuildCacheForm BuildCacheForm
        {
            get;
            private set;
        }

        public RegexConfigForm RegexConfigForm
        {
            get;
            private set;
        }

        public string Title
        {
            get { return title; }
            set { title = value; updateTitle(); }
        }

        public string CacheInfo
        {
            get { return cacheInfo; }
            set { cacheInfo = value; updateTitle(); }
        }

        public string SearchInfo
        {
            get { return searchInfo; }
            set { searchInfo = value; updateTitle(); }
        }

        string title;
        string cacheInfo;
        string searchInfo;

        void updateTitle()
        {
            string txt = title ?? ConstValue.MainFormTitle;
            if (!string.IsNullOrEmpty(cacheInfo))
            {
                txt += " " + cacheInfo;
            }
            if (!string.IsNullOrEmpty(searchInfo))
            {
                txt += " " + searchInfo;
            }
            this.Text = txt;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            searchBT.Enabled = filenameTB.Text.Length > 0;
            updateTitle();
        }

        private void filenameTB_TextChanged(object sender, EventArgs e)
        {
            searchBT.Enabled = filenameTB.Text.Length > 0;
        }

        private void buildCacheLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BuildCacheForm.ShowDialog();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (sameCB.Checked)
            {
                startWithCB.Enabled = false;
                existCB.Enabled = false;
                endWithCB.Enabled = false;
                regexCB.Enabled = false;
            }
            else
            {
                regexCB.Enabled = true;
                sameCB.Enabled = !regexCB.Checked;
                startWithCB.Enabled = !regexCB.Checked;
                existCB.Enabled = !regexCB.Checked;
                endWithCB.Enabled = !regexCB.Checked;
            }
        }

        private void regexConfigLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegexConfigForm.ShowDialog();
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            (sender as ContextMenuStrip).Enabled = resultLV.SelectedItems.Count > 0;
        }

        private void 直接打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < resultLV.SelectedItems.Count; ++i)
            {
                try
                {
                    string filepath = getFilepath(resultLV.SelectedItems[i]);
                    Shell.Open(filepath);
                }
                catch (System.Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                }
            }
        }

        private void 打开所在位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < resultLV.SelectedItems.Count; ++i)
            {
                try
                {
                    string filepath = getFilepath(resultLV.SelectedItems[i]);
                    string dir = System.IO.Path.GetDirectoryName(filepath);
                    Shell.Open(dir);
                }
                catch (System.Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                }
            }
        }

        private void 复制文件路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < resultLV.SelectedItems.Count; ++i)
                {
                    try
                    {
                        string filepath = getFilepath(resultLV.SelectedItems[i]);
                        string line = string.Format("{0}{1}", filepath, i < resultLV.SelectedItems.Count - 1 ? "\r\n" : "");
                        stringBuilder.AppendFormat(line);
                    }
                    catch (System.Exception ex)
                    {
                        Trace.WriteLine(ex.Message);
                    }
                }

                Clipboard.SetDataObject(stringBuilder.ToString(), true);
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        string getFilepath(ListViewItem lvi)
        {
            Constrain.NotNull(lvi);
            try
            {
                const int filepathIndex = 1;
                return lvi.SubItems[filepathIndex].Text;
            }
            catch (System.Exception ex)
            {
                Constrain.UnreachableCode("出现 BUG，请调试！错误：" + ex.Message);
                return null;
            }
        }

        private void resultLV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            ListViewItem lvi = resultLV.HitTest(e.Location).Item;
            if (lvi != null)
            {
                try
                {
                    string filepath = getFilepath(lvi);
                    Shell.Open(filepath);
                }
                catch (System.Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                }
            }
        }

        private void whoLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Shell.Open("http://i-code.diandian.com/");
        }
    }
}
