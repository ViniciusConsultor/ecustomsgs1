using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.DAL;
using log4net;
using ECustoms.Utilities;

namespace ECustoms
{
    public partial class frmListVehicleType : SubFormBase
    {
        private static ILog logger = LogManager.GetLogger("ECustoms.frmListVehicleType");
        private UserInfo _userinfo;
        public frmListVehicleType()
        {
            InitializeComponent();
        }

        public frmListVehicleType(UserInfo userInfo)
        {
            InitializeComponent();
            _userinfo = userInfo;

        }

        private void frmListVehicleType_Load(object sender, EventArgs e)
        {
            this.Text = "Danh sach loai phuong tien va bieu phi" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            //check permission
            btnAdd.Enabled = _userinfo.UserPermission.Contains(ConstantInfo.PERMISSON_THEM_MOI_THONG_TIN_LOAI_PHUONG_TIEN);
            btnUpdate.Enabled = _userinfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_THONG_TIN_LOAI_PHUONG_TIEN);
            btnDelete.Enabled = _userinfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_THONG_TIN_LOAI_PHUONG_TIEN);

            init();
        }

        public void init()
        {
            List<tblVehicleType> listVehicleType = VehicleTypeFactory.getAllVehicleType();
            grvVehicleType.AutoGenerateColumns = false;
            grvVehicleType.DataSource = listVehicleType;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddVehicleType frmAddVehicleType = new frmAddVehicleType(_userinfo);
            frmAddVehicleType.MdiParent = this.MdiParent;
            frmAddVehicleType.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grvVehicleType.SelectedRows.Count > 0)
                {
                    int selectedIndex = grvVehicleType.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    var vehicleTypeID = int.Parse(grvVehicleType[0, selectedIndex].Value.ToString());

                    frmAddVehicleType frmAddVehicleType = new frmAddVehicleType(1, vehicleTypeID);
                    frmAddVehicleType.MdiParent = this.MdiParent;
                    frmAddVehicleType.Show();
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
                if (this.grvVehicleType.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Bạn thự sự muốn xóa loại phí đã chọn?", "Cảnh báo!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        int selectedIndex = grvVehicleType.SelectedRows[0].Index;

                        // gets the RowID from the first column in the grid
                        var vehicleTypeID = int.Parse(grvVehicleType[0, selectedIndex].Value.ToString());

                        //kiem tra su ton tai cua vehicleType
                        var vehicleType = VehicleTypeFactory.FindById(vehicleTypeID);
                        if (vehicleType == null)
                        {
                            MessageBox.Show("Loại phương tiện này không còn tồn tại, xin kiểm tra lại");
                            return;
                        }

                        //kiem tra tinh rang buoc tham chieu
                        //neu ton tai xe nhap xuat nao thuoc loai phương tien nay thi khong duoc xoa loai phuong tien
                        
                        //TODO

                        VehicleTypeFactory.DeleteVehicleType(vehicleTypeID);

                        init();
                    }
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

        private void grvVehicleType_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_userinfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_THONG_TIN_LOAI_PHUONG_TIEN) == false)
            {
                return;
            }

            try
            {
                if (e.RowIndex >= 0 && grvVehicleType.SelectedRows.Count == 1) // Only select one row
                {
                    var selectedIndex = grvVehicleType.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    var vehicleTypeID = int.Parse(grvVehicleType[0, selectedIndex].Value.ToString());

                    var frmAddVehicleType = new frmAddVehicleType(1, vehicleTypeID);
                    frmAddVehicleType.MdiParent = this.MdiParent;
                    frmAddVehicleType.Show();

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
