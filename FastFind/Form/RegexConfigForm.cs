using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FastFind
{
    public partial class RegexConfigForm : Form
    {
        public RegexConfigForm()
        {
            InitializeComponent();
        }

        public RegexOptions RegexOptions
        {
            get
            {
                if (NoneCB.Checked)
                {
                    return RegexOptions.None;
                }

                RegexOptions options = RegexOptions.None;
                if (IgnoreCaseCB.Checked)
                {
                    options |= RegexOptions.IgnoreCase;
                }
                if (MultilineCB.Checked)
                {
                    options |= RegexOptions.Multiline;
                }
                if (ExplicitCaptureCB.Checked)
                {
                    options |= RegexOptions.ExplicitCapture;
                }
                if (CompiledCB.Checked)
                {
                    options |= RegexOptions.Compiled;
                }
                if (SinglelineCB.Checked)
                {
                    options |= RegexOptions.Singleline;
                }
                if (IgnorePatternWhitespaceCB.Checked)
                {
                    options |= RegexOptions.IgnorePatternWhitespace;
                }
                if (RightToLeftCB.Checked)
                {
                    options |= RegexOptions.RightToLeft;
                }
                if (ECMAScriptCB.Checked)
                {
                    options |= RegexOptions.ECMAScript;
                }
                if (CultureInvariantCB.Checked)
                {
                    options |= RegexOptions.CultureInvariant;
                }
                return options;
            }
        }

        // 窗体加载
        private void RegexConfigForm_Load(object sender, EventArgs e)
        {
            updateState();
        }

        // 窗体显示
        private void RegexConfigForm_Shown(object sender, EventArgs e)
        {
            // 当窗体显示的时候，先将当前各选项的状态进行拷贝和保存
            // 这样可以支持用户进行“取消”操作
            dumpState();
        }

        // 用户点击“确定”按钮
        private void okBT_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        // 用户点击“取消”按钮
        private void cancelBT_Click(object sender, EventArgs e)
        {
            restoreState();
            this.DialogResult = DialogResult.Cancel;
        }

        // 用户关闭本窗体
        private void RegexConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
            {
                restoreState();
            }
        }

        // 用户勾选/反勾选了某个选项
        private void CheckedChanged(object sender, EventArgs e)
        {
            updateState();
        }

        void updateState()
        {
            IgnoreCaseCB.Enabled = !NoneCB.Checked;
            MultilineCB.Enabled = !NoneCB.Checked;
            ExplicitCaptureCB.Enabled = !NoneCB.Checked;
            CompiledCB.Enabled = !NoneCB.Checked;
            SinglelineCB.Enabled = !NoneCB.Checked;
            IgnorePatternWhitespaceCB.Enabled = !NoneCB.Checked;
            RightToLeftCB.Enabled = !NoneCB.Checked;
            ECMAScriptCB.Enabled = !NoneCB.Checked;
            CultureInvariantCB.Enabled = !NoneCB.Checked;
        }

        void dumpState()
        {
            _None = NoneCB.Checked;
            _IgnoreCase = IgnoreCaseCB.Checked;
            _Multiline = MultilineCB.Checked;
            _ExplicitCapture = ExplicitCaptureCB.Checked;
            _Compiled = CompiledCB.Checked;
            _Singleline = SinglelineCB.Checked;
            _IgnorePatternWhitespace = IgnorePatternWhitespaceCB.Checked;
            _RightToLeft = RightToLeftCB.Checked;
            _ECMAScript = ECMAScriptCB.Checked;
            _CultureInvariant = CultureInvariantCB.Checked;
        }

        void restoreState()
        {
             NoneCB.Checked = _None;
             IgnoreCaseCB.Checked = _IgnoreCase;
             MultilineCB.Checked = _Multiline;
             ExplicitCaptureCB.Checked = _ExplicitCapture;
             CompiledCB.Checked = _Compiled;
             SinglelineCB.Checked = _Singleline;
             IgnorePatternWhitespaceCB.Checked = _IgnorePatternWhitespace;
             RightToLeftCB.Checked = _RightToLeft;
             ECMAScriptCB.Checked = _ECMAScript;
             CultureInvariantCB.Checked = _CultureInvariant;
        }

        bool _None;
        bool _IgnoreCase;
        bool _Multiline;
        bool _ExplicitCapture;
        bool _Compiled;
        bool _Singleline;
        bool _IgnorePatternWhitespace;
        bool _RightToLeft;
        bool _ECMAScript;
        bool _CultureInvariant;

        private void tryBT_Click(object sender, EventArgs e)
        {
            MessageBox.Show("抱歉，本功能尚未完成 :)");
        }

        private void referenceLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Shell.Open(@"http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regexoptions.aspx");
        }
    }
}
