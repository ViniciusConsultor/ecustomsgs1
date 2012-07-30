using System;
using System.Drawing;
using System.Windows.Forms;
using ECustoms.Utilities;
using ECustoms.BOL;
using log4net;
using System.Linq;

namespace ECustoms
{
    public partial class FrmCheckResult : SubFormBase
    {
        private readonly ILog logger = LogManager.GetLogger("Ecustoms.FrmCheckResult");
        private UserInfo _userInfo;
        public FrmCheckResult()
        {
            InitializeComponent();
        }

        public FrmCheckResult(UserInfo userInfo)
        {
            InitializeComponent();
            _userInfo = userInfo;
        }

        private void FrmCheckResult_Load(object sender, EventArgs e)
        {
            this.Text = "Tong hop thong tin kiem tra" + ConstantInfo.MESSAGE_TITLE;
            // Show form to the center
            this.Location = new Point((this.Owner.Width - this.Width) / 2, (this.Owner.Height - this.Height) / 2);
            // Bind all data
            Init();
            comboBoxDeclarationType.SelectedItem = comboBoxDeclarationType.Items[0];

            //check permission
            bntUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_KET_QUA_KIEM_TRA);
            btnDelete.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_KET_QUA_KIEM_TRA);
        }

        public void Init()
        {
            grdVehicleCheck.AutoGenerateColumns = false;
            var vehicleCheck = VehicleCheckFactory.SelectAll();
            grdVehicleCheck.DataSource = vehicleCheck;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var from = new DateTime(dtpCheckFrom.Value.Year, dtpCheckFrom.Value.Month, dtpCheckFrom.Value.Day, 0, 0, 0);
            var to = new DateTime(dtpCheckTo.Value.Year, dtpCheckTo.Value.Month, dtpCheckTo.Value.Day, 23, 59, 59);
            var result = VehicleCheckFactory.Search(from, to);

            //Fillter by checkCode
            if (txtCode.Text.Trim() != "")
            {
                result = result.Where(g => g.CheckCode != null && g.CheckCode.ToUpper().Contains(txtCode.Text.Trim().ToUpper())).ToList();
            }

            //Fillter by PlateNumber
            if (txtPlateNumber.Text.Trim().ToUpper() != "")
            {
                result = result.Where(g => g.PlateNumber != null && g.PlateNumber.ToUpper().Contains(txtPlateNumber.Text.Trim().ToUpper())).ToList();
            }
            //Fillter by DeclarationNumber
            if (txtDeclarationNumber.Text.Trim() != "")
            {
                result = result.Where(g => g.Number == (Int32.Parse(txtDeclarationNumber.Text.Trim()))).ToList();
            }

            //Fillter by companyCode
            if (txtCompanyCode.Text.Trim() != "")
            {
                result = result.Where(g => g.CompanyCode != null && g.CompanyCode.ToUpper().Contains(txtCompanyCode.Text.Trim().ToUpper())).ToList();
            }

            //Fillter by DeclarationType
            if (comboBoxDeclarationType.SelectedIndex >= 1)
            {
                result = result.Where(g => g.DeclarationType == comboBoxDeclarationType.SelectedIndex - 1).ToList();
            }

            // Order
            result = result.OrderByDescending(g => g.VehicleCheckID).ToList();
            grdVehicleCheck.DataSource = result;
        }

        private void bntUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVehicleCheck.SelectedRows.Count != 0)
                {
                    var vehicleCheckID = grdVehicleCheck.SelectedRows[0].Cells["VehicleCheckID"].Value;
                    var vehicleID = grdVehicleCheck.SelectedRows[0].Cells["VehicleID"].Value;
                    var check = new FrmCheck(_userInfo, Convert.ToInt64(vehicleID), 1, Convert.ToInt32(vehicleCheckID), 0);
                    check.Show(this);
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn 1 tờ khai cần cập nhật.");
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
                if (grdVehicleCheck.SelectedRows.Count > 0)
                {
                    var dr = MessageBox.Show("Bạn có chắc là muốn xóa?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        for (int i = 0; i < grdVehicleCheck.SelectedRows.Count; i++)
                        {
                            var checkVehicleID = Convert.ToInt32(grdVehicleCheck.SelectedRows[i].Cells["VehicleCheckID"].Value);
                            VehicleCheckFactory.Delete(checkVehicleID);
                        }
                        MessageBox.Show("Xóa xong");
                        Init();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn tờ khai.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void grdVehicleCheck_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //check permission
            if (_userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_KET_QUA_KIEM_TRA) == false)
            {
                return;
            }
            try
            {
                if (e.RowIndex >= 0 && grdVehicleCheck.SelectedRows.Count == 1) // Only select one row
                {
                    var vehicleCheckID = grdVehicleCheck.SelectedRows[0].Cells["VehicleCheckID"].Value;
                    var vehicleID = grdVehicleCheck.SelectedRows[0].Cells["VehicleID"].Value;
                    var check = new FrmCheck(_userInfo, Convert.ToInt64(vehicleID), 1, Convert.ToInt32(vehicleCheckID), 0);
                    check.Show(this);
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
