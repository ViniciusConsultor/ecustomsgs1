using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.Utilities;
using TechLink.DatabaseViewer;
using TechLink.DatabaseViewer.DataAccess;
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
            string strd = System.IO.Path.Combine(FDHelper.RunningDir(),
                                                 System.IO.Path.GetFileName(
                                                     FDHelper.RgGetUserProfilePath()));

            if (FDHelper.RgGetTechlinkAppDataPath() == string.Empty || FDHelper.RgGetUserProfilePath() == string.Empty || !System.IO.File.Exists(strd))
            {
                Application.Run(new frmCheckDigestInfo());
            }
            else
            {
                var bone = BoneReader.GetBoneInfo(FDHelper.RgGetUserProfilePath());
                var coccyx =
                    BoneReader.GetBoneInfo(strd);
                
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

                    // Set company name
                    if (ss[1] != null)
                    {
                        GlobalInfo.CompanyName = ss[1].ToString();
                    }                    

                    var xray = XRayController.CreateFeatureOfHuman(sb.ToString());
                    var xray1 = XRayController.CreateFeatureOfHuman(xray);

                    var ts = FDHelper.RgGetTimeStamp().ToString();

                    if(sss.Length > 1 && ts == sss[1] && sss[0]== xray1)
                    {
                        Coccyx.IsAtTheEndOfCoccyx = true;
                    }
                }
            }

            if (Coccyx.IsAtTheEndOfCoccyx)
            {
                string connectionString =
                    Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true);
                connectionString = connectionString.Substring(connectionString.IndexOf('\'')).Trim('\'');
                SqlCopier sqlCopier = new SqlCopier(connectionString);

                var tables = sqlCopier.GetAllTables();
                var tblSettings = tables.FirstOrDefault(item => item.Name.ToLower() == "tblsettings");
                if (tblSettings == null)
                {
                    ConfirmUpgradeDB();
                    Application.Run(new frmUpgradeDatabase("1.0.0", connectionString)); 
                }
                else
                {
                    var data = sqlCopier.GetDataFromTable(tblSettings.Name);
                    var version = (data.Rows.Count == 0 ? "1.0.0" : data.Rows[0]["Version"].ToString());

                    if(version!=UpgradeDatabase.CommandNames[UpgradeDatabase.CommandNames.Length-1])
                    {
                        ConfirmUpgradeDB();
                        Application.Run(new frmUpgradeDatabase(version, connectionString)); 
    
                    }
                }

                Application.Run(new frmLogin());    
            }
            else
            {
                MessageBox.Show("Bạn chưa đăng ký sử dụng phần mềm!");
                Application.Exit();
            }
        }

        private static void ConfirmUpgradeDB()
        {
            if(MessageBox.Show("Cơ sở dữ liệu cần phải được nâng cấp để tương thích với phiên bản mới.\r\n Bạn có chắc chắn muốn tiếp tục?","Warning",
                MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.No)
            {
                Environment.Exit(0);
            }

        }
    }
}
