using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.Utilities;
using Microsoft.Office.Interop.Excel;
using Point = System.Drawing.Point;
using log4net;
using ECustoms.DAL;
using System.Configuration;

namespace ECustoms
{
    public partial class frmDecleration : SubFormBase
    {
        private readonly ILog logger = LogManager.GetLogger("Ecustoms.frmDecleration");

        private UserInfo _userInfo;
        private readonly Form _mainForm;
        private System.Timers.Timer aTimer;
        private List<ViewAllDeclaration> _listDeclarationinfo;
        public frmDecleration()
        {
            InitializeComponent();
        }

        public frmDecleration(UserInfo userInfo, Form mainForm)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _mainForm = mainForm;
        }

        private void frmDecleration_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormClosed += new FormClosedEventHandler(frmDecleration_FormClosed);
                this.Text = "Danh sach to khai" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
                comboBoxType.SelectedIndex = 0;
                cbRegDate.Checked = true;
                cbConfirmDate.Checked = false;
                dtpConfirmTo.Enabled = false;
                dtpConfirmFrom.Enabled = false;
                // Show form to the center
                this.Location = new Point((_mainForm.Width - this.Width) / 2, (_mainForm.Height - this.Height) / 2);

                this._listDeclarationinfo = DeclarationFactory.SelectAllFromView();
                BindData();
                txtDeclaraceNumber.Focus();
                //InitialPermission();

                //Start a timer

