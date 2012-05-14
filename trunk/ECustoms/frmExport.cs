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
using ECustoms.DAL;
using System.Data.Objects.DataClasses;

namespace ECustoms
{
    public partial class frmExport : Form
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("Ecustoms.frmExport");                
        private UserInfo _userInfo;
        private int _mode;
        private int _declerationID;
        private List<ViewAllVehicleHasGood> _vehicleInfosTemp = new List<ViewAllVehicleHasGood>(); // This variable is used to store data in the gridview
        private bool _hasDeclaration;
        // This variable to let you know wthis form is opened from what form
        private Form _parent;
        public frmExport()
        {
            InitializeComponent();
        }

        public frmExport(UserInfo userInfo, int mode, Form parrent)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _mode = mode;
            _parent = parrent;
        }

        public frmExport(UserInfo userInfo, int mode, int declerationID)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _mode = mode;
            _declerationID = declerationID;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate()) return;
                var declarationInfo = GetDeclarationInfo();
                var listVehicleInfo = new List<tblVehicle>();
                tblVehicle vehicleInfo;
                // Validate Vehicle information
                if (grdVehicle.Rows.Count > 0)
                {
                    for (int i = 0; i < grdVehicle.Rows.Count; i++)
                    {
                        vehicleInfo = new tblVehicle();
                        // Do not save the record that platNumber is empty
                        if (grdVehicle.Rows[i].Cells["PlateNumber"].Value != null && grdVehicle.Rows[i].Cells["PlateNumber"].Value != "")
                        {
                            vehicleInfo.PlateNumber = grdVehicle.Rows[i].Cells["PlateNumber"].Value.ToString();
                        }
                        else
                        {
                            continue;
                        }

                        if (grdVehicle.Rows[i].Cells["NumberOfContainer"].Value != null)
                            vehicleInfo.NumberOfContainer = grdVehicle.Rows[i].Cells["NumberOfContainer"].Value.ToString();

                        if (grdVehicle.Rows[i].Cells["DriverName"].Value != null)
                            vehicleInfo.DriverName = grdVehicle.Rows[i].Cells["DriverName"].Value.ToString();

                        if (grdVehicle.Rows[i].Cells["IsExport"].Value != null)
                            vehicleInfo.IsExport = Convert.ToBoolean(grdVehicle.Rows[i].Cells["IsExport"].Value);

                        // Set Export Date
                        if (vehicleInfo.IsExport != null && vehicleInfo.IsExport.Value && grdVehicle.Rows[i].Cells["ExportDate"].Value != null)
                        {
                            vehicleInfo.ExportDate = Convert.ToDateTime(grdVehicle.Rows[i].Cells["ExportDate"].Value);
                        }

                        if (grdVehicle.Rows[i].Cells["IsImport"].Value != null)
                            vehicleInfo.IsImport = Convert.ToBoolean(grdVehicle.Rows[i].Cells["IsImport"].Value);

                        // Set Import Date
                        if (vehicleInfo.IsImport != null && vehicleInfo.IsImport.Value && grdVehicle.Rows[i].Cells["ImportDate"].Value != null)
                        {
                            vehicleInfo.ImportDate = Convert.ToDateTime(grdVehicle.Rows[i].Cells["ImportDate"].Value);
                        }

                        if (grdVehicle.Rows[i].Cells["Note"].Value != null)
                            vehicleInfo.Note = grdVehicle.Rows[i].Cells["Note"].Value.ToString();
                        if (grdVehicle.Rows[i].Cells["Status"].Value != null)
                            vehicleInfo.Status = grdVehicle.Rows[i].Cells["Status"].Value.ToString();

                        // TODO: Có thể thiếu trường HasGoodExport
                        if (!string.IsNullOrEmpty(txtImportNumber.Text) && Convert.ToInt32(txtImportNumber.Text) > 0)
                            vehicleInfo.HasGoodsImported = true;
                        else
                            vehicleInfo.HasGoodsImported = false;

                        // Add to list vehicles
                        listVehicleInfo.Add(vehicleInfo);

                    } // End for
                }
                // TODO: Need to check return value
                //DeclarationFactory.AddDeclaration(declarationInfo, listVehicleInfo, _userInfo.UserID);
                MessageBox.Show(ConstantInfo.MESSAGE_INSERT_SUCESSFULLY);

                switch (this._parent.Name.ToUpper())
                {
                    case "FRMDECLERATION":
                        {
                            // close the form
                            this.Close();
                            // Bind data to the gridivew
                            ((frmDecleration)_parent).BindData();
                        }
                        break;
                    case "FRMMAINFORM":
                        {
                            // Just close from if this form is opened from main from
                            this.Close();
                        }
                        break;
                    default:
                        break;
                }

                // Reset form
                ResetForm();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());      
            }
        }

        private bool Validate()
        {
            // Validate export declaration
            if (rdoExport.Checked)
            {
                if (string.IsNullOrEmpty(txtExportNumber.Text.Trim()) && cbExportHasDeclaration.Checked)
                {
                    MessageBox.Show(ConstantInfo.MESSAGE_BLANK_DECLARATION_NUMBER);
                    txtExportNumber.Focus();
                    return false;
                }
                return true;
            }
            if (string.IsNullOrEmpty(txtImportNumber.Text.Trim()) && cbImportHasDeclaration.Checked)
            {
                MessageBox.Show(ConstantInfo.MESSAGE_BLANK_DECLARATION_NUMBER);
                txtExportNumber.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get Declaration from Controls
        /// </summary>
        /// <returns></returns>
        private tblDeclaration GetDeclarationInfo()
        {
            var declarationInfo = new DAL.tblDeclaration();

            if (!string.IsNullOrEmpty(txtExportNumber.Text))
            {
                declarationInfo.Number = Convert.ToInt32(txtExportNumber.Text.Trim());
            }
            else
            {
                declarationInfo.Number = 0;
            }

            declarationInfo.Type = txtTypeExport.Text.Trim();
            declarationInfo.CompanyName = txtExportCompanyName.Text;
            declarationInfo.CompanyCode = txtExportCompanyCode.Text;
            declarationInfo.RegisterDate = dtpExportRegisterDate.Value;
            declarationInfo.ProductAmount = txtExportProductAmount.Text.Trim();
            declarationInfo.Unit = txtExportUnit.Text.Trim();
            declarationInfo.ProductName = txtExportProductName.Text;
            declarationInfo.HasDeclaration = cbExportHasDeclaration.Checked;

            //// import
            //if (!string.IsNullOrEmpty(txtImportNumber.Text.Trim()))
            //{
            //    //declarationInfo.ImportNumber = Convert.ToInt32(txtImportNumber.Text.Trim());
            //}
            //else
            //{
            //    declarationInfo.ImportNumber = 0;
            //}

            //declarationInfo.ImportType = txtTypeImport.Text.Trim();
            //declarationInfo.ImportCompanyName = txtImportCompanyName.Text;
            //declarationInfo.ImportCompanyCode = txtImportCompanyCode.Text;
            //declarationInfo.ImportRegisterDate = dtpImportRegisterDate.Value;
            //declarationInfo.ImportProductAmount = txtImportProductAmount.Text.Trim();
            //declarationInfo.ImportUnit = txtImportUnit.Text.Trim();
            //declarationInfo.ImportProductName = txtImportProductName.Text;
            //declarationInfo.ImportHasDeclaration = cbImportHasDeclaration.Checked;

            declarationInfo.ModifiedDate = CommonFactory.GetCurrentDate();
            declarationInfo.ModifiedByID = _userInfo.UserID;

            return declarationInfo;
        }

        private void ResetForm()
        {
            txtExportNumber.Text = "";
            txtExportProductName.Text = "";
            txtExportCompanyName.Text = "";
            txtExportProductAmount.Text = "";
            txtExportUnit.Text = "";
            txtExportTotalVehicles.Text = "";
            txtTypeExport.Text = string.Empty;
            txtTypeImport.Text = string.Empty;
            grdVehicle.DataSource = null;
        }

        private void frmExport_Load(object sender, EventArgs e)
        {
            txtExportTotalVehicles.Focus();
            this.Text = "Khai bao xuat nhap canh" + ConstantInfo.MESSAGE_TITLE;
            // Show form to the center
            this.Location = new Point((this.ParentForm.Width - this.Width) / 2, (this.ParentForm.Height - this.Height) / 2);                        
            // Init form.
            Init();
           // InitialPermission();

          //check user permission
            btnAddVehicle.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_MOI_PHUONG_TIEN);
            btnAddExisting.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_MOI_PHUONG_TIEN);
            btnUpdateVehicle.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_PHUONG_TIEN);
            btnDeleteVehicle.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XOA_PHUONG_TIEN);

            btnComfirmExport.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_XUAT_CANH);
            btnConfirmImportKH.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_NHAP_CANH);
            bntConfirmImportCH.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_NHAP_CANH);
           
            btnAdd.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_TAO_TO_KHAI);
            btnUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_TO_KHAI);
        }

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
        //        // Add Mode
        //        if (_mode == 0)
        //            btnDeleteVehicle.Enabled = true;
        //        else
        //            btnDeleteVehicle.Enabled = false;
        //    }
        //    else if (_userInfo.Type == UserType.Input)
        //    {
        //        btnComfirmExport.Enabled = false;
        //        bntConfirmImportCH.Enabled = false;
        //        btnConfirmImportKH.Enabled = false;
        //        // Add Mode
        //        if (_mode == 0)
        //            btnDeleteVehicle.Enabled = true;
        //        else
        //            btnDeleteVehicle.Enabled = false;
        //    }
        //}

        /// <summary>
        /// Init data
        /// </summary>
        private void Init()
        {
            grdVehicle.AutoGenerateColumns = false;
            // New mode))
            if (this._mode == 0)
            {
                btnUpdate.Enabled = false;
                btnAdd.Enabled = true;
                btnReset.Enabled = true;
            }
            else // Edit mode
            {
                btnUpdate.Enabled = true;
                btnAdd.Enabled = false;
                btnReset.Enabled = false;

                // Get Decleration information
                var declarationInfo = DeclarationFactory.GetByID(this._declerationID);
                // Bind Declaration to controls
                if (declarationInfo != null)
                {
                    txtExportNumber.Text = declarationInfo.Number.ToString();
                    txtExportProductName.Text = declarationInfo.ProductName;
                    txtExportCompanyName.Text = declarationInfo.CompanyName;
                    txtExportProductAmount.Text = declarationInfo.ProductAmount;
                    txtExportUnit.Text = declarationInfo.Unit;
                    txtTypeExport.Text = declarationInfo.Type;
                    //txtTypeImport.Text = declarationInfo.ImportType;
                    txtExportCompanyCode.Text = declarationInfo.CompanyCode;
                    dtpExportRegisterDate.Value = declarationInfo.RegisterDate != null ? declarationInfo.RegisterDate.Value : CommonFactory.GetCurrentDate();
                    if (declarationInfo.HasDeclaration != null && !declarationInfo.HasDeclaration.Value)
                    {
                        cbExportHasDeclaration.Checked = false;
                        gbExportDeclaration.Enabled = false;
                        gbImportDeclaration.Enabled = false;
                    }

                    //txtImportNumber.Text = declarationInfo.ImportNumber.ToString();
                    //txtImportProductName.Text = declarationInfo.ImportProductName;
                    //txtImportCompanyName.Text = declarationInfo.ImportCompanyName;
                    //txtImportProductAmount.Text = declarationInfo.ImportProductAmount;
                    //txtImportUnit.Text = declarationInfo.ImportUnit;
                    //txtImportCompanyCode.Text = declarationInfo.ImportCompanyCode;
                    //dtpImportRegisterDate.Value = declarationInfo.ImportRegisterDate != null ? declarationInfo.ImportRegisterDate.Value : DateTime.Now;

                    //if (declarationInfo.ImportHasDeclaration != null && !declarationInfo.ImportHasDeclaration.Value)
                    //{
                    //    cbImportHasDeclaration.Checked = false;
                    //    gbImportDeclaration.Enabled = false;
                    //}
                }

                // Get Vehicle by DeclarationID
                var listVehicle = VehicleFactory.GetFromViewByDeclarationID(this._declerationID);
                BindVehicle(listVehicle);
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
                // Set first column to read only
                grdVehicle.Columns[0].ReadOnly = true;
                // Set number of vehicle
                if (!string.Equals(txtExportTotalVehicles.Text, grdVehicle.Rows.Count.ToString()) || grdVehicle.Rows.Count > 0)
                {
                    txtExportTotalVehicles.Text = grdVehicle.Rows.Count.ToString();
                }
                _vehicleInfosTemp = vehicleInfos;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_declerationID != 0)
                {
                    var declerationInfo = GetDeclarationInfo();
                    // Set DeclerationID
                    declerationInfo.DeclarationID = this._declerationID;
                    // Update Decleration
                    DeclarationFactory.Update(declerationInfo);                    

                    foreach (var vehicle in this._vehicleInfosTemp)
                    {
                        //update declationId    

                        var v = new tblVehicle();
                        v.VehicleID = vehicle.VehicleID;
                        
                        v.PlateNumber = vehicle.PlateNumber;
                        v.NumberOfContainer = vehicle.NumberOfContainer;
                        v.DriverName = vehicle.DriverName;
                        v.ImportDate = vehicle.ImportDate;
                        v.IsImport = vehicle.IsImport;
                        v.ExportDate = vehicle.ExportDate;
                        v.IsExport = vehicle.IsExport;
                        v.Note = vehicle.Note;
                        v.Status = vehicle.Status;
                        v.IsCompleted = vehicle.IsCompleted;
                        v.IsGoodsImported = vehicle.IsGoodsImported;
                        v.ImportStatus = vehicle.ImportStatus;
                        v.ImportedLocalTime = vehicle.ImportedLocalTime;
                        v.HasGoodsImported = vehicle.HasGoodsImported;
                        v.ConfirmExportBy = vehicle.ConfirmExportBy;
                        v.ConfirmImportBy = vehicle.ConfirmImportBy;
                        v.ConfirmLocalImportBy = vehicle.ConfirmLocalImportBy;
                        VehicleFactory.UpdateVehicle(v);
                    }

                    MessageBox.Show("Cập nhật thành công");
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
            try
            {
                txtExportNumber.Text = "";
                txtExportProductName.Text = "";
                txtExportCompanyName.Text = "";
                txtExportProductAmount.Text = "";
                txtExportUnit.Text = "";
                grdVehicle.Rows.Clear();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());      
            }

        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                //var declarationInfo = new tblDeclaration();
                //if (!string.IsNullOrEmpty(txtExportNumber.Text))
                //{
                //    declarationInfo.Number = Convert.ToInt32(txtExportNumber.Text);
                //}
                //declarationInfo.CreatedDate = DateTime.Now;
                //declarationInfo.ProductName = txtExportProductName.Text;
                //declarationInfo.ProductAmount = txtExportProductAmount.Text;
                //declarationInfo.HasDeclaration = cbExportHasDeclaration.Checked;
                //// Add Mode
                //if (_mode == 0)
                //{
                //    var vehicle = new frmVehicle(0, this, ref _vehicleInfosTemp, declarationInfo, _userInfo);
                //    vehicle.MdiParent = this.ParentForm;
                //    vehicle.Show();
                //}
                //else
                //{
                //    declarationInfo = DeclarationFactory.SelectByID(_declerationID);
                //    if (!string.IsNullOrEmpty(txtExportNumber.Text))
                //    {
                //        declarationInfo.Number = Convert.ToInt32(txtExportNumber.Text);
                //    }
                //    declarationInfo.CreatedDate = DateTime.Now;
                //    declarationInfo.ProductName = txtExportProductName.Text;
                //    declarationInfo.ProductAmount = txtExportProductAmount.Text;
                //    declarationInfo.HasDeclaration = cbExportHasDeclaration.Checked;
                //    // Update Mode
                //    var vehicle = new frmVehicle(4, this, ref _vehicleInfosTemp, declarationInfo, _userInfo);
                //    vehicle.MdiParent = this.ParentForm;
                //    vehicle.Show();
                //}
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdateVehicle_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var declarationInfo = new tblDeclaration();
            //    if (!string.IsNullOrEmpty(txtExportNumber.Text))
            //    {
            //        declarationInfo.Number = Convert.ToInt32(txtExportNumber.Text);
            //    }
            //    declarationInfo.CreatedDate = DateTime.Now;
            //    declarationInfo.ProductName = txtExportProductName.Text;
            //    declarationInfo.ProductAmount = txtExportProductAmount.Text;
            //    declarationInfo.HasDeclaration = cbExportHasDeclaration.Checked;
            //    // New mode
            //    if (grdVehicle.SelectedRows.Count == 1 && this._mode == 0)
            //    {
            //        var vehicle = new frmVehicle(1, this, ref _vehicleInfosTemp, Convert.ToInt32(grdVehicle.SelectedRows[0].Cells["Count"].Value), declarationInfo, _userInfo);
            //        vehicle.MdiParent = this.ParentForm;
            //        vehicle.Show();
            //    }
            //    else if (grdVehicle.SelectedRows.Count == 1 && this._mode == 1) // Update Mode
            //    {
            //        var vehicle = new frmVehicle(2, this, ref _vehicleInfosTemp, Convert.ToInt32(grdVehicle.SelectedRows[0].Cells["Count"].Value), declarationInfo, _userInfo);
            //        vehicle.MdiParent = this.ParentForm;
            //        vehicle.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Bạn cần chọn 1 phương tiện cần cập nhật.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    logger.Error(ex.ToString());
            //    if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());      
            //}
        }

        private void btnDeleteVehicle_Click_1(object sender, EventArgs e)
        {
            try
            {
                //TODO: Support delete multiple
                if (grdVehicle.SelectedRows.Count == 1 && _mode == 0) // New mode
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
                else if (grdVehicle.SelectedRows.Count == 1 && _mode == 1) // Edit mode
                {
                    var dr = MessageBox.Show("Bạn có chắc là muốn xóa?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        VehicleFactory.DeleteByID(Convert.ToInt32(grdVehicle.SelectedRows[0].Cells["VehicleID"].Value));
                        // Get Vehicle by DeclarationID
                        var listVehicle = VehicleFactory.GetFromViewByDeclarationID(this._declerationID);
                        BindVehicle(listVehicle);
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

        private void cbHasDeclaration_CheckedChanged(object sender, EventArgs e)
        {
            if (cbExportHasDeclaration.Checked)
            {
                gbExportDeclaration.Enabled = true;
            }
            else
            {
                gbExportDeclaration.Enabled = false;
            }
        }

        private void grdVehicle_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex >= 0 && grdVehicle.SelectedRows.Count == 1)
            //    {

            //        var declarationInfo = new tblDeclaration();
            //        if (!string.IsNullOrEmpty(txtExportNumber.Text))
            //        {
            //            declarationInfo.Number = Convert.ToInt32(txtExportNumber.Text);
            //        }
            //        declarationInfo.CreatedDate = DateTime.Now;
            //        declarationInfo.ProductName = txtExportProductName.Text;
            //        declarationInfo.ProductAmount = txtExportProductAmount.Text;
            //        declarationInfo.HasDeclaration = cbExportHasDeclaration.Checked;

            //        // Bind the gridview data to the vehicleInfo object, make sure, the vehicleInfotem dat is same as the gridview.
            //        // Validate data of the gridview.
            //        // Clear the tem data

            //        //_vehicleInfosTemp.Clear();

            //        _vehicleInfosTemp = (List<ViewAllVehicle>)grdVehicle.DataSource;


            //        // New mode
            //        if (this._mode == 0)
            //        {
            //            var vehicle = new frmVehicle(1, this, ref _vehicleInfosTemp, Convert.ToInt32(grdVehicle.Rows[e.RowIndex].Cells["Count"].Value), declarationInfo, _userInfo);
            //            vehicle.MdiParent = this.ParentForm;
            //            vehicle.Show();
            //        }
            //        else if (this._mode == 1) // Update Mode
            //        {
            //            var vehicle = new frmVehicle(2, this, ref _vehicleInfosTemp, Convert.ToInt32(grdVehicle.Rows[e.RowIndex].Cells["Count"].Value), declarationInfo, _userInfo);
            //            vehicle.MdiParent = this.ParentForm;
            //            vehicle.Show();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    logger.Error(ex.ToString());
            //    if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            //}
        }

        private void rdoExport_CheckedChanged(object sender, EventArgs e)
        {
            cbImportHasDeclaration.Enabled = false;
            gbImportDeclaration.Enabled = false;
            cbExportHasDeclaration.Enabled = true;
            gbExportDeclaration.Enabled = true;
            cbExportHasDeclaration.Checked = true;
            grdVehicle.TabIndex = 9;
            btnAddExisting.Enabled = false;

        }

        private void rdoImport_CheckedChanged(object sender, EventArgs e)
        {
            cbImportHasDeclaration.Enabled = true;
            gbImportDeclaration.Enabled = true;
            cbExportHasDeclaration.Enabled = false;
            gbExportDeclaration.Enabled = false;
            cbImportHasDeclaration.Checked = true;
            btnAddExisting.Enabled = true;

            var declarationInfo = DeclarationFactory.GetByID(this._declerationID);

            //// Move all data from export form to import form if it is not existing
            //if (_mode == 0 || (declarationInfo != null && (declarationInfo.ImportNumber != null || declarationInfo.ImportNumber < 1)))
            //{
            //    txtImportNumber.Text = txtExportNumber.Text;
            //    txtImportCompanyName.Text = txtExportCompanyName.Text;
            //    txtImportProductName.Text = txtExportProductName.Text;
            //    txtImportProductAmount.Text = txtExportProductAmount.Text;
            //    txtImportUnit.Text = txtExportUnit.Text;
            //    txtTypeImport.Text = txtTypeExport.Text;
            //    txtImportCompanyCode.Text = txtExportCompanyCode.Text;
            //    dtpImportRegisterDate.Value = dtpExportRegisterDate.Value;
            //}
        }

        private void cbImportHasDeclaration_CheckedChanged(object sender, EventArgs e)
        {
            if (cbImportHasDeclaration.Checked)
            {
                gbImportDeclaration.Enabled = true;
            }
            else
            {
                gbImportDeclaration.Enabled = false;
            }
        }

        private void txtExportTotalVehicles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))// Enter key
            {
                try
                {

                    if (string.IsNullOrEmpty(txtExportTotalVehicles.Text)) return;
                    var totalVehicles = Convert.ToInt32(txtExportTotalVehicles.Text);

                    if (_vehicleInfosTemp.Count > totalVehicles)
                        throw new Exception("Bạn phải nhập số phương tiện lớn hơn số phương tiện hiện tại hoặc bạn phải xóa phương tiện đi");

                    ViewAllVehicleHasGood vehicleInfo;
                    var bias = totalVehicles - _vehicleInfosTemp.Count;
                    for (int i = 0; i < bias; i++)
                    {
                        vehicleInfo = new ViewAllVehicleHasGood();
                        // Add to the list object
                        _vehicleInfosTemp.Add(vehicleInfo);
                    }
                    // Bind to datagrid
                    BindVehicle(_vehicleInfosTemp);
                }
                catch (Exception ex)
                {
                    logger.Error(ex.ToString());
                    if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());      
                }
            }
        }

        private void groupBoxVehicle_Enter(object sender, EventArgs e)
        {

        }

        private void groupBoxVehicle_Enter_1(object sender, EventArgs e)
        {

        }

        private void txtExportTotalVehicles_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtExportTotalVehicles.Text)) return;
                var totalVehicles = Convert.ToInt32(txtExportTotalVehicles.Text);
                ViewAllVehicleHasGood vehicleInfo;
                for (int i = 0; i < totalVehicles - grdVehicle.Rows.Count; i++)
                {
                    vehicleInfo = new ViewAllVehicleHasGood();
                    // Add to the list object
                    _vehicleInfosTemp.Add(vehicleInfo);
                }
                // Bind to datagrid
                BindVehicle(_vehicleInfosTemp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());      
            }
        }

        private void txtExportUnit_Leave(object sender, EventArgs e)
        {
            grdVehicle.Focus();
        }

        private void txtImportUnit_Leave(object sender, EventArgs e)
        {
            grdVehicle.Focus();
        }

        private void grdVehicle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddExisting_Click(object sender, EventArgs e)
        {
            var frmSelect = new frmVehicleSelect(_declerationID);
            frmSelect.OnSelectedVehichle += new frmVehicleSelect.OnSelectedVehicleHandler(frmSelect_OnSelectedVehichle);
            frmSelect.Show();

        }

        void frmSelect_OnSelectedVehichle(object sender, EventArgs e)
        {

            var arg = (SelectedVehichleEventArgs)(e);
            var vehicleInfo = arg.Vehicle;

            foreach (var v in _vehicleInfosTemp)
            {
                if (v.VehicleID == vehicleInfo.VehicleID)
                    throw new Exception("Phương tiện này đã tồn tại trong tờ khai!");
            }
            _vehicleInfosTemp.Add(vehicleInfo);
            this.BindVehicle(_vehicleInfosTemp);

        }

        private void txtImportProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtExportTotalVehicles_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }


        #region Confirm Import or export

        private void btnComfirmExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVehicle.SelectedRows.Count == 1)
                {

                    var message = new StringBuilder();
                    message.Append("Thời gian xuất cảnh: " + CommonFactory.GetCurrentDate().ToString("dd/MM/yyyy HH:mm"));

                    if (MessageBox.Show(message.ToString(), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var count = 0;
                        foreach (var vehicleInfo in _vehicleInfosTemp)
                        {
                            count += 1;
                            if (count == Convert.ToInt32(grdVehicle.SelectedRows[0].Cells["Count"].Value))
                            {
                                vehicleInfo.ExportDate = CommonFactory.GetCurrentDate();
                                try
                                {
                                    if (vehicleInfo.ConfirmExportBy != null && vehicleInfo.ConfirmExportBy != 0 && vehicleInfo.ConfirmExportBy != _userInfo.UserID)
                                        throw new Exception("Phương tiện đã được xác nhận bởi một người dùng khác!");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return;
                                }

                                vehicleInfo.ConfirmExportBy = _userInfo.UserID;
                                vehicleInfo.IsExport = true;
                                break;
                            }
                        }
                        this.BindVehicle(_vehicleInfosTemp);
                        MessageBox.Show("Lưu thành công!");
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

        private void bntConfirmImportCH_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVehicle.SelectedRows.Count == 1)
                {
                    var message = new StringBuilder();
                    message.Append("Thời gian nhập cảnh: " + CommonFactory.GetCurrentDate().ToString("dd/MM/yyyy HH:mm"));


                    if (MessageBox.Show(message.ToString(), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var count = 0;
                        foreach (var vehicleInfo in _vehicleInfosTemp)
                        {
                            count += 1;
                            if (count == Convert.ToInt32(grdVehicle.SelectedRows[0].Cells[0].Value))
                            {
                                vehicleInfo.ImportDate = CommonFactory.GetCurrentDate();
                                vehicleInfo.IsImport = true;
                                vehicleInfo.HasGoodsImported = true;
                                vehicleInfo.ImportStatus = "Nhập cảnh có hàng";
                                try
                                {
                                    if ((vehicleInfo.ConfirmImportBy != null && vehicleInfo.ConfirmImportBy != 0) && vehicleInfo.ConfirmImportBy != _userInfo.UserID)
                                        throw new Exception("Phương tiện đã được xác nhận bởi một người dùng khác!");
                                    
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return;
                                }
                                vehicleInfo.ConfirmImportBy = _userInfo.UserID;
                                break;
                            }
                        }
                        this.BindVehicle(_vehicleInfosTemp);

                        MessageBox.Show("Lưu thành công!");
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

        private void btnConfirmImportKH_Click(object sender, EventArgs e)
        {
            try
            {

                if (grdVehicle.SelectedRows.Count == 1)
                {

                    var message = new StringBuilder();
                    message.Append("Thời gian nhập cảnh: " + CommonFactory.GetCurrentDate().ToString("dd/MM/yyyy HH:mm"));


                    if (MessageBox.Show(message.ToString(), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var count = 0;
                        foreach (var vehicleInfo in _vehicleInfosTemp)
                        {
                            count += 1;
                            if (count == Convert.ToInt32(grdVehicle.SelectedRows[0].Cells[0].Value))
                            {
                                vehicleInfo.ImportDate = CommonFactory.GetCurrentDate();
                                vehicleInfo.IsImport = true;
                                // Nhập cảnh không hàng
                                vehicleInfo.HasGoodsImported = false;
                                vehicleInfo.ImportStatus = "Nhập cảnh không có hàng";
                                try
                                {
                                    if ((vehicleInfo.ConfirmImportBy != null && vehicleInfo.ConfirmImportBy != 0) && vehicleInfo.ConfirmImportBy != _userInfo.UserID)
                                        throw new Exception("Phương tiện đã được xác nhận bởi một người dùng khác!");

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return;
                                }
                                vehicleInfo.ConfirmImportBy = _userInfo.UserID;
                                break;
                            }
                        }
                        this.BindVehicle(_vehicleInfosTemp);

                        MessageBox.Show("Lưu thành công!");
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

        #endregion
    }
}
