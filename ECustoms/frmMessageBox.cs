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
    public partial class frmMessageBox : SubFormBase
    {
        public frmMessageBox()
        {
            InitializeComponent();
        }
        public frmMessageBox(string content)
        {
            InitializeComponent();
            lblContent.Text = content;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
