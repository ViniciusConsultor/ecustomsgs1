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
    public partial class FrmAddCustoms : SubFormBase
    {
        private int _mode;  //_mode=0 : add new; _mode=1 : edit
        private string _customsCode;
        private UserInfo _userInfo;
        private FrmListCustoms _frmListCustoms;

        public FrmAddCustoms()
        {
            InitializeComponent();
        }

        public FrmAddCustoms(String customsCode, int mode, UserInfo userInfo, FrmListCustoms frmListCustoms)
        {
            _userInfo = userInfo;
            _customsCode = customsCode;
            _mode = mode;
            _frmListCustoms = frmListCustoms;

            InitializeComponent();
        }

        private void FrmAddCustoms_Load(object sender, EventArgs e)
        {
            if (_mode == 0) //add new
            {
                this.Text = "Them moi don vi hai quan" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
            }

            if (_mode == 1) //update
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;

                this.Text = "Cap nhat don vi hai quan" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
                tblCustom customs = CustomsFacory.FindByCode(_customsCode);
                if (customs == null)
                {
                    MessageBox.Show("Đơn vị hải quan này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                txtCode.ReadOnly = true;
                txtCode.Text = customs.CustomsCode;
                txtName.Text = customs.CustomsName;
                txtDescription.Text = customs.Description;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_mode == 0)
            {
                //validate
                if (validate())
                {
                    tblCustom customs = new tblCustom();
                    customs.CustomsCode = txtCode.Text;
                    customs.CustomsName = txtName.Text.Trim();
                    customs.Description = txtDescription.Text.Trim();
                    customs.CreatedBy = _userInfo.UserID;
                    customs.ModifiedBy = _userInfo.UserID;
                    if (CustomsFacory.Insert(customs) > 0)
                    {
                        try
                        {
                            _frmListCustoms.init();
                        }
                        catch (Exception ex)
                        {
                            //do nothing
                        }
                        MessageBox.Show("Thêm mới đơn vị hải quan thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới đơn vị hải quan không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            
        }

        private bool validate()
        {
            bool valid = true;
            if (_mode == 0)//add new
            {
                if (String.IsNullOrEmpty(txtCode.Text.Trim()))
                {
                    valid = false;
                    MessageBox.Show("Mã đơn vị hải quan không được để trống", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Focus();
                }
                else if (null != CustomsFacory.FindByCode(txtCode.Text.Trim()))
                {
                    valid = false;
                    MessageBox.Show("Mã đơn vị hải quan này đã tồn tại, hãy thử với mã khác", "Dữ liệu không hợp lệ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtCode.Focus();
                }

                if (String.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    valid = false;
                    MessageBox.Show("Tên đơn vị hải quan không được để trống", "Dữ liệu không hợp lệ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtName.Focus();
                }
            }
            if (_mode == 1) //update
            {
                tblCustom customs = CustomsFacory.FindByCode(_customsCode);
                if (customs == null)
                {
                    valid = false;
                    MessageBox.Show("Đơn vị hải quan này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (String.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    valid = false;
                    MessageBox.Show("Tên đơn vị hải quan không được để trống", "Dữ liệu không hợp lệ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtName.Focus();
                }
            }
            return valid;
        }
        private void reset()
        {
            txtDescription.Text = "";
            txtCode.Text = "";
            txtName.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_mode == 1)
            {
                if (validate())
                {
                    tblCustom customs = new tblCustom();
                    customs.CustomsCode = txtCode.Text;
                    customs.CustomsName = txtName.Text.Trim();
                    customs.Description = txtDescription.Text.Trim();
                    customs.ModifiedBy = _userInfo.UserID;
                    if (CustomsFacory.Update(customs) > 0)
                    {
                        try
                        {
                            _frmListCustoms.search();
                        }
                        catch (Exception ex)
                        {
                            //do nothing
                        }
                        MessageBox.Show("Cập nhật đơn vị hải quan thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Cập nhật đơn vị hải quan không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            txtCode.Text = (txtCode.Text.Trim()).ToUpper();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Enter key
            {
                txtCode.Text = (txtCode.Text.Trim()).ToUpper();
                txtName.Focus();
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Enter key
            {
                txtDescription.Focus();
            }
        }
    }
}
