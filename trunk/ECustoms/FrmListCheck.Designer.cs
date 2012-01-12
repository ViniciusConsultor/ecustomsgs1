namespace ECustoms
{
    partial class FrmListCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListCheck));
            this.grbConditionSearch = new System.Windows.Forms.GroupBox();
            this.comboBoxDeclarationType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCheckCode = new System.Windows.Forms.TextBox();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeclarationNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlateNumber = new System.Windows.Forms.TextBox();
            this.lblPlateNumber = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpCheckTo = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckFrom = new System.Windows.Forms.DateTimePicker();
            this.lblExportTo = new System.Windows.Forms.Label();
            this.lblExportFrom = new System.Windows.Forms.Label();
            this.grbResult = new System.Windows.Forms.GroupBox();
            this.grdCheck = new System.Windows.Forms.DataGridView();
            this.PlateNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeclarationNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedByName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifiedByName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grbConditionSearch.SuspendLayout();
            this.grbResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // grbConditionSearch
            // 
            this.grbConditionSearch.Controls.Add(this.comboBoxDeclarationType);
            this.grbConditionSearch.Controls.Add(this.label4);
            this.grbConditionSearch.Controls.Add(this.txtCheckCode);
            this.grbConditionSearch.Controls.Add(this.txtCompanyCode);
            this.grbConditionSearch.Controls.Add(this.label3);
            this.grbConditionSearch.Controls.Add(this.label2);
            this.grbConditionSearch.Controls.Add(this.txtDeclarationNumber);
            this.grbConditionSearch.Controls.Add(this.label1);
            this.grbConditionSearch.Controls.Add(this.txtPlateNumber);
            this.grbConditionSearch.Controls.Add(this.lblPlateNumber);
            this.grbConditionSearch.Controls.Add(this.btnSearch);
            this.grbConditionSearch.Controls.Add(this.dtpCheckTo);
            this.grbConditionSearch.Controls.Add(this.dtpCheckFrom);
            this.grbConditionSearch.Controls.Add(this.lblExportTo);
            this.grbConditionSearch.Controls.Add(this.lblExportFrom);
            this.grbConditionSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbConditionSearch.Location = new System.Drawing.Point(12, 12);
            this.grbConditionSearch.Name = "grbConditionSearch";
            this.grbConditionSearch.Size = new System.Drawing.Size(886, 111);
            this.grbConditionSearch.TabIndex = 1;
            this.grbConditionSearch.TabStop = false;
            this.grbConditionSearch.Text = "Điều kiện tìm kiếm";
            // 
            // comboBoxDeclarationType
            // 
            this.comboBoxDeclarationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDeclarationType.FormattingEnabled = true;
            this.comboBoxDeclarationType.Items.AddRange(new object[] {
            "---------",
            "Loại hình xuất",
            "Loại hình nhập",
            "Cả xuât và nhập"});
            this.comboBoxDeclarationType.Location = new System.Drawing.Point(399, 14);
            this.comboBoxDeclarationType.Name = "comboBoxDeclarationType";
            this.comboBoxDeclarationType.Size = new System.Drawing.Size(140, 28);
            this.comboBoxDeclarationType.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Loại hình";
            // 
            // txtCheckCode
            // 
            this.txtCheckCode.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtCheckCode.Location = new System.Drawing.Point(650, 16);
            this.txtCheckCode.Name = "txtCheckCode";
            this.txtCheckCode.Size = new System.Drawing.Size(89, 26);
            this.txtCheckCode.TabIndex = 7;
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtCompanyCode.Location = new System.Drawing.Point(154, 80);
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.Size = new System.Drawing.Size(105, 26);
            this.txtCompanyCode.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Mã doanh nghiệp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(557, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Số tự động";
            // 
            // txtDeclarationNumber
            // 
            this.txtDeclarationNumber.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtDeclarationNumber.Location = new System.Drawing.Point(154, 48);
            this.txtDeclarationNumber.Name = "txtDeclarationNumber";
            this.txtDeclarationNumber.Size = new System.Drawing.Size(105, 26);
            this.txtDeclarationNumber.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Số tờ khai";
            // 
            // txtPlateNumber
            // 
            this.txtPlateNumber.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtPlateNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlateNumber.Location = new System.Drawing.Point(154, 13);
            this.txtPlateNumber.Name = "txtPlateNumber";
            this.txtPlateNumber.Size = new System.Drawing.Size(105, 26);
            this.txtPlateNumber.TabIndex = 1;
            // 
            // lblPlateNumber
            // 
            this.lblPlateNumber.AutoSize = true;
            this.lblPlateNumber.Location = new System.Drawing.Point(7, 19);
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
            this.btnSearch.Location = new System.Drawing.Point(754, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 33);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpCheckTo
            // 
            this.dtpCheckTo.CustomFormat = "dd/MM/yyyy";
            this.dtpCheckTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCheckTo.Location = new System.Drawing.Point(399, 80);
            this.dtpCheckTo.Name = "dtpCheckTo";
            this.dtpCheckTo.Size = new System.Drawing.Size(120, 26);
            this.dtpCheckTo.TabIndex = 6;
            // 
            // dtpCheckFrom
            // 
            this.dtpCheckFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpCheckFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCheckFrom.Location = new System.Drawing.Point(399, 48);
            this.dtpCheckFrom.Name = "dtpCheckFrom";
            this.dtpCheckFrom.Size = new System.Drawing.Size(120, 26);
            this.dtpCheckFrom.TabIndex = 5;
            // 
            // lblExportTo
            // 
            this.lblExportTo.AutoSize = true;
            this.lblExportTo.Location = new System.Drawing.Point(265, 80);
            this.lblExportTo.Name = "lblExportTo";
            this.lblExportTo.Size = new System.Drawing.Size(131, 20);
            this.lblExportTo.TabIndex = 1;
            this.lblExportTo.Text = "Thời hạn kết thúc";
            // 
            // lblExportFrom
            // 
            this.lblExportFrom.AutoSize = true;
            this.lblExportFrom.Location = new System.Drawing.Point(265, 48);
            this.lblExportFrom.Name = "lblExportFrom";
            this.lblExportFrom.Size = new System.Drawing.Size(128, 20);
            this.lblExportFrom.TabIndex = 0;
            this.lblExportFrom.Text = "Thời hạn bắt đầu";
            // 
            // grbResult
            // 
            this.grbResult.Controls.Add(this.grdCheck);
            this.grbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbResult.Location = new System.Drawing.Point(12, 136);
            this.grbResult.Name = "grbResult";
            this.grbResult.Size = new System.Drawing.Size(984, 364);
            this.grbResult.TabIndex = 2;
            this.grbResult.TabStop = false;
            this.grbResult.Text = "Danh sách đề nghị kiểm tra";
            // 
            // grdCheck
            // 
            this.grdCheck.AllowUserToAddRows = false;
            this.grdCheck.AllowUserToDeleteRows = false;
            this.grdCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCheck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlateNumber,
            this.CheckCode,
            this.DeclarationNumber,
            this.CompanyCode,
            this.CheckFrom,
            this.CheckTo,
            this.CreatedByName,
            this.ModifiedByName,
            this.CheckID});
            this.grdCheck.Location = new System.Drawing.Point(6, 25);
            this.grdCheck.Name = "grdCheck";
            this.grdCheck.ReadOnly = true;
            this.grdCheck.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCheck.Size = new System.Drawing.Size(966, 333);
            this.grdCheck.TabIndex = 9;
            this.grdCheck.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdCheck_CellMouseDoubleClick);
            // 
            // PlateNumber
            // 
            this.PlateNumber.DataPropertyName = "PlateNumber";
            this.PlateNumber.HeaderText = "Biển kiểm soát";
            this.PlateNumber.Name = "PlateNumber";
            this.PlateNumber.ReadOnly = true;
            this.PlateNumber.Width = 140;
            // 
            // CheckCode
            // 
            this.CheckCode.DataPropertyName = "CheckCode";
            this.CheckCode.HeaderText = "Mã kiểm tra";
            this.CheckCode.Name = "CheckCode";
            this.CheckCode.ReadOnly = true;
            this.CheckCode.Width = 200;
            // 
            // DeclarationNumber
            // 
            this.DeclarationNumber.DataPropertyName = "DeclarationNumber";
            this.DeclarationNumber.HeaderText = "Số tờ khai";
            this.DeclarationNumber.Name = "DeclarationNumber";
            this.DeclarationNumber.ReadOnly = true;
            this.DeclarationNumber.Width = 120;
            // 
            // CompanyCode
            // 
            this.CompanyCode.DataPropertyName = "CompanyCode";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy hh:mm";
            this.CompanyCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.CompanyCode.HeaderText = "Mã doanh nghiệp";
            this.CompanyCode.Name = "CompanyCode";
            this.CompanyCode.ReadOnly = true;
            this.CompanyCode.Width = 170;
            // 
            // CheckFrom
            // 
            this.CheckFrom.DataPropertyName = "CheckFrom";
            this.CheckFrom.HeaderText = "Thời gian bắt đầu";
            this.CheckFrom.Name = "CheckFrom";
            this.CheckFrom.ReadOnly = true;
            this.CheckFrom.Width = 170;
            // 
            // CheckTo
            // 
            this.CheckTo.DataPropertyName = "CheckTo";
            this.CheckTo.HeaderText = "Thời gian hết hạn";
            this.CheckTo.Name = "CheckTo";
            this.CheckTo.ReadOnly = true;
            this.CheckTo.Width = 170;
            // 
            // CreatedByName
            // 
            this.CreatedByName.DataPropertyName = "CreatedByName";
            this.CreatedByName.HeaderText = "Người tạo";
            this.CreatedByName.Name = "CreatedByName";
            this.CreatedByName.ReadOnly = true;
            this.CreatedByName.Width = 120;
            // 
            // ModifiedByName
            // 
            this.ModifiedByName.DataPropertyName = "ModifiedByName";
            this.ModifiedByName.HeaderText = "Người sửa";
            this.ModifiedByName.Name = "ModifiedByName";
            this.ModifiedByName.ReadOnly = true;
            this.ModifiedByName.Width = 120;
            // 
            // CheckID
            // 
            this.CheckID.DataPropertyName = "CheckID";
            this.CheckID.HeaderText = "CheckID";
            this.CheckID.Name = "CheckID";
            this.CheckID.ReadOnly = true;
            this.CheckID.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::ECustoms.Properties.Resources._001_01;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(14, 506);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 33);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Tạo mới";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = global::ECustoms.Properties.Resources._001_45;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(121, 506);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(107, 33);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::ECustoms.Properties.Resources._001_05;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(234, 506);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 33);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FrmListCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 551);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.grbResult);
            this.Controls.Add(this.grbConditionSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmListCheck";
            this.Text = "FrmCheck";
            this.Load += new System.EventHandler(this.FrmCheck_Load);
            this.grbConditionSearch.ResumeLayout(false);
            this.grbConditionSearch.PerformLayout();
            this.grbResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbConditionSearch;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.Label lblPlateNumber;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpCheckTo;
        private System.Windows.Forms.DateTimePicker dtpCheckFrom;
        private System.Windows.Forms.Label lblExportTo;
        private System.Windows.Forms.Label lblExportFrom;
        private System.Windows.Forms.TextBox txtDeclarationNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCompanyCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCheckCode;
        private System.Windows.Forms.ComboBox comboBoxDeclarationType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grbResult;
        private System.Windows.Forms.DataGridView grdCheck;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlateNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeclarationNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedByName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifiedByName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckID;
    }
}