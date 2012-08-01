using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.DAL;
using ECustoms.Utilities.Enums;
using log4net;
using ECustoms.Utilities;

namespace ECustoms
{
    public partial class frmProfileConfig : SubFormBase
    {
        private static ILog logger = LogManager.GetLogger("ECustoms.frmProfileConfig");
        private UserInfo _userInfo;
        public frmProfileConfig()
        {
            InitializeComponent();
        }

        public frmProfileConfig(UserInfo userInfo)
        {
            _userInfo = userInfo;
            InitializeComponent();
        }

        private void frmProfileConfig_Load(object sender, EventArgs e)
        {
            this.Text = "Cau hinh gia tri mac dinh" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName; 
            init();
        }

        public void init()
        {
            var listProfileConfig = UserFactory.GetProfileConfigByUserId(_userInfo.UserID);
            foreach (var profileConfig in listProfileConfig)
            {
                if (profileConfig.Type == (int)ProfileConfig.TypeCode)
                {
                    txtTypeCode.Text = profileConfig.Value;
                    txtTypeName.Text = TypeFactory.FindByCode(profileConfig.Value).TypeName;
                    continue;
                }
                if (profileConfig.Type == (int)ProfileConfig.CustomUnit)
                {
                    txtCustomCode.Text = profileConfig.Value;
                    txtCustomName.Text = CustomsFacory.FindByCode(profileConfig.Value).CustomsName;
                }
            }

            //Autocomplete
            var autoType = new AutoCompleteStringCollection();
            var lstAutoType = TypeFactory.getAllType().Select(t=>t.TypeCode).ToArray();
            autoType.AddRange(lstAutoType);
            txtTypeCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTypeCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTypeCode.AutoCompleteCustomSource = autoType;

            var autoCustom = new AutoCompleteStringCollection();
            var lstAutoCustom = CustomsFacory.getAll().Select(t => t.CustomsCode).ToArray();
            autoCustom.AddRange(lstAutoCustom);
            txtCustomCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCustomCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCustomCode.AutoCompleteCustomSource = autoCustom;
   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validate()
        {
            if (!techlinkErrorProvider1.Validate(this)) return false;
            if (!string.IsNullOrEmpty(txtTypeCode.Text.Trim()) && TypeFactory.FindByCode(txtTypeCode.Text.Trim()) == null)
            {
                MessageBox.Show("Mã loại hình không tồn tại");
                txtTypeCode.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtCustomCode.Text.Trim()) && CustomsFacory.FindByCode(txtCustomCode.Text.Trim()) == null)
            {
                MessageBox.Show("Mã đơn vị hải quan không tồn tại");
                txtCustomCode.Focus();
                return false;
            }
            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate())
                {
                    var listProfileConfig = new List<tblProfileConfig>();
                    if (!string.IsNullOrEmpty(txtTypeCode.Text.Trim()))
                    {
                        var item = new tblProfileConfig
                                       {
                                           Type = (int) ProfileConfig.TypeCode,
                                           Value = txtTypeCode.Text.Trim()
                                       };
                        listProfileConfig.Add(item);
                    }
                    if (!string.IsNullOrEmpty(txtCustomCode.Text.Trim()))
                    {
                        var item = new tblProfileConfig
                                       {
                                           Type = (int) ProfileConfig.CustomUnit,
                                           Value = txtCustomCode.Text.Trim()
                                       };
                        listProfileConfig.Add(item);
                    }
                    UserFactory.UpdateProfileConfig(_userInfo.UserID, listProfileConfig);
                    MessageBox.Show("Cập nhật thành công");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            } 
        }

        private void txtTypeCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTypeCode.Text.Trim())) return;
            var type = TypeFactory.FindByCode(txtTypeCode.Text.Trim());
            if (type == null)
            {
                MessageBox.Show("Mã loại hình không tồn tại");
                txtTypeCode.Focus();
            }
            else
                txtTypeName.Text = type.TypeName;
        }

        private void txtCustomCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomCode.Text.Trim())) return;
            var custom = CustomsFacory.FindByCode(txtCustomCode.Text.Trim());
            if (custom == null)
            {
                MessageBox.Show("Mã đơn vị hải quan không tồn tại");
                txtCustomName.Focus();
            }
            else
                txtCustomName.Text = custom.CustomsName;
        }
    }
}
