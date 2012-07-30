using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ECustoms.Utilities;
using ECustoms.BOL;
using ECustoms.DAL;
using System.Linq;

namespace ECustoms
{
  public partial class FrmAlert : SubFormBase
  {
    private UserInfo _userInfo;
    private long _vehicleID;
    private int _checkID;
    private int _checkType;
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("Ecustoms.FrmAlert");

    public FrmAlert()
    {
      InitializeComponent();
    }

    //public FrmAlert(UserInfo userInfo, long vehicleID, int checkID)
    //{
    //  InitializeComponent();
    //  _userInfo = userInfo;
    //  _vehicleID = vehicleID;
    //  _checkID = checkID;
    //}

    public FrmAlert(UserInfo userInfo, long vehicleID, int checkID, int checkType)
    {
      InitializeComponent();
      _userInfo = userInfo;
      _vehicleID = vehicleID;
      _checkID = checkID;
      _checkType = checkType;
    }

    private void FrmAlert_Load(object sender, EventArgs e)
    {
      this.Text = "Canh bao" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
      // Show form to the center
      this.Location = new Point((this.Owner.Width - this.Width) / 2, (this.Owner.Height - this.Height) / 2);
      InitData();
    }

    private void InitData()
    {
      try
      {
        var vehicleInfos = DeclarationFactory.GetAllVehicleByVehicleID(_vehicleID);
        if (vehicleInfos == null || vehicleInfos.Count < 1) return;
        // Get DeclaationNumber
        var declarationNumber = new StringBuilder();
        for (int i = 0; i < vehicleInfos.Count; i++)
        {
          if (i != vehicleInfos.Count - 1)
          {
            declarationNumber.Append(vehicleInfos[i].Number);
            declarationNumber.Append(", ");
          }
          else
            declarationNumber.Append(vehicleInfos[i].Number);
        }
        // Set Header
        lblHeader.Text = "Đề nghị kiểm tra phương tiện " + vehicleInfos[0].PlateNumber + " tờ khai " +
                         declarationNumber;
      }
      catch (Exception ex)
      {
        logger.Error(ex.ToString());
        if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
      }

      
    }

    private void btnConfirm_Click(object sender, EventArgs e)
    {
      try
      {
        // Get check information
        var check = CheckFactory.SelectByID(_checkID);
        var vehicleCheck = VehicleCheckFactory.GetExistingVehicleHasChecked(_vehicleID).FirstOrDefault();
        if (vehicleCheck != null)
        {
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
          vehicleCheck.InputBy = _userInfo.UserID;

          if (check != null)
          {
            vehicleCheck.CheckFrom = check.CheckFrom;
            vehicleCheck.CheckTo = check.CheckTo;
          }

          

          //update
          VehicleCheckFactory.Update(vehicleCheck);
        }
        else
        {

          vehicleCheck = new tblVehicleCheck();
          vehicleCheck.VehicleID = _vehicleID;
          vehicleCheck.InputBy = _userInfo.UserID;

          if (check != null)
          {
            vehicleCheck.CheckFrom = check.CheckFrom;
            vehicleCheck.CheckTo = check.CheckTo;
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

          // Insert new 
          VehicleCheckFactory.Insert(vehicleCheck);
        }
        MessageBox.Show("Xác nhận cảnh báo thành công");
        this.Close();
      }
      catch (Exception ex)
      {
        logger.Error(ex.ToString());
        if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
      }
    }

    //private void btnConfirm_Click(object sender, EventArgs e)
    //{
    //  try
    //  {
    //    // Get check information
    //    var check = CheckFactory.SelectByID(_checkID);

    //    var vehicleCheck = new tblVehicleCheck();
    //    vehicleCheck.VehicleID = _vehicleID;
    //    vehicleCheck.InputBy = _userInfo.UserID;
    //    if(check != null)
    //    {
    //      vehicleCheck.CheckFrom = check.CheckFrom;
    //      vehicleCheck.CheckTo = check.CheckTo;
    //    }
    //    // Insert new 
    //    VehicleCheckFactory.Insert(vehicleCheck);
    //    MessageBox.Show("Xác nhận cảnh báo thành công");
    //    this.Close();
    //  } catch (Exception ex)
    //    {
    //      logger.Error(ex.ToString());
    //      if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
    //    }
    //}

    private void btnInput_Click(object sender, EventArgs e)
    {
      var frmCheck = new FrmCheck(_userInfo, _vehicleID, _checkID, _checkType);
      frmCheck.Show(this);
    }
  }
}
