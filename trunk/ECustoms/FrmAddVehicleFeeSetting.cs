using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.Utilities;
using ECustoms.BOL;
using ECustoms.DAL;
using log4net;


namespace ECustoms
{
    public partial class FrmAddVehicleFeeSetting : SubFormBase
    {
        private UserInfo _userInfo;
        private int _type;
        private tblVehicleFeeSetting _vehicleFee;
        private FrmVehicleFeeSetting _mainForm;
        public FrmAddVehicleFeeSetting()
        {
            InitializeComponent();
        }

        public FrmAddVehicleFeeSetting(UserInfo userInfo, int type, FrmVehicleFeeSetting mainForm)
        {
            //type =0: them moi
            //type=1: cap nhat
            InitializeComponent();
            _userInfo = userInfo;
            _type = type;
            _mainForm = mainForm;

        }

        public FrmAddVehicleFeeSetting(UserInfo userInfo, int type, FrmVehicleFeeSetting mainForm, tblVehicleFeeSetting vehicleFee)
        {
            //type =0: them moi
            //type=1: cap nhat
            InitializeComponent();
            _userInfo = userInfo;
            _type = type;
            _mainForm = mainForm;
            _vehicleFee = vehicleFee;

        }
        private void FrmAddVehicleFeeSetting_Load(object sender, EventArgs e)
        {
            this.Location = new Point((_mainForm.Width - this.Width) / 2, (_mainForm.Height - this.Height) / 2);
            //init vehicleType
            var listVehicleType = VehicleTypeFactory.getAllVehicleType();
            foreach (tblVehicleType vehicleType in listVehicleType)
            {
                dataSet2.tblVehicleType.Rows.Add(vehicleType.VehicleTypeID, vehicleType.Name);
            }
            cbVehicleType.DataSource = dataSet2.tblVehicleType;

            //init goodType
            var listGoodType = GoodTypeFactory.SelectAll();
            foreach (tblGoodsType goodType in listGoodType)
            {
                dataSet2.tblGoodsType.Rows.Add(goodType.TypeId, goodType.TypeName);
            }
            cbGoodType.DataSource = dataSet2.tblGoodsType;


            if (_type == 0) //add new
            {
                this.Text = "Thêm mới cấu hình tính phí phương tiện " + ConstantInfo.MESSAGE_TITLE;
                btnUpdate.Enabled = false;
                btnAdd.Enabled = true;
            }
            else if (_type == 1) //edit
            {
                this.Text = "Cập nhật cấu hình tính phí phương tiện " + ConstantInfo.MESSAGE_TITLE;
                btnUpdate.Enabled = true;
                btnAdd.Enabled = false;
                cbGoodType.Enabled = false;
                cbVehicleType.Enabled = false;

                cbGoodType.SelectedValue = _vehicleFee.GoodsTypeId;
                cbVehicleType.SelectedValue = _vehicleFee.VehicleTypeId;
                txtFee.Text = _vehicleFee.Fee / 1000 + "";
                txtDescription.Text = _vehicleFee.Description;
                
            }

        }
        
        private void txtFee_Leave(object sender, EventArgs e)
        {
            try
            {
                txtFee.Text = long.Parse(txtFee.Text.Trim()).ToString();
            }
            catch (Exception ex)
            {
                txtFee.Text = "";
            }
        }
        private bool validate()
        {
            bool validate = true;
            if(cbVehicleType.SelectedValue==null)
            {
                MessageBox.Show("Thiếu dữ liệu về loại trọng tải","Lỗi dữ liệu",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                cbVehicleType.Focus(); 
                return false; 
            }

            if(cbGoodType.SelectedValue==null)
            {
                MessageBox.Show("Thiếu dữ liệu về loại hàng hóa","Lỗi dữ liệu",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                cbGoodType.Focus(); 
                return false; 
            }

            int vehicleTypeId = int.Parse(cbVehicleType.SelectedValue.ToString());
            int goodsTypeId = int.Parse(cbGoodType.SelectedValue.ToString());

            tblVehicleFeeSetting vehicleFee = VehicleFeeSettingFactory.find(vehicleTypeId,goodsTypeId);

            if(_type ==0) //if Add new mode
            {
                if(vehicleFee!=null)
                {
                    MessageBox.Show("Biểu phí này đã tồn tại rồi, không thêm mới được","Lỗi dữ liệu",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    cbVehicleType.Focus(); 
                    return false; 
                }
            }

            if(_type ==1) //if  update mode
            {
                if(vehicleFee==null)
                {
                     MessageBox.Show("Biểu phí này không còn tồn tại rồi, không cập nhật được","Lỗi dữ liệu",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                     return false; 
                }
            }

            try
            {
                long.Parse(txtFee.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Phí phải là kiểu số", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               txtFee.Focus();
               return false; 
            }

            return validate;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                tblVehicleFeeSetting vehicleFee = new tblVehicleFeeSetting();
                vehicleFee.VehicleTypeId = int.Parse(cbVehicleType.SelectedValue.ToString());
                vehicleFee.GoodsTypeId = int.Parse(cbGoodType.SelectedValue.ToString());
                vehicleFee.Fee = long.Parse(txtFee.Text.Trim()) * 1000;
                vehicleFee.Description = txtDescription.Text.Trim();
                vehicleFee.CreatedUser = _userInfo.UserID;
                vehicleFee.UpdatedUser = _userInfo.UserID;

                if (VehicleFeeSettingFactory.Insert(vehicleFee) > 0)
                {
                    MessageBox.Show("Thêm mới biểu phí thành công", "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _mainForm.bindListVehicleFee();
                    resetForm();

                }
            }
        }
        private void resetForm()
        {
            cbGoodType.SelectedIndex = 0;
            cbVehicleType.SelectedIndex = 0;
            txtFee.Text = "";
            txtDescription.Text = "";
            cbVehicleType.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (_type == 0) //add new
            {
                resetForm();
            }
            else
            {
                cbGoodType.SelectedValue = _vehicleFee.GoodsTypeId;
                cbVehicleType.SelectedValue = _vehicleFee.VehicleTypeId;
                txtFee.Text = _vehicleFee.Fee / 1000 + "";
                txtDescription.Text = _vehicleFee.Description;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                _vehicleFee.UpdatedUser = _userInfo.UserID;
                _vehicleFee.Fee = long.Parse(txtFee.Text.Trim()) * 1000;
                _vehicleFee.Description = txtDescription.Text.Trim();

                if (VehicleFeeSettingFactory.Update(_vehicleFee) > 0)
                {
                    MessageBox.Show("Cập nhật biểu phí thành công", "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _mainForm.bindListVehicleFee();
                    this.Close();
                    _mainForm.Focus();

                }
            }
        }

    }
}
