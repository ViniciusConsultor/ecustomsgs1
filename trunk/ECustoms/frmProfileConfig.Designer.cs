namespace ECustoms
{
    partial class frmProfileConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfileConfig));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTypeCode = new System.Windows.Forms.TextBox();
            this.lblPlateNumber = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.txtCustomName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.techlinkErrorProvider1 = new ECustoms.Utilities.TechlinkErrorProvider();
            this.txtOverdueVehicleDate = new System.Windows.Forms.TextBox();
            this.lblOverdueVehicleDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSuperiorCompany = new System.Windows.Forms.Label();
            this.txtSuperiorCompany = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.techlinkErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClose.Image = global::ECustoms.Properties.Resources.Exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(424, 151);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Th&oát";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnUpdate.Image = global::ECustoms.Properties.Resources.edit;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(341, 151);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 28);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "&Cập nhật";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtTypeName
            // 
            this.txtTypeName.BackColor = System.Drawing.Color.White;
            this.txtTypeName.Enabled = false;
            this.txtTypeName.Location = new System.Drawing.Point(345, 64);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.ReadOnly = true;
            this.txtTypeName.Size = new System.Drawing.Size(142, 20);
            this.txtTypeName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(248, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tên loại hình";
            // 
            // txtTypeCode
            // 
            this.txtTypeCode.BackColor = System.Drawing.Color.White;
            this.txtTypeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTypeCode.Location = new System.Drawing.Point(107, 64);
            this.txtTypeCode.Name = "txtTypeCode";
            this.txtTypeCode.Size = new System.Drawing.Size(113, 20);
            this.txtTypeCode.TabIndex = 0;
            this.txtTypeCode.Tag = "required";
            this.txtTypeCode.Leave += new System.EventHandler(this.txtTypeCode_Leave);
            // 
            // lblPlateNumber
            // 
            this.lblPlateNumber.AutoSize = true;
            this.lblPlateNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPlateNumber.Location = new System.Drawing.Point(9, 68);
            this.lblPlateNumber.Name = "lblPlateNumber";
            this.lblPlateNumber.Size = new System.Drawing.Size(64, 13);
            this.lblPlateNumber.TabIndex = 11;
            this.lblPlateNumber.Text = "Mã loại hình";
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(12, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(451, 52);
            this.lblHeader.TabIndex = 28;
            this.lblHeader.Text = "Cấu hình giá trị mặc định";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCustomName
            // 
            this.txtCustomName.BackColor = System.Drawing.Color.White;
            this.txtCustomName.Enabled = false;
            this.txtCustomName.Location = new System.Drawing.Point(344, 92);
            this.txtCustomName.Name = "txtCustomName";
            this.txtCustomName.ReadOnly = true;
            this.txtCustomName.Size = new System.Drawing.Size(143, 20);
            this.txtCustomName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(248, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Tên ĐV Hải quan";
            // 
            // txtCustomCode
            // 
            this.txtCustomCode.BackColor = System.Drawing.Color.White;
            this.txtCustomCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomCode.Location = new System.Drawing.Point(107, 92);
            this.txtCustomCode.Name = "txtCustomCode";
            this.txtCustomCode.Size = new System.Drawing.Size(113, 20);
            this.txtCustomCode.TabIndex = 2;
            this.txtCustomCode.Tag = "required";
            this.txtCustomCode.Leave += new System.EventHandler(this.txtCustomCode_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(9, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Mã ĐV Hải quan";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TypeCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã loại hình";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TypeName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên loại hình";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn3.HeaderText = "Mô tả";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 300;
            // 
            // techlinkErrorProvider1
            // 
            this.techlinkErrorProvider1.ContainerControl = this;
            // 
            // txtOverdueVehicleDate
            // 
            this.txtOverdueVehicleDate.BackColor = System.Drawing.Color.White;
            this.txtOverdueVehicleDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOverdueVehicleDate.Location = new System.Drawing.Point(145, 118);
            this.txtOverdueVehicleDate.MaxLength = 20;
            this.txtOverdueVehicleDate.Name = "txtOverdueVehicleDate";
            this.txtOverdueVehicleDate.Size = new System.Drawing.Size(39, 20);
            this.txtOverdueVehicleDate.TabIndex = 4;
            this.txtOverdueVehicleDate.Tag = "required";
            this.txtOverdueVehicleDate.Leave += new System.EventHandler(this.txtOverdueVehicleDate_Leave);
            // 
            // lblOverdueVehicleDate
            // 
            this.lblOverdueVehicleDate.AutoSize = true;
            this.lblOverdueVehicleDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblOverdueVehicleDate.Location = new System.Drawing.Point(9, 122);
            this.lblOverdueVehicleDate.Name = "lblOverdueVehicleDate";
            this.lblOverdueVehicleDate.Size = new System.Drawing.Size(130, 13);
            this.lblOverdueVehicleDate.TabIndex = 34;
            this.lblOverdueVehicleDate.Text = "Số ngày giới hạn xe trở về";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(190, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "ngày";
            // 
            // lblSuperiorCompany
            // 
            this.lblSuperiorCompany.AutoSize = true;
            this.lblSuperiorCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSuperiorCompany.Location = new System.Drawing.Point(248, 122);
            this.lblSuperiorCompany.Name = "lblSuperiorCompany";
            this.lblSuperiorCompany.Size = new System.Drawing.Size(86, 13);
            this.lblSuperiorCompany.TabIndex = 37;
            this.lblSuperiorCompany.Text = "Tên ĐV cấp trên";
            // 
            // txtSuperiorCompany
            // 
            this.txtSuperiorCompany.BackColor = System.Drawing.Color.White;
            this.txtSuperiorCompany.Location = new System.Drawing.Point(344, 118);
            this.txtSuperiorCompany.Name = "txtSuperiorCompany";
            this.txtSuperiorCompany.Size = new System.Drawing.Size(143, 20);
            this.txtSuperiorCompany.TabIndex = 38;
            this.txtSuperiorCompany.Tag = "required";
            // 
            // frmProfileConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 191);
            this.Controls.Add(this.txtSuperiorCompany);
            this.Controls.Add(this.lblSuperiorCompany);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOverdueVehicleDate);
            this.Controls.Add(this.lblOverdueVehicleDate);
            this.Controls.Add(this.txtCustomName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustomCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTypeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.txtTypeCode);
            this.Controls.Add(this.lblPlateNumber);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProfileConfig";
            this.ShowInTaskbar = false;
            this.Text = "frmProfileConfig";
            this.Load += new System.EventHandler(this.frmProfileConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.techlinkErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTypeCode;
        private System.Windows.Forms.Label lblPlateNumber;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox txtCustomName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomCode;
        private System.Windows.Forms.Label label3;
        private Utilities.TechlinkErrorProvider techlinkErrorProvider1;
        private System.Windows.Forms.TextBox txtOverdueVehicleDate;
        private System.Windows.Forms.Label lblOverdueVehicleDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSuperiorCompany;
        private System.Windows.Forms.TextBox txtSuperiorCompany;
    }
}