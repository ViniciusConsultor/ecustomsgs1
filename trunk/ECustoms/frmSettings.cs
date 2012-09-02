using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.Utilities;

namespace ECustoms
{
    public partial class frmSettings : SubFormBase
    {
        public frmSettings()
        {
            InitializeComponent();
            string[] strHours = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
            string[] strMinutes = new string[] { "00", "10", "20", "30", "40", "50" };

            cboHour.Items.AddRange(strHours);
            cboMinute.Items.AddRange(strMinutes);
            cboHour.SelectedIndex = 0;
            cboMinute.SelectedIndex = 0;

            LoadDatabaseInfo();
        }

        private void LoadDatabaseInfo()
        {
            var settings = SettingsFactory.GetTheLastSetting();
            txtVersion.Text = settings.Version;
            txtLastimeSync.Text = settings.LastSync.ToVnDate();
            txtSyncInterval.Text = settings.SyncInterval.HasValue ? settings.SyncInterval.ToString() : "0";
            cboHour.Text = settings.SyncTime.ToHour();
            cboMinute.Text = settings.SyncTime.ToMinute();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkUseSyncInterval_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = !chkUseSyncInterval.Checked;
            txtSyncInterval.Enabled = chkUseSyncInterval.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var settings = SettingsFactory.GetTheLastSetting();
            SettingsFactory.UpdateSettings(settings.Version,settings.LastSync,txtSyncInterval.Text.StringToInt(),
                cboHour.Text + ":" + cboMinute.Text,false);

            this.Close();
        }

    }
}
