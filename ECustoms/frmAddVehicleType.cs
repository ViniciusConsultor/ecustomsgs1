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
    public partial class frmAddVehicleType : Form
    {
        private static ILog logger = LogManager.GetLogger("ECustoms.frmAddVehicleType");
        private int _type = 0; //0:add new, 1: edit
        private int _vehicleTypeID;
        private UserInfo _userInfo;

        public frmAddVehicleType()
        {
            InitializeComponent();
        }

        public frmAddVehicleType(UserInfo userInfo)
        {
            InitializeComponent();
            _userInfo = userInfo;
        }

        public frmAddVehicleType(int type, int vehicleTypeID)
        {
            _type = type;
            _vehicleTypeID = vehicleTypeID;
            InitializeComponent();
        }

        private void frmAddVehicleType_Load(object sender, EventArgs e)
        {
            this.Text = "Them moi loai phuong tien" + ConstantInfo.MESSAGE_TITLE;
            init();
        }

        private void init()
        {
            if (_type == 0)
            {
                btnUpdate.Enabled = false;
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                var vehicleType = VehicleTypeFactory.FindById(_vehicleTypeID);
                txtName.Text = vehicleType.Name;
                txtCode.Text = vehicleType.Code;
                txtCapacity.Text = vehicleType.Capacity;
                txtDescription.Text = vehicleType.Description;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validateAddNew() == false)
            {
                return;
            }
            try
            {
                tblVehicleType vehicleType = new tblVehicleType();
                vehicleType.Name = txtName.Text.Trim();
                vehicleType.Code = txtCode.Text.Trim();
                vehicleType.Capacity = txtCapacity.Text.Trim();
                vehicleType.Description = txtDescription.Text.Trim();
                vehicleType.CreatedUser = _userInfo.UserID;
                vehicleType.UpdatedUser = _userInfo.UserID;

                int result = VehicleTypeFactory.Insert(vehicleType);
                if (result == 0)
                {
                    MessageBox.Show("Thêm mới thành công");
                    txtCapacity.Text = "";
                    txtCode.Text = "";
                    txtDescription.Text = "";
                    txtName.Text = "";
                    frmMainForm mainForm = (frmMainForm)this.MdiParent;
                    Form[] listForm = mainForm.MdiChildren;
                    foreach (Form form in listForm)
                    {
                        if (form.GetType() == new frmListVehicleType().GetType())
                        {
                            ((frmListVehicleType)form).init();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ. Thêm mới không thành công.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validateUpdate() == false)
            {
                return;
            }
            try
            {
                var vehicleType = VehicleTypeFactory.FindById(_vehicleTypeID);
                vehicleType.Name = txtName.Text.Trim();
                vehicleType.Code = txtCode.Text.Trim();
                vehicleType.Capacity = txtCapacity.Text.Trim();
                vehicleType.Description = txtDescription.Text.Trim();
                int result = VehicleTypeFactory.Update(vehicleType);
                if (result == 0)
                {
                    MessageBox.Show("Cập nhập thành công");
                    txtCapacity.Text = "";
                    txtCode.Text = "";
                    txtDescription.Text = "";
                    txtName.Text = "";
                    frmMainForm mainForm = (frmMainForm)this.MdiParent;
                    Form[] listForm = mainForm.MdiChildren;
                    foreach (Form form in listForm)
                    {
                        if (form.GetType() == new frmListVehicleType().GetType())
                        {
                            ((frmListVehicleType)form).init();
                        }
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ. Cập nhập không thành công.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }


        private bool validateAddNew()
        {
            var check = true;
            if (txtCode.Text.Trim().Length == 0)
            {
                check = false;
                txtCode.Focus();
                MessageBox.Show("Chưa nhập mã loại phương tiện", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return check;
            }

            //kiem tra trung la ma loai phuong tien
            var vehicleType = VehicleTypeFactory.FindByCode(txtCode.Text.Trim());
            if (vehicleType != null)
            {
                check = false;
                txtCode.Focus();
                MessageBox.Show("Mã loại phương tiện đã tồn tại rồi, hãy thử lại với mã khác", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return check;
            }

            if (txtName.Text.Trim().Length == 0)
            {
                check = false;
                txtName.Focus();
                MessageBox.Show("Chưa nhập tên loại phương tiện", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return check;
            }

            // kiem tra trung lap ten loai phuong tien
            var vehicleTypeObj = VehicleTypeFactory.findByName(txtName.Text.Trim());
            if (vehicleTypeObj != null)
            {
                check = false;
                txtName.Focus();
                MessageBox.Show("Tên loại phương tiện đã tồn tại rồi, hãy thử lại với tên khác", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return check;
            }

            return check;
        }


        private bool validateUpdate()
        {
            var check = true;
            if (txtCode.Text.Trim().Length == 0)
            {
                check = false;
                txtCode.Focus();
                MessageBox.Show("Chưa nhập mã loại phương tiện", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return check;
            }

            //kiem tra trung lap ma loai phuong tien
            var vehicleType = VehicleTypeFactory.FindByCode(txtCode.Text.Trim());
            if (vehicleType != null && vehicleType.VehicleTypeID != _vehicleTypeID)
            {
                check = false;
                txtCode.Focus();
                MessageBox.Show("Mã loại phương tiện đã tồn tại rồi, hãy thử lại với mã khác", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return check;
            }

            if (txtName.Text.Trim().Length == 0)
            {
                check = false;
                txtName.Focus();
                MessageBox.Show("Chưa nhập tên loại phương tiện", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return check;
            }

            // kiem tra trung lap ten loai phuong tien
            var vehicleTypeObj = VehicleTypeFactory.findByName(txtName.Text.Trim());
            if (vehicleTypeObj != null && vehicleTypeObj.VehicleTypeID != _vehicleTypeID)
            {
                check = false;
                txtName.Focus();
                MessageBox.Show("Tên loại phương tiện đã tồn tại rồi, hãy thử lại với tên khác", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return check;
            }

            return check;
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            txtCode.Text = StringUtil.RemoveAllNonAlphanumericString(txtCode.Text).ToUpper();
        }
    }
}
