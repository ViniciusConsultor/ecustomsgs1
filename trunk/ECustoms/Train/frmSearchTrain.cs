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
using ECustoms.Utilities.Enums;

namespace ECustoms.Train
{
    public partial class frmSearchTrain : Form
    {
        public frmSearchTrain()
        {
            InitializeComponent();
        }

        private void frmSearchTrain_Load(object sender, EventArgs e)
        {
            this.Text = "Quan ly Tau hang Trung Quoc XNK" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            Init();
        }

        private void Init()
        {
            //init data for Type
            var listType = new List<ComboBoxItem>();
            listType.Add(new ComboBoxItem(-1, "Tất cả"));
            listType.Add(new ComboBoxItem((short)TrainType.TypeExportNormal, "Xuất cảnh thông thường"));
            listType.Add(new ComboBoxItem((short)TrainType.TypeExportChange, "Xuất cảnh chuyển cảng"));
            listType.Add(new ComboBoxItem((short)TrainType.TypeImportNormal, "Nhập cảnh thông thường"));
            listType.Add(new ComboBoxItem((short)TrainType.TypeImportChange, "Nhập cảnh chuyển cảng"));

            ddlTypeName.Items.AddRange(listType.ToArray());
            ddlTypeName.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var listTrain = TrainFactory.SearchTrain(txtNumberTrain.Text.Trim(),
                                                             Convert.ToInt32(((ComboBoxItem)ddlTypeName.SelectedItem).Value),
                                                             dtpDateXNC.Value);
                grdTrain.AutoGenerateColumns = false;
                grdTrain.DataSource = listTrain;


                for (var i = 0; i < grdTrain.Rows.Count; i++)
                {
                    // Add to count Column
                    grdTrain.Rows[i].Cells[0].Value = (i + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }
    }
}
