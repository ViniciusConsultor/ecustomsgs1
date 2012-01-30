namespace ECustoms
{
    partial class FrmDecleExport
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
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDecleExport));
          this.gbExportDeclaration = new System.Windows.Forms.GroupBox();
          this.txtExportTotalVehicles = new System.Windows.Forms.MaskedTextBox();
          this.lblTotalVehicles = new System.Windows.Forms.Label();
          this.dtpExportRegisterDate = new System.Windows.Forms.DateTimePicker();
          this.label9 = new System.Windows.Forms.Label();
          this.txtExportCompanyCode = new System.Windows.Forms.TextBox();
          this.label8 = new System.Windows.Forms.Label();
          this.txtTypeExport = new System.Windows.Forms.TextBox();
          this.label1 = new System.Windows.Forms.Label();
          this.lblNumber = new System.Windows.Forms.Label();
          this.lblProductName = new System.Windows.Forms.Label();
          this.txtExportProductName = new System.Windows.Forms.TextBox();
          this.lblCompanyName = new System.Windows.Forms.Label();
          this.txtExportNumber = new System.Windows.Forms.MaskedTextBox();
          this.txtExportCompanyName = new System.Windows.Forms.TextBox();
          this.lblProductAmount = new System.Windows.Forms.Label();
          this.txtExportProductAmount = new System.Windows.Forms.TextBox();
          this.txtExportUnit = new System.Windows.Forms.TextBox();
          this.lblUnit = new System.Windows.Forms.Label();
          this.groupBoxVehicle = new System.Windows.Forms.GroupBox();
          this.btnConfirmImportKH = new System.Windows.Forms.Button();
          this.bntConfirmImportCH = new System.Windows.Forms.Button();
          this.btnAddExisting = new System.Windows.Forms.Button();
          this.btnComfirmExport = new System.Windows.Forms.Button();
          this.btnDeleteVehicle = new System.Windows.Forms.Button();
          this.btnUpdateVehicle = new System.Windows.Forms.Button();
          this.btnAddVehicle = new System.Windows.Forms.Button();
          this.grdVehicle = new System.Windows.Forms.DataGridView();
          this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.PlateNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.DriverName = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.IsExport = new System.Windows.Forms.DataGridViewCheckBoxColumn();
          this.ImportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.IsImport = new System.Windows.Forms.DataGridViewCheckBoxColumn();
          this.VehicleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.NumberOfContainer = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.ExportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.lblHeader = new System.Windows.Forms.Label();
          this.btnUpdate = new System.Windows.Forms.Button();
          this.button1 = new System.Windows.Forms.Button();
          this.btnAdd = new System.Windows.Forms.Button();
          this.gbExportDeclaration.SuspendLayout();
          this.groupBoxVehicle.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.grdVehicle)).BeginInit();
          this.SuspendLayout();
          // 
          // gbExportDeclaration
          // 
          this.gbExportDeclaration.Controls.Add(this.txtExportTotalVehicles);
          this.gbExportDeclaration.Controls.Add(this.lblTotalVehicles);
          this.gbExportDeclaration.Controls.Add(this.dtpExportRegisterDate);
          this.gbExportDeclaration.Controls.Add(this.label9);
          this.gbExportDeclaration.Controls.Add(this.txtExportCompanyCode);
          this.gbExportDeclaration.Controls.Add(this.label8);
          this.gbExportDeclaration.Controls.Add(this.txtTypeExport);
          this.gbExportDeclaration.Controls.Add(this.label1);
          this.gbExportDeclaration.Controls.Add(this.lblNumber);
          this.gbExportDeclaration.Controls.Add(this.lblProductName);
          this.gbExportDeclaration.Controls.Add(this.txtExportProductName);
          this.gbExportDeclaration.Controls.Add(this.lblCompanyName);
          this.gbExportDeclaration.Controls.Add(this.txtExportNumber);
          this.gbExportDeclaration.Controls.Add(this.txtExportCompanyName);
          this.gbExportDeclaration.Controls.Add(this.lblProductAmount);
          this.gbExportDeclaration.Controls.Add(this.txtExportProductAmount);
          this.gbExportDeclaration.Controls.Add(this.txtExportUnit);
          this.gbExportDeclaration.Controls.Add(this.lblUnit);
          this.gbExportDeclaration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.gbExportDeclaration.Location = new System.Drawing.Point(12, 41);
          this.gbExportDeclaration.Name = "gbExportDeclaration";
          this.gbExportDeclaration.Size = new System.Drawing.Size(928, 150);
          this.gbExportDeclaration.TabIndex = 19;
          this.gbExportDeclaration.TabStop = false;
          this.gbExportDeclaration.Text = "Thông tin tờ khai xuất cảnh";
          // 
          // txtExportTotalVehicles
          // 
          this.txtExportTotalVehicles.Location = new System.Drawing.Point(792, 83);
          this.txtExportTotalVehicles.Mask = "00000";
          this.txtExportTotalVehicles.Name = "txtExportTotalVehicles";
          this.txtExportTotalVehicles.Size = new System.Drawing.Size(66, 26);
          this.txtExportTotalVehicles.TabIndex = 9;
          this.txtExportTotalVehicles.ValidatingType = typeof(int);
          this.txtExportTotalVehicles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtExportTotalVehicles_KeyDown);
          this.txtExportTotalVehicles.Leave += new System.EventHandler(this.txtExportTotalVehicles_Leave);
          // 
          // lblTotalVehicles
          // 
          this.lblTotalVehicles.AutoSize = true;
          this.lblTotalVehicles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblTotalVehicles.Location = new System.Drawing.Point(689, 86);
          this.lblTotalVehicles.Name = "lblTotalVehicles";
          this.lblTotalVehicles.Size = new System.Drawing.Size(74, 20);
          this.lblTotalVehicles.TabIndex = 15;
          this.lblTotalVehicles.Text = "Lượng xe";
          // 
          // dtpExportRegisterDate
          // 
          this.dtpExportRegisterDate.CustomFormat = "dd/MM/yyyy";
          this.dtpExportRegisterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
          this.dtpExportRegisterDate.Location = new System.Drawing.Point(131, 53);
          this.dtpExportRegisterDate.Name = "dtpExportRegisterDate";
          this.dtpExportRegisterDate.Size = new System.Drawing.Size(106, 26);
          this.dtpExportRegisterDate.TabIndex = 2;
          // 
          // label9
          // 
          this.label9.AutoSize = true;
          this.label9.Location = new System.Drawing.Point(6, 60);
          this.label9.Name = "label9";
          this.label9.Size = new System.Drawing.Size(104, 20);
          this.label9.TabIndex = 13;
          this.label9.Text = "Ngày đăng ký";
          // 
          // txtExportCompanyCode
          // 
          this.txtExportCompanyCode.Location = new System.Drawing.Point(414, 47);
          this.txtExportCompanyCode.Multiline = true;
          this.txtExportCompanyCode.Name = "txtExportCompanyCode";
          this.txtExportCompanyCode.Size = new System.Drawing.Size(251, 28);
          this.txtExportCompanyCode.TabIndex = 5;
          // 
          // label8
          // 
          this.label8.AutoSize = true;
          this.label8.Location = new System.Drawing.Point(273, 53);
          this.label8.Name = "label8";
          this.label8.Size = new System.Drawing.Size(135, 20);
          this.label8.TabIndex = 11;
          this.label8.Text = "Mã Doanh nghiệp";
          // 
          // txtTypeExport
          // 
          this.txtTypeExport.Location = new System.Drawing.Point(131, 85);
          this.txtTypeExport.Name = "txtTypeExport";
          this.txtTypeExport.Size = new System.Drawing.Size(106, 26);
          this.txtTypeExport.TabIndex = 3;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(10, 91);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(73, 20);
          this.label1.TabIndex = 10;
          this.label1.Text = "Loại hình";
          // 
          // lblNumber
          // 
          this.lblNumber.AutoSize = true;
          this.lblNumber.Location = new System.Drawing.Point(6, 27);
          this.lblNumber.Name = "lblNumber";
          this.lblNumber.Size = new System.Drawing.Size(80, 20);
          this.lblNumber.TabIndex = 0;
          this.lblNumber.Text = "Số tờ khai";
          // 
          // lblProductName
          // 
          this.lblProductName.AutoSize = true;
          this.lblProductName.Location = new System.Drawing.Point(273, 82);
          this.lblProductName.Name = "lblProductName";
          this.lblProductName.Size = new System.Drawing.Size(76, 20);
          this.lblProductName.TabIndex = 2;
          this.lblProductName.Text = "Tên hàng";
          // 
          // txtExportProductName
          // 
          this.txtExportProductName.Location = new System.Drawing.Point(414, 86);
          this.txtExportProductName.Multiline = true;
          this.txtExportProductName.Name = "txtExportProductName";
          this.txtExportProductName.Size = new System.Drawing.Size(251, 54);
          this.txtExportProductName.TabIndex = 6;
          // 
          // lblCompanyName
          // 
          this.lblCompanyName.AutoSize = true;
          this.lblCompanyName.Location = new System.Drawing.Point(268, 16);
          this.lblCompanyName.Name = "lblCompanyName";
          this.lblCompanyName.Size = new System.Drawing.Size(140, 20);
          this.lblCompanyName.TabIndex = 4;
          this.lblCompanyName.Text = "Tên Doanh nghiệp";
          // 
          // txtExportNumber
          // 
          this.txtExportNumber.Location = new System.Drawing.Point(131, 21);
          this.txtExportNumber.Mask = "0000000000";
          this.txtExportNumber.Name = "txtExportNumber";
          this.txtExportNumber.Size = new System.Drawing.Size(66, 26);
          this.txtExportNumber.TabIndex = 1;
          // 
          // txtExportCompanyName
          // 
          this.txtExportCompanyName.Location = new System.Drawing.Point(414, 13);
          this.txtExportCompanyName.Multiline = true;
          this.txtExportCompanyName.Name = "txtExportCompanyName";
          this.txtExportCompanyName.Size = new System.Drawing.Size(251, 28);
          this.txtExportCompanyName.TabIndex = 4;
          // 
          // lblProductAmount
          // 
          this.lblProductAmount.AutoSize = true;
          this.lblProductAmount.Location = new System.Drawing.Point(689, 16);
          this.lblProductAmount.Name = "lblProductAmount";
          this.lblProductAmount.Size = new System.Drawing.Size(97, 20);
          this.lblProductAmount.TabIndex = 6;
          this.lblProductAmount.Text = "Lượng Hàng";
          // 
          // txtExportProductAmount
          // 
          this.txtExportProductAmount.Location = new System.Drawing.Point(792, 15);
          this.txtExportProductAmount.Name = "txtExportProductAmount";
          this.txtExportProductAmount.Size = new System.Drawing.Size(129, 26);
          this.txtExportProductAmount.TabIndex = 7;
          // 
          // txtExportUnit
          // 
          this.txtExportUnit.Location = new System.Drawing.Point(792, 49);
          this.txtExportUnit.Name = "txtExportUnit";
          this.txtExportUnit.Size = new System.Drawing.Size(129, 26);
          this.txtExportUnit.TabIndex = 8;
          // 
          // lblUnit
          // 
          this.lblUnit.AutoSize = true;
          this.lblUnit.Location = new System.Drawing.Point(689, 53);
          this.lblUnit.Name = "lblUnit";
          this.lblUnit.Size = new System.Drawing.Size(83, 20);
          this.lblUnit.TabIndex = 8;
          this.lblUnit.Text = "Đơn vị tính";
          // 
          // groupBoxVehicle
          // 
          this.groupBoxVehicle.Controls.Add(this.btnConfirmImportKH);
          this.groupBoxVehicle.Controls.Add(this.bntConfirmImportCH);
          this.groupBoxVehicle.Controls.Add(this.btnAddExisting);
          this.groupBoxVehicle.Controls.Add(this.btnComfirmExport);
          this.groupBoxVehicle.Controls.Add(this.btnDeleteVehicle);
          this.groupBoxVehicle.Controls.Add(this.btnUpdateVehicle);
          this.groupBoxVehicle.Controls.Add(this.btnAddVehicle);
          this.groupBoxVehicle.Controls.Add(this.grdVehicle);
          this.groupBoxVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.groupBoxVehicle.Location = new System.Drawing.Point(12, 197);
          this.groupBoxVehicle.Name = "groupBoxVehicle";
          this.groupBoxVehicle.Size = new System.Drawing.Size(927, 316);
          this.groupBoxVehicle.TabIndex = 20;
          this.groupBoxVehicle.TabStop = false;
          this.groupBoxVehicle.Text = "Khai báo phương tiện";
          // 
          // btnConfirmImportKH
          // 
          this.btnConfirmImportKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnConfirmImportKH.Location = new System.Drawing.Point(783, 137);
          this.btnConfirmImportKH.Name = "btnConfirmImportKH";
          this.btnConfirmImportKH.Size = new System.Drawing.Size(138, 50);
          this.btnConfirmImportKH.TabIndex = 36;
          this.btnConfirmImportKH.Text = "Xác nhận nhập cảnh không hàng";
          this.btnConfirmImportKH.UseVisualStyleBackColor = true;
          this.btnConfirmImportKH.Click += new System.EventHandler(this.btnConfirmImportKH_Click);
          // 
          // bntConfirmImportCH
          // 
          this.bntConfirmImportCH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.bntConfirmImportCH.Location = new System.Drawing.Point(783, 81);
          this.bntConfirmImportCH.Name = "bntConfirmImportCH";
          this.bntConfirmImportCH.Size = new System.Drawing.Size(138, 50);
          this.bntConfirmImportCH.TabIndex = 35;
          this.bntConfirmImportCH.Text = "Xác nhận nhập cảnh có hàng";
          this.bntConfirmImportCH.UseVisualStyleBackColor = true;
          this.bntConfirmImportCH.Click += new System.EventHandler(this.bntConfirmImportCH_Click);
          // 
          // btnAddExisting
          // 
          this.btnAddExisting.Enabled = false;
          this.btnAddExisting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
          this.btnAddExisting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnAddExisting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnAddExisting.Image = global::ECustoms.Properties.Resources._001_01;
          this.btnAddExisting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.btnAddExisting.Location = new System.Drawing.Point(391, 273);
          this.btnAddExisting.Name = "btnAddExisting";
          this.btnAddExisting.Size = new System.Drawing.Size(235, 33);
          this.btnAddExisting.TabIndex = 24;
          this.btnAddExisting.Text = "Thêm từ phương tiện đã XK";
          this.btnAddExisting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          this.btnAddExisting.UseVisualStyleBackColor = true;
          this.btnAddExisting.Click += new System.EventHandler(this.btnAddExisting_Click);
          // 
          // btnComfirmExport
          // 
          this.btnComfirmExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnComfirmExport.Location = new System.Drawing.Point(783, 25);
          this.btnComfirmExport.Name = "btnComfirmExport";
          this.btnComfirmExport.Size = new System.Drawing.Size(138, 50);
          this.btnComfirmExport.TabIndex = 34;
          this.btnComfirmExport.Text = "Xác nhận xuất cảnh";
          this.btnComfirmExport.UseVisualStyleBackColor = true;
          this.btnComfirmExport.Click += new System.EventHandler(this.btnComfirmExport_Click);
          // 
          // btnDeleteVehicle
          // 
          this.btnDeleteVehicle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
          this.btnDeleteVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnDeleteVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnDeleteVehicle.Image = global::ECustoms.Properties.Resources._001_05;
          this.btnDeleteVehicle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.btnDeleteVehicle.Location = new System.Drawing.Point(632, 273);
          this.btnDeleteVehicle.Name = "btnDeleteVehicle";
          this.btnDeleteVehicle.Size = new System.Drawing.Size(73, 33);
          this.btnDeleteVehicle.TabIndex = 25;
          this.btnDeleteVehicle.Text = "Xóa";
          this.btnDeleteVehicle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          this.btnDeleteVehicle.UseVisualStyleBackColor = true;
          this.btnDeleteVehicle.Click += new System.EventHandler(this.btnDeleteVehicle_Click);
          // 
          // btnUpdateVehicle
          // 
          this.btnUpdateVehicle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
          this.btnUpdateVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnUpdateVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnUpdateVehicle.Image = global::ECustoms.Properties.Resources._001_45;
          this.btnUpdateVehicle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.btnUpdateVehicle.Location = new System.Drawing.Point(185, 273);
          this.btnUpdateVehicle.Name = "btnUpdateVehicle";
          this.btnUpdateVehicle.Size = new System.Drawing.Size(200, 33);
          this.btnUpdateVehicle.TabIndex = 23;
          this.btnUpdateVehicle.Text = "Cập nhật phương tiện";
          this.btnUpdateVehicle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          this.btnUpdateVehicle.UseVisualStyleBackColor = true;
          this.btnUpdateVehicle.Click += new System.EventHandler(this.btnUpdateVehicle_Click);
          // 
          // btnAddVehicle
          // 
          this.btnAddVehicle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
          this.btnAddVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnAddVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnAddVehicle.Image = global::ECustoms.Properties.Resources._001_01;
          this.btnAddVehicle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.btnAddVehicle.Location = new System.Drawing.Point(8, 273);
          this.btnAddVehicle.Name = "btnAddVehicle";
          this.btnAddVehicle.Size = new System.Drawing.Size(171, 33);
          this.btnAddVehicle.TabIndex = 22;
          this.btnAddVehicle.Text = "Thêm phương tiện";
          this.btnAddVehicle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          this.btnAddVehicle.UseVisualStyleBackColor = true;
          this.btnAddVehicle.Click += new System.EventHandler(this.btnAddVehicle_Click);
          // 
          // grdVehicle
          // 
          this.grdVehicle.AllowUserToAddRows = false;
          this.grdVehicle.AllowUserToDeleteRows = false;
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
            this.DriverName,
            this.Status,
            this.Note,
            this.IsExport,
            this.ImportDate,
            this.IsImport,
            this.VehicleID,
            this.NumberOfContainer,
            this.ExportDate});
          this.grdVehicle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
          this.grdVehicle.Location = new System.Drawing.Point(7, 25);
          this.grdVehicle.Name = "grdVehicle";
          dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.grdVehicle.RowsDefaultCellStyle = dataGridViewCellStyle5;
          this.grdVehicle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
          this.grdVehicle.Size = new System.Drawing.Size(770, 240);
          this.grdVehicle.TabIndex = 21;
          this.grdVehicle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVehicle_CellEndEdit);
          this.grdVehicle.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdVehicle_CellMouseDoubleClick);
          // 
          // Count
          // 
          this.Count.HeaderText = "STT";
          this.Count.Name = "Count";
          this.Count.Width = 50;
          // 
          // PlateNumber
          // 
          this.PlateNumber.DataPropertyName = "PlateNumber";
          dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.PlateNumber.DefaultCellStyle = dataGridViewCellStyle2;
          this.PlateNumber.HeaderText = "Biển Kiểm soát";
          this.PlateNumber.Name = "PlateNumber";
          this.PlateNumber.Width = 140;
          // 
          // DriverName
          // 
          this.DriverName.DataPropertyName = "DriverName";
          this.DriverName.HeaderText = "Tên lái xe";
          this.DriverName.Name = "DriverName";
          this.DriverName.Width = 150;
          // 
          // Status
          // 
          this.Status.DataPropertyName = "Status";
          this.Status.HeaderText = "Diễn giải";
          this.Status.Name = "Status";
          this.Status.Width = 200;
          // 
          // Note
          // 
          this.Note.DataPropertyName = "Note";
          this.Note.HeaderText = "Ghi chú";
          this.Note.Name = "Note";
          this.Note.Width = 185;
          // 
          // IsExport
          // 
          this.IsExport.DataPropertyName = "IsExport";
          this.IsExport.HeaderText = "Đã Xuất";
          this.IsExport.Name = "IsExport";
          this.IsExport.Visible = false;
          // 
          // ImportDate
          // 
          this.ImportDate.DataPropertyName = "ImportDate";
          dataGridViewCellStyle3.Format = "dd/MM/yyyy";
          this.ImportDate.DefaultCellStyle = dataGridViewCellStyle3;
          this.ImportDate.HeaderText = "Ngày nhập cảnh";
          this.ImportDate.Name = "ImportDate";
          this.ImportDate.Visible = false;
          this.ImportDate.Width = 115;
          // 
          // IsImport
          // 
          this.IsImport.DataPropertyName = "IsImport";
          this.IsImport.HeaderText = "Đã nhập";
          this.IsImport.Name = "IsImport";
          this.IsImport.Visible = false;
          // 
          // VehicleID
          // 
          this.VehicleID.DataPropertyName = "VehicleID";
          this.VehicleID.HeaderText = "VehicleID";
          this.VehicleID.Name = "VehicleID";
          this.VehicleID.Visible = false;
          // 
          // NumberOfContainer
          // 
          this.NumberOfContainer.DataPropertyName = "NumberOfContainer";
          this.NumberOfContainer.HeaderText = "Số Container";
          this.NumberOfContainer.Name = "NumberOfContainer";
          this.NumberOfContainer.Visible = false;
          // 
          // ExportDate
          // 
          this.ExportDate.DataPropertyName = "ExportDate";
          dataGridViewCellStyle4.Format = "dd/MM/yyyy";
          dataGridViewCellStyle4.NullValue = null;
          this.ExportDate.DefaultCellStyle = dataGridViewCellStyle4;
          this.ExportDate.HeaderText = "Ngày xuất cảnh";
          this.ExportDate.Name = "ExportDate";
          this.ExportDate.Visible = false;
          this.ExportDate.Width = 110;
          // 
          // lblHeader
          // 
          this.lblHeader.AutoSize = true;
          this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblHeader.Location = new System.Drawing.Point(346, 9);
          this.lblHeader.Name = "lblHeader";
          this.lblHeader.Size = new System.Drawing.Size(229, 29);
          this.lblHeader.TabIndex = 21;
          this.lblHeader.Text = "Khai báo xuất cảnh";
          // 
          // btnUpdate
          // 
          this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
          this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnUpdate.Image = global::ECustoms.Properties.Resources._001_45;
          this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.btnUpdate.Location = new System.Drawing.Point(214, 519);
          this.btnUpdate.Name = "btnUpdate";
          this.btnUpdate.Size = new System.Drawing.Size(171, 33);
          this.btnUpdate.TabIndex = 31;
          this.btnUpdate.Text = "Cập nhật tờ khai";
          this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          this.btnUpdate.UseVisualStyleBackColor = true;
          this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
          // 
          // button1
          // 
          this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
          this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.button1.Image = global::ECustoms.Properties.Resources.close;
          this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.button1.Location = new System.Drawing.Point(391, 519);
          this.button1.Name = "button1";
          this.button1.Size = new System.Drawing.Size(93, 33);
          this.button1.TabIndex = 33;
          this.button1.Text = "Đóng";
          this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          this.button1.UseVisualStyleBackColor = true;
          this.button1.Click += new System.EventHandler(this.button1_Click);
          // 
          // btnAdd
          // 
          this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
          this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnAdd.Image = global::ECustoms.Properties.Resources.save_icon;
          this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.btnAdd.Location = new System.Drawing.Point(19, 519);
          this.btnAdd.Name = "btnAdd";
          this.btnAdd.Size = new System.Drawing.Size(189, 33);
          this.btnAdd.TabIndex = 30;
          this.btnAdd.Text = "Tạo mới/lưu tờ khai";
          this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          this.btnAdd.UseVisualStyleBackColor = true;
          this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
          // 
          // FrmDecleExport
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.SystemColors.Control;
          this.CancelButton = this.button1;
          this.ClientSize = new System.Drawing.Size(951, 560);
          this.Controls.Add(this.btnUpdate);
          this.Controls.Add(this.button1);
          this.Controls.Add(this.btnAdd);
          this.Controls.Add(this.lblHeader);
          this.Controls.Add(this.groupBoxVehicle);
          this.Controls.Add(this.gbExportDeclaration);
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.KeyPreview = true;
          this.Name = "FrmDecleExport";
          this.Text = "Khai báo xuất cảnh";
          this.Load += new System.EventHandler(this.FrmDecleExport_Load);
          this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDecleExport_KeyDown);
          this.gbExportDeclaration.ResumeLayout(false);
          this.gbExportDeclaration.PerformLayout();
          this.groupBoxVehicle.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.grdVehicle)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbExportDeclaration;
        private System.Windows.Forms.DateTimePicker dtpExportRegisterDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtExportCompanyCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTypeExport;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtExportProductName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.MaskedTextBox txtExportNumber;
        private System.Windows.Forms.TextBox txtExportCompanyName;
        private System.Windows.Forms.Label lblProductAmount;
        private System.Windows.Forms.TextBox txtExportProductAmount;
        private System.Windows.Forms.TextBox txtExportUnit;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.GroupBox groupBoxVehicle;
        private System.Windows.Forms.Button btnDeleteVehicle;
        private System.Windows.Forms.Button btnUpdateVehicle;
        private System.Windows.Forms.Button btnAddVehicle;
        public System.Windows.Forms.DataGridView grdVehicle;
        private System.Windows.Forms.MaskedTextBox txtExportTotalVehicles;
        private System.Windows.Forms.Label lblTotalVehicles;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddExisting;
        private System.Windows.Forms.Button btnComfirmExport;
        private System.Windows.Forms.Button btnConfirmImportKH;
        private System.Windows.Forms.Button bntConfirmImportCH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlateNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfContainer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExportDate;
    }
}