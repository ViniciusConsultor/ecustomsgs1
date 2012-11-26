using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.Utilities;

namespace ECustoms.Train
{
    public partial class frmPartTrainExport : Form
    {
        public frmPartTrainExport()
        {
            InitializeComponent();
        }

        private void frmPartTrainExport_Load(object sender, EventArgs e)
        {
            this.Text = "Khai bao toa tau xuat" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
        }
    }
}
