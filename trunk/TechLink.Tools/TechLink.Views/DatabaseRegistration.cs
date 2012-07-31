using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using TechLink.DatabaseViewer.DataAccess;
using TechLink.DatabaseViewer.DataTransferObjects;

namespace TechLink.Views
{
    public delegate void DatabaseSeletedEventHandler(object sender, DatabaseInfo databaseInfo);

    public partial class DatabaseRegistration : UserControl
    {

        public event DatabaseSeletedEventHandler DatabaseSourceSelected;
        public event DatabaseSeletedEventHandler DatabaseDestSelected;

        private bool isDatabaseConnected = false;

        public DatabaseRegistration()
        {
            InitializeComponent();
            this.txtServer.Text = Dns.GetHostName();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnTryConnect_Click(object sender, EventArgs e)
        {
            if (opt1.Checked)
            {
                if (txtServer.Text.Trim().Length == 0)
                {
                    teckLinkErrorProvider1.SetError(txtServer, "Trường cần nhập thông tin");
                    return;
                }

                SqlAccessor.Instance().SetConnection(txtServer.Text, "", "");
                ShowDatabases();
            }
            else if (teckLinkErrorProvider1.ValidateControls())
            {
                SqlAccessor.Instance().SetConnection(txtServer.Text, txtUser.Text, txtPass.Text);
                ShowDatabases();
            }
        }

        private void ShowDatabases()
        {
            var databases = SqlAccessor.Instance().GetDatabases();
            this.gridControl1.DataSource = databases;
            isDatabaseConnected = true;
        }

        private void btnAddToSource_Click(object sender, EventArgs e)
        {
            if (!isDatabaseConnected)
            {
                MessageBox.Show("Setup server info and press connect first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show("There is no database selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DatabaseInfo selectedDb = gridView1.GetRow(gridView1.GetSelectedRows()[0]) as DatabaseInfo;

                if(DatabaseSourceSelected!=null)
                {
                    DatabaseSourceSelected.Invoke(this, selectedDb);
                }
            }
        }

        private void btnAddToDest_Click(object sender, EventArgs e)
        {
            if (!isDatabaseConnected)
            {
                MessageBox.Show("Setup server info and press connect first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show("There is no database selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DatabaseInfo selectedDb = gridView1.GetRow(gridView1.GetSelectedRows()[0]) as DatabaseInfo;
                if (DatabaseDestSelected != null)
                {
                    DatabaseDestSelected.Invoke(this, selectedDb);
                }
            }
        }
    }
}
