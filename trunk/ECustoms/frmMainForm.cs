using System;
using System.Windows.Forms;
using ECustoms.Utilities;

namespace ECustoms
{
    public partial class frmMainForm : Form
    {
        private readonly UserInfo _userInfo;
        public frmMainForm()
        {
            InitializeComponent();
        }

        public frmMainForm(UserInfo userInfo)
        {
            InitializeComponent();
            _userInfo = userInfo;
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Khai báo xuất nhập cảnh" + ConstantInfo.MESSAGE_TITLE;
            InitData();
            this.FormClosed += new FormClosedEventHandler(frmMainForm_FormClosed);
        }

        void frmMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Init data
        /// </summary>
        private void InitData()
        {
            toolstripLabelWelcome.Text = string.Format(ConstantInfo.MESSAGE_WELCOME, _userInfo.Name);

            //show/hide menu by user permission 
            menuitemUser.Visible = (_userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_MOI_NGUOI_DUNG) ||
              _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_NGUOI_DUNG) ||
              _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_NGUOI_DUNG));

            mnGroup.Visible = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_MOI_NHOM_NGUOI_DUNG) ||
                    _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_NHOM_NGUOI_DUNG) ||
                    _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_NHOM_NGUOI_DUNG);

            mnItemReport.Visible = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_IN_BAO_CAO) ||
                                   _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_IN_BAO_CAO_TNTX);

            mnReview.Visible = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_MOI_THONG_TIN_DE_NGHI_KIEM_TRA) ||
                     _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_THONG_TIN_DE_NGHI_KIEM_TRA) ||
                     _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_THONG_TIN_DE_NGHI_KIEM_TRA);

            mnReviewSummary.Visible = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_KET_QUA_KIEM_TRA) ||
                     _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_KET_QUA_KIEM_TRA);

            menuitemDeclaration.Visible = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_TO_KHAI) ||
                    _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_TO_KHAI) ||
                    _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_TO_KHAI);

            mnExport.Visible = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_TO_KHAI);

            mnImport.Visible = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_TO_KHAI);
            
            addNewVehiceToolStripMenuItem.Visible = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_MOI_PHUONG_TIEN);

            //khai bao xuat canh
            tsExport.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_TO_KHAI);
            //khai bao nhap canh
            tsImport.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_TO_KHAI);
            //tim kiem phuong tien
            //toolStripButtonSearch
            //danh sach to khai
            toolStripButtonListdeclarace.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_TO_KHAI) ||
                    _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_TO_KHAI) ||
                    _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_TO_KHAI);

            //Xuat khau chuyen cua khau
            xuấtKhẩuChuyểnCửaKhẩuToolStripMenuItem.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TRA_CUU_THONG_TIN_TNTX) ||
                    _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_HOI_BAO_TNTX) ||
                    _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_BO_XUNG_THONG_TIN_TNTX);

            //nhap khau chuyen cua khau
            nhậpKhẩuChuyểnCửaKhẩuToolStripMenuItem.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TRA_CUU_THONG_TIN_TNTX) ||
                    _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_HOI_BAO_TNTX) ||
                    _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_BO_XUNG_THONG_TIN_TNTX);

            //tam nhap tai xuat
            hàngTạmNhậpTáiXuấtToolStripMenuItem.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TRA_CUU_THONG_TIN_TNTX) ||
                    _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_HOI_BAO_TNTX) ||
                    _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_BO_XUNG_THONG_TIN_TNTX);

        }

        private void mnExport_Click(object sender, EventArgs e)
        {
            var frmDecleExport = new FrmDecleExport(_userInfo, 0, Common.DeclerationType.Export, this);
            frmDecleExport.Show(this);

        }

        private void vehicleSearch_Click(object sender, EventArgs e)
        {
          var filePath = Application.StartupPath + @"\conf\print_ticket.xml";
          PrintTicketSetting printSetting = ObjectToXml.GetTicketSetting(filePath);
          if (printSetting == null)
          {
            MessageBox.Show("Bạn chưa thiết lập cấu hình in ticket. Xin thiết lập cấu hình này trước");
            var frmPrintTicketSetting = new frmPrintTicketSetting(_userInfo);
            frmPrintTicketSetting.Show(this);
            return;
          }

            var vehicleSearch = new frmVehicleSearch(_userInfo, this);
            vehicleSearch.Show(this);
        }

        private void menuitemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuitemLogout_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();            
            frmLogin.Show();
            this.Hide();
        }

        private void menuitemDeclaration_Click(object sender, EventArgs e)
        {
            var frmDecleration = new frmDecleration(_userInfo, this);
            frmDecleration.Show(this);
        }

        private void menuitemUser_Click(object sender, EventArgs e)
        {
          var frmUser = new frmUser(_userInfo);
            frmUser.MdiParent = this;
            frmUser.Show();
        }

        private void tsExport_Click(object sender, EventArgs e)
        {
            var frmDecleExport = new FrmDecleExport(_userInfo, 0, Common.DeclerationType.Export, this);
            frmDecleExport.Show(this);
        }

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            var vehicleSearch = new frmVehicleSearch(_userInfo, this);
            vehicleSearch.Owner = this;
            vehicleSearch.Show();
        }

        private void toolStripButtonListdeclarace_Click(object sender, EventArgs e)
        {
            var frmDecleration = new frmDecleration(_userInfo, this);
            frmDecleration.Show(this);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmChangePassword = new frmChangePassword(_userInfo);            
            frmChangePassword.Show(this);

        }

        private void addNewVehiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmVehiceAdd = new frmVehicleAdd(_userInfo);
            frmVehiceAdd.MdiParent = this;
            frmVehiceAdd.Show();

        }

        private void mnItemReport_Click(object sender, EventArgs e)
        {
            var frmReport = new frmReport(this, _userInfo, 0);
            frmReport.Show(this);
        }

        //private void danhSáchTờKhaiToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var frmExport = new frmExport(_userInfo, 0, this);
        //    frmExport.MdiParent = this;
        //    frmExport.Show();
        //}

        private void mnImport_Click(object sender, EventArgs e)
        {
            var frmDecleExport = new FrmDecleExport(_userInfo, 0, Common.DeclerationType.Import, this);
            frmDecleExport.Show(this);
        }

        private void tsImport_Click(object sender, EventArgs e)
        {
            var frmDecleExport = new FrmDecleExport(_userInfo, 0, Common.DeclerationType.Import, this);
            frmDecleExport.Show(this);
        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var filePath = Application.StartupPath + @"\Docs\GS1_UserManual.pdf";
            Help.ShowHelp(this, filePath);
        }

        private void mnReview_Click(object sender, EventArgs e)
        {
            var frmCheck = new FrmListCheck(_userInfo);
            frmCheck.Show(this);
        }

        private void mnReviewSummary_Click(object sender, EventArgs e)
        {
            var frmCheckResult = new FrmCheckResult(_userInfo);
            frmCheckResult.Show(this);
        }

        private void mnGroup_Click(object sender, EventArgs e)
        {
            var frmListGroup = new FrmListGroup(_userInfo);
            frmListGroup.Show(this);
        }

        private void inTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
          var frmPrintTicketSetting = new frmPrintTicketSetting(_userInfo);
          frmPrintTicketSetting.Show(this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var frmCcp = new frmCompletedCustomsProcedures(_userInfo, this);
            frmCcp.Show(this);
        }

        private void xuấtKhẩuChuyểnCửaKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
          var frmDeclerationOptionInfo = new frmDeclerationOptionInfo(_userInfo, this, Common.DeclerationOptionType.XKCK);
          frmDeclerationOptionInfo.Show(this);
        }

        private void nhậpKhẩuChuyểnCửaKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
          var frmDeclerationOptionInfo = new frmDeclerationOptionInfo(_userInfo, this, Common.DeclerationOptionType.NKCK);
          frmDeclerationOptionInfo.Show(this);
        }

        private void hàngTạmNhậpTáiXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
          var frmDeclerationOptionInfo = new frmDeclerationOptionInfo(_userInfo, this, Common.DeclerationOptionType.TNTX);
          frmDeclerationOptionInfo.Show(this);
        }
    }
}
