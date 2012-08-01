namespace ECustoms
{
    partial class frmBackupRestoreDb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackupRestoreDb));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optBackupAll = new System.Windows.Forms.RadioButton();
            this.optBackLatest = new System.Windows.Forms.RadioButton();
            this.btnBackup = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBrowseSavePath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowseSavePath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSavePath);
            this.groupBox1.Controls.Add(this.btnRestore);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Controls.Add(this.btnBackup);
            this.groupBox1.Controls.Add(this.optBackLatest);
            this.groupBox1.Controls.Add(this.optBackupAll);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 270);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "+";
            // 
            // optBackupAll
            // 
            this.optBackupAll.AutoSize = true;
            this.optBackupAll.Checked = true;
            this.optBackupAll.Location = new System.Drawing.Point(29, 32);
            this.optBackupAll.Name = "optBackupAll";
            this.optBackupAll.Size = new System.Drawing.Size(187, 18);
            this.optBackupAll.TabIndex = 0;
            this.optBackupAll.TabStop = true;
            this.optBackupAll.Text = "Sao lưu toàn bộ cơ sở dữ liệu";
            this.optBackupAll.UseVisualStyleBackColor = true;
            // 
            // optBackLatest
            // 
            this.optBackLatest.AutoSize = true;
            this.optBackLatest.Location = new System.Drawing.Point(29, 56);
            this.optBackLatest.Name = "optBackLatest";
            this.optBackLatest.Size = new System.Drawing.Size(251, 18);
            this.optBackLatest.TabIndex = 1;
            this.optBackLatest.Text = "Sao lưu những dữ liệu cập nhật mới nhất";
            this.optBackLatest.UseVisualStyleBackColor = true;
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.SystemColors.Control;
            this.btnBackup.Location = new System.Drawing.Point(219, 124);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(114, 23);
            this.btnBackup.TabIndex = 2;
            this.btnBackup.Text = "Bắt đầu sao lưu";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPath.Location = new System.Drawing.Point(29, 178);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(267, 22);
            this.txtPath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Thư mục lưu trữ:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.btnBrowse.Location = new System.Drawing.Point(302, 177);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(31, 23);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.SystemColors.Control;
            this.btnRestore.Location = new System.Drawing.Point(219, 206);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(114, 23);
            this.btnRestore.TabIndex = 6;
            this.btnRestore.Text = "Phục hồi dữ liệu";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBrowseSavePath
            // 
            this.btnBrowseSavePath.BackColor = System.Drawing.SystemColors.Control;
            this.btnBrowseSavePath.Location = new System.Drawing.Point(302, 95);
            this.btnBrowseSavePath.Name = "btnBrowseSavePath";
            this.btnBrowseSavePath.Size = new System.Drawing.Size(31, 23);
            this.btnBrowseSavePath.TabIndex = 9;
            this.btnBrowseSavePath.Text = "...";
            this.btnBrowseSavePath.UseVisualStyleBackColor = false;
            this.btnBrowseSavePath.Click += new System.EventHandler(this.btnBrowseSavePath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Thư mục lưu trữ:";
            // 
            // txtSavePath
            // 
            this.txtSavePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSavePath.Location = new System.Drawing.Point(29, 96);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.ReadOnly = true;
            this.txtSavePath.Size = new System.Drawing.Size(267, 22);
            this.txtSavePath.TabIndex = 7;
            // 
            // frmBackupRestoreDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(415, 300);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackupRestoreDb";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.ShowInTaskbar = false;
            this.Text = "Sao lưu Cơ sở dữ liệu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.RadioButton optBackLatest;
        private System.Windows.Forms.RadioButton optBackupAll;
        private System.Windows.Forms.Button btnBrowseSavePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSavePath;
    }
}