using System;
using System.Drawing;
using System.Windows.Forms;
using ECustoms.Utilities;
using ECustoms.DAL;
using ECustoms.BOL;
using log4net;

namespace ECustoms
{
    public partial class FrmAddCheck : Form
    {
        private static log4net.ILog logger = LogManager.GetLogger("Ecustoms.FrmAddCheck");
        private UserInfo _userInfo;
        private int _mode;
        private long _checkID; 
        public FrmAddCheck()
        {
            InitializeComponent();
        }
        
        public FrmAddCheck(UserInfo userInfo, int mode, long checkID)
        {

            InitializeComponent();
            _userInfo = userInfo;
            _mode = mode;
            _checkID = checkID;
        }

        private void FrmAddCheck_Load(object sender, EventArgs e)
        {            
            this.Location = new Point((this.Owner.Width - this.Width) / 2, (this.Owner.Height - this.Height) / 2);
            InitData();
        }

        private void InitData()
        {
            // Bind data to the combobox
            comboBoxDeclarationType.Items.Add("Loại hình xuất");
            comboBoxDeclarationType.Items.Add("Loại hình nhập");
            comboBoxDeclarationType.Items.Add("Cả xuất và nhập");
            comboBoxDeclarationType.SelectedIndex = 0;
            txtPlateNumber.Focus();
            if (_mode.Equals(0))
            {  // Add mode
                this.Text = "The moi de nghi kiem tra" + ConstantInfo.MESSAGE_TITLE;
                lblHeader.Text = "Thêm mới đề nghị kiểm tra";
                btnUpdate.Enabled = false;
                btnAdd.Enabled = true;
                txtCode.Text = CheckFactory.GetCheckCode();
            }
            else // Edit mode
            {
                this.Text = "Cap nhat thong tin de nghi kiem tra" + ConstantInfo.MESSAGE_TITLE;
                lblHeader.Text = "Cập nhật thông tin đề nghị kiểm tra";
                btnUpdate.Enabled = true;
                btnAdd.Enabled = false;
                var check = CheckFactory.SelectByID(_checkID);
                if (check == null)
                    return;
                txtCode.Text = check.CheckCode;
                txtPlateNumber.Text = check.PlateNumber;
                txtDeclarationNumber.Text = check.DeclarationNumber.ToString();
                txtCompanyCode.Text = check.CompanyCode;
                if (check.DeclarationType != null) comboBoxDeclarationType.SelectedIndex = check.DeclarationType.Value;
                if (check.CheckFrom != null) dtpFrom.Value = check.CheckFrom.Value;
                if (check.CheckTo != null) dtpTo.Value = check.CheckTo.Value;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate()) return;
                // Validate
                var check = new tblCheck();
                check.CheckCode = txtCode.Text;
                check.PlateNumber = StringUtil.RemoveAllNonAlphanumericString(txtPlateNumber.Text).ToUpper();
                if (txtDeclarationNumber.Text != "")
                {
                    check.DeclarationNumber = Convert.ToInt32(txtDeclarationNumber.Text);    
                }
                
                check.CompanyCode = txtCompanyCode.Text;                
                check.DeclarationType = comboBoxDeclarationType.SelectedIndex;
                var from = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, 0, 0, 0);
                var to = new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, 23, 59, 59);
                check.CheckFrom = from;
                check.CheckTo = to;
                check.CreatedBy = _userInfo.UserID;
                check.ModifiedBy = _userInfo.UserID;
                CheckFactory.Insert(check);

                // Bind data to the owner form
                ((FrmListCheck)this.Owner).InitData();
                this.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }
        
        private bool  Validate()
        {
            var to = new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, 23, 59, 59);

            if (to < dtpFrom.Value)
            {
                MessageBox.Show("Ngày hết hạn phải lớn hơn ngày bắt đầu");
                return false;
            }
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate()) return;
                // Get the current check
                var check = CheckFactory.SelectByID(_checkID);
                if (check == null) return;
                check.PlateNumber = StringUtil.RemoveAllNonAlphanumericString(txtPlateNumber.Text).ToUpper();
                check.CompanyCode = txtCompanyCode.Text;
                if (txtDeclarationNumber.Text != "")
                {
                    check.DeclarationNumber = Convert.ToInt32(txtDeclarationNumber.Text);
                }
                check.DeclarationType = comboBoxDeclarationType.SelectedIndex;
                check.CheckFrom = dtpFrom.Value;
                check.CheckTo = dtpTo.Value;
                check.ModifiedBy = _userInfo.UserID;
                // Update
                MessageBox.Show(CheckFactory.Update(check) > 0 ? "Cập nhật thành công" : "Cập nhật lỖi");
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
            // Bind data to the owner form
            ((FrmListCheck)this.Owner).InitData();
            this.Close();
        }

        private void txtPlateNumber_Leave(object sender, EventArgs e)
        {
          txtPlateNumber.Text = StringUtil.RemoveAllNonAlphanumericString(txtPlateNumber.Text).ToUpper();
        }
    }
}
