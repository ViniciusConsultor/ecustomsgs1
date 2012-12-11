namespace ECustoms.Train
{
    partial class frmThemToaTau
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
            this.gbImportTrain = new System.Windows.Forms.GroupBox();
            this.txtSoVanDon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.techlinkErrorProvider1 = new ECustoms.Utilities.TechlinkErrorProvider();
            this.txtTenHang = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTrongLuong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSealVT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSealHQ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbImportTrain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.techlinkErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbImportTrain
            // 
            this.gbImportTrain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImportTrain.Controls.Add(this.txtSealHQ);
            this.gbImportTrain.Controls.Add(this.label5);
            this.gbImportTrain.Controls.Add(this.txtSealVT);
            this.gbImportTrain.Controls.Add(this.label4);
            this.gbImportTrain.Controls.Add(this.txtTrongLuong);
            this.gbImportTrain.Controls.Add(this.label3);
            this.gbImportTrain.Controls.Add(this.txtTenHang);
            this.gbImportTrain.Controls.Add(this.label1);
            this.gbImportTrain.Controls.Add(this.txtSoVanDon);
            this.gbImportTrain.Controls.Add(this.label2);
            this.gbImportTrain.Controls.Add(this.txtNumber);
            this.gbImportTrain.Controls.Add(this.lblNumber);
            this.gbImportTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gbImportTrain.Location = new System.Drawing.Point(12, 45);
            this.gbImportTrain.Name = "gbImportTrain";
            this.gbImportTrain.Size = new System.Drawing.Size(726, 129);
            this.gbImportTrain.TabIndex = 3;
            this.gbImportTrain.TabStop = false;
            this.gbImportTrain.Text = "Thông tin toa tàu";
            // 
            // txtSoVanDon
            // 
            this.txtSoVanDon.Location = new System.Drawing.Point(108, 57);
            this.txtSoVanDon.Name = "txtSoVanDon";
            this.txtSoVanDon.Size = new System.Drawing.Size(142, 20);
            this.txtSoVanDon.TabIndex = 41;
            this.txtSoVanDon.Tag = "required";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Số toa tàu";
            // 
            // txtNumber
            // 
            this.txtNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumber.Location = new System.Drawing.Point(108, 26);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(142, 20);
            this.txtNumber.TabIndex = 1;
            this.txtNumber.Tag = "required";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(6, 29);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(79, 13);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "Số hiệu toa tàu";
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblHeader.Location = new System.Drawing.Point(8, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(730, 24);
            this.lblHeader.TabIndex = 4;
            this.lblHeader.Text = "Khai báo toa tàu";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnDelete.TabIndex = 28;
            this.btnDelete.Text = "&Xóa";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnClose.Location = new System.Drawing.Point(287, 180);
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
            // txtTenHang
            // 
            this.txtTenHang.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTenHang.Location = new System.Drawing.Point(394, 26);
            this.txtTenHang.Name = "txtTenHang";
            this.txtTenHang.Size = new System.Drawing.Size(326, 20);
            this.txtTenHang.TabIndex = 43;
            this.txtTenHang.Tag = "required";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Tên hàng";
            // 
            // txtTrongLuong
            // 
            this.txtTrongLuong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTrongLuong.Location = new System.Drawing.Point(394, 57);
            this.txtTrongLuong.Name = "txtTrongLuong";
            this.txtTrongLuong.Size = new System.Drawing.Size(150, 20);
            this.txtTrongLuong.TabIndex = 45;
            this.txtTrongLuong.Tag = "required";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Trọng lượng";
            // 
            // txtSealVT
            // 
            this.txtSealVT.Location = new System.Drawing.Point(108, 88);
            this.txtSealVT.Name = "txtSealVT";
            this.txtSealVT.Size = new System.Drawing.Size(142, 20);
            this.txtSealVT.TabIndex = 47;
            this.txtSealVT.Tag = "required";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Số Seal hãng VT";
            // 
            // txtSealHQ
            // 
            this.txtSealHQ.Location = new System.Drawing.Point(394, 88);
            this.txtSealHQ.Name = "txtSealHQ";
            this.txtSealHQ.Size = new System.Drawing.Size(142, 20);
            this.txtSealHQ.TabIndex = 49;
            this.txtSealHQ.Tag = "required";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Số Seal Hải quan";
            // 
            // frmPartTrainExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 229);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.gbImportTrain);
            this.Name = "frmPartTrainExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmThemToaTau";
            this.Load += new System.EventHandler(this.frmPartTrainExport_Load);
            this.gbImportTrain.ResumeLayout(false);
            this.gbImportTrain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.techlinkErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbImportTrain;
        private System.Windows.Forms.TextBox txtNumber;
        public System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox txtSoVanDon;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private Utilities.TechlinkErrorProvider techlinkErrorProvider1;
        private System.Windows.Forms.TextBox txtSealHQ;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSealVT;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTrongLuong;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenHang;
        public System.Windows.Forms.Label label1;
    }
}