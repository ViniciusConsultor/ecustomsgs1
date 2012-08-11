namespace ECustoms
{
    partial class frmVehicleOverdue
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
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.grdVehicleOverdue = new System.Windows.Forms.DataGridView();
            this.grbConditionSearch = new System.Windows.Forms.GroupBox();
            this.txtDriverName = new System.Windows.Forms.TextBox();
            this.lblDriverName = new System.Windows.Forms.Label();
            this.txtPlateNumber = new System.Windows.Forms.TextBox();
            this.lblPlateNumber = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlateNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicleOverdue)).BeginInit();
            this.grbConditionSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.grdVehicleOverdue);
            this.groupBoxList.Location = new System.Drawing.Point(0, 74);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(729, 297);
            this.groupBoxList.TabIndex = 0;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "Danh sách phương tiện quá hạn";
            // 
            // grdVehicleOverdue
            // 
            this.grdVehicleOverdue.AllowUserToAddRows = false;
            this.grdVehicleOverdue.AllowUserToDeleteRows = false;
            this.grdVehicleOverdue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdVehicleOverdue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVehicleOverdue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VehicleID,
            this.PlateNumber,
            this.DriverName,
            this.ExportDate,
            this.ImportDate,
            this.ExpiryDate});
            this.grdVehicleOverdue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVehicleOverdue.Location = new System.Drawing.Point(3, 16);
            this.grdVehicleOverdue.MultiSelect = false;
            this.grdVehicleOverdue.Name = "grdVehicleOverdue";
            this.grdVehicleOverdue.ReadOnly = true;
            this.grdVehicleOverdue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdVehicleOverdue.Size = new System.Drawing.Size(723, 278);
            this.grdVehicleOverdue.TabIndex = 0;
            // 
            // grbConditionSearch
            // 
            this.grbConditionSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbConditionSearch.Controls.Add(this.txtDriverName);
            this.grbConditionSearch.Controls.Add(this.lblDriverName);
            this.grbConditionSearch.Controls.Add(this.txtPlateNumber);
            this.grbConditionSearch.Controls.Add(this.lblPlateNumber);
            this.grbConditionSearch.Controls.Add(this.btnSearch);
            this.grbConditionSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grbConditionSearch.Location = new System.Drawing.Point(3, 12);
            this.grbConditionSearch.Name = "grbConditionSearch";
            this.grbConditionSearch.Size = new System.Drawing.Size(726, 56);
            this.grbConditionSearch.TabIndex = 40;
            this.grbConditionSearch.TabStop = false;
            this.grbConditionSearch.Text = "Điều kiện tìm kiếm";
            // 
            // txtDriverName
            // 
            this.txtDriverName.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtDriverName.Location = new System.Drawing.Point(323, 22);
            this.txtDriverName.Name = "txtDriverName";
            this.txtDriverName.Size = new System.Drawing.Size(160, 20);
            this.txtDriverName.TabIndex = 2;
            // 
            // lblDriverName
            // 
            this.lblDriverName.AutoSize = true;
            this.lblDriverName.Location = new System.Drawing.Point(243, 26);
            this.lblDriverName.Name = "lblDriverName";
            this.lblDriverName.Size = new System.Drawing.Size(53, 13);
            this.lblDriverName.TabIndex = 12;
            this.lblDriverName.Text = "Tên lái xe";
            // 
            // txtPlateNumber
            // 
            this.txtPlateNumber.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtPlateNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlateNumber.Location = new System.Drawing.Point(127, 22);
            this.txtPlateNumber.Name = "txtPlateNumber";
            this.txtPlateNumber.Size = new System.Drawing.Size(95, 20);
            this.txtPlateNumber.TabIndex = 1;
            // 
            // lblPlateNumber
            // 
            this.lblPlateNumber.AutoSize = true;
            this.lblPlateNumber.Location = new System.Drawing.Point(23, 26);
            this.lblPlateNumber.Name = "lblPlateNumber";
            this.lblPlateNumber.Size = new System.Drawing.Size(76, 13);
            this.lblPlateNumber.TabIndex = 11;
            this.lblPlateNumber.Text = "Biển kiểm soát";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSearch.Image = global::ECustoms.Properties.Resources.search;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(640, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(73, 28);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Tìm k&iếm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "VehicleID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã phương tiện";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 117;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PlateNumber";
            this.dataGridViewTextBoxColumn2.HeaderText = "Biển kiểm soát";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 117;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DriverName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Tên lái xe";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 116;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ExportDate";
            this.dataGridViewTextBoxColumn4.HeaderText = "Ngày xuất cảnh";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 117;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ImportDate";
            this.dataGridViewTextBoxColumn5.HeaderText = "Ngày nhập cảnh";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 117;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Ngày hết hạn";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 113;
            // 
            // VehicleID
            // 
            this.VehicleID.DataPropertyName = "VehicleID";
            this.VehicleID.HeaderText = "Mã phương tiện";
            this.VehicleID.Name = "VehicleID";
            this.VehicleID.ReadOnly = true;
            // 
            // PlateNumber
            // 
            this.PlateNumber.DataPropertyName = "PlateNumber";
            this.PlateNumber.HeaderText = "Biển kiểm soát";
            this.PlateNumber.Name = "PlateNumber";
            this.PlateNumber.ReadOnly = true;
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
            this.ExportDate.HeaderText = "Ngày xuất cảnh";
            this.ExportDate.Name = "ExportDate";
            this.ExportDate.ReadOnly = true;
            // 
            // ImportDate
            // 
            this.ImportDate.DataPropertyName = "ImportDate";
            this.ImportDate.HeaderText = "Ngày nhập cảnh";
            this.ImportDate.Name = "ImportDate";
            this.ImportDate.ReadOnly = true;
            // 
            // ExpiryDate
            // 
            this.ExpiryDate.HeaderText = "Ngày hết hạn";
            this.ExpiryDate.Name = "ExpiryDate";
            this.ExpiryDate.ReadOnly = true;
            // 
            // frmVehicleOverdue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 371);
            this.Controls.Add(this.grbConditionSearch);
            this.Controls.Add(this.groupBoxList);
            this.Name = "frmVehicleOverdue";
            this.Text = "frmVehicleOverdueList";
            this.Load += new System.EventHandler(this.frmVehicleOverdue_Load);
            this.groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicleOverdue)).EndInit();
            this.grbConditionSearch.ResumeLayout(false);
            this.grbConditionSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.DataGridView grdVehicleOverdue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.GroupBox grbConditionSearch;
        private System.Windows.Forms.TextBox txtDriverName;
        private System.Windows.Forms.Label lblDriverName;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.Label lblPlateNumber;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlateNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExportDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}