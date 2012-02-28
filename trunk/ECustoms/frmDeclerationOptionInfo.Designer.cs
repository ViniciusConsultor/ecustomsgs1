namespace ECustoms
{
    partial class frmDeclerationOptionInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeclerationOptionInfo));
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
            this.txtGateExport = new System.Windows.Forms.TextBox();
            this.lblGateExport = new System.Windows.Forms.Label();
            this.txtRegisterPlace = new System.Windows.Forms.TextBox();
            this.lblRegisterPlace = new System.Windows.Forms.Label();
            this.cbRegDate = new System.Windows.Forms.CheckBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtDeclaraceNumber = new System.Windows.Forms.TextBox();
            this.lblDeclaraceNumber = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.grbDecleration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDecleration)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDecleration
            // 
            this.grbDecleration.Controls.Add(this.grvDecleration);
            this.grbDecleration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDecleration.Location = new System.Drawing.Point(8, 183);
            this.grbDecleration.Name = "grbDecleration";
            this.grbDecleration.Size = new System.Drawing.Size(964, 352);
            this.grbDecleration.TabIndex = 1;
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
            this.grvDecleration.Location = new System.Drawing.Point(8, 24);
            this.grvDecleration.Name = "grvDecleration";
            this.grvDecleration.ReadOnly = true;
            this.grvDecleration.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvDecleration.Size = new System.Drawing.Size(945, 320);
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
            this.groupBox1.Controls.Add(this.txtGateExport);
            this.groupBox1.Controls.Add(this.lblGateExport);
            this.groupBox1.Controls.Add(this.txtRegisterPlace);
            this.groupBox1.Controls.Add(this.lblRegisterPlace);
            this.groupBox1.Controls.Add(this.cbRegDate);
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtCompanyName);
            this.groupBox1.Controls.Add(this.lblCompanyName);
            this.groupBox1.Controls.Add(this.txtDeclaraceNumber);
            this.groupBox1.Controls.Add(this.lblDeclaraceNumber);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(962, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều kiện tìm kiếm";
            // 
            // txtGateExport
            // 
            this.txtGateExport.Location = new System.Drawing.Point(556, 102);
            this.txtGateExport.Name = "txtGateExport";
            this.txtGateExport.Size = new System.Drawing.Size(179, 26);
            this.txtGateExport.TabIndex = 6;
            // 
            // lblGateExport
            // 
            this.lblGateExport.AutoSize = true;
            this.lblGateExport.Location = new System.Drawing.Point(407, 105);
            this.lblGateExport.Name = "lblGateExport";
            this.lblGateExport.Size = new System.Drawing.Size(111, 20);
            this.lblGateExport.TabIndex = 23;
            this.lblGateExport.Text = "Cửa khẩu xuất";
            // 
            // txtRegisterPlace
            // 
            this.txtRegisterPlace.Location = new System.Drawing.Point(164, 102);
            this.txtRegisterPlace.Name = "txtRegisterPlace";
            this.txtRegisterPlace.Size = new System.Drawing.Size(189, 26);
            this.txtRegisterPlace.TabIndex = 5;
            // 
            // lblRegisterPlace
            // 
            this.lblRegisterPlace.AutoSize = true;
            this.lblRegisterPlace.Location = new System.Drawing.Point(27, 105);
            this.lblRegisterPlace.Name = "lblRegisterPlace";
            this.lblRegisterPlace.Size = new System.Drawing.Size(114, 20);
            this.lblRegisterPlace.TabIndex = 21;
            this.lblRegisterPlace.Text = "Nơi đăng ký TK";
            // 
            // cbRegDate
            // 
            this.cbRegDate.AutoSize = true;
            this.cbRegDate.Location = new System.Drawing.Point(31, 68);
            this.cbRegDate.Name = "cbRegDate";
            this.cbRegDate.Size = new System.Drawing.Size(123, 24);
            this.cbRegDate.TabIndex = 2;
            this.cbRegDate.Text = "Ngày đăng ký";
            this.cbRegDate.UseVisualStyleBackColor = true;
            this.cbRegDate.CheckedChanged += new System.EventHandler(this.cbRegDate_CheckedChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(556, 64);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(117, 26);
            this.dtpTo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Đến ngày";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(231, 64);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(122, 26);
            this.dtpFrom.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Từ ngày";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::ECustoms.Properties.Resources.search41;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(778, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(145, 33);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Tìm tờ khai";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(556, 26);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(179, 26);
            this.txtCompanyName.TabIndex = 1;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(407, 29);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(137, 20);
            this.lblCompanyName.TabIndex = 2;
            this.lblCompanyName.Text = "Tên doanh nghiệp";
            // 
            // txtDeclaraceNumber
            // 
            this.txtDeclaraceNumber.Location = new System.Drawing.Point(164, 26);
            this.txtDeclaraceNumber.Name = "txtDeclaraceNumber";
            this.txtDeclaraceNumber.Size = new System.Drawing.Size(189, 26);
            this.txtDeclaraceNumber.TabIndex = 0;
            // 
            // lblDeclaraceNumber
            // 
            this.lblDeclaraceNumber.AutoSize = true;
            this.lblDeclaraceNumber.Location = new System.Drawing.Point(27, 29);
            this.lblDeclaraceNumber.Name = "lblDeclaraceNumber";
            this.lblDeclaraceNumber.Size = new System.Drawing.Size(80, 20);
            this.lblDeclaraceNumber.TabIndex = 0;
            this.lblDeclaraceNumber.Text = "Số tờ khai";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ECustoms.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(192, 543);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 33);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = global::ECustoms.Properties.Resources._001_45;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(16, 543);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(161, 33);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Cập nhật tờ khai";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(292, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(284, 29);
            this.lblHeader.TabIndex = 22;
            this.lblHeader.Text = "Quản lý hàng hóa TNTX";
            // 
            // frmDeclerationOptionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 586);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.grbDecleration);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDeclerationOptionInfo";
            this.Text = "Danh sách tờ khai";
            this.Load += new System.EventHandler(this.frmDeclerationOptionInfo_Load);
            this.grbDecleration.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvDecleration)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDecleration;
        private System.Windows.Forms.DataGridView grvDecleration;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtDeclaraceNumber;
        private System.Windows.Forms.Label lblDeclaraceNumber;
        private System.Windows.Forms.Button btnSearch;
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
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.CheckBox cbRegDate;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGateExport;
        private System.Windows.Forms.Label lblGateExport;
        private System.Windows.Forms.TextBox txtRegisterPlace;
        private System.Windows.Forms.Label lblRegisterPlace;
    }
}