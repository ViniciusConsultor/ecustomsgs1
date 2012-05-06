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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetFee));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbConditionSearch = new System.Windows.Forms.GroupBox();
            this.cbHasFeeExport = new System.Windows.Forms.CheckBox();
            this.dtpParkingDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpParkingDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblParkingDateTo = new System.Windows.Forms.Label();
            this.lblParkingDateFrom = new System.Windows.Forms.Label();
            this.txtReceiptNumber = new System.Windows.Forms.TextBox();
            this.lblPlateNumberChinese = new System.Windows.Forms.Label();
            this.txtPlateNumber = new System.Windows.Forms.TextBox();
            this.lblPlateNumber = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grbResult = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdVehicle = new System.Windows.Forms.DataGridView();
            this.btnFeeImport = new System.Windows.Forms.Button();
            this.btnUpdateVehicle = new System.Windows.Forms.Button();
            this.btnFeeExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.cbHasFeeImport = new System.Windows.Forms.CheckBox();
            this.grbConditionSearch.SuspendLayout();
            this.grbResult.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicle)).BeginInit();
            this.SuspendLayout();
            // 
            // grbConditionSearch
            // 
            this.grbConditionSearch.Controls.Add(this.cbHasFeeImport);
            this.grbConditionSearch.Controls.Add(this.cbHasFeeExport);
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
            this.grbConditionSearch.TabIndex = 0;
            this.grbConditionSearch.TabStop = false;
            this.grbConditionSearch.Text = "Điều kiện tìm kiếm";
            // 
            // cbHasFeeExport
            // 
            this.cbHasFeeExport.AutoSize = true;
            this.cbHasFeeExport.Location = new System.Drawing.Point(523, 26);
            this.cbHasFeeExport.Name = "cbHasFeeExport";
            this.cbHasFeeExport.Size = new System.Drawing.Size(135, 24);
            this.cbHasFeeExport.TabIndex = 4;
            this.cbHasFeeExport.Text = "Đã thu phí xuất";
            this.cbHasFeeExport.UseVisualStyleBackColor = true;
            // 
            // dtpParkingDateTo
            // 
            this.dtpParkingDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpParkingDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpParkingDateTo.Location = new System.Drawing.Point(385, 61);
            this.dtpParkingDateTo.Name = "dtpParkingDateTo";
            this.dtpParkingDateTo.Size = new System.Drawing.Size(118, 26);
            this.dtpParkingDateTo.TabIndex = 3;
            // 
            // dtpParkingDateFrom
            // 
            this.dtpParkingDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpParkingDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpParkingDateFrom.Location = new System.Drawing.Point(385, 22);
            this.dtpParkingDateFrom.Name = "dtpParkingDateFrom";
            this.dtpParkingDateFrom.Size = new System.Drawing.Size(118, 26);
            this.dtpParkingDateFrom.TabIndex = 2;
            // 
            // lblParkingDateTo
            // 
            this.lblParkingDateTo.AutoSize = true;
            this.lblParkingDateTo.Location = new System.Drawing.Point(247, 66);
            this.lblParkingDateTo.Name = "lblParkingDateTo";
            this.lblParkingDateTo.Size = new System.Drawing.Size(134, 20);
            this.lblParkingDateTo.TabIndex = 24;
            this.lblParkingDateTo.Text = "Ngày vào bãi đến:";
            // 
            // lblParkingDateFrom
            // 
            this.lblParkingDateFrom.AutoSize = true;
            this.lblParkingDateFrom.Location = new System.Drawing.Point(247, 27);
            this.lblParkingDateFrom.Name = "lblParkingDateFrom";
            this.lblParkingDateFrom.Size = new System.Drawing.Size(121, 20);
            this.lblParkingDateFrom.TabIndex = 23;
            this.lblParkingDateFrom.Text = "Ngày vào bãi từ:";
            // 
            // txtReceiptNumber
            // 
            this.txtReceiptNumber.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtReceiptNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReceiptNumber.Location = new System.Drawing.Point(128, 66);
            this.txtReceiptNumber.Name = "txtReceiptNumber";
            this.txtReceiptNumber.Size = new System.Drawing.Size(105, 26);
            this.txtReceiptNumber.TabIndex = 1;
            this.txtReceiptNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceiptNumber_KeyPress);
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
            this.txtPlateNumber.TabIndex = 0;
            this.txtPlateNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlateNumber_KeyPress);
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
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::ECustoms.Properties.Resources.search41;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(743, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(118, 33);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grbResult
            // 
            this.grbResult.Controls.Add(this.groupBox1);
            this.grbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbResult.Location = new System.Drawing.Point(12, 116);
            this.grbResult.Name = "grbResult";
            this.grbResult.Size = new System.Drawing.Size(901, 442);
            this.grbResult.TabIndex = 1;
            this.grbResult.TabStop = false;
            this.grbResult.Text = "Kết quả tìm kiếm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdVehicle);
            this.groupBox1.Location = new System.Drawing.Point(6, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(890, 400);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phương tiện";
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
            this.btnFeeImport.TabIndex = 3;
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
            this.btnUpdateVehicle.TabIndex = 4;
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
            this.btnFeeExport.TabIndex = 2;
            this.btnFeeExport.Text = "XN phí xuất";
            this.btnFeeExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFeeExport.UseVisualStyleBackColor = true;
            this.btnFeeExport.Click += new System.EventHandler(this.btnFeeExport_Click);
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
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Đóng";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PlateNumber";
            this.dataGridViewTextBoxColumn1.HeaderText = "Biển kiểm soát";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 140;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DriverName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên lái xe";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ExportDate";
            dataGridViewCellStyle13.Format = "dd/MM/yyyy hh:mm";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn3.HeaderText = "Ngày xuất cảnh";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ImportDate";
            dataGridViewCellStyle14.Format = "dd/MM/yyyy hh:mm";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn4.HeaderText = "Ngày nhập cảnh";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NumberOfContainer";
            this.dataGridViewTextBoxColumn5.HeaderText = "Số container";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 135;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "parking";
            this.dataGridViewTextBoxColumn6.HeaderText = "Hàng vào bãi";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 140;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ParkingDate";
            dataGridViewCellStyle15.Format = "dd/MM/yyyy hh:mm";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn7.HeaderText = "Ngày vào bãi";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn8.HeaderText = "Diễn giải";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Note";
            this.dataGridViewTextBoxColumn9.HeaderText = "Ghi chú";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 150;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ImportStatus";
            this.dataGridViewTextBoxColumn10.HeaderText = "Trạng thái nhập cảnh";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 200;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "VehicleID";
            this.dataGridViewTextBoxColumn11.HeaderText = "VehicleID";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "ConfirmExportByName";
            this.dataGridViewTextBoxColumn12.HeaderText = "Người xác nhận xuất";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 200;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "ConfirmImportByName";
            this.dataGridViewTextBoxColumn13.HeaderText = "Người xác nhận nhập";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 200;
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
            dataGridViewCellStyle16.Format = "dd/MM/yyyy hh:mm";
            this.ExportDate.DefaultCellStyle = dataGridViewCellStyle16;
            this.ExportDate.HeaderText = "Ngày xuất cảnh";
            this.ExportDate.Name = "ExportDate";
            this.ExportDate.ReadOnly = true;
            this.ExportDate.Width = 150;
            // 
            // Importdate
            // 
            this.Importdate.DataPropertyName = "ImportDate";
            dataGridViewCellStyle17.Format = "dd/MM/yyyy hh:mm";
            this.Importdate.DefaultCellStyle = dataGridViewCellStyle17;
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
            dataGridViewCellStyle18.Format = "dd/MM/yyyy hh:mm";
            this.parkingDate.DefaultCellStyle = dataGridViewCellStyle18;
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
            // cbHasFeeImport
            // 
            this.cbHasFeeImport.AutoSize = true;
            this.cbHasFeeImport.Location = new System.Drawing.Point(523, 65);
            this.cbHasFeeImport.Name = "cbHasFeeImport";
            this.cbHasFeeImport.Size = new System.Drawing.Size(141, 24);
            this.cbHasFeeImport.TabIndex = 5;
            this.cbHasFeeImport.Text = "Đã thu phí nhập";
            this.cbHasFeeImport.UseVisualStyleBackColor = true;
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
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicle)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.CheckBox cbHasFeeExport;
        private System.Windows.Forms.CheckBox cbHasFeeImport;
    }
}