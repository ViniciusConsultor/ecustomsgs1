namespace ECustoms
{
    partial class FrmCrystalReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCrystalReport));
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.xuatCanhXeKhong = new ECustoms.XuatCanhXeKhong();
            this.exportAndHasItem1 = new ECustoms.ExportAndHasItem();
            this.importAndHasItem1 = new ECustoms.ImportAndHasItem();
            this.localImportAndHasItem1 = new ECustoms.LocalImportAndHasItem();
            this.nhapCanhXeKhong1 = new ECustoms.NhapCanhXeKhong();
            this.importGate1 = new ECustoms.ImportGate();
            this.tempImportReExport1 = new ECustoms.TempImportReExport();
            this.exportGate1 = new ECustoms.ExportGate();
            this.vehicleFreight1 = new ECustoms.VehicleFreight();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1024, 507);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // FrmCrystalReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 507);
            this.Controls.Add(this.crystalReportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCrystalReport";
            this.Text = "In sổ";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private XuatCanhXeKhong xuatCanhXeKhong;
        private ExportAndHasItem exportAndHasItem1;
        private ImportAndHasItem importAndHasItem1;
        private LocalImportAndHasItem localImportAndHasItem1;
        private NhapCanhXeKhong nhapCanhXeKhong1;
        private ImportGate importGate1;
        private TempImportReExport tempImportReExport1;
        private ExportGate exportGate1;
        private VehicleFreight vehicleFreight1;
    }
}