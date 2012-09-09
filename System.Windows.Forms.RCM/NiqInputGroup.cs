using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Niq.Msd.Base;
using Niq.Msd.Common;

namespace Niq.Msd.Layout
{
    public class InputData
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public delegate void OnItemRemoveClickHandler(object sender, object selectedItem);
    public delegate void OnBeforeCompleteInputHandler(object sender, ref string text);

    public delegate void OnValidDataInputHandler(object sender, object dataValidate);

    public partial class NiqInputGroup : NiqPanel
    {
        private List<object> _selectedItems = new List<object>();
        private List<object> _datasourceItems = new List<object>();
        private object _dataSource = null;
        private Color _buttonCellBorderColor = NiqColorTable.Input_Border1;
        private InputTypes _inputType = InputTypes.Text;
        private NiqTextbox txtInputData = new NiqTextbox();

        [Category("Niq Event")]
        public OnItemRemoveClickHandler OnItemRemoveClick;
        [Category("Niq Event")]
        public OnBeforeCompleteInputHandler OnBeforeCompleteInput;
        [Category("Niq Event")]
        public OnValidDataInputHandler OnValidDataInput;

        public NiqInputGroup()
        {
            InitializeComponent();
        }

        void txtInput_LostFocus(object sender, EventArgs e)
        {
            if (AutoUpperCase)
                txtInputData.Text = txtInputData.Text.Trim().ToUpper();

            if (OnBeforeCompleteInput != null)
            {
                string txt = txtInputData.Text;
                OnBeforeCompleteInput.Invoke(this, ref txt);

                txtInputData.Text = txt;
            }

            if (IsValidTextInput)
            {
                if (txtInputData.IsNullOrEmpty()) return;

                var check =
                    _datasourceItems.FirstOrDefault(
                        item => (item as IObjectData).ToName().ToUpper().Equals(txtInputData.Text.ToUpper()));
                if (check != null)
                {
                    this.SelectedItems.Add(check);
                    this.Controls.RemoveAt(this.Controls.Count - 1);
                    this.BindData();
                    txtInputData.Clear();
                }
                else
                {
                    this.txtInputData.SetFocus();
                    this.txtInputData.ShowWarning();

                    if (OnValidDataInput != null)
                    {
                        OnValidDataInput.Invoke(this, txtInputData.Text);
                    }
                }
            }
        }

