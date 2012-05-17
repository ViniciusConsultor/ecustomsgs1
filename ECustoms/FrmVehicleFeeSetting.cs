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
    public partial class FrmVehicleFeeSetting : Form
    {
        private static ILog logger = LogManager.GetLogger("Ecustoms.FrmVehicleFeeSetting");
        private UserInfo _userInfo;
        public FrmVehicleFeeSetting()
        {
            InitializeComponent();
        }

        public FrmVehicleFeeSetting(UserInfo userInfo)
        {
            InitializeComponent();
            _userInfo = userInfo; 
        }

        private void FrmVehicleFeeSetting_Load(object sender, EventArgs e)
        {

            this.Text = "Cấu hình tính phí phương tiện " + ConstantInfo.MESSAGE_TITLE;
            grdVehicleFee.AutoGenerateColumns = false;

            //check permission
            btnAdd.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_THEM_MOI_THONG_CAU_HINH_TINH_PHI_PHUONG_TIEN);
            btnUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_THONG_CAU_HINH_TINH_PHI_PHUONG_TIEN);
            btnDelete.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_THONG_CAU_HINH_TINH_PHI_PHUONG_TIEN);

            init();
            
        }

        private void init()
        {
            //init vehicleType
            var listVehicleType = VehicleTypeFactory.getAllVehicleType();
            dataSet2.tblVehicleType.Rows.Add(0, "Tất cả");
            foreach (tblVehicleType vehicleType in listVehicleType)
            {
                dataSet2.tblVehicleType.Rows.Add(vehicleType.VehicleTypeID, vehicleType.Name);
            }
            cbVehicleType.DataSource = dataSet2.tblVehicleType;

            //init goodType
            var listGoodType = GoodTypeFactory.SelectAll();
            dataSet2.tblGoodsType.Rows.Add(0, "Tất cả");
            foreach (tblGoodsType goodType in listGoodType)
            {
                dataSet2.tblGoodsType.Rows.Add(goodType.TypeId, goodType.TypeName);
            }
            cbGoodType.DataSource = dataSet2.tblGoodsType;

            bindListVehicleFee();
        }

        public void bindListVehicleFee()
        {

            List<tblVehicleFeeSetting> list = VehicleFeeSettingFactory.getAllVehicleFeeSetting();
            grdVehicleFee.DataSource = list;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            int vehicleTypeId = int.Parse(cbVehicleType.SelectedValue.ToString());
            int goodsTypeId = int.Parse(cbGoodType.SelectedValue.ToString());

            List<tblVehicleFeeSetting> list = VehicleFeeSettingFactory.search(vehicleTypeId, goodsTypeId);

            grdVehicleFee.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddVehicleFeeSetting addForm = new FrmAddVehicleFeeSetting(_userInfo, 0, this);
            addForm.MdiParent = this.MdiParent;
            addForm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVehicleFee.SelectedRows.Count == 1)
                {
                    int vehicleTypeId = int.Parse(grdVehicleFee.SelectedRows[0].Cells["VehicleType"].Value.ToString());
                    int goodsTypeId = int.Parse(grdVehicleFee.SelectedRows[0].Cells["GoodsType"].Value.ToString());
                    tblVehicleFeeSetting vehicleFee = VehicleFeeSettingFactory.find(vehicleTypeId, goodsTypeId);
                    if (vehicleFee == null)
                    {
                        MessageBox.Show("Không còn tồn tại loại biểu phí này, hãy tìm kiếm lại", "Lỗi đồng bộ dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    var updateForm = new FrmAddVehicleFeeSetting(_userInfo, 1, this, vehicleFee);
                    updateForm.MdiParent = this.MdiParent ;
                    updateForm.Show();
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn 1 bản nghi cần cập nhật.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void grdVehicleFee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_THONG_CAU_HINH_TINH_PHI_PHUONG_TIEN) == false)
            {
                return;
            }

            try
            {
                if (grdVehicleFee.SelectedRows.Count == 1)
                {
                    int vehicleTypeId = int.Parse(grdVehicleFee.SelectedRows[0].Cells["VehicleType"].Value.ToString());
                    int goodsTypeId = int.Parse(grdVehicleFee.SelectedRows[0].Cells["GoodsType"].Value.ToString());
                    tblVehicleFeeSetting vehicleFee = VehicleFeeSettingFactory.find(vehicleTypeId, goodsTypeId);
                    if (vehicleFee == null)
                    {
                        MessageBox.Show("Không còn tồn tại loại biểu phí này, hãy tìm kiếm lại", "Lỗi đồng bộ dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    var updateForm = new FrmAddVehicleFeeSetting(_userInfo, 1, this, vehicleFee);
                    updateForm.MdiParent = this.MdiParent;
                    updateForm.Show();
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn 1 bản nghi cần cập nhật.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVehicleFee.SelectedRows.Count == 1)
                {
                    int vehicleTypeId = int.Parse(grdVehicleFee.SelectedRows[0].Cells["VehicleType"].Value.ToString());
                    int goodsTypeId = int.Parse(grdVehicleFee.SelectedRows[0].Cells["GoodsType"].Value.ToString());
                    tblVehicleFeeSetting vehicleFee = VehicleFeeSettingFactory.find(vehicleTypeId, goodsTypeId);
                    if (vehicleFee == null)
                    {
                        MessageBox.Show("Không còn tồn tại loại biểu phí này, hãy tìm kiếm lại", "Lỗi đồng bộ dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    int result = VehicleFeeSettingFactory.Delete(vehicleFee);
                    if (result > 0)
                    {
                        search();
                        MessageBox.Show("Xóa thành công", "Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy biểu phí cần xóa trong CSDL. Xóa không thành công. Hãy tìm kiếm và tiến hành xóa lại", "Lỗi đồng bộ dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn 1 bản nghi cần xóa.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }
    }
}
