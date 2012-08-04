namespace ECustoms
{
    partial class frmDecleration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDecleration));
            this.grbDecleration = new System.Windows.Forms.GroupBox();
            this.grvDecleration = new System.Windows.Forms.DataGridView();
            this.DeclarationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExportType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisterDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfirmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfirmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifiedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifiedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeclarationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbConfirmStatus = new System.Windows.Forms.CheckBox();
            this.dtpConfirmTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpConfirmFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cbConfirmDate = new System.Windows.Forms.CheckBox();
            this.cbRegDate = new System.Windows.Forms.CheckBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtDeclaraceNumber = new System.Windows.Forms.TextBox();
            this.lblDeclaraceNumber = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewVehicle = new System.Windows.Forms.ListView();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnFee = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnAddImport = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grbDecleration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDecleration)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDecleration
            // 
            this.grbDecleration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDecleration.Controls.Add(this.grvDecleration);
            this.grbDecleration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grbDecleration.Location = new System.Drawing.Point(6, 127);
            this.grbDecleration.Name = "grbDecleration";
            this.grbDecleration.Size = new System.Drawing.Size(851, 209);
            this.grbDecleration.TabIndex = 0;
            this.grbDecleration.TabStop = false;
            this.grbDecleration.Text = "Danh sách tờ khai";
            // 
            // grvDecleration
            // 
            this.grvDecleration.AllowUserToAddRows = false;
            this.grvDecleration.AllowUserToDeleteRows = false;
            this.grvDecleration.AllowUserToOrderColumns = true;
            this.grvDecleration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvDecleration.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeclarationID,
            this.Number,
            this.CompanyCode,
            this.ExportType,
            this.RegisterDate,
            this.ConfirmStatus,
            this.ConfirmDate,
            this.ProductName,
            this.CompanyName,
            this.ProductAmount,
            this.Unit,
            this.ModifiedDate,
            this.ModifiedBy,
            this.CreatedBy,
            this.CreatedDate,
            this.DeclarationType});
            this.grvDecleration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvDecleration.Location = new System.Drawing.Point(3, 16);
            this.grvDecleration.Name = "grvDecleration";
            this.grvDecleration.ReadOnly = true;
            this.grvDecleration.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvDecleration.Size = new System.Drawing.Size(845, 190);
            this.grvDecleration.TabIndex = 0;
            this.grvDecleration.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grvDecleration_CellMouseClick);
            this.grvDecleration.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grvDecleration_CellMouseDoubleClick_1);
            this.grvDecleration.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvDecleration_RowLeave);
            // 
            // DeclarationID
            // 
            this.DeclarationID.DataPropertyName = "DeclarationID";
            this.DeclarationID.HeaderText = "DeclarationID";
            this.DeclarationID.Name = "DeclarationID";
            this.DeclarationID.ReadOnly = true;
            this.DeclarationID.Visible = false;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "Number";
            this.Number.HeaderText = "Số tờ khai";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 110;
            // 
            // CompanyCode
            // 
            this.CompanyCode.DataPropertyName = "CompanyCode";
            this.CompanyCode.HeaderText = "Mã doanh nghiệp";
            this.CompanyCode.Name = "CompanyCode";
            this.CompanyCode.ReadOnly = true;
            this.CompanyCode.Width = 160;
            // 
            // ExportType
            // 
            this.ExportType.DataPropertyName = "Type";
            this.ExportType.HeaderText = "Loại hình";
            this.ExportType.Name = "ExportType";
            this.ExportType.ReadOnly = true;
            // 
            // RegisterDate
            // 
            this.RegisterDate.DataPropertyName = "RegisterDate";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy hh:mm";
            this.RegisterDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.RegisterDate.HeaderText = "Ngày đăng ký";
            this.RegisterDate.Name = "RegisterDate";
            this.RegisterDate.ReadOnly = true;
            this.RegisterDate.Width = 150;
            // 
            // ConfirmStatus
            // 
            this.ConfirmStatus.DataPropertyName = "ConfirmStatus";
            this.ConfirmStatus.HeaderText = "Trạng thái hồ sơ";
            this.ConfirmStatus.Name = "ConfirmStatus";
            this.ConfirmStatus.ReadOnly = true;
            this.ConfirmStatus.Width = 150;
            // 
            // ConfirmDate
            // 
            this.ConfirmDate.DataPropertyName = "ConfirmDate";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy hh:mm";
            this.ConfirmDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.ConfirmDate.HeaderText = "Ngày trả hồ sơ";
            this.ConfirmDate.Name = "ConfirmDate";
            this.ConfirmDate.ReadOnly = true;
            this.ConfirmDate.Width = 150;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Tên hàng";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 120;
            // 
            // CompanyName
            // 
            this.CompanyName.DataPropertyName = "CompanyName";
            this.CompanyName.HeaderText = "Tên doanh nghiệp";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            this.CompanyName.Width = 160;
            // 
            // ProductAmount
            // 
            this.ProductAmount.DataPropertyName = "ProductAmount";
            this.ProductAmount.HeaderText = "Lượng hàng";
            this.ProductAmount.Name = "ProductAmount";
            this.ProductAmount.ReadOnly = true;
            this.ProductAmount.Width = 130;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "Đơn vị tính";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Width = 150;
            // 
            // ModifiedDate
            // 
            this.ModifiedDate.DataPropertyName = "ModifiedDate";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy hh:mm";
            this.ModifiedDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.ModifiedDate.HeaderText = "Sửa lần cuối";
            this.ModifiedDate.Name = "ModifiedDate";
            this.ModifiedDate.ReadOnly = true;
            this.ModifiedDate.Width = 150;
            // 
            // ModifiedBy
            // 
            this.ModifiedBy.DataPropertyName = "ModifiedBy";
            this.ModifiedBy.HeaderText = "Người cập nhật";
            this.ModifiedBy.Name = "ModifiedBy";
            this.ModifiedBy.ReadOnly = true;
            this.ModifiedBy.Width = 150;
            // 
            // CreatedBy
            // 
            this.CreatedBy.DataPropertyName = "CreatedBy";
            this.CreatedBy.HeaderText = "Người tạo";
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.ReadOnly = true;
            // 
            // CreatedDate
            // 
            this.CreatedDate.DataPropertyName = "CreatedDate";
            dataGridViewCellStyle4.Format = "dd/MM/yyyy hh:mm";
            this.CreatedDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.CreatedDate.HeaderText = "Ngày tạo";
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            this.CreatedDate.Width = 150;
            // 
            // DeclarationType
            // 
            this.DeclarationType.DataPropertyName = "DeclarationType";
            this.DeclarationType.HeaderText = "DeclarationType";
            this.DeclarationType.Name = "DeclarationType";
            this.DeclarationType.ReadOnly = true;
            this.DeclarationType.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbConfirmStatus);
            this.groupBox1.Controls.Add(this.dtpConfirmTo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpConfirmFrom);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbConfirmDate);
            this.groupBox1.Controls.Add(this.cbRegDate);
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtCompanyName);
            this.groupBox1.Controls.Add(this.lblCompanyName);
            this.groupBox1.Controls.Add(this.txtDeclaraceNumber);
            this.groupBox1.Controls.Add(this.lblDeclaraceNumber);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(6, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(851, 105);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều kiện tìm kiếm";
            // 
            // cbConfirmStatus
            // 
            this.cbConfirmStatus.AutoSize = true;
            this.cbConfirmStatus.Location = new System.Drawing.Point(551, 73);
            this.cbConfirmStatus.Name = "cbConfirmStatus";
            this.cbConfirmStatus.Size = new System.Drawing.Size(142, 17);
            this.cbConfirmStatus.TabIndex = 20;
            this.cbConfirmStatus.Text = "Chưa xác nhận trả hồ sơ";
            this.cbConfirmStatus.UseVisualStyleBackColor = true;
            this.cbConfirmStatus.CheckedChanged += new System.EventHandler(this.cbConfirmStatus_CheckedChanged);
            // 
            // dtpConfirmTo
            // 
            this.dtpConfirmTo.CustomFormat = "dd/MM/yyyy";
            this.dtpConfirmTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpConfirmTo.Location = new System.Drawing.Point(391, 71);
            this.dtpConfirmTo.Name = "dtpConfirmTo";
            this.dtpConfirmTo.Size = new System.Drawing.Size(86, 20);
            this.dtpConfirmTo.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Đến ngày";
            // 
            // dtpConfirmFrom
            // 
            this.dtpConfirmFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpConfirmFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpConfirmFrom.Location = new System.Drawing.Point(230, 71);
            this.dtpConfirmFrom.Name = "dtpConfirmFrom";
            this.dtpConfirmFrom.Size = new System.Drawing.Size(85, 20);
            this.dtpConfirmFrom.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Từ ngày";
            // 
            // cbConfirmDate
            // 
            this.cbConfirmDate.AutoSize = true;
            this.cbConfirmDate.Location = new System.Drawing.Point(39, 73);
            this.cbConfirmDate.Name = "cbConfirmDate";
            this.cbConfirmDate.Size = new System.Drawing.Size(95, 17);
            this.cbConfirmDate.TabIndex = 15;
            this.cbConfirmDate.Text = "Ngày trả hồ sơ";
            this.cbConfirmDate.UseVisualStyleBackColor = true;
            this.cbConfirmDate.CheckedChanged += new System.EventHandler(this.cbConfirmDate_CheckedChanged);
            // 
            // cbRegDate
            // 
            this.cbRegDate.AutoSize = true;
            this.cbRegDate.Location = new System.Drawing.Point(39, 48);
            this.cbRegDate.Name = "cbRegDate";
            this.cbRegDate.Size = new System.Drawing.Size(93, 17);
            this.cbRegDate.TabIndex = 14;
            this.cbRegDate.Text = "Ngày đăng ký";
            this.cbRegDate.UseVisualStyleBackColor = true;
            this.cbRegDate.CheckedChanged += new System.EventHandler(this.cbRegDate_CheckedChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(391, 46);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(86, 20);
            this.dtpTo.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Đến ngày";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(230, 46);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(85, 20);
            this.dtpFrom.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Từ ngày";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Tất cả",
            "Tờ khai xuất",
            "Tờ khai nhập"});
            this.comboBoxType.Location = new System.Drawing.Point(39, 19);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(114, 21);
            this.comboBoxType.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Loại";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSearch.Image = global::ECustoms.Properties.Resources.search;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(592, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 28);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Tìm tờ kha&i";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(432, 19);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(140, 20);
            this.txtCompanyName.TabIndex = 3;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(332, 23);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(94, 13);
            this.lblCompanyName.TabIndex = 2;
            this.lblCompanyName.Text = "Tên doanh nghiệp";
            // 
            // txtDeclaraceNumber
            // 
            this.txtDeclaraceNumber.Location = new System.Drawing.Point(230, 20);
            this.txtDeclaraceNumber.Name = "txtDeclaraceNumber";
            this.txtDeclaraceNumber.Size = new System.Drawing.Size(96, 20);
            this.txtDeclaraceNumber.TabIndex = 1;
            // 
            // lblDeclaraceNumber
            // 
            this.lblDeclaraceNumber.AutoSize = true;
            this.lblDeclaraceNumber.Location = new System.Drawing.Point(169, 24);
            this.lblDeclaraceNumber.Name = "lblDeclaraceNumber";
            this.lblDeclaraceNumber.Size = new System.Drawing.Size(55, 13);
            this.lblDeclaraceNumber.TabIndex = 0;
            this.lblDeclaraceNumber.Text = "Số tờ khai";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listViewVehicle);
            this.groupBox2.Controls.Add(this.lblHeader);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox2.Location = new System.Drawing.Point(9, 342);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(848, 144);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin phương tiện";
            // 
            // listViewVehicle
            // 
            this.listViewVehicle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewVehicle.Location = new System.Drawing.Point(3, 16);
            this.listViewVehicle.Name = "listViewVehicle";
            this.listViewVehicle.Size = new System.Drawing.Size(842, 125);
            this.listViewVehicle.TabIndex = 2;
            this.listViewVehicle.UseCompatibleStateImageBehavior = false;
            this.listViewVehicle.View = System.Windows.Forms.View.List;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(6, 22);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(0, 13);
            this.lblHeader.TabIndex = 1;
            // 
            // btnFee
            // 
            this.btnFee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFee.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnFee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnFee.Image = global::ECustoms.Properties.Resources.money;
            this.btnFee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFee.Location = new System.Drawing.Point(510, 492);
            this.btnFee.Name = "btnFee";
            this.btnFee.Size = new System.Drawing.Size(90, 28);
            this.btnFee.TabIndex = 10;
            this.btnFee.Text = "XN &thu phí";
            this.btnFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFee.UseVisualStyleBackColor = true;
            this.btnFee.Click += new System.EventHandler(this.btnFee_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnConfirm.Image = global::ECustoms.Properties.Resources.accept;
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(402, 492);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 28);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "X&N trả hồ  sơ";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnAddImport
            // 
            this.btnAddImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddImport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAddImport.Image = global::ECustoms.Properties.Resources.add;
            this.btnAddImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddImport.Location = new System.Drawing.Point(146, 492);
            this.btnAddImport.Name = "btnAddImport";
            this.btnAddImport.Size = new System.Drawing.Size(120, 28);
            this.btnAddImport.TabIndex = 8;
            this.btnAddImport.Text = "Tạo tờ khai nhậ&p";
            this.btnAddImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddImport.UseVisualStyleBackColor = true;
            this.btnAddImport.Click += new System.EventHandler(this.btnAddImport_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnExportExcel.Image = global::ECustoms.Properties.Resources.exce;
            this.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportExcel.Location = new System.Drawing.Point(679, 492);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(100, 28);
            this.btnExportExcel.TabIndex = 4;
            this.btnExportExcel.Text = "Expo&rt tờ khai";
            this.btnExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAdd.Image = global::ECustoms.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(18, 492);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 28);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Tạo tờ kh&ai xuất";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClose.Image = global::ECustoms.Properties.Resources.Exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(787, 492);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Th&oát";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnUpdate.Image = global::ECustoms.Properties.Resources.edit;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(274, 492);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 28);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "&Cập nhật tờ khai";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnDelete.Image = global::ECustoms.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(608, 492);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(63, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Xóa";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmDecleration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 532);
            this.Controls.Add(this.btnFee);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnAddImport);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.grbDecleration);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(868, 553);
            this.Name = "frmDecleration";
            this.ShowInTaskbar = false;
            this.Text = "Danh sách tờ khai";
            this.Load += new System.EventHandler(this.frmDecleration_Load);
            this.grbDecleration.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvDecleration)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDecleration;
        private System.Windows.Forms.DataGridView grvDecleration;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtDeclaraceNumber;
        private System.Windows.Forms.Label lblDeclaraceNumber;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ListView listViewVehicle;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddImport;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeclarationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExportType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisterDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfirmStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfirmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifiedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifiedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeclarationType;
        private System.Windows.Forms.DateTimePicker dtpConfirmTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpConfirmFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbConfirmDate;
        private System.Windows.Forms.CheckBox cbRegDate;
        private System.Windows.Forms.CheckBox cbConfirmStatus;
        private System.Windows.Forms.Button btnFee;
    }
}