﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.DAL;
using ECustoms.Utilities;
using ECustoms.Utilities.Enums;
using System.Linq;

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
        private int _statusFee;  // 0: k ấn xác nhận thu phí, 1: ấn xác nhận thu phí tất cả phương tiện
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
                    List<tblVehicleFeeSetting> listFee = null;
                    if (_statusFee == 1)
                    {
                        listFee = VehicleFeeSettingFactory.getAllVehicleFeeSetting();
                    }
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
                        if (grdVehicle.Rows[i].Cells["VehicleType"].Value != null)
                        {
                            vehicleInfo.vehicleTypeId = Int32.Parse(grdVehicle.Rows[i].Cells["VehicleType"].Value.ToString());
                        }
                        if (grdVehicle.Rows[i].Cells["ExportGoodType"].Value != null)
                        {
                            vehicleInfo.ExportGoodTypeId = Int32.Parse(grdVehicle.Rows[i].Cells["ExportGoodType"].Value.ToString());
                        }
                        if (grdVehicle.Rows[i].Cells["ImportGoodType"].Value != null)
                        {
                            vehicleInfo.ImportGoodTypeId = Int32.Parse(grdVehicle.Rows[i].Cells["ImportGoodType"].Value.ToString());
                        }
                        
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
                        
                        //Set Fee
                        if (_statusFee == 1)
                        {
                            var currentDate = CommonFactory.GetCurrentDate();
                            if (_declerationType.Equals(Common.DeclerationType.Export))
                            {
                                vehicleInfo.ExportReceiptNumber = "9999";
                                var feeSetting = listFee.Where(f =>f.VehicleTypeId == vehicleInfo.vehicleTypeId && f.GoodsTypeId == vehicleInfo.ExportGoodTypeId).FirstOrDefault();
                                var amount = feeSetting != null ? (feeSetting.Fee ?? 0) : 0;
                                vehicleInfo.feeExportAmount = amount;
                                vehicleInfo.feeExportDate = currentDate;
                                vehicleInfo.feeExportStatus = (int)FeeStatus.PaidFee;
                                vehicleInfo.confirmFeeExportBy = _userInfo.UserID;
                            }
                            else
                            {
                                vehicleInfo.ImportReceiptNumber = "9999";
                                var feeSetting = listFee.Where(f => f.VehicleTypeId == vehicleInfo.vehicleTypeId && f.GoodsTypeId == vehicleInfo.ImportGoodTypeId).FirstOrDefault();
                                var amount = feeSetting != null ? (feeSetting.Fee ?? 0) : 0;
                                vehicleInfo.feeImportAmount = amount;
                                vehicleInfo.feeImportDate = currentDate;
                                vehicleInfo.feeImportStatus = (int)FeeStatus.PaidFee;
                                vehicleInfo.confirmFeeImportBy = _userInfo.UserID;
                            }    
                        }
                        else
                        {
                            var currentDate = CommonFactory.GetCurrentDate();
                            if (_declerationType.Equals(Common.DeclerationType.Export))
                            {
                                if ((grdVehicle.Rows[i].Cells["ExportReceiptNumber"].Value == null) || string.IsNullOrEmpty(grdVehicle.Rows[i].Cells["ExportReceiptNumber"].Value.ToString().Trim()) || (grdVehicle.Rows[i].Cells["feeExportAmount"].Value == null))
                                {
                                    if (vehicleInfo.feeExportStatus == (int)FeeStatus.PaidFee)
                                    {
                                        vehicleInfo.ExportReceiptNumber = null;
                                        vehicleInfo.feeExportAmount = null;
                                        vehicleInfo.feeExportDate = null;
                                        vehicleInfo.feeExportStatus = (int)FeeStatus.HasNotPayFee;
                                        vehicleInfo.confirmFeeExportBy = _userInfo.UserID;
                                    }
                                }
                                else
                                {
                                    vehicleInfo.ExportReceiptNumber = grdVehicle.Rows[i].Cells["ExportReceiptNumber"].Value.ToString().Trim();
                                    vehicleInfo.feeExportAmount = Convert.ToInt64(grdVehicle.Rows[i].Cells["feeExportAmount"].Value);
                                    vehicleInfo.feeExportDate = currentDate;
                                    vehicleInfo.feeExportStatus = (int)FeeStatus.PaidFee;
                                    vehicleInfo.confirmFeeExportBy = _userInfo.UserID;
                                }
                            }
                            else
                            {
                                if ((grdVehicle.Rows[i].Cells["ImportReceiptNumber"].Value == null) || string.IsNullOrEmpty(grdVehicle.Rows[i].Cells["ImportReceiptNumber"].Value.ToString().Trim()) || (grdVehicle.Rows[i].Cells["feeImportAmount"].Value == null))
                                {
                                    if (vehicleInfo.feeImportStatus == (int)FeeStatus.PaidFee)
                                    {
                                        vehicleInfo.ImportReceiptNumber = null;
                                        vehicleInfo.feeImportAmount = null;
                                        vehicleInfo.feeImportDate = null;
                                        vehicleInfo.feeImportStatus = (int)FeeStatus.HasNotPayFee;
                                        vehicleInfo.confirmFeeExportBy = _userInfo.UserID;
                                    }
                                }
                                else
                                {
                                    vehicleInfo.ImportReceiptNumber = grdVehicle.Rows[i].Cells["ImportReceiptNumber"].Value.ToString().Trim();
                                    vehicleInfo.feeImportAmount = Convert.ToInt64(grdVehicle.Rows[i].Cells["feeImportAmount"].Value);
                                    vehicleInfo.feeImportDate = currentDate;
                                    vehicleInfo.feeImportStatus = (int)FeeStatus.PaidFee;
                                    vehicleInfo.confirmFeeImportBy = _userInfo.UserID;
                                }
                            }      
                        }

                        var vehicleRow = (ViewAllVehicleHasGood) grdVehicle.Rows[i].DataBoundItem;
                        if (vehicleRow.StatusChangeGood != null)
                        {    
                            vehicleInfo.StatusChangeGood = vehicleRow.StatusChangeGood;
                            vehicleInfo.ListVehicleChangeGood = vehicleRow.ListVehicleChangeGood;
                        }

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
                //cap nhat So tiep nhap tai khai Xuat chuyen khai trong nam
                //cap nhat khi la xuat khau chuyen cua khau
                if (declarationInfo.DeclarationType == (short)Common.DeclerationType.Export && declarationInfo.TypeOption==1)
                {
                    long receiveNumber = ApplicationObjectFactory.updateTotalReceiveNumber();
                    declarationInfo.ReceiveNumberInYear = receiveNumber;
                }

                // TODO: Need to check return value
                DeclarationFactory.AddDeclaration(declarationInfo, listVehicleInfo, listVehicleUpdate, _userInfo.UserID);
                //MessageBox.Show(ConstantInfo.MESSAGE_INSERT_SUCESSFULLY);
                FrmReceiveNumber frmReceiveNumber = new FrmReceiveNumber(declarationInfo.ReceiveNumberInYear.GetValueOrDefault());
                frmReceiveNumber.MdiParent = this.MdiParent;
                frmReceiveNumber.Show(this);

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
            declarationInfo.CustomsCode = txtCustomsCode.Text.Trim();
            declarationInfo.RegisterDate = dtpExportRegisterDate.Value;
            declarationInfo.ProductAmount = txtProductAmount.Text.Trim();
            declarationInfo.Unit = txtExportUnit.Text.Trim();
            declarationInfo.ProductName = txtExportProductName.Text;
            declarationInfo.ModifiedByID = _userInfo.UserID;
            //declarationInfo.ModifiedDate = CommonFactory.GetCurrentDate();
            //declarationInfo.CreatedDate = CommonFactory.GetCurrentDate();
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
            {
                declarationInfo.NumberTemp = txtNumberTemp.Text.Trim();
                declarationInfo.NumberTempInfo = txtNumberTempInfo.Text.Trim();
            }
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
            txtTypeName.Text = "";
            grdVehicle.DataSource = null;
            _vehicleInfosTemp.Clear();
            txtExportCompanyCode.Text = "";
            dtpExportRegisterDate.Value = DateTime.Now;
            txtMoney.Text = "";
            cbTNTX.SelectedIndex = 0;
            txtNumberTemp.Text = "";
            txtNumberTempInfo.Text = "";
            _statusFee = 0;
        }

        private bool Validate()
        {
            techlinkErrorProvider1.Validate(this);
            // Validate export declaration
            if (string.IsNullOrEmpty(txtExportNumber.Text.Trim()))
            {
                MessageBox.Show(ConstantInfo.MESSAGE_BLANK_DECLARATION_NUMBER);
                txtExportNumber.Focus();
                return false;
            }


            tblType type = TypeFactory.FindByCode(txtTypeExport.Text.Trim());
            if (type == null)
            {
                MessageBox.Show("Chưa nhập hoặc loại hình không tồn tại", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTypeExport.Focus();
                return false;
            }


            tblCompany company = CompanyFactory.FindByCode(txtExportCompanyCode.Text.Trim());
            if (company == null)
            {
                MessageBox.Show("Chưa nhập hoặc doanh nghiệp không tồn tại", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExportCompanyCode.Focus();
                return false;
            }

            tblCustom customs = CustomsFacory.FindByCode(txtCustomsCode.Text.Trim());
            if (customs == null)
            {
                MessageBox.Show("Chưa nhập hoặc đơn vị hải quan không tồn tại", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomsCode.Focus();
                return false;
            }

            // Không lưu khi tờ khai không có phương tiện nào
            if (grdVehicle.Rows.Count < 1)
            {
                MessageBox.Show(ConstantInfo.MESSAGE_NO_VEHICLE);
                return false;
            }
            //validate list vehicle
            foreach (ViewAllVehicleHasGood vehicle in _vehicleInfosTemp)
            {
                if (vehicle.PlateNumber==null || String.IsNullOrEmpty(vehicle.PlateNumber.Trim()))
                {
                    MessageBox.Show("Tồn tại phương tiện chưa có biển số xe trong danh sách phương tiện");
                    return false;
                }
                if (vehicle.vehicleTypeId == null || vehicle.vehicleTypeId <= 0)
                {
                    MessageBox.Show("Tồn tại phương tiện chưa có loại trọng tải trong danh sách phương tiện");
                    return false;
                }
                if (_declerationType == Common.DeclerationType.Export && (vehicle.ExportGoodTypeId == null || vehicle.ExportGoodTypeId <= 0))
                {
                    MessageBox.Show("Tồn tại phương tiện chưa có loại hàng hóa xuất cảnh trong danh sách phương tiện");
                    return false;
                }
                if (_declerationType == Common.DeclerationType.Import && (vehicle.ImportGoodTypeId == null || vehicle.ImportGoodTypeId <= 0))
                {
                    MessageBox.Show("Tồn tại phương tiện chưa có loại hàng hóa nhập cảnh trong danh sách phương tiện");
                    return false;
                }
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
            //init vehicleType
            var listVehicleType = VehicleTypeFactory.getAllVehicleType();
            dataSet2.tblVehicleType.Rows.Add(0, "Không phân loại");
            foreach (tblVehicleType vehicleType in listVehicleType)
            {
                dataSet2.tblVehicleType.Rows.Add(vehicleType.VehicleTypeID, vehicleType.Name);
            }

            //init goodType
            var listGoodType = GoodTypeFactory.SelectAll();
            dataSet2.tblGoodsType.Rows.Add(0, "Không phân loại");
            foreach (tblGoodsType goodType in listGoodType)
            {
                dataSet2.tblGoodsType.Rows.Add(goodType.TypeId, goodType.TypeName);
            }

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
                //btnAddExisting.Text = "Thêm từ xe trong bãi xuất";
                btnAddExisting.Enabled = false;
                btnAddVehicleExportParking.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_THEM_PHUONG_TIEN_CHO_TO_KHAI_XUAT_CANH);
                bntConfirmImportCH.Visible = false;
                btnConfirmImportKH.Visible = false;
                btnComfirmExport.Visible = true;
                btnComfirmExport.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_XUAT_CANH);
                cbTNTX.Items.RemoveAt(3);
                cbTNTX.Items.RemoveAt(2);
                grdVehicle.Columns["ImportGoodType"].Visible = grdVehicle.Columns["ImportReceiptNumber"].Visible = grdVehicle.Columns["feeImportAmount"].Visible = false;
                // Thu phí
                btnFee.Text = "Thu phí xuất";
                btnFee.Image = Properties.Resources._1336316540_document_export;
            }
            else
            {
                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#c1ffc0");
                this.BackColor = col;
                lblHeader.Text = "Khai báo nhập cảnh";
                gbExportDeclaration.Text = "Thông tin tờ khai nhập khẩu";
                
                btnAddExisting.Enabled = btnAddVehicleExportParking.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_THEM_PHUONG_TIEN_CHO_TO_KHAI_NHAP_CANH);
                bntConfirmImportCH.Visible = true;
                bntConfirmImportCH.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_NHAP_CANH);
                //bntConfirmImportCH.Location = new Point(865, 25);
                btnConfirmImportKH.Visible = true;
                btnConfirmImportKH.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_NHAP_CANH);
                //btnConfirmImportKH.Location = new Point(865, 81);
                btnComfirmExport.Enabled = false;
                btnAdd.Enabled = false;
                // Invisible luong xe
                lblTotalVehicles.Visible = false;
                txtExportTotalVehicles.Visible = false;
                cbTNTX.Items.RemoveAt(1);

                grdVehicle.Columns["ExportGoodType"].Visible = grdVehicle.Columns["ExportReceiptNumber"].Visible = grdVehicle.Columns["feeExportAmount"].Visible = false;
                grdVehicle.Columns["VehicleType"].ReadOnly = true;

            }

            // New mode))
            if (this._mode == 0)
            {
                cbTNTX.SelectedIndex = 0;
                btnUpdate.Enabled = false;
                btnAdd.Enabled = true;
                btnAdd.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_TO_KHAI);

                //fill default value
                var profileConfig = UserFactory.GetProfileConfigByUserId(_userInfo.UserID);
                foreach (var config in profileConfig)
                {
                    if (config.Type == (int)ProfileConfig.TypeCode)
                    {
                        txtTypeExport.Text = config.Value;
                        var type = TypeFactory.FindByCode(config.Value);
                        txtTypeName.Text = type != null ? type.TypeName : "";
                        continue;
                    }
                    if (config.Type == (int)ProfileConfig.CustomUnit)
                    {
                        txtCustomsCode.Text = config.Value;
                        var custom  = CustomsFacory.FindByCode(config.Value);
                        txtCustomsName.Text = custom != null ? custom.CustomsName : "";
                    }
                }
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
                    txtExportCompanyCode.Text = declarationInfo.CompanyCode;
                    txtExportCompanyName.Text = declarationInfo.CompanyName;
                    txtProductAmount.Text = declarationInfo.ProductAmount;
                    txtExportUnit.Text = declarationInfo.Unit;
                    txtTypeExport.Text = declarationInfo.Type;

                    tblType type = TypeFactory.FindByCode(declarationInfo.Type);
                    if (type != null)
                    {
                        txtTypeName.Text = type.TypeName;
                    }
                    else
                    {
                        txtTypeName.Text = "";
                    }

                    
                    txtCustomsCode.Text = declarationInfo.CustomsCode;
                    tblCustom customs = CustomsFacory.FindByCode(declarationInfo.CustomsCode);
                    if (customs != null)
                    {
                        txtCustomsName.Text = customs.CustomsName;
                    }
                    else
                    {
                        txtCustomsName.Text = "";
                    }

                    dtpExportRegisterDate.Value = declarationInfo.RegisterDate != null ? declarationInfo.RegisterDate.Value : CommonFactory.GetCurrentDate();
                    txtMoney.Text = declarationInfo.Money.ToString();
                    cbTNTX.SelectedItem = declarationInfo.TypeOption != null ? listTNTX[(int)declarationInfo.TypeOption] : listTNTX[0];
                    if (cbTNTX.SelectedIndex > 0)
                    {
                        pnTXTN.Visible = true;
                        txtNumberHandover.Text = declarationInfo.NumberHandover != null ? declarationInfo.NumberHandover.ToString() : "";
                        dtpHandover.Value = declarationInfo.DateHandover != null ? declarationInfo.DateHandover.Value : CommonFactory.GetCurrentDate();
                    }
                    txtNumberTemp.Text = declarationInfo.NumberTemp ?? "";
                    txtNumberTempInfo.Text = declarationInfo.NumberTempInfo ?? "";
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

                var listFee = VehicleFeeSettingFactory.getAllVehicleFeeSetting();
                
                for (int i = 0; i < grdVehicle.Rows.Count; i++)
                {
                    // Add to count Column
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
                        //fee
                        if (_declerationType.Equals(Common.DeclerationType.Export))
                        {
                            if (vehicle.feeExportStatus == null || vehicle.feeExportStatus == (int)FeeStatus.HasNotPayFee)
                            {
                                var feeSetting = listFee.Where(f => f.VehicleTypeId == vehicle.vehicleTypeId && f.GoodsTypeId == vehicle.ExportGoodTypeId).FirstOrDefault();
                                var amount = feeSetting != null ? (feeSetting.Fee ?? 0) : 0;
                                grdVehicle.Rows[i].Cells["feeExportAmount"].Value = amount;
                            }
                        }
                        else
                        {
                            if (vehicle.feeImportStatus == null || vehicle.feeImportStatus == (int)FeeStatus.HasNotPayFee)
                            {
                                var feeSetting = listFee.Where(f => f.VehicleTypeId == vehicle.vehicleTypeId && f.GoodsTypeId == vehicle.ImportGoodTypeId).FirstOrDefault();
                                var amount = feeSetting != null ? (feeSetting.Fee ?? 0) : 0;
                                grdVehicle.Rows[i].Cells["feeImportAmount"].Value = amount;
                            }
                        }
                    }
                    else
                    {
                        //fee
                        if (_declerationType.Equals(Common.DeclerationType.Export))
                        {

                            var feeSetting = listFee.Where(f => f.VehicleTypeId == Convert.ToInt32(grdVehicle.Rows[i].Cells["VehicleType"].Value) && f.GoodsTypeId == Convert.ToInt32(grdVehicle.Rows[i].Cells["ExportGoodType"].Value)).FirstOrDefault();
                            var amount = feeSetting != null ? (feeSetting.Fee ?? 0) : 0;
                            grdVehicle.Rows[i].Cells["feeExportAmount"].Value = amount;
                        }
                        else
                        {

                            var feeSetting = listFee.Where(f => f.VehicleTypeId == Convert.ToInt32(grdVehicle.Rows[i].Cells["VehicleType"].Value) && f.GoodsTypeId == Convert.ToInt32(grdVehicle.Rows[i].Cells["ImportGoodType"].Value)).FirstOrDefault();
                            var amount = feeSetting != null ? (feeSetting.Fee ?? 0) : 0;
                            grdVehicle.Rows[i].Cells["feeImportAmount"].Value = amount;
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
                    List<tblVehicleFeeSetting> listFee = null;
                    if (_statusFee == 1)
                    {
                        listFee = VehicleFeeSettingFactory.getAllVehicleFeeSetting();
                    }
                    foreach (var vehicle in this._vehicleInfosTemp)
                    {
                        // Insert vehicle and Declaration to DeclarationVehicle table
                        DeclarationVehicleFactory.Insert(vehicle.VehicleID, _declerationID);
                        // Update vehicle
                        var v = new tblVehicle();
                        v.VehicleID = vehicle.VehicleID;
                        v.PlateNumber = vehicle.PlateNumber;
                        v.PlateNumberPartner = vehicle.PlateNumberPartner;
                        v.NumberOfContainer = vehicle.NumberOfContainer;
                        v.DriverName = vehicle.DriverName;
                        v.ImportDate = vehicle.ImportDate;
                        v.IsImport = vehicle.IsImport;
                        v.ExportDate = vehicle.ExportDate;
                        v.IsExport = vehicle.IsExport;
                        v.Note = vehicle.Note;
                        v.Status = vehicle.Status;
                        v.vehicleTypeId = vehicle.vehicleTypeId;
                        v.ExportGoodTypeId = vehicle.ExportGoodTypeId;
                        v.ImportGoodTypeId = vehicle.ImportGoodTypeId;
                        v.IsCompleted = vehicle.IsCompleted;
                        v.IsGoodsImported = vehicle.IsGoodsImported;
                        v.ImportStatus = vehicle.ImportStatus;
                        v.ImportedLocalTime = vehicle.ImportedLocalTime;
                        v.HasGoodsImported = vehicle.HasGoodsImported;
                        v.ConfirmExportBy = vehicle.ConfirmExportBy;
                        v.ConfirmImportBy = vehicle.ConfirmImportBy;
                        v.ConfirmLocalImportBy = vehicle.ConfirmLocalImportBy;
                        v.CreatedDate = vehicle.CreatedDateVehicle;
                        //Set Fee
                        if (_statusFee == 1)
                        {
                            var currentDate = CommonFactory.GetCurrentDate();
                            if (_declerationType.Equals(Common.DeclerationType.Export))
                            {
                                v.ExportReceiptNumber = "9999";
                                var feeSetting = listFee.Where(f => f.VehicleTypeId == v.vehicleTypeId && f.GoodsTypeId == v.ExportGoodTypeId).FirstOrDefault();
                                var amount = feeSetting != null ? (feeSetting.Fee ?? 0) : 0;
                                v.feeExportAmount = amount;
                                v.feeExportDate = currentDate;
                                v.feeExportStatus = (int)FeeStatus.PaidFee;
                                v.confirmFeeExportBy = _userInfo.UserID;

                                //old value import
                                v.ImportReceiptNumber = vehicle.ImportReceiptNumber;
                                v.feeImportAmount = vehicle.feeImportAmount;
                                v.feeImportDate = vehicle.feeImportDate;
                                v.feeImportStatus = vehicle.feeImportStatus;
                                v.confirmFeeImportBy = vehicle.confirmFeeImportBy;
                            }
                            else
                            {
                                v.ImportReceiptNumber = "9999";
                                var feeSetting = listFee.Where(f => f.VehicleTypeId == v.vehicleTypeId && f.GoodsTypeId == v.ImportGoodTypeId).FirstOrDefault();
                                var amount = feeSetting != null ? (feeSetting.Fee ?? 0) : 0;
                                v.feeImportAmount = amount;
                                v.feeImportDate = currentDate;
                                v.feeImportStatus = (int)FeeStatus.PaidFee;
                                v.confirmFeeImportBy = _userInfo.UserID;

                                //old value export
                                v.ExportReceiptNumber = vehicle.ExportReceiptNumber;
                                v.feeExportAmount = vehicle.feeExportAmount;
                                v.feeExportDate = vehicle.feeExportDate;
                                v.feeExportStatus = vehicle.feeExportStatus;
                                v.confirmFeeExportBy = vehicle.confirmFeeExportBy;
                            }
                        }
                        else
                        {
                            var dateFee = CommonFactory.GetCurrentDate();
                            // Set old value to vehicle
                            if ((vehicle.ExportReceiptNumber == null) || string.IsNullOrEmpty(vehicle.ExportReceiptNumber.Trim()) || (vehicle.feeExportAmount == null))
                            {
                                if (vehicle.feeExportStatus == (int)FeeStatus.PaidFee)
                                {
                                    v.feeExportStatus = (int)FeeStatus.HasNotPayFee;
                                    v.confirmFeeExportBy = _userInfo.UserID;
                                }
                            }
                            else
                            {
                                v.ExportReceiptNumber = vehicle.ExportReceiptNumber.Trim();
                                v.feeExportAmount = vehicle.feeExportAmount;
                                v.feeExportDate = vehicle.feeExportDate ?? dateFee;
                                v.feeExportStatus = (int)FeeStatus.PaidFee;
                                v.confirmFeeExportBy = _userInfo.UserID;
                            }

                            if ((vehicle.ImportReceiptNumber == null) || string.IsNullOrEmpty(vehicle.ImportReceiptNumber.Trim()) || (vehicle.feeImportAmount == null))
                            {
                                if (vehicle.feeImportStatus == (int)FeeStatus.PaidFee)
                                {
                                    v.feeImportStatus = (int)FeeStatus.HasNotPayFee;
                                    v.confirmFeeImportBy = _userInfo.UserID;
                                }
                            }
                            else
                            {
                                v.ImportReceiptNumber = vehicle.ImportReceiptNumber.Trim();
                                v.feeImportAmount = vehicle.feeImportAmount;
                                v.feeImportDate = vehicle.feeImportDate ?? dateFee;
                                v.feeImportStatus = (int)FeeStatus.PaidFee;
                                v.confirmFeeImportBy = _userInfo.UserID;
                            }
                        }
                        v.ModifiedById = _userInfo.UserID;
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
                btnFee.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_THU_PHI_PHUONG_TIEN_NHAP_CANH);
            }
            else
            {
                btnAddVehicle.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_THEM_PHUONG_TIEN_CHO_TO_KHAI_XUAT_CANH);
                btnAddExisting.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_THEM_PHUONG_TIEN_CHO_TO_KHAI_XUAT_CANH);
                btnUpdateVehicle.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_PHUONG_TIEN_CHO_TO_KHAI_XUAT_CANH);
                btnDeleteVehicle.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_PHUONG_TIEN_CHO_TO_KHAI_XUAT_CANH);
                btnFee.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_THU_PHI_PHUONG_TIEN_XUAT_CANH);
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
            this.Text = "Khai bao xuat nhap canh" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            
            // Show form to the center            
            this.Location = new Point((_mainForm.Width - this.Width) / 2, (_mainForm.Height - this.Height) / 2);

            //check user permission
            CheckPermission();
            // Init form.
            Init();
            //InitialPermission();

            if (txtNumberTemp.Text.Trim().Length > 0)
            {
                txtNumberTempInfo.Enabled = true;
            }
            else
            {
                txtNumberTempInfo.Enabled = false;
            }

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
            //neu la khai bao nhap canh, thi them tu phuong tien da xuat canh hoặc xe TQ
            if (_declerationType.Equals(Common.DeclerationType.Import))
            {
                var frmSelect = new frmVehicleSelect(_declerationID);
                frmSelect.OnSelectedVehichle += new frmVehicleSelect.OnSelectedVehicleHandler(frmSelect_OnSelectedVehichle);
                frmSelect.Show(this);
            }
            else //neu la khai bao xuat canh thi them tu phuont tien trong bai xuat
            {
                //var frmSelectExport = new FrmAddSelectVehichleFromExportPark(_declerationID);
                //frmSelectExport.OnSelectedVehichle += new FrmAddSelectVehichleFromExportPark.OnSelectedVehicleHandler(frmSelect_OnSelectedVehichle);
                //frmSelectExport.Show(this);
            }
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

            //if (_declerationType.Equals(Common.DeclerationType.Import))
            //{
            //    var arg = (SelectedVehichleEventArgs)(e);

            //    var vehicleInfo = arg.Vehicle;

            //    foreach (var v in _vehicleInfosTemp)
            //    {
            //        if (v.VehicleID == vehicleInfo.VehicleID)
            //            throw new Exception("Phương tiện này đã tồn tại trong tờ khai!");
            //    }
            //    _vehicleInfosTemp.Add(vehicleInfo);
            //    this.BindVehicle(_vehicleInfosTemp);
            //}
            //else
            //{
            //    var arg = (ECustoms.SelectedVehichleEventArgs)(e);

            //    var vehicleInfo = arg.Vehicle;

            //    foreach (var v in _vehicleInfosTemp)
            //    {
            //        if (v.VehicleID == vehicleInfo.VehicleID)
            //            throw new Exception("Phương tiện này đã tồn tại trong tờ khai!");
            //    }
            //    _vehicleInfosTemp.Add(vehicleInfo);
            //    this.BindVehicle(_vehicleInfosTemp);
            //}

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

                //auto fill data
                tblVehicle vehicle = VehicleFactory.GetByPlateNumber(newValue);
                if (vehicle != null)
                {
                    grdVehicle.Rows[e.RowIndex].Cells["DriverName"].Value = vehicle.DriverName;
                    if (vehicle.vehicleTypeId != null)
                    {
                        grdVehicle.Rows[e.RowIndex].Cells["VehicleType"].Value = vehicle.vehicleTypeId;
                    }
                }
            }
            //fill fee
            var listFee = VehicleFeeSettingFactory.getAllVehicleFeeSetting();
            //fee
            if (_declerationType.Equals(Common.DeclerationType.Export))
            {
                var feeSetting = listFee.Where(f => f.VehicleTypeId == Convert.ToInt32(grdVehicle.Rows[e.RowIndex].Cells["VehicleType"].Value) && f.GoodsTypeId == Convert.ToInt32(grdVehicle.Rows[e.RowIndex].Cells["ExportGoodType"].Value)).FirstOrDefault();
                var amount = feeSetting != null ? (feeSetting.Fee ?? 0) : 0;
                grdVehicle.Rows[e.RowIndex].Cells["feeExportAmount"].Value = amount;
            }
            else
            {
                var feeSetting = listFee.Where(f => f.VehicleTypeId == Convert.ToInt32(grdVehicle.Rows[e.RowIndex].Cells["VehicleType"].Value) && f.GoodsTypeId == Convert.ToInt32(grdVehicle.Rows[e.RowIndex].Cells["ImportGoodType"].Value)).FirstOrDefault();
                var amount = feeSetting != null ? (feeSetting.Fee ?? 0) : 0;
                grdVehicle.Rows[e.RowIndex].Cells["feeImportAmount"].Value = amount;
            }
        }

        private void cbTNTX_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnTXTN.Visible = ((ComboBox)sender).SelectedIndex > 0;
        }

        private void btnFee_Click(object sender, EventArgs e)
        {
            if (grdVehicle.Rows.Count == 0)
            {
                MessageBox.Show("Bạn cần khai báo phương tiện");
                return;
            }
            var message = string.Format("Bạn có chắc là muốn xác nhận thu phí {0} của tất cả các phương tiện trong tờ khai không?",
                                        _declerationType.Equals(Common.DeclerationType.Export) ? "xuất" : "nhập");

            if (MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _statusFee = 1;
            }
        }

        #region Class
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
        #endregion

        private void txtTypeExport_Leave(object sender, EventArgs e)
        {
            String typeCode = txtTypeExport.Text.Trim();
            tblType type = TypeFactory.FindByCode(typeCode);
            if (type != null)
            {
                txtTypeName.Text = type.TypeName;
            }
            else
            {
                txtTypeName.Text = "";
            }
            LoadDeclaration();
        }

        private void txtExportCompanyCode_Leave(object sender, EventArgs e)
        {
            String companyCode = txtExportCompanyCode.Text.Trim();
            tblCompany company = CompanyFactory.FindByCode(companyCode);
            if (company != null)
            {
                txtExportCompanyName.Text = Converter.TCVN3ToUnicode(company.CompanyName);
            }
            else
            {
                txtExportCompanyName.Text = "";
            }
        }

        private void txtCustomsCode_Leave(object sender, EventArgs e)
        {
            tblCustom customs = CustomsFacory.FindByCode(txtCustomsCode.Text.Trim());
            if (customs != null)
            {
                txtCustomsName.Text = customs.CustomsName;
            }
            else
            {
                txtCustomsName.Text = "";
            }
            LoadDeclaration();
        }

        private void LoadDeclaration()
        {
            if (string.IsNullOrEmpty(txtExportNumber.Text) || string.IsNullOrEmpty(txtTypeExport.Text) || string.IsNullOrEmpty(txtCustomsCode.Text))
            {
                txtExportCompanyCode.Enabled = true;
                txtExportCompanyCode.Text = string.Empty;
                txtExportCompanyName.Text = string.Empty;
                return;
            }
            var declaration = LoadDeclarationFactory.Load(int.Parse(txtExportNumber.Text), txtTypeExport.Text, txtCustomsCode.Text, dtpExportRegisterDate.Value.Year);
            if (declaration == null)
            {
                txtExportCompanyCode.Enabled = true;
                txtExportCompanyCode.Text = string.Empty;
                txtExportCompanyName.Text = string.Empty;
                txtProductAmount.Text = string.Empty;
                return;
            }
            txtExportCompanyCode.Text = declaration.Ma_DV;
            txtExportCompanyCode.Enabled = false;
            txtExportCompanyCode_Leave(null, null);
            txtProductAmount.Text = declaration.SoLuong.ToString("#,#.###");
            txtExportUnit.Text = declaration.Dvt;
            txtExportProductName.Text = declaration.TenHang;
        }

        private void txtExportNumber_Leave(object sender, EventArgs e)
        {
            LoadDeclaration();
        }

        private void txtNumberTemp_Leave(object sender, EventArgs e)
        {
            if (txtNumberTemp.Text.Trim().Length > 0)
            {
                txtNumberTempInfo.Enabled = true;
            }
            else
            {
                txtNumberTempInfo.Enabled = false;
            }
        }

        private void btnAddVehicleExportParking_Click(object sender, EventArgs e)
        {
            var frmSelectExport = new FrmAddSelectVehichleFromExportPark(_declerationID);
            frmSelectExport.OnSelectedVehichle += new FrmAddSelectVehichleFromExportPark.OnSelectedVehicleHandler(frmSelect_OnSelectedVehichle);
            frmSelectExport.Show(this);
        }
    }
}
