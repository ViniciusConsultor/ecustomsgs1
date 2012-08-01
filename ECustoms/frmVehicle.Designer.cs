namespace ECustoms
{
    partial class frmVehicle
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVehicle));
            this.lblPlateNumber = new System.Windows.Forms.Label();
            this.txtPlateNumber = new System.Windows.Forms.TextBox();
            this.txtNumberOfContainer = new System.Windows.Forms.TextBox();
            this.lblNumberOfContainer = new System.Windows.Forms.Label();
            this.txtDriverName = new System.Windows.Forms.TextBox();
            this.lblDriverName = new System.Windows.Forms.Label();
            this.lblExportDate = new System.Windows.Forms.Label();
            this.dtpExportDate = new System.Windows.Forms.DateTimePicker();
            this.mtxtExportHour = new System.Windows.Forms.MaskedTextBox();
            this.mtxtImportHour = new System.Windows.Forms.MaskedTextBox();
            this.dtpImportDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.btnConfirmExport = new System.Windows.Forms.Button();
            this.btnConfirmImport = new System.Windows.Forms.Button();
            this.lblIsExport = new System.Windows.Forms.Label();
            this.lblIsImport = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdVehicle = new System.Windows.Forms.DataGridView();
            this.PlateNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tblVehicleTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new ECustoms.DataSet2();
            this.ExportGoodType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tblGoodsTypeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ImportGoodType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.VehicleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtVehicleChinese = new System.Windows.Forms.TextBox();
            this.lblVehicleChinese = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbVehicleType = new System.Windows.Forms.ComboBox();
            this.tblVehicleTypeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cbExportGoodType = new System.Windows.Forms.ComboBox();
            this.tblGoodsTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbImportGoodType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblVehicleTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblGoodsTypeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblVehicleTypeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblGoodsTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlateNumber
            // 
            this.lblPlateNumber.AutoSize = true;
            this.lblPlateNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlateNumber.Location = new System.Drawing.Point(12, 9);
            this.lblPlateNumber.Name = "lblPlateNumber";
            this.lblPlateNumber.Size = new System.Drawing.Size(113, 20);
            this.lblPlateNumber.TabIndex = 0;
            this.lblPlateNumber.Text = "Biển kiểm soát";
            // 
            // txtPlateNumber
            // 
            this.txtPlateNumber.Location = new System.Drawing.Point(131, 9);
            this.txtPlateNumber.MaxLength = 12;
            this.txtPlateNumber.Name = "txtPlateNumber";
            this.txtPlateNumber.Size = new System.Drawing.Size(98, 20);
            this.txtPlateNumber.TabIndex = 1;
            this.txtPlateNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlateNumber_KeyPress);
            this.txtPlateNumber.Leave += new System.EventHandler(this.txtPlateNumber_Leave);
            // 
            // txtNumberOfContainer
            // 
            this.txtNumberOfContainer.Location = new System.Drawing.Point(594, 8);
            this.txtNumberOfContainer.MaxLength = 12;
            this.txtNumberOfContainer.Name = "txtNumberOfContainer";
            this.txtNumberOfContainer.Size = new System.Drawing.Size(83, 20);
            this.txtNumberOfContainer.TabIndex = 3;
            // 
            // lblNumberOfContainer
            // 
            this.lblNumberOfContainer.AutoSize = true;
            this.lblNumberOfContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfContainer.Location = new System.Drawing.Point(486, 6);
            this.lblNumberOfContainer.Name = "lblNumberOfContainer";
            this.lblNumberOfContainer.Size = new System.Drawing.Size(102, 20);
            this.lblNumberOfContainer.TabIndex = 2;
            this.lblNumberOfContainer.Text = "Số Container";
            // 
            // txtDriverName
            // 
            this.txtDriverName.Location = new System.Drawing.Point(307, 6);
            this.txtDriverName.Name = "txtDriverName";
            this.txtDriverName.Size = new System.Drawing.Size(173, 20);
            this.txtDriverName.TabIndex = 2;
            // 
            // lblDriverName
            // 
            this.lblDriverName.AutoSize = true;
            this.lblDriverName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverName.Location = new System.Drawing.Point(226, 8);
            this.lblDriverName.Name = "lblDriverName";
            this.lblDriverName.Size = new System.Drawing.Size(75, 20);
            this.lblDriverName.TabIndex = 4;
            this.lblDriverName.Text = "Tên lái xe";
            // 
            // lblExportDate
            // 
            this.lblExportDate.AutoSize = true;
            this.lblExportDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportDate.Location = new System.Drawing.Point(13, 64);
            this.lblExportDate.Name = "lblExportDate";
            this.lblExportDate.Size = new System.Drawing.Size(118, 20);
            this.lblExportDate.TabIndex = 6;
            this.lblExportDate.Text = "Ngày xuất cảnh";
            // 
            // dtpExportDate
            // 
            this.dtpExportDate.CustomFormat = "dd/MM/yyyy";
            this.dtpExportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExportDate.Location = new System.Drawing.Point(137, 67);
            this.dtpExportDate.Name = "dtpExportDate";
            this.dtpExportDate.Size = new System.Drawing.Size(124, 20);
            this.dtpExportDate.TabIndex = 4;
            this.dtpExportDate.Value = new System.DateTime(2011, 4, 12, 8, 32, 28, 0);
            // 
            // mtxtExportHour
            // 
            this.mtxtExportHour.Location = new System.Drawing.Point(280, 68);
            this.mtxtExportHour.Mask = "00:00";
            this.mtxtExportHour.Name = "mtxtExportHour";
            this.mtxtExportHour.Size = new System.Drawing.Size(33, 20);
            this.mtxtExportHour.TabIndex = 5;
            this.mtxtExportHour.ValidatingType = typeof(System.DateTime);
            // 
            // mtxtImportHour
            // 
            this.mtxtImportHour.Location = new System.Drawing.Point(590, 70);
            this.mtxtImportHour.Mask = "00:00";
            this.mtxtImportHour.Name = "mtxtImportHour";
            this.mtxtImportHour.Size = new System.Drawing.Size(33, 20);
            this.mtxtImportHour.TabIndex = 7;
            this.mtxtImportHour.ValidatingType = typeof(System.DateTime);
            // 
            // dtpImportDate
            // 
            this.dtpImportDate.CustomFormat = "dd/MM/yyyy";
            this.dtpImportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImportDate.Location = new System.Drawing.Point(457, 70);
            this.dtpImportDate.Name = "dtpImportDate";
            this.dtpImportDate.Size = new System.Drawing.Size(127, 20);
            this.dtpImportDate.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(327, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ngày nhập cảnh";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(13, 108);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(80, 20);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Trạng thái";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(111, 108);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(658, 73);
            this.txtStatus.TabIndex = 9;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(109, 187);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(660, 73);
            this.txtNote.TabIndex = 10;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(13, 190);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(64, 20);
            this.lblNote.TabIndex = 14;
            this.lblNote.Text = "Ghi chú";
            // 
            // btnConfirmExport
            // 
            this.btnConfirmExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnConfirmExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmExport.Location = new System.Drawing.Point(790, 108);
            this.btnConfirmExport.Name = "btnConfirmExport";
            this.btnConfirmExport.Size = new System.Drawing.Size(210, 52);
            this.btnConfirmExport.TabIndex = 11;
            this.btnConfirmExport.Text = "Xác nhận xuất cảnh";
            this.btnConfirmExport.UseVisualStyleBackColor = true;
            this.btnConfirmExport.Click += new System.EventHandler(this.btnConfirmExport_Click);
            // 
            // btnConfirmImport
            // 
            this.btnConfirmImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmImport.Location = new System.Drawing.Point(790, 164);
            this.btnConfirmImport.Name = "btnConfirmImport";
            this.btnConfirmImport.Size = new System.Drawing.Size(210, 52);
            this.btnConfirmImport.TabIndex = 12;
            this.btnConfirmImport.Text = "Xác nhận nhập cảnh";
            this.btnConfirmImport.UseVisualStyleBackColor = true;
            this.btnConfirmImport.Click += new System.EventHandler(this.btnConfirmImport_Click);
            // 
            // lblIsExport
            // 
            this.lblIsExport.AutoSize = true;
            this.lblIsExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsExport.ForeColor = System.Drawing.Color.Red;
            this.lblIsExport.Location = new System.Drawing.Point(137, 67);
            this.lblIsExport.Name = "lblIsExport";
            this.lblIsExport.Size = new System.Drawing.Size(120, 20);
            this.lblIsExport.TabIndex = 17;
            this.lblIsExport.Text = "Chưa xuất cảnh";
            // 
            // lblIsImport
            // 
            this.lblIsImport.AutoSize = true;
            this.lblIsImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsImport.ForeColor = System.Drawing.Color.Red;
            this.lblIsImport.Location = new System.Drawing.Point(458, 68);
            this.lblIsImport.Name = "lblIsImport";
            this.lblIsImport.Size = new System.Drawing.Size(126, 20);
            this.lblIsImport.TabIndex = 18;
            this.lblIsImport.Text = "Chưa nhập cảnh";
            // 
            // btnReset
            // 
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::ECustoms.Properties.Resources.undo;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(483, 273);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(123, 28);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "Thiết &lập lại";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::ECustoms.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(404, 273);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(73, 28);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "&Xóa";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = global::ECustoms.Properties.Resources.edit;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(197, 273);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(201, 28);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "&Cập nhật phương tiện";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::ECustoms.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(5, 273);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(186, 28);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Lư&u trữ phương tiện";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ECustoms.Properties.Resources.Exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(612, 273);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 28);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Th&oát";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.grdVehicle);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 307);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1001, 263);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Các xe vừa nhập";
            // 
            // grdVehicle
            // 
            this.grdVehicle.AllowUserToAddRows = false;
            this.grdVehicle.AllowUserToDeleteRows = false;
            this.grdVehicle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdVehicle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVehicle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlateNumber,
            this.DriverName,
            this.ExportDate,
            this.VehicleType,
            this.ExportGoodType,
            this.ImportGoodType,
            this.VehicleID,
            this.Status,
            this.Note});
            this.grdVehicle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVehicle.Location = new System.Drawing.Point(3, 22);
            this.grdVehicle.MultiSelect = false;
            this.grdVehicle.Name = "grdVehicle";
            this.grdVehicle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdVehicle.Size = new System.Drawing.Size(995, 238);
            this.grdVehicle.TabIndex = 19;
            this.grdVehicle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVehicle_CellEndEdit);
            this.grdVehicle.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdVehicle_CellMouseDoubleClick);
            // 
            // PlateNumber
            // 
            this.PlateNumber.DataPropertyName = "PlateNumber";
            this.PlateNumber.HeaderText = "Biển kiểm soát";
            this.PlateNumber.Name = "PlateNumber";
            // 
            // DriverName
            // 
            this.DriverName.DataPropertyName = "DriverName";
            this.DriverName.HeaderText = "Tên lái xe";
            this.DriverName.Name = "DriverName";
            // 
            // ExportDate
            // 
            this.ExportDate.DataPropertyName = "ExportDate";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.ExportDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ExportDate.HeaderText = "Ngày xuất cảnh";
            this.ExportDate.Name = "ExportDate";
            // 
            // VehicleType
            // 
            this.VehicleType.DataPropertyName = "vehicleTypeId";
            this.VehicleType.DataSource = this.tblVehicleTypeBindingSource;
            this.VehicleType.DisplayMember = "Name";
            this.VehicleType.HeaderText = "Loại trọng tải";
            this.VehicleType.Name = "VehicleType";
            this.VehicleType.ValueMember = "VehicleTypeID";
            // 
            // tblVehicleTypeBindingSource
            // 
            this.tblVehicleTypeBindingSource.DataMember = "tblVehicleType";
            this.tblVehicleTypeBindingSource.DataSource = this.dataSet2;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ExportGoodType
            // 
            this.ExportGoodType.DataPropertyName = "ExportGoodTypeId";
            this.ExportGoodType.DataSource = this.tblGoodsTypeBindingSource1;
            this.ExportGoodType.DisplayMember = "TypeName";
            this.ExportGoodType.HeaderText = "Loại hàng hóa xuất";
            this.ExportGoodType.Name = "ExportGoodType";
            this.ExportGoodType.ValueMember = "TypeId";
            // 
            // tblGoodsTypeBindingSource1
            // 
            this.tblGoodsTypeBindingSource1.DataMember = "tblGoodsType";
            this.tblGoodsTypeBindingSource1.DataSource = this.dataSet2;
            // 
            // ImportGoodType
            // 
            this.ImportGoodType.DataPropertyName = "ImportGoodTypeId";
            this.ImportGoodType.DataSource = this.tblGoodsTypeBindingSource1;
            this.ImportGoodType.DisplayMember = "TypeName";
            this.ImportGoodType.HeaderText = "Loại hàng hóa nhập";
            this.ImportGoodType.Name = "ImportGoodType";
            this.ImportGoodType.ValueMember = "TypeId";
            // 
            // VehicleID
            // 
            this.VehicleID.DataPropertyName = "VehicleID";
            this.VehicleID.HeaderText = "VehicleID";
            this.VehicleID.Name = "VehicleID";
            this.VehicleID.Visible = false;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Diễn giải";
            this.Status.Name = "Status";
            // 
            // Note
            // 
            this.Note.DataPropertyName = "Note";
            this.Note.HeaderText = "Ghi chú";
            this.Note.Name = "Note";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(790, 222);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(210, 52);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtVehicleChinese
            // 
            this.txtVehicleChinese.Location = new System.Drawing.Point(307, 38);
            this.txtVehicleChinese.MaxLength = 12;
            this.txtVehicleChinese.Name = "txtVehicleChinese";
            this.txtVehicleChinese.Size = new System.Drawing.Size(173, 20);
            this.txtVehicleChinese.TabIndex = 5;
            // 
            // lblVehicleChinese
            // 
            this.lblVehicleChinese.AutoSize = true;
            this.lblVehicleChinese.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleChinese.Location = new System.Drawing.Point(12, 36);
            this.lblVehicleChinese.Name = "lblVehicleChinese";
            this.lblVehicleChinese.Size = new System.Drawing.Size(193, 20);
            this.lblVehicleChinese.TabIndex = 21;
            this.lblVehicleChinese.Text = "Biển kiểm soát xe sang tải";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(683, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Loại trọng tải";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(683, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Loại hàng hóa xuất";
            // 
            // cbVehicleType
            // 
            this.cbVehicleType.DataSource = this.tblVehicleTypeBindingSource1;
            this.cbVehicleType.DisplayMember = "Name";
            this.cbVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVehicleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVehicleType.FormattingEnabled = true;
            this.cbVehicleType.Location = new System.Drawing.Point(836, 5);
            this.cbVehicleType.Name = "cbVehicleType";
            this.cbVehicleType.Size = new System.Drawing.Size(164, 23);
            this.cbVehicleType.TabIndex = 4;
            this.cbVehicleType.ValueMember = "VehicleTypeID";
            // 
            // tblVehicleTypeBindingSource1
            // 
            this.tblVehicleTypeBindingSource1.DataMember = "tblVehicleType";
            this.tblVehicleTypeBindingSource1.DataSource = this.dataSet2;
            // 
            // cbExportGoodType
            // 
            this.cbExportGoodType.DataSource = this.tblGoodsTypeBindingSource;
            this.cbExportGoodType.DisplayMember = "TypeName";
            this.cbExportGoodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExportGoodType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbExportGoodType.FormattingEnabled = true;
            this.cbExportGoodType.Location = new System.Drawing.Point(836, 39);
            this.cbExportGoodType.Name = "cbExportGoodType";
            this.cbExportGoodType.Size = new System.Drawing.Size(164, 23);
            this.cbExportGoodType.TabIndex = 6;
            this.cbExportGoodType.ValueMember = "TypeId";
            // 
            // tblGoodsTypeBindingSource
            // 
            this.tblGoodsTypeBindingSource.DataMember = "tblGoodsType";
            this.tblGoodsTypeBindingSource.DataSource = this.dataSet2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PlateNumber";
            this.dataGridViewTextBoxColumn1.HeaderText = "Biển kiểm soát";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 140;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DriverName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên lái xe";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ExportDate";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn3.HeaderText = "Ngày xuất cảnh";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "VehicleID";
            this.dataGridViewTextBoxColumn4.HeaderText = "VehicleID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn5.HeaderText = "Diễn giải";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Note";
            this.dataGridViewTextBoxColumn6.HeaderText = "Ghi chú";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 198;
            // 
            // cbImportGoodType
            // 
            this.cbImportGoodType.DataSource = this.tblGoodsTypeBindingSource;
            this.cbImportGoodType.DisplayMember = "TypeName";
            this.cbImportGoodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImportGoodType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbImportGoodType.FormattingEnabled = true;
            this.cbImportGoodType.Location = new System.Drawing.Point(836, 68);
            this.cbImportGoodType.Name = "cbImportGoodType";
            this.cbImportGoodType.Size = new System.Drawing.Size(164, 23);
            this.cbImportGoodType.TabIndex = 26;
            this.cbImportGoodType.ValueMember = "TypeId";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(683, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Loại hàng hóa nhập";
            // 
            // frmVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 587);
            this.Controls.Add(this.cbImportGoodType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbExportGoodType);
            this.Controls.Add(this.cbVehicleType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVehicleChinese);
            this.Controls.Add(this.lblVehicleChinese);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblIsImport);
            this.Controls.Add(this.lblIsExport);
            this.Controls.Add(this.btnConfirmImport);
            this.Controls.Add(this.btnConfirmExport);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.mtxtImportHour);
            this.Controls.Add(this.dtpImportDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtxtExportHour);
            this.Controls.Add(this.dtpExportDate);
            this.Controls.Add(this.lblExportDate);
            this.Controls.Add(this.txtDriverName);
            this.Controls.Add(this.lblDriverName);
            this.Controls.Add(this.txtNumberOfContainer);
            this.Controls.Add(this.lblNumberOfContainer);
            this.Controls.Add(this.txtPlateNumber);
            this.Controls.Add(this.lblPlateNumber);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1021, 614);
            this.Name = "frmVehicle";
            this.ShowInTaskbar = false;
            this.Text = "Khai báo phương tiện";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVehicle_FormClosing);
            this.Load += new System.EventHandler(this.frmVehicle_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblVehicleTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblGoodsTypeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblVehicleTypeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblGoodsTypeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblPlateNumber;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.TextBox txtNumberOfContainer;
        private System.Windows.Forms.Label lblNumberOfContainer;
        private System.Windows.Forms.TextBox txtDriverName;
        private System.Windows.Forms.Label lblDriverName;
        private System.Windows.Forms.Label lblExportDate;
        private System.Windows.Forms.MaskedTextBox mtxtExportHour;
        private System.Windows.Forms.MaskedTextBox mtxtImportHour;
        private System.Windows.Forms.DateTimePicker dtpImportDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Button btnConfirmExport;
        private System.Windows.Forms.Button btnConfirmImport;
        private System.Windows.Forms.DateTimePicker dtpExportDate;
        private System.Windows.Forms.Label lblIsExport;
        private System.Windows.Forms.Label lblIsImport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdVehicle;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtVehicleChinese;
        public System.Windows.Forms.Label lblVehicleChinese;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbVehicleType;
        private System.Windows.Forms.ComboBox cbExportGoodType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource tblVehicleTypeBindingSource;
        private DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource tblVehicleTypeBindingSource1;
        private System.Windows.Forms.BindingSource tblGoodsTypeBindingSource;
        private System.Windows.Forms.BindingSource tblGoodsTypeBindingSource1;
        private System.Windows.Forms.ComboBox cbImportGoodType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlateNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExportDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn VehicleType;
        private System.Windows.Forms.DataGridViewComboBoxColumn ExportGoodType;
        private System.Windows.Forms.DataGridViewComboBoxColumn ImportGoodType;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
    }
}