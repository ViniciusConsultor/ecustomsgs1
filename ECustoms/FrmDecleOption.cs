using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.DAL;
using ECustoms.Utilities;

namespace ECustoms
{
    public partial class FrmDecleExportOption : Form
    {
        #region Private variables
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("Ecustoms.FrmDecleExport");
        private long _declerationID;
        private UserInfo _userInfo;
        private Form _mainForm;
        private Common.DeclerationOptionType _declerationOptionType;
        #endregion

        public FrmDecleExportOption(UserInfo userInfo, Common.DeclerationOptionType declerationOptionType, Form mainForm)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _mainForm = mainForm;
            _declerationOptionType = declerationOptionType;
        }

        public FrmDecleExportOption(Form mainForm, UserInfo userInfo, long declerationID, Common.DeclerationOptionType declerationOptionType)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _declerationID = declerationID;
            _mainForm = mainForm;
            _declerationOptionType = declerationOptionType;
        }

        public FrmDecleExportOption(UserInfo userInfo, Form mainForm)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _mainForm = mainForm;
        }


        #region Private methods

        /// <summary>
        /// Get information from UI        
        /// </summary>
        /// <returns></returns>
        private tblDeclaration GetDeclarationInfo(ref tblDeclaration declarationInfo)
        {
            declarationInfo.NumberHandover = !string.IsNullOrEmpty(txtNumberHandover.Text) ? Convert.ToInt32(txtNumberHandover.Text.Trim()) : 0;
            declarationInfo.DateHandover = dtpHandover.Value;
            declarationInfo.PersonHandoverID = _userInfo.UserID;
            //declarationInfo.DateReturn = dtpReturn.Value;
            declarationInfo.TypeOption = (short)_declerationOptionType;
            if (_declerationOptionType == Common.DeclerationOptionType.TNTX)
            {
                declarationInfo.NumberTemp = !string.IsNullOrEmpty(txtNumberTemp.Text) ? txtNumberTemp.Text.Trim() : "";
                declarationInfo.Seal = txtSeal.Text.Trim();
               

            }
            if (_declerationOptionType == Common.DeclerationOptionType.TNTX || _declerationOptionType == Common.DeclerationOptionType.XKCK)
            {
                declarationInfo.GateExport = txtExportGateCode.Text.Trim();
            }

            if (_declerationOptionType == Common.DeclerationOptionType.NKCK)
            {
                declarationInfo.GateImport = txtImportGateCode.Text.Trim();
            }
            return declarationInfo;
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

            if (pnImportGate.Visible == true)
            {
                String gateCode = txtImportGateCode.Text.Trim();
                if (string.IsNullOrEmpty(gateCode) == false)
                {
                    tblGate gate = GateFactory.FindByCode(gateCode);
                    if (gate == null)
                    {
                        MessageBox.Show("Không tồn tại cửa khẩu này");
                        txtExportGateCode.Focus();
                        return false;
                    }

                }
            }
            if (pnExportGate.Visible == true)
            {
                String gateCode = txtExportGateCode.Text.Trim();
                if (string.IsNullOrEmpty(gateCode) == false)
                {
                    tblGate gate = GateFactory.FindByCode(gateCode);
                    if (gate == null)
                    {
                        MessageBox.Show("Không tồn tại cửa khẩu này");
                        txtImportGateCode.Focus();
                        return false;
                    }

                }
            }
            return true;
        }

        /// <summary>
        /// Init data
        /// </summary>
        private void Init()
        {
            switch (_declerationOptionType)
            {
                case Common.DeclerationOptionType.XKCK:
                    //System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#ffc0c0");
                    //this.BackColor = col;
                    lblHeader.Text = "Xuất khẩu chuyển cửa khẩu";
                    gbExportDeclaration.Text = "Thông tin tờ khai xuất khẩu";
                    pnTNTX.Visible = false;
                    pnXKCK.Visible = true;
                    pnExportGate.Visible = true;
                    break;
                case Common.DeclerationOptionType.NKCK:
                    //System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#c1ffc0");
                    //this.BackColor = col ;
                    lblHeader.Text = "Nhập khẩu chuyển cửa khẩu";
                    gbExportDeclaration.Text = "Thông tin tờ khai nhập khẩu";
                    pnTNTX.Visible = false;
                    pnImportGate.Visible = true;
                    break;
                case Common.DeclerationOptionType.TNTX:
                    lblHeader.Text = "Tạm nhập tái xuất";
                    gbExportDeclaration.Text = "Thông tin tờ khai nhập";
                    //Autocomplete
                    var auto = new AutoCompleteStringCollection();
                    var lstAuto = DeclarationFactory.GetAllGateExport();
                    auto.AddRange(lstAuto.ToArray());
                    txtExportGateCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtExportGateCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtExportGateCode.AutoCompleteCustomSource = auto;
                    pnExportGate.Visible = true;
                    break;
                default:
                    break;
            }

            btnUpdate.Enabled = true;
            btnUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_BO_XUNG_THONG_TIN_TNTX);
            if (_userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_BO_XUNG_THONG_TIN_TNTX)==false)
            {
                txtNumberHandover.Enabled=false;
                dtpHandover.Enabled=false;
                txtPersonHandover.Enabled=false;
                dtpReturn.Enabled=false;
                txtNumberTemp.Enabled=false;
                txtSeal.Enabled=false;
                txtExportGateCode.Enabled = false;
            }

            // Get Decleration information
            var declarationInfo = DeclarationFactory.GetByID(this._declerationID);
            // Bind Declaration to controls
            if (declarationInfo != null)
            {
                txtExportNumber.Text = declarationInfo.Number.ToString();
                txtExportProductName.Text = declarationInfo.ProductName;
                txtExportCompanyName.Text = declarationInfo.CompanyName;
                lblGateExport.Text = declarationInfo.ProductAmount;
                txtExportUnit.Text = declarationInfo.Unit;
                txtTypeExport.Text = declarationInfo.Type;
                txtExportCompanyCode.Text = declarationInfo.CompanyCode;
                dtpExportRegisterDate.Value = declarationInfo.RegisterDate != null ? declarationInfo.RegisterDate.Value : CommonFactory.GetCurrentDate();
                txtRegisterPlace.Text = declarationInfo.RegisterPlace;
                txtMoney.Text = declarationInfo.Money.ToString();
                txtImportGateCode.Text = declarationInfo.GateImport;
                txtExportGateCode.Text = declarationInfo.GateExport;
                //Option infomation
                txtNumberHandover.Text = declarationInfo.NumberHandover != null ? declarationInfo.NumberHandover.ToString() : "";
                dtpHandover.Value = declarationInfo.DateHandover != null ? declarationInfo.DateHandover.Value : CommonFactory.GetCurrentDate();
                if (declarationInfo.DateReturn == null)
                {
                    
                    btConfirmReturn.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_HOI_BAO_TNTX);
                    dtpReturn.Visible = false;
                }
                else
                {
                    dtpReturn.Value = declarationInfo.DateReturn.Value;
                    btConfirmReturn.Enabled = false;
                }
                if (declarationInfo.PersonHandoverID != null)
                {
                    txtPersonHandover.Text = UserFactory.GetByID((int)declarationInfo.PersonHandoverID).Name;
                }
                if (declarationInfo.PersonConfirmReturnID != null)
                {
                    txtPersonConfirmReturn.Text = UserFactory.GetByID((int)declarationInfo.PersonConfirmReturnID).Name;
                }

                if (_declerationOptionType.Equals(Common.DeclerationOptionType.TNTX))
                {
                    txtNumberTemp.Text = declarationInfo.NumberTemp ?? "";
                    txtSeal.Text = declarationInfo.Seal ?? "";
                    txtExportGateCode.Text = declarationInfo.GateExport ?? "";
                    if (declarationInfo.DeclarationType == (short)Common.DeclerationType.Export)
                    {
                        gbExportDeclaration.Text = "Thông tin tờ khai xuất";
                        lblNumberTemp.Text = "Số tờ khai nhập";
                    }
                    else
                    {
                        gbExportDeclaration.Text = "Thông tin tờ khai nhập";
                        lblNumberTemp.Text = "Số tờ khai xuất";
                    }
                }
                // Get Vehicle by DeclarationID
                var listVehicle = VehicleFactory.GetFromViewByDeclarationID(this._declerationID);
                txtExportTotalVehicles.Text = listVehicle.Count.ToString();
                if (_declerationOptionType.Equals(Common.DeclerationOptionType.XKCK))
                {
                    grvVehicle.AutoGenerateColumns = false;
                    grvVehicle.DataSource = listVehicle;
                    var status = 0;
                    for (var i = 0; i < grvVehicle.Rows.Count; i++)
                    {
                        grvVehicle.Rows[i].Cells["Index"].Value = (i + 1).ToString();
                        if (grvVehicle.Rows[i].Cells["IsExport"].Value !=null && bool.Parse(grvVehicle.Rows[i].Cells["IsExport"].Value.ToString()))
                        {
                            //grvVehicle.Rows[i].Cells["StatusVehicle"].Value =  "Đã xuất cảnh";
                            status++;
                        }
                    }
                    if (status == grvVehicle.Rows.Count)
                    {
                        lblStatus.Text = status == 0 ? "Không có hàng hóa cho tờ khai này" : "Hàng hóa đã xuất khẩu";
                    }
                    else if ((status < grvVehicle.Rows.Count) && status == 0)
                    {
                        lblStatus.Text = "Chưa xuất khẩu";        
                    }
                    else
                    {
                        lblStatus.Text = string.Format("Chưa xuất khẩu hết, còn tồn {0} xe", (grvVehicle.Rows.Count - status)); 
                    }
                }



                String exportGateCode = txtExportGateCode.Text.Trim();
                if (string.IsNullOrEmpty(exportGateCode) == false)
                {
                    tblGate gate = GateFactory.FindByCode(exportGateCode);
                    if (gate != null)
                    {
                        txtExportGateName.Text = gate.GateName;
                    }

                }

                String importGateCode = txtImportGateCode.Text.Trim();
                if (string.IsNullOrEmpty(importGateCode) == false)
                {
                    tblGate gate = GateFactory.FindByCode(importGateCode);
                    if (gate != null)
                    {
                        txtImportGateName.Text = gate.GateName;
                    }

                }

            }
        }

        #endregion

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
                    txtPersonHandover.Text = _userInfo.Name;
                    MessageBox.Show("Cập nhật thành công");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void CheckPermission()
        {
            btnUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_BO_XUNG_THONG_TIN_TNTX);
        }

        private void FrmDecleOption_Load(object sender, EventArgs e)
        {
            txtExportTotalVehicles.Focus();
            this.Text = "Quan ly hang NTX, CK" + ConstantInfo.MESSAGE_TITLE;
            // Show form to the center            
            this.Location = new Point((_mainForm.Width - this.Width) / 2, (_mainForm.Height - this.Height) / 2);

            //check user permission
            CheckPermission();
            // Init form.
            Init();
            //InitialPermission();

        }

        private void btConfirmReturn_Click(object sender, EventArgs e)
        {
            try
            {
                DeclarationFactory.UpdateReturnInfo(_declerationID, _userInfo.UserID);
                dtpReturn.Value = CommonFactory.GetCurrentDate();
                dtpReturn.Visible = true;
                txtPersonConfirmReturn.Text = _userInfo.Name;
                MessageBox.Show("Xác nhận hồi báo thành công.");
                btConfirmReturn.Enabled = false;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }


        private void txtImportGateCode_Leave(object sender, EventArgs e)
        {
            txtImportGateName.Text = "";
            String gateCode = txtImportGateCode.Text.Trim();
            if (string.IsNullOrEmpty(gateCode) == false)
            {
                tblGate gate = GateFactory.FindByCode(gateCode);
                if (gate != null)
                {
                    txtImportGateName.Text = gate.GateName;
                }

            }
        }

        private void txtExportGateCode_Leave_1(object sender, EventArgs e)
        {
            txtExportGateName.Text = "";
            String gateCode = txtExportGateCode.Text.Trim();
            if (string.IsNullOrEmpty(gateCode) == false)
            {
                tblGate gate = GateFactory.FindByCode(gateCode);
                if (gate != null)
                {
                    txtExportGateName.Text = gate.GateName;
                }

            }
        }

    }
}