        void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Focus();
                txtInputData.SetFocus();
            }
        }

        public NiqInputGroup(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [Category("Niq Prop")]
        public List<object> SelectedItems
        {
            get { return _selectedItems; }
            set { _selectedItems = value; }
        }
        [Category("Niq Prop")]
        public InputTypes InputType
        {
            get { return _inputType; }
            set { _inputType = value; }
        }

        [Category("Niq Prop")]
        public object DataSource
        {
            get { return _dataSource; }
            set
            {
                _dataSource = value;
                if (_dataSource != null)
                {
                    var data = DatasourceUtils.GetInnerDataSource(_dataSource, ValueField);
                    _datasourceItems.Clear();
                    _datasourceItems.AddRange(data.Cast<object>().ToArray());
                }
            }
        }

        [Category("Niq Prop")]
        public string TextField { get; set; }

        [Category("Niq Prop")]
        public string ValueField { get; set; }

        [Category("Niq Prop")]
        public bool AutoUpperCase { get; set; }

        [Category("Niq Prop")]
        public bool IsValidTextInput { get; set; }

        [Category("Niq Prop")]
        public Color ButtonCellBorderColor
        {
            get { return _buttonCellBorderColor; }
            set { _buttonCellBorderColor = value; }
        }

        /// <summary>
        /// Present data from selected items to UI
        /// </summary>
        public void BindData()
        {
            this.Controls.Clear();


            if (SelectedItems.Count() > 0)
            {
                foreach (var item in SelectedItems)
                {
                    NiqButtonCell buttonCell = new NiqButtonCell();
                    buttonCell.Data = item;
                    buttonCell.Text = DatasourceUtils.GetValueOfProperty(item, TextField).ToString();
                    buttonCell.Value = DatasourceUtils.GetValueOfProperty(item, ValueField).ToString();
                    buttonCell.AutoSize = false;
                    buttonCell.Width = DrawHelper.MeasureString(this.CreateGraphics(), this.Font, buttonCell.Text).Width + 20;
                    buttonCell.Top = 2;
                    buttonCell.Left = 2;
                    buttonCell.Font = this.Font;
                    buttonCell.OnIconButtonClick += new OnIconButtonClickHandler(buttonCell_OnIconButtonClick);
                    buttonCell.BorderColor1 = _buttonCellBorderColor;
                    if (this.Controls.Count > 0)
                    {
                        var prevControl = this.Controls[this.Controls.Count - 1];
                        buttonCell.Top = prevControl.Top;
                        buttonCell.Left = prevControl.Left + prevControl.Width + 4;

                        if (buttonCell.Left + buttonCell.Width > this.Width)
                        {
                            buttonCell.Top += buttonCell.Height + 2;
                            buttonCell.Left = 2;
                        }
                    }
                    this.Controls.Add(buttonCell);
                }

                var prevControl1 = this.Controls[this.Controls.Count - 1];
                txtInputData.Left = prevControl1.Left + prevControl1.Width + 4;
                txtInputData.Top = prevControl1.Top;
                txtInputData.Width = 120;
                txtInputData.Height = 25;
                txtInputData.Font = this.Font;
                
                if (txtInputData.Left + txtInputData.Width > this.Width)
                {
                    txtInputData.Top = prevControl1.Top + prevControl1.Height + 2;
                    txtInputData.Left = 2;
                }

                this.Controls.Add(txtInputData);
            }
            else
            {
                txtInputData.Left = 2;
                txtInputData.Top = 2;
                txtInputData.Width = 120;
                txtInputData.Height = 25;
                txtInputData.Font = this.Font;

                this.Controls.Add(txtInputData);
            }

            txtInputData.InputType = this.InputType;
            //txtInputData.OnEnterMoveNextControl = true;
            txtInputData.KeyDown += new KeyEventHandler(txtInput_KeyDown);
            txtInputData.LostFocus += new EventHandler(txtInput_LostFocus);

            List<object> txtDatasource = DatasourceUtils.CloneObject<List<object>>(_datasourceItems);
            foreach (var selectedItem in SelectedItems)
            {
                //var _text = DatasourceUtils.GetValueOfProperty(selectedItem, TextField).ToString();
                var _value = DatasourceUtils.GetValueOfProperty(selectedItem, ValueField).ToString();

                //var removeItem = txtDatasource.FirstOrDefault(p => (p as IObjectData).ToName().Equals(_value));
                //Replace by CuongTd
                var removeItem = txtDatasource.FirstOrDefault(p => DatasourceUtils.GetValueOfProperty(p, ValueField).ToString().Equals(_value));
                txtDatasource.Remove(removeItem);
            }

            txtInputData.DataSource = txtDatasource;
            txtInputData.ValueField = ValueField;
            txtInputData.TextField = TextField;
            txtInputData.DataBind();

            if (txtInputData.Top + txtInputData.Height + 4 > this.Height)
            {
                this.Height = txtInputData.Top + txtInputData.Height + 4;
            }
        }

        public bool Remove(object item)
        {
            bool result = SelectedItems.Remove(item);
            if (result)
            {
                BindData();
            }
            return result;
        }

        public bool RemoveAt(string valueOfObject)
        {
            //var removeItem = from item in SelectedItems
            //                 where DatasourceUtils.GetValueOfProperty(item, ValueField).ToString().Equals(valueOfObject)
            //                 select item;
            bool removed = false;
            var removeOne =
                SelectedItems.FirstOrDefault(
                    item => DatasourceUtils.GetValueOfProperty(item, ValueField).ToString().Equals(valueOfObject));

            if (removeOne != null)
            {
                removed = SelectedItems.Remove(removeOne);
                BindData();
            }
            return removed;
        }

        void buttonCell_OnIconButtonClick(object sender, object dataButton)
        {
            if (OnItemRemoveClick != null)
                OnItemRemoveClick.Invoke(this, dataButton);
        }


    }
}
