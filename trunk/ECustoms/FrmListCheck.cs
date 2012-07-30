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
using log4net;

namespace ECustoms
{
    public partial class FrmListCheck : SubFormBase
    {
        private static ILog logger = LogManager.GetLogger("Ecustoms.FrmListCheck");

        private UserInfo _userInfo;
        public FrmListCheck()
        {
            InitializeComponent();
        }

        public FrmListCheck(UserInfo userInfo)
        {
            InitializeComponent();
            _userInfo = userInfo;
        }

        private void FrmCheck_Load(object sender, EventArgs e)
        {
            this.Text = "Danh sach thong tin de nghi kiem tra" + ConstantInfo.MESSAGE_TITLE;
            this.Location = new Point((this.Owner.Width - this.Width) / 2, (this.Owner.Height - this.Height) / 2);
            InitData();

            //check user permission
            btnAdd.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_MOI_THONG_TIN_DE_NGHI_KIEM_TRA);
            btnUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_THONG_TIN_DE_NGHI_KIEM_TRA);
            btnDelete.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_THONG_TIN_DE_NGHI_KIEM_TRA);
            comboBoxDeclarationType.SelectedItem = comboBoxDeclarationType.Items[0];
        }

        public void InitData()
        {
            var checks = CheckFactory.SelectAll();
            grdCheck.AutoGenerateColumns = false;
            grdCheck.DataSource = checks;
        }

        private void grdVehicle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddCheck frmAddCheck = new FrmAddCheck(_userInfo, 0, 0);
            frmAddCheck.Show(this);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdCheck.SelectedRows.Count == 1)
                {
                    var frmAddCheck = new FrmAddCheck(_userInfo, 1,
                                                  Convert.ToInt64(grdCheck.SelectedRows[0].Cells["CheckID"].Value));

                    frmAddCheck.Show(this);
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn 1 cảnh báo.");
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
                if (grdCheck.SelectedRows.Count > 0)
                {
                    var dr = MessageBox.Show("Bạn có chắc là muốn xóa?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        for (int i = 0; i < grdCheck.SelectedRows.Count; i++)
                        {
                            var checkID = Convert.ToInt64(grdCheck.SelectedRows[i].Cells["CheckID"].Value);
                            CheckFactory.Delete(checkID);
                        }
                        InitData();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn một cảnh báo.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Filter by from and to
            var checks = CheckFactory.SelectAll();
            var from = new DateTime(dtpCheckFrom.Value.Year, dtpCheckFrom.Value.Month, dtpCheckFrom.Value.Day, 0, 0, 0);
            var to = new DateTime(dtpCheckTo.Value.Year, dtpCheckTo.Value.Month, dtpCheckTo.Value.Day, 23, 59, 59);
            checks = checks.Where(g => (g.CheckFrom >= from) && (g.CheckFrom <= to) && (g.CheckTo <= to)).ToList();

            // Filter by plateNumber)
            if (!string.IsNullOrEmpty(txtPlateNumber.Text.Trim().ToUpper()))
            {
                checks = checks.Where(g => g.PlateNumber.Contains(txtPlateNumber.Text.Trim().ToUpper())).ToList();
            }

            // Filter by DeclarationNumber
            if (!string.IsNullOrEmpty(txtDeclarationNumber.Text))
            {
                checks =
                    checks.Where(
                        g =>
                        g.DeclarationNumber.HasValue &&
                        g.DeclarationNumber.Equals(Convert.ToInt32(txtDeclarationNumber.Text))).ToList();
            }

            // Filter by Company code
            if (!string.IsNullOrEmpty(txtCompanyCode.Text))
            {
                checks = checks.Where(g => g.CompanyCode.Contains(txtCompanyCode.Text)).ToList();
            }
            // filter by check code
            checks.Where(g => g.CheckCode.Contains(txtCheckCode.Text)).ToList();

            if (comboBoxDeclarationType.SelectedIndex >= 1)
            {
                checks = checks.Where(g => g.DeclarationType == comboBoxDeclarationType.SelectedIndex - 1).ToList();
            }

            // Bind data to the current search
            grdCheck.DataSource = checks;
        }

        private void grdCheck_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //check permission
            if (_userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_THONG_TIN_DE_NGHI_KIEM_TRA) == false)
            {
                return;
            }

            try
            {
                if (e.RowIndex >= 0 && grdCheck.SelectedRows.Count == 1) // Only select one row
                {
                    var frmAddCheck = new FrmAddCheck(_userInfo, 1,
                                                        Convert.ToInt64(grdCheck.SelectedRows[0].Cells["CheckID"].Value));

                    frmAddCheck.Show(this);
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
