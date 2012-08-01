namespace ECustoms
{
    partial class frmExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExport));
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtExportProductName = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtExportCompanyName = new System.Windows.Forms.TextBox();
            this.lblProductAmount = new System.Windows.Forms.Label();
            this.txtExportProductAmount = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtExportUnit = new System.Windows.Forms.TextBox();
            this.groupBoxVehicle = new System.Windows.Forms.GroupBox();
            this.btnAddExisting = new System.Windows.Forms.Button();
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
            this.txtExportNumber = new System.Windows.Forms.MaskedTextBox();
            this.gbExportDeclaration = new System.Windows.Forms.GroupBox();
            this.dtpExportRegisterDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtExportCompanyCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTypeExport = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExportTotalVehicles = new System.Windows.Forms.MaskedTextBox();
            this.lblTotalVehicles = new System.Windows.Forms.Label();
            this.cbExportHasDeclaration = new System.Windows.Forms.CheckBox();
            this.rdoImport = new System.Windows.Forms.RadioButton();
            this.gbImportDeclaration = new System.Windows.Forms.GroupBox();
            this.dtpImportRegisterDate = new System.Windows.Forms.DateTimePicker();
            this.txtTypeImport = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtImportCompanyCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImportProductName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImportNumber = new System.Windows.Forms.MaskedTextBox();
            this.txtImportCompanyName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtImportProductAmount = new System.Windows.Forms.TextBox();
            this.txtImportUnit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rdoExport = new System.Windows.Forms.RadioButton();
            this.cbImportHasDeclaration = new System.Windows.Forms.CheckBox();
            this.btnComfirmExport = new System.Windows.Forms.Button();
            this.bntConfirmImportCH = new System.Windows.Forms.Button();
            this.btnConfirmImportKH = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBoxVehicle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicle)).BeginInit();
            this.gbExportDeclaration.SuspendLayout();
            this.gbImportDeclaration.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(7, 23);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(80, 20);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "Số tờ khai";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(298, 131);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(76, 20);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Tên hàng";
            // 
            // txtExportProductName
            // 
            this.txtExportProductName.Location = new System.Drawing.Point(264, 161);
            this.txtExportProductName.Multiline = true;
            this.txtExportProductName.Name = "txtExportProductName";
            this.txtExportProductName.Size = new System.Drawing.Size(145, 64);
            this.txtExportProductName.TabIndex = 12;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(6, 57);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(140, 20);
            this.lblCompanyName.TabIndex = 4;
            this.lblCompanyName.Text = "Tên Doanh nghiệp";
            // 
            // txtExportCompanyName
            // 
            this.txtExportCompanyName.Location = new System.Drawing.Point(152, 57);
            this.txtExportCompanyName.Multiline = true;
            this.txtExportCompanyName.Name = "txtExportCompanyName";
            this.txtExportCompanyName.Size = new System.Drawing.Size(251, 28);
            this.txtExportCompanyName.TabIndex = 7;
            // 
            // lblProductAmount
            // 
            this.lblProductAmount.AutoSize = true;
            this.lblProductAmount.Location = new System.Drawing.Point(11, 164);
            this.lblProductAmount.Name = "lblProductAmount";
            this.lblProductAmount.Size = new System.Drawing.Size(97, 20);
            this.lblProductAmount.TabIndex = 6;
            this.lblProductAmount.Text = "Lượng Hàng";
            // 
            // txtExportProductAmount
            // 
            this.txtExportProductAmount.Location = new System.Drawing.Point(151, 164);
            this.txtExportProductAmount.Name = "txtExportProductAmount";
            this.txtExportProductAmount.Size = new System.Drawing.Size(107, 26);
            this.txtExportProductAmount.TabIndex = 10;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(10, 199);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(83, 20);
            this.lblUnit.TabIndex = 8;
            this.lblUnit.Text = "Đơn vị tính";
            // 
            // txtExportUnit
            // 
            this.txtExportUnit.Location = new System.Drawing.Point(151, 199);
            this.txtExportUnit.Name = "txtExportUnit";
            this.txtExportUnit.Size = new System.Drawing.Size(107, 26);
            this.txtExportUnit.TabIndex = 11;
            this.txtExportUnit.Leave += new System.EventHandler(this.txtExportUnit_Leave);
            // 
            // groupBoxVehicle
            // 
            this.groupBoxVehicle.Controls.Add(this.btnAddExisting);
            this.groupBoxVehicle.Controls.Add(this.btnDeleteVehicle);
            this.groupBoxVehicle.Controls.Add(this.btnUpdateVehicle);
            this.groupBoxVehicle.Controls.Add(this.btnAddVehicle);
            this.groupBoxVehicle.Controls.Add(this.grdVehicle);
            this.groupBoxVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxVehicle.Location = new System.Drawing.Point(6, 284);
            this.groupBoxVehicle.Name = "groupBoxVehicle";
            this.groupBoxVehicle.Size = new System.Drawing.Size(848, 314);
            this.groupBoxVehicle.TabIndex = 10;
            this.groupBoxVehicle.TabStop = false;
            this.groupBoxVehicle.Text = "Khai báo xe";
            this.groupBoxVehicle.Enter += new System.EventHandler(this.groupBoxVehicle_Enter_1);
            // 
            // btnAddExisting
            // 
            this.btnAddExisting.Enabled = false;
            this.btnAddExisting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddExisting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddExisting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddExisting.Image = global::ECustoms.Properties.Resources.add;
            this.btnAddExisting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddExisting.Location = new System.Drawing.Point(367, 273);
            this.btnAddExisting.Name = "btnAddExisting";
            this.btnAddExisting.Size = new System.Drawing.Size(229, 28);
            this.btnAddExisting.TabIndex = 24;
            this.btnAddExisting.Text = "Thêm từ phương tiện &đã XK";
            this.btnAddExisting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddExisting.UseVisualStyleBackColor = true;
            this.btnAddExisting.Click += new System.EventHandler(this.btnAddExisting_Click);
            // 
            // btnDeleteVehicle
            // 
            this.btnDeleteVehicle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDeleteVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteVehicle.Image = global::ECustoms.Properties.Resources.delete;
            this.btnDeleteVehicle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteVehicle.Location = new System.Drawing.Point(602, 273);
            this.btnDeleteVehicle.Name = "btnDeleteVehicle";
            this.btnDeleteVehicle.Size = new System.Drawing.Size(159, 28);
            this.btnDeleteVehicle.TabIndex = 25;
            this.btnDeleteVehicle.Text = "&Xóa phương tiện";
            this.btnDeleteVehicle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteVehicle.UseVisualStyleBackColor = true;
            this.btnDeleteVehicle.Click += new System.EventHandler(this.btnDeleteVehicle_Click_1);
            // 
            // btnUpdateVehicle
            // 
            this.btnUpdateVehicle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdateVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateVehicle.Image = global::ECustoms.Properties.Resources.edit;
            this.btnUpdateVehicle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateVehicle.Location = new System.Drawing.Point(174, 273);
            this.btnUpdateVehicle.Name = "btnUpdateVehicle";
            this.btnUpdateVehicle.Size = new System.Drawing.Size(187, 28);
            this.btnUpdateVehicle.TabIndex = 23;
            this.btnUpdateVehicle.Text = "&Cập nhật phương tiện";
            this.btnUpdateVehicle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateVehicle.UseVisualStyleBackColor = true;
            this.btnUpdateVehicle.Click += new System.EventHandler(this.btnUpdateVehicle_Click);
            // 
            // btnAddVehicle
            // 
            this.btnAddVehicle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddVehicle.Image = global::ECustoms.Properties.Resources.add;
            this.btnAddVehicle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddVehicle.Location = new System.Drawing.Point(8, 273);
            this.btnAddVehicle.Name = "btnAddVehicle";
            this.btnAddVehicle.Size = new System.Drawing.Size(160, 28);
            this.btnAddVehicle.TabIndex = 22;
            this.btnAddVehicle.Text = "Thê&m phương tiện";
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
            this.grdVehicle.Size = new System.Drawing.Size(828, 240);
            this.grdVehicle.TabIndex = 21;
            this.grdVehicle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVehicle_CellContentClick);
            this.grdVehicle.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdVehicle_CellMouseDoubleClick);
            // 
            // Count
            // 
            this.Count.DataPropertyName = "DeclarationID";
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
            this.Status.Width = 205;
            // 
            // Note
            // 
            this.Note.DataPropertyName = "Note";
            this.Note.HeaderText = "Ghi chú";
            this.Note.Name = "Note";
            this.Note.Width = 238;
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
            // txtExportNumber
            // 
            this.txtExportNumber.Location = new System.Drawing.Point(152, 22);
            this.txtExportNumber.Mask = "0000000000";
            this.txtExportNumber.Name = "txtExportNumber";
            this.txtExportNumber.Size = new System.Drawing.Size(66, 26);
            this.txtExportNumber.TabIndex = 5;
            // 
            // gbExportDeclaration
            // 
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
            this.gbExportDeclaration.Location = new System.Drawing.Point(6, 49);
            this.gbExportDeclaration.Name = "gbExportDeclaration";
            this.gbExportDeclaration.Size = new System.Drawing.Size(415, 234);
            this.gbExportDeclaration.TabIndex = 18;
            this.gbExportDeclaration.TabStop = false;
            this.gbExportDeclaration.Text = "Thông tin tờ khai xuất khẩu";
            // 
            // dtpExportRegisterDate
            // 
            this.dtpExportRegisterDate.CustomFormat = "dd/MM/yyyy";
            this.dtpExportRegisterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExportRegisterDate.Location = new System.Drawing.Point(152, 125);
            this.dtpExportRegisterDate.Name = "dtpExportRegisterDate";
            this.dtpExportRegisterDate.Size = new System.Drawing.Size(106, 26);
            this.dtpExportRegisterDate.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Ngày đăng ký";
            // 
            // txtExportCompanyCode
            // 
            this.txtExportCompanyCode.Location = new System.Drawing.Point(152, 91);
            this.txtExportCompanyCode.Multiline = true;
            this.txtExportCompanyCode.Name = "txtExportCompanyCode";
            this.txtExportCompanyCode.Size = new System.Drawing.Size(251, 28);
            this.txtExportCompanyCode.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Mã Doanh nghiệp";
            // 
            // txtTypeExport
            // 
            this.txtTypeExport.Location = new System.Drawing.Point(301, 22);
            this.txtTypeExport.Name = "txtTypeExport";
            this.txtTypeExport.Size = new System.Drawing.Size(102, 26);
            this.txtTypeExport.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Loại hình";
            // 
            // txtExportTotalVehicles
            // 
            this.txtExportTotalVehicles.Location = new System.Drawing.Point(334, 3);
            this.txtExportTotalVehicles.Mask = "00000";
            this.txtExportTotalVehicles.Name = "txtExportTotalVehicles";
            this.txtExportTotalVehicles.Size = new System.Drawing.Size(66, 20);
            this.txtExportTotalVehicles.TabIndex = 3;
            this.txtExportTotalVehicles.ValidatingType = typeof(int);
            this.txtExportTotalVehicles.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtExportTotalVehicles_MaskInputRejected);
            this.txtExportTotalVehicles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtExportTotalVehicles_KeyDown);
            this.txtExportTotalVehicles.Leave += new System.EventHandler(this.txtExportTotalVehicles_Leave);
            // 
            // lblTotalVehicles
            // 
            this.lblTotalVehicles.AutoSize = true;
            this.lblTotalVehicles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVehicles.Location = new System.Drawing.Point(251, 1);
            this.lblTotalVehicles.Name = "lblTotalVehicles";
            this.lblTotalVehicles.Size = new System.Drawing.Size(74, 20);
            this.lblTotalVehicles.TabIndex = 9;
            this.lblTotalVehicles.Text = "Lượng xe";
            // 
            // cbExportHasDeclaration
            // 
            this.cbExportHasDeclaration.AutoSize = true;
            this.cbExportHasDeclaration.Checked = true;
            this.cbExportHasDeclaration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbExportHasDeclaration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbExportHasDeclaration.Location = new System.Drawing.Point(12, 24);
            this.cbExportHasDeclaration.Name = "cbExportHasDeclaration";
            this.cbExportHasDeclaration.Size = new System.Drawing.Size(214, 24);
            this.cbExportHasDeclaration.TabIndex = 4;
            this.cbExportHasDeclaration.Text = "Khai báo tờ khai xuất khẩu";
            this.cbExportHasDeclaration.UseVisualStyleBackColor = true;
            this.cbExportHasDeclaration.CheckedChanged += new System.EventHandler(this.cbHasDeclaration_CheckedChanged);
            // 
            // rdoImport
            // 
            this.rdoImport.AutoSize = true;
            this.rdoImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoImport.Location = new System.Drawing.Point(427, -1);
            this.rdoImport.Name = "rdoImport";
            this.rdoImport.Size = new System.Drawing.Size(168, 24);
            this.rdoImport.TabIndex = 2;
            this.rdoImport.Text = "Khai báo nhập khẩu";
            this.rdoImport.UseVisualStyleBackColor = true;
            this.rdoImport.CheckedChanged += new System.EventHandler(this.rdoImport_CheckedChanged);
            // 
            // gbImportDeclaration
            // 
            this.gbImportDeclaration.Controls.Add(this.dtpImportRegisterDate);
            this.gbImportDeclaration.Controls.Add(this.txtTypeImport);
            this.gbImportDeclaration.Controls.Add(this.label10);
            this.gbImportDeclaration.Controls.Add(this.label7);
            this.gbImportDeclaration.Controls.Add(this.txtImportCompanyCode);
            this.gbImportDeclaration.Controls.Add(this.label11);
            this.gbImportDeclaration.Controls.Add(this.label2);
            this.gbImportDeclaration.Controls.Add(this.label3);
            this.gbImportDeclaration.Controls.Add(this.txtImportProductName);
            this.gbImportDeclaration.Controls.Add(this.label4);
            this.gbImportDeclaration.Controls.Add(this.txtImportNumber);
            this.gbImportDeclaration.Controls.Add(this.txtImportCompanyName);
            this.gbImportDeclaration.Controls.Add(this.label5);
            this.gbImportDeclaration.Controls.Add(this.txtImportProductAmount);
            this.gbImportDeclaration.Controls.Add(this.txtImportUnit);
            this.gbImportDeclaration.Controls.Add(this.label6);
            this.gbImportDeclaration.Enabled = false;
            this.gbImportDeclaration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbImportDeclaration.Location = new System.Drawing.Point(427, 48);
            this.gbImportDeclaration.Name = "gbImportDeclaration";
            this.gbImportDeclaration.Size = new System.Drawing.Size(415, 235);
            this.gbImportDeclaration.TabIndex = 21;
            this.gbImportDeclaration.TabStop = false;
            this.gbImportDeclaration.Text = "Thông tin tờ khai nhập khẩu";
            // 
            // dtpImportRegisterDate
            // 
            this.dtpImportRegisterDate.CustomFormat = "dd/MM/yyyy";
            this.dtpImportRegisterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImportRegisterDate.Location = new System.Drawing.Point(154, 125);
            this.dtpImportRegisterDate.Name = "dtpImportRegisterDate";
            this.dtpImportRegisterDate.Size = new System.Drawing.Size(106, 26);
            this.dtpImportRegisterDate.TabIndex = 17;
            // 
            // txtTypeImport
            // 
            this.txtTypeImport.Location = new System.Drawing.Point(303, 22);
            this.txtTypeImport.Name = "txtTypeImport";
            this.txtTypeImport.Size = new System.Drawing.Size(102, 26);
            this.txtTypeImport.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Ngày đăng ký";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(223, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Loại hình";
            // 
            // txtImportCompanyCode
            // 
            this.txtImportCompanyCode.Location = new System.Drawing.Point(154, 91);
            this.txtImportCompanyCode.Multiline = true;
            this.txtImportCompanyCode.Name = "txtImportCompanyCode";
            this.txtImportCompanyCode.Size = new System.Drawing.Size(251, 28);
            this.txtImportCompanyCode.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 20);
            this.label11.TabIndex = 15;
            this.label11.Text = "Mã Doanh nghiệp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số tờ khai";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên hàng";
            // 
            // txtImportProductName
            // 
            this.txtImportProductName.Location = new System.Drawing.Point(266, 159);
            this.txtImportProductName.Multiline = true;
            this.txtImportProductName.Name = "txtImportProductName";
            this.txtImportProductName.Size = new System.Drawing.Size(145, 64);
            this.txtImportProductName.TabIndex = 20;
            this.txtImportProductName.TextChanged += new System.EventHandler(this.txtImportProductName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên Doanh nghiệp";
            // 
            // txtImportNumber
            // 
            this.txtImportNumber.Location = new System.Drawing.Point(154, 25);
            this.txtImportNumber.Mask = "0000000000";
            this.txtImportNumber.Name = "txtImportNumber";
            this.txtImportNumber.Size = new System.Drawing.Size(66, 26);
            this.txtImportNumber.TabIndex = 13;
            // 
            // txtImportCompanyName
            // 
            this.txtImportCompanyName.Location = new System.Drawing.Point(154, 57);
            this.txtImportCompanyName.Multiline = true;
            this.txtImportCompanyName.Name = "txtImportCompanyName";
            this.txtImportCompanyName.Size = new System.Drawing.Size(251, 28);
            this.txtImportCompanyName.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Lượng Hàng";
            // 
            // txtImportProductAmount
            // 
            this.txtImportProductAmount.Location = new System.Drawing.Point(154, 165);
            this.txtImportProductAmount.Name = "txtImportProductAmount";
            this.txtImportProductAmount.Size = new System.Drawing.Size(106, 26);
            this.txtImportProductAmount.TabIndex = 18;
            // 
            // txtImportUnit
            // 
            this.txtImportUnit.Location = new System.Drawing.Point(154, 194);
            this.txtImportUnit.Name = "txtImportUnit";
            this.txtImportUnit.Size = new System.Drawing.Size(106, 26);
            this.txtImportUnit.TabIndex = 19;
            this.txtImportUnit.Leave += new System.EventHandler(this.txtImportUnit_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Đơn vị tính";
            // 
            // rdoExport
            // 
            this.rdoExport.AutoSize = true;
            this.rdoExport.Checked = true;
            this.rdoExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoExport.Location = new System.Drawing.Point(12, 0);
            this.rdoExport.Name = "rdoExport";
            this.rdoExport.Size = new System.Drawing.Size(162, 24);
            this.rdoExport.TabIndex = 1;
            this.rdoExport.TabStop = true;
            this.rdoExport.Text = "Khai báo xuất khẩu";
            this.rdoExport.UseVisualStyleBackColor = true;
            this.rdoExport.CheckedChanged += new System.EventHandler(this.rdoExport_CheckedChanged);
            // 
            // cbImportHasDeclaration
            // 
            this.cbImportHasDeclaration.AutoSize = true;
            this.cbImportHasDeclaration.Checked = true;
            this.cbImportHasDeclaration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbImportHasDeclaration.Enabled = false;
            this.cbImportHasDeclaration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbImportHasDeclaration.Location = new System.Drawing.Point(427, 28);
            this.cbImportHasDeclaration.Name = "cbImportHasDeclaration";
            this.cbImportHasDeclaration.Size = new System.Drawing.Size(220, 24);
            this.cbImportHasDeclaration.TabIndex = 10;
            this.cbImportHasDeclaration.Text = "Khai báo tờ khai nhập khẩu";
            this.cbImportHasDeclaration.UseVisualStyleBackColor = true;
            this.cbImportHasDeclaration.CheckedChanged += new System.EventHandler(this.cbImportHasDeclaration_CheckedChanged);
            // 
            // btnComfirmExport
            // 
            this.btnComfirmExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComfirmExport.Location = new System.Drawing.Point(860, 316);
            this.btnComfirmExport.Name = "btnComfirmExport";
            this.btnComfirmExport.Size = new System.Drawing.Size(158, 50);
            this.btnComfirmExport.TabIndex = 30;
            this.btnComfirmExport.Text = "Xác nhận xuất cảnh";
            this.btnComfirmExport.UseVisualStyleBackColor = true;
            this.btnComfirmExport.Click += new System.EventHandler(this.btnComfirmExport_Click);
            // 
            // bntConfirmImportCH
            // 
            this.bntConfirmImportCH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntConfirmImportCH.Location = new System.Drawing.Point(860, 372);
            this.bntConfirmImportCH.Name = "bntConfirmImportCH";
            this.bntConfirmImportCH.Size = new System.Drawing.Size(158, 50);
            this.bntConfirmImportCH.TabIndex = 31;
            this.bntConfirmImportCH.Text = "Xác nhận nhập cảnh có hàng";
            this.bntConfirmImportCH.UseVisualStyleBackColor = true;
            this.bntConfirmImportCH.Click += new System.EventHandler(this.bntConfirmImportCH_Click);
            // 
            // btnConfirmImportKH
            // 
            this.btnConfirmImportKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmImportKH.Location = new System.Drawing.Point(860, 428);
            this.btnConfirmImportKH.Name = "btnConfirmImportKH";
            this.btnConfirmImportKH.Size = new System.Drawing.Size(158, 50);
            this.btnConfirmImportKH.TabIndex = 32;
            this.btnConfirmImportKH.Text = "Xác nhận nhập cảnh không hàng";
            this.btnConfirmImportKH.UseVisualStyleBackColor = true;
            this.btnConfirmImportKH.Click += new System.EventHandler(this.btnConfirmImportKH_Click);
            // 
            // btnReset
            // 
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::ECustoms.Properties.Resources.undo;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(344, 606);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(131, 28);
            this.btnReset.TabIndex = 28;
            this.btnReset.Text = "Thiết &lập lại";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = global::ECustoms.Properties.Resources.edit;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(190, 606);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(148, 28);
            this.btnUpdate.TabIndex = 27;
            this.btnUpdate.Text = "C&ập nhật tờ khai";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::ECustoms.Properties.Resources.Exit;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(481, 606);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 28);
            this.button1.TabIndex = 29;
            this.button1.Text = "Th&oát";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::ECustoms.Properties.Resources.save;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(14, 604);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(170, 28);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Tạo mới/lư&u tờ khai";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 639);
            this.Controls.Add(this.btnConfirmImportKH);
            this.Controls.Add(this.bntConfirmImportCH);
            this.Controls.Add(this.btnComfirmExport);
            this.Controls.Add(this.txtExportTotalVehicles);
            this.Controls.Add(this.cbImportHasDeclaration);
            this.Controls.Add(this.lblTotalVehicles);
            this.Controls.Add(this.rdoExport);
            this.Controls.Add(this.gbImportDeclaration);
            this.Controls.Add(this.rdoImport);
            this.Controls.Add(this.cbExportHasDeclaration);
            this.Controls.Add(this.gbExportDeclaration);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBoxVehicle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExport";
            this.ShowInTaskbar = false;
            this.Text = "Khai xuất khẩu - mới nhập ";
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.groupBoxVehicle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicle)).EndInit();
            this.gbExportDeclaration.ResumeLayout(false);
            this.gbExportDeclaration.PerformLayout();
            this.gbImportDeclaration.ResumeLayout(false);
            this.gbImportDeclaration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtExportProductName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtExportCompanyName;
        private System.Windows.Forms.Label lblProductAmount;
        private System.Windows.Forms.TextBox txtExportProductAmount;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtExportUnit;
        private System.Windows.Forms.GroupBox groupBoxVehicle;
        private System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.DataGridView grdVehicle;
        private System.Windows.Forms.MaskedTextBox txtExportNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAddVehicle;
        private System.Windows.Forms.Button btnUpdateVehicle;
        private System.Windows.Forms.Button btnDeleteVehicle;
        private System.Windows.Forms.GroupBox gbExportDeclaration;
        private System.Windows.Forms.CheckBox cbExportHasDeclaration;
        private System.Windows.Forms.Label lblTotalVehicles;
        private System.Windows.Forms.RadioButton rdoImport;
        private System.Windows.Forms.GroupBox gbImportDeclaration;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImportProductName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtImportNumber;
        private System.Windows.Forms.TextBox txtImportCompanyName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtImportProductAmount;
        private System.Windows.Forms.TextBox txtImportUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdoExport;
        private System.Windows.Forms.CheckBox cbImportHasDeclaration;
        private System.Windows.Forms.MaskedTextBox txtExportTotalVehicles;
        private System.Windows.Forms.Button btnAddExisting;
        private System.Windows.Forms.TextBox txtTypeExport;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTypeImport;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnComfirmExport;
        private System.Windows.Forms.Button bntConfirmImportCH;
        private System.Windows.Forms.Button btnConfirmImportKH;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtExportCompanyCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpExportRegisterDate;
        private System.Windows.Forms.DateTimePicker dtpImportRegisterDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtImportCompanyCode;
        private System.Windows.Forms.Label label11;
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