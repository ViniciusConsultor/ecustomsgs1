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
    public partial class FrmAddCompany : SubFormBase
    {
        private static ILog logger = LogManager.GetLogger("Ecustoms.FrmAddCompany");

        private int _mode;  //_mode=0 : add new; _mode=1 : edit
        private string _companyCode;
        private UserInfo _userInfo;
        private FrmListCompany _frmListCompany;

        public FrmAddCompany()
        {
            InitializeComponent();
        }

        public FrmAddCompany(String companyCode, int mode, UserInfo userInfo, FrmListCompany frmListCompany)
        {
            _userInfo = userInfo;
            _companyCode = companyCode;
            _mode = mode;
            _frmListCompany = frmListCompany;

            InitializeComponent();
        }
        private void FrmAddCompany_Load(object sender, EventArgs e)
        {
            if (_mode == 0) //add new
            {
                this.Text = "Them moi doanh nghiep" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
            }

            if (_mode == 1) //update
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;

                this.Text = "Cap nhat doanh nghiep" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
                tblCompany company = CompanyFactory.FindByCode(_companyCode);
                if (company == null)
                {
                    MessageBox.Show("Doanh nghiệp này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                txtCompanyCode.ReadOnly = true;
                txtCompanyCode.Text = company.CompanyCode;
                txtCompanyName.Text = company.CompanyName;
                txtDescription.Text = company.Description;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_mode == 0)
            {
                //validate
                if (validate())
                {
                    tblCompany company = new tblCompany();
                    company.CompanyCode = txtCompanyCode.Text.Trim();
                    company.CompanyName = txtCompanyName.Text.Trim();
                    company.Description = txtDescription.Text.Trim();
                    company.CreatedBy = _userInfo.UserID;
                    company.ModifiedBy = _userInfo.UserID;
                    if (CompanyFactory.Insert(company) > 0)
                    {
                        try
                        {
                            _frmListCompany.init();
                        }
                        catch (Exception ex)
                        {
                            //do nothing
                        }
                        MessageBox.Show("Thêm mới doanh nghiệp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới doanh nghiệp không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private bool validate()
        {
            bool valid = true;
            if (_mode == 0)//add new
            {
                if (String.IsNullOrEmpty(txtCompanyCode.Text.Trim()))
                {
                    valid = false;
                    MessageBox.Show("Mã doanh nghiệp không được để trống", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCompanyCode.Focus();
                }
                else if (null != CompanyFactory.FindByCode(txtCompanyCode.Text.Trim()))
                {
                    valid = false;
                    MessageBox.Show("Mã doanh nghiệp này đã tồn tại, hãy thử với mã khác", "Dữ liệu không hợp lệ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtCompanyCode.Focus();
                }

                if (String.IsNullOrEmpty(txtCompanyName.Text.Trim()))
                {
                    valid = false;
                    MessageBox.Show("Tên doanh nghiệp không được để trống", "Dữ liệu không hợp lệ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtCompanyName.Focus();
                }
            }
            if (_mode == 1) //update
            {
                tblCompany company = CompanyFactory.FindByCode(_companyCode);
                if (company == null)
                {
                    valid = false;
                    MessageBox.Show("Doanh nghiệp này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (String.IsNullOrEmpty(txtCompanyName.Text.Trim()))
                {
                    valid = false;
                    MessageBox.Show("Tên doanh nghiệp không được để trống", "Dữ liệu không hợp lệ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtCompanyName.Focus();
                }
            }
            return valid;
        }
        private void reset()
        {
            txtDescription.Text = "";
            txtCompanyCode.Text = "";
            txtCompanyName.Text = "";
        }

        private void txtCompanyCode_Leave(object sender, EventArgs e)
        {
            txtCompanyCode.Text = Utilities.StringUtil.RemoveAllNonAlphanumericString(txtCompanyCode.Text).ToUpper();
        }

        private void txtCompanyCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Enter key
            {
                txtCompanyCode.Text = Utilities.StringUtil.RemoveAllNonAlphanumericString(txtCompanyCode.Text).ToUpper();
                txtCompanyName.Focus();
            }
        }

        private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Enter key
            {
                txtDescription.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_mode == 1)
            {
                if (validate())
                {
                    tblCompany company = new tblCompany();
                    company.CompanyCode = txtCompanyCode.Text;
                    company.CompanyName = txtCompanyName.Text.Trim();
                    company.Description = txtDescription.Text.Trim();
                    company.ModifiedBy = _userInfo.UserID;
                    if (CompanyFactory.Update(company) > 0)
                    {
                        try
                        {
                            _frmListCompany.search();
                        }
                        catch (Exception ex)
                        {
                            //do nothing
                        }
                        MessageBox.Show("Cập doanh nghiệp hình thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Cập nhật doanh nghiệp không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }


    }
}
