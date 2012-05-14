namespace ECustoms
{
    partial class FrmCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheck));
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblDeclaraceNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblImportDate = new System.Windows.Forms.Label();
            this.lblExportDate = new System.Windows.Forms.Label();
            this.lblPlateNumber = new System.Windows.Forms.Label();
            this.btnUpdateVehicle = new System.Windows.Forms.Button();
            this.btnAddVehicle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(48, 10);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(414, 29);
            this.lblHeader.TabIndex = 22;
            this.lblHeader.Text = "Nhập thông tin kiểm tra phương tiện";
            // 
            // lblDeclaraceNumber
            // 
            this.lblDeclaraceNumber.AutoSize = true;
            this.lblDeclaraceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeclaraceNumber.Location = new System.Drawing.Point(4, 30);
            this.lblDeclaraceNumber.Name = "lblDeclaraceNumber";
            this.lblDeclaraceNumber.Size = new System.Drawing.Size(113, 20);
            this.lblDeclaraceNumber.TabIndex = 23;
            this.lblDeclaraceNumber.Text = "Biển kiểm soát";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Ngày xuất cảnh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Ngày nhập cảnh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Kết quả kiểm tra";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(137, 149);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(355, 119);
            this.txtResult.TabIndex = 31;
            this.txtResult.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ECustoms.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(253, 353);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 33);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "Thoát";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblImportDate);
            this.groupBox1.Controls.Add(this.lblExportDate);
            this.groupBox1.Controls.Add(this.lblPlateNumber);
            this.groupBox1.Controls.Add(this.lblDeclaraceNumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtResult);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 287);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin kiểm tra phương tiện";
            // 
            // lblImportDate
            // 
            this.lblImportDate.AutoSize = true;
            this.lblImportDate.Location = new System.Drawing.Point(134, 101);
            this.lblImportDate.Name = "lblImportDate";
            this.lblImportDate.Size = new System.Drawing.Size(0, 20);
            this.lblImportDate.TabIndex = 37;
            // 
            // lblExportDate
            // 
            this.lblExportDate.AutoSize = true;
            this.lblExportDate.Location = new System.Drawing.Point(133, 62);
            this.lblExportDate.Name = "lblExportDate";
            this.lblExportDate.Size = new System.Drawing.Size(0, 20);
            this.lblExportDate.TabIndex = 36;
            // 
            // lblPlateNumber
            // 
            this.lblPlateNumber.AutoSize = true;
            this.lblPlateNumber.Location = new System.Drawing.Point(133, 30);
            this.lblPlateNumber.Name = "lblPlateNumber";
            this.lblPlateNumber.Size = new System.Drawing.Size(0, 20);
            this.lblPlateNumber.TabIndex = 35;
            // 
            // btnUpdateVehicle
            // 
            this.btnUpdateVehicle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdateVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateVehicle.Image = global::ECustoms.Properties.Resources._001_45;
            this.btnUpdateVehicle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateVehicle.Location = new System.Drawing.Point(135, 353);
            this.btnUpdateVehicle.Name = "btnUpdateVehicle";
            this.btnUpdateVehicle.Size = new System.Drawing.Size(112, 33);
            this.btnUpdateVehicle.TabIndex = 38;
            this.btnUpdateVehicle.Text = "Cập nhật";
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
            this.btnAddVehicle.Location = new System.Drawing.Point(12, 353);
            this.btnAddVehicle.Name = "btnAddVehicle";
            this.btnAddVehicle.Size = new System.Drawing.Size(117, 33);
            this.btnAddVehicle.TabIndex = 37;
            this.btnAddVehicle.Text = "Thêm mới";
            this.btnAddVehicle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddVehicle.UseVisualStyleBackColor = true;
            this.btnAddVehicle.Click += new System.EventHandler(this.btnAddVehicle_Click);
            // 
            // FrmCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 398);
            this.Controls.Add(this.btnUpdateVehicle);
            this.Controls.Add(this.btnAddVehicle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCheck";
            this.Text = "FrmCheck";
            this.Load += new System.EventHandler(this.FrmCheck_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblDeclaraceNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpdateVehicle;
        private System.Windows.Forms.Button btnAddVehicle;
        private System.Windows.Forms.Label lblImportDate;
        private System.Windows.Forms.Label lblExportDate;
        private System.Windows.Forms.Label lblPlateNumber;
    }
}