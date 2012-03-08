using System;
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
            //declarationInfo.DeclarationType = declarationInfo.DeclarationType;
            //declarationInfo.Number = !string.IsNullOrEmpty(txtExportNumber.Text) ? Convert.ToInt32(txtExportNumber.Text.Trim()) : 0;
            //declarationInfo.Type = txtTypeExport.Text.Trim();
            //declarationInfo.CompanyName = txtExportCompanyName.Text;
            //declarationInfo.CompanyCode = txtExportCompanyCode.Text;
            //declarationInfo.RegisterDate = dtpExportRegisterDate.Value;
            //declarationInfo.ProductAmount = lblGateExport.Text.Trim();
            //declarationInfo.Unit = txtExportUnit.Text.Trim();
            //declarationInfo.ProductName = txtExportProductName.Text;
            //declarationInfo.ModifiedDate = CommonFactory.GetCurrentDate();
            //declarationInfo.ModifiedByID = _userInfo.UserID;
            //declarationInfo.CreatedDate = CommonFactory.GetCurrentDate();
            //declarationInfo.RegisterPlace = txtRegisterPlace.Text.Trim();
            //declarationInfo.Money = !string.IsNullOrEmpty(txtMoney.Text) ? Convert.ToInt32(txtMoney.Text.Trim()) : 0;
            declarationInfo.NumberHandover = !string.IsNullOrEmpty(txtNumberHandover.Text) ? Convert.ToInt32(txtNumberHandover.Text.Trim()) : 0;
            declarationInfo.DateHandover = dtpHandover.Value;
            declarationInfo.PersonHandover = txtPersonHandover.Text.Trim();
            //declarationInfo.DateReturn = dtpReturn.Value;
            declarationInfo.TypeOption = (short)_declerationOptionType;
            if (_declerationOptionType == Common.DeclerationOptionType.TNTX)
            {
                declarationInfo.NumberTemp = !string.IsNullOrEmpty(txtNumberTemp.Text) ? txtNumberTemp.Text.Trim() : "";
                declarationInfo.Seal = txtSeal.Text.Trim();
                declarationInfo.GateExport = txtGateExport.Text.Trim();

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
                    break;
                case Common.DeclerationOptionType.NKCK:
                    //System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#c1ffc0");
                    //this.BackColor = col ;
                    lblHeader.Text = "Nhập khẩu chuyển cửa khẩu";
                    gbExportDeclaration.Text = "Thông tin tờ khai nhập khẩu";
                    pnTNTX.Visible = false;
                    break;
                case Common.DeclerationOptionType.TNTX:
                    lblHeader.Text = "Tạm nhập tái xuất";
                    gbExportDeclaration.Text = "Thông tin tờ khai nhập";
                    //Autocomplete
                    var auto = new AutoCompleteStringCollection();
                    var lstAuto = DeclarationFactory.GetAllGateExport();
                    auto.AddRange(lstAuto.ToArray());
                    txtGateExport.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtGateExport.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtGateExport.AutoCompleteCustomSource = auto;
                    break;
                default:
                    break;
            }

            btnUpdate.Enabled = true;
            btnUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_TO_KHAI);

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
                //Option infomation
                txtNumberHandover.Text = declarationInfo.NumberHandover != null ? declarationInfo.NumberHandover.ToString() : "";
                dtpHandover.Value = declarationInfo.DateHandover != null ? declarationInfo.DateHandover.Value : DateTime.Now;
                if (declarationInfo.DateReturn == null)
                {
                    btConfirmReturn.Enabled = true;
                    dtpReturn.Visible = false;
                }
                else
                {
                    dtpReturn.Value = declarationInfo.DateReturn.Value;
                    btConfirmReturn.Enabled = false;
                }
                txtPersonHandover.Text = declarationInfo.PersonHandover;
                if (declarationInfo.PersonConfirmReturnID != null)
                {
                    txtPersonConfirmReturn.Text = UserFactory.GetByID((int)declarationInfo.PersonConfirmReturnID).Name;
                }

                if (_declerationOptionType.Equals(Common.DeclerationOptionType.TNTX))
                {
                    txtNumberTemp.Text = declarationInfo.NumberTemp ?? "";
                    txtSeal.Text = declarationInfo.Seal ?? "";
                    txtGateExport.Text = declarationInfo.GateExport ?? "";
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
            btnUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_TO_KHAI);
        }

        private void FrmDecleOption_Load(object sender, EventArgs e)
        {
            txtExportTotalVehicles.Focus();
            this.Text = "Quản lý hàng NTX, CK" + ConstantInfo.MESSAGE_TITLE;
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
                dtpReturn.Value = DateTime.Now;
                dtpReturn.Visible = true;
                MessageBox.Show("Xác nhận hồi báo thành công.");
                btConfirmReturn.Enabled = false;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

    }
}
