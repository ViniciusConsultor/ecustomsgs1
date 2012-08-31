namespace ECustoms
{
    partial class frmDeclarationFilesManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeclarationFilesManagement));
            this.lblDeclarationNumber = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePickerReturn = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerHandover = new System.Windows.Forms.DateTimePicker();
            this.txtType = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbxCustomsCode = new System.Windows.Forms.ComboBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtRegisteredYear = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grvDeclarationList = new System.Windows.Forms.DataGridView();
            this.DeclarationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tblLoanStatusBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new ECustoms.DataSet2();
            this.FilesLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomsCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateReturn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateHandover = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonHandoverUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonReceive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonHandoverSecondUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonReceiveSecond = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblLoanStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewLoanStatus = new System.Windows.Forms.Button();
            this.btnGetFiles = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReturnFiles = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tblLoanStatusBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDeclarationList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLoanStatusBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLoanStatusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLoanStatusBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDeclarationNumber
            // 
            this.lblDeclarationNumber.AutoSize = true;
            this.lblDeclarationNumber.Location = new System.Drawing.Point(6, 17);
            this.lblDeclarationNumber.Name = "lblDeclarationNumber";
            this.lblDeclarationNumber.Size = new System.Drawing.Size(55, 13);
            this.lblDeclarationNumber.TabIndex = 0;
            this.lblDeclarationNumber.Text = "Số tờ khai";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DeclarationID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "PersonHandoverUserName";
            this.dataGridViewTextBoxColumn9.FillWeight = 2.856749E-05F;
            this.dataGridViewTextBoxColumn9.HeaderText = "Người bàn giao lên phúc tập";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Number";
            this.dataGridViewTextBoxColumn2.FillWeight = 5.30004F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Số tờ khai";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 96;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "PersonReceive";
            this.dataGridViewTextBoxColumn10.FillWeight = 8.51311E-05F;
            this.dataGridViewTextBoxColumn10.HeaderText = "Người nhận bàn giao lên phúc tập";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 200;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "CreatedDate";
            this.dataGridViewTextBoxColumn8.FillWeight = 558.3757F;
            this.dataGridViewTextBoxColumn8.HeaderText = "CreatedDate";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 96;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "PersonHandoverSecondUserName";
            this.dataGridViewTextBoxColumn11.FillWeight = 0.000259347F;
            this.dataGridViewTextBoxColumn11.HeaderText = "Người bàn giao sang lưu trữ";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DateHandover";
            this.dataGridViewTextBoxColumn7.FillWeight = 275.9182F;
            this.dataGridViewTextBoxColumn7.HeaderText = "Ngày bàn giao lưu trữ";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 96;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CompanyName";
            this.dataGridViewTextBoxColumn3.FillWeight = 23.97429F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Tên đơn vị XNK";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 96;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DateReturn";
            this.dataGridViewTextBoxColumn6.FillWeight = 136.177F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Ngày trả hồ sơ";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 96;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CustomsCode";
            this.dataGridViewTextBoxColumn4.FillWeight = 33.09856F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Mã Hải quan";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 96;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Type";
            this.dataGridViewTextBoxColumn5.FillWeight = 67.15515F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Loại hình";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 96;
            // 
            // dateTimePickerReturn
            // 
            this.dateTimePickerReturn.Checked = false;
            this.dateTimePickerReturn.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerReturn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerReturn.Location = new System.Drawing.Point(98, 41);
            this.dateTimePickerReturn.Name = "dateTimePickerReturn";
            this.dateTimePickerReturn.ShowCheckBox = true;
            this.dateTimePickerReturn.Size = new System.Drawing.Size(113, 20);
            this.dateTimePickerReturn.TabIndex = 35;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dateTimePickerReturn);
            this.groupBox1.Controls.Add(this.dateTimePickerHandover);
            this.groupBox1.Controls.Add(this.txtType);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cbxCustomsCode);
            this.groupBox1.Controls.Add(this.txtCompanyName);
            this.groupBox1.Controls.Add(this.txtRegisteredYear);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblDeclarationNumber);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(10, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1010, 76);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều kiện tìm kiếm";
            // 
            // dateTimePickerHandover
            // 
            this.dateTimePickerHandover.Checked = false;
            this.dateTimePickerHandover.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerHandover.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerHandover.Location = new System.Drawing.Point(559, 41);
            this.dateTimePickerHandover.Name = "dateTimePickerHandover";
            this.dateTimePickerHandover.ShowCheckBox = true;
            this.dateTimePickerHandover.Size = new System.Drawing.Size(98, 20);
            this.dateTimePickerHandover.TabIndex = 34;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(318, 13);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(121, 20);
            this.txtType.TabIndex = 15;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSearch.Image = global::ECustoms.Properties.Resources.search;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(914, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 28);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Tìm k&iếm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbxCustomsCode
            // 
            this.cbxCustomsCode.FormattingEnabled = true;
            this.cbxCustomsCode.Location = new System.Drawing.Point(766, 14);
            this.cbxCustomsCode.Name = "cbxCustomsCode";
            this.cbxCustomsCode.Size = new System.Drawing.Size(113, 21);
            this.cbxCustomsCode.TabIndex = 13;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(318, 41);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(121, 20);
            this.txtCompanyName.TabIndex = 11;
            // 
            // txtRegisteredYear
            // 
            this.txtRegisteredYear.Location = new System.Drawing.Point(559, 13);
            this.txtRegisteredYear.Name = "txtRegisteredYear";
            this.txtRegisteredYear.Size = new System.Drawing.Size(98, 20);
            this.txtRegisteredYear.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tên đơn vị XNK";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(445, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Ngày bàn giao lưu trữ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ngày trả hồ sơ";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(98, 13);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(113, 20);
            this.txtNumber.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loại hình";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Năm đăng ký";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(674, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã ĐV Hải quan";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.grvDeclarationList);
            this.groupBox2.Location = new System.Drawing.Point(10, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1013, 369);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách tờ khai";
            // 
            // grvDeclarationList
            // 
            this.grvDeclarationList.AllowUserToAddRows = false;
            this.grvDeclarationList.AllowUserToDeleteRows = false;
            this.grvDeclarationList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeclarationID,
            this.Number,
            this.LoanStatus,
            this.FilesLocation,
            this.CompanyName,
            this.CustomsCode,
            this.Type,
            this.DateReturn,
            this.DateHandover,
            this.CreatedDate,
            this.PersonHandoverUserName,
            this.PersonReceive,
            this.PersonHandoverSecondUserName,
            this.PersonReceiveSecond});
            this.grvDeclarationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvDeclarationList.Location = new System.Drawing.Point(3, 16);
            this.grvDeclarationList.Name = "grvDeclarationList";
            this.grvDeclarationList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvDeclarationList.Size = new System.Drawing.Size(1007, 350);
            this.grvDeclarationList.TabIndex = 0;
            this.grvDeclarationList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvDeclarationList_CellDoubleClick);
            this.grvDeclarationList.SelectionChanged += new System.EventHandler(this.grvDeclarationList_SelectionChanged);
            // 
            // DeclarationID
            // 
            this.DeclarationID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DeclarationID.DataPropertyName = "DeclarationID";
            this.DeclarationID.HeaderText = "ID";
            this.DeclarationID.Name = "DeclarationID";
            this.DeclarationID.Visible = false;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "Number";
            this.Number.FillWeight = 5.30004F;
            this.Number.HeaderText = "Số tờ khai";
            this.Number.Name = "Number";
            // 
            // LoanStatus
            // 
            this.LoanStatus.DataPropertyName = "LoanStatus";
            this.LoanStatus.DataSource = this.tblLoanStatusBindingSource2;
            this.LoanStatus.DisplayMember = "StatusName";
            this.LoanStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoanStatus.HeaderText = "Trạng thái hồ sơ";
            this.LoanStatus.Name = "LoanStatus";
            this.LoanStatus.ReadOnly = true;
            this.LoanStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LoanStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.LoanStatus.ValueMember = "StatusCode";
            this.LoanStatus.Width = 150;
            // 
            // tblLoanStatusBindingSource2
            // 
            this.tblLoanStatusBindingSource2.DataMember = "tblLoanStatus";
            this.tblLoanStatusBindingSource2.DataSource = this.dataSet2;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FilesLocation
            // 
            this.FilesLocation.DataPropertyName = "FilesLocation";
            this.FilesLocation.HeaderText = "Vị trí lưu trữ";
            this.FilesLocation.Name = "FilesLocation";
            this.FilesLocation.Width = 200;
            // 
            // CompanyName
            // 
            this.CompanyName.DataPropertyName = "CompanyName";
            this.CompanyName.FillWeight = 23.97429F;
            this.CompanyName.HeaderText = "Tên đơn vị XNK";
            this.CompanyName.Name = "CompanyName";
            // 
            // CustomsCode
            // 
            this.CustomsCode.DataPropertyName = "CustomsCode";
            this.CustomsCode.FillWeight = 33.09856F;
            this.CustomsCode.HeaderText = "Mã Hải quan";
            this.CustomsCode.Name = "CustomsCode";
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.FillWeight = 67.15515F;
            this.Type.HeaderText = "Loại hình";
            this.Type.Name = "Type";
            // 
            // DateReturn
            // 
            this.DateReturn.DataPropertyName = "DateReturn";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy hh:mm";
            this.DateReturn.DefaultCellStyle = dataGridViewCellStyle1;
            this.DateReturn.FillWeight = 136.177F;
            this.DateReturn.HeaderText = "Ngày trả hồ sơ";
            this.DateReturn.Name = "DateReturn";
            this.DateReturn.Width = 120;
            // 
            // DateHandover
            // 
            this.DateHandover.DataPropertyName = "DateHandover";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy hh:mm";
            this.DateHandover.DefaultCellStyle = dataGridViewCellStyle2;
            this.DateHandover.FillWeight = 275.9182F;
            this.DateHandover.HeaderText = "Ngày bàn giao lưu trữ";
            this.DateHandover.Name = "DateHandover";
            this.DateHandover.Width = 150;
            // 
            // CreatedDate
            // 
            this.CreatedDate.DataPropertyName = "CreatedDate";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy hh:mm";
            this.CreatedDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.CreatedDate.FillWeight = 558.3757F;
            this.CreatedDate.HeaderText = "Ngày đăng ký";
            this.CreatedDate.Name = "CreatedDate";
            // 
            // PersonHandoverUserName
            // 
            this.PersonHandoverUserName.DataPropertyName = "PersonHandoverUserName";
            this.PersonHandoverUserName.FillWeight = 2.856749E-05F;
            this.PersonHandoverUserName.HeaderText = "Người bàn giao lên phúc tập";
            this.PersonHandoverUserName.Name = "PersonHandoverUserName";
            this.PersonHandoverUserName.Width = 200;
            // 
            // PersonReceive
            // 
            this.PersonReceive.DataPropertyName = "PersonReceive";
            this.PersonReceive.FillWeight = 8.51311E-05F;
            this.PersonReceive.HeaderText = "Người nhận bàn giao lên phúc tập";
            this.PersonReceive.Name = "PersonReceive";
            this.PersonReceive.Width = 200;
            // 
            // PersonHandoverSecondUserName
            // 
            this.PersonHandoverSecondUserName.DataPropertyName = "PersonHandoverSecondUserName";
            this.PersonHandoverSecondUserName.FillWeight = 0.000259347F;
            this.PersonHandoverSecondUserName.HeaderText = "Người bàn giao sang lưu trữ";
            this.PersonHandoverSecondUserName.Name = "PersonHandoverSecondUserName";
            this.PersonHandoverSecondUserName.Width = 200;
            // 
            // PersonReceiveSecond
            // 
            this.PersonReceiveSecond.DataPropertyName = "PersonReceiveSecond";
            this.PersonReceiveSecond.FillWeight = 0.000795932F;
            this.PersonReceiveSecond.HeaderText = "Người nhận bàn giao sang lưu trữ";
            this.PersonReceiveSecond.Name = "PersonReceiveSecond";
            this.PersonReceiveSecond.Width = 200;
            // 
            // tblLoanStatusBindingSource
            // 
            this.tblLoanStatusBindingSource.DataMember = "tblLoanStatus";
            this.tblLoanStatusBindingSource.DataSource = this.dataSet2;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "PersonReceiveSecond";
            this.dataGridViewTextBoxColumn12.FillWeight = 0.000795932F;
            this.dataGridViewTextBoxColumn12.HeaderText = "Người nhận bàn giao sang lưu trữ";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 200;
            // 
            // btnViewLoanStatus
            // 
            this.btnViewLoanStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewLoanStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnViewLoanStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewLoanStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnViewLoanStatus.Image = global::ECustoms.Properties.Resources.view;
            this.btnViewLoanStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewLoanStatus.Location = new System.Drawing.Point(448, 461);
            this.btnViewLoanStatus.Name = "btnViewLoanStatus";
            this.btnViewLoanStatus.Size = new System.Drawing.Size(163, 28);
            this.btnViewLoanStatus.TabIndex = 18;
            this.btnViewLoanStatus.Text = "&Xem chi tiết mượn trả hồ sơ";
            this.btnViewLoanStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewLoanStatus.UseVisualStyleBackColor = true;
            this.btnViewLoanStatus.Click += new System.EventHandler(this.btnViewLoanStatus_Click);
            // 
            // btnGetFiles
            // 
            this.btnGetFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetFiles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnGetFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnGetFiles.Image = global::ECustoms.Properties.Resources.exportSmall;
            this.btnGetFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetFiles.Location = new System.Drawing.Point(617, 461);
            this.btnGetFiles.Name = "btnGetFiles";
            this.btnGetFiles.Size = new System.Drawing.Size(89, 28);
            this.btnGetFiles.TabIndex = 16;
            this.btnGetFiles.Text = "&Mượn hồ sơ";
            this.btnGetFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetFiles.UseVisualStyleBackColor = true;
            this.btnGetFiles.Click += new System.EventHandler(this.btnGetFiles_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClose.Image = global::ECustoms.Properties.Resources.Exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(957, 461);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 28);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Th&oát";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReturnFiles
            // 
            this.btnReturnFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturnFiles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReturnFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnReturnFiles.Image = global::ECustoms.Properties.Resources.importSmall;
            this.btnReturnFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturnFiles.Location = new System.Drawing.Point(712, 461);
            this.btnReturnFiles.Name = "btnReturnFiles";
            this.btnReturnFiles.Size = new System.Drawing.Size(82, 28);
            this.btnReturnFiles.TabIndex = 19;
            this.btnReturnFiles.Text = "&Trả hồ sơ";
            this.btnReturnFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReturnFiles.UseVisualStyleBackColor = true;
            this.btnReturnFiles.Click += new System.EventHandler(this.btnReturnFiles_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnUpdate.Image = global::ECustoms.Properties.Resources.edit;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(800, 461);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(151, 28);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.Text = "&Cập nhật thông tin hồ sơ";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tblLoanStatusBindingSource1
            // 
            this.tblLoanStatusBindingSource1.DataMember = "tblLoanStatus";
            this.tblLoanStatusBindingSource1.DataSource = this.dataSet2;
            // 
            // frmDeclarationFilesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 501);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnViewLoanStatus);
            this.Controls.Add(this.btnGetFiles);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReturnFiles);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDeclarationFilesManagement";
            this.Text = "frmDeclarationFilesManagement";
            this.Load += new System.EventHandler(this.frmDeclarationFilesManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvDeclarationList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLoanStatusBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLoanStatusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLoanStatusBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDeclarationNumber;
        private System.Windows.Forms.Button btnViewLoanStatus;
        private System.Windows.Forms.Button btnGetFiles;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReturnFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DateTimePicker dateTimePickerReturn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerHandover;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbxCustomsCode;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtRegisteredYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grvDeclarationList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.BindingSource tblLoanStatusBindingSource;
        private DataSet2 dataSet2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.BindingSource tblLoanStatusBindingSource2;
        private System.Windows.Forms.BindingSource tblLoanStatusBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeclarationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewComboBoxColumn LoanStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilesLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomsCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateHandover;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonHandoverUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonReceive;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonHandoverSecondUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonReceiveSecond;
    }
}