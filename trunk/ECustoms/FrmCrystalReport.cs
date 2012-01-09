using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using ECustoms.Utilities.Enums;
using ECustoms.Utilities;

namespace ECustoms
{
    public partial class FrmCrystalReport : Form
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("Ecustoms.FrmDecleExport");
        private ReportType _type;
        private DateTime _from;
        private DateTime _to;
        private UserInfo _userInfo;

        public FrmCrystalReport(ReportType type, DateTime from, DateTime to, UserInfo userInfo)
        {
            InitializeComponent();
            _type = type;
            _from = from;
            _to = to;
            _userInfo = userInfo;
            ViewReport();
            this.WindowState = FormWindowState.Maximized;
        }

        public FrmCrystalReport(vehicleTicket vehicleTicketReport, UserInfo userInfo)
        {
          InitializeComponent();
          _userInfo = userInfo;
          crystalReportViewer1.ReportSource = vehicleTicketReport;
          this.WindowState = FormWindowState.Maximized;
        }

        private  void ViewReport()
        {
            try
            {
                var connection = new SqlConnection(Common.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["connectionString"], true));

                switch (_type)
                {
                    case ReportType.ExportAndNoItem: // Type 1
                        {
                            // Created by
                            var createdByxuatCanhXeKhong = (TextObject)xuatCanhXeKhong.Section1.ReportObjects["CreatedBy"];
                            createdByxuatCanhXeKhong.Text = _userInfo.Name;
                            createdByxuatCanhXeKhong.Text = _userInfo.Name;
                            // Date From
                            var dateFromxuatCanhXeKhong = (TextObject)xuatCanhXeKhong.Section1.ReportObjects["dateFrom"];
                            dateFromxuatCanhXeKhong.Text = _from.ToString("dd/MM/yyy HH:mm");

                            // Date to
                            var dateToxuatCanhXeKhong = (TextObject)xuatCanhXeKhong.Section1.ReportObjects["dateTo"];
                            dateToxuatCanhXeKhong.Text = _to.ToString("dd/MM/yyy HH:mm");
                            
                            // Header 
                            var lblHeader = (TextObject)xuatCanhXeKhong.Section1.ReportObjects["lblHeader"];
                            lblHeader.Text = "Sổ theo dõi phương tiện xuất cảnh xe không";

                            var sql = new StringBuilder();
                            sql.Append("SELECT * ");
                            sql.Append(" FROM  ViewAllVehicleHasGood ");
                            sql.Append(" WHERE IsExport = 1 ");
                            sql.Append(" AND  ExportDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                            sql.Append("' AND ExportDate < = '" + _to.ToString("yyyy-MM-dd HH:mm"));
                            sql.Append("' AND  DeclarationID = 0");

                            var adpater = new SqlDataAdapter(sql.ToString(), connection);
                            var dt = new DataTable();
                            adpater.Fill(dt);
                            xuatCanhXeKhong.SetDataSource(dt);
                            crystalReportViewer1.ReportSource = xuatCanhXeKhong;
                        }
                        break;
                    case ReportType.ImportAndNoItem: // Type 2
                        {
                            var createdByxuatCanhXeKhong = (TextObject)nhapCanhXeKhong1.Section1.ReportObjects["CreatedBy"];
                            createdByxuatCanhXeKhong.Text = _userInfo.Name;
                            createdByxuatCanhXeKhong.Text = _userInfo.Name;

                            var dateFromxuatCanhXeKhong = (TextObject)nhapCanhXeKhong1.Section1.ReportObjects["dateFrom"];
                            dateFromxuatCanhXeKhong.Text = _from.ToString("dd/MM/yyy HH:mm");

                            var dateToxuatCanhXeKhong = (TextObject)nhapCanhXeKhong1.Section1.ReportObjects["dateTo"];
                            dateToxuatCanhXeKhong.Text = _to.ToString("dd/MM/yyy HH:mm");

                            // Header 
                            var lblHeader = (TextObject)nhapCanhXeKhong1.Section1.ReportObjects["lblHeader"];
                            lblHeader.Text = "Sổ theo dõi phương tiện nhập cảnh xe không";

                            var sql = new StringBuilder();
                            sql.Append("SELECT * ");
                            sql.Append(" FROM  ViewAllVehicleHasGood ");
                            sql.Append(" WHERE IsImport = 1 ");
                            sql.Append(" AND  ImportDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                            sql.Append("' AND ImportDate < = '" + _to.ToString("yyyy-MM-dd HH:mm"));
                            sql.Append("' AND DeclarationID = 0 ");

                            var adpater = new SqlDataAdapter(sql.ToString(), connection);
                            var dt = new DataTable();
                            adpater.Fill(dt);
                            nhapCanhXeKhong1.SetDataSource(dt);
                            crystalReportViewer1.ReportSource = nhapCanhXeKhong1;
                        }
                        break;
                    case ReportType.ExportAndHasItem: // type 3
                        {
                            var createdByexportAndHasItem = (TextObject)exportAndHasItem1.Section1.ReportObjects["CreatedBy"];
                            createdByexportAndHasItem.Text = _userInfo.Name;
                            createdByexportAndHasItem.Text = _userInfo.Name;

                            var dateexportAndHasItem = (TextObject)exportAndHasItem1.Section1.ReportObjects["dateFrom"];
                            dateexportAndHasItem.Text = _from.ToString("dd/MM/yyy HH:mm");

                            var dateToexportAndHasItem = (TextObject)exportAndHasItem1.Section1.ReportObjects["dateTo"];
                            dateToexportAndHasItem.Text = _to.ToString("dd/MM/yyy HH:mm");

                            // Header 
                            var lblHeader = (TextObject)xuatCanhXeKhong.Section1.ReportObjects["lblHeader"];
                            lblHeader.Text = "Sổ theo dõi phương tiện chở hàng xuất khẩu";

                            var sql = new StringBuilder();
                            sql.Append("SELECT     * FROM ViewAllVehicleHasGood ");
                            sql.Append(" WHERE  ");
                            sql.Append(" DeclarationID > 0 ");
                            sql.Append(" AND DeclarationType = 0 ");
                            sql.Append(" AND IsExport = 1 ");
                            sql.Append(" AND  ExportDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                            sql.Append("' AND ExportDate < = '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");

                            var adpater = new SqlDataAdapter(sql.ToString(), connection);
                            var dt = new DataTable();
                            adpater.Fill(dt);
                            exportAndHasItem1.SetDataSource(dt);
                            crystalReportViewer1.ReportSource = exportAndHasItem1;
                        }
                        break;
                    case ReportType.ImportAndHasItem: // Type 4
                        {
                            var createdimportAndHasItem = (TextObject)importAndHasItem1.Section1.ReportObjects["CreatedBy"];
                            createdimportAndHasItem.Text = _userInfo.Name;
                            createdimportAndHasItem.Text = _userInfo.Name;

                            var dateFromimportAndHasItem = (TextObject)importAndHasItem1.Section1.ReportObjects["dateFrom"];
                            dateFromimportAndHasItem.Text = _from.ToString("dd/MM/yyy HH:mm");

                            var dateToimportAndHasItem = (TextObject)importAndHasItem1.Section1.ReportObjects["dateTo"];
                            dateToimportAndHasItem.Text = _to.ToString("dd/MM/yyy HH:mm");

                            // Header 
                            var lblHeader = (TextObject)xuatCanhXeKhong.Section1.ReportObjects["lblHeader"];
                            lblHeader.Text = "Sổ theo dõi phương tiện chở hàng nhập khẩu";

                            var sql = new StringBuilder();
                            sql.Append("SELECT * FROM ViewAllVehicleHasGood ");
                            sql.Append(" WHERE ");
                            sql.Append(" (DeclarationID > 0 OR DeclarationID = 1) "); // LAY NHUNG PHUONG TIEN THUOC TO KHAI 1, CO NGHIA LA DANG O BAI                        
                            sql.Append(" AND HasGoodsImported = 1 ");
                            sql.Append(" AND DeclarationType = 1 ");
                            sql.Append(" AND IsImport = 1 ");
                            sql.Append(" AND  ImportDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                            sql.Append("' AND ImportDate < = '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");

                            var adpater = new SqlDataAdapter(sql.ToString(), connection);
                            var dt = new DataTable();
                            adpater.Fill(dt);
                            importAndHasItem1.SetDataSource(dt);
                            crystalReportViewer1.ReportSource = importAndHasItem1;
                        }
                        break;
                    case ReportType.LocalImportAndHasItem:
                        {
                            var createdlocalImportAndHasItem = (TextObject)localImportAndHasItem1.Section1.ReportObjects["CreatedBy"];
                            createdlocalImportAndHasItem.Text = _userInfo.Name;
                            createdlocalImportAndHasItem.Text = _userInfo.Name;


                            var dateFromlocalImportAndHasItem = (TextObject)localImportAndHasItem1.Section1.ReportObjects["dateFrom"];
                            dateFromlocalImportAndHasItem.Text = _from.ToString("dd/MM/yyy HH:mm");

                            var dateTolocalImportAndHasItem = (TextObject)localImportAndHasItem1.Section1.ReportObjects["dateTo"];
                            dateTolocalImportAndHasItem.Text = _to.ToString("dd/MM/yyy HH:mm");

                            var sql = new StringBuilder();
                            sql.Append("SELECT     * FROM ViewAllVehicleHasGood ");
                            
                            sql.Append(" WHERE ");
                            sql.Append(" DeclarationID > 1 ");
                            sql.Append(" AND DeclarationType = 1 ");
                            sql.Append(" AND IsGoodsImported = 1 ");
                            sql.Append(" AND  ImportedLocalTime >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                            sql.Append("' AND ImportedLocalTime < = '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");

                            var adpater = new SqlDataAdapter(sql.ToString(), connection);
                            var dt = new DataTable();
                            adpater.Fill(dt);
                            localImportAndHasItem1.SetDataSource(dt);
                            crystalReportViewer1.ReportSource = localImportAndHasItem1;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
