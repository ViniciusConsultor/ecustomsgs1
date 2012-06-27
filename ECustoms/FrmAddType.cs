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
    public partial class FrmAddType : Form
    {
        private int _mode;  //_mode=0 : add new; _mode=1 : edit
        private string _typeCode;
        private UserInfo _userInfo;
        private FrmListType _frmListType;
        public FrmAddType()
        {
            InitializeComponent();
        }

        public FrmAddType(String typeCode, int mode, UserInfo userInfo, FrmListType frmListType)
        {
            _userInfo = userInfo;
            _typeCode = typeCode;
            _mode = mode;
            _frmListType = frmListType;

            InitializeComponent();
        }

        private void FrmAddType_Load(object sender, EventArgs e)
        {
            if (_mode == 0) //add new
            {
                this.Text = "Them moi loai hinh" + ConstantInfo.MESSAGE_TITLE;
            }

            if (_mode == 0) //update
            {
                this.Text = "Cap nhat loai hinh" + ConstantInfo.MESSAGE_TITLE;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_mode == 0)
            {
                //validate
                if (validate())
                {
                    tblType type = new tblType();
                    type.TypeCode = txtTypeCode.Text;
                    type.TypeName = txtTypeName.Text.Trim();
                    type.Description = txtDescription.Text.Trim();
                    type.CreatedBy = _userInfo.UserID;
                    type.ModifiedBy = _userInfo.UserID;
                    if (TypeFactory.Insert(type) > 0)
                    {
                        try
                        {
                            _frmListType.init();
                        }
                        catch (Exception ex)
                        {
                            //do nothing
                        }
                        MessageBox.Show("Thêm mới loại hình thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới loại hình không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            

        }
        private bool validate()
        {
            bool valid = true;
            if (_mode == 0)//add new
            {
                if(String.IsNullOrEmpty(txtTypeCode.Text.Trim()))
                {
                    valid = false;
                    MessageBox.Show("Mã loại hình không được để trống", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTypeCode.Focus();
                }
                else if (null != TypeFactory.FindByCode(txtTypeCode.Text.Trim()))
                {
                    valid = false;
                    MessageBox.Show("Mã loại hình này đã tồn tại, hãy thử với mã khác", "Dữ liệu không hợp lệ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtTypeCode.Focus();
                }

                if (String.IsNullOrEmpty(txtTypeName.Text.Trim()))
                {
                    valid = false;
                    MessageBox.Show("Tên loại hình không được để trống", "Dữ liệu không hợp lệ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtTypeCode.Focus();
                }
            }
            if (_mode == 1) //update
            {
                
            }
            return valid;
        }
        private void reset()
        {
            txtDescription.Text = "";
            txtTypeCode.Text = "";
            txtTypeName.Text = "";
        }

        private void txtTypeCode_Leave(object sender, EventArgs e)
        {
            txtTypeCode.Text = Utilities.StringUtil.RemoveAllNonAlphanumericString(txtTypeCode.Text).ToUpper();
        }

        private void txtTypeCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Enter key
            {
                txtTypeCode.Text = Utilities.StringUtil.RemoveAllNonAlphanumericString(txtTypeCode.Text).ToUpper();
                txtTypeName.Focus();
            }
        }

        private void txtTypeName_KeyDown(object sender, KeyEventArgs e)
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
    }
}
