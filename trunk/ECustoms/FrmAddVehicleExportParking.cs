using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.DAL;
using log4net;
using ECustoms.Utilities;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ECustoms
{
    public partial class FrmAddVehicleExportParking : Form
    {
        private static log4net.ILog logger = LogManager.GetLogger("Ecustoms.FrmAddVehicleExportParking");
        private List<ViewAllVehicleHasGood> _vehicleInfosTemp = new List<ViewAllVehicleHasGood>();
        private UserInfo _userInfo;
        private PrintTicketSetting _printSetting;

        public List<ViewAllVehicleHasGood> VehicleInfosTemp
        {
            get { return _vehicleInfosTemp; }
            set { _vehicleInfosTemp = value; }
        }



        public UserInfo UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        public FrmAddVehicleExportParking()
        {
            InitializeComponent();
        }

        public FrmAddVehicleExportParking(UserInfo userInfor)
        {

            InitializeComponent();
            LoadPrintSetting();
            grdVehicle.AutoGenerateColumns = false;
            _userInfo = userInfor;
        }

        public void LoadPrintSetting()
        {
            var filePath = System.Windows.Forms.Application.StartupPath + @"\conf\print_ticket.xml";
            _printSetting = ObjectToXml.GetTicketSetting(filePath);
        }

        private bool Validate()
        {
            // comments code because new requirements
            // allow empty when inserting new verhicle,
            // the driver name might be filled later

            if (string.IsNullOrEmpty(txtPlateNumber.Text.Trim()))
            {
                MessageBox.Show("Biểm kiểm soát không được để trống!");
                txtPlateNumber.Focus();
                return false;
            }


            for (int i = 0; i < grdVehicle.Rows.Count; i++)
            {
                if (grdVehicle.Rows[i].Cells["PlateNumber"].Value.Equals(txtPlateNumber.Text))
                {
                    MessageBox.Show("Biểm kiểm soát đã được nhập");
                    txtPlateNumber.Focus();
                    pictureBoxValid.Visible = false;
                    pictureBoxInvalid.Visible = true;
                    return false;
                }
            }


            return true;
        }

        private void ResetForm(bool isAll)
        {
            txtDriverName.Text = "";
            txtPlateNumber.Text = "";
            txtNumberOfContainer.Text = "";
            txtStatus.Text = "";
            txtNote.Text = "";
 
            pictureBoxInvalid.Visible = false;
            pictureBoxValid.Visible = false;

            // Set focus
            txtPlateNumber.Focus();
        }

        private ViewAllVehicleHasGood GetVehicle()
        {
            var vehicleInfo = new ViewAllVehicleHasGood();
            try
            {
                if (!Validate())
                    return null;
                // Add data to veicleInfo list

                vehicleInfo.DriverName = txtDriverName.Text.Trim();
                vehicleInfo.PlateNumber = txtPlateNumber.Text = StringUtil.RemoveAllNonAlphanumericString(txtPlateNumber.Text).ToUpper();

                vehicleInfo.vehicleTypeId = Int32.Parse(cbVehicleType.SelectedValue.ToString());
                vehicleInfo.GoodTypeId = Int32.Parse(cbGoodType.SelectedValue.ToString());

                if (txtNumberOfContainer.Text != "")
                {
                    vehicleInfo.NumberOfContainer = txtNumberOfContainer.Text.Trim();
                }

                vehicleInfo.Status = txtStatus.Text;
                vehicleInfo.Note = txtNote.Text;
                vehicleInfo.VehicleID = _vehicleInfosTemp.Count + 1;
                vehicleInfo.IsExport = false;
                vehicleInfo.IsImport = false;
                vehicleInfo.IsCompleted = false;
                vehicleInfo.IsExportParking = true;
                vehicleInfo.ExportParkingDate = CommonFactory.GetCurrentDate();
                vehicleInfo.ConfirmExportParkingBy = UserInfo.UserID;


            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
            return vehicleInfo;
        }

        private void FrmAddVehicleExportParking_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Khai bao phuong tien nhap bai xuat" + ConstantInfo.MESSAGE_TITLE;

                //init vehicleType
                var listVehicleType = VehicleTypeFactory.getAllVehicleType();
                dataSet2.tblVehicleType.Rows.Add(0, "Không phân loại");
                foreach (tblVehicleType vehicleType in listVehicleType)
                {
                    dataSet2.tblVehicleType.Rows.Add(vehicleType.VehicleTypeID, vehicleType.Name);
                }
                cbVehicleType.DataSource = dataSet2.tblVehicleType;

                //init goodType
                var listGoodType = GoodTypeFactory.SelectAll();
                dataSet2.tblGoodsType.Rows.Add(0, "Không phân loại");
                foreach (tblGoodsType goodType in listGoodType)
                {
                    dataSet2.tblGoodsType.Rows.Add(goodType.TypeId, goodType.TypeName);
                }
                cbGoodType.DataSource = dataSet2.tblGoodsType;
                
                pictureBoxInvalid.Visible = false;
                pictureBoxValid.Visible = false;
                //InitialPermission();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var vehicleInfo = GetVehicle();
                if (vehicleInfo != null)
                {
                    // Bind to gridview.
                    VehicleInfosTemp.Add(vehicleInfo);
                    BindVehicle(VehicleInfosTemp);
                    //print ticket
                    if (_printSetting != null && _printSetting.PrintInputExportPark == true)
                    {
                        PrintTicket(vehicleInfo);
                    }

                    ResetForm(false);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        public void BindVehicle(List<ViewAllVehicleHasGood> vehicleInfos)
        {
            try
            {
                grdVehicle.DataSource = null;

                // Bind count column

                grdVehicle.DataSource = vehicleInfos;
                // Add to count Column
                for (int i = 0; i < grdVehicle.Rows.Count; i++)
                {
                    grdVehicle.Rows[i].Cells[0].Value = i + 1;
                }

                //Set curent cell for poiter to bottom
                if (grdVehicle.Rows.Count > 0)
                {
                    this.grdVehicle.CurrentCell = this.grdVehicle[0, this.grdVehicle.Rows.Count - 1];
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVehicle.SelectedRows.Count == 1) // New mode
                {
                    var dr = MessageBox.Show("Bạn có chắc là muốn xóa?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        var count = 0;
                        foreach (var vehicleInfo in _vehicleInfosTemp)
                        {
                            count += 1;
                            if (count == Convert.ToInt32(grdVehicle.SelectedRows[0].Cells["Count"].Value))
                            {
                                _vehicleInfosTemp.Remove(vehicleInfo);
                                break;
                            }

                        }
                        this.BindVehicle(_vehicleInfosTemp);
                    }
                }

                else
                {
                    MessageBox.Show("Bạn cần chọn 1 phương tiện cần xóa.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (VehicleInfosTemp.Count == 0)
                    throw new Exception("Phương tiện không được để trống");

                foreach (var info in VehicleInfosTemp)
                {
                    var vehicleInfo = new tblVehicle();
                    vehicleInfo.DriverName = info.DriverName;
                    vehicleInfo.PlateNumber = info.PlateNumber;
                    vehicleInfo.NumberOfContainer = info.NumberOfContainer;
                    vehicleInfo.ExportDate = info.ExportDate;
                    vehicleInfo.ConfirmExportBy = info.ConfirmExportBy;
                    vehicleInfo.ImportDate = info.ImportDate;
                    vehicleInfo.ConfirmImportBy = info.ConfirmImportBy;
                    vehicleInfo.Status = info.Status;
                    vehicleInfo.Note = info.Note;
                    vehicleInfo.VehicleID = info.VehicleID;
                    vehicleInfo.IsExport = info.IsExport;
                    vehicleInfo.IsImport = info.IsImport;
                    vehicleInfo.IsCompleted = info.IsCompleted;

                    vehicleInfo.vehicleTypeId = info.vehicleTypeId;
                    vehicleInfo.GoodTypeId = info.GoodTypeId;

                    vehicleInfo.IsExportParking = info.IsExportParking;
                    vehicleInfo.ExportParkingDate = info.ExportParkingDate;
                    vehicleInfo.ConfirmExportParkingBy = info.ConfirmExportParkingBy;

                    VehicleFactory.InsertVehicle(vehicleInfo);
                }

                MessageBox.Show(ConstantInfo.MESSAGE_INSERT_SUCESSFULLY);
                // Reset form
                ResetForm(true);
                this.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void txtPlateNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Enter key
            {
                try
                {
                    AutoFillVehicleType();

                    var vehicleInfo = GetVehicle();
                    if (vehicleInfo != null)
                    {
                        // Bind to gridview.
                        VehicleInfosTemp.Add(vehicleInfo);
                        BindVehicle(VehicleInfosTemp);

                        ResetForm(false);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex.ToString());
                    if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
                }
            }
        }

        private void txtPlateNumber_Leave(object sender, EventArgs e)
        {
            txtPlateNumber.Text = StringUtil.RemoveAllNonAlphanumericString(txtPlateNumber.Text).ToUpper();
            AutoFillVehicleType();
        }

        private void grdVehicle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 1) && (grdVehicle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null))
            {
                string newValue = StringUtil.RemoveAllNonAlphanumericString(grdVehicle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).ToUpper();
                grdVehicle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = newValue;
                //auto fill data
                tblVehicle vehicle = VehicleFactory.GetByPlateNumber(newValue);
                if (vehicle != null)
                {
                    grdVehicle.Rows[e.RowIndex].Cells["DriverName"].Value = vehicle.DriverName;
                    if (vehicle.vehicleTypeId != null)
                    {
                        grdVehicle.Rows[e.RowIndex].Cells["VehicleType"].Value = vehicle.vehicleTypeId;
                    }
                }
            }
        }

        private void PrintTicket(ViewAllVehicleHasGood vehicleInfo)
        {
            var vehicleTicket = new ECustoms.VehicleExportParkTicket();

            var txtPrintUser = (TextObject)vehicleTicket.Section3.ReportObjects["txtPrintUser"];
            var txtPrintType = (TextObject)vehicleTicket.Section3.ReportObjects["txtPrintType"];

            var txtTotalPrintVehicleTicketOfDay = (TextObject)vehicleTicket.Section3.ReportObjects["txtTotalPrintVehicleTicketOfDay"];
            var txtPrintDate = (TextObject)vehicleTicket.Section3.ReportObjects["txtPrintDate"];
            var txtParkingDate = (TextObject)vehicleTicket.Section3.ReportObjects["txtParkingDate"];
            var txtVehicleNumber = (TextObject)vehicleTicket.Section3.ReportObjects["txtVehicleNumber"];
            var txtBarcode = (TextObject)vehicleTicket.Section3.ReportObjects["txtBarcode"];
            
            txtVehicleNumber.Text = vehicleInfo.PlateNumber;

            if (vehicleInfo.ExportParkingDate != null)
            {
                txtParkingDate.Text = ((DateTime)vehicleInfo.ExportParkingDate).ToString("dd/MM/yyyy HH:mm");
            }

            txtBarcode.Text = "*" + vehicleInfo.PlateNumber + "*";

            txtPrintUser.Text = _userInfo.Name;
            txtPrintType.Text = "Nhập xe vào bãi xuất";
            DateTime currentDate = CommonFactory.GetCurrentDate();
            txtPrintDate.Text = currentDate.ToString("dd/MM/yyyy HH:mm");

            //update tong so lan print ticket trong 1 ngay
            long orderNumber = ApplicationObjectFactory.updateTotalTicketPrint(ApplicationObjectFactory.TOTAL_EXPORT_PARK_TICKET_IN_DATE);

            txtTotalPrintVehicleTicketOfDay.Text = orderNumber.ToString();

            //preview ticket
            //var report = new FrmCrystalReport(vehicleTicket, _userInfo);
            //report.MaximizeBox = true;
            //report.Show(this);

            //Print ticket directly
            vehicleTicket.ExportToDisk(ExportFormatType.CrystalReport, "VehicleTicket.rpt");

            foreach (String printerName in _printSetting.ListPrinter)
            {
                try
                {
                    AutoPrintReport(printerName, "VehicleTicket.rpt");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không kết nối được với máy in: " + printerName);
                }
            }

        
        }

        private void AutoPrintReport(string printerName, String reportFileURL)
        {
            //PageMargins margins;
            ReportDocument Report = new ReportDocument();

            //VehicleInputTicket ticket = new VehicleInputTicket();
            //ticket.ExportToDisk(ExportFormatType.CrystalReport, "VehicleTicket.rpt");
            Report.Load(reportFileURL);

            // Select the printer.
            Report.PrintOptions.PrinterName = printerName;

            // Print the report. Set the startPageN and endPageN
            // parameters to 0 to print all pages.
            Report.PrintToPrinter(1, false, 0, 0);
        }

        private void AutoFillVehicleType()
        {
            tblVehicle vehicle = VehicleFactory.GetByPlateNumber(txtPlateNumber.Text);
            if (vehicle != null)
            {
                if (vehicle.vehicleTypeId != null)
                {
                    cbVehicleType.SelectedValue = vehicle.vehicleTypeId;
                }
                txtDriverName.Text = vehicle.DriverName;
            }
        }
    }
}
