using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.Utilities;
using ECustoms.Utilities.Enums;
using Microsoft.Office.Interop.Excel;
using Point = System.Drawing.Point;
using ECustoms.DAL;
using log4net;
using System.Linq;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ECustoms
{
    public partial class frmVehicleSearch : SubFormBase
    {
        private static ILog logger = LogManager.GetLogger("Ecustoms.frmVehicleSearch");
        private UserInfo _userInfo;
        private Form _mainForm;
        private int _checkID;
        private PrintTicketSetting _printSetting;

        public frmVehicleSearch()
        {
            InitializeComponent();
        }

        public frmVehicleSearch(UserInfo userInfo, Form mainForm)
        {
            InitializeComponent();
            _userInfo = userInfo;
            //InitialPermission();
            _mainForm = mainForm;
        }

        public void LoadPrintSetting()
        {
            var filePath = System.Windows.Forms.Application.StartupPath + @"\conf\print_ticket.xml";
            _printSetting = ObjectToXml.GetTicketSetting(filePath);
        }
        //private void InitialPermission()
        //{
        //    //throw new NotImplementedException();

        //    if (_userInfo.Type == UserType.Admin)
        //    {

        //    }
        //    else if (_userInfo.Type == UserType.Confirm)
        //    {
        //        btnDelete.Enabled = false;
        //    }
        //    else if (_userInfo.Type == UserType.Input)
        //    {
        //        btnXacNhanXuatCanh.Enabled = false;
        //        btnXacNhanNhapCanhCoHang.Enabled = false;
        //        btnXacNhanXuatCanhKhongCoHang.Enabled = false;
        //        btnLocalConfirm.Enabled = false;
        //        btnUpdateNoidia.Enabled = false;
        //        btnDelete.Enabled = false;
        //        dtpNoidia.Enabled = false;
        //        hourNoidia.Enabled = false;
        //    }
        //}
        private void frmVehicleSearch_Load(object sender, EventArgs e)
        {
            LoadPrintSetting();
            this.Text = "Tim kiem" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            // Show form to the center
            this.Location = new Point((_mainForm.Width - this.Width) / 2, (_mainForm.Height - this.Height) / 2);
            //Init data
            BindData();
            txtPlateNumber.Focus();
            hourNoidia.Text = CommonFactory.GetCurrentDate().ToString("HH:mm");

            //check user permission
            btnUpdateVehicle.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_PHUONG_TIEN);
            btnDelete.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_PHUONG_TIEN);

            btnXacNhanNhapCanhCoHang.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_NHAP_CANH);
            btnXacNhanXuatCanh.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_XUAT_CANH);
            btnXacNhanXuatCanhKhongCoHang.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_NHAP_CANH);
            btnLocalConfirm.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_HANG_VAO_NOI_DIA);
            btnUpdateNoidia.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_THOI_GIAN_VAO_NOI_DIA);
            btnExportExcel.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_EXPORT_HO_SO);
            btnParking.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_HANG_VAO_BAI);
        }

        public void BindData()
        {
            try
            {
                grdVehicle.AutoGenerateColumns = false;
                List<ViewAllVehicleHasGood> result = VehicleFactory.SearchVehicle(cbIsCompleted.Checked, txtPlateNumber.Text.Trim().ToUpper(), txtPlateNumberChinese.Text.Trim().ToUpper(), cbIsExport.Checked, cbIsImport.Checked, cbIsNotImport.Checked, dtpImportFrom.Value, dtpImportTo.Value,
                                                        dtpExportFrom.Value, dtpExportTo.Value, cbIsChineseVehicle.Checked);
                // Limit xe khong cho hang
                if (checkBoxNoItem.Checked)
                {
                    result = result.Where(g => g.DeclarationID == 0).ToList();
                }

                if (checkBoxNhapCanhCHChuaVaoND.Checked)
                {
                    result = result.Where(g => g.DeclarationID == 1 && (g.IsGoodsImported == null || g.IsGoodsImported == false)).ToList();
                }
                //xe vao bai
                if (cbParking.Checked == true)
                {
                    var parkingDateFrom = new DateTime(dtpPackingDateFrom.Value.Year, dtpPackingDateFrom.Value.Month, dtpPackingDateFrom.Value.Day, 0, 0, 0);
                    var parkingDateTo = new DateTime(dtpPackingDateTo.Value.Year, dtpPackingDateTo.Value.Month, dtpPackingDateTo.Value.Day, 23, 59, 59);

                    result = result.Where(g => g.Parking != null && g.ParkingDate >= parkingDateFrom && g.ParkingDate <= parkingDateTo).ToList();
                }

                var listVehilceID = result.Select(x => x.VehicleID).Distinct().ToList();

                var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
                var allVehicles = db.ViewAllVehicles.ToList();
                db.Connection.Close();
                // var allVehicles = VehicleFactory.GetAllViewAllVehicle();
                var q = (from x in allVehicles where listVehilceID.Contains(x.VehicleID) select x).OrderByDescending(g => g.Parking).OrderByDescending(g => g.ModifiedDate).ToList();

                grdVehicle.DataSource = q;

                int xeKhongChoHangDaXC = 0;
                int xeKhongChoHangDaNC = 0;
                int xeCoHangDaXC = 0;
                int xeNhapHangDaNC = 0;
                int xeVaoNoiDia = 0;

                if (result.Count > 0)
                {
                    var listXeKhongChoHangDaXC = result.Where(g => g.DeclarationID == 0 && g.IsExport != null && g.IsExport.Value == true).Select(x => x.VehicleID).Distinct().ToList();
                    xeKhongChoHangDaXC = listXeKhongChoHangDaXC.Count;
                    var listXeKhongChoHangDaNC = result.Where(g => g.DeclarationID == 0 && g.IsImport != null && g.IsImport.Value == true).Select(x => x.VehicleID).Distinct().ToList();
                    xeKhongChoHangDaNC = listXeKhongChoHangDaNC.Count;
                    var listXeCohangDaXC = result.Where(g => g.DeclarationID > 0 && g.IsExport != null && g.IsExport.Value == true).Select(x => x.VehicleID).Distinct().ToList();
                    xeCoHangDaXC = listXeCohangDaXC.Count;
                    var listXeNhapHangDaNC = result.Where(g => g.DeclarationID > 0 && g.IsImport != null && g.IsImport.Value == true && g.HasGoodsImported != null && g.HasGoodsImported.Value == true).Select(x => x.VehicleID).Distinct().ToList();
                    xeNhapHangDaNC = listXeNhapHangDaNC.Count;
                    var listXeVaoNoiDia = result.Where(g => g.IsGoodsImported == true && g.DeclarationID > 1).Select(x => x.VehicleID).Distinct().ToList();
                    xeVaoNoiDia = listXeVaoNoiDia.Count;

                    // Set Decleration info
                    SetDeclerationInfo(grdVehicle.Rows[0]);
                }
                else
                {
                    lblHeader.Text = "";
                    listViewVehicle.Clear();
                }

                lblKhongXC.Text = xeKhongChoHangDaXC.ToString();
                lblKhongNC.Text = xeKhongChoHangDaNC.ToString();
                lblCohangNC.Text = xeNhapHangDaNC.ToString();
                lblCoHangXC.Text = xeCoHangDaXC.ToString();
                lblVaonoidia.Text = xeVaoNoiDia.ToString();
                txtPlateNumber.Focus();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Set Vehicel
        /// </summary>
        /// <param name="row"></param>
        private void SetDeclerationInfo(DataGridViewRow row)
        {
            try
            {
                // Clear result
                listViewVehicle.Clear();
                lblHeader.Visible = true;

                var plateNumber = row.Cells["PlateNumber"].Value;

                lblHeader.Text = "Thông tin về tờ khai cho phương tiện có biển kiểm soát: " + plateNumber + ":";

                // Get List vehicle 
                var vehicleID = Convert.ToInt32(row.Cells["VehicleID"].Value);

                var listDecleration = DeclarationFactory.GetByVehicleID(vehicleID);
                StringBuilder declerationInfo;
                // return if does not any vehicle
                if (listDecleration.Count <= 0) return;
                for (int i = 0; i < listDecleration.Count; i++)
                {
                    ListViewItem listViewItem = new ListViewItem();

                    var currentDecleration = listDecleration[i];
                    declerationInfo = new StringBuilder();
                    if (currentDecleration.DeclarationType == 0)// to khai xuat
                    {
                        declerationInfo.Append("Số tờ khai xuất: " + currentDecleration.Number + "; ");
                    }
                    else // to khai nhap
                    {
                        declerationInfo.Append("Số tờ khai nhập: " + currentDecleration.Number + "; ");
                    }

                    declerationInfo.Append("Loại hình: " + currentDecleration.Type + "; ");
                    if (currentDecleration.RegisterDate != null)
                    {
                        declerationInfo.Append("Ngày đăng ký: " + currentDecleration.RegisterDate.Value.ToString("dd/MM/yyyy") + "; ");
                    }
                    else
                        declerationInfo.Append("Ngày đăng ký: ; ");

                    if (currentDecleration.ConfirmStatus != null)
                    {
                        declerationInfo.Append("Trạng thái: " + currentDecleration.ConfirmStatus + "; ");
                        System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#8af2db");
                        listViewItem.BackColor = col;
                    }
                    else
                    {
                        declerationInfo.Append("Trạng thái: ; ");
                        System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#fff17e");
                        listViewItem.BackColor = col;
                    }

                    declerationInfo.Append("Tên hàng: " + currentDecleration.ProductName + "; ");
                    declerationInfo.Append("Lượng hàng: " + currentDecleration.ProductAmount + "; ");
                    declerationInfo.Append("Đơn vị tính: " + currentDecleration.Unit + "");
                    listViewItem.Text = declerationInfo.ToString();
                    // Add data to listView
                    listViewVehicle.Items.Add(listViewItem);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void cbIsExport_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbIsChineseVehicle.Checked)
            {
                // Export
                if (cbIsExport.Checked)
                {
                    EnableExport(true);
                }
                else
                {
                    EnableExport(false);
                    EnabledImport(false);
                    cbIsImport.Checked = false;
                    cbIsNotImport.Checked = false;
                }    
            }
            else //xe TQ
            {
                if (cbIsExport.Checked && !cbIsImport.Checked)
                {
                    MessageBox.Show("Bạn phải nhập thời gian nhập cảnh.");
                    cbIsExport.Checked = false;
                    return;
                }

                if (cbIsExport.Checked && cbIsImport.Checked) // completed
                {
                    EnableExport(true);
                    cbIsNotImport.Checked = false;
                    cbIsNotImport.Enabled = false;
                }
                else
                {
                    EnableExport(false);
                    cbIsExport.Checked = false;
                }        
            }
            
        }

        private void cbIsImport_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbIsChineseVehicle.Checked)
            {
                // Import
                if (!cbIsExport.Checked && cbIsImport.Checked)
                {
                    MessageBox.Show("Bạn phải nhập thời gian xuất cảnh.");
                    cbIsImport.Checked = false;
                    return;
                }

                if (cbIsImport.Checked && cbIsExport.Checked) // completed
                {
                    EnabledImport(true);
                    cbIsNotImport.Checked = false;
                    cbIsNotImport.Enabled = false;
                }
                else if (!cbIsCompleted.Checked)
                {
                    EnabledImport(false);
                    cbIsNotImport.Enabled = true;
                }
            }
            else //xe TQ
            {
                if (cbIsImport.Checked)
                {
                    EnabledImport(true);
                    cbIsNotImport.Checked = false;
                    cbIsNotImport.Enabled = false;
                }
                else
                {
                    EnabledImport(false);
                    EnableExport(false);
                    cbIsExport.Checked = false;
                    cbIsNotImport.Checked = false;
                }    
            }
            
        }

        /// <summary>
        /// Enable or disable Import information
        /// </summary>
        /// <param name="value">True is enable</param>
        private void EnabledImport(bool value)
        {
            lblImportFrom.Enabled = value;
            lblImportTo.Enabled = value;
            dtpImportFrom.Enabled = value;
            dtpImportTo.Enabled = value;
        }

        /// <summary>
        /// Enable or disable Export information
        /// </summary>
        /// <param name="value">True if enabled</param>
        private void EnableExport(bool value)
        {
            lblExportFrom.Enabled = value;
            lblExportTo.Enabled = value;
            dtpExportFrom.Enabled = value;
            dtpExportTo.Enabled = value;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void cbIsNotImport_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbIsChineseVehicle.Checked)
            {
                // Import
                if (!cbIsExport.Checked && cbIsNotImport.Checked)
                {
                    MessageBox.Show("Bạn phải nhập thời gian xuất cảnh.");
                    cbIsNotImport.Checked = false;
                    return;
                }

                if (cbIsImport.Checked && cbIsNotImport.Checked)
                {
                    EnabledImport(true);
                    cbIsImport.Checked = false;
                    cbIsImport.Enabled = false;

                }
                else if (!cbIsImport.Checked)
                {
                    EnabledImport(false);
                    cbIsImport.Enabled = true;
                }    
            }
            else //xeTQ
            {
                if (cbIsNotImport.Checked)
                {
                    EnabledImport(false);
                    cbIsImport.Checked = false;
                    cbIsImport.Enabled = false;
                }
                else
                {
                    EnabledImport(false);
                    EnableExport(false);
                    cbIsExport.Checked = false;
                    cbIsImport.Checked = false;
                }        
            }
            
        }

        private void grdVehicle_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_PHUONG_TIEN) || _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_PHUONG_TIEN) || _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_NHAP_CANH) || _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_XUAT_CANH))
            {
                try
                {
                    if (e.RowIndex >= 0 && grdVehicle.SelectedRows.Count == 1) // Only select one row
                    {
                        var vehicle = new frmVehicle(3, Convert.ToInt32(grdVehicle.Rows[e.RowIndex].Cells["VehicleID"].Value), _userInfo, _mainForm, this);
                        vehicle.Show(this);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex.ToString());
                    if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");

                var excel = new ApplicationClass();
                excel.Application.Workbooks.Add(true);

                var columnIndex = 0;
                ((Range)excel.Cells[1, 1]).Font.Bold = true;
                ((Range)excel.Cells[1, 2]).Font.Bold = true;
                excel.Cells[1, 1] = "Số tờ khai xuất";
                excel.Cells[1, 2] = "Số tờ khai nhập";
                excel.Cells[1, 3] = "Ngày đăng ký";
                // Add column header
                for (var i = 0; i < grdVehicle.Columns.Count; i++)
                {
                    if (!grdVehicle.Columns[i].Visible) continue;
                    columnIndex++;
                    excel.Cells[1, columnIndex + 3] = grdVehicle.Columns[i].HeaderText;
                    ((Range)excel.Cells[1, columnIndex + 3]).Font.Bold = true;
                }

                int rowIndex = 0;

                foreach (DataGridViewRow dataRow in grdVehicle.Rows)
                {
                    rowIndex++;
                    var vehicleID = Convert.ToInt64(dataRow.Cells["VehicleID"].Value);
                    var listDecleration = DeclarationFactory.GetByVehicleID(vehicleID);

                    // Set số tờ khai xuất
                    if (listDecleration.Count > 0)
                    {
                        var listExport = listDecleration.Where(g => g.DeclarationType == 0).ToList();
                        for (int i = 0; i < listExport.Count; i++)
                        {
                            if (i != listExport.Count - 1)
                            {
                                excel.Cells[rowIndex + 1, 1] = listExport[i].Number + ";";
                            }
                            else
                                excel.Cells[rowIndex + 1, 1] = listExport[i].Number;
                        }
                        // Set sốt tờ khai nhập
                        var listImport = listDecleration.Where(g => g.DeclarationType == 1).ToList();
                        for (int i = 0; i < listImport.Count; i++)
                        {
                            if (i != listImport.Count - 1)
                            {
                                excel.Cells[rowIndex + 1, 2] = listImport[i].Number + ";";
                            }
                            else
                                excel.Cells[rowIndex + 1, 2] = listImport[i].Number;
                        }
                        // set ngày đăng ký
                        for (int i = 0; i < listDecleration.Count; i++)
                        {
                            if (i != listDecleration.Count - 1)
                            {
                                excel.Cells[rowIndex + 1, 3] = listDecleration[i].RegisterDate + ";";
                            }
                            else
                                excel.Cells[rowIndex + 1, 3] = listDecleration[i].RegisterDate;
                        }
                    }
                    else
                    {
                        excel.Cells[rowIndex + 1, 1] = "";
                        excel.Cells[rowIndex + 1, 2] = "";
                        excel.Cells[rowIndex + 1, 3] = "";
                    }
                    // Set Ngày đăng ký                    
                    excel.Cells[rowIndex + 1, 4] = dataRow.Cells["PlateNumber"].Value != null ? dataRow.Cells["PlateNumber"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 5] = dataRow.Cells["DriverName"].Value != null ? dataRow.Cells["DriverName"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 6] = dataRow.Cells["ExportDate"].Value != null ? ((DateTime)(dataRow.Cells["ExportDate"].Value)).ToString("dd/MM/yyyy hh:mm") : "";
                    excel.Cells[rowIndex + 1, 7] = dataRow.Cells["ImportDate"].Value != null ? ((DateTime)(dataRow.Cells["ImportDate"].Value)).ToString("dd/MM/yyyy hh:mm") : "";
                    excel.Cells[rowIndex + 1, 8] = dataRow.Cells["NumberOfContainer"].Value != null ? dataRow.Cells["NumberOfContainer"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 9] = dataRow.Cells["parking"].Value != null ? dataRow.Cells["parking"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 10] = dataRow.Cells["ParkingDate"].Value != null ? ((DateTime)(dataRow.Cells["ParkingDate"].Value)).ToString("dd/MM/yyyy hh:mm") : "";
                    excel.Cells[rowIndex + 1, 11] = dataRow.Cells["Status"].Value != null ? dataRow.Cells["Status"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 12] = dataRow.Cells["Note"].Value != null ? dataRow.Cells["Note"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 13] = dataRow.Cells["ImportStatus"].Value != null ? dataRow.Cells["ImportStatus"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 14] = dataRow.Cells["ImportedLocalTime"].Value != null ? dataRow.Cells["ImportedLocalTime"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 15] = dataRow.Cells["ConfirmExportByName"].Value != null ? dataRow.Cells["ConfirmExportByName"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 16] = dataRow.Cells["ConfirmImportByName"].Value != null ? dataRow.Cells["ConfirmImportByName"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 17] = dataRow.Cells["ConfirmLocalImportByName"].Value != null ? dataRow.Cells["ConfirmLocalImportByName"].Value.ToString() : "";

                    excel.Visible = true;
                    var worksheet = (Worksheet)excel.ActiveSheet;
                    worksheet.Activate();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                //if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdateVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVehicle.SelectedRows.Count == 1)
                {
                    var vehicle = new frmVehicle(3, Convert.ToInt64(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value), _userInfo, _mainForm, this);
                    vehicle.MdiParent = this.ParentForm;
                    vehicle.Show();
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn 1 phương tiện cần cập nhật.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void txtPlateNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Enter key
            {
                BindData();
                if (grdVehicle.Rows.Count > 0) // Set focus
                {
                    btnXacNhanXuatCanh.Focus();
                }
            }
        }

        private void txtPlateNumberChinese_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Enter key
            {
                BindData();
                if (grdVehicle.Rows.Count > 0) // Set focus
                {
                    btnXacNhanXuatCanh.Focus();
                }
            }
        }
        private void btnXacNhanXuatCanh_Click(object sender, EventArgs e)
        {
            try
            {
                var vehicleID = long.Parse(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value.ToString());
                if (grdVehicle.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Bạn cần chọn 1 phương tiện.");
                    return;
                }

                if (IsCheck(vehicleID, VehicleCheckFactory.CHECK_TYPE_EXPORT))
                {
                    // Show alert form
                    FrmAlert frmAlert = new FrmAlert(_userInfo, vehicleID, _checkID, VehicleCheckFactory.CHECK_TYPE_EXPORT);
                    frmAlert.Show(this);
                    return;
                }

                var vehicleInfo = VehicleFactory.GetByID(long.Parse(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value.ToString()));

                var message = new StringBuilder();
                message.AppendLine("Thời gian xuất cảnh: " + CommonFactory.GetCurrentDate().ToString("dd/MM/yyyy HH:mm"));
                //Kiem tra co phai xe khong cho hang
                var isExportNoGood = VehicleFactory.IsVehicleExportNoGood(vehicleInfo.VehicleID);
                if (isExportNoGood)
                {
                    message.AppendLine("Xe không chở hàng, không thu phí");
                }
                else
                {
                    GetInfoVehicleDialog(message, vehicleInfo, 0);
                }

                //if (MessageBox.Show(message.ToString(), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                var msgBox = new frmMessageBox(message.ToString());
                if (msgBox.ShowDialog() == DialogResult.Yes)
                {
                    vehicleInfo.ExportDate = CommonFactory.GetCurrentDate();

                    if (vehicleInfo.ConfirmExportBy != null && vehicleInfo.ConfirmExportBy != 0 && vehicleInfo.ConfirmExportBy != _userInfo.UserID)
                        throw new Exception("Phương tiện đã được xác nhận bởi một người dùng khác!");

                    vehicleInfo.ConfirmExportBy = _userInfo.UserID;
                    vehicleInfo.IsExport = true;
                    if (isExportNoGood) vehicleInfo.feeExportStatus = (int) FeeStatus.NotNeedPayFee;
                    VehicleFactory.UpdateVehicle(vehicleInfo);
                
                    // Bind to grid
                    BindData();

                    //print ticket
                    //printTicket(1, vehicleInfo);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void GetInfoVehicleDialog(StringBuilder message, tblVehicle vehicleInfo, int type)
        {
            //Loại trọng tải
            var vehicleType = string.Empty;
            if (vehicleInfo.vehicleTypeId == null)
            {
                vehicleType = "Chưa xác định";
            }
            else
            {
                var vehicleTypeInfo = VehicleTypeFactory.FindById((int)vehicleInfo.vehicleTypeId);
                if (vehicleTypeInfo != null)
                {
                    vehicleType = vehicleTypeInfo.Capacity;
                }

            }
            message.AppendLine("Loại trọng tải: " + vehicleType);
            //Tình trạng thu phí, type = 0 : XN xuất khẩu, type = 1: XN nhập khẩu
            if (type == 0)
            {
                message.AppendLine("Tình trạng thu phí xuất: " + GetFeeStatus(vehicleInfo.feeExportStatus));
            }
            else
            {
                message.AppendLine("Tình trạng thu phí nhập: " + GetFeeStatus(vehicleInfo.feeImportStatus));
            }
            //Loại hàng
            var goodTypeId = type == 0 ? vehicleInfo.ExportGoodTypeId : vehicleInfo.ImportGoodTypeId;
            var goodType = goodTypeId == null ? "Chưa xác định" : GoodTypeFactory.GetTypeNameById((int)goodTypeId);
            message.AppendLine("Loại hàng: " + goodType);
        }

        private string GetFeeStatus(int? feeStatus)
        {
            if (feeStatus == null)
            {
                return "Chưa thu phí";
            }
            switch (feeStatus)
            {
                case (int)FeeStatus.NotNeedPayFee:
                    return "Không thu phí";
                case (int)FeeStatus.HasNotPayFee:
                    return "Chưa thu phí";
                case (int)FeeStatus.PaidFee:
                    return "Đã thu phí";
                default:
                    return "Không xác định";
            }
            
        }

        private void btnXacNhanNhapCanhCoHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVehicle.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Bạn cần chọn 1 phương tiện.");
                    return;
                }
                var vehicleID = long.Parse(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value.ToString());

                //check work-flow
                tblVehicle vehicle = VehicleFactory.GetByID(vehicleID);
                if (vehicle != null && vehicle.IsExport != true)
                {
                    MessageBox.Show("Xe này chưa được xuất cảnh, nên không thể nhập cảnh có hàng", "Lỗi trình tự");
                    return;
                }

                if (IsCheck(vehicleID, VehicleCheckFactory.CHECK_TYPE_IMPORT))
                {
                    // Show alert form
                    FrmAlert frmAlert = new FrmAlert(_userInfo, vehicleID, _checkID, VehicleCheckFactory.CHECK_TYPE_IMPORT);
                    frmAlert.Show(this);
                    return;
                }
                var message = new StringBuilder();
                message.Append("Thời gian nhập cảnh: " + CommonFactory.GetCurrentDate().ToString("dd/MM/yyyy HH:mm"));

                //var vehicle = VehicleFactory.GetByID(long.Parse(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value.ToString()));
                //var vehicle = VehicleFactory.GetByID(int.Parse(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value.ToString()));

                //if (MessageBox.Show(message.ToString(), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                var msgBox = new frmMessageBox(message.ToString());
                if (msgBox.ShowDialog() == DialogResult.Yes)
                {
                    vehicle.ImportDate = CommonFactory.GetCurrentDate();
                    //vehicle.ImportHour = CommonFactory.GetCurrentDate().ToString("HH:mm");
                    vehicle.IsImport = true;
                    vehicle.HasGoodsImported = true;
                    vehicle.ImportStatus = "Nhập cảnh có hàng";
                    if (vehicle.ConfirmImportBy != null && vehicle.ConfirmImportBy != 0 && vehicle.ConfirmImportBy != _userInfo.UserID)
                        throw new Exception("Phương tiện đã được xác nhận bởi một người dùng khác!");
                    var declarationImport = DeclarationFactory.GetByVehicleID(vehicle.VehicleID).Where(g => g.DeclarationType == 1).ToList();

                    // Neu phuong tien nay chua co trong to khai nhap, add phuong tien nay vao to khai so 1))
                    if (!DeclarationVehicleFactory.IsExisting(vehicle.VehicleID, 1) && declarationImport.Count == 0)
                    {
                        DeclarationVehicleFactory.Insert(vehicle.VehicleID, 1);
                    }

                    vehicle.ConfirmImportBy = _userInfo.UserID;
                    VehicleFactory.UpdateVehicle(vehicle);
                    // Bind data to gridview
                    BindData();

                    //print ticket
                    if (_printSetting != null && _printSetting.PrintImportHasGood == true)
                    {
                        if (vehicle.HasGoodsImportedTocalPrint != null)
                        {
                            if (MessageBox.Show("Xe này đã in phiếu rồi. Bạn có muốn in lại", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                printTicket(2, vehicle);
                            }
                        }
                        else
                        {
                            printTicket(2, vehicle);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnXacNhanXuatCanhKhongCoHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVehicle.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Bạn cần chọn 1 phương tiện.");
                    return;
                }

                var vehicleID = long.Parse(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value.ToString());
                //check work-flow
                tblVehicle vehicle = VehicleFactory.GetByID(vehicleID);
                if (vehicle != null && vehicle.IsExport != true)
                {
                    MessageBox.Show("Xe này chưa được xuất cảnh, nên không thể nhập cảnh không hàng", "Lỗi trình tự");
                    return;
                }

                // Thảo mãn điều kiện kiểm tra hoặc xe xuất cảnh không có hàng, nhập cũng không có hàng
                if (IsCheck(vehicleID, VehicleCheckFactory.CHECK_TYPE_EXPORT) || IsExportNoGoods(vehicleID))
                {
                    // Show alert form
                    var frmAlert = new FrmAlert(_userInfo, vehicleID, _checkID, VehicleCheckFactory.CHECK_TYPE_EXPORT);
                    frmAlert.Show(this);
                    return;
                }

                var message = new StringBuilder();
                message.AppendLine("Thời gian nhập cảnh: " + CommonFactory.GetCurrentDate().ToString("dd/MM/yyyy HH:mm"));
                message.AppendLine("Nhập cảnh không có hàng, không thu phí");

                //var vehicle = VehicleFactory.GetByID(long.Parse(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value.ToString()));

                //if (MessageBox.Show(message.ToString(), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                var msgBox = new frmMessageBox(message.ToString());
                if (msgBox.ShowDialog() == DialogResult.Yes)
                {
                    vehicle.ImportDate = CommonFactory.GetCurrentDate();
                    vehicle.IsImport = true;
                    vehicle.HasGoodsImported = false;
                    if (vehicle.ConfirmImportBy != null && vehicle.ConfirmImportBy != 0 && vehicle.ConfirmImportBy != _userInfo.UserID)
                        throw new Exception("Phương tiện đã được xác nhận bởi một người dùng khác!");

                    vehicle.ConfirmImportBy = _userInfo.UserID;
                    vehicle.ImportStatus = "Nhập cảnh không có hàng";
                    vehicle.feeImportStatus = (int) FeeStatus.NotNeedPayFee;
                    VehicleFactory.UpdateVehicle(vehicle);
                }
                // Bind data
                BindData();

                //print ticket
                //printTicket(2, vehicle);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnLocalConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVehicle.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Bạn cần chọn 1 phương tiện.");
                    return;
                }
                var vehicleID = long.Parse(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value.ToString());

                //check work-flow
                tblVehicle vehicle = VehicleFactory.GetByID(vehicleID);
                //if (vehicle != null && vehicle.Parking == null)
                //{
                //  MessageBox.Show("Xe này chưa chưa vào bãi, nên không thể vào nội địa", "Lỗi trình tự");
                //  return;
                //}

                //check work-flow
                if (vehicle != null && vehicle.HasGoodsImported != true)
                {
                    MessageBox.Show("Xe này chưa nhập cảnh có hàng, nên không thể vào nội địa", "Lỗi trình tự");
                    return;
                }

                var message = new StringBuilder();

                message.AppendLine("Thời gian vào nội địa: " + CommonFactory.GetCurrentDate().ToString("dd/MM/yyyy HH:mm"));

                GetInfoVehicleDialog(message, vehicle, 1);

                //if (MessageBox.Show(message.ToString(), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                var msgBox = new frmMessageBox(message.ToString());
                if (msgBox.ShowDialog() == DialogResult.Yes)
                {
                    // Neu thoa man dieu kien canh bao, hoac la xe nay khong co to khai nhap, thi cung hien len canh bao
                    //neu da canh bao roi thi thoi khong canh bao nua
                    var vehicleCheck = VehicleCheckFactory.GetExistingVehicleHasChecked(vehicleID).FirstOrDefault();
                    if (IsCheck(vehicleID, VehicleCheckFactory.CHECK_TYPE_IMPORT_LOCAL) || (IsNotHasDeclerationImport(vehicleID) && vehicleCheck == null))
                    {
                        // Show alert form
                        var frmAlert = new FrmAlert(_userInfo, vehicleID, _checkID, VehicleCheckFactory.CHECK_TYPE_IMPORT_LOCAL);
                        frmAlert.Show(this);
                        return;
                    }

                    var vehicleInfo = VehicleFactory.GetByID(long.Parse(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value.ToString()));
                    vehicleInfo.IsGoodsImported = true;
                    vehicleInfo.ImportedLocalTime = CommonFactory.GetCurrentDate();
                    // is completed when user is confirm is local 
                    vehicleInfo.IsCompleted = true;

                    if (vehicleInfo.ConfirmLocalImportBy != null && vehicleInfo.ConfirmLocalImportBy != 0 && vehicleInfo.ConfirmLocalImportBy != _userInfo.UserID)
                        throw new Exception("Phương tiện đã được xác nhận bởi một người dùng khác!");

                    if (DeclarationVehicleFactory.IsExisting(vehicleInfo.VehicleID, 1)) // Neu ton tai thi xoa trong to khai 1
                    {
                        DeclarationVehicleFactory.DeleteByVehicleDeclarationID(vehicleInfo.VehicleID, 1);
                    }

                    vehicleInfo.ConfirmLocalImportBy = _userInfo.UserID;

                    VehicleFactory.UpdateVehicle(vehicleInfo);
                    // Bind data to gridview
                    BindData();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void cbIsCompleted_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsCompleted.Checked)
            {
                cbIsNotImport.Checked = false;
                cbIsNotImport.Enabled = false;
            }
            else
            {
                cbIsNotImport.Enabled = true;
            }
        }

        private void grdVehicle_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                logger.Info("grvDecleration_CellMouseClick");
                SetDeclerationInfo(grdVehicle.Rows[e.RowIndex]);

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
                if (grdVehicle.SelectedRows.Count > 0)
                {
                    var dr = MessageBox.Show("Bạn có chắc là muốn xóa?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        for (int i = 0; i < grdVehicle.SelectedRows.Count; i++)
                        {
                            var vehicleID = long.Parse(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value.ToString());
                            if (VehicleFactory.DeleteByID(vehicleID) > 0)
                                MessageBox.Show("Xóa xong");
                            else
                                MessageBox.Show("Xóa bị lỗi");
                        }
                        BindData();
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

        private void btnUpdateNoidia_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVehicle.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Bạn cần chọn 1 phương tiện.");
                    return;
                }

                var vehicleID = long.Parse(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value.ToString());
                if (IsCheck(vehicleID, VehicleCheckFactory.CHECK_TYPE_IMPORT_LOCAL))
                {
                    // Show alert form
                    FrmAlert frmAlert = new FrmAlert(_userInfo, vehicleID, _checkID, VehicleCheckFactory.CHECK_TYPE_IMPORT_LOCAL);
                    frmAlert.Show(this);
                    return;
                }

                var dateNoidia = Utilities.Common.AddHourMinutes(dtpNoidia.Value, hourNoidia.Text);

                var message = new StringBuilder();
                message.Append("Thời gian vào nội địa: " + dateNoidia.ToString("dd/MM/yyyy HH:mm"));

                //if (MessageBox.Show(message.ToString(), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                var msgBox = new frmMessageBox(message.ToString());
                if (msgBox.ShowDialog() == DialogResult.Yes)
                {
                    var vehicleInfo = VehicleFactory.GetByID(int.Parse(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value.ToString()));

                    vehicleInfo.ImportedLocalTime = dateNoidia;
                    VehicleFactory.UpdateVehicle(vehicleInfo);
                    BindData();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void listViewVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grdVehicle_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;
            //try
            //{
            //    logger.Info("grdVehicle_RowLeave");
            //    SetDeclerationInfo(grdVehicle.Rows[e.RowIndex]);
            //}
            //catch (Exception ex)
            //{
            //    logger.Error(ex.ToString());
            //    if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            //}
        }

        #region Check method
        private bool IsCheck(long vehicleID, int checkType)
        {
            //// Neu phuogn tien nay da duoc canh bao truoc do thi thoi, ko canh bao nua.
            //if (VehicleCheckFactory.IsExistingVehicle(vehicleID))
            //{
            //  return false;
            //}

            var currentDate = CommonFactory.GetCurrentDate();
            var checks =
                CheckFactory.SelectAll().Where(g => g.CheckFrom <= currentDate && currentDate <= g.CheckTo).ToList();
            if (checks.Count < 1) return false;

            var vehicles = DeclarationFactory.GetAllVehicleByVehicleID(vehicleID);
            // Return if donesn't any vehicle
            if (vehicles.Count < 1) return false;



            //bien xac dinh loai hinh check
            //=true neu can check ca xuat va nhap
            var checkImportAndExport = false;
            ViewAllCheck viewCheck = null;
            ViewAllCheck viewCheckImport = null;
            ViewAllCheck viewCheckExport = null;
            //lay danh sach cac canh bao phu hop voi phuong tien
            List<ViewAllCheck> listCheck = new List<ViewAllCheck>();
            foreach (var check in checks)
            {
                // Check by DeclarationNumber)
                foreach (var vehicle in vehicles)
                {
                    if (vehicle.Number != null && vehicle.Number.Equals(check.DeclarationNumber))
                    {
                        if (listCheck.Contains(check) == false)
                        {
                            listCheck.Add(check);
                            if (check.DeclarationType == CheckFactory.DECLARATION_TYPE_EXPORT_AND_IMPORT)
                            {
                                checkImportAndExport = true;
                                viewCheck = check;
                            }
                            if (check.DeclarationType == CheckFactory.DECLARATION_TYPE_EXPORT)
                            {
                                viewCheckExport = check;
                            }
                            if (check.DeclarationType == CheckFactory.DECLARATION_TYPE_IMPORTT)
                            {
                                viewCheckImport = check;
                            }
                        }
                    }

                    if (vehicle.PlateNumber.ToUpper().Equals(check.PlateNumber.ToUpper()))
                    {
                        if (listCheck.Contains(check) == false)
                        {
                            listCheck.Add(check);
                            if (check.DeclarationType == CheckFactory.DECLARATION_TYPE_EXPORT_AND_IMPORT)
                            {
                                checkImportAndExport = true;
                                viewCheck = check;
                            }
                            if (check.DeclarationType == CheckFactory.DECLARATION_TYPE_EXPORT)
                            {
                                viewCheckExport = check;
                            }
                            if (check.DeclarationType == CheckFactory.DECLARATION_TYPE_IMPORTT)
                            {
                                viewCheckImport = check;
                            }
                        }
                    }
                }
            }

            var vehicleCheck = VehicleCheckFactory.GetExistingVehicleHasChecked(vehicleID).FirstOrDefault();
            //neu phuong tien can check ca nhap canh va xuat canh
            if (checkImportAndExport == true)
            {
                //neu phuong tien chua duoc check lan nao
                if (vehicleCheck == null)
                {
                    _checkID = viewCheck.CheckID;
                    return true;
                }
                else //neu phuong tien da duoc checked
                {
                    //kiem tra dieu kien doi voi Xuat canh
                    if (vehicleCheck.IsExportChecked != true && checkType == VehicleCheckFactory.CHECK_TYPE_EXPORT)
                    {
                        _checkID = viewCheck.CheckID;
                        return true;
                    }

                    //kiem tra dieu kien voi nhap canh
                    if (vehicleCheck.IsImportChecked != true && checkType == VehicleCheckFactory.CHECK_TYPE_IMPORT)
                    {
                        _checkID = viewCheck.CheckID;
                        return true;
                    }

                    //kiem tra dieu kien voi hang vao noi dia

                    if (vehicleCheck.IsLocalImportChecked != true && checkType == VehicleCheckFactory.CHECK_TYPE_IMPORT_LOCAL)
                    {
                        _checkID = viewCheck.CheckID;
                        return true;
                    }

                }
                //var vehicleCheck = VehicleCheckFactory.GetExistingVehicleHasChecked(vehicleID);
                //// TODO: Need to vertify
                //if (vehicleCheck.Count == 0 || (vehicleCheck.Count == 1 && (vehicles[0].IsExport != null && vehicles[0].IsExport.Value)) || (vehicleCheck.Count == 2 && (vehicles[0].IsImport != null && vehicles[0].IsImport.Value)))
                //{
                //  _checkID = viewCheck.CheckID;
                //  _vehicleId = vehicleID;
                //  return true;
                //}
                //else
                //{
                //  return false;
                //}
            }
            //neu la nhap canh hoac xac nhan hang vao noi dia, phai kiem tra 2 lan
            else if (viewCheckImport != null && (checkType == VehicleCheckFactory.CHECK_TYPE_IMPORT || checkType == VehicleCheckFactory.CHECK_TYPE_IMPORT_LOCAL))
            {
                //kiem tra dieu kien voi nhap canh
                if (vehicleCheck == null || (vehicleCheck.IsImportChecked != true && checkType == VehicleCheckFactory.CHECK_TYPE_IMPORT))
                {
                    _checkID = viewCheckImport.CheckID;
                    return true;
                }

                //kiem tra dieu kien voi hang vao noi dia
                if (vehicleCheck == null || (vehicleCheck.IsLocalImportChecked != true && checkType == VehicleCheckFactory.CHECK_TYPE_IMPORT_LOCAL))
                {
                    _checkID = viewCheckImport.CheckID;
                    return true;
                }
            }
            else if (viewCheckExport != null) //truong hop con lai, chi check xuat canh
            {
                // Neu phuogn tien nay da duoc canh bao truoc do thi thoi, ko canh bao nua.
                if (VehicleCheckFactory.IsExistingVehicle(vehicleID))
                {
                    return false;
                }
                _checkID = viewCheckExport.CheckID;
                return true;
            }
            //else if(listCheck !=null && listCheck.Count >0)
            //{
            //  // Neu phuogn tien nay da duoc canh bao truoc do thi thoi, ko canh bao nua.
            //  if (VehicleCheckFactory.IsExistingVehicle(vehicleID))
            //  {
            //    return false;
            //  }
            //  _checkID = listCheck.FirstOrDefault().CheckID;
            //  return true;
            //}

            return false;


            //foreach (var check in checks)
            //{
            //  // Check by DeclarationNumber)
            //  foreach (var vehicle in vehicles)
            //  {

            //    //// Neu phuogn tien nay da duoc canh bao truoc do thi thoi, ko canh bao nua.
            //    if (VehicleCheckFactory.IsExistingVehicle(vehicleID))
            //    {
            //      if (vehicle.Number.Equals(check.DeclarationNumber) && (check.DeclarationType == CheckFactory.DECLARATION_TYPE_EXPORT_AND_IMPORT))
            //      {
            //        tblVehicle vehicleObj = VehicleFactory.GetByID(vehicle.VehicleID);
            //        if (vehicleObj.IsExport == true && (vehicleObj.IsImport == true || vehicleObj.HasGoodsImported == true))
            //        {
            //          return false;
            //        }
            //        _checkID = check.CheckID;
            //        return true;
            //      }
            //      else
            //      {
            //        return false;
            //      }
            //    }



            //    //if (vehicle.RegisterDate.HasValue && check.RegisterDate.HasValue && vehicle.RegisterDate.Value.Day.Equals(check.RegisterDate.Value.Day) && vehicle.RegisterDate.Value.Month.Equals(check.RegisterDate.Value.Month) && vehicle.RegisterDate.Value.Year.Equals(check.RegisterDate.Value.Year))
            //    //  return true;
            //  }

            //  // Check by PlateNumber
            //  if (vehicles[0].PlateNumber.Equals(check.PlateNumber))
            //  {
            //    _checkID = check.CheckID;
            //    return true;
            //  }

            //}

            //return false;
        }


        //#region Check method
        //private bool IsCheck(long vehicleID)
        //{
        //   // Neu phuogn tien nay da duoc canh bao truoc do thi thoi, ko canh bao nua.
        //  if (VehicleCheckFactory.IsExistingVehicleInBothImportAndExport(vehicleID))
        //  {
        //    return false;
        //  }

        //   if (VehicleCheckFactory.IsExistingVehicle(vehicleID))
        //     return false;
        //   var currentDate = CommonFactory.GetCurrentDate();
        //   var checks =
        //       CheckFactory.SelectAll().Where(g => g.CheckFrom <= currentDate && currentDate <= g.CheckTo).ToList();
        //   if (checks.Count < 1) return false;

        //   var vehicles = DeclarationFactory.GetAllVehicleByVehicleID(vehicleID);
        //   // Return if donesn't any vehicle
        //   if (vehicles.Count < 1) return false;

        //   foreach (var check in checks)
        //   {
        //       // Check by DeclarationNumber)
        //       foreach (var vehicle in vehicles)
        //       {
        //           if(vehicle.Number.Equals(check.DeclarationNumber) && vehicle.DeclarationType.Equals(check.DeclarationType))
        //           {
        //              if ((VehicleCheckFactory.IsExistingVehicle(vehicleID)) && (check.DeclarationType != CheckFactory.DECLARATION_TYPE_EXPORT_AND_IMPORT))
        //              {
        //                return false;
        //              }

        //               _checkID = check.CheckID;
        //               return true;
        //           }

        //           //if (vehicle.RegisterDate.HasValue && check.RegisterDate.HasValue && vehicle.RegisterDate.Value.Day.Equals(check.RegisterDate.Value.Day) && vehicle.RegisterDate.Value.Month.Equals(check.RegisterDate.Value.Month) && vehicle.RegisterDate.Value.Year.Equals(check.RegisterDate.Value.Year))
        //             //  return true;
        //       }

        //       // Check by PlateNumber
        //       if (vehicles[0].PlateNumber.Equals(check.PlateNumber))
        //       {
        //          if ((VehicleCheckFactory.IsExistingVehicle(vehicleID)) && (check.DeclarationType != CheckFactory.DECLARATION_TYPE_EXPORT_AND_IMPORT))
        //          {
        //             return false;
        //          }
        //           _checkID = check.CheckID;
        //           return true;
        //       }

        //   }

        //   return false;
        //}

        /// <summary>
        /// Return true, nếu xe này xuất cảnh xe không, nhưng nhập cảnh cũng không có hàng
        /// </summary>
        /// <param name="vehicleID"></param>
        /// <returns></returns>
        private bool IsExportNoGoods(long vehicleID)
        {
            // Neu phuogn tien nay da duoc canh bao truoc do thi thoi, ko canh bao nua.
            if (VehicleCheckFactory.IsExistingVehicle(vehicleID)) return false;

            var listVehicle = DeclarationFactory.GetAllVehicleByVehicleID(vehicleID);
            // Đối với xe không chở hàng xuất cảnh, không trở hạng nhập cảnh. Tức là đi xe không về xe không --> Show cảnh báo.

            if (listVehicle.Count < 1) return false;
            foreach (var vehicle in listVehicle)
            {
                if (vehicle.Number < 1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Kie tra xem xe hien tai da co to khai nhap chua
        /// return true neu chua co to khai nhap
        /// return false neu co to khai nhap
        /// </summary>
        /// <param name="vehicleID"></param>
        /// <returns></returns>
        private bool IsNotHasDeclerationImport(long vehicleID)
        {
            var listVehicle = DeclarationFactory.GetAllVehicleByVehicleID(vehicleID);
            //Chi can xe nay nam trong 1 to khai nhap canh, thi xe nay duoc coi la co to khai nhap
            foreach (var vehicle in listVehicle)
            {
                //neu da nhap canh, va co to khai nhap
                //vehicle.Number = 0: la xe khong
                //vehicle.Number= 1 : la xe khong nhap canh nhung lai kong co to khai nhap
                if (vehicle.IsImport == true && vehicle.DeclarationType == 1 && vehicle.DeclarationID > 1)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Kie tra xem xe hien tai da co to khai nhap chua
        /// </summary>
        /// <param name="vehicleID"></param>
        /// <returns></returns>
        //private bool IsNotHasDeclerationImport(long vehicleID)
        //{
        //    var listVehicle = DeclarationFactory.GetAllVehicleByVehicleID(vehicleID);
        //    foreach (var vehicle in listVehicle)
        //    {

        //        // Chua dc nhap canh, da nhap canh nhung chua co to khai nhap
        //        if (vehicle.IsImport == null || !vehicle.IsImport.Value || (vehicle.IsImport.Value && vehicle.DeclarationType != 1 &&  vehicle.Number != 0 ) )
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        #endregion

        private void grdVehicle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnParking_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVehicle.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Bạn cần chọn 1 phương tiện.");
                    return;
                }

                var vehicleInfo = VehicleFactory.GetByID(long.Parse(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value.ToString()));
                //check work-flow
                if (vehicleInfo != null && vehicleInfo.HasGoodsImported != true)
                {
                    MessageBox.Show("Xe này chưa nhập cảnh có hàng, nên không thể vào bãi", "Lỗi trình tự");
                    return;
                }

                vehicleInfo.Parking = "Hàng đã vào bãi";
                vehicleInfo.ParkingDate = CommonFactory.GetCurrentDate();
                VehicleFactory.UpdateVehicle(vehicleInfo);
                // Bind data to gridview
                BindData();

                //print ticket
                if (_printSetting != null && _printSetting.PrintParking == true)
                {
                    if (vehicleInfo.ParkingTotalPrint != null)
                    {
                        if (MessageBox.Show("Xe này đã in phiếu rồi. Bạn có muốn in lại", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            printTicket(3, vehicleInfo);
                        }
                    }
                    else
                    {
                        printTicket(3, vehicleInfo);
                    }

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void cbParking_CheckedChanged(object sender, EventArgs e)
        {
            if (cbParking.Checked == true)
            {
                dtpPackingDateFrom.Enabled = true;
                dtpPackingDateTo.Enabled = true;
            }
            else
            {
                dtpPackingDateFrom.Enabled = false;
                dtpPackingDateTo.Enabled = false;
            }
        }

        private void printTicket(int printType, tblVehicle vehicleInfo)
        {
            //print khi xuat canh
            //print ticket report
            List<viewDeclarationVehicle> listViewDeclarationVehicle = VehicleFactory.GetImportDeclarationVehicleByVehicleID(vehicleInfo.VehicleID);
            vehicleTicket = new ECustoms.vehicleTicket();
            var txtPrintUser = (TextObject)vehicleTicket.Section1.ReportObjects["txtPrintUser"];
            var txtPrintType = (TextObject)vehicleTicket.Section1.ReportObjects["txtPrintType"];
            var txtVehicleNumber = (TextObject)vehicleTicket.Section1.ReportObjects["txtVehicleNumber"];
            var txtVehicleType = (TextObject)vehicleTicket.Section1.ReportObjects["txtVehicleType"];
            var txtExportDate = (TextObject)vehicleTicket.Section1.ReportObjects["txtExportDate"];
            var txtImportDate = (TextObject)vehicleTicket.Section1.ReportObjects["txtImportDate"];
            var txtParkingDate = (TextObject)vehicleTicket.Section1.ReportObjects["txtParkingDate"];
            var txtDecleNumber = (TextObject)vehicleTicket.Section1.ReportObjects["txtDecleNumber"];
            var txtType = (TextObject)vehicleTicket.Section1.ReportObjects["txtType"];
            var txtRegisterDate = (TextObject)vehicleTicket.Section1.ReportObjects["txtRegisterDate"];
            var txtCompany = (TextObject)vehicleTicket.Section1.ReportObjects["txtCompany"];
            var txtGoodName = (TextObject)vehicleTicket.Section1.ReportObjects["txtGoodName"];
            var txtAmount = (TextObject)vehicleTicket.Section1.ReportObjects["txtAmount"];
            var txtUnit = (TextObject)vehicleTicket.Section1.ReportObjects["txtUnit"];
            var txtBarcode = (TextObject)vehicleTicket.Section1.ReportObjects["txtBarcode"];
            var txtSTT = (TextObject)vehicleTicket.Section1.ReportObjects["txtSTT"];
            var txtTotalPrintVehicleTicketOfDay = (TextObject)vehicleTicket.Section1.ReportObjects["txtTotalPrintVehicleTicketOfDay"];
            var txtPrintDate = (TextObject)vehicleTicket.Section1.ReportObjects["txtPrintDate"];

            txtVehicleNumber.Text = vehicleInfo.PlateNumber;

            if(vehicleInfo.vehicleTypeId !=null && vehicleInfo.vehicleTypeId>0)
            {
                tblVehicleType vehicleType = VehicleTypeFactory.FindById(vehicleInfo.vehicleTypeId.GetValueOrDefault());
                if(vehicleType!=null)
                {
                    txtVehicleType.Text = vehicleType.Name;
                }
                else
                {
                    txtVehicleType.Text = "Không phân loại";
                }
            }
            else
            {
                txtVehicleType.Text = "Không phân loại";
            }

            if (vehicleInfo.ExportDate != null)
            {
                txtExportDate.Text = ((DateTime)vehicleInfo.ExportDate).ToString("dd/MM/yyyy HH:mm");
            }
            if (vehicleInfo.ImportDate != null)
            {
                txtImportDate.Text = ((DateTime)vehicleInfo.ImportDate).ToString("dd/MM/yyyy HH:mm");
            }
            if (vehicleInfo.ParkingDate != null)
            {
                txtParkingDate.Text = ((DateTime)vehicleInfo.ParkingDate).ToString("dd/MM/yyyy HH:mm");
            }
            //string listDeclarationNumber = "";
            //foreach (viewDeclarationVehicle view in listViewDeclarationVehicle)
            //{
            //  listDeclarationNumber += view.Number + "; ";
            //}
            //if (string.IsNullOrEmpty(listDeclarationNumber) == false)
            //{
            //  listDeclarationNumber.Remove(listDeclarationNumber.Length - 2, 1);
            //  txtDecleNumber.Text = listDeclarationNumber;
            //}

            viewDeclarationVehicle viewVehicle = listViewDeclarationVehicle.FirstOrDefault();
            if (viewVehicle != null)
            {
                txtDecleNumber.Text = viewVehicle.Number + "";
                txtType.Text = viewVehicle.Type;
                if (viewVehicle.RegisterDate != null)
                {
                    txtRegisterDate.Text = ((DateTime)viewVehicle.RegisterDate).ToString("dd/MM/yyyy HH:mm");
                }

                txtCompany.Text = viewVehicle.CompanyName;
                txtGoodName.Text = viewVehicle.ProductName;
                txtAmount.Text = viewVehicle.ProductAmount;
                txtUnit.Text = viewVehicle.Unit;
            }

            txtPrintUser.Text = _userInfo.Name;

            
            switch (printType)
            {
                case 1:
                    txtPrintType.Text = "Xuất cảnh";
                    break;
                case 2:
                    txtPrintType.Text = "Nhập cảnh";
                    if (vehicleInfo.HasGoodsImportedTocalPrint != null)
                    {
                        //tang so lan in
                        vehicleInfo.HasGoodsImportedTocalPrint = vehicleInfo.HasGoodsImportedTocalPrint + 1;
                    }
                    else
                    {
                        //in lan dau tien
                        vehicleInfo.HasGoodsImportedTocalPrint = 1;

                        //update tong so lan print ticket trong 1 ngay
                        long orderNumber = updateTotalTicketPrint();

                        //cap nhat so tu thu in cua xe
                        vehicleInfo.HasGoodsImportedPrintOrderNumber = orderNumber;

                    }
                    txtSTT.Text = vehicleInfo.HasGoodsImportedTocalPrint.ToString();
                    txtTotalPrintVehicleTicketOfDay.Text = vehicleInfo.HasGoodsImportedPrintOrderNumber.GetValueOrDefault().ToString();
                    break;
                case 3:
                    txtPrintType.Text = "Xác nhận hàng vào bãi";
                    if (vehicleInfo.ParkingTotalPrint != null)
                    {
                        //tang so lan in
                        vehicleInfo.ParkingTotalPrint = vehicleInfo.ParkingTotalPrint + 1;
                    }
                    else
                    {
                        //in lan dau tien
                        vehicleInfo.ParkingTotalPrint = 1;

                        //update tong so lan print ticket trong 1 ngay
                        long orderNumber= updateTotalTicketPrint();

                        //cap nhat so tu thu in cua xe
                        vehicleInfo.ParkingTotalPrintOrderNumber = orderNumber;
                    }
                    txtSTT.Text = vehicleInfo.ParkingTotalPrint.ToString();
                    txtTotalPrintVehicleTicketOfDay.Text = vehicleInfo.ParkingTotalPrintOrderNumber.GetValueOrDefault().ToString();
                    break;
            }

            txtBarcode.Text = "*" + vehicleInfo.PlateNumber + "*";
            DateTime currentDate = CommonFactory.GetCurrentDate();
            //cap nhat so lan in ticket cua phuong tien vao CSDL

            VehicleFactory.UpdateTicketTotalPrint(vehicleInfo);

            txtPrintDate.Text = currentDate.ToString("dd/MM/yyyy HH:mm");

            //preview ticket
            //var report = new FrmCrystalReport(vehicleTicket, _userInfo);
            //report.MaximizeBox = true;
            //report.Show(this);

            //Print ticket directly
            vehicleTicket.ExportToDisk(ExportFormatType.CrystalReport, "VehicleTicket.rpt");

            foreach (String printerName in _printSetting.ListPrinter)
            {
                try
                {
                    AutoPrintReport(printerName, "VehicleTicket.rpt");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không kết nối được với máy in: " + printerName);
                }
            }

            return;
        }

        //cap nhat so thu tu cua ticket
        //day la tong so lan in ticket trong 1 ngay
        private long updateTotalTicketPrint()
        {
            return ApplicationObjectFactory.updateTotalTicketPrint(ApplicationObjectFactory.TOTAL_TICKET_IN_DATE);
        }

        private void AutoPrintReport(string printerName, String reportFileURL)
        {
            //PageMargins margins;
            ReportDocument Report = new ReportDocument();

            //VehicleInputTicket ticket = new VehicleInputTicket();
            //ticket.ExportToDisk(ExportFormatType.CrystalReport, "VehicleTicket.rpt");
            Report.Load(reportFileURL);

            // Select the printer.
            Report.PrintOptions.PrinterName = printerName;

            // Print the report. Set the startPageN and endPageN
            // parameters to 0 to print all pages.
            Report.PrintToPrinter(1, false, 0, 0);
        }

        private void cbIsChineseVehicle_CheckedChanged(object sender, EventArgs e)
        {
            EnabledImport(true);
            EnableExport(false);
            cbIsExport.Checked = cbIsNotImport.Checked = cbIsNotImport.Enabled = false;
            cbIsImport.Checked = true;

            txtPlateNumberChinese.Visible = lblPlateNumberChinese.Visible = grdVehicle.Columns["PlateNumberPartner"].Visible = !cbIsChineseVehicle.Checked;
            BindData();
            if (grdVehicle.Rows.Count > 0) // Set focus
            {
                btnXacNhanXuatCanh.Focus();
            }
        }

    }
}
