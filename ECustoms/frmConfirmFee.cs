using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.DAL;
using ECustoms.Utilities;
using ECustoms.Utilities.Enums;
using log4net;
using ECustoms.BOL;

namespace ECustoms
{
    public partial class frmConfirmFee : Form
    {
        private static ILog logger = LogManager.GetLogger("ECustoms.frmConfirmFee");
        private UserInfo _userinfo;
        private int _mode; // 0 - add new, 1- edit
        private int _type; // 0 - XN phí xuất, 1 - XN phí nhập
        private long _vehicleId;

        public frmConfirmFee()
        {
            InitializeComponent();
            if (_mode == 0)
            {
                Init();
            }
        }

        public frmConfirmFee(UserInfo userInfo, int mode, int type, long vehicleId)
        {
            InitializeComponent();
            _userinfo = userInfo;
            _mode = mode;
            _type = type;
            _vehicleId = vehicleId;
            
            if (_mode == 0)
            {
                Init();
            }
            else
            {
                InitData();
            }
        }
       
        private void Init()
        {
            mtxtFeeHour.Text = string.Format("{0:HH:mm}", CommonFactory.GetCurrentDate());

            //auto fill fee
            var vehicleInfo = VehicleFactory.GetByID(_vehicleId);
            var goodTypeId = _type == 0 ? vehicleInfo.ExportGoodTypeId.GetValueOrDefault() : vehicleInfo.ImportGoodTypeId.GetValueOrDefault();
            tblVehicleFeeSetting vehiclFee = VehicleFeeSettingFactory.find(vehicleInfo.vehicleTypeId.GetValueOrDefault(), goodTypeId);
            if (vehiclFee != null)
            {
                txtMoney.Text = vehiclFee.Fee.ToString();
            }
        }

        private void InitData()
        {
            var vehicleInfo = VehicleFactory.GetByID(_vehicleId);
            if (_type == 0)
            {
                txtMoney.Text = vehicleInfo.feeExportAmount.ToString();
                txtReceipt.Text = vehicleInfo.ExportReceiptNumber;
                if (vehicleInfo.feeExportDate != null)
                {
                    dtpFee.Value = (DateTime)vehicleInfo.feeExportDate;
                    mtxtFeeHour.Text = string.Format("{0:HH:mm}", vehicleInfo.feeExportDate);
                }
            }
            else
            {
                txtMoney.Text = vehicleInfo.feeImportAmount.ToString();
                txtReceipt.Text = vehicleInfo.ImportReceiptNumber;
                if (vehicleInfo.feeImportDate != null)
                {
                    dtpFee.Value = (DateTime)vehicleInfo.feeImportDate;
                    mtxtFeeHour.Text = string.Format("{0:HH:mm}", vehicleInfo.feeImportDate);
                }    
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtReceipt.Text.Trim()))
            {
                MessageBox.Show("Số biên lai không được để trống!");
                txtReceipt.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtMoney.Text.Trim()))
            {
                MessageBox.Show("Số tiền thu không được để trống!");
                txtMoney.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(mtxtFeeHour.Text.Trim()))
            {
                MessageBox.Show("Giờ thu không được để trống!");
                mtxtFeeHour.Focus();
                return false;
            }
            else
            {
                var hour = mtxtFeeHour.Text.Split(':')[0];
                var minute = mtxtFeeHour.Text.Split(':')[1];
                if (string.IsNullOrEmpty(hour) || string.IsNullOrEmpty(minute)  || int.Parse(hour) >= 24 || int.Parse(minute) >= 60)
                {
                    MessageBox.Show("Giờ thu không đúng!");
                    mtxtFeeHour.Focus();
                    return false;
                }
            }
           
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConfirmFee_Load(object sender, EventArgs e)
        {
            this.Text = _type == 0 ? "Xac nhan thu phi xuat" : "Xac nhan thu phi nhap" + ConstantInfo.MESSAGE_TITLE;
        }

        private void btnConfirmFee_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                var vehicleInfo = VehicleFactory.GetByID(_vehicleId);
                var hour = mtxtFeeHour.Text.Split(':')[0];
                var minute = mtxtFeeHour.Text.Split(':')[1];
                var dateFee = new DateTime(dtpFee.Value.Year, dtpFee.Value.Month, dtpFee.Value.Day, int.Parse(hour), int.Parse(minute), 0);
                if (_type == 0)
                {
                    vehicleInfo.ExportReceiptNumber = txtReceipt.Text.Trim();
                    vehicleInfo.feeExportAmount = long.Parse(txtMoney.Text.Trim());
                    vehicleInfo.feeExportDate = dateFee;
                    vehicleInfo.feeExportStatus = (int) FeeStatus.PaidFee;
                    vehicleInfo.confirmFeeExportBy = _userinfo.UserID;
                }
                else
                {
                    vehicleInfo.ImportReceiptNumber = txtReceipt.Text.Trim();
                    vehicleInfo.feeImportAmount = long.Parse(txtMoney.Text.Trim());
                    vehicleInfo.feeImportDate = dateFee;
                    vehicleInfo.feeImportStatus = (int) FeeStatus.PaidFee;
                    vehicleInfo.confirmFeeImportBy = _userinfo.UserID;
                }
                VehicleFactory.UpdateVehicle(vehicleInfo);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
