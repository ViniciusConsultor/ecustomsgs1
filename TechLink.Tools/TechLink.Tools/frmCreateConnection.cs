using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TechLink.Views;

namespace TechLink.Tools
{
    public partial class frmCreateConnection : DevExpress.XtraEditors.XtraForm
    {
        public event DatabaseSeletedEventHandler DatabaseSourceSelected;
        public event DatabaseSeletedEventHandler DatabaseDestSelected;

        public frmCreateConnection()
        {
            InitializeComponent();
            this.databaseRegistration1.DatabaseDestSelected += new DatabaseSeletedEventHandler(frmCreateConnection_DatabaseDestSelected);
            this.databaseRegistration1.DatabaseSourceSelected += new DatabaseSeletedEventHandler(frmCreateConnection_DatabaseSourceSelected);

        }

        void frmCreateConnection_DatabaseSourceSelected(object sender, DatabaseViewer.DataTransferObjects.DatabaseInfo databaseInfo)
        {
            if (DatabaseSourceSelected != null)
            {
                DatabaseSourceSelected.Invoke(sender, databaseInfo);
            }
        }

        void frmCreateConnection_DatabaseDestSelected(object sender, DatabaseViewer.DataTransferObjects.DatabaseInfo databaseInfo)
        {
            if(DatabaseDestSelected!=null)
            {
                DatabaseDestSelected.Invoke(sender, databaseInfo);
            }
        }

        private void databaseRegistration1_Load(object sender, EventArgs e)
        {

        }
    }
}