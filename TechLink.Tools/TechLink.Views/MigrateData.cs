using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TechLink.DatabaseViewer;
using TechLink.DatabaseViewer.DataAccess;
using TechLink.DatabaseViewer.DataTransferObjects;

namespace TechLink.Views
{
    public delegate void GetConnectionEventHandler(object sender, out string connection);

    public partial class MigrateData : UserControl
    {
        public event GetConnectionEventHandler GetSourceConnectionClick;
        public event GetConnectionEventHandler GetDestinationConnectionClick;

        private string sourceCnn = string.Empty;
        private string destCnn = string.Empty;
        private SqlCopier sqlSourceCopier;
        private SqlCopier sqlDestCopier;
        private CommandList commands = new CommandList();

        public MigrateData()
        {
            InitializeComponent();
            cboCommands.Properties.Items.AddRange(commands.CommandNames);
        }

        private void btnSourceCnn_Click(object sender, EventArgs e)
        {
            if (GetSourceConnectionClick != null)
            {
                GetSourceConnectionClick.Invoke(this, out sourceCnn);
                if (sourceCnn != string.Empty)
                {
                    sqlSourceCopier = new SqlCopier(sourceCnn);
                    this.gridSource.DataSource = sqlSourceCopier.GetAllTables();
                }
            }
        }

        private void btnDestCnn_Click(object sender, EventArgs e)
        {
            if (GetDestinationConnectionClick != null)
            {
                GetDestinationConnectionClick.Invoke(this, out destCnn);

                if (destCnn != string.Empty)
                {
                    sqlDestCopier = new SqlCopier(destCnn);
                    this.gridDestination.DataSource = sqlDestCopier.GetAllTables();
                }
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if(this.gridView1.SelectedRowsCount==0 || this.gridView2.SelectedRowsCount==0)
            {
                MessageBox.Show("Bảng dữ liệu nguồn, bảng dữ liệu đích chưa được chọn đầy đủ!", "warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TableInfo selectedSourceTable = gridView1.GetRow(gridView1.GetSelectedRows()[0]) as TableInfo;
            TableInfo selectedDestTable = gridView2.GetRow(gridView2.GetSelectedRows()[0]) as TableInfo;

            commands.Initial(sqlSourceCopier, sqlDestCopier, null);
            if(commands.ExecuteCommand(cboCommands.Text))
            {
                MessageBox.Show("Sao chép dữ liệu thành công!", "Info", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể sao chép dữ liệu từ bảng nguồn!", "Warning", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
    }
}
