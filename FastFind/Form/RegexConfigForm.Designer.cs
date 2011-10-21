namespace FastFind
{
    partial class RegexConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegexConfigForm));
            this.NoneCB = new System.Windows.Forms.CheckBox();
            this.IgnoreCaseCB = new System.Windows.Forms.CheckBox();
            this.MultilineCB = new System.Windows.Forms.CheckBox();
            this.ExplicitCaptureCB = new System.Windows.Forms.CheckBox();
            this.CompiledCB = new System.Windows.Forms.CheckBox();
            this.SinglelineCB = new System.Windows.Forms.CheckBox();
            this.IgnorePatternWhitespaceCB = new System.Windows.Forms.CheckBox();
            this.RightToLeftCB = new System.Windows.Forms.CheckBox();
            this.ECMAScriptCB = new System.Windows.Forms.CheckBox();
            this.CultureInvariantCB = new System.Windows.Forms.CheckBox();
            this.referenceLL = new System.Windows.Forms.LinkLabel();
            this.cancelBT = new System.Windows.Forms.Button();
            this.okBT = new System.Windows.Forms.Button();
            this.tryBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NoneCB
            // 
            this.NoneCB.AutoSize = true;
            this.NoneCB.Checked = true;
            this.NoneCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NoneCB.Location = new System.Drawing.Point(12, 24);
            this.NoneCB.Name = "NoneCB";
            this.NoneCB.Size = new System.Drawing.Size(48, 16);
            this.NoneCB.TabIndex = 0;
            this.NoneCB.Text = "None";
            this.NoneCB.UseVisualStyleBackColor = true;
            this.NoneCB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // IgnoreCaseCB
            // 
            this.IgnoreCaseCB.AutoSize = true;
            this.IgnoreCaseCB.Location = new System.Drawing.Point(12, 46);
            this.IgnoreCaseCB.Name = "IgnoreCaseCB";
            this.IgnoreCaseCB.Size = new System.Drawing.Size(84, 16);
            this.IgnoreCaseCB.TabIndex = 1;
            this.IgnoreCaseCB.Text = "IgnoreCase";
            this.IgnoreCaseCB.UseVisualStyleBackColor = true;
            this.IgnoreCaseCB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // MultilineCB
            // 
            this.MultilineCB.AutoSize = true;
            this.MultilineCB.Location = new System.Drawing.Point(102, 46);
            this.MultilineCB.Name = "MultilineCB";
            this.MultilineCB.Size = new System.Drawing.Size(78, 16);
            this.MultilineCB.TabIndex = 2;
            this.MultilineCB.Text = "Multiline";
            this.MultilineCB.UseVisualStyleBackColor = true;
            this.MultilineCB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // ExplicitCaptureCB
            // 
            this.ExplicitCaptureCB.AutoSize = true;
            this.ExplicitCaptureCB.Location = new System.Drawing.Point(186, 46);
            this.ExplicitCaptureCB.Name = "ExplicitCaptureCB";
            this.ExplicitCaptureCB.Size = new System.Drawing.Size(114, 16);
            this.ExplicitCaptureCB.TabIndex = 3;
            this.ExplicitCaptureCB.Text = "ExplicitCapture";
            this.ExplicitCaptureCB.UseVisualStyleBackColor = true;
            this.ExplicitCaptureCB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // CompiledCB
            // 
            this.CompiledCB.AutoSize = true;
            this.CompiledCB.Location = new System.Drawing.Point(306, 46);
            this.CompiledCB.Name = "CompiledCB";
            this.CompiledCB.Size = new System.Drawing.Size(72, 16);
            this.CompiledCB.TabIndex = 4;
            this.CompiledCB.Text = "Compiled";
            this.CompiledCB.UseVisualStyleBackColor = true;
            this.CompiledCB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // SinglelineCB
            // 
            this.SinglelineCB.AutoSize = true;
            this.SinglelineCB.Location = new System.Drawing.Point(396, 46);
            this.SinglelineCB.Name = "SinglelineCB";
            this.SinglelineCB.Size = new System.Drawing.Size(84, 16);
            this.SinglelineCB.TabIndex = 5;
            this.SinglelineCB.Text = "Singleline";
            this.SinglelineCB.UseVisualStyleBackColor = true;
            this.SinglelineCB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // IgnorePatternWhitespaceCB
            // 
            this.IgnorePatternWhitespaceCB.AutoSize = true;
            this.IgnorePatternWhitespaceCB.Location = new System.Drawing.Point(12, 68);
            this.IgnorePatternWhitespaceCB.Name = "IgnorePatternWhitespaceCB";
            this.IgnorePatternWhitespaceCB.Size = new System.Drawing.Size(162, 16);
            this.IgnorePatternWhitespaceCB.TabIndex = 6;
            this.IgnorePatternWhitespaceCB.Text = "IgnorePatternWhitespace";
            this.IgnorePatternWhitespaceCB.UseVisualStyleBackColor = true;
            this.IgnorePatternWhitespaceCB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // RightToLeftCB
            // 
            this.RightToLeftCB.AutoSize = true;
            this.RightToLeftCB.Location = new System.Drawing.Point(186, 68);
            this.RightToLeftCB.Name = "RightToLeftCB";
            this.RightToLeftCB.Size = new System.Drawing.Size(90, 16);
            this.RightToLeftCB.TabIndex = 7;
            this.RightToLeftCB.Text = "RightToLeft";
            this.RightToLeftCB.UseVisualStyleBackColor = true;
            this.RightToLeftCB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // ECMAScriptCB
            // 
            this.ECMAScriptCB.AutoSize = true;
            this.ECMAScriptCB.Location = new System.Drawing.Point(306, 68);
            this.ECMAScriptCB.Name = "ECMAScriptCB";
            this.ECMAScriptCB.Size = new System.Drawing.Size(84, 16);
            this.ECMAScriptCB.TabIndex = 8;
            this.ECMAScriptCB.Text = "ECMAScript";
            this.ECMAScriptCB.UseVisualStyleBackColor = true;
            this.ECMAScriptCB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // CultureInvariantCB
            // 
            this.CultureInvariantCB.AutoSize = true;
            this.CultureInvariantCB.Location = new System.Drawing.Point(396, 68);
            this.CultureInvariantCB.Name = "CultureInvariantCB";
            this.CultureInvariantCB.Size = new System.Drawing.Size(120, 16);
            this.CultureInvariantCB.TabIndex = 9;
            this.CultureInvariantCB.Text = "CultureInvariant";
            this.CultureInvariantCB.UseVisualStyleBackColor = true;
            this.CultureInvariantCB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // referenceLL
            // 
            this.referenceLL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.referenceLL.AutoSize = true;
            this.referenceLL.LinkColor = System.Drawing.Color.Gray;
            this.referenceLL.Location = new System.Drawing.Point(348, 9);
            this.referenceLL.Name = "referenceLL";
            this.referenceLL.Size = new System.Drawing.Size(173, 12);
            this.referenceLL.TabIndex = 10;
            this.referenceLL.TabStop = true;
            this.referenceLL.Text = "不明白这些选项？查阅官方资料";
            this.referenceLL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.referenceLL_LinkClicked);
            // 
            // cancelBT
            // 
            this.cancelBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBT.Location = new System.Drawing.Point(446, 115);
            this.cancelBT.Name = "cancelBT";
            this.cancelBT.Size = new System.Drawing.Size(75, 23);
            this.cancelBT.TabIndex = 11;
            this.cancelBT.Text = "取消";
            this.cancelBT.UseVisualStyleBackColor = true;
            this.cancelBT.Click += new System.EventHandler(this.cancelBT_Click);
            // 
            // okBT
            // 
            this.okBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBT.Location = new System.Drawing.Point(365, 115);
            this.okBT.Name = "okBT";
            this.okBT.Size = new System.Drawing.Size(75, 23);
            this.okBT.TabIndex = 12;
            this.okBT.Text = "确定";
            this.okBT.UseVisualStyleBackColor = true;
            this.okBT.Click += new System.EventHandler(this.okBT_Click);
            // 
            // tryBT
            // 
            this.tryBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tryBT.Location = new System.Drawing.Point(12, 115);
            this.tryBT.Name = "tryBT";
            this.tryBT.Size = new System.Drawing.Size(102, 23);
            this.tryBT.TabIndex = 13;
            this.tryBT.Text = "动手实验";
            this.tryBT.UseVisualStyleBackColor = true;
            this.tryBT.Click += new System.EventHandler(this.tryBT_Click);
            // 
            // RegexConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 150);
            this.Controls.Add(this.tryBT);
            this.Controls.Add(this.okBT);
            this.Controls.Add(this.cancelBT);
            this.Controls.Add(this.referenceLL);
            this.Controls.Add(this.CultureInvariantCB);
            this.Controls.Add(this.ECMAScriptCB);
            this.Controls.Add(this.RightToLeftCB);
            this.Controls.Add(this.IgnorePatternWhitespaceCB);
            this.Controls.Add(this.SinglelineCB);
            this.Controls.Add(this.CompiledCB);
            this.Controls.Add(this.ExplicitCaptureCB);
            this.Controls.Add(this.MultilineCB);
            this.Controls.Add(this.IgnoreCaseCB);
            this.Controls.Add(this.NoneCB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(549, 188);
            this.MinimumSize = new System.Drawing.Size(549, 188);
            this.Name = "RegexConfigForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "正则表达式选项";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegexConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.RegexConfigForm_Load);
            this.Shown += new System.EventHandler(this.RegexConfigForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox NoneCB;
        private System.Windows.Forms.CheckBox IgnoreCaseCB;
        private System.Windows.Forms.CheckBox MultilineCB;
        private System.Windows.Forms.CheckBox ExplicitCaptureCB;
        private System.Windows.Forms.CheckBox CompiledCB;
        private System.Windows.Forms.CheckBox SinglelineCB;
        private System.Windows.Forms.CheckBox IgnorePatternWhitespaceCB;
        private System.Windows.Forms.CheckBox RightToLeftCB;
        private System.Windows.Forms.CheckBox ECMAScriptCB;
        private System.Windows.Forms.CheckBox CultureInvariantCB;
        private System.Windows.Forms.LinkLabel referenceLL;
        private System.Windows.Forms.Button cancelBT;
        private System.Windows.Forms.Button okBT;
        private System.Windows.Forms.Button tryBT;
    }
}