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
    public partial class frmBranchesManager : SubFormBase
    {
        public frmBranchesManager()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStartSync_Click(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows.Count==0)
            {
                MessageBox.Show("Chọn một đơn vị để yêu cầu đồng bộ dữ liệu", "Ưarning", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }


        }
    }
}
