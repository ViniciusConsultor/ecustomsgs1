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
using ECustoms.Utilities;
using ECustoms.Utilities.Enums;

namespace ECustoms.Train
{
    public partial class frmTrainPassengers : Form
    {
        private UserInfo _userInfo;
        private short _mode; //0: addnew, 1: edit

        public frmTrainPassengers()
        {
            InitializeComponent();
        }
        public frmTrainPassengers(UserInfo userInfo)
        {
            InitializeComponent();
            _userInfo = userInfo;
        }

        private void frmTrainPassengers_Load(object sender, EventArgs e)
        {
            this.Text = "Khai bao tau khach XNK" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            Init();
        }

        private void Init()
        {
            //init data for Type
            var listType = new List<ComboBoxItem>
                               {
                                   new ComboBoxItem((short)TrainType.TypeExport, "Xuất cảnh"),
                                   new ComboBoxItem((short)TrainType.TypeImport, "Nhập cảnh")
                               };
            ddlTypeName.Items.AddRange(listType.ToArray());
            ddlTypeName.SelectedIndex = 0;

            //mode
            if (_mode == 0)
            {
                btnUpdate.Enabled = btnDelete.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Validate()
        {
            return techlinkErrorProvider1.Validate(this);
        }

        private void Reset()
        {
            txtNumberTrain.Text = txtJourney.Text = txtNumberPersonVN.Text = txtNumberPersonForegin.Text = txtNumberStaff.Text = string.Empty;
            ddlTypeName.SelectedIndex = 0;
            dtpRegisterDate.Value = DateTime.Now;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate()) return;
                var trainPassenger = new tblTrain();
                trainPassenger.Number = txtNumberTrain.Text.Trim();
                trainPassenger.Type = (short) ((ComboBoxItem) ddlTypeName.SelectedItem).Value;
                if (trainPassenger.Type == (short) TrainType.TypeExport)
                {
                    trainPassenger.IsExport = true;
                    trainPassenger.DateExport = dtpRegisterDate.Value;
                }
                else if (trainPassenger.Type == (short)TrainType.TypeImport)
                {
                    trainPassenger.IsImport = true;
                    trainPassenger.DateImport = dtpRegisterDate.Value;     
                }
                trainPassenger.Jounery = txtJourney.Text.Trim();
                trainPassenger.PassengerVN = int.Parse(txtNumberPersonVN.Text);
                trainPassenger.PassengerForegin = int.Parse(txtNumberPersonForegin.Text);
                trainPassenger.Staff = int.Parse(txtNumberStaff.Text);

                trainPassenger.CreatedBy = _userInfo.UserID;
                if (TrainFactory.Insert(trainPassenger) > 0)
                {
                    MessageBox.Show("Thêm mới thành công!");
                    Reset();
                }
                else MessageBox.Show("Thêm mới không thành công!");
            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }
    }
}
