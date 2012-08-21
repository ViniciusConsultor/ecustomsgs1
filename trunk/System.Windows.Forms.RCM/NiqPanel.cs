using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Niq.Msd.Common;

namespace Niq.Msd.Layout
{
    public partial class NiqPanel : Panel
    {
        public NiqPanel()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.EnableNotifyMessage, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserMouse, true);

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            DrawBackGround(e.Graphics, rect);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Invalidate();
        }

        private void DrawBackGround(Graphics graphics, Rectangle rect)
        {
            DrawHelper.DrawDoubleBorder(graphics, rect, BorderColor,
                                            NiqColorTable.Group_BackGround,
                                            NiqColorTable.Group_BackGround, NiqColorTable.Group_BackGround, 2,
                                            true);
        }

        public NiqPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private Color _borderColor = NiqColorTable.Input_Border1;
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }
    }
}
