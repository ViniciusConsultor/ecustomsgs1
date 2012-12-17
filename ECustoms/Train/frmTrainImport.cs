using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.DAL;
using ECustoms.Utilities;
using ECustoms.Utilities.Enums;

namespace ECustoms.Train
{
    public partial class frmTrainImport : Form
    {
        private short _type; //0: xuat canh, 1 nhap canh
        private short _mode; //0: addnew, 1: edit
        private UserInfo _userInfo;
        private List<tblToaTau> listToaTau = new List<tblToaTau>();

        public frmTrainImport()
        {
            InitializeComponent();
        }
        public frmTrainImport(UserInfo userInfo, short type)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _type = type;
        }

        private void frmTrainImport_Load(object sender, EventArgs e)
        {
            this.Text = "Tau hang Trung Quoc" + (_type == 0 ? "xuat canh" : "nhap canh") + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            Init();
        }

        private void Init()
        {
            //init data for Type
            var listType = new List<ComboBoxItem>();
            if (_type == 0)
            {
                listType.Add(new ComboBoxItem((short)TrainType.TypeExportNormal, "Xuất cảnh thông thường"));
                listType.Add(new ComboBoxItem((short)TrainType.TypeExportChange, "Xuất cảnh chuyển cảng"));

                lblHeader.Text = "Khai báo tàu hàng Trung Quốc xuất cảnh";
                lblGaDenDi.Text = "Tên HQ ga đi";
                lblCodeGaDenDi.Text = "Mã HQ ga đi";
            }
            else if (_type == 1)
            {
                listType.Add(new ComboBoxItem((short)TrainType.TypeImportNormal, "Nhập cảnh thông thường"));
                listType.Add(new ComboBoxItem((short)TrainType.TypeImportChange, "Nhập cảnh chuyển cảng"));

                lblHeader.Text = "Khai báo tàu hàng Trung Quốc nhập cảnh";
                lblGaDenDi.Text = "Tên HQ ga đến";
                lblCodeGaDenDi.Text = "Mã HQ ga đến";
            }
            ddlTypeName.Items.AddRange(listType.ToArray());
            ddlTypeName.SelectedIndex = 1;

            //init dropdownlist Type name
            var listTypeName = TypeFactory.getAllType();
            listTypeName.Insert(0, new tblType
            {
                TypeName = "Tên loại hình",
                TypeCode = ""
            });
            ddlTypeExport.DataSource = listTypeName.Select(x => new
            {
                x.TypeName,
                TypeCode = x.TypeCode.Trim()
            }).ToList();
            ddlTypeExport.ValueMember = "TypeCode";
            ddlTypeExport.DisplayMember = "TypeName";
            ddlTypeExport.SelectedIndex = 0;

            //init dropdownlist Customs name
            var listHQ = CustomsFacory.getAll();
            var listCustomsName = new List<tblCustom>();
            listCustomsName.AddRange(listHQ);
            listCustomsName.Insert(0, new tblCustom
            {
                CustomsName = "Tên ĐV Hải quan",
                CustomsCode = ""
            });
            ddlCustomsName.DataSource = listCustomsName.Select(x => new
            {
                x.CustomsName,
                CustomsCode = x.CustomsCode.Trim()
            }).ToList();
            ddlCustomsName.ValueMember = "CustomsCode";
            ddlCustomsName.DisplayMember = "CustomsName";
            ddlCustomsName.SelectedIndex = 0;
            ////init ma cua khau
            var listStation = new List<tblCustom>();
            listStation.AddRange(listHQ);
            listStation.Insert(0, new tblCustom
            {
                CustomsName = "Tên HQ Cửa khẩu",
                CustomsCode = ""
            });
            ddlCuaKhau.DataSource = listStation.Select(x => new
            {
                x.CustomsName,
                CustomsCode = x.CustomsCode.Trim()
            }).ToList();
            ddlCuaKhau.ValueMember = "CustomsCode";
            ddlCuaKhau.DisplayMember = "CustomsName";
            ddlCuaKhau.SelectedIndex = 0;
            //init ma ga den di
            var listGaDenDi = new List<tblCustom>();
            listGaDenDi.AddRange(listHQ);
            listGaDenDi.Insert(0, new tblCustom
            {
                CustomsName = "Tên HQ",
                CustomsCode = ""
            });
            ddlGaDenDi.DataSource = listGaDenDi.Select(x => new
            {
                x.CustomsName,
                CustomsCode = x.CustomsCode.Trim()
            }).ToList();
            ddlGaDenDi.ValueMember = "CustomsCode";
            ddlGaDenDi.DisplayMember = "CustomsName";
            ddlGaDenDi.SelectedIndex = 0;

            //grid Toa tau
            grdToaTau.AutoGenerateColumns = false;

            //mode
            if (_mode == 0)
            {
                btnUpdate.Enabled = btnDelete.Enabled = false;
            }
        }

