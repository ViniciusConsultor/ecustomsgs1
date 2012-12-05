namespace ECustoms.Train
{
    partial class frmTrainPassengers
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.gbInfoTrain = new System.Windows.Forms.GroupBox();
            this.txtNumberStaff = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumberPersonForegin = new System.Windows.Forms.MaskedTextBox();
            this.txtNumberPersonVN = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJourney = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlTypeName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpRegisterDate = new System.Windows.Forms.DateTimePicker();
            this.txtNumberTrain = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.techlinkErrorProvider1 = new ECustoms.Utilities.TechlinkErrorProvider();
            this.gbInfoTrain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.techlinkErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblHeader.Location = new System.Drawing.Point(12, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(728, 24);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "Khai báo tàu khách XNK";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbInfoTrain
            // 
            this.gbInfoTrain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInfoTrain.Controls.Add(this.txtNumberStaff);
            this.gbInfoTrain.Controls.Add(this.label6);
            this.gbInfoTrain.Controls.Add(this.txtNumberPersonForegin);
            this.gbInfoTrain.Controls.Add(this.txtNumberPersonVN);
            this.gbInfoTrain.Controls.Add(this.label4);
            this.gbInfoTrain.Controls.Add(this.label3);
            this.gbInfoTrain.Controls.Add(this.txtJourney);
            this.gbInfoTrain.Controls.Add(this.label2);
            this.gbInfoTrain.Controls.Add(this.ddlTypeName);
            this.gbInfoTrain.Controls.Add(this.label5);
            this.gbInfoTrain.Controls.Add(this.dtpRegisterDate);
            this.gbInfoTrain.Controls.Add(this.txtNumberTrain);
            this.gbInfoTrain.Controls.Add(this.label1);
            this.gbInfoTrain.Controls.Add(this.lblNumber);
            this.gbInfoTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gbInfoTrain.Location = new System.Drawing.Point(12, 40);
            this.gbInfoTrain.Name = "gbInfoTrain";
            this.gbInfoTrain.Size = new System.Drawing.Size(728, 125);
            this.gbInfoTrain.TabIndex = 3;
            this.gbInfoTrain.TabStop = false;
            this.gbInfoTrain.Text = "Thông tin tàu khách XNK";
            // 
            // txtNumberStaff
            // 
            this.txtNumberStaff.Location = new System.Drawing.Point(580, 88);
            this.txtNumberStaff.Mask = "00000";
            this.txtNumberStaff.Name = "txtNumberStaff";
            this.txtNumberStaff.Size = new System.Drawing.Size(133, 20);
            this.txtNumberStaff.TabIndex = 49;
            this.txtNumberStaff.Tag = "required";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(490, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "Số NV tàu";
            // 
            // txtNumberPersonForegin
            // 
            this.txtNumberPersonForegin.Location = new System.Drawing.Point(348, 88);
            this.txtNumberPersonForegin.Mask = "00000";
            this.txtNumberPersonForegin.Name = "txtNumberPersonForegin";
            this.txtNumberPersonForegin.Size = new System.Drawing.Size(106, 20);
            this.txtNumberPersonForegin.TabIndex = 47;
            this.txtNumberPersonForegin.Tag = "required";
            // 
            // txtNumberPersonVN
            // 
            this.txtNumberPersonVN.Location = new System.Drawing.Point(108, 88);
            this.txtNumberPersonVN.Mask = "00000";
            this.txtNumberPersonVN.Name = "txtNumberPersonVN";
            this.txtNumberPersonVN.Size = new System.Drawing.Size(105, 20);
            this.txtNumberPersonVN.TabIndex = 46;
            this.txtNumberPersonVN.Tag = "required";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Số lượng HK NN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Số lượng HK VN";
            // 
            // txtJourney
            // 
            this.txtJourney.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtJourney.Location = new System.Drawing.Point(108, 55);
            this.txtJourney.Name = "txtJourney";
            this.txtJourney.Size = new System.Drawing.Size(605, 20);
            this.txtJourney.TabIndex = 41;
            this.txtJourney.Tag = "required";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Hành trình";
            // 
            // ddlTypeName
            // 
            this.ddlTypeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlTypeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlTypeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTypeName.FormattingEnabled = true;
            this.ddlTypeName.Location = new System.Drawing.Point(580, 25);
            this.ddlTypeName.Name = "ddlTypeName";
            this.ddlTypeName.Size = new System.Drawing.Size(133, 21);
            this.ddlTypeName.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(490, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Loại hình XNC";
            // 
            // dtpRegisterDate
            // 
            this.dtpRegisterDate.CustomFormat = "dd/MM/yyyy";
            this.dtpRegisterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRegisterDate.Location = new System.Drawing.Point(371, 26);
            this.dtpRegisterDate.Name = "dtpRegisterDate";
            this.dtpRegisterDate.Size = new System.Drawing.Size(83, 20);
            this.dtpRegisterDate.TabIndex = 5;
            // 
            // txtNumberTrain
            // 
            this.txtNumberTrain.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberTrain.Location = new System.Drawing.Point(108, 26);
            this.txtNumberTrain.Name = "txtNumberTrain";
            this.txtNumberTrain.Size = new System.Drawing.Size(142, 20);
            this.txtNumberTrain.TabIndex = 1;
            this.txtNumberTrain.Tag = "required";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ngày XNC";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(6, 29);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(89, 13);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "Số hiệu đoàn tàu";
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnDelete.Image = global::ECustoms.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(209, 180);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(53, 28);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "&Xóa";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAddNew
            // 
            this.btnAddNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAddNew.Image = global::ECustoms.Properties.Resources.add;
            this.btnAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNew.Location = new System.Drawing.Point(21, 180);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(83, 28);
            this.btnAddNew.TabIndex = 27;
            this.btnAddNew.Text = "&Thêm mới";
            this.btnAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClose.Image = global::ECustoms.Properties.Resources.Exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(290, 180);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 28);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Th&oát";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnUpdate.Image = global::ECustoms.Properties.Resources.save;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(126, 180);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(57, 28);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "&Lưu";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // techlinkErrorProvider1
            // 
            this.techlinkErrorProvider1.ContainerControl = this;
            // 
            // frmTrainPassengers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 226);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.gbInfoTrain);
            this.Controls.Add(this.lblHeader);
            this.Name = "frmTrainPassengers";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTrainPassengers";
            this.Load += new System.EventHandler(this.frmTrainPassengers_Load);
            this.gbInfoTrain.ResumeLayout(false);
            this.gbInfoTrain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.techlinkErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.GroupBox gbInfoTrain;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJourney;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlTypeName;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpRegisterDate;
        private System.Windows.Forms.TextBox txtNumberTrain;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.MaskedTextBox txtNumberStaff;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtNumberPersonForegin;
        private System.Windows.Forms.MaskedTextBox txtNumberPersonVN;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private Utilities.TechlinkErrorProvider techlinkErrorProvider1;
    }
}