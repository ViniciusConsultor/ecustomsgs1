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
    public partial class FrmAddGate : SubFormBase
    {
        private int _mode;  //_mode=0 : add new; _mode=1 : edit
        private string _gateCode;
        private UserInfo _userInfo;
        private FrmListGate _frmListGate;

        public FrmAddGate()
        {
            InitializeComponent();
        }

        public FrmAddGate(String gateCode, int mode, UserInfo userInfo, FrmListGate frmListGate)
        {
            _userInfo = userInfo;
            _gateCode = gateCode;
            _mode = mode;
            _frmListGate = frmListGate;

            InitializeComponent();
        }

        private void FrmAddGate_Load(object sender, EventArgs e)
        {
            if (_mode == 0) //add new
            {
                this.Text = "Them moi cua khau" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
            }

            if (_mode == 1) //update
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;

                this.Text = "Cap nhat cua khau" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
                tblGate gate = GateFactory.FindByCode(_gateCode);
                if (gate == null)
                {
                    MessageBox.Show("Cửa khẩu này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                txtGateCode.ReadOnly = true;
                txtGateCode.Text = gate.GateCode;
                txtGateName.Text = gate.GateName;
                txtDescription.Text = gate.Description;
            }
        }

        private bool validate()
        {
            bool valid = true;
            if (_mode == 0)//add new
            {
                if (String.IsNullOrEmpty(txtGateCode.Text.Trim()))
                {
                    valid = false;
                    MessageBox.Show("Mã cửa khẩu không được để trống", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGateCode.Focus();
                }
                else if (null != GateFactory.FindByCode(txtGateCode.Text.Trim()))
                {
                    valid = false;
                    MessageBox.Show("Mã cửa khẩu này đã tồn tại, hãy thử với mã khác", "Dữ liệu không hợp lệ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtGateCode.Focus();
                }

                if (String.IsNullOrEmpty(txtGateName.Text.Trim()))
                {
                    valid = false;
                    MessageBox.Show("Tên cửa khẩu không được để trống", "Dữ liệu không hợp lệ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtGateName.Focus();
                }
            }
            if (_mode == 1) //update
            {
                tblGate gate = GateFactory.FindByCode(_gateCode);
                if (gate == null)
                {
                    valid = false;
                    MessageBox.Show("Cửa khẩu này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (String.IsNullOrEmpty(txtGateName.Text.Trim()))
                {
                    valid = false;
                    MessageBox.Show("Tên cửa khẩu không được để trống", "Dữ liệu không hợp lệ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtGateName.Focus();
                }
            }
            return valid;
        }
        private void reset()
        {
            txtDescription.Text = "";
            txtGateCode.Text = "";
            txtGateName.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_mode == 0)
            {
                //validate
                if (validate())
                {
                    tblGate gate = new tblGate();
                    gate.GateCode = txtGateCode.Text.Trim();
                    gate.GateName = txtGateName.Text.Trim();
                    gate.Description = txtDescription.Text.Trim();
                    gate.CreatedBy = _userInfo.UserID;
                    gate.ModifiedBy = _userInfo.UserID;
                    if (GateFactory.Insert(gate) > 0)
                    {
                        try
                        {
                            _frmListGate.init();
                        }
                        catch (Exception ex)
                        {
                            //do nothing
                        }
                        MessageBox.Show("Thêm mới cửa khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới cửa khẩu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_mode == 1)
            {
                if (validate())
                {
                    tblGate gate = new tblGate();
                    gate.GateCode = txtGateCode.Text.Trim();
                    gate.GateName = txtGateName.Text.Trim();
                    gate.Description = txtDescription.Text.Trim();
                    gate.ModifiedBy = _userInfo.UserID;
                    if (GateFactory.Update(gate) > 0)
                    {
                        try
                        {
                            _frmListGate.search();
                        }
                        catch (Exception ex)
                        {
                            //do nothing
                        }
                        MessageBox.Show("Cập nhật cửa khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Cập nhật cửa khẩu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtGateCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Enter key
            {
                txtGateName.Focus();
            }
        }

        private void txtGateName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Enter key
            {
                txtDescription.Focus();
            }
        }
    }
}