                // The secret here :)
                this.aTimer = new System.Timers.Timer();
                this.aTimer.Elapsed += new ElapsedEventHandler(OnTimerMonitor);
                this.aTimer.Interval = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["TimeDelay"]) * 1000;
                this.aTimer.Enabled = true;

                //check user permission
                btnAdd.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_TO_KHAI);
                btnAddImport.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_TO_KHAI);
                btnUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_TO_KHAI);
                btnDelete.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_TO_KHAI);
                btnConfirm.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TRA_HO_SO);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        void frmDecleration_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.aTimer.Enabled = false;
        }

        private void OnTimerMonitor(object sender, System.Timers.ElapsedEventArgs e)
        {
            MonitorContacIdCallback monitorContacIdCallback = new MonitorContacIdCallback(BindData);
            this.Invoke(monitorContacIdCallback);
        }

        private delegate void MonitorContacIdCallback();

        /// <summary>
        /// Personal check
        /// </summary>
        //private void InitialPermission()
        //{
        //    //throw new NotImplementedException();

        //    if (_userInfo.Type == UserType.Admin)
        //    {

        //    }
        //    else if (_userInfo.Type == UserType.Confirm)
        //    {
        //        btnDelete.Enabled = false;
        //    }
        //    else if (_userInfo.Type == UserType.Input)
        //    {
        //        btnDelete.Enabled = false;
        //    }
        //}

        /// <summary>
        /// Bind data by search codition
        /// This methold will be called after refresh time ( from web.config)
        /// </summary>
        public void BindData()
        {
            try
            {
                var from = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, 0, 0, 0);
                var to = new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, 23, 59, 59);

                var confirmFrom = new DateTime(dtpConfirmFrom.Value.Year, dtpConfirmFrom.Value.Month, dtpConfirmFrom.Value.Day, 0, 0, 0);
                var confirmTo = new DateTime(dtpConfirmTo.Value.Year, dtpConfirmTo.Value.Month, dtpConfirmTo.Value.Day, 23, 59, 59);

                // Get declaration from database
                _listDeclarationinfo = DeclarationFactory.SelectAllFromView();
                var declarationNumber = txtDeclaraceNumber.Text.Trim();
                var companyName = txtCompanyName.Text.Trim();
                List<ViewAllDeclaration> result = null;

                result = _listDeclarationinfo.OrderByDescending(p => p.ModifiedDate).ToList();
                //filter by declarationNumber
                if (string.IsNullOrEmpty(txtDeclaraceNumber.Text) == false) //TODO: xem lai cho nay vua sua dâtbae
                { //has nunber, not has copany name
                    result = result.Where(d => d.Number.ToString().Contains(declarationNumber)).OrderByDescending(p => p.ModifiedDate).ToList();
                }

                //filter by CompanyName
                if (string.IsNullOrEmpty(txtCompanyName.Text) == false)
                { // has company name, has not number
                    result = result.Where(d => (d.CompanyName != null) && (d.CompanyName.Contains(companyName))).OrderByDescending(p => p.ModifiedDate).ToList();
                }

                //filter by RegisterDate
                if (cbRegDate.Checked == true)
                {
                    result =
                      result.Where(g => g.RegisterDate >= from && g.RegisterDate <= to).OrderByDescending(
                        p => p.ModifiedDate).ToList();
                }
                else
                {
                    result = result.OrderByDescending(p => p.ModifiedDate).ToList();
                }

                //filter by ConfirmDate (ngay tra ho so)
                if (cbConfirmDate.Checked == true)
                {
                    result =
                      result.Where(g => g.ConfirmStatus != null && g.ConfirmDate >= confirmFrom && g.ConfirmDate <= confirmTo).OrderByDescending(
                        p => p.ModifiedDate).ToList();
                }
                else
                {
                    result = result.OrderByDescending(p => p.ModifiedDate).ToList();
                }

                //fillter by ConfirmStatus
                if (cbConfirmStatus.Checked == true)
                {
                    result = result.Where(g => g.ConfirmStatus == null).OrderByDescending(p => p.ModifiedDate).ToList();
                }
                else
                {
                    result = result.OrderByDescending(p => p.ModifiedDate).ToList();
                }

                // Filter by Type
                FilterByType(ref result);
                grvDecleration.AutoGenerateColumns = false;
                grvDecleration.DataSource = result;

                for (int i = 0; i < grvDecleration.Rows.Count; i++)
                {
                    var declarationType = grvDecleration.Rows[i].Cells["DeclarationType"].Value;
                    if (declarationType.Equals((short)Common.DeclerationType.Export)) // tờ khai xuất
                    {
                        System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#ffc0c0");
                        grvDecleration.Rows[i].DefaultCellStyle.BackColor = col;
                    }
                    else
                    {
                        System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#c1ffc0");
                        grvDecleration.Rows[i].DefaultCellStyle.BackColor = col;
                    }
                }

                if (result != null && result.Count > 0)
                {
                    SetVehicleInfo(grvDecleration.Rows[0]);
                }
                else
                {  // No result
                    lblHeader.Text = "";
                    listViewVehicle.Clear();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        #region Private methods

        /// <summary>
        /// Filter data by Decleration type
        /// </summary>
        /// <param name="declarations"></param>
        private void FilterByType(ref List<ViewAllDeclaration> declarations)
        {
            switch (comboBoxType.SelectedIndex)
            {
                case 1:
                    declarations = declarations.Where(g => g.DeclarationType == 0).ToList();
                    break;
                case 2:
                    declarations = declarations.Where(g => g.DeclarationType == 1).ToList();
                    break;
            }
        }

        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDecleration.SelectedRows.Count > 0)
                {
                    var dr = MessageBox.Show("Bạn có chắc là muốn xóa?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        for (int i = 0; i < grvDecleration.SelectedRows.Count; i++)
                        {
                            var declerationID = Convert.ToInt64(grvDecleration.SelectedRows[i].Cells[0].Value);
                            DeclarationFactory.DeleteByID(declerationID);
                        }
                        MessageBox.Show("Xóa xong");
                        BindData();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn tờ khai.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDecleration.SelectedRows.Count != 0)
                {
                    var declarationType = grvDecleration.SelectedRows[0].Cells["DeclarationType"].Value;
                    if (declarationType.Equals((short)Common.DeclerationType.Export)) // tờ khai xuất
                    {
                        var frmExport = new FrmDecleExport(_mainForm, _userInfo, 1, Convert.ToInt32(grvDecleration.SelectedRows[0].Cells[0].Value), Common.DeclerationType.Export);
                        frmExport.Show(this);
                    }
                    else
                    {
                        var frmExport = new FrmDecleExport(_mainForm, _userInfo, 1, Convert.ToInt32(grvDecleration.SelectedRows[0].Cells[0].Value), Common.DeclerationType.Import);
                        frmExport.Show(this);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn 1 tờ khai cần cập nhật.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmExport = new FrmDecleExport(_userInfo, 0, Common.DeclerationType.Export, _mainForm);
            frmExport.Show(this);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
                var excel = new ApplicationClass();
                excel.Application.Workbooks.Add(true);

                var columnIndex = 0;
                for (var i = 0; i < grvDecleration.Columns.Count; i++)
                {
                    if (!grvDecleration.Columns[i].Visible) continue;
                    columnIndex++;
                    excel.Cells[1, columnIndex] = grvDecleration.Columns[i].HeaderText;
                    ((Range)excel.Cells[1, columnIndex]).Font.Bold = true;
                }
                int rowIndex = 0;
                foreach (DataGridViewRow dataRow in grvDecleration.Rows)
                {
                    rowIndex++;

                    excel.Cells[rowIndex + 1, 1] = dataRow.Cells["Number"].Value != null ? dataRow.Cells["Number"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 2] = dataRow.Cells["CompanyCode"].Value != null ? dataRow.Cells["CompanyCode"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 3] = dataRow.Cells["ExportType"].Value != null ? dataRow.Cells["ExportType"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 4] = dataRow.Cells["RegisterDate"].Value != null ? ((DateTime)(dataRow.Cells["RegisterDate"].Value)).ToString("dd/MM/yyyy hh:mm") : "";
                    excel.Cells[rowIndex + 1, 5] = dataRow.Cells["ConfirmStatus"].Value != null ? dataRow.Cells["ConfirmStatus"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 6] = dataRow.Cells["ConfirmDate"].Value != null ? ((DateTime)(dataRow.Cells["ConfirmDate"].Value)).ToString("dd/MM/yyyy hh:mm") : "";
                    excel.Cells[rowIndex + 1, 7] = dataRow.Cells["ProductName"].Value != null ? dataRow.Cells["ProductName"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 8] = dataRow.Cells["CompanyName"].Value != null ? dataRow.Cells["CompanyName"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 9] = dataRow.Cells["ProductAmount"].Value != null ? dataRow.Cells["ProductAmount"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 10] = dataRow.Cells["Unit"].Value != null ? dataRow.Cells["Unit"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 11] = dataRow.Cells["ModifiedDate"].Value != null ? dataRow.Cells["ModifiedDate"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 12] = dataRow.Cells["ModifiedBy"].Value != null ? dataRow.Cells["ModifiedBy"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 13] = dataRow.Cells["CreatedBy"].Value != null ? dataRow.Cells["CreatedBy"].Value.ToString() : "";
                    excel.Cells[rowIndex + 1, 14] = dataRow.Cells["CreatedDate"].Value != null ? dataRow.Cells["CreatedDate"].Value.ToString() : "";
                }

                excel.Visible = true;
                var worksheet = (Worksheet)excel.ActiveSheet;
                worksheet.Activate();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        //private void BindSearch() 
        //{
        //    try
        //    {
        //        var declarationNumber = txtDeclaraceNumber.Text.Trim();
        //        var companyName = txtCompanyName.Text.Trim();
        //        List<tblDeclaration> result = null;
        //        var db = new dbEcustomEntities(Utilities.Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

        //        List<tblDeclaration> listDeclaration = db.tblDeclarations.ToList();
        //        result = listDeclaration.Where(d => (d.Number.ToString().Equals(declarationNumber) || d.ImportNumber.ToString().Equals(declarationNumber)) && (d.CompanyName.Contains(companyName) || d.ImportCompanyName.Contains(companyName))).ToList();
        //        grvDecleration.DataSource = result;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
        //        logger.Error(ex.ToString());
        //    }

        //}

        private void grvDecleration_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                logger.Info("grvDecleration_RowLeave");
                SetVehicleInfo(grvDecleration.Rows[e.RowIndex]);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Set Vehicel
        /// </summary>
        /// <param name="row"></param>
        private void SetVehicleInfo(DataGridViewRow row)
        {
            try
            {
                // Clear result
                listViewVehicle.Clear();
                lblHeader.Visible = true;

                var exportNumber = row.Cells["Number"].Value;
                var declarationType = row.Cells["DeclarationType"].Value;

                if (declarationType.Equals((short)Common.DeclerationType.Export)) // tờ khai xuất
                    lblHeader.Text = "Thông tin về phương tiện chở hàng cho tờ khai xuất " + exportNumber + ":";
                else
                    lblHeader.Text = "Thông tin về phương tiện chở hàng cho tờ khai nhập " + exportNumber + ":";

                // Get List vehicle 
                var declaractionID = Convert.ToInt32(row.Cells["DeclarationID"].Value);
                var listVehicle = VehicleFactory.GetByDeclarationID(declaractionID);
                StringBuilder vehicleInfo;
                // return if does not any vehicle
                if (listVehicle.Count <= 0) return;
                for (int i = 0; i < listVehicle.Count; i++)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    var currentVehicle = listVehicle[i];
                    vehicleInfo = new StringBuilder();
                    vehicleInfo.Append("Xe " + currentVehicle.PlateNumber + "; ");
                    // Exported information
                    if (currentVehicle.IsExport != null && currentVehicle.IsExport.Value) // Exported
                    {
                        vehicleInfo.Append("Đã xuất cảnh ngày " + currentVehicle.ExportDate.Value.ToString("dd/MM/yyyy HH:mm"));
                        System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#fff17e");
                        listViewItem.BackColor = col;
                    }
                    else // not exported
                    {
                        vehicleInfo.Append(" Chưa XC;");
                    }

                    // Import Information
                    if (currentVehicle.IsImport != null && currentVehicle.IsImport.Value) // Imported
                    {
                        vehicleInfo.Append(" Đã NC ngày " + currentVehicle.ImportDate.Value.ToString("dd/MM/yyyy HH:MM"));
                        System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#a0c8f9");
                        listViewItem.BackColor = col;
                    }
                    else // not imported
                        vehicleInfo.Append(" Chưa NC;");
                    // hasGoodsImport
                    if (currentVehicle.HasGoodsImported != null && currentVehicle.HasGoodsImported.Value)
                        vehicleInfo.Append(" Có chở hàng NK;");
                    else
                        vehicleInfo.Append(" Không chở hàng NK;");
                    // Go to local
                    if (currentVehicle.IsGoodsImported != null && currentVehicle.IsGoodsImported.Value)
                    {
                        vehicleInfo.Append(" Đã vào nội địa");
                        System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
                        listViewItem.BackColor = col;
                    }
                    else
                        vehicleInfo.Append(" Chưa vào nội địa");

                    listViewItem.Text = vehicleInfo.ToString();
                    // Add data to listView
                    listViewVehicle.Items.Add(listViewItem);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void grvDecleration_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_TO_KHAI))
            {
                try
                {
                    if (e.RowIndex >= 0 && grvDecleration.SelectedRows.Count == 1) // Only select one row
                    {
                        var declarationType = grvDecleration.SelectedRows[0].Cells["DeclarationType"].Value;
                        if (declarationType.Equals((short)Common.DeclerationType.Export)) // tờ khai xuất
                        {
                            var frmExport = new FrmDecleExport(_mainForm, _userInfo, 1, Convert.ToInt64(grvDecleration.SelectedRows[0].Cells[0].Value), Common.DeclerationType.Export);
                            frmExport.Show(this);
                        }
                        else
                        {
                            var frmExport = new FrmDecleExport(_mainForm, _userInfo, 1, Convert.ToInt64(grvDecleration.SelectedRows[0].Cells[0].Value), Common.DeclerationType.Import);
                            frmExport.Show(this);
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex.ToString());
                    if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnAddImport_Click(object sender, EventArgs e)
        {
            var frmExport = new FrmDecleExport(_userInfo, 0, Common.DeclerationType.Import, _mainForm);
            frmExport.Show(this);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDecleration.SelectedRows.Count != 0)
                {
                    var dr = MessageBox.Show("Bạn có chắc là muốn xác nhận?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        var result = DeclarationFactory.ConfirmReturnDocument("Đã trả hồ sơ",
                                                         Convert.ToInt64(grvDecleration.SelectedRows[0].Cells[0].Value));
                        BindData();                        
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn 1 tờ khai cần cập nhật.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void grvDecleration_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                logger.Info("grvDecleration_RowLeave");
                SetVehicleInfo(grvDecleration.Rows[e.RowIndex]);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void cbRegDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRegDate.Checked == true)
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
        }

        private void cbConfirmDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConfirmDate.Checked == true)
            {
                dtpConfirmFrom.Enabled = true;
                dtpConfirmTo.Enabled = true;
                cbConfirmStatus.Checked = false;
            }
            else
            {
                dtpConfirmFrom.Enabled = false;
                dtpConfirmTo.Enabled = false;
                cbConfirmStatus.Enabled = true;
            }
        }

        private void cbConfirmStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConfirmStatus.Checked == true)
            {
                cbConfirmDate.Checked = false;
                dtpConfirmFrom.Enabled = false;
                dtpConfirmTo.Enabled = false;
            }
            else
            {
                cbConfirmDate.Enabled = true;
            }
        }

        private void btnFee_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDecleration.SelectedRows.Count == 1)
                {
                    var frmDeclarationFee = new frmDeclarationFee(_userInfo, Convert.ToInt32(grvDecleration.SelectedRows[0].Cells["DeclarationType"].Value), Convert.ToInt64(grvDecleration.SelectedRows[0].Cells[0].Value), Convert.ToInt32(grvDecleration.SelectedRows[0].Cells["Number"].Value));
                    frmDeclarationFee.ShowDialog(this);
                    return;
                    var dr = MessageBox.Show("Bạn có chắc là muốn xác nhận thu phí?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        DeclarationFactory.ConfirmGetFee(Convert.ToInt64(grvDecleration.SelectedRows[0].Cells[0].Value), Convert.ToInt32(grvDecleration.SelectedRows[0].Cells["DeclarationType"].Value), _userInfo.UserID);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn 1 tờ khai cần cập nhật.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }
    }
}
