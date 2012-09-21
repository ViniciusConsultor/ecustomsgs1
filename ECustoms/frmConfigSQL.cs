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
using ECustoms.Utilities;

namespace ECustoms
{
    public partial class frmConfigSQL : SubFormBase
    {
        public frmConfigSQL()
        {
            InitializeComponent();
            txtServer.Text = Dns.GetHostName();
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
                    var cnn = string.Format("metadata=res://*/ModelEcustoms.csdl|res://*/ModelEcustoms.ssdl|res://*/ModelEcustoms.msl;provider=System.Data.SqlClient;provider connection string='{0}'", SqlAccessor.Instance().ConnectionString);
                    if (connectionStringsSection.ConnectionStrings["dbEcustomEntities"] == null)
                    {
                        connectionStringsSection.ConnectionStrings.Add(new ConnectionStringSettings("dbEcustomEntities", Utilities.Common.Encrypt(cnn, true)));     
                    }
                    else
                    {
                        connectionStringsSection.ConnectionStrings["dbEcustomEntities"].ConnectionString = Utilities.Common.Encrypt(cnn, true);    
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

        private void frmConfigSQL_Load(object sender, EventArgs e)
        {
            this.Text = "Cau hinh ket noi CSDL" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
        }
    }
}
