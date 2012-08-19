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
using TechLink.DatabaseViewer.DataAccess;

namespace ECustoms
{
    public partial class frmBackupRestoreDb : SubFormBase
    {
        private string connectionString = string.Empty;


        public frmBackupRestoreDb()
        {
            InitializeComponent();

            connectionString =
                    Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true);
            connectionString = connectionString.Substring(connectionString.IndexOf('\'')).Trim('\'');
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Chưa có thông tin cơ sở dữ liệu sao lưu!", "Warning", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtSavePath.Text))
            {
                MessageBox.Show("Chưa có chọn thư mục lưu trữ cơ sở dữ liệu sao lưu!", "Warning", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            SqlCopier sqlCopier = new SqlCopier(connectionString);
            if(optBackupAll.Checked)
            {
                var ret = sqlCopier.RunStoreProc("BackupFullDatabase", new object[] { "@fileSaved", txtSavePath.Text });
                if(ret!=null)
                {
                    MessageBox.Show("Sao lưu dữ liệu thành công!", "Info", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                }
            }
            else
            {
                var ret = sqlCopier.RunStoreProc("BackupDiferentialDatabase", new object[] { "@fileSaved", txtSavePath.Text });
                if (ret != null)
                {
                    MessageBox.Show("Sao lưu dữ liệu thành công!", "Info", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "*.bak|*.bak";
            openFile.ShowDialog(this);
            if (!string.IsNullOrEmpty(openFile.FileName))
            {
                txtPath.Text = openFile.FileName;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phục hồi dữ liệu thành công!", "Info", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
        }

        private void btnBrowseSavePath_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".bak";
            saveFile.Filter = "*.bak|*.bak";
            saveFile.FileName = "database_backup_" + DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString() +
                                "_" + DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + "." +
                                DateTime.Now.Day.ToString() + ".bak";
            saveFile.ShowDialog(this);
            if (saveFile.FileName.IndexOf(':') == 1)
            {
                this.txtSavePath.Text = saveFile.FileName;
            }
        }
    }
}
