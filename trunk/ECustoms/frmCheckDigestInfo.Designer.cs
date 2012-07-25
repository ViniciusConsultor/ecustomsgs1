namespace ECustoms
{
    partial class frmCheckDigestInfo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUserOnlineErrorChecker = new System.Windows.Forms.CheckBox();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumberOfUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumberOfPc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnLater = new System.Windows.Forms.Button();
            this.techlinkErrorProvider1 = new ECustoms.Utilities.TechlinkErrorProvider();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.techlinkErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUserOnlineErrorChecker);
            this.groupBox1.Controls.Add(this.txtSerial);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNumberOfUser);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNumberOfPc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDomain);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUnitName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "+";
            // 
            // chkUserOnlineErrorChecker
            // 
            this.chkUserOnlineErrorChecker.AutoSize = true;
            this.chkUserOnlineErrorChecker.Location = new System.Drawing.Point(24, 197);
            this.chkUserOnlineErrorChecker.Name = "chkUserOnlineErrorChecker";
            this.chkUserOnlineErrorChecker.Size = new System.Drawing.Size(255, 18);
            this.chkUserOnlineErrorChecker.TabIndex = 12;
            this.chkUserOnlineErrorChecker.Text = "Sử dụng dịch vụ thông báo lỗi trực tuyến";
            this.chkUserOnlineErrorChecker.UseVisualStyleBackColor = true;
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(110, 165);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(317, 22);
            this.txtSerial.TabIndex = 11;
            this.txtSerial.Tag = "required";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Mã đăng ký:";
            // 
            // txtNumberOfUser
            // 
            this.txtNumberOfUser.Location = new System.Drawing.Point(276, 137);
            this.txtNumberOfUser.Name = "txtNumberOfUser";
            this.txtNumberOfUser.Size = new System.Drawing.Size(86, 22);
            this.txtNumberOfUser.TabIndex = 9;
            this.txtNumberOfUser.Tag = "required";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số người sử dụng tối đa trong hệ thống:";
            // 
            // txtNumberOfPc
            // 
            this.txtNumberOfPc.Location = new System.Drawing.Point(276, 109);
            this.txtNumberOfPc.Name = "txtNumberOfPc";
            this.txtNumberOfPc.Size = new System.Drawing.Size(86, 22);
            this.txtNumberOfPc.TabIndex = 7;
            this.txtNumberOfPc.Tag = "required";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số máy tối đa tham gia hệ thống:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(110, 81);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(317, 22);
            this.txtAddress.TabIndex = 5;
            this.txtAddress.Tag = "required";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Địa chỉ:";
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(110, 53);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(317, 22);
            this.txtDomain.TabIndex = 3;
            this.txtDomain.Tag = "required";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Domain:";
            // 
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(110, 24);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(317, 22);
            this.txtUnitName.TabIndex = 1;
            this.txtUnitName.Tag = "required";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đơn vị:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(392, 259);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Đồng ý";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnLater
            // 
            this.btnLater.Location = new System.Drawing.Point(289, 259);
            this.btnLater.Name = "btnLater";
            this.btnLater.Size = new System.Drawing.Size(86, 23);
            this.btnLater.TabIndex = 2;
            this.btnLater.Text = "Đăng ký sau";
            this.btnLater.UseVisualStyleBackColor = true;
            this.btnLater.Click += new System.EventHandler(this.btnLater_Click);
            // 
            // techlinkErrorProvider1
            // 
            this.techlinkErrorProvider1.ContainerControl = this;
            // 
            // frmCheckDigestInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 294);
            this.Controls.Add(this.btnLater);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheckDigestInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký thông tin sử dụng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCheckDigestInfo_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.techlinkErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumberOfUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumberOfPc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkUserOnlineErrorChecker;
        private System.Windows.Forms.Button btnLater;
        private Utilities.TechlinkErrorProvider techlinkErrorProvider1;
    }
}