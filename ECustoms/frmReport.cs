using System;
using System.Drawing;
using System.Windows.Forms;
using ECustoms.Utilities;
using ECustoms.Utilities.Enums;
using log4net;

namespace ECustoms
{
    public partial class frmReport : SubFormBase
    {
        private static log4net.ILog logger = LogManager.GetLogger("Ecustoms.frmReport");
        private Form _mainForm;
        private UserInfo _userInfo;
        private int _type;

        public frmReport(Form mainFrom, UserInfo userInfo, int type)
        {
            _userInfo = userInfo;
            _type = type;
            InitializeComponent();
            InitializeReportType();
            _mainForm = mainFrom;

        }

        private void InitializeReportType()
        {
            // Put some stuff in the combo box
            cbReportType.Items.Add("Phương tiện xuất cảnh xe không");
            cbReportType.Items.Add("Phương tiện nhập cảnh xe không");
            cbReportType.Items.Add("Phương tiện chở hàng xuất khẩu");
            cbReportType.Items.Add("Phương tiện chở hàng nhập khẩu");
            cbReportType.Items.Add("Phương tiện hoàn thành thủ tục Hải quan vào nội địa");

            if (_userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_IN_BAO_CAO_TNTX))
            {
                cbReportType.Items.Add("Xuất khẩu chuyển cửa khẩu");
                cbReportType.Items.Add("Nhập khẩu chuyển cửa khẩu");
                cbReportType.Items.Add("Hàng tạm nhập tái xuất");
            }

            cbReportType.Items.Add("Số liệu phương tiện vận chuyển hàng hóa");
            cbReportType.SelectedIndex = _type;
            if (_type != 0)
                cbReportType.Enabled = false;
        }

        /// <summary>
        /// Get DataTable to report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var from = new DateTime(dtpExportFrom.Value.Year, dtpExportFrom.Value.Month, dtpExportFrom.Value.Day, 0, 0, 0);
                var to = new DateTime(dtpExportTo.Value.Year, dtpExportTo.Value.Month, dtpExportTo.Value.Day, 23, 59, 59);
                var reportType = GetReportType(cbReportType.SelectedIndex + 1);

                var report = new FrmCrystalReport(reportType, from, to, _userInfo);
                report.MaximizeBox = true;
                report.Show(this);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
            
        }

        private void frmReport_Load(object sender, EventArgs e)
        {

            this.Location = new Point((_mainForm.Width - this.Width) / 2, (_mainForm.Height - this.Height) / 2);
         }

        private ReportType GetReportType(int value)
        {
            switch (value)
            {
                case 1:
                    return ReportType.ExportAndNoItem;
                    break;
                case 2:
                    return ReportType.ImportAndNoItem;
                    break;
                case 3:
                    return ReportType.ExportAndHasItem;
                    break;
                case 4 :
                    return ReportType.ImportAndHasItem;
                    break;
                case 5:
                    return ReportType.LocalImportAndHasItem;
                    break;
                case 6:
                    return ReportType.ExportGateTransfer;
                    break;
                case 7:
                    return ReportType.ImportGateTransfer;
                    break;
                case 8:
                    return ReportType.TempImportedReExport;
                    break;
                case 9:
                    return ReportType.VehicleTransportGoods;
                    break;
            }
            return ReportType.ExportAndNoItem;
        }

        private void cbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTime.Text = (cbReportType.SelectedIndex > 4 && cbReportType.SelectedIndex < 8) ? "Thời gian nhập máy từ:" : "Thời gian từ:";
        }
    }
}
