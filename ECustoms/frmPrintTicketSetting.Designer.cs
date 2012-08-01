namespace ECustoms
{
  partial class frmPrintTicketSetting
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintTicketSetting));
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.cbPrintExportPark = new System.Windows.Forms.CheckBox();
        this.listBoxPrint = new System.Windows.Forms.ListBox();
        this.label1 = new System.Windows.Forms.Label();
        this.cbPrintParking = new System.Windows.Forms.CheckBox();
        this.cbPrintImportHasGood = new System.Windows.Forms.CheckBox();
        this.btnClose = new System.Windows.Forms.Button();
        this.btnSave = new System.Windows.Forms.Button();
        this.groupBox1.SuspendLayout();
        this.SuspendLayout();
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.cbPrintExportPark);
        this.groupBox1.Controls.Add(this.listBoxPrint);
        this.groupBox1.Controls.Add(this.label1);
        this.groupBox1.Controls.Add(this.cbPrintParking);
        this.groupBox1.Controls.Add(this.cbPrintImportHasGood);
        this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.groupBox1.Location = new System.Drawing.Point(22, 19);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(344, 264);
        this.groupBox1.TabIndex = 0;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Thiết lập in ticket";
        // 
        // cbPrintExportPark
        // 
        this.cbPrintExportPark.AutoSize = true;
        this.cbPrintExportPark.Location = new System.Drawing.Point(10, 228);
        this.cbPrintExportPark.Name = "cbPrintExportPark";
        this.cbPrintExportPark.Size = new System.Drawing.Size(222, 24);
        this.cbPrintExportPark.TabIndex = 4;
        this.cbPrintExportPark.Text = "In khi xác nhận vào bãi xuất";
        this.cbPrintExportPark.UseVisualStyleBackColor = true;
        // 
        // listBoxPrint
        // 
        this.listBoxPrint.FormattingEnabled = true;
        this.listBoxPrint.ItemHeight = 20;
        this.listBoxPrint.Location = new System.Drawing.Point(10, 49);
        this.listBoxPrint.Name = "listBoxPrint";
        this.listBoxPrint.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
        this.listBoxPrint.Size = new System.Drawing.Size(266, 104);
        this.listBoxPrint.TabIndex = 3;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(6, 26);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(135, 20);
        this.label1.TabIndex = 2;
        this.label1.Text = "Danh sách máy in";
        // 
        // cbPrintParking
        // 
        this.cbPrintParking.AutoSize = true;
        this.cbPrintParking.Location = new System.Drawing.Point(10, 198);
        this.cbPrintParking.Name = "cbPrintParking";
        this.cbPrintParking.Size = new System.Drawing.Size(228, 24);
        this.cbPrintParking.TabIndex = 1;
        this.cbPrintParking.Text = "In khi xác nhận vào bãi nhập";
        this.cbPrintParking.UseVisualStyleBackColor = true;
        // 
        // cbPrintImportHasGood
        // 
        this.cbPrintImportHasGood.AutoSize = true;
        this.cbPrintImportHasGood.Location = new System.Drawing.Point(10, 168);
        this.cbPrintImportHasGood.Name = "cbPrintImportHasGood";
        this.cbPrintImportHasGood.Size = new System.Drawing.Size(274, 24);
        this.cbPrintImportHasGood.TabIndex = 0;
        this.cbPrintImportHasGood.Text = "In khi xác nhận nhập cảnh có hàng";
        this.cbPrintImportHasGood.UseVisualStyleBackColor = true;
        // 
        // btnClose
        // 
        this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnClose.Image = global::ECustoms.Properties.Resources.Exit;
        this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnClose.Location = new System.Drawing.Point(282, 289);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(84, 28);
        this.btnClose.TabIndex = 8;
        this.btnClose.Text = "Th&oát";
        this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnClose.UseVisualStyleBackColor = true;
        this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
        // 
        // btnSave
        // 
        this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnSave.Image = global::ECustoms.Properties.Resources.save;
        this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnSave.Location = new System.Drawing.Point(197, 289);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(79, 28);
        this.btnSave.TabIndex = 7;
        this.btnSave.Text = "Lư&u";
        this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnSave.UseVisualStyleBackColor = true;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        // 
        // frmPrintTicketSetting
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(378, 329);
        this.Controls.Add(this.btnClose);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.groupBox1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.Name = "frmPrintTicketSetting";
        this.ShowInTaskbar = false;
        this.Text = "frmPrintTicketSetting";
        this.Load += new System.EventHandler(this.frmPrintTicketSetting_Load);
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox cbPrintParking;
    private System.Windows.Forms.CheckBox cbPrintImportHasGood;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListBox listBoxPrint;
    private System.Windows.Forms.CheckBox cbPrintExportPark;
  }
}