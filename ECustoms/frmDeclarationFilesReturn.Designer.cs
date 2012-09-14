namespace ECustoms
{
    partial class frmDeclarationFilesReturn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeclarationFilesReturn));
            this.grbInfo = new System.Windows.Forms.GroupBox();
            this.txtReturnLoanDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pkReturnDate = new System.Windows.Forms.DateTimePicker();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLoanReason = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pkLoanDate = new System.Windows.Forms.DateTimePicker();
            this.txtBorrower = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbInfo
            // 
            this.grbInfo.Controls.Add(this.txtReturnLoanDescription);
            this.grbInfo.Controls.Add(this.label6);
            this.grbInfo.Controls.Add(this.label7);
            this.grbInfo.Controls.Add(this.pkReturnDate);
            this.grbInfo.Controls.Add(this.lblPageNumber);
            this.grbInfo.Controls.Add(this.lblNumber);
            this.grbInfo.Controls.Add(this.label5);
            this.grbInfo.Controls.Add(this.lbl1);
            this.grbInfo.Controls.Add(this.label4);
            this.grbInfo.Controls.Add(this.txtDescription);
            this.grbInfo.Controls.Add(this.label2);
            this.grbInfo.Controls.Add(this.txtLoanReason);
            this.grbInfo.Controls.Add(this.label3);
            this.grbInfo.Controls.Add(this.pkLoanDate);
            this.grbInfo.Controls.Add(this.txtBorrower);
            this.grbInfo.Controls.Add(this.label1);
            this.grbInfo.Location = new System.Drawing.Point(12, 12);
            this.grbInfo.Name = "grbInfo";
            this.grbInfo.Size = new System.Drawing.Size(645, 501);
            this.grbInfo.TabIndex = 40;
            this.grbInfo.TabStop = false;
            this.grbInfo.Text = "Thông tin mượn hồ sơ";
            // 
            // txtReturnLoanDescription
            // 
            this.txtReturnLoanDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnLoanDescription.Location = new System.Drawing.Point(178, 374);
            this.txtReturnLoanDescription.MaxLength = 4000;
            this.txtReturnLoanDescription.Multiline = true;
            this.txtReturnLoanDescription.Name = "txtReturnLoanDescription";
            this.txtReturnLoanDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReturnLoanDescription.Size = new System.Drawing.Size(454, 88);
            this.txtReturnLoanDescription.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 371);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 45;
            this.label6.Text = "Ghi chú khi trả";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 16);
            this.label7.TabIndex = 43;
            this.label7.Text = "Ngày trả";
            // 
            // pkReturnDate
            // 
            this.pkReturnDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.pkReturnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pkReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkReturnDate.Location = new System.Drawing.Point(178, 340);
            this.pkReturnDate.Name = "pkReturnDate";
            this.pkReturnDate.Size = new System.Drawing.Size(158, 22);
            this.pkReturnDate.TabIndex = 44;
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageNumber.Location = new System.Drawing.Point(175, 53);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(69, 16);
            this.lblPageNumber.TabIndex = 42;
            this.lblPageNumber.Text = "Số lượng";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.Location = new System.Drawing.Point(175, 27);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(77, 16);
            this.lblNumber.TabIndex = 41;
            this.lblNumber.Text = "Số tờ khai";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 16);
            this.label5.TabIndex = 39;
            this.label5.Text = "Số lượng (tờ) trong hồ sơ";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(14, 27);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(67, 16);
            this.lbl1.TabIndex = 38;
            this.lbl1.Text = "Số tờ khai";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 16);
            this.label4.TabIndex = 37;
            this.label4.Text = "Nghi chú khi mượn";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(178, 242);
            this.txtDescription.MaxLength = 4000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(454, 88);
            this.txtDescription.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "Lý do mượn";
            // 
            // txtLoanReason
            // 
            this.txtLoanReason.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLoanReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoanReason.Location = new System.Drawing.Point(178, 145);
            this.txtLoanReason.MaxLength = 4000;
            this.txtLoanReason.Multiline = true;
            this.txtLoanReason.Name = "txtLoanReason";
            this.txtLoanReason.ReadOnly = true;
            this.txtLoanReason.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLoanReason.Size = new System.Drawing.Size(454, 88);
            this.txtLoanReason.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 32;
            this.label3.Text = "Ngày mượn";
            // 
            // pkLoanDate
            // 
            this.pkLoanDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.pkLoanDate.Enabled = false;
            this.pkLoanDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pkLoanDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkLoanDate.Location = new System.Drawing.Point(178, 82);
            this.pkLoanDate.Name = "pkLoanDate";
            this.pkLoanDate.Size = new System.Drawing.Size(158, 22);
            this.pkLoanDate.TabIndex = 33;
            // 
            // txtBorrower
            // 
            this.txtBorrower.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBorrower.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBorrower.Location = new System.Drawing.Point(178, 113);
            this.txtBorrower.MaxLength = 500;
            this.txtBorrower.Name = "txtBorrower";
            this.txtBorrower.ReadOnly = true;
            this.txtBorrower.Size = new System.Drawing.Size(454, 22);
            this.txtBorrower.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "Người mượn";
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAdd.Image = global::ECustoms.Properties.Resources.save;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(535, 519);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(51, 28);
            this.btnAdd.TabIndex = 47;
            this.btnAdd.Text = "Lư&u";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClose.Image = global::ECustoms.Properties.Resources.Exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(594, 519);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 28);
            this.btnClose.TabIndex = 48;
            this.btnClose.Text = "Th&oát";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmDeclarationFilesReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 558);
            this.Controls.Add(this.grbInfo);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDeclarationFilesReturn";
            this.Text = "frmDeclarationFilesReturn";
            this.Load += new System.EventHandler(this.frmDeclarationFilesReturn_Load);
            this.grbInfo.ResumeLayout(false);
            this.grbInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbInfo;
        private System.Windows.Forms.Label lblPageNumber;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLoanReason;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker pkLoanDate;
        private System.Windows.Forms.TextBox txtBorrower;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtReturnLoanDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker pkReturnDate;
    }
}