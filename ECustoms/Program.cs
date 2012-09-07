using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ECustoms.Utilities;
using TechLink.DatabaseViewer;
using TechLink.DatabaseViewer.DataAccess;
using techlink.Digest;

namespace ECustoms
{
    //Windows API need to use in Mutex program
    internal class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }

    static class Program
    {
        static Mutex mutex = new Mutex(true, "{23A90C21-7121-4C55-AEA4-1CFF7A118D16}");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                string strd = System.IO.Path.Combine(FDHelper.RunningDir(),
                                                     System.IO.Path.GetFileName(
                                                         FDHelper.RgGetUserProfilePath()));


                var isRunCheckDigestInfo = false;
                if (FDHelper.RgGetTechlinkAppDataPath() == string.Empty || FDHelper.RgGetUserProfilePath() == string.Empty || !System.IO.File.Exists(strd))
                {
                    isRunCheckDigestInfo = true;
                    Application.Run(new frmCheckDigestInfo());
                }
                else
                {
                    var bone = BoneReader.GetBoneInfo(FDHelper.RgGetUserProfilePath());
                    var coccyx =
                        BoneReader.GetBoneInfo(strd);

                    if (bone.Length == 0)
                    {
                        isRunCheckDigestInfo = true;
                        Application.Run(new frmCheckDigestInfo());
                    }
                    else
                    {
                        var s = XRayController.TranslateBoneInformation(bone);
                        var coc = XRayController.TranslateBoneInformation(coccyx);

                        string[] ss = s.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        string[] sss = coc.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

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

                        if (sss.Length > 1 && ts == sss[1] && sss[0] == xray1)
                        {
                            Coccyx.IsAtTheEndOfCoccyx = true;
                        }
                    }
                }

                if (Coccyx.IsAtTheEndOfCoccyx)
                {
                    RegisterSuccess();
                }
                else
                {
                    //MessageBox.Show("Bạn chưa đăng ký sử dụng phần mềm!");
                    //Application.Exit();
                    if (!isRunCheckDigestInfo) Application.Run(new frmCheckDigestInfo());
                    RegisterSuccess();
                }
                mutex.ReleaseMutex();
            }
            else
            {

                //If the application is started, show the message to warning and...
                MessageBox.Show("GS1 đã được khởi động. Bạn hãy kiểm tra lại cửa sổ đang mở!", "ECustom",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //Then post a message to show the opened windows
                NativeMethods.PostMessage(
                    (IntPtr)NativeMethods.HWND_BROADCAST,
                    NativeMethods.WM_SHOWME,
                    IntPtr.Zero,
                    IntPtr.Zero);
            }



        }

        private static void ConfirmUpgradeDB()
        {
            if (MessageBox.Show("Cơ sở dữ liệu cần phải được nâng cấp để tương thích với phiên bản mới.\r\n Bạn có chắc chắn muốn tiếp tục?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                Environment.Exit(0);
            }

        }

        private static void RegisterSuccess()
        {
            if (ConfigurationManager.ConnectionStrings["dbEcustomEntities"] == null)
            {
                Application.Run(new frmConfigSQL());
            }
            if (ConfigurationManager.ConnectionStrings["dbEcustomEntities"] == null)
            {
                Application.Exit();
                return;
            }
            string connectionString =
                Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true);
            connectionString = connectionString.Substring(connectionString.IndexOf('\'') == -1 ? 0 : connectionString.IndexOf('\'')).Trim('\'');
            SqlCopier sqlCopier = new SqlCopier(connectionString);

            var tables = sqlCopier.GetAllTables();
            var tblSettings = tables.FirstOrDefault(item => item.Name.ToLower() == "tblsettings");
            if (tblSettings == null)
            {
                ConfirmUpgradeDB();
                //frmUpgradeDatabase upgradeDatabase = new frmUpgradeDatabase(ConstantInfo.CurrentVersion, connectionString);
                Application.Run(new frmUpgradeDatabase(ConstantInfo.CurrentVersion, connectionString));
            }
            else
            {
                var data = sqlCopier.GetDataFromTable(tblSettings.Name);
                var version = (data.Rows.Count == 0 ? ConstantInfo.CurrentVersion : data.Rows[0]["Version"].ToString());

                if (version != UpgradeDatabase.CommandNames[UpgradeDatabase.CommandNames.Length - 1])
                {
                    ConfirmUpgradeDB();
                    Application.Run(new frmUpgradeDatabase(version, connectionString));

                }
            }

            Application.Run(new frmLogin());
        }
    }
}
