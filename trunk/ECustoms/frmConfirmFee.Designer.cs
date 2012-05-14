namespace ECustoms
{
    partial class frmConfirmFee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmFee));
            this.grbResult = new System.Windows.Forms.GroupBox();
            this.txtMoney = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFee = new System.Windows.Forms.DateTimePicker();
            this.mtxtFeeHour = new System.Windows.Forms.MaskedTextBox();
            this.txtReceipt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirmFee = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
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
            this.grbResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbResult
            // 
            this.grbResult.Controls.Add(this.txtMoney);
            this.grbResult.Controls.Add(this.label3);
            this.grbResult.Controls.Add(this.dtpFee);
            this.grbResult.Controls.Add(this.mtxtFeeHour);
            this.grbResult.Controls.Add(this.txtReceipt);
            this.grbResult.Controls.Add(this.label2);
            this.grbResult.Controls.Add(this.label1);
            this.grbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbResult.Location = new System.Drawing.Point(12, 12);
            this.grbResult.Name = "grbResult";
            this.grbResult.Size = new System.Drawing.Size(332, 134);
            this.grbResult.TabIndex = 0;
            this.grbResult.TabStop = false;
            this.grbResult.Text = "Thông tin thu phí";
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(134, 63);
            this.txtMoney.Mask = "000000000000";
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(185, 26);
            this.txtMoney.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Ngày thu";
            // 
            // dtpFee
            // 
            this.dtpFee.CustomFormat = "dd/MM/yyyy";
            this.dtpFee.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFee.Location = new System.Drawing.Point(134, 95);
            this.dtpFee.Name = "dtpFee";
            this.dtpFee.Size = new System.Drawing.Size(125, 26);
            this.dtpFee.TabIndex = 2;
            // 
            // mtxtFeeHour
            // 
            this.mtxtFeeHour.Location = new System.Drawing.Point(265, 95);
            this.mtxtFeeHour.Mask = "00:00";
            this.mtxtFeeHour.Name = "mtxtFeeHour";
            this.mtxtFeeHour.Size = new System.Drawing.Size(54, 26);
            this.mtxtFeeHour.TabIndex = 3;
            this.mtxtFeeHour.ValidatingType = typeof(System.DateTime);
            // 
            // txtReceipt
            // 
            this.txtReceipt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReceipt.Location = new System.Drawing.Point(134, 31);
            this.txtReceipt.Name = "txtReceipt";
            this.txtReceipt.Size = new System.Drawing.Size(185, 26);
            this.txtReceipt.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số tiền thu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số biên lai";
            // 
            // btnConfirmFee
            // 
            this.btnConfirmFee.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnConfirmFee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmFee.Image = global::ECustoms.Properties.Resources.confirm;
            this.btnConfirmFee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmFee.Location = new System.Drawing.Point(121, 152);
            this.btnConfirmFee.Name = "btnConfirmFee";
            this.btnConfirmFee.Size = new System.Drawing.Size(119, 33);
            this.btnConfirmFee.TabIndex = 0;
            this.btnConfirmFee.Text = "Xác nhận";
            this.btnConfirmFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmFee.UseVisualStyleBackColor = true;
            this.btnConfirmFee.Click += new System.EventHandler(this.btnConfirmFee_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ECustoms.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(255, 152);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 33);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Thoát";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PlateNumber";
            this.dataGridViewTextBoxColumn1.HeaderText = "Biển kiểm soát";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 140;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DriverName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên lái xe";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ExportDate";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy hh:mm";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn3.HeaderText = "Ngày xuất cảnh";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ImportDate";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy hh:mm";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn4.HeaderText = "Ngày nhập cảnh";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NumberOfContainer";
            this.dataGridViewTextBoxColumn5.HeaderText = "Số container";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 135;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "parking";
            this.dataGridViewTextBoxColumn6.HeaderText = "Hàng vào bãi";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 140;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ParkingDate";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy hh:mm";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn7.HeaderText = "Ngày vào bãi";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn8.HeaderText = "Diễn giải";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Note";
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
            // frmConfirmFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 201);
            this.Controls.Add(this.btnConfirmFee);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grbResult);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfirmFee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGetFee";
            this.Load += new System.EventHandler(this.frmConfirmFee_Load);
            this.grbResult.ResumeLayout(false);
            this.grbResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbResult;
        private System.Windows.Forms.Button btnConfirmFee;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtxtFeeHour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFee;
        private System.Windows.Forms.MaskedTextBox txtMoney;
        private System.Windows.Forms.TextBox txtReceipt;
    }
}