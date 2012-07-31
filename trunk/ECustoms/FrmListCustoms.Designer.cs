namespace ECustoms
{
    partial class FrmListCustoms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListCustoms));
            this.grbConditionSearch = new System.Windows.Forms.GroupBox();
            this.txtCustomsName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomsCode = new System.Windows.Forms.TextBox();
            this.lblPlateNumber = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grbUser = new System.Windows.Forms.GroupBox();
            this.grvCustoms = new System.Windows.Forms.DataGridView();
            this.CompanyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbConditionSearch.SuspendLayout();
            this.grbUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustoms)).BeginInit();
            this.SuspendLayout();
            // 
            // grbConditionSearch
            // 
            this.grbConditionSearch.Controls.Add(this.txtCustomsName);
            this.grbConditionSearch.Controls.Add(this.label1);
            this.grbConditionSearch.Controls.Add(this.txtCustomsCode);
            this.grbConditionSearch.Controls.Add(this.lblPlateNumber);
            this.grbConditionSearch.Controls.Add(this.btnSearch);
            this.grbConditionSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbConditionSearch.Location = new System.Drawing.Point(8, 7);
            this.grbConditionSearch.Name = "grbConditionSearch";
            this.grbConditionSearch.Size = new System.Drawing.Size(906, 73);
            this.grbConditionSearch.TabIndex = 39;
            this.grbConditionSearch.TabStop = false;
            this.grbConditionSearch.Text = "Điều kiện tìm kiếm";
            // 
            // txtCustomsName
            // 
            this.txtCustomsName.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtCustomsName.Location = new System.Drawing.Point(419, 25);
            this.txtCustomsName.Name = "txtCustomsName";
            this.txtCustomsName.Size = new System.Drawing.Size(340, 26);
            this.txtCustomsName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tên ĐV hải quan";
            // 
            // txtCustomsCode
            // 
            this.txtCustomsCode.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtCustomsCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomsCode.Location = new System.Drawing.Point(150, 25);
            this.txtCustomsCode.Name = "txtCustomsCode";
            this.txtCustomsCode.Size = new System.Drawing.Size(121, 26);
            this.txtCustomsCode.TabIndex = 1;
            // 
            // lblPlateNumber
            // 
            this.lblPlateNumber.AutoSize = true;
            this.lblPlateNumber.Location = new System.Drawing.Point(13, 28);
            this.lblPlateNumber.Name = "lblPlateNumber";
            this.lblPlateNumber.Size = new System.Drawing.Size(123, 20);
            this.lblPlateNumber.TabIndex = 11;
            this.lblPlateNumber.Text = "Mã ĐV hải quan";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::ECustoms.Properties.Resources.search;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(777, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grbUser
            // 
            this.grbUser.Controls.Add(this.grvCustoms);
            this.grbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbUser.Location = new System.Drawing.Point(5, 86);
            this.grbUser.Name = "grbUser";
            this.grbUser.Size = new System.Drawing.Size(909, 370);
            this.grbUser.TabIndex = 36;
            this.grbUser.TabStop = false;
            this.grbUser.Text = "Danh sách đơn vị hải quan";
            // 
            // grvCustoms
            // 
            this.grvCustoms.AllowUserToAddRows = false;
            this.grvCustoms.AllowUserToDeleteRows = false;
            this.grvCustoms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvCustoms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyCode,
            this.CompanyName,
            this.Description});
            this.grvCustoms.Location = new System.Drawing.Point(6, 25);
            this.grvCustoms.MultiSelect = false;
            this.grvCustoms.Name = "grvCustoms";
            this.grvCustoms.ReadOnly = true;
            this.grvCustoms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvCustoms.Size = new System.Drawing.Size(897, 334);
            this.grvCustoms.TabIndex = 38;
            this.grvCustoms.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvCustoms_CellDoubleClick);
            // 
            // CompanyCode
            // 
            this.CompanyCode.DataPropertyName = "CustomsCode";
            this.CompanyCode.HeaderText = "Mã ĐV hải quan";
            this.CompanyCode.Name = "CompanyCode";
            this.CompanyCode.ReadOnly = true;
            this.CompanyCode.Width = 150;
            // 
            // CompanyName
            // 
            this.CompanyName.DataPropertyName = "CustomsName";
            this.CompanyName.HeaderText = "Tên ĐV hải quan";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            this.CompanyName.Width = 400;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Mô tả";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 300;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ECustoms.Properties.Resources.Exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(824, 462);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 28);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Thoát";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::ECustoms.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(751, 462);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(67, 28);
            this.btnDelete.TabIndex = 36;
            this.btnDelete.Text = "Xóa";
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
            this.btnUpdate.Location = new System.Drawing.Point(644, 462);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 28);
            this.btnUpdate.TabIndex = 35;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::ECustoms.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(545, 462);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 28);
            this.btnAdd.TabIndex = 34;
            this.btnAdd.Text = "Tạo mới";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CustomsCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã ĐV hải quan";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CustomsName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên ĐV hải quan";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 400;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn3.HeaderText = "Mô tả";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 300;
            // 
            // FrmListCustoms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 494);
            this.Controls.Add(this.grbConditionSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.grbUser);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmListCustoms";
            this.Text = "FrmListCustoms";
            this.Load += new System.EventHandler(this.FrmListCustoms_Load);
            this.grbConditionSearch.ResumeLayout(false);
            this.grbConditionSearch.PerformLayout();
            this.grbUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvCustoms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbConditionSearch;
        private System.Windows.Forms.TextBox txtCustomsName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomsCode;
        private System.Windows.Forms.Label lblPlateNumber;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox grbUser;
        private System.Windows.Forms.DataGridView grvCustoms;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}