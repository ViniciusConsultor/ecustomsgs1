﻿namespace ECustoms
{
    partial class FrmAddCheck
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddCheck));
          this.lblHeader = new System.Windows.Forms.Label();
          this.label1 = new System.Windows.Forms.Label();
          this.txtCode = new System.Windows.Forms.TextBox();
          this.label2 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.label4 = new System.Windows.Forms.Label();
          this.label6 = new System.Windows.Forms.Label();
          this.label7 = new System.Windows.Forms.Label();
          this.label8 = new System.Windows.Forms.Label();
          this.txtPlateNumber = new System.Windows.Forms.TextBox();
          this.txtCompanyCode = new System.Windows.Forms.TextBox();
          this.dtpFrom = new System.Windows.Forms.DateTimePicker();
          this.dtpTo = new System.Windows.Forms.DateTimePicker();
          this.comboBoxDeclarationType = new System.Windows.Forms.ComboBox();
          this.btnClose = new System.Windows.Forms.Button();
          this.btnUpdate = new System.Windows.Forms.Button();
          this.btnAdd = new System.Windows.Forms.Button();
          this.grbConditionSearch = new System.Windows.Forms.GroupBox();
          this.txtDeclarationNumber = new System.Windows.Forms.MaskedTextBox();
          this.grbConditionSearch.SuspendLayout();
          this.SuspendLayout();
          // 
          // lblHeader
          // 
          this.lblHeader.AutoSize = true;
          this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblHeader.Location = new System.Drawing.Point(16, 18);
          this.lblHeader.Name = "lblHeader";
          this.lblHeader.Size = new System.Drawing.Size(343, 29);
          this.lblHeader.TabIndex = 22;
          this.lblHeader.Text = "_Thêm mới kiểm tra thông tin";
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label1.Location = new System.Drawing.Point(11, 25);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(91, 20);
          this.label1.TabIndex = 23;
          this.label1.Text = "Mã kiểm tra";
          // 
          // txtCode
          // 
          this.txtCode.Location = new System.Drawing.Point(165, 25);
          this.txtCode.Name = "txtCode";
          this.txtCode.ReadOnly = true;
          this.txtCode.Size = new System.Drawing.Size(149, 26);
          this.txtCode.TabIndex = 1;
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label2.Location = new System.Drawing.Point(11, 57);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(113, 20);
          this.label2.TabIndex = 25;
          this.label2.Text = "Biển kiểm soát";
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label3.Location = new System.Drawing.Point(11, 89);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(80, 20);
          this.label3.TabIndex = 26;
          this.label3.Text = "Số tờ khai";
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label4.Location = new System.Drawing.Point(10, 121);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(132, 20);
          this.label4.TabIndex = 27;
          this.label4.Text = "Mã doanh nghiệp";
          // 
          // label6
          // 
          this.label6.AutoSize = true;
          this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label6.Location = new System.Drawing.Point(11, 156);
          this.label6.Name = "label6";
          this.label6.Size = new System.Drawing.Size(73, 20);
          this.label6.TabIndex = 29;
          this.label6.Text = "Loại hình";
          // 
          // label7
          // 
          this.label7.AutoSize = true;
          this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label7.Location = new System.Drawing.Point(11, 187);
          this.label7.Name = "label7";
          this.label7.Size = new System.Drawing.Size(131, 20);
          this.label7.TabIndex = 30;
          this.label7.Text = "Thời gian bắt đầu";
          // 
          // label8
          // 
          this.label8.AutoSize = true;
          this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label8.Location = new System.Drawing.Point(11, 219);
          this.label8.Name = "label8";
          this.label8.Size = new System.Drawing.Size(134, 20);
          this.label8.TabIndex = 31;
          this.label8.Text = "Thời gian kết thúc";
          // 
          // txtPlateNumber
          // 
          this.txtPlateNumber.Location = new System.Drawing.Point(165, 57);
          this.txtPlateNumber.Name = "txtPlateNumber";
          this.txtPlateNumber.Size = new System.Drawing.Size(149, 26);
          this.txtPlateNumber.TabIndex = 2;
          this.txtPlateNumber.Leave += new System.EventHandler(this.txtPlateNumber_Leave);
          // 
          // txtCompanyCode
          // 
          this.txtCompanyCode.Location = new System.Drawing.Point(165, 121);
          this.txtCompanyCode.Name = "txtCompanyCode";
          this.txtCompanyCode.Size = new System.Drawing.Size(149, 26);
          this.txtCompanyCode.TabIndex = 4;
          // 
          // dtpFrom
          // 
          this.dtpFrom.CustomFormat = "dd/MM/yyyy";
          this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
          this.dtpFrom.Location = new System.Drawing.Point(165, 187);
          this.dtpFrom.Name = "dtpFrom";
          this.dtpFrom.Size = new System.Drawing.Size(114, 26);
          this.dtpFrom.TabIndex = 7;
          // 
          // dtpTo
          // 
          this.dtpTo.CustomFormat = "dd/MM/yyyy";
          this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
          this.dtpTo.Location = new System.Drawing.Point(165, 219);
          this.dtpTo.Name = "dtpTo";
          this.dtpTo.Size = new System.Drawing.Size(114, 26);
          this.dtpTo.TabIndex = 8;
          // 
          // comboBoxDeclarationType
          // 
          this.comboBoxDeclarationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.comboBoxDeclarationType.FormattingEnabled = true;
          this.comboBoxDeclarationType.Location = new System.Drawing.Point(165, 153);
          this.comboBoxDeclarationType.Name = "comboBoxDeclarationType";
          this.comboBoxDeclarationType.Size = new System.Drawing.Size(149, 28);
          this.comboBoxDeclarationType.TabIndex = 6;
          // 
          // btnClose
          // 
          this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
          this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnClose.Image = global::ECustoms.Properties.Resources.close;
          this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.btnClose.Location = new System.Drawing.Point(269, 330);
          this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
          this.btnClose.Name = "btnClose";
          this.btnClose.Size = new System.Drawing.Size(82, 33);
          this.btnClose.TabIndex = 41;
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
          this.btnUpdate.Location = new System.Drawing.Point(147, 330);
          this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
          this.btnUpdate.Name = "btnUpdate";
          this.btnUpdate.Size = new System.Drawing.Size(114, 33);
          this.btnUpdate.TabIndex = 40;
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
          this.btnAdd.Image = global::ECustoms.Properties.Resources._001_01;
          this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.btnAdd.Location = new System.Drawing.Point(21, 330);
          this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
          this.btnAdd.Name = "btnAdd";
          this.btnAdd.Size = new System.Drawing.Size(118, 33);
          this.btnAdd.TabIndex = 39;
          this.btnAdd.Text = "Thêm mới";
          this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          this.btnAdd.UseVisualStyleBackColor = true;
          this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
          // 
          // grbConditionSearch
          // 
          this.grbConditionSearch.Controls.Add(this.txtDeclarationNumber);
          this.grbConditionSearch.Controls.Add(this.txtCode);
          this.grbConditionSearch.Controls.Add(this.label1);
          this.grbConditionSearch.Controls.Add(this.label2);
          this.grbConditionSearch.Controls.Add(this.label3);
          this.grbConditionSearch.Controls.Add(this.comboBoxDeclarationType);
          this.grbConditionSearch.Controls.Add(this.label4);
          this.grbConditionSearch.Controls.Add(this.dtpTo);
          this.grbConditionSearch.Controls.Add(this.dtpFrom);
          this.grbConditionSearch.Controls.Add(this.label6);
          this.grbConditionSearch.Controls.Add(this.label7);
          this.grbConditionSearch.Controls.Add(this.txtCompanyCode);
          this.grbConditionSearch.Controls.Add(this.label8);
          this.grbConditionSearch.Controls.Add(this.txtPlateNumber);
          this.grbConditionSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.grbConditionSearch.Location = new System.Drawing.Point(21, 64);
          this.grbConditionSearch.Name = "grbConditionSearch";
          this.grbConditionSearch.Size = new System.Drawing.Size(330, 258);
          this.grbConditionSearch.TabIndex = 42;
          this.grbConditionSearch.TabStop = false;
          this.grbConditionSearch.Text = "Thông tin kiểm tra";
          // 
          // txtDeclarationNumber
          // 
          this.txtDeclarationNumber.Location = new System.Drawing.Point(165, 89);
          this.txtDeclarationNumber.Mask = "0000000000";
          this.txtDeclarationNumber.Name = "txtDeclarationNumber";
          this.txtDeclarationNumber.Size = new System.Drawing.Size(149, 26);
          this.txtDeclarationNumber.TabIndex = 3;
          // 
          // FrmAddCheck
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(379, 371);
          this.Controls.Add(this.grbConditionSearch);
          this.Controls.Add(this.btnClose);
          this.Controls.Add(this.btnUpdate);
          this.Controls.Add(this.btnAdd);
          this.Controls.Add(this.lblHeader);
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.Name = "FrmAddCheck";
          this.Text = "FrmAddCheck";
          this.Load += new System.EventHandler(this.FrmAddCheck_Load);
          this.grbConditionSearch.ResumeLayout(false);
          this.grbConditionSearch.PerformLayout();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.TextBox txtCompanyCode;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.ComboBox comboBoxDeclarationType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grbConditionSearch;
        private System.Windows.Forms.MaskedTextBox txtDeclarationNumber;
    }
}