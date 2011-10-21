namespace FastFind
{
    partial class BuildCacheForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuildCacheForm));
            this.startBT = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.stopBT = new System.Windows.Forms.Button();
            this.rootPathTB = new System.Windows.Forms.TextBox();
            this.browseBT = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // startBT
            // 
            this.startBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startBT.Location = new System.Drawing.Point(427, 3);
            this.startBT.Name = "startBT";
            this.startBT.Size = new System.Drawing.Size(75, 23);
            this.startBT.TabIndex = 2;
            this.startBT.Text = "开始";
            this.startBT.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(0, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(421, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 3;
            // 
            // stopBT
            // 
            this.stopBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stopBT.Enabled = false;
            this.stopBT.Location = new System.Drawing.Point(508, 3);
            this.stopBT.Name = "stopBT";
            this.stopBT.Size = new System.Drawing.Size(75, 23);
            this.stopBT.TabIndex = 4;
            this.stopBT.Text = "停止";
            this.stopBT.UseVisualStyleBackColor = true;
            // 
            // rootPathTB
            // 
            this.rootPathTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rootPathTB.Location = new System.Drawing.Point(12, 11);
            this.rootPathTB.Name = "rootPathTB";
            this.rootPathTB.Size = new System.Drawing.Size(502, 21);
            this.rootPathTB.TabIndex = 5;
            this.rootPathTB.TextChanged += new System.EventHandler(this.rootPathTB_TextChanged);
            // 
            // browseBT
            // 
            this.browseBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseBT.Location = new System.Drawing.Point(520, 9);
            this.browseBT.Name = "browseBT";
            this.browseBT.Size = new System.Drawing.Size(75, 21);
            this.browseBT.TabIndex = 6;
            this.browseBT.Text = "浏览...";
            this.browseBT.UseVisualStyleBackColor = true;
            this.browseBT.Click += new System.EventHandler(this.browseBT_Click);
            // 
            // actionPanel
            // 
            this.actionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.actionPanel.Controls.Add(this.progressBar);
            this.actionPanel.Controls.Add(this.startBT);
            this.actionPanel.Controls.Add(this.stopBT);
            this.actionPanel.Location = new System.Drawing.Point(12, 33);
            this.actionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(583, 52);
            this.actionPanel.TabIndex = 7;
            // 
            // BuildCacheForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 78);
            this.Controls.Add(this.actionPanel);
            this.Controls.Add(this.browseBT);
            this.Controls.Add(this.rootPathTB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(621, 116);
            this.MinimumSize = new System.Drawing.Size(621, 116);
            this.Name = "BuildCacheForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "缓存生成";
            this.Load += new System.EventHandler(this.BuildCacheForm_Load);
            this.Shown += new System.EventHandler(this.BuildCacheForm_Shown);
            this.actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button startBT;
        public System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.Button stopBT;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        public System.Windows.Forms.TextBox rootPathTB;
        public System.Windows.Forms.Button browseBT;
        public System.Windows.Forms.Panel actionPanel;

    }
}