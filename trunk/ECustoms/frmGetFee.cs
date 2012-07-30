using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.Utilities;
using ECustoms.Utilities.Enums;
using Microsoft.Office.Interop.Excel;
using Point = System.Drawing.Point;
using log4net;
using ECustoms.DAL;
using System.Configuration;

namespace ECustoms
{
    public partial class frmGetFee : SubFormBase
    {
        private static ILog logger = LogManager.GetLogger("ECustoms.frmGetFee");
        private UserInfo _userinfo;

        public frmGetFee()
        {
            InitializeComponent();
        }

        public frmGetFee(UserInfo userInfo)
        {
            InitializeComponent();
            _userinfo = userInfo;

        }

        private void frmGetFee_Load(object sender, EventArgs e)
        {
            this.Text = "Thu phi" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;

            //check permission
            btnFeeExport.Enabled = _userinfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_THU_PHI_PHUONG_TIEN_XUAT_CANH);
            btnFeeImport.Enabled = _userinfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_THU_PHI_PHUONG_TIEN_NHAP_CANH);
            btnExportExcel.Enabled = _userinfo.UserPermission.Contains(ConstantInfo.PERMISSON_XUAT_EXCEL_THONG_TIN_THU_PHI_PHUONG_TIEN);

            //Init data
            Search();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Search();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
           
        }

        
        /// <summary>
        /// Tìm kiếm phương tiện thu phí
        /// </summary>        
        private void Search()
        {
            var listVehicle =  VehicleFactory.SeachFee(txtPlateNumber.Text.Trim(), txtReceiptNumber.Text.Trim(), cbCreatedVehicle.Checked, dtpCreatedDateFrom.Value, dtpCreatedDateTo.Value, cbIsParking.Checked, dtpParkingDateFrom.Value, dtpParkingDateTo.Value, cbGetFee.Checked, dtpFeeFrom.Value, dtpFeeTo.Value);
            // Bind data to the gridview
            grdVehicle.AutoGenerateColumns = false;
            //listVehicle = listVehicle.Distinct(new ViewAllVehicleHasGoodComparer()).ToList();
            grdVehicle.DataSource = listVehicle;
            txtPlateNumber.Focus();
        }

        #region Private Class
        /// <summary>
        /// Class to compare ViewAllVehicleHasGood
        /// </summary>
        private class ViewAllVehicleHasGoodComparer : IEqualityComparer<ViewAllVehicleHasGood>
        {
            public bool Equals(ViewAllVehicleHasGood x, ViewAllVehicleHasGood y)
            {
                if (Object.ReferenceEquals(x, y)) return true;
                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;
                return x.VehicleID == y.VehicleID;
            }
            public int GetHashCode(ViewAllVehicleHasGood vehicle)
            {
                if (Object.ReferenceEquals(vehicle, null)) return 0;
                var hashVehicleId = vehicle.VehicleID.GetHashCode();
                return hashVehicleId;
            }
        }
        #endregion

        private void txtPlateNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Enter key
            {
                Search();
            }
        }

        private void txtReceiptNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Enter key
            {
                Search();
            }
        }

        private void cbCreatedVehicle_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCreatedVehicle.Checked)
            {
                dtpCreatedDateFrom.Enabled = dtpCreatedDateTo.Enabled = true;
            }
            else
            {
                dtpCreatedDateFrom.Enabled = dtpCreatedDateTo.Enabled = false;    
            }
        }

        private void cbIsParking_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsParking.Checked)
            {
                dtpParkingDateFrom.Enabled = dtpParkingDateTo.Enabled = true;
            }
            else
            {
                dtpParkingDateFrom.Enabled = dtpParkingDateTo.Enabled = false;
            }
        }

        private void btnFeeExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVehicle.SelectedRows.Count == 1)
                {
                    var vehicleId = long.Parse(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value.ToString());
                    var mode = 0; //add new
                    var feeStatus = grdVehicle.SelectedRows[0].Cells["feeExportStatus"].Value;
                    if (feeStatus != null && int.Parse(feeStatus.ToString()) == (int)FeeStatus.PaidFee) mode = 1; //edit
                    var frmConfirmFee = new frmConfirmFee(_userinfo, mode, 0, vehicleId);
                    if (frmConfirmFee.ShowDialog() == DialogResult.OK)
                    {
                        Search();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn 1 phương tiện cần xác nhận.");
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnFeeImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVehicle.SelectedRows.Count == 1)
                {
                    var vehicleId = long.Parse(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value.ToString());
                    var mode = 0; //add new
                    var feeStatus = grdVehicle.SelectedRows[0].Cells["feeImportStatus"].Value;
                    if (feeStatus != null && int.Parse(feeStatus.ToString()) == (int)FeeStatus.PaidFee) mode = 1; //edit
                    var frmConfirmFee = new frmConfirmFee(_userinfo, mode, 1, vehicleId);
                    if (frmConfirmFee.ShowDialog() == DialogResult.OK)
                    {
                        Search();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn 1 phương tiện cần xác nhận.");
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
                var excel = new ApplicationClass();
                excel.Application.Workbooks.Add(true);

                var columnIndex = 0;
                for (var i = 0; i < grdVehicle.Columns.Count; i++)
                {
                    if (!grdVehicle.Columns[i].Visible) continue;
                    columnIndex++;
                    excel.Cells[1, columnIndex] = grdVehicle.Columns[i].HeaderText;
                    ((Range)excel.Cells[1, columnIndex]).Font.Bold = true;
                }
                int rowIndex = 0;
                foreach (DataGridViewRow dataRow in grdVehicle.Rows)
                {
                    rowIndex++; 
                    excel.Cells[rowIndex + 1, 1] = dataRow.Cells["PlateNumber"].Value != null ? dataRow.Cells["PlateNumber"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 2] = dataRow.Cells["DriverName"].Value != null ? dataRow.Cells["DriverName"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 3] = dataRow.Cells["VehicleTypeName"].Value != null ? dataRow.Cells["VehicleTypeName"].Value.ToString() : "";

                    excel.Cells[rowIndex + 1, 4] = dataRow.Cells["ExportReceiptNumber"].Value != null ? dataRow.Cells["ExportReceiptNumber"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 5] = dataRow.Cells["ImportReceiptNumber"].Value != null ? dataRow.Cells["ImportReceiptNumber"].Value.ToString() : "";
    
                    excel.Cells[rowIndex + 1, 6] = dataRow.Cells["ExportDate"].Value != null ? ((DateTime)(dataRow.Cells["ExportDate"].Value)).ToString("dd/MM/yyyy hh:mm") : "";
                    excel.Cells[rowIndex + 1, 7] = dataRow.Cells["ImportDate"].Value != null ? ((DateTime)(dataRow.Cells["ImportDate"].Value)).ToString("dd/MM/yyyy hh:mm") : "";
                    excel.Cells[rowIndex + 1, 8] = dataRow.Cells["NumberOfContainer"].Value != null ? dataRow.Cells["NumberOfContainer"].Value.ToString() : "";
                    
                    excel.Cells[rowIndex + 1, 9] = dataRow.Cells["parking"].Value != null ? dataRow.Cells["parking"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 10] = dataRow.Cells["ParkingDate"].Value != null ? ((DateTime)(dataRow.Cells["ParkingDate"].Value)).ToString("dd/MM/yyyy hh:mm") : "";
                    excel.Cells[rowIndex + 1, 11] = dataRow.Cells["status"].Value != null ? dataRow.Cells["status"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 12] = dataRow.Cells["Note"].Value != null ? dataRow.Cells["Note"].Value.ToString() : "";
                    
                    excel.Cells[rowIndex + 1, 13] = dataRow.Cells["ImportStatus"].Value != null ? dataRow.Cells["ImportStatus"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 14] = dataRow.Cells["ConfirmExportByName"].Value != null ? dataRow.Cells["ConfirmExportByName"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 15] = dataRow.Cells["ConfirmImportByName"].Value != null ? dataRow.Cells["ConfirmImportByName"].Value.ToString() : "";


                    excel.Cells[rowIndex + 1, 16] = dataRow.Cells["ConfirmFeeExportByUserName"].Value != null ? dataRow.Cells["ConfirmFeeExportByUserName"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 17] = dataRow.Cells["ConfirmFeeImportByUserName"].Value != null ? dataRow.Cells["ConfirmFeeImportByUserName"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 18] = dataRow.Cells["feeExportAmount"].Value != null ? dataRow.Cells["feeExportAmount"].Value.ToString() : "";


                    excel.Cells[rowIndex + 1, 19] = dataRow.Cells["feeImportAmount"].Value != null ? dataRow.Cells["feeImportAmount"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 20] = dataRow.Cells["DeclarationExportNumber"].Value != null ? dataRow.Cells["DeclarationExportNumber"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 21] = dataRow.Cells["DeclarationExportType"].Value != null ? dataRow.Cells["DeclarationExportType"].Value.ToString() : "";


                    excel.Cells[rowIndex + 1, 22] = dataRow.Cells["DeclarationImportNumber"].Value != null ? dataRow.Cells["DeclarationImportNumber"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 23] = dataRow.Cells["DeclarationImportType"].Value != null ? dataRow.Cells["DeclarationImportType"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 24] = dataRow.Cells["ExportGoodsTypeName"].Value != null ? dataRow.Cells["ExportGoodsTypeName"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 24] = dataRow.Cells["ImportGoodsTypeName"].Value != null ? dataRow.Cells["ImportGoodsTypeName"].Value.ToString() : "";
               
                }

                excel.Visible = true;
                var worksheet = (Worksheet)excel.ActiveSheet;
                worksheet.Activate();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void cbGetFee_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGetFee.Checked)
            {
                dtpFeeFrom.Enabled = dtpFeeTo.Enabled = true;
            }
            else
            {
                dtpFeeFrom.Enabled = dtpFeeTo.Enabled = false;
            }
        }
    }
}
