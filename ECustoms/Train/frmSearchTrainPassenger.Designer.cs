namespace ECustoms.Train
{
    partial class frmSearchTrainPassenger
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ddlTypeName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateXNC = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumberTrain = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdTrain = new System.Windows.Forms.DataGridView();
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
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfContainer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feeExportAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jounery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberPassengersVN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberPassengersNN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberStaff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTrain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.ddlTypeName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpDateXNC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNumberTrain);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(797, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều kiện tìm kiếm";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSearch.Image = global::ECustoms.Properties.Resources.search;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(703, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 36);
            this.btnSearch.TabIndex = 41;
            this.btnSearch.Text = "Tìm k&iếm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ddlTypeName
            // 
            this.ddlTypeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlTypeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlTypeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTypeName.FormattingEnabled = true;
            this.ddlTypeName.Location = new System.Drawing.Point(514, 21);
            this.ddlTypeName.Name = "ddlTypeName";
            this.ddlTypeName.Size = new System.Drawing.Size(142, 21);
            this.ddlTypeName.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(458, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Loại hình";
            // 
            // dtpDateXNC
            // 
            this.dtpDateXNC.CustomFormat = "dd/MM/yyyy";
            this.dtpDateXNC.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateXNC.Location = new System.Drawing.Point(336, 22);
            this.dtpDateXNC.Name = "dtpDateXNC";
            this.dtpDateXNC.Size = new System.Drawing.Size(89, 20);
            this.dtpDateXNC.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày XNC";
            // 
            // txtNumberTrain
            // 
            this.txtNumberTrain.Location = new System.Drawing.Point(111, 22);
            this.txtNumberTrain.Name = "txtNumberTrain";
            this.txtNumberTrain.Size = new System.Drawing.Size(134, 20);
            this.txtNumberTrain.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số hiệu chuyến tàu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdTrain);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(797, 309);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết quả tìm kiếm";
            // 
            // grdTrain
            // 
            this.grdTrain.AllowUserToAddRows = false;
            this.grdTrain.AllowUserToDeleteRows = false;
            this.grdTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTrain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdTrain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTrain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Count,
            this.Number,
            this.NumberOfContainer,
            this.feeExportAmount,
            this.Jounery,
            this.NumberPassengersVN,
            this.NumberPassengersNN,
            this.NumberStaff,
            this.CreatedDate,
            this.CreatedBy,
            this.Note});
            this.grdTrain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdTrain.Location = new System.Drawing.Point(9, 19);
            this.grdTrain.Name = "grdTrain";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdTrain.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdTrain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTrain.Size = new System.Drawing.Size(788, 290);
            this.grdTrain.TabIndex = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "STT";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Number";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.HeaderText = "SH Chuyến tàu";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CreatedDate";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "Ngày XNC";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Type";
            this.dataGridViewTextBoxColumn4.HeaderText = "Loại hình XNC";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Jouney";
            this.dataGridViewTextBoxColumn5.HeaderText = "Ngày nhập máy";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PassengerVN";
            this.dataGridViewTextBoxColumn6.HeaderText = "Người nhập máy";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 130;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Note";
            this.dataGridViewTextBoxColumn7.HeaderText = "Ghi chú";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Staff";
            this.dataGridViewTextBoxColumn8.HeaderText = "Số nhân viên";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "CreatedDate";
            this.dataGridViewTextBoxColumn9.HeaderText = "Ngày nhập máy";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 120;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Createdby";
            this.dataGridViewTextBoxColumn10.HeaderText = "Người nhập máy";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 130;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Note";
            this.dataGridViewTextBoxColumn11.HeaderText = "Ghi chú";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // Count
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Count.DefaultCellStyle = dataGridViewCellStyle2;
            this.Count.HeaderText = "STT";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.Width = 50;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "Number";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Number.DefaultCellStyle = dataGridViewCellStyle3;
            this.Number.HeaderText = "SH Chuyến tàu";
            this.Number.Name = "Number";
            this.Number.Width = 120;
            // 
            // NumberOfContainer
            // 
            this.NumberOfContainer.DataPropertyName = "DateExImport";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NumberOfContainer.DefaultCellStyle = dataGridViewCellStyle4;
            this.NumberOfContainer.HeaderText = "Ngày XNC";
            this.NumberOfContainer.Name = "NumberOfContainer";
            // 
            // feeExportAmount
            // 
            this.feeExportAmount.DataPropertyName = "TypeExImport";
            this.feeExportAmount.HeaderText = "Loại hình XNC";
            this.feeExportAmount.Name = "feeExportAmount";
            // 
            // Jounery
            // 
            this.Jounery.DataPropertyName = "Jounery";
            this.Jounery.HeaderText = "Hành trình";
            this.Jounery.Name = "Jounery";
            this.Jounery.ReadOnly = true;
            // 
            // NumberPassengersVN
            // 
            this.NumberPassengersVN.DataPropertyName = "PassengerVN";
            this.NumberPassengersVN.HeaderText = "Số lượng HK VN";
            this.NumberPassengersVN.Name = "NumberPassengersVN";
            this.NumberPassengersVN.ReadOnly = true;
            this.NumberPassengersVN.Width = 120;
            // 
            // NumberPassengersNN
            // 
            this.NumberPassengersNN.DataPropertyName = "PassengerForegin";
            this.NumberPassengersNN.HeaderText = "Số lượng HK NN";
            this.NumberPassengersNN.Name = "NumberPassengersNN";
            this.NumberPassengersNN.ReadOnly = true;
            this.NumberPassengersNN.Width = 120;
            // 
            // NumberStaff
            // 
            this.NumberStaff.DataPropertyName = "Staff";
            this.NumberStaff.HeaderText = "Số nhân viên";
            this.NumberStaff.Name = "NumberStaff";
            this.NumberStaff.ReadOnly = true;
            // 
            // CreatedDate
            // 
            this.CreatedDate.DataPropertyName = "CreatedDate";
            this.CreatedDate.HeaderText = "Ngày nhập máy";
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.Width = 120;
            // 
            // CreatedBy
            // 
            this.CreatedBy.DataPropertyName = "CreatedBy";
            this.CreatedBy.HeaderText = "Người nhập máy";
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.Width = 130;
            // 
            // Note
            // 
            this.Note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Note.DataPropertyName = "Note";
            this.Note.HeaderText = "Ghi chú";
            this.Note.Name = "Note";
            this.Note.Visible = false;
            // 
            // frmSearchTrainPassenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 401);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSearchTrainPassenger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSearchTrainPassenger";
            this.Load += new System.EventHandler(this.frmSearchTrainPassenger_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTrain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumberTrain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDateXNC;
        private System.Windows.Forms.ComboBox ddlTypeName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DataGridView grdTrain;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfContainer;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeExportAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jounery;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberPassengersVN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberPassengersNN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberStaff;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
    }
}