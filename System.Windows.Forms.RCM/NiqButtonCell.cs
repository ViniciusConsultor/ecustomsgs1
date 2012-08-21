using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Niq.Msd.Common;

namespace Niq.Msd.Layout
{
    public delegate void OnIconButtonClickHandler(object sender, object dataButton);

    public class NiqButtonCell : NiqLabel
    {
        private Color _borderColor1 = NiqColorTable.Input_Border1;
        private Color _borderColor2 = NiqColorTable.TransparentColor;
        private Color _colorFill1 = NiqColorTable.StandardColor_Gray1;
        private Color _colorFill2 = NiqColorTable.StandardColor_Gray2;
        private bool mouseIsEntered = false;

        [Category("Niq Event")]
        public event OnIconButtonClickHandler OnIconButtonClick;

        public NiqButtonCell()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.EnableNotifyMessage, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserMouse, true);

            //this.AutoSize = false;
            this.BackColor = Color.Transparent;
            this.Padding = new Padding(5, 5, 2, 5);
            this.ImageAlign = ContentAlignment.MiddleRight;
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.Image = System.Windows.Forms.RCM.Properties.Resources.bullet_delete;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            if (mouseIsEntered)
            {
                DrawHelper.DrawDoubleBorder(pevent.Graphics, rect, BorderColor1, BorderColor2, ColorFill2, ColorFill1, 3,
                                        true);
            }
            else
            {
                DrawHelper.DrawDoubleBorder(pevent.Graphics, rect, BorderColor1, BorderColor2, ColorFill1, ColorFill2, 3,
                                            true);    
            }
            
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (IconRect.Contains(e.Location))
            {
                if (OnIconButtonClick != null)
                {
                    OnIconButtonClick.Invoke(this, Data);
                }

                return;
            }

            base.OnMouseClick(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {

            //base.OnMouseMove(e);
            if (IconRect.Contains(e.Location))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            //base.OnMouseEnter(e);
            mouseIsEntered = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            //base.OnMouseLeave(e);
            mouseIsEntered = false;
            this.Invalidate();
        }

        private Rectangle IconRect
        {
            get
            {
                Rectangle rect = new Rectangle(this.Width - 16, 0, 16, this.Height);
                return rect;
            }
        }

        [Category("Niq Prop")]
        public Color BorderColor1
        {
            get { return _borderColor1; }
            set { _borderColor1 = value; }
        }

        [Category("Niq Prop")]
        public Color BorderColor2
        {
            get { return _borderColor2; }
            set { _borderColor2 = value; }
        }

        [Category("Niq Prop")]
        public Color ColorFill1
        {
            get { return _colorFill1; }
            set { _colorFill1 = value; }
        }

        [Category("Niq Prop")]
        public Color ColorFill2
        {
            get { return _colorFill2; }
            set { _colorFill2 = value; }
        }

        [Category("Niq Prop")]
        public object Data { get; set; }

        [Category("Niq Prop")]
        public string Value { get; set; }

    }
}
