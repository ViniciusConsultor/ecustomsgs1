namespace ECustoms
{
    partial class frmDeclarationFee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeclarationFee));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFee = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.grdVehicle = new System.Windows.Forms.DataGridView();
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
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlateNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExportGoodType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportGoodType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExportReceiptNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportReceiptNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feeExportAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feeImportAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicle)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ECustoms.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(866, 339);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 33);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Thoát";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFee
            // 
            this.btnFee.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnFee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFee.Image = ((System.Drawing.Image)(resources.GetObject("btnFee.Image")));
            this.btnFee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFee.Location = new System.Drawing.Point(718, 339);
            this.btnFee.Name = "btnFee";
            this.btnFee.Size = new System.Drawing.Size(142, 33);
            this.btnFee.TabIndex = 5;
            this.btnFee.Text = "Thu phí nhập";
            this.btnFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFee.UseVisualStyleBackColor = true;
            this.btnFee.Click += new System.EventHandler(this.btnFee_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(12, 19);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(944, 23);
            this.lblHeader.TabIndex = 6;
            this.lblHeader.Text = " Thông tin thu phí {0} cho tờ khai {0} số {1}";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdVehicle
            // 
            this.grdVehicle.AllowUserToAddRows = false;
            this.grdVehicle.AllowUserToDeleteRows = false;
            this.grdVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdVehicle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdVehicle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVehicle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Count,
            this.PlateNumber,
            this.VehicleType,
            this.ExportGoodType,
            this.ImportGoodType,
            this.ExportReceiptNumber,
            this.ImportReceiptNumber,
            this.feeExportAmount,
            this.feeImportAmount,
            this.VehicleID});
            this.grdVehicle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdVehicle.Location = new System.Drawing.Point(12, 63);
            this.grdVehicle.Name = "grdVehicle";
            this.grdVehicle.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdVehicle.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdVehicle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdVehicle.Size = new System.Drawing.Size(944, 270);
            this.grdVehicle.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PlateNumber";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.HeaderText = "Biển kiểm soát";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 140;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DriverName";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên lái xe";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ExportDate";
            dataGridViewCellStyle7.Format = "dd/MM/yyyy hh:mm";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.HeaderText = "Ngày xuất cảnh";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ImportDate";
            dataGridViewCellStyle8.Format = "dd/MM/yyyy hh:mm";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn4.HeaderText = "Ngày nhập cảnh";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NumberOfContainer";
            this.dataGridViewTextBoxColumn5.HeaderText = "Số container";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 135;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "parking";
            this.dataGridViewTextBoxColumn6.HeaderText = "Hàng vào bãi";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 140;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ParkingDate";
            dataGridViewCellStyle9.Format = "dd/MM/yyyy hh:mm";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn7.HeaderText = "Ngày vào bãi";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Status";
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = null;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn8.HeaderText = "Diễn giải";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Note";
            dataGridViewCellStyle11.Format = "N0";
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle11;
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
            this.dataGridViewTextBoxColumn10.Visible = false;
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
            // Count
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Count.DefaultCellStyle = dataGridViewCellStyle2;
            this.Count.HeaderText = "STT";
            this.Count.Name = "Count";
            this.Count.Width = 50;
            // 
            // PlateNumber
            // 
            this.PlateNumber.DataPropertyName = "PlateNumber";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlateNumber.DefaultCellStyle = dataGridViewCellStyle3;
            this.PlateNumber.HeaderText = "Biển Kiểm soát";
            this.PlateNumber.Name = "PlateNumber";
            this.PlateNumber.ReadOnly = true;
            this.PlateNumber.Width = 140;
            // 
            // VehicleType
            // 
            this.VehicleType.DataPropertyName = "Name";
            this.VehicleType.HeaderText = "Loại trọng tải";
            this.VehicleType.Name = "VehicleType";
            this.VehicleType.ReadOnly = true;
            this.VehicleType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VehicleType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VehicleType.Width = 200;
            // 
            // ExportGoodType
            // 
            this.ExportGoodType.DataPropertyName = "ExportGoodTypeName";
            this.ExportGoodType.HeaderText = "Loại hàng hóa xuất";
            this.ExportGoodType.Name = "ExportGoodType";
            this.ExportGoodType.ReadOnly = true;
            this.ExportGoodType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ExportGoodType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExportGoodType.Visible = false;
            this.ExportGoodType.Width = 200;
            // 
            // ImportGoodType
            // 
            this.ImportGoodType.DataPropertyName = "ImportGoodTypeName";
            this.ImportGoodType.HeaderText = "Loại hàng hóa nhập";
            this.ImportGoodType.Name = "ImportGoodType";
            this.ImportGoodType.ReadOnly = true;
            this.ImportGoodType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ImportGoodType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ImportGoodType.Width = 200;
            // 
            // ExportReceiptNumber
            // 
            this.ExportReceiptNumber.DataPropertyName = "ExportReceiptNumber";
            this.ExportReceiptNumber.HeaderText = "Số biên lai xuất";
            this.ExportReceiptNumber.Name = "ExportReceiptNumber";
            this.ExportReceiptNumber.Visible = false;
            this.ExportReceiptNumber.Width = 200;
            // 
            // ImportReceiptNumber
            // 
            this.ImportReceiptNumber.DataPropertyName = "ImportReceiptNumber";
            this.ImportReceiptNumber.HeaderText = "Số biên lai nhập";
            this.ImportReceiptNumber.Name = "ImportReceiptNumber";
            this.ImportReceiptNumber.Width = 200;
            // 
            // feeExportAmount
            // 
            this.feeExportAmount.DataPropertyName = "feeExportAmount";
            this.feeExportAmount.HeaderText = "Số phí xuất";
            this.feeExportAmount.Name = "feeExportAmount";
            this.feeExportAmount.Visible = false;
            this.feeExportAmount.Width = 150;
            // 
            // feeImportAmount
            // 
            this.feeImportAmount.DataPropertyName = "feeImportAmount";
            this.feeImportAmount.HeaderText = "Số phí nhập";
            this.feeImportAmount.Name = "feeImportAmount";
            this.feeImportAmount.Width = 150;
            // 
            // VehicleID
            // 
            this.VehicleID.DataPropertyName = "VehicleID";
            this.VehicleID.HeaderText = "VehicleID";
            this.VehicleID.Name = "VehicleID";
            this.VehicleID.Visible = false;
            // 
            // frmDeclarationFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 384);
            this.Controls.Add(this.grdVehicle);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnFee);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDeclarationFee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDeclarationFee";
            this.Load += new System.EventHandler(this.frmDeclarationFee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
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
        private System.Windows.Forms.Button btnFee;
        private System.Windows.Forms.Label lblHeader;
        public System.Windows.Forms.DataGridView grdVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlateNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExportGoodType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportGoodType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExportReceiptNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportReceiptNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeExportAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeImportAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleID;
    }
}