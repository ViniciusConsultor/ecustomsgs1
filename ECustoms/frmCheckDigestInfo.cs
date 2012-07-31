using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ECustoms.Utilities;
using techlink.Digest;

namespace ECustoms
{
    public partial class frmCheckDigestInfo : SubFormBase
    {
        private string str = "abcdefghikmnlopqrstuv";
        private bool force_close = false;

        public frmCheckDigestInfo()
        {
            InitializeComponent();
#if FORCE_REG
    //        btnLater.Visible = false;
#endif
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
        }

        private bool ValidateInfoRequired()
        {
            bool hasError = false;
            techlinkErrorProvider1.ValidateRequiredFields(this, ref hasError);
            return !hasError;
        }

        private void frmCheckDigestInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!force_close) e.Cancel = true;
            e.Cancel = false;
        }

        private void btnLater_Click(object sender, EventArgs e)
        {
            force_close = true;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            force_close = true;
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateInfoRequired())
            {
                var cpRight = AssemblyHelper.GetCopyright();
                //Copyright + Unit Name + Domain Name + Address + Number of PCs + Number of End Users
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(cpRight);
                sb.AppendLine(txtUnitName.Text);
                sb.AppendLine(txtDomain.Text);
                sb.AppendLine(txtAddress.Text);
                sb.AppendLine(txtNumberOfPc.Text);
                sb.AppendLine(txtNumberOfUser.Text);
                //sb.AppendLine(txtSerial.Text);

                string s = sb.ToString();
                string appData = FDHelper.TechlinkAppData();
                string currentdir = FDHelper.RunningDir();

                Random rnd = new Random(str.Length);
                string ss = string.Empty;
                for (int i = 0; i < 10; i++)
                {
                    ss += str[rnd.Next(0, str.Length - 1)];
                }
                ss += ".dat";

                if (FDHelper.CreateFolderIfDoesnotExisted(appData))
                {
                    FDHelper.DeleteAllFilesInFolder(appData);

                    FDHelper.SaveTechLinkAppDataPath(appData);
                    FDHelper.SaveTechLinkUserProfile(ss);

                    string featureHuman = XRayController.CreateFeatureOfHuman(s);

                    string k = XRayController.CreateFeatureOfHuman(featureHuman);
                    Guid guid = new Guid(k);

                    if (guid.ToString().ToUpper() == txtSerial.Text)
                    {
                        sb.AppendLine(featureHuman);
                        sb.AppendLine(txtSerial.Text);

                        long time = DateTime.Now.Ticks;
                        FDHelper.SaveTechLinkTimeStamp(time);
                        var bone = XRayController.TranslateBoneInformation(sb.ToString());

                        k += "\r\n" + time.ToString();

                        var coccyx = XRayController.TranslateBoneInformation(k);

                        appData = System.IO.Path.Combine(appData, ss);
                        currentdir = System.IO.Path.Combine(currentdir, ss);

                        BoneReader.CreateHuman(appData, bone);
                        BoneReader.CreateHuman(currentdir, coccyx);

                        Coccyx.IsAtTheEndOfCoccyx = true;
                        force_close = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mã đăng ký sử dụng chương trình không hợp lệ!");
                        return;
                    }
                }
            }
            else
            {

            }
        }
    }
}
