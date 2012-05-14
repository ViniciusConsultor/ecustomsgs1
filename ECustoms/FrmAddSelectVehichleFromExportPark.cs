using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.Utilities;
using log4net;
using ECustoms.DAL;

namespace ECustoms
{
    public partial class FrmAddSelectVehichleFromExportPark : Form
    {
        private static log4net.ILog logger = LogManager.GetLogger("Ecustoms.FrmAddSelectVehichleFromExportPark");
        public event OnSelectedVehicleHandler OnSelectedVehichle;
        public delegate void OnSelectedVehicleHandler(object sender, EventArgs e);
        private List<tblVehicle> _vehicles;
        private long _declarationID;
        public FrmAddSelectVehichleFromExportPark(long declarationID)
        {
            InitializeComponent();
            _declarationID = declarationID;
        }

        public FrmAddSelectVehichleFromExportPark()
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
            try
            {
                if (grdVehicle.SelectedRows.Count == 1)
                {
                    var vehicleInfo = VehicleFactory.GetByIDFromView(((int.Parse(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value.ToString()))));
                    try
                    {
                        List<viewDeclarationVehicle> listExistedDeclarationVehicleImported = VehicleFactory.GetExistDeclarationExportOfVehicleInExportPark(vehicleInfo.VehicleID);
                        if (listExistedDeclarationVehicleImported != null && listExistedDeclarationVehicleImported.Count() > 0)
                        {
                            string listDeclarationNumber = "";
                            foreach (viewDeclarationVehicle obj in listExistedDeclarationVehicleImported)
                            {

                                listDeclarationNumber += (obj.Number + ",");
                            }

                            listDeclarationNumber.Remove(listDeclarationNumber.Length - 1);

                            DialogResult result = MessageBox.Show("Phương tiện này đã được khai báo chở hàng cho tờ khai số " + listDeclarationNumber + "\n" + "Bạn có muốn tiếp tục không ?", "Cảnh báo trùng lặp phương tiện trong các tờ khai khác nhau", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes) //chap nhan them 1 phuong tien trung lap tren 2 to khai nhap canh
                            {
                                OnSelectedVehichle(this, new SelectedVehichleEventArgs() { Vehicle = vehicleInfo });
                            }
                            else if (result == DialogResult.No) //Khong chap nhan them 1 phuong tien trung lap tren 2 to khai nhap canh
                            {
                                return;
                            }
                        }
                        else
                        {
                            OnSelectedVehichle(this, new SelectedVehichleEventArgs() { Vehicle = vehicleInfo });
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Phương tiện này đã tồn tại trong tờ khai!");
                        return;
                    }


                }
                else
                {
                    MessageBox.Show("Bạn cần chọn 1 phương tiện");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void grdVehicle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddVehicle();
        }

        private void FrmAddSelectVehichleFromExportPark_Load(object sender, EventArgs e)
        {
            this.Text = "Them tu phuong tien trong bai xuat" + ConstantInfo.MESSAGE_TITLE;
            this.Location = new Point((this.Owner.Width - this.Width) / 2 + 400, (this.Owner.Height - this.Height) / 2);
            // Set focus
            txtPlate.Focus();
            BindData();
        }

        private void BindData()
        {
            _vehicles = VehicleFactory.GetVehicleInExportPark();
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

                    // TODO: Need to change this solution. need to create one more metheod for searching
                    _vehicles = VehicleFactory.GetVehicleInExportPark();
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

        private void grdVehicle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13)) // Enter key
            {
                try
                {
                    if (string.IsNullOrEmpty(txtPlate.Text))
                    {
                        BindData();
                    }
                    else
                    {

                        // TODO: Need to change this solution. need to create one more metheod for searching
                        _vehicles = VehicleFactory.GetExported();
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
        }

        //public class SelectedVehichleInExportParkEventArgs : EventArgs
        //{
        //    public ViewAllVehicleHasGood Vehicle
        //    {
        //        get;
        //        set;
        //    }
        //}
    }
}
