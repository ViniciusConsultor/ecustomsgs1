using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Niq.Msd.Layout;
using Niq.Msd.Test;

namespace TechLink.TestControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<LicenceNumber> lst = new List<LicenceNumber>();
            LicenceNumber n1 = new LicenceNumber("16H-9309", "16H-9309");
            LicenceNumber n2 = new LicenceNumber("18H-7722", "18H-7722");
            LicenceNumber n3 = new LicenceNumber("12M-0016", "12M-0016");
            LicenceNumber n4 = new LicenceNumber("88K-4544", "88K-4544");
            LicenceNumber n5 = new LicenceNumber("16H-9009", "16H-9009");
            LicenceNumber n6 = new LicenceNumber("16H-9679", "16H-9679");
            LicenceNumber n7 = new LicenceNumber("11H-1111", "11H-1111");
            LicenceNumber n8 = new LicenceNumber("18H-1118", "18H-1118");
            LicenceNumber n9 = new LicenceNumber("18H-1221", "18H-1221");

            lst.AddRange(new LicenceNumber[] { n1, n2, n3, n4, n5, n6, n7, n8, n9 });
            niqInputGroup1.DataSource = lst;
            niqInputGroup1.SelectedItems.AddRange(new object[] { n1, n2, n3 });
            niqInputGroup1.TextField = "Text";
            niqInputGroup1.ValueField = "Value";
            niqInputGroup1.BindData();
            niqInputGroup1.IsValidTextInput = true;

            niqInputGroup1.OnItemRemoveClick += new OnItemRemoveClickHandler(niqInputGroup1_OnItemRemoveClick);
            niqInputGroup1.OnValidDataInput += new OnValidDataInputHandler(niqInputGroup1_OnValidDataInput);
        }

        private void niqInputGroup1_OnValidDataInput(object sender, object datavalidate)
        {

        }

        private void niqInputGroup1_OnItemRemoveClick(object sender, object selecteditem)
        {
            LicenceNumber licenceNumber = selecteditem as LicenceNumber;
            MessageBox.Show("Selected Item is: " + licenceNumber.Text);
            niqInputGroup1.RemoveAt(licenceNumber.Value);
        }
    }
}
