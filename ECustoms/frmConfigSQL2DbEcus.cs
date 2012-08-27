using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using TechLink.DatabaseViewer.DataAccess;

namespace ECustoms
{
    public partial class frmConfigSQL2DbEcus : SubFormBase
    {
        public frmConfigSQL2DbEcus()
        {
            InitializeComponent();
            //txtServer.Text = Dns.GetHostName();
            initData();
        }
        private void initData()
        {
            if (ConfigurationManager.ConnectionStrings["dbEcusDeclaration"] == null) txtServer.Text = Dns.GetHostName();
            else
            {
                var sConnection = ConfigurationManager.ConnectionStrings["dbEcusDeclaration"].ConnectionString;
                txtServer.Text = getSubString(sConnection, "Data Source=");
                if (sConnection.IndexOf("Integrated Security=") > 0)
                {
                    var sAuthen = getSubString(sConnection, "Integrated Security=");
                    if (sAuthen.Equals("SSPI"))
                    {
                        rbIntergrated.Checked = true;
                    }
                }
                else
                {
                    rbUser.Checked = true;
                    txtUser.Text = getSubString(sConnection, "User Id=");
                    txtPassword.Text = getSubString(sConnection, "Password=");
                }
                groupBox2_Leave(null, null);
                var dbName = getSubString(sConnection, "Initial Catalog=");
                cbDatabase.SelectedValue = dbName;
            }
        }
        private string getSubString (string s, string sIndex, string sLastIndex = ";")
        {
            var startIndex = s.LastIndexOf(sIndex) + sIndex.Length;
            var endIndex = s.IndexOf(sLastIndex, startIndex);
            var length = endIndex >= s.Length ? s.Length - startIndex : endIndex - startIndex;
            return s.Substring(startIndex, length);
        }
        private void rbUser_CheckedChanged(object sender, EventArgs e)
        {
            lblUser.Enabled = lblPassword.Enabled = txtUser.Enabled = txtPassword.Enabled = rbUser.Checked;
            if (!rbUser.Checked)
            {
                txtUser.Text = txtPassword.Text = "";
            }
        }

        private void groupBox2_Leave(object sender, EventArgs e)
        {
            cbDatabase.DataSource = null;
            if (rbIntergrated.Checked)
            {
                txtUser.Tag = txtPassword.Tag = "";
                if (techlinkErrorProvider1.Validate(this))
                {
                    SqlAccessor.Instance().SetConnection(txtServer.Text, "", "");
                    cbDatabase.DataSource = SqlAccessor.Instance().GetDatabases();
                    cbDatabase.DisplayMember = "Name";
                    cbDatabase.ValueMember = "Name";
                }
            }
            else
            {
                txtUser.Tag = txtPassword.Tag = "required";
                if (techlinkErrorProvider1.Validate(this))
                {
                    SqlAccessor.Instance().SetConnection(txtServer.Text, txtUser.Text, txtPassword.Text);
                    cbDatabase.DataSource = SqlAccessor.Instance().GetDatabases();
                    cbDatabase.DisplayMember = "Name";
                    cbDatabase.ValueMember = "Name";
                }
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var isSuccess = false;
            if (techlinkErrorProvider1.Validate(this))
            {
                if (cbDatabase.Text.Trim().Length == 0)
                {
                    cbDatabase.Focus();
                    return;
                }
                if (rbIntergrated.Checked)
                {
                    SqlAccessor.Instance().SetConnection(txtServer.Text, cbDatabase.Text, "", "");
                }
                else
                {
                    SqlAccessor.Instance().SetConnection(txtServer.Text, cbDatabase.Text, txtUser.Text, txtPassword.Text);         
                }
                var listDb = SqlAccessor.Instance().GetDatabases();
                if (listDb.Any(x=> x.Name == cbDatabase.Text))
                {
                    isSuccess = true;
                }
                if (isSuccess)
                {
                    //Save config
                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                    var cnn = string.Format("metadata=res://*/ModelEcusDeclaration.csdl|res://*/ModelEcusDeclaration.ssdl|res://*/ModelEcusDeclaration.msl;provider=System.Data.SqlClient;provider connection string='{0}'", SqlAccessor.Instance().ConnectionString);
                    if (connectionStringsSection.ConnectionStrings["dbEcusDeclaration"] == null)
                    {
                        connectionStringsSection.ConnectionStrings.Add(new ConnectionStringSettings("dbEcusDeclaration", Utilities.Common.Encrypt(cnn, true)));     
                    }
                    else
                    {
                        connectionStringsSection.ConnectionStrings["dbEcusDeclaration"].ConnectionString = Utilities.Common.Encrypt(cnn, true);    
                    }
                    
                    config.Save();
                    ConfigurationManager.RefreshSection("connectionStrings");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kết nối cơ sở dữ liệu không thành công");   
                }

            }
        }
    }
}
