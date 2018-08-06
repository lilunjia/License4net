namespace Tool_MachineCode
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxAuthorizeType = new System.Windows.Forms.ComboBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxAuthorizeType
            // 
            this.cbxAuthorizeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAuthorizeType.FormattingEnabled = true;
            this.cbxAuthorizeType.Items.AddRange(new object[] {
            "CPU序列号",
            "硬盘序列号",
            "网卡Mac地址"});
            this.cbxAuthorizeType.Location = new System.Drawing.Point(54, 52);
            this.cbxAuthorizeType.Name = "cbxAuthorizeType";
            this.cbxAuthorizeType.Size = new System.Drawing.Size(241, 26);
            this.cbxAuthorizeType.TabIndex = 0;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(54, 105);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(390, 252);
            this.txtContent.TabIndex = 1;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(356, 52);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(88, 33);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "查询";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 405);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.cbxAuthorizeType);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "机器码生成器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxAuthorizeType;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnGenerate;
    }
}

