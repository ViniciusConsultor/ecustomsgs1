using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.Utilities;
using techlink.Digest;

namespace ECustoms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (FDHelper.RgGetTechlinkAppDataPath() == string.Empty || FDHelper.RgGetUserProfilePath() == string.Empty)
            {
                Application.Run(new frmCheckDigestInfo());
            }
            else
            {
                var bone = BoneReader.GetBoneInfo(FDHelper.RgGetUserProfilePath());
                var coccyx =
                    BoneReader.GetBoneInfo(System.IO.Path.Combine(FDHelper.RunningDir(),
                                                                  System.IO.Path.GetFileName(
                                                                      FDHelper.RgGetUserProfilePath())));
                
                if(bone.Length==0)
                {
                    Application.Run(new frmCheckDigestInfo());
                }
                else
                {
                    var s = XRayController.TranslateBoneInformation(bone);
                    var coc = XRayController.TranslateBoneInformation(coccyx);

                    string[] ss = s.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
                    string[] sss = coc.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);

                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < 6; i++)
                    {
                        sb.AppendLine(ss[i]);
                    }

                    var xray = XRayController.CreateFeatureOfHuman(sb.ToString());
                    var xray1 = XRayController.CreateFeatureOfHuman(xray);

                    var ts = FDHelper.RgGetTimeStamp().ToString();

                    if(ts == sss[1] && sss[0]== xray1)
                    {
                        Coccyx.IsAtTheEndOfCoccyx = true;
                    }
                }
            }

            if (Coccyx.IsAtTheEndOfCoccyx)
            {
                Application.Run(new frmLogin());    
            }
            else
            {
                MessageBox.Show("Bạn chưa đăng ký sử dụng phần mềm!");
                Application.Exit();
            }
        }
    }
}
