using System;
using System.Linq;
using System.Windows.Forms;
using ECustoms.Utilities;
using ECustoms.Utilities.Enums;
using log4net;
using ECustoms.BOL;

namespace ECustoms
{
    public partial class frmDeclarationFee : SubFormBase
    {
        private static ILog logger = LogManager.GetLogger("ECustoms.frmDeclarationFee");
        private UserInfo _userinfo;
        private int _type; // 0 - XN phí xuất, 1 - XN phí nhập
        private long _declarationId;
        private int _declarationNumber;

        public frmDeclarationFee()
        {
            InitializeComponent();
            Init();
        }

        public frmDeclarationFee(UserInfo userInfo, int type, long declarationId, int declarationNumber)
        {
            InitializeComponent();
            _userinfo = userInfo;
            _type = type;
            _declarationId = declarationId;
            _declarationNumber = declarationNumber;
            Init();
        }
       
        private void InitFee()
        {
            var listFee = VehicleFeeSettingFactory.getAllVehicleFeeSetting();
            for (int i = 0; i < grdVehicle.Rows.Count; i++)
            {
                var vehicleInfo = VehicleFactory.GetByID(Convert.ToInt64(grdVehicle.Rows[i].Cells["VehicleID"].Value));
                if (_type == 0)
                {
                    if (vehicleInfo.feeExportStatus == null || vehicleInfo.feeExportStatus == (int) FeeStatus.HasNotPayFee)
                    {
                        var feeSetting = listFee.Where(f => f.VehicleTypeId == vehicleInfo.vehicleTypeId && f.GoodsTypeId == vehicleInfo.ExportGoodTypeId).FirstOrDefault();
                        var amount = feeSetting != null ? (feeSetting.Fee ?? 0) : 0;
                        grdVehicle.Rows[i].Cells["feeExportAmount"].Value = amount;
                    }
                }
                else
                {
                    if (vehicleInfo.feeImportStatus == null || vehicleInfo.feeImportStatus == (int)FeeStatus.HasNotPayFee)
                    {
                        var feeSetting = listFee.Where(f => f.VehicleTypeId == vehicleInfo.vehicleTypeId && f.GoodsTypeId == vehicleInfo.ImportGoodTypeId).FirstOrDefault();
                        var amount = feeSetting != null ? (feeSetting.Fee ?? 0) : 0;
                        grdVehicle.Rows[i].Cells["feeImportAmount"].Value = amount;
                    }    
                }
            }
        }

        private void Init()
        {
            if (_type == 0)
            {
                btnFee.Image = Properties.Resources._1336316540_document_export;
                btnFee.Text = "Thu phí xuất";
                lblHeader.Text = string.Format(lblHeader.Text, "xuất", _declarationNumber);
                grdVehicle.Columns["ExportGoodType"].Visible = grdVehicle.Columns["ExportReceiptNumber"].Visible = grdVehicle.Columns["feeExportAmount"].Visible = true;
                grdVehicle.Columns["ImportGoodType"].Visible = grdVehicle.Columns["ImportReceiptNumber"].Visible = grdVehicle.Columns["feeImportAmount"].Visible = false;
            }
            else
            {
                lblHeader.Text = string.Format(lblHeader.Text, "nhập", _declarationNumber);
                grdVehicle.Columns["ExportGoodType"].Visible = grdVehicle.Columns["ExportReceiptNumber"].Visible = grdVehicle.Columns["feeExportAmount"].Visible = false;
                grdVehicle.Columns["ImportGoodType"].Visible = grdVehicle.Columns["ImportReceiptNumber"].Visible = grdVehicle.Columns["feeImportAmount"].Visible = true;
            }
        }

        private void InitData()
        {
            var listVehicle = VehicleFactory.GetFromViewByDeclarationID(_declarationId);
            grdVehicle.AutoGenerateColumns = false;
            grdVehicle.DataSource = listVehicle;
            // Add to count Column
            for (int i = 0; i < grdVehicle.Rows.Count; i++)
            {
                grdVehicle.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
            grdVehicle.Columns[0].ReadOnly = true;
            
            InitFee();
        }

        private bool Validate()
        {
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDeclarationFee_Load(object sender, EventArgs e)
        {
            this.Text = _type == 0 ? "Xac nhan thu phi xuat" : "Xac nhan thu phi nhap" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            InitData();
        }

        private void btnFee_Click(object sender, EventArgs e)
        {
            try
            {
                var dateFee = CommonFactory.GetCurrentDate();
                for (int i = 0; i < grdVehicle.Rows.Count; i++)
                {
                    var vehicleId = grdVehicle.Rows[i].Cells["VehicleID"].Value;
                    var vehicleInfo = VehicleFactory.GetByID(Convert.ToInt64(vehicleId));
                    if (_type == 0)
                    {
                        if ((grdVehicle.Rows[i].Cells["ExportReceiptNumber"].Value == null) || string.IsNullOrEmpty(grdVehicle.Rows[i].Cells["ExportReceiptNumber"].Value.ToString().Trim()) || (grdVehicle.Rows[i].Cells["feeExportAmount"].Value == null))
                        {
                            if (vehicleInfo.feeExportStatus == (int) FeeStatus.PaidFee)
                            {
                                vehicleInfo.ExportReceiptNumber = null;
                                vehicleInfo.feeExportAmount = null;
                                vehicleInfo.feeExportDate = null;
                                vehicleInfo.feeExportStatus = (int) FeeStatus.HasNotPayFee;
                                vehicleInfo.confirmFeeExportBy = _userinfo.UserID;
                            }
                            else
                                continue;
                        }
                        else
                        {
                            vehicleInfo.ExportReceiptNumber = grdVehicle.Rows[i].Cells["ExportReceiptNumber"].Value.ToString().Trim();
                            vehicleInfo.feeExportAmount = Convert.ToInt64(grdVehicle.Rows[i].Cells["feeExportAmount"].Value);
                            vehicleInfo.feeExportDate = dateFee;
                            vehicleInfo.feeExportStatus = (int)FeeStatus.PaidFee;
                            vehicleInfo.confirmFeeExportBy = _userinfo.UserID;    
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
                                vehicleInfo.confirmFeeExportBy = _userinfo.UserID;
                            }
                            else
                                continue;
                        }
                        else
                        {
                            vehicleInfo.ImportReceiptNumber = grdVehicle.Rows[i].Cells["ImportReceiptNumber"].Value.ToString().Trim();
                            vehicleInfo.feeImportAmount = Convert.ToInt64(grdVehicle.Rows[i].Cells["feeImportAmount"].Value);
                            vehicleInfo.feeImportDate = dateFee;
                            vehicleInfo.feeImportStatus = (int)FeeStatus.PaidFee;
                            vehicleInfo.confirmFeeImportBy = _userinfo.UserID;
                        }
                    }
                    VehicleFactory.UpdateVehicle(vehicleInfo);
                }
                MessageBox.Show("Cập nhật thành công");
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
