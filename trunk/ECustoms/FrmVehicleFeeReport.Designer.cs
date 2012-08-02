namespace ECustoms
{
    partial class FrmVehicleFeeReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVehicleFeeReport));
            this.dtpImportTo = new System.Windows.Forms.DateTimePicker();
            this.dtpImportFrom = new System.Windows.Forms.DateTimePicker();
            this.lblExportTo = new System.Windows.Forms.Label();
            this.lblImportTo = new System.Windows.Forms.Label();
            this.dtpExportTo = new System.Windows.Forms.DateTimePicker();
            this.dtpExportFrom = new System.Windows.Forms.DateTimePicker();
            this.lblExportFrom = new System.Windows.Forms.Label();
            this.lblImportFrom = new System.Windows.Forms.Label();
            this.cbFeeImport = new System.Windows.Forms.CheckBox();
            this.cbFeeExport = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpImportTo
            // 
            this.dtpImportTo.CustomFormat = "dd/MM/yyyy";
            this.dtpImportTo.Enabled = false;
            this.dtpImportTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpImportTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImportTo.Location = new System.Drawing.Point(595, 23);
            this.dtpImportTo.Name = "dtpImportTo";
            this.dtpImportTo.Size = new System.Drawing.Size(122, 26);
            this.dtpImportTo.TabIndex = 17;
            // 
            // dtpImportFrom
            // 
            this.dtpImportFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpImportFrom.Enabled = false;
            this.dtpImportFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpImportFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImportFrom.Location = new System.Drawing.Point(330, 23);
            this.dtpImportFrom.Name = "dtpImportFrom";
            this.dtpImportFrom.Size = new System.Drawing.Size(122, 26);
            this.dtpImportFrom.TabIndex = 16;
            // 
            // lblExportTo
            // 
            this.lblExportTo.AutoSize = true;
            this.lblExportTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportTo.Location = new System.Drawing.Point(489, 73);
            this.lblExportTo.Name = "lblExportTo";
            this.lblExportTo.Size = new System.Drawing.Size(81, 20);
            this.lblExportTo.TabIndex = 14;
            this.lblExportTo.Text = "Đến ngày:";
            // 
            // lblImportTo
            // 
            this.lblImportTo.AutoSize = true;
            this.lblImportTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportTo.Location = new System.Drawing.Point(489, 27);
            this.lblImportTo.Name = "lblImportTo";
            this.lblImportTo.Size = new System.Drawing.Size(81, 20);
            this.lblImportTo.TabIndex = 13;
            this.lblImportTo.Text = "Đến ngày:";
            // 
            // dtpExportTo
            // 
            this.dtpExportTo.CustomFormat = "dd/MM/yyyy";
            this.dtpExportTo.Enabled = false;
            this.dtpExportTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExportTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExportTo.Location = new System.Drawing.Point(595, 69);
            this.dtpExportTo.Name = "dtpExportTo";
            this.dtpExportTo.Size = new System.Drawing.Size(122, 26);
            this.dtpExportTo.TabIndex = 15;
            // 
            // dtpExportFrom
            // 
            this.dtpExportFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpExportFrom.Enabled = false;
            this.dtpExportFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExportFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExportFrom.Location = new System.Drawing.Point(330, 69);
            this.dtpExportFrom.Name = "dtpExportFrom";
            this.dtpExportFrom.Size = new System.Drawing.Size(122, 26);
            this.dtpExportFrom.TabIndex = 12;
            // 
            // lblExportFrom
            // 
            this.lblExportFrom.AutoSize = true;
            this.lblExportFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportFrom.Location = new System.Drawing.Point(238, 74);
            this.lblExportFrom.Name = "lblExportFrom";
            this.lblExportFrom.Size = new System.Drawing.Size(69, 20);
            this.lblExportFrom.TabIndex = 11;
            this.lblExportFrom.Text = "Từ ngày:";
            // 
            // lblImportFrom
            // 
            this.lblImportFrom.AutoSize = true;
            this.lblImportFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportFrom.Location = new System.Drawing.Point(237, 27);
            this.lblImportFrom.Name = "lblImportFrom";
            this.lblImportFrom.Size = new System.Drawing.Size(69, 20);
            this.lblImportFrom.TabIndex = 10;
            this.lblImportFrom.Text = "Từ ngày:";
            // 
            // cbFeeImport
            // 
            this.cbFeeImport.AutoSize = true;
            this.cbFeeImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFeeImport.Location = new System.Drawing.Point(13, 27);
            this.cbFeeImport.Name = "cbFeeImport";
            this.cbFeeImport.Size = new System.Drawing.Size(195, 24);
            this.cbFeeImport.TabIndex = 18;
            this.cbFeeImport.Text = "Ngày thu phí nhập cảnh";
            this.cbFeeImport.UseVisualStyleBackColor = true;
            this.cbFeeImport.CheckedChanged += new System.EventHandler(this.cbFeeImport_CheckedChanged);
            // 
            // cbFeeExport
            // 
            this.cbFeeExport.AutoSize = true;
            this.cbFeeExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFeeExport.Location = new System.Drawing.Point(13, 72);
            this.cbFeeExport.Name = "cbFeeExport";
            this.cbFeeExport.Size = new System.Drawing.Size(189, 24);
            this.cbFeeExport.TabIndex = 19;
            this.cbFeeExport.Text = "Ngày thu phí xuất cảnh";
            this.cbFeeExport.UseVisualStyleBackColor = true;
            this.cbFeeExport.CheckedChanged += new System.EventHandler(this.cbFeeExport_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::ECustoms.Properties.Resources.report224x24_24_bit;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(578, 118);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(139, 28);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "&Hiện báo cáo";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmVehicleFeeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 158);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbFeeExport);
            this.Controls.Add(this.cbFeeImport);
            this.Controls.Add(this.dtpImportTo);
            this.Controls.Add(this.dtpImportFrom);
            this.Controls.Add(this.lblExportTo);
            this.Controls.Add(this.lblImportTo);
            this.Controls.Add(this.dtpExportTo);
            this.Controls.Add(this.dtpExportFrom);
            this.Controls.Add(this.lblExportFrom);
            this.Controls.Add(this.lblImportFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmVehicleFeeReport";
            this.ShowInTaskbar = false;
            this.Text = "FrmVehicleFeeReport";
            this.Load += new System.EventHandler(this.FrmVehicleFeeReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpImportTo;
        private System.Windows.Forms.DateTimePicker dtpImportFrom;
        private System.Windows.Forms.Label lblExportTo;
        private System.Windows.Forms.Label lblImportTo;
        private System.Windows.Forms.DateTimePicker dtpExportTo;
        private System.Windows.Forms.DateTimePicker dtpExportFrom;
        private System.Windows.Forms.Label lblExportFrom;
        private System.Windows.Forms.Label lblImportFrom;
        private System.Windows.Forms.CheckBox cbFeeImport;
        private System.Windows.Forms.CheckBox cbFeeExport;
        private System.Windows.Forms.Button btnSearch;
    }
}