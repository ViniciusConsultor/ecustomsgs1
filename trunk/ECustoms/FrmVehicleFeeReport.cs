using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.DAL;
using ECustoms.Utilities;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace ECustoms
{
    public partial class FrmVehicleFeeReport : Form
    {
        private UserInfo _userInfo;
        public FrmVehicleFeeReport()
        {
            InitializeComponent();
        }

        public FrmVehicleFeeReport(UserInfo userInfo)
        {
            InitializeComponent();
            _userInfo = userInfo;
        }

        private void cbFeeImport_CheckedChanged(object sender, EventArgs e)
        {
            dtpImportFrom.Enabled = cbFeeImport.Checked;
            lblImportFrom.Enabled = cbFeeImport.Checked;
            dtpImportTo.Enabled = cbFeeImport.Checked;
            lblImportTo.Enabled = cbFeeImport.Checked;
        }

        private void cbFeeExport_CheckedChanged(object sender, EventArgs e)
        {
            dtpExportFrom.Enabled = cbFeeExport.Checked;
            dtpExportTo.Enabled = cbFeeExport.Checked;

            lblExportFrom.Enabled = cbFeeExport.Checked;
            lblExportTo.Enabled = cbFeeExport.Checked;
            
        }

        private void FrmVehicleFeeReport_Load(object sender, EventArgs e)
        {
            this.Text = "Báo cáo thu phí" + ConstantInfo.MESSAGE_TITLE;
            cbFeeExport.Checked = true;
            cbFeeImport.Checked = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbFeeExport.Checked == false && cbFeeImport.Checked == false)
            {
                MessageBox.Show("Bạn cần chọn loại báo cáo");
                return;
            }
            try
            {

                var dateImportValueFrom = new DateTime(dtpImportFrom.Value.Year, dtpImportFrom.Value.Month, dtpImportFrom.Value.Day, 0, 0, 0);
                var dateImportValueTo = new DateTime(dtpImportTo.Value.Year, dtpImportTo.Value.Month, dtpImportTo.Value.Day, 23, 59, 59);

                var dateExportValueFrom = new DateTime(dtpExportFrom.Value.Year, dtpExportFrom.Value.Month, dtpExportFrom.Value.Day, 0, 0, 0);
                var dateExportValueTo = new DateTime(dtpExportTo.Value.Year, dtpExportTo.Value.Month, dtpExportTo.Value.Day, 23, 59, 59);


                var vehicleFeeReport = new VehicleFeeReport();

                var connection = new SqlConnection(Common.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["connectionString"], true));

                var createdBy = (TextObject)vehicleFeeReport.Section1.ReportObjects["CreatedBy"];
                createdBy.Text = _userInfo.Name;

                var dateImportFrom = (TextObject)vehicleFeeReport.Section1.ReportObjects["dateImportFrom"];
                dateImportFrom.Text = dtpImportFrom.Value.ToString("dd/MM/yyy");

                var dateImportTo = (TextObject)vehicleFeeReport.Section1.ReportObjects["dateImportTo"];
                dateImportTo.Text = dtpImportTo.Value.ToString("dd/MM/yyy");


                var dateExportFrom = (TextObject)vehicleFeeReport.Section1.ReportObjects["dateExportFrom"];
                dateExportFrom.Text = dtpExportFrom.Value.ToString("dd/MM/yyy");

                var dateExportTo = (TextObject)vehicleFeeReport.Section1.ReportObjects["dateExportTo"];
                dateExportTo.Text = dtpExportTo.Value.ToString("dd/MM/yyy");


                var sql = new StringBuilder();

                if (cbFeeImport.Checked == true && cbFeeExport.Checked == false)
                {
                    sql.Append("select * from ViewAllVehicleHasGood as table1");
                    sql.Append(" inner join");
                    sql.Append(" (select VehicleID,max(ViewAllVehicleHasGood.DeclarationID) as maxDeclarationID from ViewAllVehicleHasGood ");
                    sql.Append(" where 1=1");
                    sql.Append(" group by ViewAllVehicleHasGood.VehicleID) as table2");

                    sql.Append(" on table1.VehicleID = table2.VehicleID and table1.DeclarationID = table2.maxDeclarationID");

                    sql.Append(" AND  table1.feeImportDate >= '" + dateImportValueFrom.ToString("yyyy-MM-dd HH:mm"));
                    sql.Append("' AND table1.feeImportDate < = '" + dateImportValueTo.ToString("yyyy-MM-dd HH:mm") + "'");
                }


                if (cbFeeImport.Checked == false && cbFeeExport.Checked == true)
                {
                    sql.Append("select * from ViewAllVehicleHasGood as table1");
                    sql.Append(" inner join");
                    sql.Append(" (select VehicleID,max(ViewAllVehicleHasGood.DeclarationID) as maxDeclarationID from ViewAllVehicleHasGood ");
                    sql.Append(" where 1=1");
                    sql.Append(" group by ViewAllVehicleHasGood.VehicleID) as table2");

                    sql.Append(" on table1.VehicleID = table2.VehicleID and table1.DeclarationID = table2.maxDeclarationID");

                    sql.Append(" AND  table1.feeExportDate >= '" + dateExportValueFrom.ToString("yyyy-MM-dd HH:mm"));
                    sql.Append("' AND table1.feeExportDate < = '" + dateExportValueTo.ToString("yyyy-MM-dd HH:mm") + "'");
                }


                if (cbFeeImport.Checked == true && cbFeeExport.Checked == true)
                {
                    sql.Append("select * from ViewAllVehicleHasGood as table1");
                    sql.Append(" inner join");
                    sql.Append(" (select VehicleID,max(ViewAllVehicleHasGood.DeclarationID) as maxDeclarationID from ViewAllVehicleHasGood ");
                    sql.Append(" where 1=1");
                    sql.Append(" group by ViewAllVehicleHasGood.VehicleID) as table2");

                    sql.Append(" on table1.VehicleID = table2.VehicleID and table1.DeclarationID = table2.maxDeclarationID");

                    sql.Append(" AND  ((table1.feeExportDate >= '" + dateImportValueFrom.ToString("yyyy-MM-dd HH:mm"));
                    sql.Append("' AND table1.feeExportDate < = '" + dateImportValueTo.ToString("yyyy-MM-dd HH:mm") + "')");

                    sql.Append(" OR ( table1.feeImportDate >= '" + dateExportValueFrom.ToString("yyyy-MM-dd HH:mm"));
                    sql.Append("' AND table1.feeImportDate < = '" + dateExportValueTo.ToString("yyyy-MM-dd HH:mm") + "'))");
                }

                var adpater = new SqlDataAdapter(sql.ToString(), connection);
                var dt = new DataTable();
                adpater.Fill(dt);
                vehicleFeeReport.SetDataSource(dt);

                FrmCrystalReport frmReport = new FrmCrystalReport(vehicleFeeReport);
                frmReport.Show(); 
            }
            catch (Exception ex)
            {
            }
        }
    }
}
