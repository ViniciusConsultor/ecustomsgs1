using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using ECustoms.Utilities.Enums;
using ECustoms.Utilities;
using ECustoms.BOL;

namespace ECustoms
{
    public partial class FrmCrystalReport : SubFormBase
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("Ecustoms.FrmDecleExport");
        private String _type; //loai hinh
        private ReportType _reportType;
        private DateTime _from;
        private DateTime _to;
        private UserInfo _userInfo;
        private string _branchId;

        public FrmCrystalReport(VehicleFeeReport report)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = report;
            this.WindowState = FormWindowState.Maximized;
        }

        public FrmCrystalReport(ReportType reportType, DateTime from, DateTime to, UserInfo userInfo, string branchId = "0",string type= "")
        {
            InitializeComponent();
            _type = type;
            _branchId = branchId;
            _reportType = reportType;
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

        public FrmCrystalReport(VehicleExportParkTicket vehicleTicket, UserInfo userInfo)
        {
            InitializeComponent();
            _userInfo = userInfo;
            crystalReportViewer1.ReportSource = vehicleTicket;
            this.WindowState = FormWindowState.Maximized;
        }


        private string GetUserConfig()
        {
            var profileConfig = UserFactory.GetProfileConfigByUserId(_userInfo.UserID);
            foreach (var config in profileConfig)
            {
                if (config.Type == (int)ProfileConfig.SuperiorCompany)
                {
                    return config.Value;
                }
            }
            return "";
        }

        private  void ViewReport()
        {
            try
            {
                var connection = new SqlConnection(Common.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["connectionString"], true));

                switch (_reportType)
                {
                    case ReportType.ExportAndNoItem: // Type 1
                        {
                            // Superior Company
                            ((TextObject)xuatCanhXeKhong.Section1.ReportObjects["SuperiorCompany"]).Text = GetUserConfig().ToUpper();
                            // Company
                            ((TextObject)xuatCanhXeKhong.Section1.ReportObjects["CompanyName"]).Text = GlobalInfo.CompanyName.ToUpper();
                            // Created by
                            var createdByxuatCanhXeKhong = (TextObject)xuatCanhXeKhong.Section1.ReportObjects["CreatedBy"];
                            createdByxuatCanhXeKhong.Text = _userInfo.Name;
                            
                            // Date From
                            var dateFromxuatCanhXeKhong = (TextObject)xuatCanhXeKhong.Section1.ReportObjects["dateFrom"];
                            dateFromxuatCanhXeKhong.Text = _from.ToString("dd/MM/yyy HH:mm");

                            // Date to
                            var dateToxuatCanhXeKhong = (TextObject)xuatCanhXeKhong.Section1.ReportObjects["dateTo"];
                            dateToxuatCanhXeKhong.Text = _to.ToString("dd/MM/yyy HH:mm");
                            
                            // Header 
                            var lblHeader = (TextObject)xuatCanhXeKhong.Section1.ReportObjects["lblHeader"];
                            lblHeader.Text = "SỔ THEO DÕI PHƯƠNG TIỆN XUẤT CẢNH XE KHÔNG";

                            var sql = new StringBuilder();
                            if (_branchId != "0")  //tim theo chi cuc hai quan
                            {
                                sql.Append("SELECT * ");
                                sql.Append(" FROM  ViewAllVehicleHasGood ");
                                sql.Append(" WHERE IsExport = 1 ");
                                sql.Append(" AND  ExportDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                sql.Append("' AND ExportDate < = '" + _to.ToString("yyyy-MM-dd HH:mm"));
                                sql.Append("' AND  DeclarationID = 0");
                                sql.Append(" AND  BranchId = '" + _branchId + "'");
                            }
                            else //tim tat cac cac chi cuc hai quan
                            {
                                sql.Append("SELECT * ");
                                sql.Append(" FROM  ViewAllVehicleHasGood ");
                                sql.Append(" WHERE IsExport = 1 ");
                                sql.Append(" AND  ExportDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                sql.Append("' AND ExportDate < = '" + _to.ToString("yyyy-MM-dd HH:mm"));
                                sql.Append("' AND  DeclarationID = 0");
                            }
                            if(string.IsNullOrEmpty(_type)==false)
                            {
                                sql.Append(" AND  Type = '" + _type + "'");
                            }
                           
                            var adpater = new SqlDataAdapter(sql.ToString(), connection);
                            var dt = new DataTable();
                            adpater.Fill(dt);
                            xuatCanhXeKhong.SetDataSource(dt);
                            crystalReportViewer1.ReportSource = xuatCanhXeKhong;                            
                        }
                        break;
                    case ReportType.ImportAndNoItem: // Type 2
                        {
                            // Superior Company
                            ((TextObject)nhapCanhXeKhong1.Section1.ReportObjects["SuperiorCompany"]).Text = GetUserConfig().ToUpper();
                            // Company
                            ((TextObject)nhapCanhXeKhong1.Section1.ReportObjects["CompanyName"]).Text = GlobalInfo.CompanyName.ToUpper();
                            var createdByxuatCanhXeKhong = (TextObject)nhapCanhXeKhong1.Section1.ReportObjects["CreatedBy"];
                            createdByxuatCanhXeKhong.Text = _userInfo.Name;

                            var dateFromxuatCanhXeKhong = (TextObject)nhapCanhXeKhong1.Section1.ReportObjects["dateFrom"];
                            dateFromxuatCanhXeKhong.Text = _from.ToString("dd/MM/yyy HH:mm");

                            var dateToxuatCanhXeKhong = (TextObject)nhapCanhXeKhong1.Section1.ReportObjects["dateTo"];
                            dateToxuatCanhXeKhong.Text = _to.ToString("dd/MM/yyy HH:mm");

                            // Header 
                            var lblHeader = (TextObject)nhapCanhXeKhong1.Section1.ReportObjects["lblHeader"];
                            lblHeader.Text = "Sổ theo dõi phương tiện nhập cảnh xe không";

                            var sql = new StringBuilder();
                            if (_branchId != "0")  //tim theo chi cuc hai quan
                            {
                                sql.Append("SELECT * ");
                                sql.Append(" FROM  ViewAllVehicleHasGood ");
                                sql.Append(" WHERE IsImport = 1 ");
                                sql.Append(" AND  ImportDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                sql.Append("' AND ImportDate < = '" + _to.ToString("yyyy-MM-dd HH:mm"));
                                sql.Append("' AND DeclarationID = 0 ");
                                sql.Append(" AND  BranchId = '" + _branchId + "'");
                            }
                            else //tim tat cac cac chi cuc hai quan
                            {
                                sql.Append("SELECT * ");
                                sql.Append(" FROM  ViewAllVehicleHasGood ");
                                sql.Append(" WHERE IsImport = 1 ");
                                sql.Append(" AND  ImportDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                sql.Append("' AND ImportDate < = '" + _to.ToString("yyyy-MM-dd HH:mm"));
                                sql.Append("' AND DeclarationID = 0 ");
                            }

                            if(string.IsNullOrEmpty(_type)==false)
                            {
                                sql.Append(" AND  Type = '" + _type + "'");
                            }

                            var adpater = new SqlDataAdapter(sql.ToString(), connection);
                            var dt = new DataTable();
                            adpater.Fill(dt);
                            nhapCanhXeKhong1.SetDataSource(dt);
                            crystalReportViewer1.ReportSource = nhapCanhXeKhong1;
                        }
                        break;
                    case ReportType.ExportAndHasItem: // type 3
                        {
                            // Superior Company
                            ((TextObject)exportAndHasItem1.Section1.ReportObjects["SuperiorCompany"]).Text = GetUserConfig().ToUpper();
                            // Company
                            ((TextObject)exportAndHasItem1.Section1.ReportObjects["CompanyName"]).Text = GlobalInfo.CompanyName.ToUpper();
                            var createdByexportAndHasItem = (TextObject)exportAndHasItem1.Section1.ReportObjects["CreatedBy"];
                            createdByexportAndHasItem.Text = _userInfo.Name;

                            var dateexportAndHasItem = (TextObject)exportAndHasItem1.Section1.ReportObjects["dateFrom"];
                            dateexportAndHasItem.Text = _from.ToString("dd/MM/yyy HH:mm");

                            var dateToexportAndHasItem = (TextObject)exportAndHasItem1.Section1.ReportObjects["dateTo"];
                            dateToexportAndHasItem.Text = _to.ToString("dd/MM/yyy HH:mm");

                            // Header 
                            var lblHeader = (TextObject)xuatCanhXeKhong.Section1.ReportObjects["lblHeader"];
                            lblHeader.Text = "SỔ THEO DÕI PHƯƠNG TIỆN CHỞ HÀNG XUẤT KHẨU";

                            var sql = new StringBuilder();
                            if (_branchId != "0")  //tim theo chi cuc hai quan
                            {
                                sql.Append("SELECT     * FROM ViewAllVehicleHasGood ");
                                sql.Append(" WHERE  ");
                                sql.Append(" DeclarationID > 0 ");
                                sql.Append(" AND DeclarationType = 0 ");
                                sql.Append(" AND IsExport = 1 ");
                                sql.Append(" AND  ExportDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                sql.Append("' AND ExportDate < = '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");
                                sql.Append(" AND  BranchId = '" + _branchId + "'");
                            }
                            else
                            {
                                sql.Append("SELECT     * FROM ViewAllVehicleHasGood ");
                                sql.Append(" WHERE  ");
                                sql.Append(" DeclarationID > 0 ");
                                sql.Append(" AND DeclarationType = 0 ");
                                sql.Append(" AND IsExport = 1 ");
                                sql.Append(" AND  ExportDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                sql.Append("' AND ExportDate < = '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");
                            }

                            if(string.IsNullOrEmpty(_type)==false)
                            {
                                sql.Append(" AND  Type = '" + _type + "'");
                            }

                            var adpater = new SqlDataAdapter(sql.ToString(), connection);
                            var dt = new DataTable();
                            adpater.Fill(dt);
                            exportAndHasItem1.SetDataSource(dt);
                            crystalReportViewer1.ReportSource = exportAndHasItem1;
                        }
                        break;
                    case ReportType.ImportAndHasItem: // Type 4
                        {
                            // Superior Company
                            ((TextObject)importAndHasItem1.Section1.ReportObjects["SuperiorCompany"]).Text = GetUserConfig().ToUpper();
                            // Company
                            ((TextObject)importAndHasItem1.Section1.ReportObjects["CompanyName"]).Text = GlobalInfo.CompanyName.ToUpper();
                            var createdimportAndHasItem = (TextObject)importAndHasItem1.Section1.ReportObjects["CreatedBy"];
                            createdimportAndHasItem.Text = _userInfo.Name;

                            var dateFromimportAndHasItem = (TextObject)importAndHasItem1.Section1.ReportObjects["dateFrom"];
                            dateFromimportAndHasItem.Text = _from.ToString("dd/MM/yyy HH:mm");

                            var dateToimportAndHasItem = (TextObject)importAndHasItem1.Section1.ReportObjects["dateTo"];
                            dateToimportAndHasItem.Text = _to.ToString("dd/MM/yyy HH:mm");

                            // Header 
                            var lblHeader = (TextObject)xuatCanhXeKhong.Section1.ReportObjects["lblHeader"];
                            lblHeader.Text = "SỔ THEO DÕI PHƯƠNG TIỆN CHỞ HÀNG NHẬP KHẨU";

                            var sql = new StringBuilder();
                            //sql.Append("SELECT * FROM ViewAllVehicleHasGood ");
                            //sql.Append(" WHERE ");
                            //sql.Append(" (DeclarationID > 0 OR DeclarationID = 1) "); // LAY NHUNG PHUONG TIEN THUOC TO KHAI 1, CO NGHIA LA DANG O BAI                        
                            //sql.Append(" AND HasGoodsImported = 1 ");
                            //sql.Append(" AND DeclarationType = 1 ");
                            //sql.Append(" AND IsImport = 1 ");
                            //sql.Append(" AND  ImportDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                            //sql.Append("' AND ImportDate < = '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");
                            if (_branchId != "0")  //tim theo chi cuc hai quan
                            {
                                sql.Append("select * from ViewAllVehicleHasGood as table1");
                                sql.Append(" inner join");
                                sql.Append(" (select VehicleID,max(ViewAllVehicleHasGood.DeclarationID) as maxDeclarationID, DeclarationType from ViewAllVehicleHasGood ");
                                sql.Append(" where 1=1");
                                sql.Append(" group by ViewAllVehicleHasGood.VehicleID, ViewAllVehicleHasGood.DeclarationType) as table2");

                                sql.Append(" on table1.VehicleID = table2.VehicleID and table1.DeclarationID = table2.maxDeclarationID");
                                sql.Append(" AND");


                                sql.Append(" (table1.DeclarationID > 0 OR table1.DeclarationID = 1) "); // LAY NHUNG PHUONG TIEN THUOC TO KHAI 1, CO NGHIA LA DANG O BAI                        
                                sql.Append(" AND table1.HasGoodsImported = 1 ");
                                sql.Append(" AND table1.DeclarationType = 1 ");
                                sql.Append(" AND table1.IsImport = 1 ");
                                sql.Append(" AND  table1.ImportDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                sql.Append("' AND table1.ImportDate < = '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");
                                sql.Append(" AND  table1.BranchId = '" + _branchId + "'");
                            }
                            else
                            {
                                sql.Append("select * from ViewAllVehicleHasGood as table1");
                                sql.Append(" inner join");
                                sql.Append(" (select VehicleID,max(ViewAllVehicleHasGood.DeclarationID) as maxDeclarationID, DeclarationType from ViewAllVehicleHasGood ");
                                sql.Append(" where 1=1");
                                sql.Append(" group by ViewAllVehicleHasGood.VehicleID, ViewAllVehicleHasGood.DeclarationType) as table2");

                                sql.Append(" on table1.VehicleID = table2.VehicleID and table1.DeclarationID = table2.maxDeclarationID");
                                sql.Append(" AND");


                                sql.Append(" (table1.DeclarationID > 0 OR table1.DeclarationID = 1) "); // LAY NHUNG PHUONG TIEN THUOC TO KHAI 1, CO NGHIA LA DANG O BAI                        
                                sql.Append(" AND table1.HasGoodsImported = 1 ");
                                sql.Append(" AND table1.DeclarationType = 1 ");
                                sql.Append(" AND table1.IsImport = 1 ");
                                sql.Append(" AND  table1.ImportDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                sql.Append("' AND table1.ImportDate < = '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");
                            }

                            if(string.IsNullOrEmpty(_type)==false)
                            {
                                sql.Append(" AND  table1.Type = '" + _type + "'");
                            }

                            var adpater = new SqlDataAdapter(sql.ToString(), connection);
                            var dt = new DataTable();
                            adpater.Fill(dt);
                            importAndHasItem1.SetDataSource(dt);
                            crystalReportViewer1.ReportSource = importAndHasItem1;
                        }
                        break;
                    case ReportType.LocalImportAndHasItem:
                        {
                            // Superior Company
                            ((TextObject)localImportAndHasItem1.Section1.ReportObjects["SuperiorCompany"]).Text = GetUserConfig().ToUpper();
                            // Company
                            ((TextObject)localImportAndHasItem1.Section1.ReportObjects["CompanyName"]).Text = GlobalInfo.CompanyName.ToUpper();
                            var createdlocalImportAndHasItem = (TextObject)localImportAndHasItem1.Section1.ReportObjects["CreatedBy"];
                            createdlocalImportAndHasItem.Text = _userInfo.Name;

                            var dateFromlocalImportAndHasItem = (TextObject)localImportAndHasItem1.Section1.ReportObjects["dateFrom"];
                            dateFromlocalImportAndHasItem.Text = _from.ToString("dd/MM/yyy HH:mm");

                            var dateTolocalImportAndHasItem = (TextObject)localImportAndHasItem1.Section1.ReportObjects["dateTo"];
                            dateTolocalImportAndHasItem.Text = _to.ToString("dd/MM/yyy HH:mm");

                            var sql = new StringBuilder();
                            if (_branchId != "0")  //tim theo chi cuc hai quan
                            {
                                sql.Append("SELECT     * FROM ViewAllVehicleHasGood ");

                                sql.Append(" WHERE ");
                                sql.Append(" DeclarationID > 1 ");
                                sql.Append(" AND DeclarationType = 1 ");
                                sql.Append(" AND IsGoodsImported = 1 ");
                                sql.Append(" AND  ImportedLocalTime >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                sql.Append("' AND ImportedLocalTime < = '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");
                                sql.Append(" AND  BranchId = '" + _branchId + "'");
                            }
                            else
                            {
                                sql.Append("SELECT     * FROM ViewAllVehicleHasGood ");

                                sql.Append(" WHERE ");
                                sql.Append(" DeclarationID > 1 ");
                                sql.Append(" AND DeclarationType = 1 ");
                                sql.Append(" AND IsGoodsImported = 1 ");
                                sql.Append(" AND  ImportedLocalTime >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                sql.Append("' AND ImportedLocalTime < = '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");
                            }

                            if(string.IsNullOrEmpty(_type)==false)
                            {
                                sql.Append(" AND  Type = '" + _type + "'");
                            }

                            var adpater = new SqlDataAdapter(sql.ToString(), connection);
                            var dt = new DataTable();
                            adpater.Fill(dt);
                            localImportAndHasItem1.SetDataSource(dt);
                            crystalReportViewer1.ReportSource = localImportAndHasItem1;
                        }
                        break;
                    case ReportType.ExportGateTransfer:
                        {
                            // Superior Company
                            ((TextObject)exportGate1.Section1.ReportObjects["SuperiorCompany"]).Text = GetUserConfig().ToUpper();
                            // Company
                            ((TextObject)exportGate1.Section1.ReportObjects["CompanyName"]).Text = GlobalInfo.CompanyName.ToUpper();
                            var dateFrom = (TextObject)exportGate1.Section1.ReportObjects["dateFrom"];
                            dateFrom.Text = _from.ToString("dd/MM/yyyy");

                            var dateTo = (TextObject)exportGate1.Section1.ReportObjects["dateTo"];
                            dateTo.Text = _to.ToString("dd/MM/yyyy");

                            StringBuilder buffer = new StringBuilder();
                            if (_branchId != "0")  //tim theo chi cuc hai quan
                            {
                                buffer.Append(" SELECT    * FROM ViewAllDeclarationTNTX ");
                                buffer.Append(" WHERE ");
                                buffer.Append(" DeclarationID > 1 ");
                                buffer.Append(" AND TypeOption = " + (short)Common.DeclerationOptionType.XKCK);
                                buffer.Append(" AND CreatedDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                buffer.Append("' AND CreatedDate <= '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");
                                buffer.Append(" AND  BranchId = '" + _branchId + "'");
                            }
                            else
                            {
                                buffer.Append(" SELECT    * FROM ViewAllDeclarationTNTX ");
                                buffer.Append(" WHERE ");
                                buffer.Append(" DeclarationID > 1 ");
                                buffer.Append(" AND TypeOption = " + (short)Common.DeclerationOptionType.XKCK);
                                buffer.Append(" AND CreatedDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                buffer.Append("' AND CreatedDate <= '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");

                            }
                            if(string.IsNullOrEmpty(_type)==false)
                            {
                                buffer.Append(" AND  Type = '" + _type + "'");
                            }

                            var adpater = new SqlDataAdapter(buffer.ToString(), connection);
                            var dt = new DataTable();
                            adpater.Fill(dt);
                            exportGate1.SetDataSource(dt);
                            crystalReportViewer1.ReportSource = exportGate1;
                        }
                        break;
                    case ReportType.ImportGateTransfer:
                        {
                            // Superior Company
                            ((TextObject)importGate1.Section1.ReportObjects["SuperiorCompany"]).Text = GetUserConfig().ToUpper();
                            // Company
                            ((TextObject)importGate1.Section1.ReportObjects["CompanyName"]).Text = GlobalInfo.CompanyName.ToUpper();
                            var dateFrom = (TextObject)importGate1.Section1.ReportObjects["dateFrom"];
                            dateFrom.Text = _from.ToString("dd/MM/yyyy");

                            var dateTo = (TextObject)importGate1.Section1.ReportObjects["dateTo"];
                            dateTo.Text = _to.ToString("dd/MM/yyyy");

                            StringBuilder buffer = new StringBuilder();
                            if (_branchId != "0")  //tim theo chi cuc hai quan
                            {
                                buffer.Append(" SELECT    * FROM ViewAllDeclarationTNTX ");
                                buffer.Append(" WHERE ");
                                buffer.Append(" DeclarationID > 1 ");
                                buffer.Append(" AND TypeOption = " + (short)Common.DeclerationOptionType.NKCK);
                                buffer.Append(" AND CreatedDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                buffer.Append("' AND CreatedDate <= '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");
                                buffer.Append(" AND  BranchId = '" + _branchId + "'");
                            }
                            else
                            {
                                buffer.Append(" SELECT    * FROM ViewAllDeclarationTNTX ");
                                buffer.Append(" WHERE ");
                                buffer.Append(" DeclarationID > 1 ");
                                buffer.Append(" AND TypeOption = " + (short)Common.DeclerationOptionType.NKCK);
                                buffer.Append(" AND CreatedDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                buffer.Append("' AND CreatedDate <= '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");
                            }

                            if(string.IsNullOrEmpty(_type)==false)
                            {
                                buffer.Append(" AND  Type = '" + _type + "'");
                            }

                            var adpater = new SqlDataAdapter(buffer.ToString(), connection);
                            var dt = new DataTable();
                            adpater.Fill(dt);
                            importGate1.SetDataSource(dt);
                            crystalReportViewer1.ReportSource = importGate1;
                        }
                        break;
                    case ReportType.TempImportedReExport:
                        {
                            // Superior Company
                            ((TextObject)tempImportReExport1.Section1.ReportObjects["SuperiorCompany"]).Text = GetUserConfig().ToUpper();
                            // Company
                            ((TextObject)tempImportReExport1.Section1.ReportObjects["CompanyName"]).Text = GlobalInfo.CompanyName.ToUpper();
                            var dateFrom = (TextObject)tempImportReExport1.Section1.ReportObjects["dateFrom"];
                            dateFrom.Text = _from.ToString("dd/MM/yyyy");

                            var dateTo = (TextObject)tempImportReExport1.Section1.ReportObjects["dateTo"];
                            dateTo.Text = _to.ToString("dd/MM/yyyy");

                            StringBuilder buffer = new StringBuilder();
                            if (_branchId != "0")  //tim theo chi cuc hai quan
                            {
                                buffer.Append(" SELECT    * FROM ViewAllDeclarationTNTX ");
                                buffer.Append(" WHERE ");
                                buffer.Append(" DeclarationID > 1 ");
                                buffer.Append(" AND TypeOption = " + (short)Common.DeclerationOptionType.TNTX);
                                buffer.Append(" AND CreatedDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                buffer.Append("' AND CreatedDate <= '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");
                                buffer.Append(" AND  BranchId = '" + _branchId + "'");
                            }
                            else
                            {
                                buffer.Append(" SELECT    * FROM ViewAllDeclarationTNTX ");
                                buffer.Append(" WHERE ");
                                buffer.Append(" DeclarationID > 1 ");
                                buffer.Append(" AND TypeOption = " + (short)Common.DeclerationOptionType.TNTX);
                                buffer.Append(" AND CreatedDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                buffer.Append("' AND CreatedDate <= '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");
                            }

                            if(string.IsNullOrEmpty(_type)==false)
                            {
                                buffer.Append(" AND  Type = '" + _type + "'");
                            }

                            var adpater = new SqlDataAdapter(buffer.ToString(), connection);
                            var dt = new DataTable();
                            adpater.Fill(dt);
                            tempImportReExport1.SetDataSource(dt);
                            crystalReportViewer1.ReportSource = tempImportReExport1;
                        }
                        break;
                    case ReportType.VehicleTransportGoods:
                        {
                            // Superior Company
                            ((TextObject)vehicleFreight1.Section1.ReportObjects["SuperiorCompany"]).Text = GetUserConfig().ToUpper();
                            // Company
                            ((TextObject)vehicleFreight1.Section1.ReportObjects["CompanyName"]).Text = GlobalInfo.CompanyName.ToUpper();
                            var dateFrom = (TextObject)vehicleFreight1.Section1.ReportObjects["dateFrom"];
                            dateFrom.Text = _from.ToString("dd/MM/yyyy");

                            var dateTo = (TextObject)vehicleFreight1.Section1.ReportObjects["dateTo"];
                            dateTo.Text = _to.ToString("dd/MM/yyyy");

                            StringBuilder buffer = new StringBuilder();
                            if (_branchId != "0")  //tim theo chi cuc hai quan
                            {
                                buffer.Append(" SELECT vehicleTypeId, GoodTypeName, COUNT(*) as CountVehicle, SUM (FeeAmount) as SumFeeAmount, Name FROM ViewVehicleFreight ");
                                buffer.Append(" WHERE ");
                                buffer.Append(" CreatedDate >= '" + _from.ToString("yyyy-MM-dd HH:mm") + "'");
                                buffer.Append(" AND CreatedDate <= '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");
                                buffer.Append(" AND  BranchId = '" + _branchId + "'");
                                if(string.IsNullOrEmpty(_type)==false)
                                {
                                    buffer.Append(" AND  Type = '" + _type + "'");
                                }
                                buffer.Append(" GROUP BY vehicleTypeId, GoodTypeName, Name");
                            }
                            else
                            {
                                buffer.Append(" SELECT vehicleTypeId, GoodTypeName, COUNT(*) as CountVehicle, SUM (FeeAmount) as SumFeeAmount, Name FROM ViewVehicleFreight ");
                                buffer.Append(" WHERE ");
                                buffer.Append(" CreatedDate >= '" + _from.ToString("yyyy-MM-dd HH:mm") + "'");
                                buffer.Append(" AND CreatedDate <= '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");
                                if(string.IsNullOrEmpty(_type)==false)
                                {
                                    buffer.Append(" AND  Type = '" + _type + "'");
                                }
                                buffer.Append(" GROUP BY vehicleTypeId, GoodTypeName, Name");
                            }

                            var adpater = new SqlDataAdapter(buffer.ToString(), connection);
                            var dt = new DataTable();
                            adpater.Fill(dt);
                            vehicleFreight1.SetDataSource(dt);
                            crystalReportViewer1.ReportSource = vehicleFreight1;
                            break;
                        }

                    case ReportType.ChinesseVehicle: // Type 10 Xe Trung Quoc
                        {
                            // Superior Company
                            ((TextObject)chinesseVehicleReport1.Section1.ReportObjects["SuperiorCompany"]).Text = GetUserConfig().ToUpper();
                            // Company
                            ((TextObject)chinesseVehicleReport1.Section1.ReportObjects["CompanyName"]).Text = GlobalInfo.CompanyName.ToUpper();
                            var createdimportAndHasItem = (TextObject)chinesseVehicleReport1.Section1.ReportObjects["CreatedBy"];
                            createdimportAndHasItem.Text = _userInfo.Name;

                            var dateFromimportAndHasItem = (TextObject)chinesseVehicleReport1.Section1.ReportObjects["dateFrom"];
                            dateFromimportAndHasItem.Text = _from.ToString("dd/MM/yyy HH:mm");

                            var dateToimportAndHasItem = (TextObject)chinesseVehicleReport1.Section1.ReportObjects["dateTo"];
                            dateToimportAndHasItem.Text = _to.ToString("dd/MM/yyy HH:mm");

                            // Header 
                            var lblHeader = (TextObject)xuatCanhXeKhong.Section1.ReportObjects["lblHeader"];
                            lblHeader.Text = "SỔ THEO DÕI PHƯƠNG TIỆN XE TRUNG QUỐC";

                            var sql = new StringBuilder();
                            //sql.Append("SELECT * FROM ViewAllVehicleHasGood ");
                            //sql.Append(" WHERE ");
                            //sql.Append(" (DeclarationID > 0 OR DeclarationID = 1) "); // LAY NHUNG PHUONG TIEN THUOC TO KHAI 1, CO NGHIA LA DANG O BAI                        
                            //sql.Append(" AND HasGoodsImported = 1 ");
                            //sql.Append(" AND DeclarationType = 1 ");
                            //sql.Append(" AND IsImport = 1 ");
                            //sql.Append(" AND  ImportDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                            //sql.Append("' AND ImportDate < = '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");
                            if (_branchId != "0")  //tim theo chi cuc hai quan
                            {
                                sql.Append("select * from ViewAllVehicleHasGood as table1");
                                sql.Append(" WHERE  IsChineseVehicle=1");
                                sql.Append(" AND  table1.ImportDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                sql.Append("' AND table1.ImportDate < = '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");
                                sql.Append(" AND  table1.BranchId = '" + _branchId + "'");
                            }
                            else
                            {
                                sql.Append("select * from ViewAllVehicleHasGood as table1");
                                sql.Append(" WHERE  IsChineseVehicle=1");
                                sql.Append(" AND  table1.ImportDate >= '" + _from.ToString("yyyy-MM-dd HH:mm"));
                                sql.Append("' AND table1.ImportDate < = '" + _to.ToString("yyyy-MM-dd HH:mm") + "'");
                            }

                            if(string.IsNullOrEmpty(_type)==false)
                            {
                                sql.Append(" AND  table1.Type = '" + _type + "'");
                            }

                            var adpater = new SqlDataAdapter(sql.ToString(), connection);
                            var dt = new DataTable();
                            adpater.Fill(dt);
                            chinesseVehicleReport1.SetDataSource(dt);
                            crystalReportViewer1.ReportSource = chinesseVehicleReport1;
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
