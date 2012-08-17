using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECustoms.BOL
{
    public partial class FrmReceiveNumber : Form
    {
        private long _receiveNumber;
        public FrmReceiveNumber()
        {
            InitializeComponent();
        }

        public FrmReceiveNumber(long receiveNumber)
        {
            InitializeComponent();
            _receiveNumber = receiveNumber;
        }

        private void FrmReceiveNumber_Load(object sender, EventArgs e)
        {
            lblReceiveNumber.Text = _receiveNumber.ToString();
            btnOK.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
