using System;
using System.Windows.Forms;
using ECustoms.Utilities;

namespace ECustoms.Train
{
    public partial class frmTrainImport : Form
    {
        private short _type;
        public frmTrainImport()
        {
            InitializeComponent();
        }
        public frmTrainImport(short type)
        {
            InitializeComponent();
            _type = type;
        }

        private void frmTrainImport_Load(object sender, EventArgs e)
        {
            this.Text = "Tau hang Trung Quoc nhap canh" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
        }
    }
}
