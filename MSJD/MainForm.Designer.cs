
namespace MSJD
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.ServerTypeCombo = new System.Windows.Forms.ComboBox();
            this.VersionCombo = new System.Windows.Forms.ComboBox();
            this.BuildCombo = new System.Windows.Forms.ComboBox();
            this.downloadBtn = new System.Windows.Forms.Button();
            this.downloadProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Download Server Jar";
            // 
            // ServerTypeCombo
            // 
            this.ServerTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerTypeCombo.FormattingEnabled = true;
            this.ServerTypeCombo.Location = new System.Drawing.Point(12, 89);
            this.ServerTypeCombo.Name = "ServerTypeCombo";
            this.ServerTypeCombo.Size = new System.Drawing.Size(261, 20);
            this.ServerTypeCombo.TabIndex = 1;
            this.ServerTypeCombo.SelectedIndexChanged += new System.EventHandler(this.ServerTypeCombo_SelectedIndexChanged);
            // 
            // VersionCombo
            // 
            this.VersionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VersionCombo.FormattingEnabled = true;
            this.VersionCombo.Location = new System.Drawing.Point(12, 138);
            this.VersionCombo.Name = "VersionCombo";
            this.VersionCombo.Size = new System.Drawing.Size(261, 20);
            this.VersionCombo.TabIndex = 2;
            this.VersionCombo.SelectedIndexChanged += new System.EventHandler(this.VersionCombo_SelectedIndexChanged);
            // 
            // BuildCombo
            // 
            this.BuildCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BuildCombo.FormattingEnabled = true;
            this.BuildCombo.Location = new System.Drawing.Point(12, 189);
            this.BuildCombo.Name = "BuildCombo";
            this.BuildCombo.Size = new System.Drawing.Size(261, 20);
            this.BuildCombo.TabIndex = 3;
            this.BuildCombo.SelectedIndexChanged += new System.EventHandler(this.BuildCombo_SelectedIndexChanged);
            // 
            // downloadBtn
            // 
            this.downloadBtn.Location = new System.Drawing.Point(12, 237);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(261, 23);
            this.downloadBtn.TabIndex = 4;
            this.downloadBtn.Text = "Download";
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // downloadProgress
            // 
            this.downloadProgress.Location = new System.Drawing.Point(12, 289);
            this.downloadProgress.Name = "downloadProgress";
            this.downloadProgress.Size = new System.Drawing.Size(261, 23);
            this.downloadProgress.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.downloadProgress);
            this.Controls.Add(this.downloadBtn);
            this.Controls.Add(this.BuildCombo);
            this.Controls.Add(this.VersionCombo);
            this.Controls.Add(this.ServerTypeCombo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MSJD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ServerTypeCombo;
        private System.Windows.Forms.ComboBox VersionCombo;
        private System.Windows.Forms.ComboBox BuildCombo;
        private System.Windows.Forms.Button downloadBtn;
        private System.Windows.Forms.ProgressBar downloadProgress;
    }
}

