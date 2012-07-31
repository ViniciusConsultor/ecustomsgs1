using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using techlink.Digest;

namespace TechLink.Views
{
    public partial class LicenceCreator : UserControl
    {
        public LicenceCreator()
        {
            InitializeComponent();
             
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Create();
        }

        private bool Create()
        {
            if (dxErrorProvider1.ValidateControls())
            {
                var cpRight = AssemblyHelper.GetCopyright();
                //Copyright + Unit Name + Domain Name + Address + Number of PCs + Number of End Users
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(cpRight);
                sb.AppendLine(txtUnit.Text);
                sb.AppendLine(txtDomain.Text);
                sb.AppendLine(txtAddress.Text);
                sb.AppendLine(txtNumberOfPc.Text);
                sb.AppendLine(txtNumberOfPeople.Text);

                string s = sb.ToString();

                string featureHuman = XRayController.CreateFeatureOfHuman(s);

                string k = XRayController.CreateFeatureOfHuman(featureHuman);
                Guid guid = new Guid(k);
                txtSerial.Text = guid.ToString().ToUpper();
                return true;
            }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Create())
            {
                //Save data
            }
        }
    }
}
