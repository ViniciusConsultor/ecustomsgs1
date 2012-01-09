using System;
using System.Drawing;
using System.Windows.Forms;
using ECustoms.Utilities;
using ECustoms.BOL;
using log4net;

namespace ECustoms
{
    public partial class frmChangePassword : Form
    {
        private static log4net.ILog logger = LogManager.GetLogger("Ecustoms.frmLogin");
        private UserInfo _userInfo;
        private UserFactory _userBOL = new UserFactory();
        public frmChangePassword(UserInfo userInfor)
        {
            InitializeComponent();
            txtPassOld.Focus();
            var userInfoTemp = UserFactory.GetByID(userInfor.UserID);
            var user = new UserInfo();
            user.UserID = userInfoTemp.UserID;
            user.Password = userInfoTemp.Password;
            user.UserName = userInfoTemp.Password;
            _userInfo = user;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {                
                if (Validate())
                {
                  var user = UserFactory.GetByID(_userInfo.UserID);
                  user.Password = txtPassword.Text.Trim();
              
                  // Update
                  MessageBox.Show(UserFactory.Update(user) > 0
                                    ? ConstantInfo.MESSAGE_UPDATE_SUCESSFULLY
                                    : ConstantInfo.MESSAGE_UPDATE_FAIL);

                  this.Close();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtPassOld.Text.Trim()))
            {
                MessageBox.Show(ConstantInfo.MESSAGE_BLANK_PASSWORD);
                txtPassOld.Focus();
                return false;
            }

            if (!Common.Encode(txtPassOld.Text.Trim()).Equals(_userInfo.Password))
            {
                MessageBox.Show(ConstantInfo.MESSAGE_INCORRECT_PASS);
                txtPassOld.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show(ConstantInfo.MESSAGE_BLANK_PASSWORD);
                txtPassword.Focus();
                return false;
            }


            if (!txtPassword.Text.Trim().Equals(txtRetypePassword.Text.Trim()))
            {
                MessageBox.Show(ConstantInfo.MESSAGE_COMPARE_PASSWORD);
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

          this.Text = "Thay đổi mật khẩu" + ConstantInfo.MESSAGE_TITLE;
          // Show form to the center
          this.Location = new Point((this.Owner.Width - this.Width) / 2, (this.Owner.Height - this.Height) / 2);
          txtPassOld.Focus();
        }
    }
}
