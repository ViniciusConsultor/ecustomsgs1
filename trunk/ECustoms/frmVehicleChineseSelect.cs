using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.Utilities;
using log4net;
using ECustoms.DAL;

namespace ECustoms
{
    public partial class frmVehicleChineseSelect : Form
    {
        private static log4net.ILog logger = LogManager.GetLogger("Ecustoms.frmVehicleChineseSelect");
        public event OnSelectedVehicleHandler OnSelectedVehichle;
        public delegate void OnSelectedVehicleHandler(object sender, EventArgs e);
        private List<tblVehicle> _vehicles;
        private long _declarationID;
        public frmVehicleChineseSelect(long declarationID)
        {
            InitializeComponent();
            _declarationID = declarationID;
        }
        public frmVehicleChineseSelect()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddVehichle_Click(object sender, EventArgs e)
        {
            AddVehicle();
        }

        private void AddVehicle()
        {
        
        }

        private void grdVehicle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddVehicle();
        }

        private void frmVehicleChineseSelect_Load(object sender, EventArgs e)
        {
            this.Text = "Tim kiem phuong tien xe Trung Quoc" + ConstantInfo.MESSAGE_TITLE;
            // Set focus
            txtPlate.Focus();
            BindData();
        }

        private void BindData()
        {
            _vehicles = VehicleFactory.GetChineseVehicle();
            grdVehicle.AutoGenerateColumns = false;
            grdVehicle.DataSource = _vehicles;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPlate.Text))
                {
                    BindData();
                }
                else
                {
                    _vehicles = VehicleFactory.GetChineseVehicle();
                    _vehicles = _vehicles.Where(g => g.PlateNumber != null && g.PlateNumber.ToUpper().Contains(txtPlate.Text.ToUpper())).ToList();
                    grdVehicle.DataSource = _vehicles;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void txtPlate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13)) // Enter key
            {
                btnSearch_Click(null, null);
            }
        }
        
    }
}
