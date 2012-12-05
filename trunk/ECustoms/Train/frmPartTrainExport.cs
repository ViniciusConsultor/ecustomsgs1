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
    public partial class frmPartTrainExport : Form
    {
        private UserInfo _userInfo;
        private short _mode; //0: addnew, 1: edit

        public frmPartTrainExport()
        {
            InitializeComponent();
        }

        public frmPartTrainExport(UserInfo userInfo)
        {
            InitializeComponent();
            _userInfo = userInfo;
        }

        private void frmPartTrainExport_Load(object sender, EventArgs e)
        {
            this.Text = "Khai bao toa tau xuat" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
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
            txtNumberTrain.Text = txtNumberPartofTrain.Text = string.Empty;
            ddlTypeName.SelectedIndex = 0;
            dtpRegisterDate.Value = DateTime.Now;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate()) return;
                var train = new tblTrain();
                train.Number = txtNumberTrain.Text.Trim();
                train.Type = (short)((ComboBoxItem)ddlTypeName.SelectedItem).Value;
                if (train.Type == (short)TrainType.TypeExport)
                {
                    train.IsExport = true;
                    train.DateExport = dtpRegisterDate.Value;
                }
                else if (train.Type == (short)TrainType.TypeImport)
                {
                    train.IsImport = true;
                    train.DateImport = dtpRegisterDate.Value;
                }
                train.NumberPartTrain = txtNumberPartofTrain.Text.Trim();

                train.CreatedBy = _userInfo.UserID;
                if (TrainFactory.Insert(train) > 0)
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
