namespace ECustoms
{
    partial class frmDeclarationLoanDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeclarationLoanDetail));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pkLoanDateFrom = new System.Windows.Forms.DateTimePicker();
            this.pkLoanDateTo = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grvList = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.pkReturnDateFrom = new System.Windows.Forms.DateTimePicker();
            this.pkReturnDateTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeclarationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrowerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LenderFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetLoanDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnLoanDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pkReturnDateFrom);
            this.groupBox1.Controls.Add(this.pkReturnDateTo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblNumber);
            this.groupBox1.Controls.Add(this.lbl1);
            this.groupBox1.Controls.Add(this.pkLoanDateFrom);
            this.groupBox1.Controls.Add(this.pkLoanDateTo);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(15, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(865, 105);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều kiện tìm kiếm";
            // 
            // pkLoanDateFrom
            // 
            this.pkLoanDateFrom.Checked = false;
            this.pkLoanDateFrom.CustomFormat = "dd/MM/yyyy";
            this.pkLoanDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkLoanDateFrom.Location = new System.Drawing.Point(98, 41);
            this.pkLoanDateFrom.Name = "pkLoanDateFrom";
            this.pkLoanDateFrom.ShowCheckBox = true;
            this.pkLoanDateFrom.Size = new System.Drawing.Size(113, 20);
            this.pkLoanDateFrom.TabIndex = 35;
            // 
            // pkLoanDateTo
            // 
            this.pkLoanDateTo.Checked = false;
            this.pkLoanDateTo.CustomFormat = "dd/MM/yyyy";
            this.pkLoanDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkLoanDateTo.Location = new System.Drawing.Point(309, 41);
            this.pkLoanDateTo.Name = "pkLoanDateTo";
            this.pkLoanDateTo.ShowCheckBox = true;
            this.pkLoanDateTo.Size = new System.Drawing.Size(98, 20);
            this.pkLoanDateTo.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "đến ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ngày mượn từ ";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.grvList);
            this.groupBox2.Location = new System.Drawing.Point(15, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(865, 330);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách tờ khai";
            // 
            // grvList
            // 
            this.grvList.AllowUserToAddRows = false;
            this.grvList.AllowUserToDeleteRows = false;
            this.grvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DeclarationID,
            this.Number,
            this.LoanDate,
            this.ReturnDate,
            this.BorrowerName,
            this.LenderFullName,
            this.LoanReason,
            this.GetLoanDescription,
            this.ReturnLoanDescription});
            this.grvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvList.Location = new System.Drawing.Point(3, 16);
            this.grvList.Name = "grvList";
            this.grvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvList.Size = new System.Drawing.Size(859, 311);
            this.grvList.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSearch.Image = global::ECustoms.Properties.Resources.search;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(779, 65);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 28);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Tìm k&iếm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.Location = new System.Drawing.Point(106, 16);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(77, 16);
            this.lblNumber.TabIndex = 43;
            this.lblNumber.Text = "Số tờ khai";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(6, 16);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(67, 16);
            this.lbl1.TabIndex = 42;
            this.lbl1.Text = "Số tờ khai";
            // 
            // pkReturnDateFrom
            // 
            this.pkReturnDateFrom.Checked = false;
            this.pkReturnDateFrom.CustomFormat = "dd/MM/yyyy";
            this.pkReturnDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkReturnDateFrom.Location = new System.Drawing.Point(98, 73);
            this.pkReturnDateFrom.Name = "pkReturnDateFrom";
            this.pkReturnDateFrom.ShowCheckBox = true;
            this.pkReturnDateFrom.Size = new System.Drawing.Size(113, 20);
            this.pkReturnDateFrom.TabIndex = 47;
            // 
            // pkReturnDateTo
            // 
            this.pkReturnDateTo.Checked = false;
            this.pkReturnDateTo.CustomFormat = "dd/MM/yyyy";
            this.pkReturnDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkReturnDateTo.Location = new System.Drawing.Point(309, 73);
            this.pkReturnDateTo.Name = "pkReturnDateTo";
            this.pkReturnDateTo.ShowCheckBox = true;
            this.pkReturnDateTo.Size = new System.Drawing.Size(98, 20);
            this.pkReturnDateTo.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "đến ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Ngày trả từ ";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClose.Image = global::ECustoms.Properties.Resources.Exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(814, 464);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 28);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Th&oát";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 43;
            // 
            // DeclarationID
            // 
            this.DeclarationID.DataPropertyName = "DeclarationID";
            this.DeclarationID.HeaderText = "DeclarationID";
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
            // LoanDate
            // 
            this.LoanDate.DataPropertyName = "LoanDate";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy hh:mm";
            this.LoanDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.LoanDate.HeaderText = "Ngày mượn";
            this.LoanDate.Name = "LoanDate";
            // 
            // ReturnDate
            // 
            this.ReturnDate.DataPropertyName = "ReturnDate";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy hh:mm";
            this.ReturnDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.ReturnDate.HeaderText = "Ngày trả";
            this.ReturnDate.Name = "ReturnDate";
            // 
            // BorrowerName
            // 
            this.BorrowerName.DataPropertyName = "BorrowerName";
            this.BorrowerName.HeaderText = "Người mượn";
            this.BorrowerName.Name = "BorrowerName";
            this.BorrowerName.Width = 150;
            // 
            // LenderFullName
            // 
            this.LenderFullName.DataPropertyName = "LenderFullName";
            this.LenderFullName.HeaderText = "Người cho mượn";
            this.LenderFullName.Name = "LenderFullName";
            this.LenderFullName.Width = 150;
            // 
            // LoanReason
            // 
            this.LoanReason.DataPropertyName = "LoanReason";
            this.LoanReason.HeaderText = "Lý do mượn";
            this.LoanReason.Name = "LoanReason";
            this.LoanReason.Width = 200;
            // 
            // GetLoanDescription
            // 
            this.GetLoanDescription.DataPropertyName = "GetLoanDescription";
            this.GetLoanDescription.HeaderText = "Nghi chú khi mượn";
            this.GetLoanDescription.Name = "GetLoanDescription";
            this.GetLoanDescription.Width = 200;
            // 
            // ReturnLoanDescription
            // 
            this.ReturnLoanDescription.DataPropertyName = "ReturnLoanDescription";
            this.ReturnLoanDescription.HeaderText = "Ghi chú khi trả";
            this.ReturnLoanDescription.Name = "ReturnLoanDescription";
            this.ReturnLoanDescription.Width = 200;
            // 
            // frmDeclarationLoanDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 504);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDeclarationLoanDetail";
            this.Text = "frmDeclarationLoanDetail";
            this.Load += new System.EventHandler(this.frmDeclarationLoanDetail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker pkLoanDateFrom;
        private System.Windows.Forms.DateTimePicker pkLoanDateTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grvList;
        private System.Windows.Forms.DateTimePicker pkReturnDateFrom;
        private System.Windows.Forms.DateTimePicker pkReturnDateTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeclarationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LenderFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn GetLoanDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnLoanDescription;
    }
}