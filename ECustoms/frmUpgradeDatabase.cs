using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.Utilities;
using TechLink.DatabaseViewer;
using TechLink.DatabaseViewer.DataAccess;

namespace ECustoms
{

    public partial class frmUpgradeDatabase : SubFormBase
    {
        private string connectionString =
            Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true);

        private string _version = string.Empty;

        public frmUpgradeDatabase(string version)
        {
            InitializeComponent();
            _version = version;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SqlCopier sqlCopier = new SqlCopier(connectionString);
            UpgradeDatabase upgradeDatabase = new UpgradeDatabase();

            var currentVersions = _version.Split('.');
            int fromVersion = 0;

            for (int i = 0; i < UpgradeDatabase.CommandNames.Length; i++)
            {
                var newVersions = UpgradeDatabase.CommandNames[i].Split('.');
                if (int.Parse(currentVersions[0]) < int.Parse(newVersions[0]) ||
                    int.Parse(currentVersions[1]) < int.Parse(newVersions[1]) ||
                    int.Parse(currentVersions[2]) < int.Parse(newVersions[2]))
                {
                    fromVersion = i;
                    break;
                }
            }

            upgradeDatabase.InitialCommands(sqlCopier);

            for (int i = fromVersion; i < UpgradeDatabase.CommandNames.Length; i++)
            {
                if (!upgradeDatabase.UpgradeCommands[UpgradeDatabase.CommandNames[i]].DoUpgrade(this.progressBar1))
                {
                    MessageBox.Show(
                        "Nâng cấp cơ sở dữ liệu không thành công. Ứng dụng không thể tiếp tục chạy.\r\nVui lòng liên hệ với TechLink để được trợ giúp!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

            }

            MessageBox.Show(
                "Nâng cấp cơ sở dữ liệu thành công. Nhấn OK để tiếp tục!",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }
    }
}
