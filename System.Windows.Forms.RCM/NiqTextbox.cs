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
    public partial class NiqTextbox : Panel, INiqInputControl
    {
        private Color _borderFirst = NiqColorTable.Input_Border1;
        private Color _borderSecond = NiqColorTable.TransparentColor;
        private Color _colorFillFirst = Color.White;
        private Color _colorFillSecond = Color.White;

        private object _dataSource;
        private InputTypes _inputType = InputTypes.Text;
        private string _textField;
        private string _valueField;
        private object _inputValue;

        private TextBox txtInput = new TextBox();
        private Timer timer = new Timer();
        private int tick = 0;

        public NiqTextbox()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.EnableNotifyMessage, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserMouse, true);

            InitializeComponent();
            InitializeComponentExtend();

            txtInput.KeyDown += new KeyEventHandler(txtInput_KeyDown);
            txtInput.LostFocus += new EventHandler(txtInput_LostFocus);
            //this.GotFocus += new EventHandler(NiqTextbox_GotFocus);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 300;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
            Color border = BorderFirst;
            Color first = ColorFillFirst;
            Color second = ColorFillSecond;

            if (tick % 2==0)
            {
                border = NiqColorTable.StandardColor_Yellow;
                first = NiqColorTable.StandardColor_Yellow;
                second = NiqColorTable.StandardColor_Yellow;
            }

            tick++;

            if(tick==6)
            {
                tick = 0;
                timer.Stop();
            }

            txtInput.BackColor = first;
            DrawHelper.DrawDoubleBorder(this.CreateGraphics(), r, border,
                                       BorderSecond, first, second, 2, true);
        }

        private void InitializeComponentExtend()
        {
            this.Padding = new Padding(2);

            txtInput.BorderStyle = BorderStyle.None;
            txtInput.Font = this.Font;
            txtInput.Padding = new Padding(2);

            this.Controls.Clear();
            this.Controls.Add(txtInput);

            if (!txtInput.Multiline)
            {
                if (txtInput.Height > this.Height - this.Padding.Top - this.Padding.Bottom)
                {
                    this.Height = txtInput.Height + this.Padding.Top + this.Padding.Bottom;
                }

                txtInput.Top = (this.Height - txtInput.Height - this.Padding.Bottom - this.Padding.Top) / 2 + 1;
                txtInput.Left = 4;
                txtInput.Width = this.Width - 8;
            }


        }

        void txtInput_LostFocus(object sender, EventArgs e)
        {
            if (InputType == InputTypes.LicenceNumber)
            {
                this.txtInput.Text = this.txtInput.Text.ToLicenceNumber().ToUpper();
            }

            OnLostFocus(e);
        }

        void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);

            if (e.KeyCode == Keys.Enter && OnEnterMoveNextControl && !e.Handled)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        [Category("Niq Prop")]
        public string InputText
        {
            get
            {
                return txtInput.Text;
            }
            set
            {
                txtInput.Text = value;
            }
        }
        [Category("Niq Prop")]
        public object InputValue
        {
            get { return _inputValue; }
            set { _inputValue = value; }
        }
        [Category("Niq Prop")]
        public bool MultipleLines
        {
            get { return txtInput.Multiline; }
            set
            {
                txtInput.Multiline = value;
                InitializeComponentExtend();
            }
        }
        [Category("Niq Prop")]
        public bool ReadOnly { get { return txtInput.ReadOnly; } set { txtInput.ReadOnly = value; } }
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
            set { _dataSource = value; }
        }
        [Category("Niq Prop")]
        public string TextField
        {
            get { return _textField; }
            set { _textField = value; }
        }
        [Category("Niq Prop")]
        public string ValueField
        {
            get { return _valueField; }
            set { _valueField = value; }
        }
        [Category("Niq Prop")]
        public string Text { get { return txtInput.Text; } set { txtInput.Text = value; } }
        [Category("Niq Prop")]
        public bool OnEnterMoveNextControl { get; set; }
        [Category("Niq Prop")]
        public Font Font
        {
            get { return txtInput.Font; }
            set { txtInput.Font = value; }
        }


        [Category("Niq Prop")]
        public Color BorderFirst
        {
            get { return _borderFirst; }
            set { _borderFirst = value; }
        }


        [Category("Niq Prop")]
        public Color BorderSecond
        {
            get { return _borderSecond; }
            set { _borderSecond = value; }
        }


        [Category("Niq Prop")]
        public Color ColorFillFirst
        {
            get { return _colorFillFirst; }
            set { _colorFillFirst = value; }
        }



        [Category("Niq Prop")]
        public Color ColorFillSecond
        {
            get { return _colorFillSecond; }
            set { _colorFillSecond = value; }
        }

        public bool IsNullOrEmpty()
        {
            return string.IsNullOrEmpty(txtInput.Text) || (txtInput.Text.Trim().Length == 0);
        }

        public void ShowWarning()
        {
            this.timer.Start();
        }

        public void DataBind()
        {
            //throw new NotImplementedException();
            this.txtInput.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.txtInput.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var data = DatasourceUtils.GetInnerDataSource(_dataSource, ValueField);

            List<string> lstString = new List<string>();

            foreach (var item in data)
            {
                if (item is IObjectData)
                {
                    lstString.Add((item as IObjectData).ToName());
                }
            }
            this.txtInput.AutoCompleteCustomSource.Clear();
            this.txtInput.AutoCompleteCustomSource.AddRange(lstString.ToArray());
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle r = new Rectangle(0, 0, this.Width, this.Height);

            DrawHelper.DrawDoubleBorder(e.Graphics, r, BorderFirst,
                                        BorderSecond, ColorFillFirst, ColorFillSecond, 2, true);
            //base.OnPaint(e);
            //InitializeComponentExtend();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            InitializeComponentExtend();
            this.Invalidate();
            //base.OnSizeChanged(e);
        }

        public void SetFocus()
        {
            this.txtInput.Focus();
            txtInput.SelectionStart = 0;
            txtInput.SelectionLength = txtInput.Text.Length;
            txtInput.Select();
        }

        public void Clear()
        {
            txtInput.Clear();
        }
    }
}
