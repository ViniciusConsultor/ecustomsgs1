using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ECustoms.BOL;
using ECustoms.Utilities;
using Point = System.Drawing.Point;
using log4net;
using ECustoms.DAL;

namespace ECustoms
{
    public partial class frmDeclerationOptionInfo : Form
    {
        private readonly ILog logger = LogManager.GetLogger("Ecustoms.frmDeclerationOptionInfo");

        private UserInfo _userInfo;
        private readonly Form _mainForm;
        private List<ViewAllDeclaration> _listDeclarationinfo;
        private Common.DeclerationOptionType _declerationOptionType;
        public frmDeclerationOptionInfo()
        {
            InitializeComponent();
        }

        public frmDeclerationOptionInfo(UserInfo userInfo, Form mainForm, Common.DeclerationOptionType declerationOptionType)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _mainForm = mainForm;
            _declerationOptionType = declerationOptionType;
        }

        private void frmDeclerationOptionInfo_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Danh sach to khai" + ConstantInfo.MESSAGE_TITLE;
                switch (_declerationOptionType)
                {
                    case Common.DeclerationOptionType.XKCK:
                        lblHeader.Text = "Quản lý hàng xuất khẩu chuyển cửa khẩu";
                        lblGateExport.Visible = txtGateExport.Visible = false;
                        break;
                    case Common.DeclerationOptionType.NKCK:
                        lblHeader.Text = "Quản lý hàng nhập khẩu chuyển cửa khẩu";
                        lblGateExport.Visible = txtGateExport.Visible = false;
                        break;
                    case Common.DeclerationOptionType.TNTX:
                        lblHeader.Text = "Quản lý hàng tạm nhập tái xuất";
                        lblRegisterPlace.Visible = txtRegisterPlace.Visible = false;
                        break;
                    default:
                        break;
                }
                // Show form to the center
                this.Location = new Point((_mainForm.Width - this.Width) / 2, (_mainForm.Height - this.Height) / 2);
                //custumize check box column
                var cusCheckbox = new DataGridViewDisableCheckBoxColumn();
                cusCheckbox.Name = "CusCheckReturn";
                cusCheckbox.Width = 50;
                var cbCusHeader = new DatagridViewCheckBoxHeaderCell();
                cbCusHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(cbCusHeader_OnCheckBoxClicked);
                cusCheckbox.HeaderCell = cbCusHeader;
                cusCheckbox.HeaderText = "";
                grvDecleration.Columns.Insert(0, cusCheckbox);

                this._listDeclarationinfo = DeclarationFactory.SelectAllFromView();
                //BindData();
                txtDeclaraceNumber.Focus();
                //InitialPermission();

