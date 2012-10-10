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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckDigestInfo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.opt2 = new System.Windows.Forms.RadioButton();
            this.opt1 = new System.Windows.Forms.RadioButton();
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
            this.techlinkErrorProvider1 = new ECustoms.Utilities.TechlinkErrorProvider();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.viewVehicleFreightTableAdapter1 = new ECustoms.DataSet2TableAdapters.ViewVehicleFreightTableAdapter();
            this.cachedXuatCanhXeKhong1 = new ECustoms.CachedXuatCanhXeKhong();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.techlinkErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.opt2);
            this.groupBox1.Controls.Add(this.opt1);
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
            this.groupBox1.Size = new System.Drawing.Size(454, 290);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "+";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(110, 193);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(78, 22);
            this.txtCode.TabIndex = 13;
            this.txtCode.Tag = "required";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "Mã đơn vị:";
            // 
            // opt2
            // 
            this.opt2.AutoSize = true;
            this.opt2.Checked = true;
            this.opt2.Location = new System.Drawing.Point(240, 257);
            this.opt2.Name = "opt2";
            this.opt2.Size = new System.Drawing.Size(187, 18);
            this.opt2.TabIndex = 16;
            this.opt2.TabStop = true;
            this.opt2.Text = "Đơn vị sử dụng là cấp Chi Cục";
            this.opt2.UseVisualStyleBackColor = true;
            // 
            // opt1
            // 
            this.opt1.AutoSize = true;
            this.opt1.Location = new System.Drawing.Point(24, 257);
            this.opt1.Name = "opt1";
            this.opt1.Size = new System.Drawing.Size(167, 18);
            this.opt1.TabIndex = 15;
            this.opt1.Text = "Đơn vị sử dụng là cấp Cục";
            this.opt1.UseVisualStyleBackColor = true;
            // 
            // chkUserOnlineErrorChecker
            // 
            this.chkUserOnlineErrorChecker.AutoSize = true;
            this.chkUserOnlineErrorChecker.Location = new System.Drawing.Point(24, 232);
            this.chkUserOnlineErrorChecker.Name = "chkUserOnlineErrorChecker";
            this.chkUserOnlineErrorChecker.Size = new System.Drawing.Size(255, 18);
            this.chkUserOnlineErrorChecker.TabIndex = 14;
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
            // techlinkErrorProvider1
            // 
            this.techlinkErrorProvider1.ContainerControl = this;
            // 
            // btnAccept
            // 
            this.btnAccept.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAccept.Image = global::ECustoms.Properties.Resources.accept;
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccept.Location = new System.Drawing.Point(294, 311);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(70, 28);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Đồn&g ý";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClose.Image = global::ECustoms.Properties.Resources.Exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(372, 311);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đăng ký sa&u";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // viewVehicleFreightTableAdapter1
            // 
            this.viewVehicleFreightTableAdapter1.ClearBeforeFill = true;
            // 
            // frmCheckDigestInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(486, 354);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheckDigestInfo";
            this.ShowInTaskbar = false;
            this.Text = "Đăng ký thông tin sử dụng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCheckDigestInfo_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.techlinkErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
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
        private Utilities.TechlinkErrorProvider techlinkErrorProvider1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.RadioButton opt2;
        private System.Windows.Forms.RadioButton opt1;
        private DataSet2TableAdapters.ViewVehicleFreightTableAdapter viewVehicleFreightTableAdapter1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label7;
        private CachedXuatCanhXeKhong cachedXuatCanhXeKhong1;
    }
}