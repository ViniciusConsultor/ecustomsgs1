using System;
using System.Collections.Generic;
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
    public partial class frmVehicle : Form
    {
        private static log4net.ILog logger = LogManager.GetLogger("Ecustoms.frmVehicle");
        private List<ViewAllVehicleHasGood> _vehicleInfosTemp;
        private List<ViewAllVehicleHasGood> _newAddingVehicles = new List<ViewAllVehicleHasGood>();
        private int _mode = 0;
        private long _vehicleID;        
        private int _declarationID;
        private bool _isExport = false;
        private bool _isImport = false;
        private tblDeclaration _parrentDeclaration;
        private UserInfo _userInfo;
        private bool _isCompleted = false;
        private int _count;
        private string _currentModifyPlateNumber = string.Empty;
        private Form _mainForm;
        private Common.DeclerationType _type;

        private Form _seachFrom;

        public frmVehicle()
        {
            InitializeComponent();
            grdVehicle.AutoGenerateColumns = false;
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
        //        btnConfirmExport.Visible = false;
        //        btnConfirmImport.Visible = false;
        //        btnSearch.Visible = false;
        //        btnDelete.Enabled = false;
        //    }
        //}

        public frmVehicle(int mode, Form mainForm, ref  List<ViewAllVehicleHasGood> vehicleInfosTemp, tblDeclaration declarationInfo, UserInfo userInfo)
        {
            InitializeComponent();
            grdVehicle.AutoGenerateColumns = false;

            _mode = mode;
            _mainForm = mainForm;
            _vehicleInfosTemp = vehicleInfosTemp;
            _parrentDeclaration = declarationInfo;
            _userInfo = userInfo;

            //InitialPermission();
        }

        public frmVehicle(int mode, Form mainFrom, ref  List<ViewAllVehicleHasGood> vehicleInfosTemp, int count, tblDeclaration parrentDeclaration, UserInfo userInfo, Common.DeclerationType type)
        {
            InitializeComponent();
            grdVehicle.AutoGenerateColumns = false;
            _mode = mode;
            _mainForm = mainFrom;
            _vehicleInfosTemp = vehicleInfosTemp;
            _count = count;
            _parrentDeclaration = parrentDeclaration;
            _userInfo = userInfo;
            _type = type;
        }

        public frmVehicle(int mode, long vehicleID, UserInfo userInfo, Form mainForm, Form searchForm)
        {
            InitializeComponent();
            _mode = mode;
            _vehicleID = vehicleID;
            _userInfo = userInfo;
            _mainForm = mainForm;
            _seachFrom = searchForm;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Validate()
        {
            // comments code because new requirements
            // allow empty when inserting new verhicle,
            // the driver name might be filled later

            if (string.IsNullOrEmpty(txtPlateNumber.Text.Trim()))
            {
                MessageBox.Show("BKS không được để trống!");
                txtPlateNumber.Focus();
                return false;
            }
            return true;
        }

        private void ResetForm()
        {
            txtDriverName.Text = "";
            txtPlateNumber.Text = "";
            txtVehicleChinese.Text = "";
            txtNumberOfContainer.Text = "";
            dtpExportDate.Value = CommonFactory.GetCurrentDate();
            mtxtExportHour.Text = "";
            txtStatus.Text = "";
            txtNote.Text = "";
            dtpExportDate.Visible = false;
            mtxtExportHour.Visible = false;
            _isExport = false;
            lblIsExport.Visible = true;

            dtpImportDate.Visible = false;
            mtxtImportHour.Visible = false;
            lblIsImport.Visible = true;
            _isImport = false;
            // Set focus
            txtPlateNumber.Focus();
        }

        private void CheckPermisson()
        {
          //btnAdd.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_MOI_PHUONG_TIEN);
          btnUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_PHUONG_TIEN);
          btnDelete.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_PHUONG_TIEN);
          btnConfirmExport.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_XUAT_CANH);
          btnConfirmImport.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_NHAP_CANH);
        }

        private void frmVehicle_Load(object sender, EventArgs e)
        {
            this.Text = "Khai báo phương tiện" + ConstantInfo.MESSAGE_TITLE;
            this.Location = new Point((_mainForm.Width - this.Width) / 2, (_mainForm.Height - this.Height) / 2);
            Init();
            MessageBox.Show("df");
          
        }

        private void Init()
        {
            try
            {
                
                //init vehicleType
                var listVehicleType = VehicleTypeFactory.getAllVehicleType();
                foreach (tblVehicleType vehicleType in listVehicleType)
                {
                    cbVehicleType.Items.Add(vehicleType.Name);
                }
                //init goodType
                var listGoodType = GoodTypeFactory.SelectAll();
                foreach (tblGoodType goodType in listGoodType)
                {
                    cbGoodType.Items.Add(goodType.TypeName);
                }

                if (_type.Equals(Common.DeclerationType.Export))
                {
                    btnConfirmExport.Enabled = true;
                    btnConfirmExport.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_XUAT_CANH);
                    btnConfirmImport.Enabled = false;

                    //Autocomplete registerplace
                    var auto = new AutoCompleteStringCollection();
                    var lstAuto = VehicleFactory.GetAllPlateNumberChineseNoGoods();
                    auto.AddRange(lstAuto.ToArray());
                    txtVehicleChinese.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtVehicleChinese.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtVehicleChinese.AutoCompleteCustomSource = auto;
                }
                else
                {
                    btnConfirmExport.Enabled = false;
                    btnConfirmImport.Enabled = true;
                    btnConfirmImport.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_NHAP_CANH);
                }

                // TODO: Need to handler it
                if (_mode == 3)
                {
                    btnDelete.Enabled = true;
                    btnDelete.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_PHUONG_TIEN);
                }
                btnSearch.Enabled = false;

                if (_mode == 0 || _mode == 4) // Add mode - Click on Add New
                {
                    dtpImportDate.Visible = false;
                    mtxtImportHour.Visible = false;
                    dtpExportDate.Visible = false;
                    mtxtExportHour.Visible = false;
                    lblIsExport.Visible = true;
                    lblIsImport.Visible = true;
                    btnUpdate.Enabled = false;
                    btnAdd.Enabled = true;
                    //btnAdd.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_MOI_PHUONG_TIEN);
                    btnDelete.Enabled = false;
                    btnConfirmImport.Enabled = true;
                    btnConfirmImport.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_NHAP_CANH);
                    btnConfirmExport.Enabled = true;
                    btnConfirmExport.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_XUAT_CANH);
                    ResetForm();
                    btnAdd.Text = "Lưu trữ phương tiện";
                    btnSearch.Enabled = true;

                }
                else if (_mode == 1) // Add mode - CLick on Update
                {
                    dtpImportDate.Visible = false;
                    mtxtImportHour.Visible = false;
                    btnUpdate.Enabled = true;
                    btnUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_PHUONG_TIEN);
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = true;
                    btnDelete.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_PHUONG_TIEN);
                    btnConfirmImport.Enabled = true;
                    btnConfirmImport.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_NHAP_CANH);
                    for (int i = 0; i < _vehicleInfosTemp.Count; i++)
                    {
                        if (i + 1 == _count)
                        {
                            BindDataToControls(_vehicleInfosTemp[i]);
                            break;
                        }
                    }

                    btnAdd.Text = "Lưu trữ phương tiện";
                }
                else if (_mode == 2 || _mode == 3) // EditMode - Update
                {
                    btnAdd.Enabled = false;
                    // Get data from database                    
                    var vehicleInfo = VehicleFactory.GetByIDFromView(_vehicleID);

                    if (_vehicleID == 0) // If vehicleID > 0 --> this form is opened form search form. so get data from database. If vehicle=0--> get by Count
                    {

                        for (int i = 0; i < _vehicleInfosTemp.Count; i++)
                        {
                            if (i + 1 == _count)
                            {
                                vehicleInfo = _vehicleInfosTemp[i];
                                break;
                            }
                        }
                    }
                    if (vehicleInfo.ImportDate != null && vehicleInfo.ImportDate.Value != null && vehicleInfo.IsImport != null && vehicleInfo.IsImport.Value)
                    {
                        if (vehicleInfo.ImportDate == null || vehicleInfo.ImportDate.Value.Year.Equals(1900))
                        {
                            vehicleInfo.ImportDate = null;
                            dtpImportDate.Visible = false;
                            mtxtImportHour.Visible = false;
                            lblIsImport.Visible = true;
                        }

                        if (vehicleInfo.ExportDate == null || vehicleInfo.ExportDate.Value.Year.Equals(1900))
                        {
                            vehicleInfo.ExportDate = null;
                            dtpExportDate.Visible = false;
                            mtxtExportHour.Visible = false;
                            lblIsExport.Visible = true;
                        }
                    }

                    // Bind data to Controls

                    //if(vehicleInfo.IsExport){
                    //if(vehicleInfo.ConfirmExportBy != _userInfo.UserID)
                    //}

                    BindDataToControls(vehicleInfo);

                    _declarationID = Convert.ToInt32(vehicleInfo.DeclarationID);
                    btnAdd.Text = "Thêm mới phương tiện";
                }

                //// Check permission
                //if (_userInfo.PermissionID != 2) // Not is admin
                //{
                //    btnConfirmExport.Enabled = false;
                //    btnConfirmImport.Enabled = false;
                //}

                //InitialPermission();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void BindDataToControls(ViewAllVehicleHasGood vehicleInfo)
        {
            try
            {
                txtDriverName.Text = vehicleInfo.DriverName;
                txtPlateNumber.Text = vehicleInfo.PlateNumber;
                //if (vehicleInfo.IsChineseVehicle == null || vehicleInfo.IsChineseVehicle == false)
                //{
                //    lblVehicleChinese.Visible = txtVehicleChinese.Visible = true;
                //    txtVehicleChinese.Text = vehicleInfo.PlateNumberPartner;    
                //}
                //else
                //{
                //    lblVehicleChinese.Visible = txtVehicleChinese.Visible = false;
                //}
                txtVehicleChinese.Text = vehicleInfo.PlateNumberPartner;
                if (vehicleInfo.IsChineseVehicle == true)
                {
                    txtVehicleChinese.AutoCompleteMode = AutoCompleteMode.None;
                }

                txtNumberOfContainer.Text = vehicleInfo.NumberOfContainer;

                if (vehicleInfo.IsImport != null && vehicleInfo.IsImport.Value)
                {
                    dtpImportDate.Value = (DateTime)vehicleInfo.ImportDate;
                    dtpImportDate.Visible = true;
                    mtxtImportHour.Text = vehicleInfo.ImportDate.Value.ToString("HH:mm");
                    mtxtImportHour.Visible = true;
                    lblIsImport.Visible = false;
                }
                else
                {
                    dtpImportDate.Visible = false;
                    mtxtImportHour.Visible = false;
                    lblIsImport.Visible = true;
                }

                if (vehicleInfo.IsExport != null && vehicleInfo.IsExport.Value && vehicleInfo.ExportDate != null)
                {
                    dtpExportDate.Value = (DateTime)vehicleInfo.ExportDate;
                    dtpExportDate.Visible = true;
                    mtxtExportHour.Text = vehicleInfo.ExportDate.Value.ToString("HH:mm");
                    mtxtExportHour.Visible = true;
                    lblIsExport.Visible = false;
                }
                else
                {
                    dtpExportDate.Visible = false;
                    mtxtExportHour.Visible = false;
                    lblIsExport.Visible = true;
                }

                txtStatus.Text = vehicleInfo.Status;
                txtNote.Text = vehicleInfo.Note;
                if(vehicleInfo.IsImport != null) {
                    _isImport = vehicleInfo.IsImport.Value;
                }

                if (vehicleInfo.IsExport != null)
                {
                    _isExport = vehicleInfo.IsExport.Value;
                }

                if (vehicleInfo.ConfirmImportBy != null && vehicleInfo.ConfirmImportBy != 0 && vehicleInfo.ConfirmImportBy != _userInfo.UserID)
                    btnConfirmImport.Enabled = false;

                if (vehicleInfo.ConfirmExportBy != null && vehicleInfo.ConfirmExportBy != 0 && vehicleInfo.ConfirmExportBy != _userInfo.UserID)
                {
                  btnConfirmExport.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnConfirmExport_Click(object sender, EventArgs e)
        {
            try
            {
                var message = new StringBuilder();
                message.Append("Thời gian xuất cảnh: " + CommonFactory.GetCurrentDate().ToString("dd/MM/yyyy HH:mm"));
                if (_parrentDeclaration != null && _parrentDeclaration.Number > 0) // Has decleration
                {
                    message.Append("; Số tờ khai: " + _parrentDeclaration.Number);
                    message.Append("; Ngày khai: " + CommonFactory.GetCurrentDate().ToString("dd/MM/yyy HH:mm"));
                    message.Append("; Tên hàng: " + _parrentDeclaration.ProductName);
                    message.Append("; Số lượng: " + _parrentDeclaration.ProductAmount);
                }

                if (MessageBox.Show(message.ToString(), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dtpExportDate.Visible = true;
                    dtpExportDate.Value = CommonFactory.GetCurrentDate();
                    mtxtExportHour.Visible = true;
                    mtxtExportHour.Text = string.Format("{0:HH:mm}", CommonFactory.GetCurrentDate());
                    lblIsExport.Visible = false;

                    if (_mode == 1 || _mode == 2) // AddNew- Edit 
                    {
                        var count = 0;
                        foreach (var vehicleInfo in _vehicleInfosTemp)
                        {
                            count += 1;
                            if (count == _count)
                            {
                                if (vehicleInfo.ConfirmExportBy == null || vehicleInfo.ConfirmExportBy == 0)
                                {
                                    _isExport = true;
                                    vehicleInfo.IsExport = _isExport;
                                    vehicleInfo.ExportDate = Utilities.Common.AddHourMinutes(dtpExportDate.Value,
                                                                                             mtxtExportHour.Text);
                                    vehicleInfo.ConfirmExportBy = _userInfo.UserID;
                                }
                                else
                                {
                                    if (vehicleInfo.ConfirmExportBy != null && vehicleInfo.ConfirmExportBy != _userInfo.UserID)
                                        throw new Exception("Phương tiện này đã được xác nhận xuất khẩu bởi người khác!");
                                }
                            }
                        }
                    }
                    else if (_mode == 4 || _mode == 3)
                    {
                        _isExport = true;                        
                    }
                }
                else
                {
                    dtpExportDate.Visible = false;
                    mtxtExportHour.Visible = false;
                    lblIsExport.Visible = true;
                    _isExport = false;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnConfirmImport_Click(object sender, EventArgs e)
        {
            try
            {
                var message = new StringBuilder();
                message.Append("Thời gian nhập cảnh: " + CommonFactory.GetCurrentDate().ToString("dd/MM/yyyy HH:mm"));
                if (_parrentDeclaration != null && _parrentDeclaration.Number > 0)
                {
                    message.Append("; Số tờ khai: " + _parrentDeclaration.Number);
                    message.Append("; Ngày khai: " + CommonFactory.GetCurrentDate().ToString("dd/MM/yyy HH:mm"));
                    message.Append("; Tên hàng: " + _parrentDeclaration.ProductName);
                    message.Append("; Số lượng: " + _parrentDeclaration.ProductAmount);
                }

                if (MessageBox.Show(message.ToString(), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dtpImportDate.Visible = true;
                    dtpImportDate.Value = CommonFactory.GetCurrentDate();
                    mtxtImportHour.Visible = true;
                    mtxtImportHour.Text = string.Format("{0:HH:mm}", CommonFactory.GetCurrentDate());
                    lblIsImport.Visible = false;
                    //_isImport = true;
                    _isCompleted = true;

                    if (_mode == 1 || _mode == 2) // AddNew- Edit - Update mode
                    {
                        var count = 0;
                        foreach (var vehicleInfo in _vehicleInfosTemp)
                        {
                            count += 1;
                            if (count == _count)
                            {
                                if (vehicleInfo.ConfirmImportBy != null || vehicleInfo.ConfirmImportBy == 0)
                                {
                                    _isImport = true;
                                    vehicleInfo.IsImport = _isImport;
                                    vehicleInfo.ImportDate = Common.AddHourMinutes(dtpImportDate.Value,
                                                                                   mtxtImportHour.Text);
                                    vehicleInfo.ConfirmImportBy = _userInfo.UserID;
                                }
                                else
                                {
                                    if (vehicleInfo.ConfirmImportBy != null && vehicleInfo.ConfirmImportBy != _userInfo.UserID)
                                        throw new Exception("Phương tiện này đã được xác nhận xuất khẩu bởi người khác!");
                                }

                            }
                        }
                    }
                    else if (_mode == 4 || _mode == 3)
                    {
                        _isImport = true;
                    }
                }
                else
                {
                    dtpImportDate.Visible = false;
                    mtxtImportHour.Visible = false;
                    lblIsImport.Visible = true;
                    _isImport = false;
                    _isCompleted = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // add new vehicle
            try
            {
                if (!Validate()) return;

                // Add data to veicleInfo list
                var vehicleInfo = new ViewAllVehicleHasGood();
                vehicleInfo.DriverName = txtDriverName.Text.Trim();
                vehicleInfo.PlateNumber = StringUtil.RemoveAllNonAlphanumericString(txtPlateNumber.Text).ToUpper();
                vehicleInfo.PlateNumberPartner = StringUtil.RemoveAllNonAlphanumericString(txtVehicleChinese.Text).ToUpper();
                if (txtNumberOfContainer.Text != "")
                {
                    vehicleInfo.NumberOfContainer = txtNumberOfContainer.Text.Trim();
                }

                if (_isExport)
                {
                    vehicleInfo.ExportDate = dtpExportDate.Value;                    
                    vehicleInfo.ConfirmExportBy = _userInfo.UserID;
                }

                if (_isImport)
                {
                    vehicleInfo.ImportDate = dtpImportDate.Value;                    
                    vehicleInfo.ConfirmImportBy = _userInfo.UserID;
                }

                vehicleInfo.Status = txtStatus.Text;
                vehicleInfo.Note = txtNote.Text;                
                vehicleInfo.IsExport = _isExport;
                vehicleInfo.IsImport = _isImport;
                vehicleInfo.IsCompleted = _isCompleted;
                vehicleInfo.DeclarationID = _parrentDeclaration.DeclarationID;
                if (vehicleInfo.ExportDate != null && vehicleInfo.ExportDate.Value.Year.Equals(1900))
                {
                    vehicleInfo.ExportDate = null;
                }
                if (vehicleInfo.ImportDate != null && vehicleInfo.ImportDate.Value.Year.Equals(1900))
                {
                    vehicleInfo.ImportDate = null;
                }

                // Add Mode
                if (_mode == 0)
                {
                    // Bind to gridview.
                    _vehicleInfosTemp.Add(vehicleInfo);
                    _newAddingVehicles.Add(vehicleInfo);
                    ((FrmDecleExport)this.Owner).BindVehicle(_vehicleInfosTemp);
                }
                else
                {
                    // Insert into database
                    // _vehicleBOL.Insert(vehicleInfo);
                    _newAddingVehicles.Add(vehicleInfo);
                    // Bind to gridview.
                    // Get Vehicle by DeclarationID
                    var listVehicle = VehicleFactory.GetFromViewByDeclarationID((Convert.ToInt32(vehicleInfo.DeclarationID)));
                    ((FrmDecleExport)this.Owner).BindVehicle(listVehicle);

                }
                grdVehicle.DataSource = null;
                grdVehicle.DataSource = _newAddingVehicles;

                //Set curent cell for poiter to bottom
                this.grdVehicle.CurrentCell = this.grdVehicle[0, this.grdVehicle.Rows.Count - 1];

                // MessageBox.Show(ConstantInfo.MESSAGE_INSERT_SUCESSFULLY);
                ResetForm();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                // process when user updating new vehicle input
                if (!string.IsNullOrEmpty(_currentModifyPlateNumber))
                {
                    // update to list
                    var result = _newAddingVehicles.Where(v => v.PlateNumber.ToString().Equals(_currentModifyPlateNumber, StringComparison.InvariantCultureIgnoreCase)).ToList().FirstOrDefault();
                    if (result == null)
                    {
                        return;
                    }
                    result.DriverName = txtDriverName.Text.Trim();
                    result.PlateNumber = StringUtil.RemoveAllNonAlphanumericString(txtPlateNumber.Text).ToUpper();
                    result.PlateNumberPartner = StringUtil.RemoveAllNonAlphanumericString(txtVehicleChinese.Text).ToUpper();
                    result.NumberOfContainer = txtNumberOfContainer.Text;
                    result.Status = txtStatus.Text;
                    result.Note = txtNote.Text;

                    grdVehicle.Refresh();
                    ((FrmDecleExport)this.Owner).grdVehicle.DataSource = null;
                    ((FrmDecleExport)this.Owner).grdVehicle.DataSource = _vehicleInfosTemp;
                    // assign to emty when finsih proccessing
                    _currentModifyPlateNumber = string.Empty;

                    btnAdd.Enabled = true;
                    //btnAdd.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_MOI_PHUONG_TIEN);
                    btnUpdate.Enabled = false;
                    ResetForm();

                    return;
                }

                if (!Validate()) return;
                if (_mode == 1 || _mode == 2) // AddNew- Edit
                {
                    var count = 0;
                    foreach (var vehicleInfo in _vehicleInfosTemp)
                    {
                        count += 1;
                        if (count == _count)
                        {
                            vehicleInfo.DriverName = txtDriverName.Text.Trim();
                            vehicleInfo.PlateNumber = StringUtil.RemoveAllNonAlphanumericString(txtPlateNumber.Text).ToUpper();
                            vehicleInfo.PlateNumberPartner = StringUtil.RemoveAllNonAlphanumericString(txtVehicleChinese.Text).ToUpper();
                            vehicleInfo.NumberOfContainer = txtNumberOfContainer.Text.Trim();
                            vehicleInfo.ExportDate = dtpExportDate.Value;
                            // Add hour and minuites 
                            if (_isExport) {
                                vehicleInfo.ExportDate = Common.AddHourMinutes(vehicleInfo.ExportDate.Value, mtxtExportHour.Text);
                            }
                            if (_isImport) {
                                // Add hour and minuites 
                                vehicleInfo.ImportDate = Common.AddHourMinutes(vehicleInfo.ImportDate.Value, mtxtImportHour.Text);
                            }                                                        
                            
                            vehicleInfo.Status = txtStatus.Text;
                            vehicleInfo.Note = txtNote.Text;
                            vehicleInfo.IsCompleted = _isCompleted;
                            vehicleInfo.IsExport = _isExport;
                            vehicleInfo.IsImport = _isImport;

                            if ((vehicleInfo.ConfirmExportBy == null || vehicleInfo.ConfirmExportBy.Value == 0) && vehicleInfo.IsExport != null && vehicleInfo.IsExport.Value)
                                vehicleInfo.ConfirmExportBy = _userInfo.UserID;

                            if (vehicleInfo.ConfirmImportBy == 0 && vehicleInfo.IsImport.Value)
                                vehicleInfo.ConfirmImportBy = _userInfo.UserID;
                            break;
                        }
                    }
                    
                    ((FrmDecleExport)this.Owner).BindVehicle(_vehicleInfosTemp);
                    MessageBox.Show("Lưu thành công.");
                    this.Close();
                }

                if (_mode == 3) // Edit mode from Search form
                {                    
                    var vehicle = VehicleFactory.GetByID(_vehicleID);
                    vehicle.DriverName = txtDriverName.Text.Trim();
                    vehicle.PlateNumber = StringUtil.RemoveAllNonAlphanumericString(txtPlateNumber.Text).ToUpper();
                    vehicle.PlateNumberPartner = StringUtil.RemoveAllNonAlphanumericString(txtVehicleChinese.Text).ToUpper();
                    if (!string.IsNullOrEmpty(txtNumberOfContainer.Text.Trim()))
                        vehicle.NumberOfContainer = txtNumberOfContainer.Text.Trim();

                    vehicle.Status = txtStatus.Text;
                    vehicle.Note = txtNote.Text;
                    vehicle.IsExport = _isExport;
                    vehicle.IsImport = _isImport;

                    if ((vehicle.ConfirmExportBy == null || vehicle.ConfirmExportBy.Value == 0) && vehicle.IsExport.Value)
                        vehicle.ConfirmExportBy = _userInfo.UserID;

                    if ((vehicle.ConfirmImportBy == null || vehicle.ConfirmImportBy.Value == 0) && vehicle.IsImport.Value)
                        vehicle.ConfirmImportBy = _userInfo.UserID;

                    vehicle.IsCompleted = _isCompleted;
                    // Set datetime for export
                    if (_isExport)
                    {
                        var exportHour = Convert.ToInt32(mtxtExportHour.Text.Split(':')[0]);
                        var exportMinitues = Convert.ToInt32(mtxtExportHour.Text.Split(':')[1]);
                        vehicle.ExportDate = dtpExportDate.Value.AddHours(exportHour - dtpExportDate.Value.Hour);
                        vehicle.ExportDate = vehicle.ExportDate.Value.AddMinutes(exportMinitues - dtpExportDate.Value.Minute);
                    }
                    // Set datetime for import
                    if (_isImport)
                    {
                        var importHour = Convert.ToInt32(mtxtImportHour.Text.Split(':')[0]);
                        var importMinitues = Convert.ToInt32(mtxtImportHour.Text.Split(':')[1]);
                        vehicle.ImportDate = dtpImportDate.Value.AddHours(importHour - dtpImportDate.Value.Hour);
                        vehicle.ImportDate = vehicle.ImportDate.Value.AddMinutes(importMinitues - dtpImportDate.Value.Minute);
                    }

                    VehicleFactory.UpdateVehicle(vehicle);

                    MessageBox.Show("Cập nhật thành công.");
                    ((frmVehicleSearch)this._seachFrom).BindData();
                    this.Close();
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
                if (_mode == 1) // Add new - delete mode
                {
                    var count = 0;
                    foreach (var vehicleInfo in _vehicleInfosTemp)
                    {
                        count += 1;
                        if (count == _vehicleID)
                        {
                            _vehicleInfosTemp.Remove(vehicleInfo);
                            MessageBox.Show("Xóa xong");
                        }
                        break;
                    }
                    ((FrmDecleExport)this.Owner).BindVehicle(_vehicleInfosTemp);
                    this.Close();
                }
                if (_mode == 2) // Edit Mode - delete
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // Remove from tblDeclerationVehicle
                        DeclarationVehicleFactory.DeleteByVehicleDeclarationID(_vehicleID, _declarationID);
                        MessageBox.Show("Xóa thành công.");
                        this.Close();
                    }
                }

                if (_mode == 3) // From search
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                           
                        // Delete from database
                        VehicleFactory.DeleteByID(_vehicleID);
                        // Get Vehicle by DeclarationID
                        MessageBox.Show("Xóa thành công.");
                        ((frmVehicleSearch)this._seachFrom).BindData();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDriverName.Text = "";
            txtPlateNumber.Text = "";
            txtVehicleChinese.Text = "";
            txtNumberOfContainer.Text = "";
            dtpImportDate.Visible = false;
            dtpExportDate.Visible = false;
            mtxtImportHour.Visible = false;
            mtxtExportHour.Visible = false;
            lblIsImport.Visible = true;
            lblIsExport.Visible = true;
            _isImport = false;
            _isExport = false;
            txtStatus.Text = "";
            txtNote.Text = "";
        }

        /// <summary>
        /// Handles the KeyPress event of the txtPlateNumber control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyPressEventArgs"/> instance containing the event data.</param>
        private void txtPlateNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((_mode == 0 || _mode == 4) && e.KeyChar == 13)
                {
                    if (!Validate()) return;

                    // Add data to veicleInfo list
                    var vehicleInfo = new ViewAllVehicleHasGood();
                    vehicleInfo.DriverName = txtDriverName.Text.Trim();
                    vehicleInfo.PlateNumber = StringUtil.RemoveAllNonAlphanumericString(txtPlateNumber.Text).ToUpper();
                    vehicleInfo.PlateNumberPartner = StringUtil.RemoveAllNonAlphanumericString(txtVehicleChinese.Text).ToUpper();
                    if (txtNumberOfContainer.Text != "")
                    {
                        vehicleInfo.NumberOfContainer = txtNumberOfContainer.Text.Trim();
                    }

                    if (_isExport)
                    {
                        vehicleInfo.ExportDate = dtpExportDate.Value;
                        // add Hour minutes
                        vehicleInfo.ExportDate = Common.AddHourMinutes(vehicleInfo.ExportDate.Value, mtxtExportHour.Text);
                    }

                    if (_isImport)
                    {
                        vehicleInfo.ImportDate = dtpImportDate.Value;
                        vehicleInfo.ImportDate = Common.AddHourMinutes(vehicleInfo.ImportDate.Value, mtxtImportHour.Text);
                    }

                    vehicleInfo.Status = txtStatus.Text;
                    vehicleInfo.Note = txtNote.Text;
                    vehicleInfo.VehicleID = _vehicleInfosTemp.Count + 1;
                    vehicleInfo.IsExport = _isExport;
                    vehicleInfo.IsImport = _isImport;
                    vehicleInfo.IsCompleted = _isCompleted;
                    vehicleInfo.DeclarationID = _parrentDeclaration.DeclarationID;
                    if (vehicleInfo.ExportDate != null && vehicleInfo.ExportDate.Value.Year.Equals(1900))
                    {
                        vehicleInfo.ExportDate = null;
                    }
                    if (vehicleInfo.ImportDate != null && vehicleInfo.ImportDate.Value.Year.Equals(1900))
                    {
                        vehicleInfo.ImportDate = null;
                    }

                    _vehicleInfosTemp.Add(vehicleInfo);
                    _newAddingVehicles.Add(vehicleInfo);
                    ResetForm();
                    grdVehicle.DataSource = null;
                    grdVehicle.DataSource = _newAddingVehicles;
                    grdVehicle.Refresh();
                    //Set curent cell for poiter to bottom
                    this.grdVehicle.CurrentCell = this.grdVehicle[0, this.grdVehicle.Rows.Count - 1];


                    ((FrmDecleExport)this.Owner).BindVehicle(_vehicleInfosTemp);
                    txtPlateNumber.Focus();
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
            try
            {
                if (_newAddingVehicles.Count < 0) return;
                var driverName = txtDriverName.Text.Trim();
                var plateNumber = txtPlateNumber.Text.Trim();

                if (string.IsNullOrEmpty(driverName) && string.IsNullOrEmpty(plateNumber))
                {
                    grdVehicle.DataSource = _newAddingVehicles;
                    this.grdVehicle.CurrentCell = this.grdVehicle[0, this.grdVehicle.Rows.Count - 1];
                }

                var result = _newAddingVehicles.Where(v => (v.DriverName.IndexOf(driverName, StringComparison.InvariantCultureIgnoreCase) >= 0)
                                                               && (v.PlateNumber.IndexOf(plateNumber, StringComparison.InvariantCultureIgnoreCase) >= 0)).ToList();
                grdVehicle.DataSource = result;
                this.grdVehicle.CurrentCell = this.grdVehicle[0, this.grdVehicle.Rows.Count - 1];
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void grdVehicle_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var plateNumber = grdVehicle.Rows[e.RowIndex].Cells["PlateNumber"].Value.ToString();
                var result = _newAddingVehicles.Where(v => v.PlateNumber.ToString().Equals(plateNumber, StringComparison.InvariantCultureIgnoreCase)).ToList().FirstOrDefault();
                txtDriverName.Text = result.DriverName;
                txtPlateNumber.Text = result.PlateNumber;
                txtVehicleChinese.Text = result.PlateNumberPartner;
                txtNumberOfContainer.Text = result.NumberOfContainer.ToString();
                txtStatus.Text = result.Status;
                txtNote.Text = result.Note;
                if (result.ImportDate != null)
                {
                  mtxtImportHour.Text = result.ImportDate.Value.ToString("HH:mm");
                }
                if (result.ExportDate != null)
                {
                  mtxtExportHour.Text = result.ExportDate.Value.ToString("HH:mm");
                }
                _currentModifyPlateNumber = plateNumber;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void frmVehicle_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_parrentDeclaration == null || _parrentDeclaration.DeclarationID == 0)
                {
                    return;
                }
                // add to database when closing form
                foreach (var vehicle in _newAddingVehicles)
                {
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
                    v.Status = vehicle.Status;
                    v.IsCompleted = vehicle.IsCompleted;
                    v.IsGoodsImported = vehicle.IsGoodsImported;
                    v.ImportStatus = vehicle.ImportStatus;
                    v.ImportedLocalTime = vehicle.ImportedLocalTime;
                    v.HasGoodsImported = vehicle.HasGoodsImported;
                    v.ConfirmExportBy = vehicle.ConfirmExportBy;
                    v.ConfirmImportBy = vehicle.ConfirmImportBy;
                    v.ConfirmLocalImportBy = vehicle.ConfirmLocalImportBy;
                    VehicleFactory.InsertVehicle(v,_parrentDeclaration.DeclarationID);                                        
                }

                ((FrmDecleExport)this.Owner).grdVehicle.DataSource = null;
                var listVehicle = VehicleFactory.GetFromViewByDeclarationID(_parrentDeclaration.DeclarationID);
                ((FrmDecleExport)this.Owner).BindVehicle(listVehicle);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void txtPlateNumber_Leave(object sender, EventArgs e)
        {
          txtPlateNumber.Text = StringUtil.RemoveAllNonAlphanumericString(txtPlateNumber.Text).ToUpper();
        }

        private void grdVehicle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
          if ((e.ColumnIndex == 0) && (grdVehicle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null))
          {
            string newValue = StringUtil.RemoveAllNonAlphanumericString(grdVehicle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).ToUpper();
            grdVehicle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = newValue;
          }
        }
    }
}