                //check user permission
               //btnUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_BO_XUNG_THONG_TIN_TNTX);
                btConfirmReturn.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_XAC_NHAN_HOI_BAO_TNTX);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private delegate void MonitorContacIdCallback();

        /// <summary>
        /// Bind data by search codition
        /// This methold will be called after refresh time ( from web.config)
        /// </summary>
        public void BindData()
        {
            try
            {
                // Get declaration from database
                _listDeclarationinfo = DeclarationFactory.SelectAllFromView();
                var declarationNumber = txtDeclaraceNumber.Text.Trim();
                var companyName = txtCompanyName.Text.Trim();
                List<ViewAllDeclaration> result = null;

                result = _listDeclarationinfo;
                //filter by declarationNumber
                if (!string.IsNullOrEmpty(txtDeclaraceNumber.Text))
                { //has nunber, not has copany name
                    result = result.Where(d => d.Number.ToString().Contains(declarationNumber)).ToList();
                }

                //filter by CompanyName
                if (string.IsNullOrEmpty(txtCompanyName.Text) == false)
                { // has company name, has not number
                    result = result.Where(d => (d.CompanyName != null) && (d.CompanyName.Contains(companyName))).ToList();
                }
                //filter by RegisterDate
                DateTime from, to;
                if (cbRegDate.Checked)
                {
                    from = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, 0, 0, 0);
                    to = new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, 23, 59, 59);
                    result = result.Where(g => g.RegisterDate >= from && g.RegisterDate <= to).ToList();
                }
                //filter by CreatedDate
                if (cbCreatedDate.Checked)
                {
                    from = new DateTime(dtpCreatedFrom.Value.Year, dtpCreatedFrom.Value.Month, dtpCreatedFrom.Value.Day, 0, 0, 0);
                    to = new DateTime(dtpCreatedTo.Value.Year, dtpCreatedTo.Value.Month, dtpCreatedTo.Value.Day, 23, 59, 59);
                    result = result.Where(g => g.CreatedDate >= from && g.CreatedDate <= to).ToList();
                }
                //filter by Return
                if (cbReturn.Checked != cbNotReturn.Checked)
                {
                    result = cbReturn.Checked ? result.Where(g => g.DateReturn != null).ToList() : result.Where(g => g.DateReturn == null).ToList();
                }
                //filter by Register Place
                if (!string.IsNullOrEmpty(txtRegisterPlace.Text))
                {
                    result = result.Where(d => (d.RegisterPlace != null) && (d.RegisterPlace.Contains(txtRegisterPlace.Text.Trim()))).ToList();
                }
                //filter by Gate export
                if (!string.IsNullOrEmpty(txtGateExport.Text))
                {
                    result = result.Where(d => (d.GateExport != null) && (d.GateExport.Contains(txtGateExport.Text.Trim()))).ToList();
                }

                // Filter by Type
                FilterByType(ref result);
                result = result.OrderByDescending(p => p.ModifiedDate).ToList();
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
            switch (_declerationOptionType)
            {
                case Common.DeclerationOptionType.XKCK:
                    declarations = declarations.Where(g => g.DeclarationType == (short)Common.DeclerationType.Export && (g.TypeOption == (short)Common.DeclerationOptionType.XKCK)).ToList();
                    break;
                case Common.DeclerationOptionType.NKCK:
                    declarations = declarations.Where(g => g.DeclarationType == (short)Common.DeclerationType.Import && (g.TypeOption == (short)Common.DeclerationOptionType.NKCK)).ToList();
                    break;
                case Common.DeclerationOptionType.TNTX:
                    declarations = declarations.Where(g => g.DeclarationType == (short)Common.DeclerationType.Import && g.TypeOption == (short)Common.DeclerationOptionType.TNTX).ToList();
                    break;
            }
        }

        #endregion

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDecleration.SelectedRows.Count != 0)
                {
                    var frmDecleExportOption = new FrmDecleExportOption(_mainForm, _userInfo, Convert.ToInt64(grvDecleration.SelectedRows[0].Cells["DeclarationID"].Value), _declerationOptionType);
                    frmDecleExportOption.Show(this);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void grvDecleration_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                logger.Info("grvDecleration_RowLeave");
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void grvDecleration_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0 && grvDecleration.SelectedRows.Count == 1) // Only select one row
                {
                    var frmExport = new FrmDecleExportOption(_mainForm, _userInfo, Convert.ToInt64(grvDecleration.SelectedRows[0].Cells["DeclarationID"].Value), _declerationOptionType);
                    frmExport.Show(this);
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
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void cbRegDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRegDate.Checked)
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

        private void grvDecleration_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (grvDecleration.Columns[e.ColumnIndex].Name != "CusCheckReturn")
            {
                grvDecleration.Columns[e.ColumnIndex].ReadOnly = true;
            }
            else
            {
                var dataRow = grvDecleration.Rows[e.RowIndex].DataBoundItem as ViewAllDeclaration;
                if (dataRow == null) return;
                if (dataRow.DateReturn != null)
                {
                    var cb = (DataGridViewDisableCheckBoxCell) grvDecleration.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cb.Enabled = false;
                    cb.ReadOnly = true;
                }
            }
        }

        private void cbCusHeader_OnCheckBoxClicked(bool check)
        {
            for (var i = 0; i < grvDecleration.Rows.Count; i++)
            {
                if (grvDecleration.Rows[i].Cells["DateReturn"].Value != null) continue;
                grvDecleration.Rows[i].Cells["CusCheckReturn"].Value = check;
            }
            grvDecleration.EndEdit();
        }

        private void btConfirmReturn_Click(object sender, EventArgs e)
        {
            try
            {
                var reload = false;
                for (var i = 0; i < grvDecleration.Rows.Count; i++)
                {
                    if (grvDecleration.Rows[i].Cells["CusCheckReturn"].Value != null && (bool) grvDecleration.Rows[i].Cells["CusCheckReturn"].Value)
                    {
                        var dataRow = grvDecleration.Rows[i].DataBoundItem as ViewAllDeclaration;
                        if (dataRow == null) break;
                        DeclarationFactory.UpdateReturnInfo(dataRow.DeclarationID, _userInfo.UserID);
                        reload = true;
                    }
                }
                if (reload)
                {
                   MessageBox.Show("Xác nhận hồi báo thành công.");
                   BindData(); 
                }
                
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void cbCreatedDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCreatedDate.Checked)
            {
                dtpCreatedFrom.Enabled = dtpCreatedTo.Enabled = true;
            }
            else
            {
                dtpCreatedFrom.Enabled = dtpCreatedTo.Enabled = false;
            }
        }

    }

    #region Custumize checkbox column data gird view
    public delegate void CheckBoxClickedHandler(bool state);
    public class DataGridViewCheckBoxHeaderCellEventArgs : EventArgs
    {
        bool _bChecked;
        public DataGridViewCheckBoxHeaderCellEventArgs(bool bChecked)
        {
            _bChecked = bChecked;
        }
        public bool Checked
        {
            get { return _bChecked; }
        }
    }
    class DatagridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
    {
        Point checkBoxLocation;
        Size checkBoxSize;
        bool _checked = false;
        Point _cellLocation = new Point();
        System.Windows.Forms.VisualStyles.CheckBoxState _cbState =
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;
        public event CheckBoxClickedHandler OnCheckBoxClicked;

        public DatagridViewCheckBoxHeaderCell()
        {
        }

        protected override void Paint(System.Drawing.Graphics graphics,
            System.Drawing.Rectangle clipBounds,
            System.Drawing.Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates dataGridViewElementState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                dataGridViewElementState, value,
                formattedValue, errorText, cellStyle,
                advancedBorderStyle, paintParts);
            Point p = new Point();
            Size s = CheckBoxRenderer.GetGlyphSize(graphics,
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            p.X = cellBounds.Location.X +
                (cellBounds.Width / 2) - (s.Width / 2);
            p.Y = cellBounds.Location.Y +
                (cellBounds.Height / 2) - (s.Height / 2);
            _cellLocation = cellBounds.Location;
            checkBoxLocation = p;
            checkBoxSize = s;
            if (_checked)
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.CheckedNormal;
            else
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.UncheckedNormal;
            CheckBoxRenderer.DrawCheckBox
            (graphics, checkBoxLocation, _cbState);
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
            if (p.X >= checkBoxLocation.X && p.X <=
                checkBoxLocation.X + checkBoxSize.Width
            && p.Y >= checkBoxLocation.Y && p.Y <=
                checkBoxLocation.Y + checkBoxSize.Height)
            {
                _checked = !_checked;
                if (OnCheckBoxClicked != null)
                {
                    OnCheckBoxClicked(_checked);
                    this.DataGridView.InvalidateCell(this);
                }

            }
            base.OnMouseClick(e);
        }
    }
    public class DataGridViewDisableCheckBoxColumn : DataGridViewCheckBoxColumn
    {
        public DataGridViewDisableCheckBoxColumn()
        {
            this.CellTemplate = new DataGridViewDisableCheckBoxCell();
        }
    }
    public class DataGridViewDisableCheckBoxCell : DataGridViewCheckBoxCell
    {
        bool enabledValue;
        public bool Enabled
        {
            get
            {
                return enabledValue;
            }
            set
            {
                enabledValue = value;
            }
        }
        // Override the Clone method so that the Enabled property is copied.
        public override object Clone()
        {
            DataGridViewDisableCheckBoxCell cell = (DataGridViewDisableCheckBoxCell)base.Clone();
            cell.Enabled = this.Enabled;
            return cell;
        }
        // By default, enable the CheckBox cell.
        public DataGridViewDisableCheckBoxCell()
        {
            this.enabledValue = true;
        }
        protected override void Paint(Graphics graphics,
        Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
        DataGridViewElementStates elementState, object value,
        object formattedValue, string errorText,
        DataGridViewCellStyle cellStyle,
        DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
        {
            // The checkBox cell is disabled, so paint the border,
            // background, and disabled checkBox for the cell.
            if (!this.enabledValue)
            {
                // Draw the cell background, if specified.
                if ((paintParts & DataGridViewPaintParts.Background) == DataGridViewPaintParts.Background)
                {
                    Brush cellBackground = new SolidBrush(this.Selected ? cellStyle.SelectionBackColor : cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }
                // Draw the cell borders, if specified.
                if ((paintParts & DataGridViewPaintParts.Border) == DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
                }
                CheckState checkState = CheckState.Unchecked;
                if (formattedValue != null)
                {
                    if (formattedValue is CheckState)
                    {
                        checkState = (CheckState)formattedValue;
                    }
                    else if (formattedValue is bool)
                    {
                        if ((bool)formattedValue)
                        {
                            checkState = CheckState.Checked;
                        }
                    }
                }
                CheckBoxState state = checkState == CheckState.Checked ? CheckBoxState.CheckedDisabled : CheckBoxState.UncheckedDisabled;
                // Calculate the area in which to draw the checkBox.
                // force to unchecked!!
                Size size = CheckBoxRenderer.GetGlyphSize(graphics, state);
                Point center = new Point(cellBounds.X, cellBounds.Y);
                center.X += (cellBounds.Width - size.Width) / 2;
                center.Y += (cellBounds.Height - size.Height) / 2;
                // Draw the disabled checkBox.
                // We prevent painting of the checkbox if the Width,
                // plus a little padding, is too small.
                if (size.Width + 4 < cellBounds.Width)
                {
                    CheckBoxRenderer.DrawCheckBox(graphics, center, state);
                }
            }
            else
            {
                // The checkBox cell is enabled, so let the base class
                // handle the painting.
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            }
        }
    }
    #endregion
}
