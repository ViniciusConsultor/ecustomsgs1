﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.DAL;
using ECustoms.Utilities;

namespace ECustoms
{
    public partial class FrmDecleExport : Form
    {
        #region Private variables
        private int _mode;
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("Ecustoms.FrmDecleExport");
        private List<ViewAllVehicleHasGood> _vehicleInfosTemp = new List<ViewAllVehicleHasGood>(); // This variable is used to store data in the gridview
        private long _declerationID;
        private UserInfo _userInfo;
        private Form _mainForm;
        private Common.DeclerationType _declerationType;
        #endregion

        public FrmDecleExport(UserInfo userInfo, int mode, Common.DeclerationType declerationType, Form mainForm)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _mode = mode;
            _mainForm = mainForm;
            _declerationType = declerationType;
        }

        public FrmDecleExport(Form mainForm, UserInfo userInfo, int mode, long declerationID, Common.DeclerationType declerationType)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _mode = mode;
            _declerationID = declerationID;
            _mainForm = mainForm;
            _declerationType = declerationType;
        }

        public FrmDecleExport(UserInfo userInfo, Form mainForm)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _mainForm = mainForm;
        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                var declarationInfo = new tblDeclaration();
                if (!string.IsNullOrEmpty(txtExportNumber.Text))
                {
                    declarationInfo.Number = Convert.ToInt32(txtExportNumber.Text);
                }
                declarationInfo.CreatedDate = CommonFactory.GetCurrentDate();
                declarationInfo.ProductName = txtExportProductName.Text;
                declarationInfo.ProductAmount = txtProductAmount.Text;
                // Add Mode
                if (_mode == 0)
                {
                    var vehicle = new frmVehicle(0, _mainForm, ref _vehicleInfosTemp, declarationInfo, _userInfo);
                    vehicle.Show(this);
                }
                else
                {
                    declarationInfo = DeclarationFactory.GetByID(_declerationID);
                    if (!string.IsNullOrEmpty(txtExportNumber.Text))
                    {
                        declarationInfo.Number = Convert.ToInt32(txtExportNumber.Text);
                    }
                    declarationInfo.CreatedDate = CommonFactory.GetCurrentDate();
                    declarationInfo.ProductName = txtExportProductName.Text;
                    declarationInfo.ProductAmount = txtProductAmount.Text;
                    // Update Mode
                    var vehicle = new frmVehicle(4, _mainForm, ref _vehicleInfosTemp, declarationInfo, _userInfo);
                    vehicle.Show(this);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate()) return;
                var declaratioInfo = new tblDeclaration();
                var declarationInfo = GetDeclarationInfo(ref declaratioInfo);
                var listVehicleInfo = new List<tblVehicle>();
                var listVehicleUpdate = new List<tblVehicle>();
                tblVehicle vehicleInfo;
                // Validate Vehicle information
                if (grdVehicle.Rows.Count > 0)
                {
                    for (int i = 0; i < grdVehicle.Rows.Count; i++)
                    {
                        if (grdVehicle.Rows[i].Cells["VehicleID"].Value != null && Convert.ToInt64(grdVehicle.Rows[i].Cells["VehicleID"].Value) > 0) // Update this vehicle only.
                        {
                            // Get vehcleInfor from database
                            vehicleInfo = VehicleFactory.GetByID(Convert.ToInt64(grdVehicle.Rows[i].Cells["VehicleID"].Value));
                        }
                        else
                        {
                            vehicleInfo = new tblVehicle();
                        }


                        // Do not save the record that platNumber is empty
                        if (grdVehicle.Rows[i].Cells["PlateNumber"].Value != null && grdVehicle.Rows[i].Cells["PlateNumber"].Value != "")
                        {
                            vehicleInfo.PlateNumber = grdVehicle.Rows[i].Cells["PlateNumber"].Value.ToString();
                        }
                        else // Don't insert the record that the platnumber is null
                        {
                            continue;
                        }

                        if (grdVehicle.Rows[i].Cells["NumberOfContainer"].Value != null)
                            vehicleInfo.NumberOfContainer = grdVehicle.Rows[i].Cells["NumberOfContainer"].Value.ToString();

                        if (grdVehicle.Rows[i].Cells["DriverName"].Value != null)
                            vehicleInfo.DriverName = grdVehicle.Rows[i].Cells["DriverName"].Value.ToString();

                        if (grdVehicle.Rows[i].Cells["IsExport"].Value != null)
                            vehicleInfo.IsExport = Convert.ToBoolean(grdVehicle.Rows[i].Cells["IsExport"].Value);

                        // Set Export Date
                        if (vehicleInfo.IsExport != null && vehicleInfo.IsExport.Value && grdVehicle.Rows[i].Cells["ExportDate"].Value != null)
                        {
                            vehicleInfo.ExportDate = Convert.ToDateTime(grdVehicle.Rows[i].Cells["ExportDate"].Value);
                        }

                        if (grdVehicle.Rows[i].Cells["IsImport"].Value != null)
                            vehicleInfo.IsImport = Convert.ToBoolean(grdVehicle.Rows[i].Cells["IsImport"].Value);

                        // Set Import Date
                        if (vehicleInfo.IsImport != null && vehicleInfo.IsImport.Value && grdVehicle.Rows[i].Cells["ImportDate"].Value != null)
                        {
                            vehicleInfo.ImportDate = Convert.ToDateTime(grdVehicle.Rows[i].Cells["ImportDate"].Value);
                        }

                        if (grdVehicle.Rows[i].Cells["Note"].Value != null)
                            vehicleInfo.Note = grdVehicle.Rows[i].Cells["Note"].Value.ToString();
                        if (grdVehicle.Rows[i].Cells["Status"].Value != null)
                            vehicleInfo.Status = grdVehicle.Rows[i].Cells["Status"].Value.ToString();

                        if (grdVehicle.Rows[i].Cells["VehicleID"].Value != null && Convert.ToInt64(grdVehicle.Rows[i].Cells["VehicleID"].Value) > 0) // Update this vehicle only.
                        {

                            listVehicleUpdate.Add(vehicleInfo);
                            continue;
                        }

                        // If this vehicle is set import/export, set the confirmImport by /confirmExpor by
                        if (vehicleInfo.IsExport != null && vehicleInfo.IsExport.Value)
                        {
                            vehicleInfo.ConfirmExportBy = _userInfo.UserID;
                        }

                        if (vehicleInfo.IsImport != null && vehicleInfo.IsImport.Value)
                        {
                            vehicleInfo.ConfirmImportBy = _userInfo.UserID;
                        }

                        // Add to list vehicles
                        listVehicleInfo.Add(vehicleInfo);

                    } // End for
                }
                // TODO: Need to check return value
                DeclarationFactory.AddDeclaration(declarationInfo, listVehicleInfo, listVehicleUpdate, _userInfo.UserID);
                MessageBox.Show(ConstantInfo.MESSAGE_INSERT_SUCESSFULLY);

                switch (this.Owner.Name.ToUpper())
                {
                    case "FRMDECLERATION":
                        {
                            // Bind data to the gridivew
                            ((frmDecleration)Owner).BindData();
                            // close the form
                            //this.Close();
                        }
                        break;
                    case "FRMMAINFORM":
                        {
                            // Just close from if this form is opened from main from
                            //this.Close();
                        }
                        break;
                    default:
                        break;
                }

                // Reset form
                ResetForm();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        #region Private methods

        /// <summary>
        /// Get information from UI        
        /// </summary>
        /// <returns></returns>
        private tblDeclaration GetDeclarationInfo(ref tblDeclaration declarationInfo)
        {
            declarationInfo.DeclarationType = (short)_declerationType;
            declarationInfo.Number = !string.IsNullOrEmpty(txtExportNumber.Text) ? Convert.ToInt32(txtExportNumber.Text.Trim()) : 0;
            declarationInfo.Type = txtTypeExport.Text.Trim();
            declarationInfo.CompanyName = txtExportCompanyName.Text;
            declarationInfo.CompanyCode = txtExportCompanyCode.Text;
            declarationInfo.RegisterDate = dtpExportRegisterDate.Value;
            declarationInfo.ProductAmount = txtProductAmount.Text.Trim();
            declarationInfo.Unit = txtExportUnit.Text.Trim();
            declarationInfo.ProductName = txtExportProductName.Text;
            declarationInfo.ModifiedByID = _userInfo.UserID;
            //declarationInfo.ModifiedDate = CommonFactory.GetCurrentDate();
            //declarationInfo.CreatedDate = CommonFactory.GetCurrentDate();
            declarationInfo.RegisterPlace = txtRegisterPlace.Text.Trim();
            declarationInfo.Money = !string.IsNullOrEmpty(txtMoney.Text) ? Convert.ToInt32(txtMoney.Text.Trim()) : 0;
            declarationInfo.TypeOption = short.Parse(((ComboBoxItem)cbTNTX.SelectedItem).Value);
            if (cbTNTX.SelectedIndex > 0 && pnTXTN.Visible)
            {
                if (!string.IsNullOrEmpty(txtNumberHandover.Text.Trim()))
                {
                    declarationInfo.NumberHandover = int.Parse(txtNumberHandover.Text.Trim());
                }
                declarationInfo.DateHandover = dtpHandover.Value;
                declarationInfo.PersonHandoverID = _userInfo.UserID;
            }
            if (!string.IsNullOrEmpty(txtNumberTemp.Text.Trim()))
                declarationInfo.NumberTemp = txtNumberTemp.Text.Trim();
            return declarationInfo;
        }

        private void ResetForm()
        {
            txtExportNumber.Text = "";
            txtExportProductName.Text = "";
            txtExportCompanyName.Text = "";
            txtProductAmount.Text = "";
            txtExportUnit.Text = "";
            txtExportTotalVehicles.Text = "";
            txtTypeExport.Text = string.Empty;
            grdVehicle.DataSource = null;
            _vehicleInfosTemp.Clear();
            txtExportCompanyCode.Text = "";
            dtpExportRegisterDate.Value = DateTime.Now;
            txtMoney.Text = "";
            txtRegisterPlace.Text = "B15E-Chi cục Hải quan Tân Thanh";
            cbTNTX.SelectedIndex = 0;
            txtNumberTemp.Text = "";
        }

        private bool Validate()
        {
            // Validate export declaration
            if (string.IsNullOrEmpty(txtExportNumber.Text.Trim()))
            {
                MessageBox.Show(ConstantInfo.MESSAGE_BLANK_DECLARATION_NUMBER);
                txtExportNumber.Focus();
                return false;
            }
            // Không lưu khi tờ khai không có phương tiện nào
            if (grdVehicle.Rows.Count < 1)
            {
                MessageBox.Show(ConstantInfo.MESSAGE_NO_VEHICLE);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Personal check
        /// </summary>
        //private void InitialPermission()
        //{
        //    //throw new NotImplementedException();

        //    switch (_userInfo.Type)
        //    {
        //        case UserType.Admin:
        //            break;
        //        case UserType.Confirm:
        //            if (_mode == 0)
        //                btnDeleteVehicle.Enabled = true;
        //            else
        //                btnDeleteVehicle.Enabled = false;
        //            break;
        //        case UserType.Input:
        //            btnComfirmExport.Enabled = false;
        //            btnConfirmImportKH.Enabled = false;
        //            btnConfirmImportKH.Enabled = false;
        //            break;
        //    }
        //}

        /// <summary>
        /// Init data
        /// </summary>
        private void Init()
        {
            //Autocomplete registerplace
            var auto = new AutoCompleteStringCollection();
            var lstAuto = DeclarationFactory.GetAllRegisterPlace();
            auto.AddRange(lstAuto.ToArray());
            txtRegisterPlace.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtRegisterPlace.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtRegisterPlace.AutoCompleteCustomSource = auto;

            //Autocomplete type export
            var autoType = new AutoCompleteStringCollection();
            autoType.AddRange(DeclarationFactory.GetAllTypeExport().ToArray());
            txtTypeExport.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTypeExport.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTypeExport.AutoCompleteCustomSource = autoType;

            grdVehicle.AutoGenerateColumns = false;
            //Init data for cbTNTX
            var listTNTX = new List<ComboBoxItem>();
            listTNTX.Add(new ComboBoxItem("0", "Tất cả"));
            listTNTX.Add(new ComboBoxItem("1", "XK chuyển CK"));
            listTNTX.Add(new ComboBoxItem("2", "NK chuyển CK"));
            listTNTX.Add(new ComboBoxItem("3", "Tạm nhập tái xuất"));
            cbTNTX.Items.AddRange(listTNTX.ToArray());

            if (_declerationType.Equals(Common.DeclerationType.Export))
            {
                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#ffc0c0");
                this.BackColor = col;
                lblHeader.Text = "Khai báo xuất cảnh";
                gbExportDeclaration.Text = "Thông tin tờ khai xuất khẩu";
                btnAddExisting.Enabled = false;
                bntConfirmImportCH.Visible = false;
                btnConfirmImportKH.Visible = false;
                btnComfirmExport.Visible = true;
                btnComfirmExport.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_XUAT_CANH);
                cbTNTX.Items.RemoveAt(3);
                cbTNTX.Items.RemoveAt(2);

            }
            else
            {
                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#c1ffc0");
                this.BackColor = col;
                lblHeader.Text = "Khai báo nhập cảnh";
                gbExportDeclaration.Text = "Thông tin tờ khai nhập khẩu";
                btnAddExisting.Enabled = true;
                btnAddExisting.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_THEM_PHUONG_TIEN_CHO_TO_KHAI_NHAP_CANH);
                bntConfirmImportCH.Visible = true;
                bntConfirmImportCH.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_NHAP_CANH);
                bntConfirmImportCH.Location = new Point(783, 25);
                btnConfirmImportKH.Visible = true;
                btnConfirmImportKH.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_NHAP_CANH);
                btnConfirmImportKH.Location = new Point(783, 81);
                btnComfirmExport.Enabled = false;
                btnAdd.Enabled = false;
                // Invisible luong xe
                lblTotalVehicles.Visible = false;
                txtExportTotalVehicles.Visible = false;
                cbTNTX.Items.RemoveAt(1);
            }

            // New mode))
            if (this._mode == 0)
            {
                cbTNTX.SelectedIndex = 0;
                btnUpdate.Enabled = false;
                btnAdd.Enabled = true;
                btnAdd.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_TO_KHAI);
            }
            else // Edit mode
            {
                btnUpdate.Enabled = true;
                btnUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_TO_KHAI);
                btnAdd.Enabled = false;

                // Get Decleration information
                var declarationInfo = DeclarationFactory.GetByID(this._declerationID);
                // Bind Declaration to controls
                if (declarationInfo != null)
                {
                    txtExportNumber.Text = declarationInfo.Number.ToString();
                    txtExportProductName.Text = declarationInfo.ProductName;
                    txtExportCompanyName.Text = declarationInfo.CompanyName;
                    txtProductAmount.Text = declarationInfo.ProductAmount;
                    txtExportUnit.Text = declarationInfo.Unit;
                    txtTypeExport.Text = declarationInfo.Type;
                    txtExportCompanyCode.Text = declarationInfo.CompanyCode;
                    dtpExportRegisterDate.Value = declarationInfo.RegisterDate != null ? declarationInfo.RegisterDate.Value : CommonFactory.GetCurrentDate();
                    txtRegisterPlace.Text = declarationInfo.RegisterPlace;
                    txtMoney.Text = declarationInfo.Money.ToString();
                    cbTNTX.SelectedItem = declarationInfo.TypeOption != null ? listTNTX[(int)declarationInfo.TypeOption] : listTNTX[0];
                    if (cbTNTX.SelectedIndex > 0)
                    {
                        pnTXTN.Visible = true;
                        txtNumberHandover.Text = declarationInfo.NumberHandover != null ? declarationInfo.NumberHandover.ToString() : "";
                        dtpHandover.Value = declarationInfo.DateHandover != null ? declarationInfo.DateHandover.Value : CommonFactory.GetCurrentDate();
                    }
                    txtNumberTemp.Text = declarationInfo.NumberTemp ?? "";
                }
                // Get Vehicle by DeclarationID
                var listVehicle = VehicleFactory.GetFromViewByDeclarationID(this._declerationID);
                BindVehicle(listVehicle);
            }
            if (_declerationType.Equals(Common.DeclerationType.Import)) btnAddVehicle.Enabled = false;
        }

        #endregion

        //private void btnReset_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //      txtExportNumber.Text = "";
        //      txtExportProductName.Text = "";
        //      txtExportCompanyName.Text = "";
        //      txtExportProductAmount.Text = "";
        //      txtExportUnit.Text = "";
        //      txtTypeExport.Text = "";
        //      txtExportCompanyCode.Text = "";
        //      txtExportCompanyCode.Text = "";
        //      dtpExportRegisterDate.Value = DateTime.Now;

        //      grdVehicle.Rows.Clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex.ToString());
        //        if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
        //    }
        //}

        private void btnUpdateVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                var declarationInfo = new tblDeclaration();
                if (!string.IsNullOrEmpty(txtExportNumber.Text))
                {
                    declarationInfo.Number = Convert.ToInt32(txtExportNumber.Text);
                }
                declarationInfo.CreatedDate = CommonFactory.GetCurrentDate();
                declarationInfo.ProductName = txtExportProductName.Text;
                declarationInfo.ProductAmount = txtProductAmount.Text;
                // New mode
                if (grdVehicle.SelectedRows.Count == 1 && this._mode == 0)
                {
                    var vehicle = new frmVehicle(1, _mainForm, ref _vehicleInfosTemp, Convert.ToInt32(grdVehicle.SelectedRows[0].Cells["Count"].Value), declarationInfo, _userInfo, _declerationType);
                    vehicle.Show(this);
                }
                else if (grdVehicle.SelectedRows.Count == 1 && this._mode == 1) // Update Mode
                {
                    var vehicle = new frmVehicle(2, _mainForm, ref _vehicleInfosTemp, Convert.ToInt32(grdVehicle.SelectedRows[0].Cells["Count"].Value), declarationInfo, _userInfo, _declerationType);
                    vehicle.Show(this);
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

        public void BindVehicle(List<ViewAllVehicleHasGood> vehicleInfos)
        {
            try
            {
                grdVehicle.DataSource = null;
                // Bind count column
                grdVehicle.AutoGenerateColumns = false;
                grdVehicle.DataSource = vehicleInfos;
                // Add to count Column
                for (int i = 0; i < grdVehicle.Rows.Count; i++)
                {
                    grdVehicle.Rows[i].Cells[0].Value = (i + 1).ToString();
                    // Trong trường hợp phương tiện đã xuất cảnh, thì disable cột biển kiểm soát, không cho cập nhật.
                    // Get vehicle ID
                    var vehicleID = grdVehicle.Rows[i].Cells["VehicleID"].Value;
                    if (vehicleID != null && Convert.ToInt64(vehicleID) > 0)
                    {
                        // Get Vehicle
                        var vehicle = VehicleFactory.GetByID(Convert.ToInt64(vehicleID));
                        if (vehicle != null && vehicle.IsExport == true)
                        {
                            // Disable PlateNumber
                            grdVehicle.Rows[i].Cells["PlateNumber"].ReadOnly = true;
                        }
                    }
                }
                // Set first column to read only
                grdVehicle.Columns[0].ReadOnly = true;
                // Set number of vehicle
                if (!string.Equals(txtExportTotalVehicles.Text, grdVehicle.Rows.Count.ToString()) || grdVehicle.Rows.Count > 0)
                {
                    txtExportTotalVehicles.Text = grdVehicle.Rows.Count.ToString();
                }
                _vehicleInfosTemp = vehicleInfos;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnDeleteVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO: Support delete multiple
                if (grdVehicle.SelectedRows.Count == 1 && _mode == 0) // New mode
                {
                    var dr = MessageBox.Show("Bạn có chắc là muốn xóa?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        var count = 0;
                        foreach (var vehicleInfo in _vehicleInfosTemp)
                        {
                            count += 1;
                            if (count == Convert.ToInt32(grdVehicle.SelectedRows[0].Cells["Count"].Value))
                            {
                                _vehicleInfosTemp.Remove(vehicleInfo);
                                break;
                            }

                        }
                        this.BindVehicle(_vehicleInfosTemp);
                    }
                }
                else if (grdVehicle.SelectedRows.Count == 1 && _mode == 1) // Edit mode
                {
                    var dr = MessageBox.Show("Bạn có chắc là muốn xóa?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        // Remove vehicle from declerationVehicle table
                        DeclarationVehicleFactory.DeleteByVehicleDeclarationID(
                            Convert.ToInt32(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value), this._declerationID);
                        // Get Vehicle by DeclarationID
                        var listVehicle = VehicleFactory.GetFromViewByDeclarationID(this._declerationID);
                        BindVehicle(listVehicle);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn 1 phương tiện cần xóa.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate()) return;
                if (_declerationID != 0)
                {
                    // Get decleration by ID
                    var declerationInfoTemp = DeclarationFactory.GetByID(_declerationID);
                    var declerationInfo = GetDeclarationInfo(ref declerationInfoTemp);

                    // Update Decleration
                    DeclarationFactory.Update(declerationInfo);
                    // Delete all existing vehicle by DeclarationID from tblDeclarationVehicle
                    DeclarationVehicleFactory.DeleteVehicleByDecarationID(_declerationID);
                    foreach (var vehicle in this._vehicleInfosTemp)
                    {
                        // Insert vehicle and Declaration to DeclarationVehicle table
                        DeclarationVehicleFactory.Insert(vehicle.VehicleID, _declerationID);
                        // Update vehicle
                        var v = new tblVehicle();
                        v.VehicleID = vehicle.VehicleID;
                        v.PlateNumber = vehicle.PlateNumber;
                        v.NumberOfContainer = vehicle.NumberOfContainer;
                        v.DriverName = vehicle.DriverName;
                        v.ImportDate = vehicle.ImportDate;
                        v.IsImport = vehicle.IsImport;
                        v.ExportDate = vehicle.ExportDate;
                        v.IsExport = vehicle.IsExport;
                        v.Note = vehicle.Note;
                        //v.Status = vehicle.Status;
                        v.IsCompleted = vehicle.IsCompleted;
                        v.IsGoodsImported = vehicle.IsGoodsImported;
                        v.ImportStatus = vehicle.ImportStatus;
                        v.ImportedLocalTime = vehicle.ImportedLocalTime;
                        v.HasGoodsImported = vehicle.HasGoodsImported;
                        v.ConfirmExportBy = vehicle.ConfirmExportBy;
                        v.ConfirmImportBy = vehicle.ConfirmImportBy;
                        v.ConfirmLocalImportBy = vehicle.ConfirmLocalImportBy;
                        VehicleFactory.UpdateVehicle(v);
                    }
                    MessageBox.Show("Cập nhật thành công");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void txtExportTotalVehicles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))// Enter key
            {
                try
                {

                    if (string.IsNullOrEmpty(txtExportTotalVehicles.Text)) return;
                    var totalVehicles = Convert.ToInt32(txtExportTotalVehicles.Text);

                    if (_vehicleInfosTemp.Count > totalVehicles)
                        throw new Exception("Bạn phải nhập số phương tiện lớn hơn số phương tiện hiện tại hoặc bạn phải xóa phương tiện đi");

                    ViewAllVehicleHasGood vehicleInfo;
                    var bias = totalVehicles - _vehicleInfosTemp.Count;
                    for (int i = 0; i < bias; i++)
                    {
                        vehicleInfo = new ViewAllVehicleHasGood();
                        // Add to the list object
                        _vehicleInfosTemp.Add(vehicleInfo);
                    }
                    // Bind to datagrid
                    BindVehicle(_vehicleInfosTemp);
                }
                catch (Exception ex)
                {
                    logger.Error(ex.ToString());
                    if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
                }
            }
        }

        private void txtExportTotalVehicles_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtExportTotalVehicles.Text)) return;
                var totalVehicles = Convert.ToInt32(txtExportTotalVehicles.Text);
                ViewAllVehicleHasGood vehicleInfo;
                for (int i = 0; i < totalVehicles - grdVehicle.Rows.Count; i++)
                {
                    vehicleInfo = new ViewAllVehicleHasGood();
                    // Add to the list object
                    _vehicleInfosTemp.Add(vehicleInfo);
                }
                // Bind to datagrid
                BindVehicle(_vehicleInfosTemp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void grdVehicle_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_PHUONG_TIEN))
            {
                try
                {
                    if (e.RowIndex >= 0 && grdVehicle.SelectedRows.Count == 1)
                    {

                        var declarationInfo = new tblDeclaration();
                        if (!string.IsNullOrEmpty(txtExportNumber.Text))
                        {
                            declarationInfo.Number = Convert.ToInt32(txtExportNumber.Text);
                        }
                        declarationInfo.CreatedDate = CommonFactory.GetCurrentDate();
                        declarationInfo.ProductName = txtExportProductName.Text;
                        declarationInfo.ProductAmount = txtProductAmount.Text;

                        // Bind the gridview data to the vehicleInfo object, make sure, the vehicleInfotem dat is same as the gridview.
                        // Validate data of the gridview.
                        // Clear the tem data

                        //_vehicleInfosTemp.Clear();

                        _vehicleInfosTemp = (List<ViewAllVehicleHasGood>)grdVehicle.DataSource;


                        // New mode
                        if (this._mode == 0)
                        {
                            var vehicle = new frmVehicle(1, _mainForm, ref _vehicleInfosTemp, Convert.ToInt32(grdVehicle.Rows[e.RowIndex].Cells["Count"].Value), declarationInfo, _userInfo, _declerationType);
                            vehicle.Show(this);
                        }
                        else if (this._mode == 1) // Update Mode
                        {
                            var vehicle = new frmVehicle(2, _mainForm, ref _vehicleInfosTemp, Convert.ToInt32(grdVehicle.Rows[e.RowIndex].Cells["Count"].Value), declarationInfo, _userInfo, _declerationType);
                            vehicle.Show(this);
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex.ToString());
                    if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
                }
            }
        }

        private void CheckPermission()
        {

            //check user permission
            if (_declerationType == Common.DeclerationType.Import)
            {
                //btnAddVehicle.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_THEM_PHUONG_TIEN_CHO_TO_KHAI_NHAP_CANH);
                btnAddExisting.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_THEM_PHUONG_TIEN_CHO_TO_KHAI_NHAP_CANH);
                btnUpdateVehicle.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_PHUONG_TIEN_CHO_TO_KHAI_NHAP_CANH);
                btnDeleteVehicle.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_PHUONG_TIEN_CHO_TO_KHAI_NHAP_CANH);
            }
            else
            {
                btnAddVehicle.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_THEM_PHUONG_TIEN_CHO_TO_KHAI_XUAT_CANH);
                //btnAddExisting.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_MOI_PHUONG_TIEN);
                btnUpdateVehicle.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_PHUONG_TIEN_CHO_TO_KHAI_XUAT_CANH);
                btnDeleteVehicle.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_PHUONG_TIEN_CHO_TO_KHAI_XUAT_CANH);
            }

            btnComfirmExport.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_XUAT_CANH);
            btnConfirmImportKH.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_NHAP_CANH);
            bntConfirmImportCH.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_NHAP_CANH);

            btnAdd.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_TO_KHAI);
            btnUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_TO_KHAI);
        }

        private void FrmDecleExport_Load(object sender, EventArgs e)
        {
            txtExportTotalVehicles.Focus();
            this.Text = "Khai báo xuất nhập cảnh" + ConstantInfo.MESSAGE_TITLE;
            // Show form to the center            
            this.Location = new Point((_mainForm.Width - this.Width) / 2, (_mainForm.Height - this.Height) / 2);

            //check user permission
            CheckPermission();
            // Init form.
            Init();
            //InitialPermission();

        }

        private void btnComfirmExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVehicle.SelectedRows.Count == 1)
                {
                    var message = new StringBuilder();
                    message.Append("Thời gian xuất cảnh: " + CommonFactory.GetCurrentDate().ToString("dd/MM/yyyy HH:mm"));

                    if (MessageBox.Show(message.ToString(), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var count = 0;
                        foreach (var vehicleInfo in _vehicleInfosTemp)
                        {
                            count += 1;
                            if (count == Convert.ToInt32(grdVehicle.SelectedRows[0].Cells["Count"].Value))
                            {
                                vehicleInfo.ExportDate = CommonFactory.GetCurrentDate();
                                try
                                {
                                    if (vehicleInfo.ConfirmExportBy != null && vehicleInfo.ConfirmExportBy != 0 && vehicleInfo.ConfirmExportBy != _userInfo.UserID)
                                        throw new Exception("Phương tiện đã được xác nhận bởi một người dùng khác!");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return;
                                }

                                vehicleInfo.ConfirmExportBy = _userInfo.UserID;
                                vehicleInfo.IsExport = true;
                                break;
                            }
                        }
                        this.BindVehicle(_vehicleInfosTemp);
                        MessageBox.Show("Lưu thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn 1 phương tiện");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnAddExisting_Click(object sender, EventArgs e)
        {
            var frmSelect = new frmVehicleSelect(_declerationID);
            frmSelect.OnSelectedVehichle += new frmVehicleSelect.OnSelectedVehicleHandler(frmSelect_OnSelectedVehichle);
            frmSelect.Show(this);
        }

        void frmSelect_OnSelectedVehichle(object sender, EventArgs e)
        {

            var arg = (SelectedVehichleEventArgs)(e);
            var vehicleInfo = arg.Vehicle;

            foreach (var v in _vehicleInfosTemp)
            {
                if (v.VehicleID == vehicleInfo.VehicleID)
                    throw new Exception("Phương tiện này đã tồn tại trong tờ khai!");
            }
            _vehicleInfosTemp.Add(vehicleInfo);
            this.BindVehicle(_vehicleInfosTemp);

        }

        private void bntConfirmImportCH_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVehicle.SelectedRows.Count == 1)
                {
                    var message = new StringBuilder();
                    message.Append("Thời gian nhập cảnh: " + CommonFactory.GetCurrentDate().ToString("dd/MM/yyyy HH:mm"));


                    if (MessageBox.Show(message.ToString(), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var count = 0;
                        foreach (var vehicleInfo in _vehicleInfosTemp)
                        {
                            count += 1;
                            if (count == Convert.ToInt32(grdVehicle.SelectedRows[0].Cells[0].Value))
                            {
                                vehicleInfo.ImportDate = CommonFactory.GetCurrentDate();
                                vehicleInfo.IsImport = true;
                                vehicleInfo.HasGoodsImported = true;
                                vehicleInfo.ImportStatus = "Nhập cảnh có hàng";
                                try
                                {
                                    if ((vehicleInfo.ConfirmImportBy != null && vehicleInfo.ConfirmImportBy != 0) && vehicleInfo.ConfirmImportBy != _userInfo.UserID)
                                        throw new Exception("Phương tiện đã được xác nhận bởi một người dùng khác!");

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return;
                                }
                                vehicleInfo.ConfirmImportBy = _userInfo.UserID;
                                break;
                            }
                        }
                        this.BindVehicle(_vehicleInfosTemp);

                        MessageBox.Show("Lưu thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn 1 phương tiện");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnConfirmImportKH_Click(object sender, EventArgs e)
        {
            try
            {

                if (grdVehicle.SelectedRows.Count == 1)
                {

                    var message = new StringBuilder();
                    message.Append("Thời gian nhập cảnh: " + CommonFactory.GetCurrentDate().ToString("dd/MM/yyyy HH:mm"));


                    if (MessageBox.Show(message.ToString(), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var count = 0;
                        foreach (var vehicleInfo in _vehicleInfosTemp)
                        {
                            count += 1;
                            if (count == Convert.ToInt32(grdVehicle.SelectedRows[0].Cells[0].Value))
                            {
                                vehicleInfo.ImportDate = CommonFactory.GetCurrentDate();
                                vehicleInfo.IsImport = true;
                                // Nhập cảnh không hàng
                                vehicleInfo.HasGoodsImported = false;
                                vehicleInfo.ImportStatus = "Nhập cảnh không có hàng";
                                try
                                {
                                    if ((vehicleInfo.ConfirmImportBy != null && vehicleInfo.ConfirmImportBy != 0) && vehicleInfo.ConfirmImportBy != _userInfo.UserID)
                                        throw new Exception("Phương tiện đã được xác nhận bởi một người dùng khác!");

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return;
                                }
                                vehicleInfo.ConfirmImportBy = _userInfo.UserID;
                                break;
                            }
                        }
                        this.BindVehicle(_vehicleInfosTemp);

                        MessageBox.Show("Lưu thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn 1 phương tiện");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void FrmDecleExport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (_declerationType == Common.DeclerationType.Export) btnComfirmExport_Click(sender, e);
            }
            if (e.KeyCode == Keys.F6)
            {
                if (_declerationType == Common.DeclerationType.Import) bntConfirmImportCH_Click(sender, e);
            }
            if (e.KeyCode == Keys.F7)
            {
                if (_declerationType == Common.DeclerationType.Import) btnConfirmImportKH_Click(sender, e);
            }
        }

        private void grdVehicle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 1) && (grdVehicle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null))
            {
                string newValue = StringUtil.RemoveAllNonAlphanumericString(grdVehicle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).ToUpper();
                grdVehicle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = newValue;
            }
        }

        private void cbTNTX_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnTXTN.Visible = ((ComboBox)sender).SelectedIndex > 0;
        }

        public class ComboBoxItem
        {
            public string Value;
            public string Text;
            public ComboBoxItem(string val, string text)
            {
                Value = val;
                Text = text;
            }
            public override string ToString()
            {
                return Text;
            }
        }
    }
}