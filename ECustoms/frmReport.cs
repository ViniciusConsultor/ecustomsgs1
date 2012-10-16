using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ECustoms.Utilities;
using ECustoms.Utilities.Enums;
using log4net;
using System.Collections.Generic;
using ECustoms.BOL;
using ECustoms.DAL;

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

            dataSet2.tblReportType.Rows.Add(1, "Phương tiện xuất cảnh xe không");
            dataSet2.tblReportType.Rows.Add(2, "Phương tiện nhập cảnh xe không");
            dataSet2.tblReportType.Rows.Add(3, "Phương tiện chở hàng xuất khẩu");
            dataSet2.tblReportType.Rows.Add(4, "Phương tiện chở hàng nhập khẩu");
            dataSet2.tblReportType.Rows.Add(5, "Phương tiện hoàn thành thủ tục Hải quan vào nội địa");

            if (_userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_IN_BAO_CAO_TNTX))
            {
                dataSet2.tblReportType.Rows.Add(6, "Xuất khẩu chuyển cửa khẩu");
                dataSet2.tblReportType.Rows.Add(7, "Nhập khẩu chuyển cửa khẩu");
                dataSet2.tblReportType.Rows.Add(8, "Hàng tạm nhập tái xuất");
            }
            dataSet2.tblReportType.Rows.Add(9,"Số liệu phương tiện vận chuyển hàng hóa");
            dataSet2.tblReportType.Rows.Add(10, "Xe Trung Quốc");

            //// Put some stuff in the combo box
            //cbReportType.Items.Add("Phương tiện xuất cảnh xe không");
            //cbReportType.Items.Add("Phương tiện nhập cảnh xe không");
            //cbReportType.Items.Add("Phương tiện chở hàng xuất khẩu");
            //cbReportType.Items.Add("Phương tiện chở hàng nhập khẩu");
            //cbReportType.Items.Add("Phương tiện hoàn thành thủ tục Hải quan vào nội địa");

            //if (_userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_IN_BAO_CAO_TNTX))
            //{
            //    cbReportType.Items.Add("Xuất khẩu chuyển cửa khẩu");
            //    cbReportType.Items.Add("Nhập khẩu chuyển cửa khẩu");
            //    cbReportType.Items.Add("Hàng tạm nhập tái xuất");
            //}

            //cbReportType.Items.Add("Số liệu phương tiện vận chuyển hàng hóa");

            cbReportType.SelectedValue = _type;
        }

        /// <summary>
        /// Get DataTable to report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if ((cbReportType.SelectedValue + "").Equals(""))
            {
                MessageBox.Show(this,"Chưa chọn loại báo cáo","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var from = new DateTime(dtpExportFrom.Value.Year, dtpExportFrom.Value.Month, dtpExportFrom.Value.Day, 0, 0, 0);
                var to = new DateTime(dtpExportTo.Value.Year, dtpExportTo.Value.Month, dtpExportTo.Value.Day, 23, 59, 59);
                var reportType = GetReportType(Int32.Parse(cbReportType.SelectedValue + ""));
                var branchId = cbUnit.SelectedValue.ToString();
                var type = cbType.SelectedValue.ToString();
                var report = new FrmCrystalReport(reportType, from, to, _userInfo, branchId, type);
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
            var list = new List<tblCustom>();
            var custom = new tblCustom {CustomsCode = "0", CustomsName = "Tất cả"};
            list.Add(custom);

            //tao danh sach don vi hai quan
            var listtblCustoms = CustomsFacory.getAll();
            list.AddRange(listtblCustoms.Select(item => new tblCustom {CustomsCode = item.CustomsCode.Trim(), CustomsName = item.CustomsName}));

            cbUnit.DisplayMember = "CustomsName";
            cbUnit.ValueMember = "CustomsCode";
            cbUnit.DataSource = list;
            if (FDHelper.RgGetSizeOfUnit() == ConstantInfo.Branch)
            {
                String unitCode= FDHelper.RgCodeOfUnit();
                cbUnit.SelectedValue = unitCode;
                cbUnit.Enabled = false;
            }

            //tao danh sach loai hinh
            List<tblType> listType = new List<tblType>();
            tblType type = new tblType();
            type.TypeCode = "";
            type.TypeName = "Tất cả";
            listType.Add(type);
            foreach (tblType obj in TypeFactory.getAllType())
            {
                tblType typeObj = new tblType();
                typeObj.TypeName = obj.TypeCode + " - " + obj.TypeName;
                typeObj.TypeCode = obj.TypeCode;
                listType.Add(typeObj);
            }
            cbType.DisplayMember = "TypeName";
            cbType.ValueMember = "TypeCode";
            cbType.DataSource = listType;
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
                case 10:
                    return ReportType.ChinesseVehicle;
                    break;
            }
            return ReportType.ExportAndNoItem;
        }

        private void cbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTime.Text = (cbReportType.SelectedIndex > 4 && cbReportType.SelectedIndex < 8) ? "Thời gian nhập máy từ:" : "Thời gian từ:";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