        private void ddlTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = (short)((ComboBoxItem)ddlTypeName.SelectedItem).Value;
            if (type == (short)TrainType.TypeExportChange || type == (short)TrainType.TypeImportChange)
            {
                pnChangeStation.Visible = true;
                pnNormally.Visible = false;
            }
            else
            {
                pnChangeStation.Visible = false;
                pnNormally.Visible = true;
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
            txtNumberTrain.Text = txtExportNumber.Text = txtTypeExport.Text = txtCustomsCode.Text = txtNumberHandover.Text = txtCodeCuaKhau.Text = txtCodeGaDenDi.Text = txtStatusVehicle.Text = txtStatusGood.Text = string.Empty;
            ddlTypeName.SelectedIndex = 1;
            dtpRegisterDate.Value = dtpDeclaration.Value = DateTime.Now;
            ddlTypeExport.SelectedIndex =
            ddlCustomsName.SelectedIndex = ddlCuaKhau.SelectedIndex = ddlGaDenDi.SelectedIndex = 0;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate()) return;
                var train = new tblTrain();
                train.Number = txtNumberTrain.Text.Trim();
                var type = (short)((ComboBoxItem)ddlTypeName.SelectedItem).Value;
                train.Type = type;
                if (type == (short)TrainType.TypeExportChange || type == (short)TrainType.TypeImportChange)
                {
                    train.NumberHandover = txtNumberHandover.Text.Trim();
                    train.DateHandover = dtpHandover.Value;
                    train.CodeStation = txtCodeCuaKhau.Text.Trim();
                    train.CodeStationFromTo = txtCodeGaDenDi.Text.Trim();
                    train.StatusVehicle = txtStatusVehicle.Text.Trim();
                    train.StatusGoods = txtStatusGood.Text.Trim();
                }

                train.CreatedBy = _userInfo.UserID;
                if (TrainFactory.Insert(train) > 0)
                {
                    //insert tờ khai
                    if (type == (short)TrainType.TypeExportNormal || type == (short)TrainType.TypeImportNormal)
                    {
                        var declare = new tblToKhaiTau()
                                          {
                                              Number = Convert.ToInt32(txtExportNumber.Text.Trim()),
                                              DateDeclaration = dtpDeclaration.Value,
                                              TypeCode = txtTypeExport.Text.Trim(),
                                              CustomCode = txtCustomsCode.Text.Trim(),
                                              CreatedBy = _userInfo.UserID,
                                              TrainID = train.TrainID
                                          };
                        TrainFactory.InsertToKhai(declare);

                    }
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

        private void btnAddToaTau_Click(object sender, EventArgs e)
        {
            var frm = new frmThemToaTau(0, _userInfo, ref listToaTau);
            frm.ShowDialog(this);
        }

        private void txtTypeExport_Leave(object sender, EventArgs e)
        {
            var typeCode = txtTypeExport.Text.Trim();
            var type = TypeFactory.FindByCode(typeCode);
            if (type != null)
            {
                ddlTypeExport.SelectedValue = typeCode;
            }
            else
            {
                ddlTypeExport.SelectedIndex = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTypeExport.Text = ddlTypeExport.SelectedValue.ToString();
        }

        private void txtCustomsCode_Leave(object sender, EventArgs e)
        {
            var customs = CustomsFacory.FindByCode(txtCustomsCode.Text.Trim());
            if (customs != null)
            {
                ddlCustomsName.SelectedValue = customs.CustomsCode.Trim();
            }
            else
            {
                ddlCustomsName.SelectedIndex = 0;
            }
        }

        private void ddlCustomsName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCustomsCode.Text = ddlCustomsName.SelectedValue.ToString();
        }

        private void txtCodeCuaKhau_Leave(object sender, EventArgs e)
        {
            var customs = CustomsFacory.FindByCode(txtCodeCuaKhau.Text.Trim());
            if (customs != null)
            {
                ddlCuaKhau.SelectedValue = customs.CustomsCode.Trim();
            }
            else
            {
                ddlCuaKhau.SelectedIndex = 0;
            }
        }

        private void ddlCuaKhau_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodeCuaKhau.Text = ddlCuaKhau.SelectedValue.ToString();
        }

        private void txtCodeGaDenDi_Leave(object sender, EventArgs e)
        {
            var customs = CustomsFacory.FindByCode(txtCodeGaDenDi.Text.Trim());
            if (customs != null)
            {
                ddlGaDenDi.SelectedValue = customs.CustomsCode.Trim();
            }
            else
            {
                ddlGaDenDi.SelectedIndex = 0;
            }
        }

        private void ddlGaDenDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodeGaDenDi.Text = ddlGaDenDi.SelectedValue.ToString();
        }

        public void BindToaTau()
        {
            grdToaTau.DataSource = null;
            // Bind count column
            grdToaTau.AutoGenerateColumns = true;
            grdToaTau.DataSource = listToaTau;
        }
    }
}
