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
using log4net;
using ECustoms.Utilities;

namespace ECustoms
{
    public partial class frmDeclarationManagement : Form
    {
        private static log4net.ILog logger = LogManager.GetLogger("Ecustoms.frmDeclarationManagement");
        UserInfo _userInfo;
        bool _isSecondHandover;
        bool _isManagementMode;
        List<ViewDeclarationManagement> listDeclaration = new List<ViewDeclarationManagement>();
        public frmDeclarationManagement()
        {
            InitializeComponent();
        }
        public void Init() {
            List<tblCustom> listCustoms = CustomsFacory.getAll();
            cbxCustomsCode.DataSource = listCustoms;
            cbxCustomsCode.DisplayMember = "CustomsCode";
            cbxCustomsCode.ValueMember = "CustomsCode";
            cbxCustomsCode.SelectedIndex = -1;
            btnConfirmHandover.Visible = !_isManagementMode;
            fillData();
        }

        public void fillData()
        {
            if (!_isSecondHandover && !_isManagementMode)
            {
                listDeclaration = DeclarationManagementFactory.GetDeclarationNew();
                this.Text = "Ban giao ho so tu nhan vien len phuc tap" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
                btnConfirmHandover.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_BAN_GIAO_HO_SO_TO_KHAI_LEN_PHUC_TAP);

            }
            else if (_isSecondHandover && !_isManagementMode)
            {
                listDeclaration = DeclarationManagementFactory.GetDeclarationHandover();
                this.Text = "Ban giao ho so tu phuc tap sang luu tru" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
                btnConfirmHandover.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_BAN_GIAO_HO_SO_TO_KHAI_SANG_LUU_TRU);

            }
            else
            {
                listDeclaration = DeclarationManagementFactory.GetDeclarationSaved();
                this.Text = "Muon tra ho so" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            }
            grvDeclarationList.AutoGenerateColumns = false;
            grvDeclarationList.DataSource = listDeclaration;
        }

        public frmDeclarationManagement(UserInfo userInfo,bool isSecondHandover = false, bool isManagementMode = false)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _isSecondHandover = isSecondHandover;
            _isManagementMode = isManagementMode;
            Init();
        }

        private void btConfirmReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grvDeclarationList.SelectedRows.Count > 0)
                {
                    int selectedIndex = grvDeclarationList.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    long declarationID;
                    if (!Int64.TryParse(grvDeclarationList[0, selectedIndex].Value.ToString(), out declarationID))
                    {
                        MessageBox.Show("Tờ khai không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    tblDeclaration declaration = DeclarationFactory.GetByID(declarationID);
                    if (declaration == null)
                    {
                        MessageBox.Show("Tờ khai không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    frmPageNumber frm = new frmPageNumber(this,_userInfo, declarationID, _isSecondHandover);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn một bản ghi để cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            } 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void search()
        {
            string number = txtNumber.Text.Trim();
            string type = txtType.Text.Trim();
            string registeredYear = txtRegisteredYear.Text.Trim();
            string customsCode = cbxCustomsCode.Text.Trim();

            DateTime DateReturnFrom = new DateTime(dateTimePickerReturn.Value.Year, dateTimePickerReturn.Value.Month, dateTimePickerReturn.Value.Day, 0, 0, 0);
            DateTime DateReturnTo = new DateTime(dateTimePickerReturn.Value.Year, dateTimePickerReturn.Value.Month, dateTimePickerReturn.Value.Day, 23, 59, 59);

            DateTime DateHandoverFrom = new DateTime(dateTimePickerHandover.Value.Year, dateTimePickerHandover.Value.Month, dateTimePickerHandover.Value.Day, 0, 0, 0);
            DateTime DateHandoverTo = new DateTime(dateTimePickerHandover.Value.Year, dateTimePickerHandover.Value.Month, dateTimePickerHandover.Value.Day, 23, 59, 59);

            string companyName = txtCompanyName.Text.Trim();

            
            if (!_isSecondHandover && !_isManagementMode)
            {
                listDeclaration = DeclarationManagementFactory.GetDeclarationNew();
            }
            else if (_isSecondHandover && !_isManagementMode)
            {
                listDeclaration = DeclarationManagementFactory.GetDeclarationHandover();
            }
            else
            {
                listDeclaration = DeclarationManagementFactory.GetDeclarationSaved();
            }

            if (string.IsNullOrEmpty(number) == false)
            {
                listDeclaration = listDeclaration.Where(g => g.Number.ToString().Contains(number)).ToList();
            }

            if (string.IsNullOrEmpty(type) == false)
            {
                listDeclaration = listDeclaration.Where(g => g.Type!=null && g.Type.ToString().Contains(type)).ToList();
            }

            if (string.IsNullOrEmpty(registeredYear) == false)
            {
                listDeclaration = listDeclaration.Where(g => g.CreatedDate.GetValueOrDefault().Year.ToString() == registeredYear).ToList();
            }

            if (string.IsNullOrEmpty(customsCode) == false)
            {
                listDeclaration = listDeclaration.Where(g => g.CustomsCode!=null && g.CustomsCode.ToString().Contains(customsCode)).ToList();
            }
            if (dateTimePickerReturn.Checked == true)
            {
                listDeclaration = listDeclaration.Where(g => g.DateReturn != null && g.DateReturn >= DateReturnFrom && g.DateReturn <= DateReturnTo).ToList();
            }

            if (dateTimePickerHandover.Checked == true)
            {
                listDeclaration = listDeclaration.Where(g => g.DateHandover != null && g.DateHandover >= DateHandoverFrom && g.DateHandover <= DateHandoverTo).ToList();
            }

            if (string.IsNullOrEmpty(companyName) == false)
            {
                listDeclaration = listDeclaration.Where(g => g.CompanyName!=null && g.CompanyName.ToString().Contains(companyName)).ToList();
            }

            grvDeclarationList.AutoGenerateColumns = false;
            grvDeclarationList.DataSource = listDeclaration;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {

            search();

        //    if (listDeclaration.Count > 0)
        //    {
        //        if (!String.IsNullOrEmpty(txtNumber.Text.Trim()))
        //        {
        //            int declarationNumber;
        //            if (Int32.TryParse(txtNumber.Text.Trim(), out declarationNumber))
        //            {
        //                listDeclaration = listDeclaration.Where(g => g.Number == declarationNumber).ToList();
        //                var test = listDeclaration.Where(g => g.Number == declarationNumber).ToList();
        //            }
        //        }
        //        if (!String.IsNullOrEmpty(txtType.Text.Trim()))
        //        {
        //            listDeclaration = listDeclaration.Where(g => g.Type == txtType.Text.Trim()).ToList();
        //        }
        //        if (!String.IsNullOrEmpty(txtRegisteredYear.Text.Trim()))
        //        {
        //            int registeredYear;
        //            if (Int32.TryParse(txtRegisteredYear.Text.Trim(), out registeredYear))
        //            {
        //                listDeclaration = listDeclaration.Where(g => g.RegisterDate.Value.Year == registeredYear).ToList();
        //            }
        //        }
        //        if (cbxCustomsCode.SelectedIndex != -1)
        //        {
        //            listDeclaration = listDeclaration.Where(g => g.CustomsCode == cbxCustomsCode.SelectedValue).ToList();
        //        }
        //        //if (dateTimePickerReturn.Value)
        //        //{
        //        //    listDeclaration = listDeclaration.Where(g => g.DateReturn == dateTimePickerReturn.Value).ToList();
        //        //}
        //        if (!String.IsNullOrEmpty(txtCompanyName.Text.Trim()))
        //        {
        //            listDeclaration = listDeclaration.Where(g => g.CompanyName == txtCompanyName.Text.Trim()).ToList();
        //        }

        //    }
        //    grvDeclarationList.DataSource = listDeclaration;
        }

        private void frmDeclarationManagement_Load(object sender, EventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {

        }
    }
}
