using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        }

        private void LoadDatabaseInfo()
        {
            
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

    }
}
