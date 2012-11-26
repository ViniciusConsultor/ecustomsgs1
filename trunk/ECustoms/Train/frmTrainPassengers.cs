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
    public partial class frmTrainPassengers : Form
    {
        public frmTrainPassengers()
        {
            InitializeComponent();
        }

        private void frmTrainPassengers_Load(object sender, EventArgs e)
        {
            this.Text = "Khai bao tau khach XNK" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
        }
    }
}
