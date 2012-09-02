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
        private string _version = string.Empty;
        private string _connection = string.Empty;

        public frmUpgradeDatabase(string version, string connection)
        {
            InitializeComponent();
            _version = version;
            _connection = connection;
        }

        

        public void DoUpgrate()
        {
            SqlCopier sqlCopier = new SqlCopier(_connection);
            UpgradeDatabase upgradeDatabase = new UpgradeDatabase();
            string unitCode = FDHelper.RgCodeOfUnit();

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
                if (!upgradeDatabase.UpgradeCommands[UpgradeDatabase.CommandNames[i]].DoUpgrade(new List<object> { this.progressBar1, unitCode }))
                {
                    MessageBox.Show(
                        "Nâng cấp cơ sở dữ liệu không thành công. Ứng dụng không thể tiếp tục chạy.\r\nVui lòng liên hệ với TechLink để được trợ giúp!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }

            }

            MessageBox.Show(
                "Nâng cấp cơ sở dữ liệu thành công. Nhấn OK để tiếp tục!",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void frmUpgradeDatabase_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            DoUpgrate();
        }
    }
}
