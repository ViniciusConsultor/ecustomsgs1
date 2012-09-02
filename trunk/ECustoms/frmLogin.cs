using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.RCM;
using System.Windows.Forms.ResourcesManager;
using ECustoms.BOL;
using ECustoms.Utilities;
using log4net;
using ECustoms.DAL;

namespace ECustoms
{
    public partial class frmLogin : SubFormBase
    {
        //private readonly ILog logger;
        private static log4net.ILog logger =  LogManager.GetLogger("Ecustoms.frmLogin");
        
        public frmLogin()
        {            
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        /// <summary>
        /// Logins this instance.
        /// </summary>
        private void Login()
        {
            try
            {
                //logger.Info("btnLogin_Click");
                if (Validate())
                {                    
                    var objTblUer = new tblUser();
                    objTblUer.UserName = txtUsername.Text.Trim();
                    objTblUer.Password = txtPassword.Text.Trim();
                    var userInfoNew = UserFactory.GetUserInfo(objTblUer);
                    
                    if (userInfoNew != null && !userInfoNew.UserName.Equals(string.Empty)) // Login sucessfully
                    {
                        // Bind UserInfo
                        var userInfo = new UserInfo();
                        userInfo.UserName = userInfoNew.UserName;
                        userInfo.Name = userInfoNew.Name;
                        userInfo.Password = userInfoNew.Password;
                        userInfo.UserID = userInfoNew.UserID;

                        //get all User's permission
                        userInfo.UserPermission = UserGroupPermissionFactory.GetAllPermissionOfUser(userInfo.UserID);
                        //if user is admin, set all permission for admin
                        if (userInfo.UserName == "admin")
                        {
                            userInfo.UserPermission = UserGroupPermissionFactory.GetAllPermissionForAdmin();
                        }
                        // Redirect to the main form
                        var mainForm = new frmMainForm(userInfo);
                        mainForm.WindowState = FormWindowState.Maximized;
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(ConstantInfo.MESSAGE_LOGIN_FAIL, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private bool  Validate()
        {
            techlinkErrorProvider1.Validate(this);
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {                  
            this.Text = "Dang nhap" +  ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            txtUsername.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            //this.Close();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Enter key
            {                                 
              Login();              
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Enter key
            {
                Login();
            }
        }       
    }
}
