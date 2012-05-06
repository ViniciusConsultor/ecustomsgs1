﻿namespace ECustoms
{
    partial class frmGetFee
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetFee));
            this.grbConditionSearch = new System.Windows.Forms.GroupBox();
            this.txtReceiptNumber = new System.Windows.Forms.TextBox();
            this.lblPlateNumberChinese = new System.Windows.Forms.Label();
            this.txtPlateNumber = new System.Windows.Forms.TextBox();
            this.lblPlateNumber = new System.Windows.Forms.Label();
            this.grbResult = new System.Windows.Forms.GroupBox();
            this.grdVehicle = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpParkingDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpParkingDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblParkingDateTo = new System.Windows.Forms.Label();
            this.lblParkingDateFrom = new System.Windows.Forms.Label();
            this.PlateNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfContainer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parkingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfirmExportByName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfirmImportByName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFeeImport = new System.Windows.Forms.Button();
            this.btnUpdateVehicle = new System.Windows.Forms.Button();
            this.btnFeeExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grbConditionSearch.SuspendLayout();
            this.grbResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicle)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbConditionSearch
            // 
            this.grbConditionSearch.Controls.Add(this.dtpParkingDateTo);
            this.grbConditionSearch.Controls.Add(this.dtpParkingDateFrom);
            this.grbConditionSearch.Controls.Add(this.lblParkingDateTo);
            this.grbConditionSearch.Controls.Add(this.lblParkingDateFrom);
            this.grbConditionSearch.Controls.Add(this.txtReceiptNumber);
            this.grbConditionSearch.Controls.Add(this.lblPlateNumberChinese);
            this.grbConditionSearch.Controls.Add(this.txtPlateNumber);
            this.grbConditionSearch.Controls.Add(this.lblPlateNumber);
            this.grbConditionSearch.Controls.Add(this.btnSearch);
            this.grbConditionSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbConditionSearch.Location = new System.Drawing.Point(12, 12);
            this.grbConditionSearch.Name = "grbConditionSearch";
            this.grbConditionSearch.Size = new System.Drawing.Size(896, 98);
            this.grbConditionSearch.TabIndex = 1;
            this.grbConditionSearch.TabStop = false;
            this.grbConditionSearch.Text = "Điều kiện tìm kiếm";
            // 
            // txtReceiptNumber
            // 
            this.txtReceiptNumber.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtReceiptNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReceiptNumber.Location = new System.Drawing.Point(128, 66);
            this.txtReceiptNumber.Name = "txtReceiptNumber";
            this.txtReceiptNumber.Size = new System.Drawing.Size(105, 26);
            this.txtReceiptNumber.TabIndex = 2;
            // 
            // lblPlateNumberChinese
            // 
            this.lblPlateNumberChinese.AutoSize = true;
            this.lblPlateNumberChinese.Location = new System.Drawing.Point(9, 66);
            this.lblPlateNumberChinese.Name = "lblPlateNumberChinese";
            this.lblPlateNumberChinese.Size = new System.Drawing.Size(82, 20);
            this.lblPlateNumberChinese.TabIndex = 21;
            this.lblPlateNumberChinese.Text = "Số biên lai";
            // 
            // txtPlateNumber
            // 
            this.txtPlateNumber.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtPlateNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlateNumber.Location = new System.Drawing.Point(128, 28);
            this.txtPlateNumber.Name = "txtPlateNumber";
            this.txtPlateNumber.Size = new System.Drawing.Size(105, 26);
            this.txtPlateNumber.TabIndex = 1;
            // 
            // lblPlateNumber
            // 
            this.lblPlateNumber.AutoSize = true;
            this.lblPlateNumber.Location = new System.Drawing.Point(9, 27);
            this.lblPlateNumber.Name = "lblPlateNumber";
            this.lblPlateNumber.Size = new System.Drawing.Size(113, 20);
            this.lblPlateNumber.TabIndex = 11;
            this.lblPlateNumber.Text = "Biển kiểm soát";
            // 
            // grbResult
            // 
            this.grbResult.Controls.Add(this.groupBox1);
            this.grbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbResult.Location = new System.Drawing.Point(12, 116);
            this.grbResult.Name = "grbResult";
            this.grbResult.Size = new System.Drawing.Size(901, 442);
            this.grbResult.TabIndex = 2;
            this.grbResult.TabStop = false;
            this.grbResult.Text = "Kết quả tìm kiếm";
            // 
            // grdVehicle
            // 
            this.grdVehicle.AllowUserToAddRows = false;
            this.grdVehicle.AllowUserToDeleteRows = false;
            this.grdVehicle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVehicle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlateNumber,
            this.DriverName,
            this.ExportDate,
            this.Importdate,
            this.NumberOfContainer,
            this.parking,
            this.parkingDate,
            this.Status,
            this.Note,
            this.ImportStatus,
            this.VehicleID,
            this.ConfirmExportByName,
            this.ConfirmImportByName});
            this.grdVehicle.Location = new System.Drawing.Point(11, 25);
            this.grdVehicle.Name = "grdVehicle";
            this.grdVehicle.ReadOnly = true;
            this.grdVehicle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdVehicle.Size = new System.Drawing.Size(868, 369);
            this.grdVehicle.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdVehicle);
            this.groupBox1.Location = new System.Drawing.Point(6, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(890, 400);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phương tiện";
            // 
            // dtpParkingDateTo
            // 
            this.dtpParkingDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpParkingDateTo.Enabled = false;
            this.dtpParkingDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpParkingDateTo.Location = new System.Drawing.Point(387, 64);
            this.dtpParkingDateTo.Name = "dtpParkingDateTo";
            this.dtpParkingDateTo.Size = new System.Drawing.Size(118, 26);
            this.dtpParkingDateTo.TabIndex = 4;
            // 
            // dtpParkingDateFrom
            // 
            this.dtpParkingDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpParkingDateFrom.Enabled = false;
            this.dtpParkingDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpParkingDateFrom.Location = new System.Drawing.Point(387, 28);
            this.dtpParkingDateFrom.Name = "dtpParkingDateFrom";
            this.dtpParkingDateFrom.Size = new System.Drawing.Size(118, 26);
            this.dtpParkingDateFrom.TabIndex = 3;
            // 
            // lblParkingDateTo
            // 
            this.lblParkingDateTo.AutoSize = true;
            this.lblParkingDateTo.Enabled = false;
            this.lblParkingDateTo.Location = new System.Drawing.Point(247, 66);
            this.lblParkingDateTo.Name = "lblParkingDateTo";
            this.lblParkingDateTo.Size = new System.Drawing.Size(134, 20);
            this.lblParkingDateTo.TabIndex = 24;
            this.lblParkingDateTo.Text = "Ngày vào bãi đến:";
            // 
            // lblParkingDateFrom
            // 
            this.lblParkingDateFrom.AutoSize = true;
            this.lblParkingDateFrom.Enabled = false;
            this.lblParkingDateFrom.Location = new System.Drawing.Point(239, 28);
            this.lblParkingDateFrom.Name = "lblParkingDateFrom";
            this.lblParkingDateFrom.Size = new System.Drawing.Size(121, 20);
            this.lblParkingDateFrom.TabIndex = 23;
            this.lblParkingDateFrom.Text = "Ngày vào bãi từ:";
            // 
            // PlateNumber
            // 
            this.PlateNumber.DataPropertyName = "PlateNumber";
            this.PlateNumber.HeaderText = "Biển kiểm soát";
            this.PlateNumber.Name = "PlateNumber";
            this.PlateNumber.ReadOnly = true;
            this.PlateNumber.Width = 140;
            // 
            // DriverName
            // 
            this.DriverName.DataPropertyName = "DriverName";
            this.DriverName.HeaderText = "Tên lái xe";
            this.DriverName.Name = "DriverName";
            this.DriverName.ReadOnly = true;
            // 
            // ExportDate
            // 
            this.ExportDate.DataPropertyName = "ExportDate";
            dataGridViewCellStyle4.Format = "dd/MM/yyyy hh:mm";
            this.ExportDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.ExportDate.HeaderText = "Ngày xuất cảnh";
            this.ExportDate.Name = "ExportDate";
            this.ExportDate.ReadOnly = true;
            this.ExportDate.Width = 150;
            // 
            // Importdate
            // 
            this.Importdate.DataPropertyName = "ImportDate";
            dataGridViewCellStyle5.Format = "dd/MM/yyyy hh:mm";
            this.Importdate.DefaultCellStyle = dataGridViewCellStyle5;
            this.Importdate.HeaderText = "Ngày nhập cảnh";
            this.Importdate.Name = "Importdate";
            this.Importdate.ReadOnly = true;
            this.Importdate.Width = 150;
            // 
            // NumberOfContainer
            // 
            this.NumberOfContainer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NumberOfContainer.DataPropertyName = "NumberOfContainer";
            this.NumberOfContainer.HeaderText = "Số container";
            this.NumberOfContainer.Name = "NumberOfContainer";
            this.NumberOfContainer.ReadOnly = true;
            this.NumberOfContainer.Width = 135;
            // 
            // parking
            // 
            this.parking.DataPropertyName = "parking";
            this.parking.HeaderText = "Hàng vào bãi";
            this.parking.Name = "parking";
            this.parking.ReadOnly = true;
            this.parking.Width = 140;
            // 
            // parkingDate
            // 
            this.parkingDate.DataPropertyName = "ParkingDate";
            dataGridViewCellStyle6.Format = "dd/MM/yyyy hh:mm";
            this.parkingDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.parkingDate.HeaderText = "Ngày vào bãi";
            this.parkingDate.Name = "parkingDate";
            this.parkingDate.ReadOnly = true;
            this.parkingDate.Width = 150;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Diễn giải";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 120;
            // 
            // Note
            // 
            this.Note.DataPropertyName = "Note";
            this.Note.HeaderText = "Ghi chú";
            this.Note.Name = "Note";
            this.Note.ReadOnly = true;
            this.Note.Width = 150;
            // 
            // ImportStatus
            // 
            this.ImportStatus.DataPropertyName = "ImportStatus";
            this.ImportStatus.HeaderText = "Trạng thái nhập cảnh";
            this.ImportStatus.Name = "ImportStatus";
            this.ImportStatus.ReadOnly = true;
            this.ImportStatus.Width = 200;
            // 
            // VehicleID
            // 
            this.VehicleID.DataPropertyName = "VehicleID";
            this.VehicleID.HeaderText = "VehicleID";
            this.VehicleID.Name = "VehicleID";
            this.VehicleID.ReadOnly = true;
            this.VehicleID.Visible = false;
            // 
            // ConfirmExportByName
            // 
            this.ConfirmExportByName.DataPropertyName = "ConfirmExportByName";
            this.ConfirmExportByName.HeaderText = "Người xác nhận xuất";
            this.ConfirmExportByName.Name = "ConfirmExportByName";
            this.ConfirmExportByName.ReadOnly = true;
            this.ConfirmExportByName.Width = 200;
            // 
            // ConfirmImportByName
            // 
            this.ConfirmImportByName.DataPropertyName = "ConfirmImportByName";
            this.ConfirmImportByName.HeaderText = "Người xác nhận nhập";
            this.ConfirmImportByName.Name = "ConfirmImportByName";
            this.ConfirmImportByName.ReadOnly = true;
            this.ConfirmImportByName.Width = 200;
            // 
            // btnFeeImport
            // 
            this.btnFeeImport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnFeeImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFeeImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeeImport.Image = ((System.Drawing.Image)(resources.GetObject("btnFeeImport.Image")));
            this.btnFeeImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFeeImport.Location = new System.Drawing.Point(171, 564);
            this.btnFeeImport.Name = "btnFeeImport";
            this.btnFeeImport.Size = new System.Drawing.Size(142, 33);
            this.btnFeeImport.TabIndex = 11;
            this.btnFeeImport.Text = "XN phí nhập";
            this.btnFeeImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFeeImport.UseVisualStyleBackColor = true;
            // 
            // btnUpdateVehicle
            // 
            this.btnUpdateVehicle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdateVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateVehicle.Image = global::ECustoms.Properties.Resources._001_45;
            this.btnUpdateVehicle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateVehicle.Location = new System.Drawing.Point(319, 564);
            this.btnUpdateVehicle.Name = "btnUpdateVehicle";
            this.btnUpdateVehicle.Size = new System.Drawing.Size(196, 33);
            this.btnUpdateVehicle.TabIndex = 12;
            this.btnUpdateVehicle.Text = "Cập nhật phương tiện";
            this.btnUpdateVehicle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateVehicle.UseVisualStyleBackColor = true;
            // 
            // btnFeeExport
            // 
            this.btnFeeExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnFeeExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFeeExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeeExport.Image = global::ECustoms.Properties.Resources._1336316540_document_export;
            this.btnFeeExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFeeExport.Location = new System.Drawing.Point(25, 564);
            this.btnFeeExport.Name = "btnFeeExport";
            this.btnFeeExport.Size = new System.Drawing.Size(140, 33);
            this.btnFeeExport.TabIndex = 10;
            this.btnFeeExport.Text = "XN phí xuất";
            this.btnFeeExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFeeExport.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ECustoms.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(521, 564);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 33);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Đóng";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::ECustoms.Properties.Resources.search41;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(530, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(118, 33);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // frmGetFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 603);
            this.Controls.Add(this.btnFeeImport);
            this.Controls.Add(this.btnUpdateVehicle);
            this.Controls.Add(this.btnFeeExport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grbResult);
            this.Controls.Add(this.grbConditionSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGetFee";
            this.Text = "frmGetFee";
            this.Load += new System.EventHandler(this.frmGetFee_Load);
            this.grbConditionSearch.ResumeLayout(false);
            this.grbConditionSearch.PerformLayout();
            this.grbResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbConditionSearch;
        private System.Windows.Forms.TextBox txtReceiptNumber;
        private System.Windows.Forms.Label lblPlateNumberChinese;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.Label lblPlateNumber;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox grbResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdVehicle;
        private System.Windows.Forms.Button btnUpdateVehicle;
        private System.Windows.Forms.Button btnFeeExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtpParkingDateTo;
        private System.Windows.Forms.DateTimePicker dtpParkingDateFrom;
        private System.Windows.Forms.Label lblParkingDateTo;
        private System.Windows.Forms.Label lblParkingDateFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlateNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExportDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfContainer;
        private System.Windows.Forms.DataGridViewTextBoxColumn parking;
        private System.Windows.Forms.DataGridViewTextBoxColumn parkingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfirmExportByName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfirmImportByName;
        private System.Windows.Forms.Button btnFeeImport;
    }
}