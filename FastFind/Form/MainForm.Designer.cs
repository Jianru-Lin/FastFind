namespace FastFind
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("完全匹配", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("匹配开头", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("匹配中间", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("匹配结尾", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("正则匹配", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.searchBT = new System.Windows.Forms.Button();
            this.resultLV = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.直接打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开所在位置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制文件路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startWithCB = new System.Windows.Forms.CheckBox();
            this.existCB = new System.Windows.Forms.CheckBox();
            this.endWithCB = new System.Windows.Forms.CheckBox();
            this.regexCB = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buildCacheLL = new System.Windows.Forms.LinkLabel();
            this.sameCB = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.regexConfigLL = new System.Windows.Forms.LinkLabel();
            this.clearCacheLL = new System.Windows.Forms.LinkLabel();
            this.filenameTB = new System.Windows.Forms.TextBox();
            this.whoLL = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchBT
            // 
            this.searchBT.Location = new System.Drawing.Point(12, 37);
            this.searchBT.Name = "searchBT";
            this.searchBT.Size = new System.Drawing.Size(121, 23);
            this.searchBT.TabIndex = 1;
            this.searchBT.Text = "查找";
            this.searchBT.UseVisualStyleBackColor = true;
            // 
            // resultLV
            // 
            this.resultLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.resultLV.ContextMenuStrip = this.contextMenuStrip;
            this.resultLV.FullRowSelect = true;
            listViewGroup6.Header = "完全匹配";
            listViewGroup6.Name = "Same";
            listViewGroup7.Header = "匹配开头";
            listViewGroup7.Name = "StartWith";
            listViewGroup8.Header = "匹配中间";
            listViewGroup8.Name = "Exist";
            listViewGroup9.Header = "匹配结尾";
            listViewGroup9.Name = "EndWith";
            listViewGroup10.Header = "正则匹配";
            listViewGroup10.Name = "Regex";
            this.resultLV.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup6,
            listViewGroup7,
            listViewGroup8,
            listViewGroup9,
            listViewGroup10});
            this.resultLV.Location = new System.Drawing.Point(12, 66);
            this.resultLV.Name = "resultLV";
            this.resultLV.Size = new System.Drawing.Size(760, 318);
            this.resultLV.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.resultLV.TabIndex = 2;
            this.resultLV.UseCompatibleStateImageBehavior = false;
            this.resultLV.View = System.Windows.Forms.View.Details;
            this.resultLV.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.resultLV_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "路径";
            this.columnHeader2.Width = 500;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.直接打开ToolStripMenuItem,
            this.打开所在位置ToolStripMenuItem,
            this.复制文件路径ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(158, 70);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // 直接打开ToolStripMenuItem
            // 
            this.直接打开ToolStripMenuItem.Name = "直接打开ToolStripMenuItem";
            this.直接打开ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.直接打开ToolStripMenuItem.Text = "直接打开";
            this.直接打开ToolStripMenuItem.Click += new System.EventHandler(this.直接打开ToolStripMenuItem_Click);
            // 
            // 打开所在位置ToolStripMenuItem
            // 
            this.打开所在位置ToolStripMenuItem.Name = "打开所在位置ToolStripMenuItem";
            this.打开所在位置ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.打开所在位置ToolStripMenuItem.Text = "打开所在位置...";
            this.打开所在位置ToolStripMenuItem.Click += new System.EventHandler(this.打开所在位置ToolStripMenuItem_Click);
            // 
            // 复制文件路径ToolStripMenuItem
            // 
            this.复制文件路径ToolStripMenuItem.Name = "复制文件路径ToolStripMenuItem";
            this.复制文件路径ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.复制文件路径ToolStripMenuItem.Text = "复制文件路径";
            this.复制文件路径ToolStripMenuItem.Click += new System.EventHandler(this.复制文件路径ToolStripMenuItem_Click);
            // 
            // startWithCB
            // 
            this.startWithCB.AutoSize = true;
            this.startWithCB.Checked = true;
            this.startWithCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.startWithCB.Location = new System.Drawing.Point(239, 42);
            this.startWithCB.Name = "startWithCB";
            this.startWithCB.Size = new System.Drawing.Size(72, 16);
            this.startWithCB.TabIndex = 3;
            this.startWithCB.Text = "匹配开头";
            this.startWithCB.UseVisualStyleBackColor = true;
            this.startWithCB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // existCB
            // 
            this.existCB.AutoSize = true;
            this.existCB.Location = new System.Drawing.Point(319, 42);
            this.existCB.Name = "existCB";
            this.existCB.Size = new System.Drawing.Size(72, 16);
            this.existCB.TabIndex = 4;
            this.existCB.Text = "匹配中间";
            this.existCB.UseVisualStyleBackColor = true;
            this.existCB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // endWithCB
            // 
            this.endWithCB.AutoSize = true;
            this.endWithCB.Location = new System.Drawing.Point(399, 42);
            this.endWithCB.Name = "endWithCB";
            this.endWithCB.Size = new System.Drawing.Size(72, 16);
            this.endWithCB.TabIndex = 5;
            this.endWithCB.Text = "匹配结尾";
            this.endWithCB.UseVisualStyleBackColor = true;
            this.endWithCB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // regexCB
            // 
            this.regexCB.AutoSize = true;
            this.regexCB.Location = new System.Drawing.Point(502, 42);
            this.regexCB.Name = "regexCB";
            this.regexCB.Size = new System.Drawing.Size(108, 16);
            this.regexCB.TabIndex = 6;
            this.regexCB.Text = "正则表达式匹配";
            this.regexCB.UseVisualStyleBackColor = true;
            this.regexCB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(479, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "|";
            // 
            // buildCacheLL
            // 
            this.buildCacheLL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buildCacheLL.AutoSize = true;
            this.buildCacheLL.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.buildCacheLL.LinkColor = System.Drawing.Color.Green;
            this.buildCacheLL.Location = new System.Drawing.Point(660, 43);
            this.buildCacheLL.Name = "buildCacheLL";
            this.buildCacheLL.Size = new System.Drawing.Size(77, 12);
            this.buildCacheLL.TabIndex = 8;
            this.buildCacheLL.TabStop = true;
            this.buildCacheLL.Text = "缓存数据生成";
            this.buildCacheLL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.buildCacheLL_LinkClicked);
            // 
            // sameCB
            // 
            this.sameCB.AutoSize = true;
            this.sameCB.Location = new System.Drawing.Point(139, 42);
            this.sameCB.Name = "sameCB";
            this.sameCB.Size = new System.Drawing.Size(72, 16);
            this.sameCB.TabIndex = 9;
            this.sameCB.Text = "完全匹配";
            this.sameCB.UseVisualStyleBackColor = true;
            this.sameCB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "|";
            // 
            // regexConfigLL
            // 
            this.regexConfigLL.AutoSize = true;
            this.regexConfigLL.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.regexConfigLL.LinkColor = System.Drawing.Color.Green;
            this.regexConfigLL.Location = new System.Drawing.Point(605, 43);
            this.regexConfigLL.Name = "regexConfigLL";
            this.regexConfigLL.Size = new System.Drawing.Size(29, 12);
            this.regexConfigLL.TabIndex = 11;
            this.regexConfigLL.TabStop = true;
            this.regexConfigLL.Text = "参数";
            this.regexConfigLL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.regexConfigLL_LinkClicked);
            // 
            // clearCacheLL
            // 
            this.clearCacheLL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearCacheLL.AutoSize = true;
            this.clearCacheLL.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.clearCacheLL.LinkColor = System.Drawing.Color.Green;
            this.clearCacheLL.Location = new System.Drawing.Point(743, 43);
            this.clearCacheLL.Name = "clearCacheLL";
            this.clearCacheLL.Size = new System.Drawing.Size(29, 12);
            this.clearCacheLL.TabIndex = 12;
            this.clearCacheLL.TabStop = true;
            this.clearCacheLL.Text = "清除";
            // 
            // filenameTB
            // 
            this.filenameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameTB.Location = new System.Drawing.Point(12, 10);
            this.filenameTB.Name = "filenameTB";
            this.filenameTB.Size = new System.Drawing.Size(760, 21);
            this.filenameTB.TabIndex = 14;
            this.filenameTB.TextChanged += new System.EventHandler(this.filenameTB_TextChanged);
            // 
            // whoLL
            // 
            this.whoLL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.whoLL.AutoSize = true;
            this.whoLL.LinkColor = System.Drawing.Color.Gray;
            this.whoLL.Location = new System.Drawing.Point(12, 387);
            this.whoLL.Name = "whoLL";
            this.whoLL.Size = new System.Drawing.Size(101, 12);
            this.whoLL.TabIndex = 15;
            this.whoLL.TabStop = true;
            this.whoLL.Text = "谁写了这个软件？";
            this.whoLL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.whoLL_LinkClicked);
            // 
            // MainForm
            // 
            this.AcceptButton = this.searchBT;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 408);
            this.Controls.Add(this.filenameTB);
            this.Controls.Add(this.whoLL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clearCacheLL);
            this.Controls.Add(this.sameCB);
            this.Controls.Add(this.regexConfigLL);
            this.Controls.Add(this.resultLV);
            this.Controls.Add(this.searchBT);
            this.Controls.Add(this.startWithCB);
            this.Controls.Add(this.regexCB);
            this.Controls.Add(this.existCB);
            this.Controls.Add(this.buildCacheLL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endWithCB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 446);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 直接打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开所在位置ToolStripMenuItem;
        public System.Windows.Forms.Button searchBT;
        public System.Windows.Forms.ListView resultLV;
        private System.Windows.Forms.ToolStripMenuItem 复制文件路径ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel buildCacheLL;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox startWithCB;
        public System.Windows.Forms.CheckBox existCB;
        public System.Windows.Forms.CheckBox endWithCB;
        public System.Windows.Forms.CheckBox regexCB;
        public System.Windows.Forms.CheckBox sameCB;
        private System.Windows.Forms.LinkLabel regexConfigLL;
        public System.Windows.Forms.LinkLabel clearCacheLL;
        public System.Windows.Forms.TextBox filenameTB;
        private System.Windows.Forms.LinkLabel whoLL;
    }
}

