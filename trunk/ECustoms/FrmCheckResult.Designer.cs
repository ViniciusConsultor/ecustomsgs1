namespace ECustoms
{
    partial class FrmCheckResult
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckResult));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdVehicleCheck = new System.Windows.Forms.DataGridView();
            this.InputByName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecievedByName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckByName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleCheckID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlateNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxDeclarationType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDeclarationNumber = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlateNumber = new System.Windows.Forms.TextBox();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpCheckTo = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckFrom = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblDeclaraceNumber = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.bntUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicleCheck)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.grdVehicleCheck);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1079, 331);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng hợp thông tin kiểm tra";
            // 
            // grdVehicleCheck
            // 
            this.grdVehicleCheck.AllowUserToAddRows = false;
            this.grdVehicleCheck.AllowUserToDeleteRows = false;
            this.grdVehicleCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVehicleCheck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InputByName,
            this.RecievedByName,
            this.CheckByName,
            this.CheckCode,
            this.Result,
            this.CheckFrom,
            this.CheckTo,
            this.VehicleCheckID,
            this.Number,
            this.CompanyCode,
            this.PlateNumber,
            this.VehicleID,
            this.ExportDate,
            this.ImportDate});
            this.grdVehicleCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVehicleCheck.Location = new System.Drawing.Point(3, 22);
            this.grdVehicleCheck.MultiSelect = false;
            this.grdVehicleCheck.Name = "grdVehicleCheck";
            this.grdVehicleCheck.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdVehicleCheck.Size = new System.Drawing.Size(1073, 306);
            this.grdVehicleCheck.TabIndex = 19;
            this.grdVehicleCheck.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdVehicleCheck_CellMouseDoubleClick);
            // 
            // InputByName
            // 
            this.InputByName.DataPropertyName = "InputByName";
            this.InputByName.HeaderText = "Người nhập thông tin";
            this.InputByName.Name = "InputByName";
            this.InputByName.Width = 200;
            // 
            // RecievedByName
            // 
            this.RecievedByName.DataPropertyName = "RecievedByName";
            this.RecievedByName.HeaderText = "Người nhận thông tin";
            this.RecievedByName.Name = "RecievedByName";
            this.RecievedByName.Width = 190;
            // 
            // CheckByName
            // 
            this.CheckByName.DataPropertyName = "CheckByName";
            this.CheckByName.HeaderText = "Người kiểm tra";
            this.CheckByName.Name = "CheckByName";
            this.CheckByName.Visible = false;
            // 
            // CheckCode
            // 
            this.CheckCode.DataPropertyName = "CheckCode";
            this.CheckCode.HeaderText = "Mã kiểm tra";
            this.CheckCode.Name = "CheckCode";
            this.CheckCode.Width = 120;
            // 
            // Result
            // 
            this.Result.DataPropertyName = "Result";
            this.Result.HeaderText = "Kết quả kiểm tra";
            this.Result.Name = "Result";
            this.Result.Width = 170;
            // 
            // CheckFrom
            // 
            this.CheckFrom.DataPropertyName = "CheckFrom";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.CheckFrom.DefaultCellStyle = dataGridViewCellStyle1;
            this.CheckFrom.HeaderText = "Thời hạn bắt đầu";
            this.CheckFrom.Name = "CheckFrom";
            this.CheckFrom.Width = 170;
            // 
            // CheckTo
            // 
            this.CheckTo.DataPropertyName = "CheckTo";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            dataGridViewCellStyle2.NullValue = null;
            this.CheckTo.DefaultCellStyle = dataGridViewCellStyle2;
            this.CheckTo.HeaderText = "Thời hạn kết thúc";
            this.CheckTo.Name = "CheckTo";
            this.CheckTo.Width = 170;
            // 
            // VehicleCheckID
            // 
            this.VehicleCheckID.DataPropertyName = "VehicleCheckID";
            this.VehicleCheckID.HeaderText = "VehicleCheckID";
            this.VehicleCheckID.Name = "VehicleCheckID";
            this.VehicleCheckID.ReadOnly = true;
            this.VehicleCheckID.Visible = false;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "Number";
            this.Number.HeaderText = "Số tờ khai";
            this.Number.Name = "Number";
            this.Number.Width = 120;
            // 
            // CompanyCode
            // 
            this.CompanyCode.DataPropertyName = "CompanyCode";
            this.CompanyCode.HeaderText = "Mã doanh nghiệp";
            this.CompanyCode.Name = "CompanyCode";
            this.CompanyCode.Width = 170;
            // 
            // PlateNumber
            // 
            this.PlateNumber.DataPropertyName = "PlateNumber";
            this.PlateNumber.HeaderText = "Biển kiểm soát";
            this.PlateNumber.Name = "PlateNumber";
            this.PlateNumber.Width = 150;
            // 
            // VehicleID
            // 
            this.VehicleID.DataPropertyName = "VehicleID";
            this.VehicleID.HeaderText = "VehicleID";
            this.VehicleID.Name = "VehicleID";
            this.VehicleID.Visible = false;
            // 
            // ExportDate
            // 
            this.ExportDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ExportDate.DataPropertyName = "ExportDate";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy hh:mm";
            dataGridViewCellStyle3.NullValue = null;
            this.ExportDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.ExportDate.HeaderText = "Ngày xuất cảnh";
            this.ExportDate.Name = "ExportDate";
            this.ExportDate.Width = 131;
            // 
            // ImportDate
            // 
            this.ImportDate.DataPropertyName = "ImportDate";
            dataGridViewCellStyle4.Format = "dd/MM/yyyy hh:mm";
            dataGridViewCellStyle4.NullValue = null;
            this.ImportDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.ImportDate.HeaderText = "Ngày nhập cảnh";
            this.ImportDate.Name = "ImportDate";
            this.ImportDate.Width = 200;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxDeclarationType);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDeclarationNumber);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtCode);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPlateNumber);
            this.groupBox2.Controls.Add(this.txtCompanyCode);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtpCheckTo);
            this.groupBox2.Controls.Add(this.dtpCheckFrom);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.lblCompanyName);
            this.groupBox2.Controls.Add(this.lblDeclaraceNumber);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1076, 97);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Điều kiện tìm kiếm";
            // 
            // comboBoxDeclarationType
            // 
            this.comboBoxDeclarationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDeclarationType.FormattingEnabled = true;
            this.comboBoxDeclarationType.Items.AddRange(new object[] {
            "------",
            "Loại hình xuật",
            "Loại hình nhập",
            "Cả xuất và nhập"});
            this.comboBoxDeclarationType.Location = new System.Drawing.Point(870, 17);
            this.comboBoxDeclarationType.Name = "comboBoxDeclarationType";
            this.comboBoxDeclarationType.Size = new System.Drawing.Size(128, 28);
            this.comboBoxDeclarationType.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(781, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "Loại hình";
            // 
            // txtDeclarationNumber
            // 
            this.txtDeclarationNumber.Location = new System.Drawing.Point(670, 19);
            this.txtDeclarationNumber.Mask = "0000000000";
            this.txtDeclarationNumber.Name = "txtDeclarationNumber";
            this.txtDeclarationNumber.Size = new System.Drawing.Size(95, 26);
            this.txtDeclarationNumber.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(535, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Số tờ khai";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(391, 20);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(128, 26);
            this.txtCode.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Mã kiểm tra";
            // 
            // txtPlateNumber
            // 
            this.txtPlateNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlateNumber.Location = new System.Drawing.Point(391, 53);
            this.txtPlateNumber.Name = "txtPlateNumber";
            this.txtPlateNumber.Size = new System.Drawing.Size(128, 26);
            this.txtPlateNumber.TabIndex = 16;
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.Location = new System.Drawing.Point(670, 53);
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.Size = new System.Drawing.Size(95, 26);
            this.txtCompanyCode.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(535, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mã doanh nghiệp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Biển kiểm soát";
            // 
            // dtpCheckTo
            // 
            this.dtpCheckTo.CustomFormat = "dd/MM/yyyy";
            this.dtpCheckTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCheckTo.Location = new System.Drawing.Point(144, 54);
            this.dtpCheckTo.Name = "dtpCheckTo";
            this.dtpCheckTo.Size = new System.Drawing.Size(122, 26);
            this.dtpCheckTo.TabIndex = 12;
            // 
            // dtpCheckFrom
            // 
            this.dtpCheckFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpCheckFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCheckFrom.Location = new System.Drawing.Point(144, 19);
            this.dtpCheckFrom.Name = "dtpCheckFrom";
            this.dtpCheckFrom.Size = new System.Drawing.Size(122, 26);
            this.dtpCheckFrom.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::ECustoms.Properties.Resources.search;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(870, 52);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(128, 28);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(6, 61);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(131, 20);
            this.lblCompanyName.TabIndex = 2;
            this.lblCompanyName.Text = "Thời hạn kết thúc";
            // 
            // lblDeclaraceNumber
            // 
            this.lblDeclaraceNumber.AutoSize = true;
            this.lblDeclaraceNumber.Location = new System.Drawing.Point(6, 24);
            this.lblDeclaraceNumber.Name = "lblDeclaraceNumber";
            this.lblDeclaraceNumber.Size = new System.Drawing.Size(132, 20);
            this.lblDeclaraceNumber.TabIndex = 0;
            this.lblDeclaraceNumber.Text = "Thời hạn bắt đầu ";
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::ECustoms.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(939, 449);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(67, 28);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // bntUpdate
            // 
            this.bntUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bntUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntUpdate.Image = global::ECustoms.Properties.Resources.edit;
            this.bntUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntUpdate.Location = new System.Drawing.Point(834, 449);
            this.bntUpdate.Name = "bntUpdate";
            this.bntUpdate.Size = new System.Drawing.Size(99, 28);
            this.bntUpdate.TabIndex = 23;
            this.bntUpdate.Text = "Cập nhật";
            this.bntUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntUpdate.UseVisualStyleBackColor = true;
            this.bntUpdate.Click += new System.EventHandler(this.bntUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ECustoms.Properties.Resources.Exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1009, 449);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 28);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Thoát";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmCheckResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 498);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.bntUpdate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCheckResult";
            this.Text = "FrmCheckResult";
            this.Load += new System.EventHandler(this.FrmCheckResult_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicleCheck)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdVehicleCheck;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpCheckTo;
        private System.Windows.Forms.DateTimePicker dtpCheckFrom;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblDeclaraceNumber;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button bntUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCompanyCode;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.MaskedTextBox txtDeclarationNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxDeclarationType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputByName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecievedByName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckByName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleCheckID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlateNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExportDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportDate;
    }
}