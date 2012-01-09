using System;
using System.Drawing;
using System.Windows.Forms;
using ECustoms.Utilities;
using ECustoms.BOL;
using ECustoms.DAL;
using System.Linq;

namespace ECustoms
{
  public partial class FrmCheck : Form
  {
    private int _mode;
    private UserInfo _userInfo;
    private long _vehicleID;
    private int _vehicleCheckID;
    private int _checkID;
    private int _checkType = 0;
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("Ecustoms.FrmCheck");

    public FrmCheck()
    {
      InitializeComponent();
    }

    public FrmCheck(UserInfo userInfo, long vehicleID, int mode, int vehicleCheckID, int checkID)
    {
      InitializeComponent();
      _userInfo = userInfo;
      _vehicleID = vehicleID;
      _mode = mode;
      _vehicleCheckID = vehicleCheckID;
      _checkID = checkID;
    }

    public FrmCheck(UserInfo userInfo, long vehicleID, int checkID, int checkType)
    {
      InitializeComponent();
      _userInfo = userInfo;
      _vehicleID = vehicleID;
      var vehicleCheck = VehicleCheckFactory.GetExistingVehicleHasChecked(vehicleID).FirstOrDefault();
      if (vehicleCheck != null)
      {
        _mode = 1; // Edit Mode: neu da ton tai thong tin kiem tra doi voi phuong tien, thi update thong tin do
        _vehicleCheckID = vehicleCheck.VehicleCheckID;
      }
      else
      {
        _mode = 0; //add new: chua ton tai thong tin kiem tra doi voi phuong tien,  thi them moi
        _vehicleCheckID = 0;
      }
      _checkID = checkID;
      _checkType = checkType;
    }

    public FrmCheck(UserInfo userInfo, int mode)
    {
      InitializeComponent();
      _mode = mode;
      _userInfo = userInfo;
    }

    private void FrmCheck_Load(object sender, EventArgs e)
    {
      this.Text = "Nhập thông tin kiểm tra" + ConstantInfo.MESSAGE_TITLE;
      // Show form to the center
      this.Location = new Point((this.Owner.Owner.Width - this.Width) / 2, (this.Owner.Owner.Height - this.Height) / 2);
      Init();
    }

    private void Init()
    {
      try
      {
        if (_mode == 0)// New mode
        {
          btnAddVehicle.Enabled = true;
          btnUpdateVehicle.Enabled = false;
          lblHeader.Text = "Nhập thông tin kiểm tra phương tiện";
          var vehicle = VehicleFactory.GetByID(_vehicleID);
          lblPlateNumber.Text = vehicle.PlateNumber;
          lblExportDate.Text = vehicle.ExportDate != null ? vehicle.ExportDate.Value.ToString("dd/MM/yyy HH:mm") : "";
          lblImportDate.Text = vehicle.ImportDate != null ? vehicle.ImportDate.Value.ToString("dd/MM/yyy HH:mm") : "";
        }
        else // Edit Mode
        {
          btnAddVehicle.Enabled = false;
          btnUpdateVehicle.Enabled = true;
          lblHeader.Text = "Cập nhật thông tin kiểm tra phương tiện";
          // Get VehicleInfo
          var vehicle = VehicleFactory.GetByID(_vehicleID);
          lblPlateNumber.Text = vehicle.PlateNumber;
          lblExportDate.Text = vehicle.ExportDate != null ? vehicle.ExportDate.Value.ToString("dd/MM/yyy HH:mm") : "";
          lblImportDate.Text = vehicle.ImportDate != null ? vehicle.ImportDate.Value.ToString("dd/MM/yyy HH:mm") : "";
          // Get vehicleCheck
          var vehicleCheck = VehicleCheckFactory.SelectByID(_vehicleCheckID);
          txtResult.Text = vehicleCheck.Result;
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

    private void btnAddVehicle_Click(object sender, EventArgs e)
    {
      try
      {
        // Get check information
        var check = CheckFactory.SelectByID(_checkID);

        var vehicleCheck = new tblVehicleCheck();
        vehicleCheck.VehicleID = _vehicleID;
        vehicleCheck.RecievedBy = _userInfo.UserID;
        vehicleCheck.InputBy = _userInfo.UserID;
        vehicleCheck.Result = txtResult.Text;
        if (check != null)
        {
          vehicleCheck.CheckFrom = check.CheckFrom;
          vehicleCheck.CheckTo = check.CheckTo;
          vehicleCheck.CheckCode = check.CheckCode;
        }
        if (_checkType == VehicleCheckFactory.CHECK_TYPE_EXPORT)
        {
          vehicleCheck.IsExportChecked = true;
        }
        if (_checkType == VehicleCheckFactory.CHECK_TYPE_IMPORT)
        {
          vehicleCheck.IsImportChecked = true;
        }
        if (_checkType == VehicleCheckFactory.CHECK_TYPE_IMPORT_LOCAL)
        {
          vehicleCheck.IsLocalImportChecked = true;
        }

        VehicleCheckFactory.Insert(vehicleCheck);
        MessageBox.Show("Nhập thông tin xong");
        this.Owner.Close();
        this.Close();
      }
      catch (Exception ex)
      {
        logger.Error(ex.ToString());
        if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
      }      
    }

    private void btnUpdateVehicle_Click(object sender, EventArgs e)
    {
      try
      {
        var vehicleCheck = VehicleCheckFactory.SelectVehicleCheckByID(_vehicleCheckID);
        vehicleCheck.Result = txtResult.Text;
        vehicleCheck.InputBy = vehicleCheck.InputBy;

        if (_checkType == VehicleCheckFactory.CHECK_TYPE_EXPORT)
        {
          vehicleCheck.IsExportChecked = true;
        }

        if (_checkType == VehicleCheckFactory.CHECK_TYPE_IMPORT)
        {
          vehicleCheck.IsImportChecked = true;
        }
        if (_checkType == VehicleCheckFactory.CHECK_TYPE_IMPORT_LOCAL)
        {
          vehicleCheck.IsLocalImportChecked = true;
        }

        VehicleCheckFactory.Update(vehicleCheck);
        MessageBox.Show("Cập nhật thành công");
        if (_checkType == 0)
        {
          ((FrmCheckResult)this.Owner).Init();
        }
        else
        {
          this.Owner.Close();
          this.Close();
        }
        this.Close();
      }
      catch (Exception ex)
      {
        logger.Error(ex.ToString());
        if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
      }       
    }
  }
}
