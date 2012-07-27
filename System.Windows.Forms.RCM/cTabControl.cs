namespace System.Windows.Forms.RCM
{
    #region Directives
    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Diagnostics;
    using System.Text;
    using System.Reflection;
    using System.Drawing.Drawing2D;
    #endregion

    #region Enums
    public enum TabRenderStyle
    {
        Custom,
        Graphic
    }
    #endregion

    public class cTabControl : NativeWindow, IDisposable
    {
        #region Constants
        // alphablend
        private const byte AC_SRC_OVER = 0x00;
        private const byte AC_SRC_ALPHA = 0x01;
        // window messages
        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_MOUSELEAVE = 0x2A3;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_MOUSEHOVER = 0x2A1;
        private const int WM_PAINT = 0xF;
        // tab messages
        private const int TCIF_STATE = 0x0010;
        private const int TCM_FIRST = 0x1300;
        private const int TCM_GETIMAGELIST = (TCM_FIRST + 2);
        private const int TCM_SETIMAGELIST = (TCM_FIRST + 3);
        private const int TCM_GETITEMCOUNT = (TCM_FIRST + 4);
        private const int TCM_GETITEMA = (TCM_FIRST + 5);
        private const int TCM_GETITEMW = (TCM_FIRST + 60);
        private const int TCM_SETITEMA = (TCM_FIRST + 6);
        private const int TCM_SETITEMW = (TCM_FIRST + 61);
        private const int TCM_INSERTITEMA = (TCM_FIRST + 7);
        private const int TCM_INSERTITEMW = (TCM_FIRST + 62);
        private const int TCM_DELETEITEM = (TCM_FIRST + 8);
        private const int TCM_DELETEALLITEMS = (TCM_FIRST + 9);
        private const int TCM_GETITEMRECT = (TCM_FIRST + 10);
        private const int TCN_FIRST = 550;
        private const int TCN_LAST = 580;
        private const int TCN_KEYDOWN = (TCN_FIRST - 0);
        private const int TCN_SELCHANGE = (TCN_FIRST - 1);
        private const int TCN_SELCHANGING = (TCN_FIRST - 2);
        private const int TCN_GETOBJECT = (TCN_FIRST - 3);
        private const int TCIS_BUTTONPRESSED = 0x0001;
        private const int TCIS_HIGHLIGHTED = 0x0002;
        #endregion

        #region Structs
        [StructLayout(LayoutKind.Sequential)]
        private struct PAINTSTRUCT
        {
            internal IntPtr hdc;
            internal int fErase;
            internal RECT rcPaint;
            internal int fRestore;
            internal int fIncUpdate;
            internal int Reserved1;
            internal int Reserved2;
            internal int Reserved3;
            internal int Reserved4;
            internal int Reserved5;
            internal int Reserved6;
            internal int Reserved7;
            internal int Reserved8;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            internal RECT(int X, int Y, int Width, int Height)
            {
                this.Left = X;
                this.Top = Y;
                this.Right = Width;
                this.Bottom = Height;
            }
            internal int Left;
            internal int Top;
            internal int Right;
            internal int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct BLENDFUNCTION
        {
            byte BlendOp;
            byte BlendFlags;
            byte SourceConstantAlpha;
            byte AlphaFormat;

            internal BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
            {
                BlendOp = op;
                BlendFlags = flags;
                SourceConstantAlpha = alpha;
                AlphaFormat = format;
            }
        }
        #endregion

        #region API
        [DllImport("user32.dll")]
        private static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("user32.dll")]
        private static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, ref RECT lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool PtInRect([In] ref RECT lprc, Point pt);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        private extern static int OffsetRect(ref RECT lpRect, int x, int y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetClientRect(IntPtr hWnd, ref RECT r);

        [DllImport("gdi32.dll", EntryPoint = "GdiAlphaBlend")]
        private static extern bool AlphaBlend(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest,
        IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, BLENDFUNCTION blendFunction);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool StretchBlt(IntPtr hDest, int X, int Y, int nWidth, int nHeight, IntPtr hdcSrc,
        int sX, int sY, int nWidthSrc, int nHeightSrc, int dwRop);

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

        [DllImport("user32.dll")]
        private static extern bool ValidateRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        [DllImport("user32.dll")]
        private extern static int InflateRect(ref RECT lpRect, int x, int y);
        #endregion

        #region Fields
        // tab
        private bool _bPainting = false;
        private IntPtr _tabControlWnd = IntPtr.Zero;
        private Bitmap _tabHeaderBitmap;
        private Color _tabBorderColor = Color.DarkGray;
        private Color _tabGradientBegin = Color.White;
        private Color _tabGradientEnd = Color.Silver;
        private Color _tabForeColor = Color.Black;
        private Color _tabFocusedColor = Color.CornflowerBlue;
        private Color _tabFocusedForeColor = Color.White;
        private Color _tabSelectedColor = Color.White;
        private Color _tabSelectedForeColor = Color.Black;
        private Blend _tabStripGradientBlend = new Blend();
        private TabRenderStyle _tabRenderStyle = TabRenderStyle.Custom;
        // tooltip
        private bool _toolTipShown = false;
        private bool _toolTipEnable = false;
        private bool _toolTipUseIcon = false;
        private bool _toolTipRightToLeft = false;
        private int _toolTipMaximumLength = 200;
        private int _toolTipDelayTime = 1000;
        private int _toolTipVisibleTime = 2000;
        private Color _toolTipGradientBegin = Color.White;
        private Color _toolTipGradientEnd = Color.Black;
        private Color _toolTipForeColor = Color.Black;
        private TabPage _lastFocusedPage;
        private ToolTip _toolTip;
        private Dictionary<TabPage, string> _toolTipText = new Dictionary<TabPage, string>();
        private Dictionary<TabPage, string> _toolTipTitle = new Dictionary<TabPage, string>();
        #endregion

        #region Constructor
        public cTabControl(IntPtr hWnd, Bitmap skin)
        {
            if (hWnd == IntPtr.Zero)
                throw new Exception("The tab control handle is invalid.");
            if (skin == null)
                throw new Exception("The image provided is invalid.");
            TabHeaderGraphic = skin;
            Init();
            _tabControlWnd = hWnd;
            this.AssignHandle(hWnd);
        }

        public cTabControl(IntPtr hWnd)
        {
            if (hWnd == IntPtr.Zero)
                throw new Exception("The tab control handle is invalid.");
            Init();
            _tabControlWnd = hWnd;
            this.AssignHandle(hWnd);
        }

        private void Init()
        {
            this.TabDrawingStyle = TabRenderStyle.Graphic;
            this.TabFocusedForeColor = Color.Black;
            this.TabForeColor = Color.Black;
            this.TabSelectedForeColor = Color.Black;
            //this.TabHeaderGraphic = Properties.Resources.tab4;

            //_tabStripGradientBlend.Positions = new float[] { 0f, .3f, .4f, .9f, 1f };
            //_tabStripGradientBlend.Factors = new float[] { 0f, .2f, .5f, 1f, .6f };
        }
        #endregion

        #region ToolTip Events
        private void tab_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control.GetType() == typeof(TabPage))
            {
                TabPage item = (TabPage)e.Control;
                if (ToolTipEnable == true && !String.IsNullOrEmpty(item.ToolTipText))
                {
                    _toolTipText.Add(item, item.ToolTipText);
                    item.ToolTipText = "";
                }
            }
        }

        private void tab_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control.GetType() == typeof(TabPage))
            {
                if (_toolTipText.ContainsKey((TabPage)e.Control))
                    _toolTipText.Remove((TabPage)e.Control);
                if (_toolTipTitle.ContainsKey((TabPage)e.Control))
                    _toolTipTitle.Remove((TabPage)e.Control);
            }
        }

        private void tab_HandleCreated(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TabControl))
            {
                TabControl tab = (TabControl)sender;
                _tabControlWnd = tab.Handle;
            }
        }

        private void tab_HandleDestroyed(object sender, EventArgs e)
        {
            if (_toolTip != null)
                _toolTip.Dispose();
        }

        private void tab_MouseDown(object sender, MouseEventArgs e)
        {
            toolTipStop();
        }

        private void tab_MouseLeave(object sender, EventArgs e)
        {
            toolTipStop();
        }

        private void tab_MouseMove(object sender, MouseEventArgs e)
        {
            TabPage item = overPage();
            if (item != null)
                toolTipStart(item);
        }
        #endregion

        #region Properties
        #region Tab Control
        /// <summary>
        /// Get/Set the tab border color.
        /// </summary>
        public Color TabBorderColor
        {
            get { return _tabBorderColor; }
            set { _tabBorderColor = value; }
        }

        /// <summary>
        /// Get/Set the drawing render style.
        /// </summary>
        public TabRenderStyle TabDrawingStyle
        {
            get { return _tabRenderStyle; }
            set { _tabRenderStyle = value; }
        }

        /// <summary>
        /// Get/Set the ForeColor.
        /// </summary>
        public Color TabForeColor
        {
            get { return _tabForeColor; }
            set { _tabForeColor = value; }
        }

        /// <summary>
        /// Get/Set the focused ForeColor.
        /// </summary>
        public Color TabFocusedForeColor
        {
            get { return _tabFocusedForeColor; }
            set { _tabFocusedForeColor = value; }
        }

        /// <summary>
        /// Get/Set the tab focused Color.
        /// </summary>
        public Color TabFocusedColor
        {
            get { return _tabFocusedColor; }
            set { _tabFocusedColor = value; }
        }

        /// <summary>
        /// Get/Set the starting color of the button fade gradient.
        /// </summary>
        public Color TabGradientBegin
        {
            get { return _tabGradientBegin; }
            set { _tabGradientBegin = value; }
        }

        /// <summary>
        /// Get/Set the ending color of the button fade gradient.
        /// </summary>
        public Color TabGradientEnd
        {
            get { return _tabGradientEnd; }
            set { _tabGradientEnd = value; }
        }

        /// <summary>
        /// Get/Set the blend factor of the gradient.
        /// </summary>
        public Blend TabGradientBlend
        {
            get { return _tabStripGradientBlend; }
            set { _tabStripGradientBlend = value; }
        }

        /// <summary>
        /// Get/Set the bitmap used for the tab header.
        /// </summary>
        public Bitmap TabHeaderGraphic
        {
            get { return _tabHeaderBitmap; }
            set { _tabHeaderBitmap = value; }
        }

        /// <summary>
        /// Get/Set the tab selected Color.
        /// </summary>
        public Color TabSelectedColor
        {
            get { return _tabSelectedColor; }
            set { _tabSelectedColor = value; }
        }

        /// <summary>
        /// Get/Set the tab selected Color.
        /// </summary>
        public Color TabSelectedForeColor
        {
            get { return _tabSelectedForeColor; }
            set { _tabSelectedForeColor = value; }
        }
        #endregion

        #region ToolTip
        /// <summary>
        /// The amount of time in milliseconds before the ToolTip appears.
        /// </summary>
        public int ToolTipDelayTime
        {
            get { return _toolTipDelayTime; }
            set
            {
                _toolTipDelayTime = value;
                if (_toolTip != null)
                    _toolTip.DelayTime = value;
            }
        }

        /// <summary>
        /// Get/Set the ToolStrip enabled property.
        /// </summary>
        public bool ToolTipEnable
        {
            get { return _toolTipEnable; }
            set { _toolTipEnable = value; }
        }

        /// <summary>
        /// Get/Set the forecolor of drop down menu items.
        /// </summary>
        public Color ToolTipForeColor
        {
            get { return _toolTipForeColor; }
            set
            {
                _toolTipForeColor = value;
                if (_toolTip != null)
                    _toolTip.ForeColor = value;
            }
        }

        /// <summary>
        /// Get/Set the starting color of the gradient.
        /// </summary>
        public Color ToolTipGradientBegin
        {
            get { return _toolTipGradientBegin; }
            set
            {
                _toolTipGradientBegin = value;
                if (_toolTip != null)
                    _toolTip.GradientBegin = value;
            }
        }

        /// <summary>
        /// Get/Set the ending color of the gradient.
        /// </summary>
        public Color ToolTipGradientEnd
        {
            get { return _toolTipGradientEnd; }
            set
            {
                _toolTipGradientEnd = value;
                if (_toolTip != null)
                    _toolTip.GradientEnd = value;
            }
        }

        /// <summary>
        /// The maximum length of the ToolTip in pixels.
        /// </summary>
        public int ToolTipMaximumLength
        {
            get { return _toolTipMaximumLength; }
            set
            {
                _toolTipMaximumLength = value;
                if (_toolTip != null)
                    _toolTip.MaximumLength = value;
            }
        }

        /// <summary>
        /// Position the ToolTip text right to left.
        /// </summary>
        public bool ToolTipRightToLeft
        {
            get { return _toolTipRightToLeft; }
            set
            {
                _toolTipRightToLeft = value;
                if (_toolTip != null)
                    _toolTip.TextRightToLeft = value;
            }
        }

        /// <summary>
        /// Display the buttons icon in the ToolTip.
        /// </summary>
        public bool ToolTipUseIcon
        {
            get { return _toolTipUseIcon; }
            set
            {
                _toolTipUseIcon = value;
                if (_toolTip != null)
                    _toolTip.UseIcon = value;
            }
        }

        /// <summary>
        /// The length of time in milliseconds that the ToolTip remains visible.
        /// </summary>
        public int ToolTipVisibleTime
        {
            get { return _toolTipVisibleTime; }
            set
            {
                _toolTipVisibleTime = value;
                if (_toolTip != null)
                    _toolTip.VisibleTime = value;
            }
        }
        #endregion
        #endregion

        #region Methods
        #region Tab Control
        public void Dispose()
        {
            this.ReleaseHandle();
            _tabHeaderBitmap.Dispose();
        }

        private void drawFocusedTab(Graphics g, Rectangle bounds, LinearGradientMode gradient)
        {
            // draw using anti alias
            using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
            {
                // create the path
                using (GraphicsPath buttonPath = createRoundRectanglePath(
                    g,
                    bounds.X, bounds.Y,
                    bounds.Width, bounds.Height,
                    1.0f))
                {
                    // draw the outer edge
                    using (Pen borderPen = new Pen(Color.FromArgb(50, Color.SlateGray), 1f))
                        g.DrawPath(borderPen, buttonPath);
                }
                bounds.Inflate(-1, -1);

                using (GraphicsPath buttonPath = createRoundRectanglePath(
                    g,
                    bounds.X, bounds.Y,
                    bounds.Width, bounds.Height,
                    1.0f))
                {
                    // draw the inner edge
                    using (Pen borderPen = new Pen(Color.FromArgb(50, TabBorderColor), 1.5f))
                        g.DrawPath(borderPen, buttonPath);

                    // create a thin gradient cover
                    using (LinearGradientBrush fillBrush = new LinearGradientBrush(
                        bounds,
                        Color.FromArgb(50, Color.FromArgb(200, Color.White)),
                        Color.FromArgb(50, TabGradientEnd),
                        gradient))
                    {
                        // shift the blend factors
                        Blend blend = new Blend();
                        blend.Positions = new float[] { 0f, .3f, .6f, 1f };
                        blend.Factors = new float[] { 0f, .5f, .8f, .2f };
                        fillBrush.Blend = blend;
                        // fill the path
                        g.FillPath(fillBrush, buttonPath);
                    }
                }
            }
        }

        private void drawTabControl()
        {
            // buffer drawing
            cStoreDc tempDc = new cStoreDc();
            int state = 0;
            RECT tabRect = new RECT();
            RECT ctlRect = new RECT();
            Rectangle headerRect = new Rectangle();
            TabControl tab = (TabControl)Control.FromHandle(_tabControlWnd);
            TabAlignment align = tab.Alignment;
            Rectangle fillRect = new Rectangle();

            // get size and dimension buffer dc
            GetWindowRect(_tabControlWnd, ref ctlRect);
            OffsetRect(ref ctlRect, -ctlRect.Left, -ctlRect.Top);
            tempDc.Width = ctlRect.Right;
            tempDc.Height = ctlRect.Bottom;
            Graphics g = Graphics.FromHdc(tempDc.Hdc);

            fillRect = new Rectangle(0, 0, ctlRect.Right, ctlRect.Bottom);
            // fill and backfill //
            if (tab.TabCount > 0)
            {
                // fill transparent section
                headerRect = new Rectangle(0, 0, ctlRect.Right, tab.DisplayRectangle.Y);
                using (Brush fillBrush = new SolidBrush(tab.Parent.BackColor))
                    g.FillRectangle(fillBrush, headerRect);
                // backfill the client
                headerRect = new Rectangle(0, tab.DisplayRectangle.Y, ctlRect.Right, ctlRect.Bottom - tab.DisplayRectangle.Y);
                using (Brush fillBrush = new SolidBrush(tab.Parent.BackColor))
                    g.FillRectangle(fillBrush, tab.ClientRectangle);
            }
            else
            {
                using (Brush fillBrush = new SolidBrush(Color.White))
                    g.FillRectangle(fillBrush, fillRect);
            }

            // draw the frame //
            //using (Pen darkPen = new Pen(Color.FromKnownColor(KnownColor.ControlDark)))
            using (Pen darkPen = new Pen(TabBorderColor)) //tester
            {
                Rectangle r = tab.DisplayRectangle;
                r.Inflate(1, 1);
                r.X--;
                r.Y--;
                g.DrawRectangle(darkPen, r);
            }

            // draw the tab headers //
            for (int i = 0; i < tab.TabCount; i++)
            {
                //tab.TabPages[i].Size = new Size(tab.TabPages[i].Size.Width + 5, tab.TabPages[i].Size.Height);
                // get the header size
                SendMessage(_tabControlWnd, TCM_GETITEMRECT, i, ref tabRect);

                // state
                if (tab.Enabled == false)
                    state = 3;
                else if (tab.SelectedTab == tab.TabPages[i])
                    state = 2;
                else if (Hovering(tabRect))
                    state = 1;
                else
                    state = 0;

                // bitmap mode //
                if (TabDrawingStyle == TabRenderStyle.Graphic && _tabHeaderBitmap != null)
                {
                    int width = _tabHeaderBitmap.Width / 4;
                    // create a new bitmap
                    Bitmap bm;
                    Bitmap cl;
                    int xsize = (state != 2) ? (tabRect.Bottom - tabRect.Top) : (tabRect.Bottom - tabRect.Top) - 7;
                    //xsize = (tabRect.Bottom - tabRect.Top) - 7;

                    // to maintain a constant border depth while stretching the bitmap //
                    if (align == TabAlignment.Bottom || align == TabAlignment.Top)
                        bm = new Bitmap(tabRect.Right - tabRect.Left, xsize);
                    else
                        bm = new Bitmap(xsize, tabRect.Right - tabRect.Left);

                    Graphics gcl = Graphics.FromImage(bm);
                    
                    // clone the inner portion
                    cl = _tabHeaderBitmap.Clone(new Rectangle((state * width) + 8, 0, width - 16, _tabHeaderBitmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);
                    // draw to new bmp
                    if (align == TabAlignment.Bottom || align == TabAlignment.Top)
                        gcl.DrawImage(cl, new Rectangle(8, 0, tabRect.Right - tabRect.Left, xsize));
                    else
                        gcl.DrawImage(cl, new Rectangle(8, 0, xsize, tabRect.Right - tabRect.Left));

                    // clone and draw the edges
                    // left
                    cl = _tabHeaderBitmap.Clone(new Rectangle(state * width, 0, 8, _tabHeaderBitmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);
                    gcl.DrawImage(cl, new Rectangle(0, 0, 8, xsize));
                    cl.Dispose();
                    // top
                    //cl = _tabHeaderBitmap.Clone(new Rectangle(state * width + 8, 0, width - 16, 7), System.Drawing.Imaging.PixelFormat.DontCare);
                    //gcl.DrawImage(cl, new Rectangle(8, 0, bm.Width - 16, 7));
                    //cl.Dispose();
                    //right
                    cl = _tabHeaderBitmap.Clone(new Rectangle((state * width) + (width - 16), 0, 16, _tabHeaderBitmap.Height), System.Drawing.Imaging.PixelFormat.Format64bppArgb);
                    gcl.DrawImage(cl, new Rectangle(bm.Width - 16, 0, 16, xsize));
                    cl.Dispose();
                    gcl.Dispose();
                    Rectangle dstRect = new Rectangle();

                    // set the base drawing coordinates //
                    switch (align)
                    {
                        case TabAlignment.Bottom:
                            dstRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top);
                            bm.RotateFlip(RotateFlipType.Rotate180FlipX);
                            if (state == 2)
                            {
                                dstRect.Height++;
                                dstRect.Y--;
                            }
                            break;
                        case TabAlignment.Left:
                            dstRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top);
                            bm.RotateFlip(RotateFlipType.Rotate90FlipX);
                            if (state == 2)
                                dstRect.Width++;
                            break;
                        case TabAlignment.Right:
                            dstRect = new Rectangle(tabRect.Left - 1, tabRect.Top, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top);
                            bm.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            if (state == 2)
                            {
                                dstRect.Width++;
                                dstRect.X--;
                            }
                            break;
                        case TabAlignment.Top:
                            dstRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top);
                            if (state == 2)
                                dstRect.Height++;
                            break;
                    }
                    // draw the image to temp dc
                    width = tabRect.Right - tabRect.Left;
                    Rectangle srcRect = new Rectangle(0, 0, bm.Width, bm.Height);
                    g.DrawImage(bm, dstRect, srcRect, GraphicsUnit.Pixel);
                    bm.Save(@"c:\full.bmp");
                    bm.Dispose();
                }
                // custom draw //
                else
                {
                    Color clBegin = TabGradientBegin;
                    Color clEnd = TabGradientEnd;
                    SendMessage(_tabControlWnd, TCM_GETITEMRECT, i, ref tabRect);
                    headerRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top);
                    // gradient color assignment
                    switch (align)
                    {
                        case TabAlignment.Bottom:
                            headerRect.Y -= 2;
                            clBegin = TabGradientBegin;
                            clEnd = (state == 2) ? TabSelectedColor : TabGradientEnd;
                            break;
                        case TabAlignment.Left:
                            clBegin = TabGradientBegin;
                            clEnd = (state == 2) ? TabSelectedColor : TabGradientEnd;
                            break;
                        case TabAlignment.Right:
                            headerRect.X -= 2;
                            clEnd = (state == 2) ? TabSelectedColor : TabGradientEnd;
                            clBegin = TabGradientBegin;
                            break;
                        case TabAlignment.Top:
                            clBegin = TabGradientBegin;
                            clEnd = (state == 2) ? TabSelectedColor : TabGradientEnd;
                            break;
                    }
                    if (tab.Enabled == false)
                    {
                        clBegin = Color.LightGray;
                        clEnd = Color.LightGray;
                    }
                    // draw the gradient
                    fillRect = headerRect;
                    fillRect.Inflate(-1, -1);
                    fillRect.Width++;
                    fillRect.Height++;
                    drawBlendedGradient(g,
                        (align == TabAlignment.Bottom || align == TabAlignment.Top) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal,
                        clBegin,
                        (state == 1) ? TabFocusedColor : clEnd,
                        fillRect,
                        TabGradientBlend);
                    if (state == 1)
                    {
                        // selection mask
                        drawFocusedTab(g, headerRect, LinearGradientMode.Vertical);
                    }
                    else if (state == 2)
                    {
                        // draw selected tab header frame
                        using (Pen darkPen = new Pen(TabBorderColor))
                            g.DrawRectangle(darkPen, headerRect);
                        // cover edge
                        switch (align)
                        {
                            case TabAlignment.Bottom:
                                using (Pen edgePen = new Pen(clBegin))
                                    g.DrawLine(edgePen, new Point(headerRect.Left + 1, headerRect.Top), new Point(headerRect.Right - 1, headerRect.Top));
                                break;
                            case TabAlignment.Left:
                                using (Pen edgePen = new Pen(clBegin))
                                    g.DrawLine(edgePen, new Point(headerRect.Right, headerRect.Top + 1), new Point(headerRect.Right, headerRect.Bottom - 1));
                                break;
                            case TabAlignment.Right:
                                using (Pen edgePen = new Pen(clBegin))
                                    g.DrawLine(edgePen, new Point(headerRect.Left, headerRect.Top + 1), new Point(headerRect.Left, headerRect.Bottom - 1));
                                break;
                            case TabAlignment.Top:
                                using (Pen edgePen = new Pen(clBegin))
                                    g.DrawLine(edgePen, new Point(headerRect.Left + 1, headerRect.Bottom), new Point(headerRect.Right - 1, headerRect.Bottom));
                                break;
                        }
                    }
                    else
                    {
                        // frame inactive tabs
                        using (Pen darkPen = new Pen(Color.FromArgb(100, TabBorderColor)))
                            g.DrawRectangle(darkPen, headerRect);
                    }
                }

                // draw icon //
                int hoffset = 4;
                int voffset = 4;
                if (tab.ImageList != null)
                {
                    // calculate offsets and draw the icon
                    if (tab.TabPages[i].ImageIndex > -1)
                    {
                        if (align == TabAlignment.Top || align == TabAlignment.Bottom)
                        {
                            voffset = ((tabRect.Bottom - tabRect.Top) - tab.ImageList.Images[i].Size.Height) / 2;
                            hoffset = 4;
                            tab.ImageList.Draw(g, new Point(tabRect.Left + hoffset, tabRect.Top + voffset), tab.TabPages[i].ImageIndex);
                            hoffset += tab.ImageList.Images[i].Size.Width;
                        }
                        else if (align == TabAlignment.Right)
                        {
                            hoffset = ((tabRect.Right - tabRect.Left) - tab.ImageList.Images[i].Size.Width) / 2;
                            voffset = 4;
                            tab.ImageList.Draw(g, new Point(tabRect.Left + hoffset, tabRect.Top + voffset), tab.TabPages[i].ImageIndex);
                            voffset += tab.ImageList.Images[i].Size.Height;
                        }
                        else if (align == TabAlignment.Left)
                        {
                            hoffset = ((tabRect.Right - tabRect.Left) - tab.ImageList.Images[i].Size.Width) / 2;
                            voffset = (tab.ImageList.Images[i].Size.Height + 4);
                            tab.ImageList.Draw(g, new Point(tabRect.Left + hoffset, tabRect.Bottom - voffset), tab.TabPages[i].ImageIndex);
                            voffset = tab.ImageList.Images[i].Size.Height + 4;
                        }
                    }
                }

                // draw text //
                // text offsets
                SizeF sz = g.MeasureString(tab.TabPages[i].Text, tab.Font);
                if (align == TabAlignment.Top || align == TabAlignment.Bottom)
                    voffset = ((tabRect.Bottom - tabRect.Top) - (int)sz.Height) / 2;
                else
                    hoffset = ((tabRect.Right - tabRect.Left) - (int)sz.Height) / 2;

                // text graphics
                Graphics gx = Graphics.FromHdcInternal(tempDc.Hdc);
                using (StringFormat sf = new StringFormat())
                {
                    gx.SmoothingMode = SmoothingMode.AntiAlias;
                    gx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    // poition and format
                    if (align == TabAlignment.Top || align == TabAlignment.Bottom)
                    {
                        hoffset += tabRect.Left;
                        voffset += tabRect.Top;
                    }
                    else if (align == TabAlignment.Left)
                    {
                        // create 'mirrored' text
                        // vertical text
                        sf.FormatFlags = StringFormatFlags.DirectionVertical;
                        // create a new matrix and rotate
                        Matrix mt = new Matrix();
                        mt.Rotate(180f);
                        // adjust offsets
                        voffset += -tabRect.Bottom;
                        hoffset += -tabRect.Right;
                        // apply the transform
                        gx.Transform = mt;

                    }
                    else if (align == TabAlignment.Right)
                    {
                        sf.FormatFlags = StringFormatFlags.DirectionVertical;
                        hoffset += tabRect.Left;
                        voffset += tabRect.Top;
                    }
                    // rtl
                    Font font = tab.Font;
                    if (tab.RightToLeftLayout)
                        sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                    Color foreColor;
                    if (state == 1)
                        foreColor = TabFocusedForeColor;
                    else if (state == 2)
                        foreColor = System.Drawing.Color.FromArgb(21, 66, 139);
                    else
                    {
                        foreColor = Color.White;
                        font = new Font(tab.Font.FontFamily, tab.Font.Size, FontStyle.Regular);
                    }
                    // draw the text
                    using (Brush captionBrush = new SolidBrush(foreColor))
                        gx.DrawString(tab.TabPages[i].Text ,font , captionBrush, new RectangleF(hoffset, voffset, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top), sf);
                }
                gx.Dispose();
            }

            g.Dispose();
            // draw the buffer to the control
            g = Graphics.FromHwnd(_tabControlWnd);
            BitBlt(g.GetHdc(), 0, 0, ctlRect.Right, ctlRect.Bottom, tempDc.Hdc, 0, 0, 0xCC0020);
            g.ReleaseHdc();
            tempDc.Dispose();
        }
        #endregion

        #region Helpers
        private GraphicsPath createRoundRectanglePath(Graphics g, float X, float Y, float width, float height, float radius)
        {
            // create a path
            GraphicsPath pathBounds = new GraphicsPath();
            pathBounds.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            pathBounds.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            pathBounds.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            pathBounds.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            pathBounds.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            pathBounds.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            pathBounds.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            pathBounds.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            pathBounds.CloseFigure();
            return pathBounds;
        }

        private void drawBlendedGradient(Graphics g, LinearGradientMode mode, Color begin, Color end, Rectangle rc, Blend bp)
        {
            using (LinearGradientBrush hb = new LinearGradientBrush(
                rc,
                begin,
                end,
                mode))
            {
                hb.Blend = bp;
                g.FillRectangle(hb, rc);
            }
        }

        private bool Hovering(RECT tabHeader)
        {
            RECT windowRect = new RECT();
            Point pos = new Point();

            GetWindowRect(_tabControlWnd, ref windowRect);
            OffsetRect(ref tabHeader, windowRect.Left, windowRect.Top);
            GetCursorPos(ref pos);
            if (PtInRect(ref tabHeader, pos))
                return true;
            return false;
        }
        #endregion

        #region ToolTip
        private TabPage overPage()
        {
            TabControl tab = (TabControl)Control.FromHandle(_tabControlWnd);
            RECT tabRect = new RECT();
            if (tab != null)
            {
                for (int i = 0; i < tab.TabCount; i++)
                {
                    SendMessage(_tabControlWnd, TCM_GETITEMRECT, i, ref tabRect);
                    if (Hovering(tabRect))
                        return tab.TabPages[i];
                }
            }
            return null;
        }

        private void toolTipStart(TabPage item)
        {
            if ((_toolTip != null) && (ToolTipEnable))
            {
                if (item != _lastFocusedPage)
                {
                    toolTipStop();
                    _lastFocusedPage = item;
                    _toolTipShown = false;
                }
                else
                {
                    if (_toolTipShown)
                        return;
                }
                Rectangle bounds = new Rectangle();
                RECT tabRect = new RECT();
                if (_toolTipText.ContainsKey(item))
                {
                    string caption = _toolTipText[item];
                    string title = String.Empty;
                    if (_toolTipTitle.ContainsKey(item))
                        title = _toolTipTitle[item];
                    TabControl tab = (TabControl)Control.FromHandle(_tabControlWnd);
                    SendMessage(_tabControlWnd, TCM_GETITEMRECT, tab.TabPages.IndexOf(item), ref tabRect);

                    bounds.X = tabRect.Left + 10;
                    bounds.Y = tabRect.Bottom + 10;
                    bounds.Width = ToolTipMaximumLength;
                    bounds.Height = 20;
                    _toolTip.UseIcon = ToolTipUseIcon;
                    Bitmap bmp = null;
                    if (ToolTipUseIcon)
                    {
                        if (tab.ImageList != null && item.ImageIndex > -1)
                        {
                            Size imageSize = tab.ImageList.ImageSize;
                            bmp = new Bitmap(tab.ImageList.Images[item.ImageIndex], imageSize);
                        }
                    }
                    _toolTip.Start(title, caption, bmp, bounds);
                    _toolTipShown = true;
                }
            }
        }

        private void toolTipStop()
        {
            if (_toolTip != null)
                _toolTip.Stop();
        }

        public void ToolTipTitle(TabPage item, string title)
        {
            if (!String.IsNullOrEmpty(title))
            {
                _toolTipTitle.Add(item, title);
            }
        }

        public void UseCustomToolTips(TabControl tab)
        {
            tab.MouseMove += new MouseEventHandler(tab_MouseMove);
            tab.MouseLeave += new EventHandler(tab_MouseLeave);
            tab.MouseDown += new MouseEventHandler(tab_MouseDown);
            tab.ControlAdded += new ControlEventHandler(tab_ControlAdded);
            tab.ControlRemoved += new ControlEventHandler(tab_ControlRemoved);
            tab.HandleDestroyed += new EventHandler(tab_HandleDestroyed);
            tab.HandleCreated += new EventHandler(tab_HandleCreated);
            _toolTipTitle.Clear();
            _toolTipText.Clear();
            foreach (TabPage item in tab.TabPages)
            {
                if (!String.IsNullOrEmpty(item.ToolTipText))
                {
                    _toolTipText.Add(item, item.ToolTipText);
                    item.ToolTipText = "";
                }
            }
            if (_toolTipText.Count > 0)
            {
                _toolTip = new ToolTip(tab.Handle);
                _toolTip.TextRightToLeft = ToolTipRightToLeft;
                ToolTipEnable = true;
            }
        }
        #endregion
        #endregion

        #region WndProc
        protected override void WndProc(ref Message m)
        {
            PAINTSTRUCT pntStrct = new PAINTSTRUCT();
            switch (m.Msg)
            {
                case WM_PAINT:
                    if (!_bPainting)
                    {
                        _bPainting = true;
                        // start painting engine
                        BeginPaint(m.HWnd, ref pntStrct);
                        drawTabControl();
                        ValidateRect(m.HWnd, ref pntStrct.rcPaint);
                        // done
                        EndPaint(m.HWnd, ref pntStrct);

                        _bPainting = false;
                    }
                    else
                    {
                        base.WndProc(ref m);
                    }
                    break;

                case WM_MOUSEMOVE:
                    // only necessary if vertically aligned..
                    drawTabControl();
                    base.WndProc(ref m);
                    break;

                case WM_MOUSELEAVE:
                    drawTabControl();
                    base.WndProc(ref m);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion
    }
    #region GraphicsMode
    //internal class GraphicsMode : IDisposable
    //{
    //    #region Instance Fields
    //    private Graphics _graphicCopy;
    //    private SmoothingMode _oldMode;
    //    #endregion

    //    #region Identity
    //    /// <summary>
    //    /// Initialize a new instance of the class.
    //    /// </summary>
    //    /// <param name="g">Graphics instance.</param>
    //    /// <param name="mode">Desired Smoothing mode.</param>
    //    public GraphicsMode(Graphics g, SmoothingMode mode)
    //    {
    //        _graphicCopy = g;
    //        _oldMode = _graphicCopy.SmoothingMode;
    //        _graphicCopy.SmoothingMode = mode;
    //    }

    //    /// <summary>
    //    /// Revert the SmoothingMode to original setting.
    //    /// </summary>
    //    public void Dispose()
    //    {
    //        _graphicCopy.SmoothingMode = _oldMode;
    //    }
    //    #endregion
    //}
    #endregion

    #region ToolTip
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    internal class ToolTip : NativeWindow
    {
        #region Constants
        // setwindowpos
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        // size/move
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOZORDER = 0x0004;
        private const uint SWP_NOREDRAW = 0x0008;
        private const uint SWP_NOACTIVATE = 0x0010;
        private const uint SWP_FRAMECHANGED = 0x0020;
        private const uint SWP_SHOWWINDOW = 0x0040;
        private const uint SWP_HIDEWINDOW = 0x0080;
        private const uint SWP_NOCOPYBITS = 0x0100;
        private const uint SWP_NOOWNERZORDER = 0x0200;
        private const uint SWP_NOSENDCHANGING = 0x0400;
        // styles
        private const int TTS_ALWAYSTIP = 0x01;
        private const int TTS_NOPREFIX = 0x02;
        private const int TTS_NOANIMATE = 0x10;
        private const int TTS_NOFADE = 0x20;
        private const int TTS_BALLOON = 0x40;
        private const int TTS_CLOSE = 0x80;
        private const int TTS_USEVISUALSTYLE = 0x100;
        // window messages
        private const int WM_NOTIFY = 0x4E;
        private const int WM_REFLECT = 0x2000;
        private const int WM_PAINT = 0xF;
        private const int WM_SIZE = 0x5;
        private const int WM_MOVE = 0x3;
        private const int WM_SETFONT = 0x30;
        private const int WM_GETFONT = 0x31;
        private const int WM_SHOWWINDOW = 0x18;
        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_MOUSELEAVE = 0x2A3;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_RBUTTONUP = 0x205;
        private const int WM_RBUTTONDBLCLK = 0x206;
        private const int WM_MBUTTONDOWN = 0x207;
        private const int WM_MBUTTONUP = 0x208;
        private const int WM_MBUTTONDBLCLK = 0x209;
        private const int WM_MOUSEWHEEL = 0x20A;
        private const int WM_TIMER = 0x113;
        private const int WM_NCPAINT = 0x85;
        private const int WM_DESTROY = 0x2;
        private const int WM_SETFOCUS = 0x7;
        private const int WM_KILLFOCUS = 0x8;
        private const int WM_IME_NOTIFY = 0x282;
        private const int WM_IME_SETCONTEXT = 0x281;
        private const int WM_ACTIVATE = 0x6;
        private const int WM_NCACTIVATE = 0x86;
        private const int WM_STYLECHANGED = 0x7d;
        private const int WM_STYLECHANGING = 0x7c;
        private const int WM_WINDOWPOSCHANGING = 0x46;
        private const int WM_WINDOWPOSCHANGED = 0x47;
        private const int WM_NCCALCSIZE = 0x83;
        private const int WM_CTLCOLOR = 0x3d8d610;
        // window styles
        private const int GWL_STYLE = (-16);
        private const int GWL_EXSTYLE = (-20);
        private const int SS_OWNERDRAW = 0xD;
        private const int WS_OVERLAPPED = 0x0;
        private const int WS_TABSTOP = 0x10000;
        private const int WS_THICKFRAME = 0x40000;
        private const int WS_HSCROLL = 0x100000;
        private const int WS_VSCROLL = 0x200000;
        private const int WS_BORDER = 0x800000;
        private const int WS_CLIPCHILDREN = 0x2000000;
        private const int WS_CLIPSIBLINGS = 0x4000000;
        private const int WS_VISIBLE = 0x10000000;
        private const int WS_CHILD = 0x40000000;
        private const int WS_POPUP = -2147483648;
        // window extended styles
        private const int WS_EX_LTRREADING = 0x0;
        private const int WS_EX_LEFT = 0x0;
        private const int WS_EX_RIGHTSCROLLBAR = 0x0;
        private const int WS_EX_DLGMODALFRAME = 0x1;
        private const int WS_EX_NOPARENTNOTIFY = 0x4;
        private const int WS_EX_TOPMOST = 0x8;
        private const int WS_EX_ACCEPTFILES = 0x10;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int WS_EX_MDICHILD = 0x40;
        private const int WS_EX_TOOLWINDOW = 0x80;
        private const int WS_EX_WINDOWEDGE = 0x100;
        private const int WS_EX_CLIENTEDGE = 0x200;
        private const int WS_EX_CONTEXTHELP = 0x400;
        private const int WS_EX_RIGHT = 0x1000;
        private const int WS_EX_RTLREADING = 0x2000;
        private const int WS_EX_LEFTSCROLLBAR = 0x4000;
        private const int WS_EX_CONTROLPARENT = 0x10000;
        private const int WS_EX_STATICEDGE = 0x20000;
        private const int WS_EX_APPWINDOW = 0x40000;
        private const int WS_EX_NOACTIVATE = 0x8000000;
        private const int WS_EX_LAYERED = 0x80000;
        #endregion

        #region Structs
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            private RECT(int X, int Y, int Width, int Height)
            {
                this.Left = X;
                this.Top = Y;
                this.Right = Width;
                this.Bottom = Height;
            }
            internal int Left;
            internal int Top;
            internal int Right;
            internal int Bottom;
        }
        #endregion

        #region API
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr CreateWindowEx(int exstyle, string lpClassName, string lpWindowName, int dwStyle,
            int x, int y, int nWidth, int nHeight, IntPtr hwndParent, IntPtr Menu, IntPtr hInstance, IntPtr lpParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DestroyWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = false)]
        private static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern IntPtr SetTimer(IntPtr hWnd, int nIDEvent, uint uElapse, IntPtr lpTimerFunc);

        [DllImport("user32.dll", ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool KillTimer(IntPtr hWnd, uint uIDEvent);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int x, int y, int cx, int cy, uint flags);

        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, ref RECT r);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("user32.dll")]
        private static extern bool ScreenToClient(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr handle);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr handle, IntPtr hdc);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        #endregion

        #region Fields
        private bool _timerActive = false;
        private bool _tipShowing = false;
        private bool _textRightToLeft = false;
        private bool _useIcon = false;
        private int _timerTick = 0;
        private int _delayTime = 1000;
        private int _visibleTime = 2000;
        private string _clientCaption = String.Empty;
        private string _clientTitle = String.Empty;
        private Color _foreColor = Color.Black;
        private Color _gradientBegin = Color.White;
        private Color _gradientEnd = Color.Silver;
        private IntPtr _hTipWnd = IntPtr.Zero;
        private IntPtr _hInstance = IntPtr.Zero;
        private IntPtr _hParentWnd = IntPtr.Zero;
        private Rectangle _clientBounds = new Rectangle();
        private Font _titleFont;
        private Font _captionFont;
        private Bitmap _clientImage = null;
        #endregion

        #region Constructor
        public ToolTip(IntPtr hParentWnd)
        {
            Type t = typeof(ToolTip);
            Module m = t.Module;
            _hInstance = Marshal.GetHINSTANCE(m);
            _hParentWnd = hParentWnd;
            // create window
            _hTipWnd = CreateWindowEx(WS_EX_TOPMOST | WS_EX_TOOLWINDOW,
                "STATIC", "",
                SS_OWNERDRAW | WS_CHILD | WS_CLIPSIBLINGS | WS_OVERLAPPED,
                0, 0,
                0, 0,
                GetDesktopWindow(),
                IntPtr.Zero, _hInstance, IntPtr.Zero);
            // set starting position
            SetWindowPos(_hTipWnd, HWND_TOP,
                0, 0,
                0, 0,
                SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE | SWP_NOOWNERZORDER);
            createFonts();
            this.AssignHandle(_hTipWnd);
        }
        #endregion

        #region Properties
        private Rectangle TipBounds
        {
            get { return _clientBounds; }
            set { _clientBounds = value; }
        }

        private string Caption
        {
            get { return _clientCaption; }
            set { _clientCaption = value; }
        }

        public int DelayTime
        {
            get { return _delayTime; }
            set { _delayTime = value; }
        }

        public Color ForeColor
        {
            get { return _foreColor; }
            set { _foreColor = value; }
        }

        public Color GradientBegin
        {
            get { return _gradientBegin; }
            set { _gradientBegin = value; }
        }

        public Color GradientEnd
        {
            get { return _gradientEnd; }
            set { _gradientEnd = value; }
        }

        public Bitmap ItemImage
        {
            get { return _clientImage; }
            set { _clientImage = value; }
        }

        public int MaximumLength
        {
            set { _clientBounds.Width = value; }
        }

        public bool TextRightToLeft
        {
            get { return _textRightToLeft; }
            set { _textRightToLeft = value; }
        }

        private string Title
        {
            get { return _clientTitle; }
            set { _clientTitle = value; }
        }

        public bool UseIcon
        {
            get { return _useIcon; }
            set { _useIcon = value; }
        }

        public int VisibleTime
        {
            get { return _visibleTime; }
            set { _visibleTime = value; }
        }
        #endregion

        #region Public Methods
        public void Start(string title, string caption, Bitmap image, Rectangle bounds)
        {
            if (_timerActive)
                Stop();
            destroyImage();
            Title = title;
            Caption = caption;
            ItemImage = image;
            TipBounds = bounds;
            SetTimer(_hTipWnd, 1, 100, IntPtr.Zero);
        }

        public void Stop()
        {
            // kill the timer
            KillTimer(_hTipWnd, 1);
            // hide the window
            showWindow(false);
            // reset properties
            Title = String.Empty;
            Caption = String.Empty;
            ItemImage = null;
            TipBounds = Rectangle.Empty;
            // reset timer values
            _timerTick = 0;
            _tipShowing = false;
            _timerActive = false;
        }

        public void Dispose()
        {
            if (_hTipWnd != IntPtr.Zero)
            {
                this.ReleaseHandle();
                destroyFonts();
                destroyImage();
                DestroyWindow(_hTipWnd);
                _hTipWnd = IntPtr.Zero;
            }
        }
        #endregion

        #region Internal Methods
        private Rectangle calculateSize()
        {
            SizeF textSize = new SizeF();
            SizeF titleSize = new SizeF();

            // calculate text
            if (!String.IsNullOrEmpty(Caption))
                textSize = calcTextSize(Caption, _captionFont, 0);
            // calc title
            if (!String.IsNullOrEmpty(Title))
                titleSize = calcTextSize(Title, _titleFont, 0);
            if (textSize.Width < titleSize.Width)
                textSize.Width = titleSize.Width;
            if (titleSize.Height > 0)
                textSize.Height += (titleSize.Height + 4);
            // calc icon
            if ((ItemImage != null) && (UseIcon))
            {
                textSize.Height += 8;
                textSize.Width += ItemImage.Size.Width + 8;
            }
            else
            {
                textSize.Height += 4;
                textSize.Width += 4;
            }
            Rectangle bounds = new Rectangle(0, 0, (int)textSize.Width, (int)textSize.Height);
            bounds.Inflate(4, 4);
            bounds.Offset(4, 4);
            return bounds;
        }

        private SizeF calcTextSize(string text, Font font, int width)
        {
            SizeF sF = new SizeF();
            IntPtr hdc = GetDC(_hTipWnd);
            Graphics g = Graphics.FromHdc(hdc);
            if (width > 0)
                sF = g.MeasureString(text, font, width);
            else
                sF = g.MeasureString(text, font);
            ReleaseDC(_hTipWnd, hdc);
            g.Dispose();
            return sF;
        }

        private void copyBackground(Graphics g)
        {
            RECT windowRect = new RECT();
            GetWindowRect(_hTipWnd, ref windowRect);
            g.CopyFromScreen(windowRect.Left, windowRect.Top, 0, 0, new Size(windowRect.Right - windowRect.Left, windowRect.Bottom - windowRect.Top), CopyPixelOperation.SourceCopy);
        }

        private void createFonts()
        {
            _titleFont = new Font("Tahoma", 8, FontStyle.Bold);
            _captionFont = new Font("Tahoma", 8, FontStyle.Regular);
        }

        private GraphicsPath createRoundRectanglePath(Graphics g, float X, float Y, float width, float height, float radius)
        {
            // create a path
            GraphicsPath pathBounds = new GraphicsPath();
            pathBounds.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            pathBounds.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            pathBounds.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            pathBounds.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            pathBounds.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            pathBounds.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            pathBounds.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            pathBounds.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            pathBounds.CloseFigure();
            return pathBounds;
        }

        private void destroyFonts()
        {
            if (_titleFont != null)
                _titleFont.Dispose();
            if (_captionFont != null)
                _captionFont.Dispose();
        }

        private void destroyImage()
        {
            if (ItemImage != null)
                ItemImage.Dispose();
            ItemImage = null;
        }

        private void drawBackground(IntPtr hdc)
        {
            // create the graphics instance
            Graphics g = Graphics.FromHdc(hdc);
            // copy in the background to mimic transparency
            copyBackground(g);
            // create the shadow rect
            Rectangle shadowArea = new Rectangle(3, TipBounds.Height - 3, TipBounds.Width - 3, TipBounds.Height);
            // draw the bottom shadow
            using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
            {
                using (GraphicsPath shadowPath = createRoundRectanglePath(g, 4, TipBounds.Height - 4, TipBounds.Width - 4, TipBounds.Height, 1f))
                {
                    using (LinearGradientBrush shadowBrush = new LinearGradientBrush(shadowArea, Color.FromArgb(100, 0x99, 0x99, 0x99), Color.FromArgb(60, 0x44, 0x44, 0x44), LinearGradientMode.Vertical))
                    {
                        Blend blend = new Blend();
                        blend.Positions = new float[] { 0f, .3f, .6f, 1f };
                        blend.Factors = new float[] { 0f, .3f, .6f, .9f };
                        shadowBrush.Blend = blend;
                        g.FillPath(shadowBrush, shadowPath);
                    }
                }
                // draw the right shadow
                using (GraphicsPath shadowPath = createRoundRectanglePath(g, TipBounds.Width - 4, 4, TipBounds.Width - 4, TipBounds.Height - 8, 1f))
                {
                    using (LinearGradientBrush shadowBrush = new LinearGradientBrush(shadowArea, Color.FromArgb(100, 0x99, 0x99, 0x99), Color.FromArgb(60, 0x44, 0x44, 0x44), LinearGradientMode.Horizontal))
                    {
                        Blend blend = new Blend();
                        blend.Positions = new float[] { 0f, .3f, .6f, 1f };
                        blend.Factors = new float[] { 0f, .3f, .6f, .9f };
                        shadowBrush.Blend = blend;
                        g.FillPath(shadowBrush, shadowPath);
                    }
                }
                // adjust the bounds
                Rectangle fillBounds = new Rectangle(0, 0, TipBounds.Width - 4, TipBounds.Height - 4);
                using (GraphicsPath fillPath = createRoundRectanglePath(g, fillBounds.X, fillBounds.Y, fillBounds.Width, fillBounds.Height, 2f))
                {
                    using (LinearGradientBrush shadowBrush = new LinearGradientBrush(shadowArea, GradientBegin, GradientEnd, LinearGradientMode.Vertical))
                    {
                        // draw the frame
                        using (Pen fillPen = new Pen(Color.FromArgb(250, 0x44, 0x44, 0x44)))
                            g.DrawPath(fillPen, fillPath);
                        // fill the body
                        Blend blend = new Blend();
                        blend.Positions = new float[] { 0f, .4f, .6f, 1f };
                        blend.Factors = new float[] { 0f, .3f, .6f, .8f };
                        shadowBrush.Blend = blend;
                        g.FillPath(shadowBrush, fillPath);
                    }
                }
            }
            g.Dispose();
        }

        private void drawCaption(IntPtr hdc)
        {
            Graphics g = Graphics.FromHdc(hdc);
            using (StringFormat sF = new StringFormat())
            {
                int vOffset;
                int hOffset;

                if ((ItemImage != null) && (UseIcon))
                {
                    vOffset = ItemImage.Size.Width + 8;
                    if (!String.IsNullOrEmpty(Title))
                        hOffset = (ItemImage.Size.Height / 2) + (_titleFont.Height);
                    else
                        hOffset = (TipBounds.Height - ItemImage.Size.Height) / 2;
                }
                else if (!String.IsNullOrEmpty(Title))
                {
                    vOffset = 4;
                    hOffset = (_titleFont.Height + 8);
                }
                else
                {
                    vOffset = 4;
                    hOffset = 4;
                }

                sF.Alignment = StringAlignment.Near;
                sF.LineAlignment = StringAlignment.Near;
                if (TextRightToLeft)
                    sF.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                using (Brush captionBrush = new SolidBrush(ForeColor))
                    g.DrawString(Caption, _captionFont, captionBrush, new RectangleF(vOffset, hOffset, TipBounds.Width - vOffset, TipBounds.Height - hOffset), sF);
            }
            g.Dispose();
        }

        private void drawIcon(IntPtr hdc)
        {
            if (ItemImage != null)
            {
                Graphics g = Graphics.FromHdc(hdc);
                g.DrawImage(ItemImage, new Point(4, 4));
                g.Dispose();
            }
        }

        private void drawTitle(IntPtr hdc)
        {
            Graphics g = Graphics.FromHdc(hdc);
            using (StringFormat sF = new StringFormat())
            {
                int vOffset;
                int hOffset;

                if ((ItemImage != null) && (UseIcon))
                {
                    vOffset = ItemImage.Size.Width + 8;
                    hOffset = (ItemImage.Size.Height / 2) + 2;
                }
                else
                {
                    vOffset = 4;
                    hOffset = 12;
                }

                sF.Alignment = StringAlignment.Near;
                sF.LineAlignment = StringAlignment.Center;
                sF.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
                sF.FormatFlags = StringFormatFlags.NoWrap;

                if (TextRightToLeft)
                    sF.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                using (Brush titleBrush = new SolidBrush(ForeColor))
                    g.DrawString(Title, _titleFont, titleBrush, new PointF(vOffset, hOffset), sF);
            }
            g.Dispose();
        }

        private void positionWindow()
        {
            if (_hTipWnd != IntPtr.Zero)
            {
                // offset with screen position
                RECT windowRect = new RECT();
                GetWindowRect(_hParentWnd, ref windowRect);
                windowRect.Left += TipBounds.X;
                windowRect.Top += TipBounds.Y;
                // position the window
                SetWindowPos(_hTipWnd, HWND_TOPMOST, windowRect.Left, windowRect.Top, TipBounds.Width, TipBounds.Height, SWP_SHOWWINDOW | SWP_NOACTIVATE);
            }
        }

        private void renderTip()
        {
            if ((Caption != String.Empty) && (TipBounds != Rectangle.Empty))
            {
                // create the canvas
                _clientBounds.Height = 50;
                Rectangle bounds = calculateSize();
                bounds.X = TipBounds.X;
                bounds.Y = TipBounds.Y;
                TipBounds = bounds;
                cStoreDc drawDc = new cStoreDc();
                drawDc.Width = TipBounds.Width;
                drawDc.Height = TipBounds.Height;
                positionWindow();
                // show the window
                showWindow(true);
                // draw the background to the temp dc
                drawBackground(drawDc.Hdc);
                // draw image and text
                if ((ItemImage != null) && (UseIcon))
                    drawIcon(drawDc.Hdc);
                if (Title != String.Empty)
                    drawTitle(drawDc.Hdc);
                drawCaption(drawDc.Hdc);
                // draw the tempdc to the window
                IntPtr hdc = GetDC(_hTipWnd);
                BitBlt(hdc, 0, 0, TipBounds.Width, TipBounds.Height, drawDc.Hdc, 0, 0, 0xCC0020);
                ReleaseDC(_hTipWnd, hdc);
                // cleanup
                drawDc.Dispose();
            }
        }

        private void showWindow(bool show)
        {
            if (show)
                SetWindowPos(_hTipWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_SHOWWINDOW | SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE);
            else
                SetWindowPos(_hTipWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_HIDEWINDOW | SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE);
        }
        #endregion

        #region WndProc
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_TIMER:
                    _timerTick++;
                    if (_timerTick > (DelayTime / 100))
                    {
                        if (!_tipShowing)
                        {
                            _tipShowing = true;
                            renderTip();
                        }
                    }
                    if (_timerTick > ((DelayTime + VisibleTime) / 100))
                        Stop();
                    base.WndProc(ref m);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion
    }
    #endregion

    #region StoreDc
    //[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    //internal class cStoreDc
    //{
    //    [DllImport("gdi32.dll")]
    //    private static extern IntPtr CreateDCA([MarshalAs(UnmanagedType.LPStr)]string lpszDriver, [MarshalAs(UnmanagedType.LPStr)]string lpszDevice, [MarshalAs(UnmanagedType.LPStr)]string lpszOutput, int lpInitData);

    //    [DllImport("gdi32.dll")]
    //    private static extern IntPtr CreateDCW([MarshalAs(UnmanagedType.LPWStr)]string lpszDriver, [MarshalAs(UnmanagedType.LPWStr)]string lpszDevice, [MarshalAs(UnmanagedType.LPWStr)]string lpszOutput, int lpInitData);

    //    [DllImport("gdi32.dll")]
    //    private static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, int lpInitData);

    //    [DllImport("gdi32.dll")]
    //    private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

    //    [DllImport("gdi32.dll")]
    //    private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

    //    [DllImport("gdi32.dll")]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    private static extern bool DeleteDC(IntPtr hdc);

    //    [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true)]
    //    private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

    //    [DllImport("gdi32.dll")]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    private static extern bool DeleteObject(IntPtr hObject);

    //    private int _Height = 0;
    //    private int _Width = 0;
    //    private IntPtr _Hdc = IntPtr.Zero;
    //    private IntPtr _Bmp = IntPtr.Zero;
    //    private IntPtr _BmpOld = IntPtr.Zero;

    //    public IntPtr Hdc
    //    {
    //        get { return _Hdc; }
    //    }

    //    public IntPtr HBmp
    //    {
    //        get { return _Bmp; }
    //    }

    //    public int Height
    //    {
    //        get { return _Height; }
    //        set
    //        {
    //            if (_Height != value)
    //            {
    //                _Height = value;
    //                ImageCreate(_Width, _Height);
    //            }
    //        }
    //    }

    //    public int Width
    //    {
    //        get { return _Width; }
    //        set
    //        {
    //            if (_Width != value)
    //            {
    //                _Width = value;
    //                ImageCreate(_Width, _Height);
    //            }
    //        }
    //    }

    //    private void ImageCreate(int Width, int Height)
    //    {
    //        IntPtr pHdc = IntPtr.Zero;

    //        ImageDestroy();
    //        pHdc = CreateDCA("DISPLAY", "", "", 0);
    //        _Hdc = CreateCompatibleDC(pHdc);
    //        _Bmp = CreateCompatibleBitmap(pHdc, _Width, _Height);
    //        _BmpOld = SelectObject(_Hdc, _Bmp);
    //        if (_BmpOld == IntPtr.Zero)
    //        {
    //            ImageDestroy();
    //        }
    //        else
    //        {
    //            _Width = Width;
    //            _Height = Height;
    //        }
    //        DeleteDC(pHdc);
    //        pHdc = IntPtr.Zero;
    //    }

    //    private void ImageDestroy()
    //    {
    //        if (_BmpOld != IntPtr.Zero)
    //        {
    //            SelectObject(_Hdc, _BmpOld);
    //            _BmpOld = IntPtr.Zero;
    //        }
    //        if (_Bmp != IntPtr.Zero)
    //        {
    //            DeleteObject(_Bmp);
    //            _Bmp = IntPtr.Zero;
    //        }
    //        if (_Hdc != IntPtr.Zero)
    //        {
    //            DeleteDC(_Hdc);
    //            _Hdc = IntPtr.Zero;
    //        }
    //    }

    //    public void Dispose()
    //    {
    //        ImageDestroy();
    //    }
    //}
    #endregion

    //#region Directives
    //using System;
    //using System.Windows.Forms;
    //using System.Runtime.InteropServices;
    //using System.Collections.Generic;
    //using System.Drawing;
    //using System.Text;
    //using System.Drawing.Drawing2D;
    //#endregion

    //#region Enums
    //public enum TabRenderStyle
    //{
    //    Custom,
    //    Graphic
    //}
    //#endregion

    //public class cTabControl : NativeWindow, IDisposable
    //{
    //    #region Constants
    //    // alphablend
    //    private const byte AC_SRC_OVER = 0x00;
    //    private const byte AC_SRC_ALPHA = 0x01;
    //    // window messages
    //    private const int WM_MOUSEMOVE = 0x200;
    //    private const int WM_MOUSELEAVE = 0x2A3;
    //    private const int WM_LBUTTONDOWN = 0x201;
    //    private const int WM_LBUTTONUP = 0x202;
    //    private const int WM_MOUSEHOVER = 0x2A1;
    //    private const int WM_PAINT = 0xF;
    //    // tab messages
    //    private const int TCIF_STATE = 0x0010;
    //    private const int TCM_FIRST = 0x1300;
    //    private const int TCM_GETIMAGELIST = (TCM_FIRST + 2);
    //    private const int TCM_SETIMAGELIST = (TCM_FIRST + 3);
    //    private const int TCM_GETITEMCOUNT = (TCM_FIRST + 4);
    //    private const int TCM_GETITEMA = (TCM_FIRST + 5);
    //    private const int TCM_GETITEMW = (TCM_FIRST + 60);
    //    private const int TCM_SETITEMA = (TCM_FIRST + 6);
    //    private const int TCM_SETITEMW = (TCM_FIRST + 61);
    //    private const int TCM_INSERTITEMA = (TCM_FIRST + 7);
    //    private const int TCM_INSERTITEMW = (TCM_FIRST + 62);
    //    private const int TCM_DELETEITEM = (TCM_FIRST + 8);
    //    private const int TCM_DELETEALLITEMS = (TCM_FIRST + 9);
    //    private const int TCM_GETITEMRECT = (TCM_FIRST + 10);
    //    private const int TCN_FIRST = 550;
    //    private const int TCN_LAST = 580;
    //    private const int TCN_KEYDOWN = (TCN_FIRST - 0);
    //    private const int TCN_SELCHANGE = (TCN_FIRST - 1);
    //    private const int TCN_SELCHANGING = (TCN_FIRST - 2);
    //    private const int TCN_GETOBJECT = (TCN_FIRST - 3);
    //    private const int TCIS_BUTTONPRESSED = 0x0001;
    //    private const int TCIS_HIGHLIGHTED = 0x0002;
    //    // message handler
    //    private static IntPtr MSG_HANDLED = new IntPtr(1);
    //    #endregion

    //    #region Structs
    //    [StructLayout(LayoutKind.Sequential)]
    //    private struct PAINTSTRUCT
    //    {
    //        internal IntPtr hdc;
    //        internal int fErase;
    //        internal RECT rcPaint;
    //        internal int fRestore;
    //        internal int fIncUpdate;
    //        internal int Reserved1;
    //        internal int Reserved2;
    //        internal int Reserved3;
    //        internal int Reserved4;
    //        internal int Reserved5;
    //        internal int Reserved6;
    //        internal int Reserved7;
    //        internal int Reserved8;
    //    }

    //    [StructLayout(LayoutKind.Sequential)]
    //    private struct RECT
    //    {
    //        internal RECT(int X, int Y, int Width, int Height)
    //        {
    //            this.Left = X;
    //            this.Top = Y;
    //            this.Right = Width;
    //            this.Bottom = Height;
    //        }
    //        internal int Left;
    //        internal int Top;
    //        internal int Right;
    //        internal int Bottom;
    //    }

    //    [StructLayout(LayoutKind.Sequential)]
    //    private struct BLENDFUNCTION
    //    {
    //        byte BlendOp;
    //        byte BlendFlags;
    //        byte SourceConstantAlpha;
    //        byte AlphaFormat;

    //        internal BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
    //        {
    //            BlendOp = op;
    //            BlendFlags = flags;
    //            SourceConstantAlpha = alpha;
    //            AlphaFormat = format;
    //        }
    //    }
    //    #endregion

    //    #region API
    //    [DllImport("user32.dll")]
    //    private static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

    //    [DllImport("user32.dll")]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    private static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

    //    [DllImport("user32.dll")]
    //    private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, ref RECT lParam);

    //    [DllImport("user32.dll")]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    private static extern bool GetCursorPos(ref Point lpPoint);

    //    [DllImport("user32.dll")]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    private static extern bool PtInRect([In] ref RECT lprc, Point pt);

    //    [DllImport("user32.dll")]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

    //    [DllImport("user32.dll")]
    //    private extern static int OffsetRect(ref RECT lpRect, int x, int y);

    //    [DllImport("user32.dll")]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    private static extern bool GetClientRect(IntPtr hWnd, ref RECT r);

    //    [DllImport("gdi32.dll", EntryPoint = "GdiAlphaBlend")]
    //    private static extern bool AlphaBlend(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest,
    //    IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, BLENDFUNCTION blendFunction);

    //    [DllImport("gdi32.dll")]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    private static extern bool StretchBlt(IntPtr hDest, int X, int Y, int nWidth, int nHeight, IntPtr hdcSrc,
    //    int sX, int sY, int nWidthSrc, int nHeightSrc, int dwRop);

    //    [DllImport("gdi32.dll")]
    //    private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

    //    [DllImport("user32.dll")]
    //    private static extern bool ValidateRect(IntPtr hWnd, ref RECT lpRect);

    //    [DllImport("gdi32.dll")]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

    //    [DllImport("user32.dll")]
    //    private extern static int InflateRect(ref RECT lpRect, int x, int y);

    //    [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
    //    private static extern int SetWindowTheme(IntPtr hWnd, String pszSubAppName, String pszSubIdList);
    //    #endregion

    //    #region Fields
    //    // tab
    //    private bool _bPainting = false;
    //    private IntPtr _hTabControlWnd = IntPtr.Zero;
    //    private Bitmap _oTabHeaderBitmap;
    //    private Color _oTabBorderColor = Color.DarkGray;
    //    private Color _oTabGradientBegin = Color.White;
    //    private Color _oTabGradientEnd = Color.Silver;
    //    private Color _oTabForeColor = Color.Black;
    //    private Color _oTabFocusedColor = Color.DarkGray;
    //    private Color _oTabFocusedForeColor = Color.Black;
    //    private Color _oTabSelectedColor = Color.White;
    //    private Color _oTabSelectedForeColor = Color.Black;
    //    private Blend _tTabStripGradientBlend = new Blend();
    //    private TabRenderStyle _eTabRenderStyle = TabRenderStyle.Graphic;
    //    // tooltip
    //    private bool _bToolTipShown = false;
    //    private bool _bToolTipEnable = false;
    //    private bool _bToolTipUseIcon = false;
    //    private bool _bToolTipRightToLeft = false;
    //    private int _iToolTipMaximumLength = 200;
    //    private int _iToolTipDelayTime = 1000;
    //    private int _iToolTipVisibleTime = 2000;
    //    private Color _oToolTipGradientBegin = Color.White;
    //    private Color _oToolTipGradientEnd = Color.Black;
    //    private Color _oToolTipForeColor = Color.Black;
    //    private TabPage _oLastFocusedPage;
    //    private cToolTip _cToolTip;
    //    private Dictionary<TabPage, string> _oToolTipText = new Dictionary<TabPage, string>();
    //    private Dictionary<TabPage, string> _oToolTipTitle = new Dictionary<TabPage, string>();
    //    #endregion

    //    #region Constructor
    //    public cTabControl(IntPtr hWnd, Bitmap skin)
    //    {
    //        if (hWnd == IntPtr.Zero)
    //            throw new Exception("The tab control handle is invalid.");
    //        if (skin == null)
    //            throw new Exception("The image provided is invalid.");
    //        TabHeaderGraphic = skin;
    //        Init();
    //        _hTabControlWnd = hWnd;
    //        //SetWindowTheme(_tabControlWnd, "", "");
    //        this.AssignHandle(hWnd);
    //    }

    //    public cTabControl(IntPtr hWnd)
    //    {
    //        if (hWnd == IntPtr.Zero)
    //            throw new Exception("The tab control handle is invalid.");
    //        Init();
    //        _hTabControlWnd = hWnd;
    //        //SetWindowTheme(_tabControlWnd, "", "");
    //        this.AssignHandle(_hTabControlWnd);
    //    }

    //    private void Init()
    //    {
    //        _tTabStripGradientBlend.Positions = new float[] { 0f, .3f, .4f, .9f, 1f };
    //        _tTabStripGradientBlend.Factors = new float[] { 0f, .2f, .5f, 1f, .6f };
    //    }
    //    #endregion

    //    #region ToolTip Events
    //    private void tab_ControlAdded(object sender, ControlEventArgs e)
    //    {
    //        if (e.Control.GetType() == typeof(TabPage))
    //        {
    //            TabPage item = (TabPage)e.Control;
    //            if (ToolTipEnable == true && !String.IsNullOrEmpty(item.ToolTipText))
    //            {
    //                _oToolTipText.Add(item, item.ToolTipText);
    //                item.ToolTipText = "";
    //            }
    //        }
    //    }

    //    private void tab_ControlRemoved(object sender, ControlEventArgs e)
    //    {
    //        if (e.Control.GetType() == typeof(TabPage))
    //        {
    //            if (_oToolTipText.ContainsKey((TabPage)e.Control))
    //                _oToolTipText.Remove((TabPage)e.Control);
    //            if (_oToolTipTitle.ContainsKey((TabPage)e.Control))
    //                _oToolTipTitle.Remove((TabPage)e.Control);
    //        }
    //    }

    //    private void tab_HandleCreated(object sender, EventArgs e)
    //    {
    //        if (sender.GetType() == typeof(TabControl))
    //        {
    //            TabControl tab = (TabControl)sender;
    //            _hTabControlWnd = tab.Handle;
    //        }
    //    }

    //    private void tab_HandleDestroyed(object sender, EventArgs e)
    //    {
    //        if (_cToolTip != null)
    //            _cToolTip.Dispose();
    //    }

    //    private void tab_MouseDown(object sender, MouseEventArgs e)
    //    {
    //        toolTipStop();
    //    }

    //    private void tab_MouseLeave(object sender, EventArgs e)
    //    {
    //        toolTipStop();
    //    }

    //    private void tab_MouseMove(object sender, MouseEventArgs e)
    //    {
    //        TabPage item = overPage();
    //        if (item != null)
    //            toolTipStart(item);
    //    }
    //    #endregion

    //    #region Properties
    //    #region Tab Control
    //    /// <summary>
    //    /// Get/Set the tab border color.
    //    /// </summary>
    //    public Color TabBorderColor
    //    {
    //        get { return _oTabBorderColor; }
    //        set { _oTabBorderColor = value; }
    //    }

    //    /// <summary>
    //    /// Get/Set the drawing render style.
    //    /// </summary>
    //    public TabRenderStyle TabDrawingStyle
    //    {
    //        get { return _eTabRenderStyle; }
    //        set { _eTabRenderStyle = value; }
    //    }

    //    /// <summary>
    //    /// Get/Set the ForeColor.
    //    /// </summary>
    //    public Color TabForeColor
    //    {
    //        get { return _oTabForeColor; }
    //        set { _oTabForeColor = value; }
    //    }

    //    /// <summary>
    //    /// Get/Set the focused ForeColor.
    //    /// </summary>
    //    public Color TabFocusedForeColor
    //    {
    //        get { return _oTabFocusedForeColor; }
    //        set { _oTabFocusedForeColor = value; }
    //    }

    //    /// <summary>
    //    /// Get/Set the tab focused Color.
    //    /// </summary>
    //    public Color TabFocusedColor
    //    {
    //        get { return _oTabFocusedColor; }
    //        set { _oTabFocusedColor = value; }
    //    }

    //    /// <summary>
    //    /// Get/Set the starting color of the button fade gradient.
    //    /// </summary>
    //    public Color TabGradientBegin
    //    {
    //        get { return _oTabGradientBegin; }
    //        set { _oTabGradientBegin = value; }
    //    }

    //    /// <summary>
    //    /// Get/Set the ending color of the button fade gradient.
    //    /// </summary>
    //    public Color TabGradientEnd
    //    {
    //        get { return _oTabGradientEnd; }
    //        set { _oTabGradientEnd = value; }
    //    }

    //    /// <summary>
    //    /// Get/Set the blend factor of the gradient.
    //    /// </summary>
    //    public Blend TabGradientBlend
    //    {
    //        get { return _tTabStripGradientBlend; }
    //        set { _tTabStripGradientBlend = value; }
    //    }

    //    /// <summary>
    //    /// Get/Set the bitmap used for the tab header.
    //    /// </summary>
    //    public Bitmap TabHeaderGraphic
    //    {
    //        get { return _oTabHeaderBitmap; }
    //        set { _oTabHeaderBitmap = value; }
    //    }

    //    /// <summary>
    //    /// Get/Set the tab selected Color.
    //    /// </summary>
    //    public Color TabSelectedColor
    //    {
    //        get { return _oTabSelectedColor; }
    //        set { _oTabSelectedColor = value; }
    //    }

    //    /// <summary>
    //    /// Get/Set the tab selected Color.
    //    /// </summary>
    //    public Color TabSelectedForeColor
    //    {
    //        get { return _oTabSelectedForeColor; }
    //        set { _oTabSelectedForeColor = value; }
    //    }
    //    #endregion

    //    #region ToolTip
    //    /// <summary>
    //    /// The amount of time in milliseconds before the ToolTip appears.
    //    /// </summary>
    //    public int ToolTipDelayTime
    //    {
    //        get { return _iToolTipDelayTime; }
    //        set
    //        {
    //            _iToolTipDelayTime = value;
    //            if (_cToolTip != null)
    //                _cToolTip.DelayTime = value;
    //        }
    //    }

    //    /// <summary>
    //    /// Get/Set the ToolStrip enabled property.
    //    /// </summary>
    //    public bool ToolTipEnable
    //    {
    //        get { return _bToolTipEnable; }
    //        set { _bToolTipEnable = value; }
    //    }

    //    /// <summary>
    //    /// Get/Set the forecolor of drop down menu items.
    //    /// </summary>
    //    public Color ToolTipForeColor
    //    {
    //        get { return _oToolTipForeColor; }
    //        set
    //        {
    //            _oToolTipForeColor = value;
    //            if (_cToolTip != null)
    //                _cToolTip.ForeColor = value;
    //        }
    //    }

    //    /// <summary>
    //    /// Get/Set the starting color of the gradient.
    //    /// </summary>
    //    public Color ToolTipGradientBegin
    //    {
    //        get { return _oToolTipGradientBegin; }
    //        set
    //        {
    //            _oToolTipGradientBegin = value;
    //            if (_cToolTip != null)
    //                _cToolTip.GradientBegin = value;
    //        }
    //    }

    //    /// <summary>
    //    /// Get/Set the ending color of the gradient.
    //    /// </summary>
    //    public Color ToolTipGradientEnd
    //    {
    //        get { return _oToolTipGradientEnd; }
    //        set
    //        {
    //            _oToolTipGradientEnd = value;
    //            if (_cToolTip != null)
    //                _cToolTip.GradientEnd = value;
    //        }
    //    }

    //    /// <summary>
    //    /// The maximum length of the ToolTip in pixels.
    //    /// </summary>
    //    public int ToolTipMaximumLength
    //    {
    //        get { return _iToolTipMaximumLength; }
    //        set
    //        {
    //            _iToolTipMaximumLength = value;
    //            if (_cToolTip != null)
    //                _cToolTip.MaximumLength = value;
    //        }
    //    }

    //    /// <summary>
    //    /// Position the ToolTip text right to left.
    //    /// </summary>
    //    public bool ToolTipRightToLeft
    //    {
    //        get { return _bToolTipRightToLeft; }
    //        set
    //        {
    //            _bToolTipRightToLeft = value;
    //            if (_cToolTip != null)
    //                _cToolTip.TextRightToLeft = value;
    //        }
    //    }

    //    /// <summary>
    //    /// Display the buttons icon in the ToolTip.
    //    /// </summary>
    //    public bool ToolTipUseIcon
    //    {
    //        get { return _bToolTipUseIcon; }
    //        set
    //        {
    //            _bToolTipUseIcon = value;
    //            if (_cToolTip != null)
    //                _cToolTip.UseIcon = value;
    //        }
    //    }

    //    /// <summary>
    //    /// The length of time in milliseconds that the ToolTip remains visible.
    //    /// </summary>
    //    public int ToolTipVisibleTime
    //    {
    //        get { return _iToolTipVisibleTime; }
    //        set
    //        {
    //            _iToolTipVisibleTime = value;
    //            if (_cToolTip != null)
    //                _cToolTip.VisibleTime = value;
    //        }
    //    }
    //    #endregion
    //    #endregion

    //    #region Methods
    //    #region Tab Control
    //    public void Dispose()
    //    {
    //        this.ReleaseHandle();
    //        if (_oTabHeaderBitmap != null) _oTabHeaderBitmap.Dispose();
    //    }

    //    private void drawFocusedTab(Graphics g, Rectangle bounds, LinearGradientMode gradient)
    //    {
    //        // draw using anti alias
    //        using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
    //        {
    //            // create the path
    //            using (GraphicsPath buttonPath = createRoundRectanglePath(
    //                g,
    //                bounds.X, bounds.Y,
    //                bounds.Width, bounds.Height,
    //                1.0f))
    //            {
    //                // draw the outer edge
    //                using (Pen borderPen = new Pen(Color.FromArgb(50, Color.SlateGray), 1f))
    //                    g.DrawPath(borderPen, buttonPath);
    //            }
    //            bounds.Inflate(-1, -1);

    //            using (GraphicsPath buttonPath = createRoundRectanglePath(
    //                g,
    //                bounds.X, bounds.Y,
    //                bounds.Width, bounds.Height,
    //                1.0f))
    //            {
    //                // draw the inner edge
    //                using (Pen borderPen = new Pen(Color.FromArgb(50, TabBorderColor), 1.5f))
    //                    g.DrawPath(borderPen, buttonPath);

    //                // create a thin gradient cover
    //                using (LinearGradientBrush fillBrush = new LinearGradientBrush(
    //                    bounds,
    //                    Color.FromArgb(50, Color.FromArgb(200, Color.White)),
    //                    Color.FromArgb(50, TabGradientEnd),
    //                    gradient))
    //                {
    //                    // shift the blend factors
    //                    Blend blend = new Blend();
    //                    blend.Positions = new float[] { 0f, .3f, .6f, 1f };
    //                    blend.Factors = new float[] { 0f, .5f, .8f, .2f };
    //                    fillBrush.Blend = blend;
    //                    // fill the path
    //                    g.FillPath(fillBrush, buttonPath);
    //                }
    //            }
    //        }
    //    }

    //    private void drawTabControl()
    //    {
    //        // buffer drawing
    //        cStoreDc tempDc = new cStoreDc();
    //        int state = 0;
    //        RECT tabRect = new RECT();
    //        RECT ctlRect = new RECT();
    //        Rectangle headerRect = new Rectangle();
    //        TabControl tab = (TabControl)Control.FromHandle(_hTabControlWnd);
    //        TabAlignment align = tab.Alignment;
    //        Rectangle fillRect = new Rectangle();

    //        // get size and dimension buffer dc
    //        GetWindowRect(_hTabControlWnd, ref ctlRect);
    //        OffsetRect(ref ctlRect, -ctlRect.Left, -ctlRect.Top);
    //        tempDc.Width = ctlRect.Right;
    //        tempDc.Height = ctlRect.Bottom;
    //        Graphics g = Graphics.FromHdc(tempDc.Hdc);

    //        fillRect = new Rectangle(0, 0, ctlRect.Right, ctlRect.Bottom);
    //        // fill and backfill //
    //        if (tab.TabCount > 0)
    //        {
    //            // fill transparent section
    //            headerRect = new Rectangle(0, 0, ctlRect.Right, tab.DisplayRectangle.Y);
    //            using (Brush fillBrush = new SolidBrush(tab.Parent.BackColor))
    //                g.FillRectangle(fillBrush, headerRect);
    //            // backfill the client
    //            headerRect = new Rectangle(0, tab.DisplayRectangle.Y, ctlRect.Right, ctlRect.Bottom - tab.DisplayRectangle.Y);
    //            using (Brush fillBrush = new SolidBrush(tab.Parent.BackColor))
    //                g.FillRectangle(fillBrush, tab.ClientRectangle);
    //        }
    //        else
    //        {
    //            using (Brush fillBrush = new SolidBrush(Color.White))
    //                g.FillRectangle(fillBrush, fillRect);
    //        }

    //        // draw the frame //
    //        //using (Pen darkPen = new Pen(Color.FromKnownColor(KnownColor.ControlDark)))
    //        using (Pen darkPen = new Pen(TabBorderColor)) //tester
    //        {
    //            Rectangle r = tab.DisplayRectangle;
    //            r.Inflate(1, 1);
    //            r.X--;
    //            r.Y--;
    //            g.DrawRectangle(darkPen, r);
    //        }

    //        // draw the tab headers //
    //        for (int i = 0; i < tab.TabCount; i++)
    //        {
    //            // get the header size
    //            SendMessage(_hTabControlWnd, TCM_GETITEMRECT, i, ref tabRect);

    //            // state
    //            if (!tab.Enabled)
    //                state = 3;
    //            else if (tab.SelectedTab == tab.TabPages[i])
    //                state = 2;
    //            else if (Hovering(tabRect))
    //                state = 1;
    //            else
    //                state = 0;

    //            // bitmap mode //
    //            if (TabDrawingStyle == TabRenderStyle.Graphic && _oTabHeaderBitmap != null)
    //            {
    //                int width = _oTabHeaderBitmap.Width / 4;
    //                // create a new bitmap
    //                Bitmap bm;
    //                Bitmap cl;
    //                int xsize = (state != 2) ? (tabRect.Bottom - tabRect.Top) : (tabRect.Bottom - tabRect.Top) - 2;

    //                // to maintain a constant border depth while stretching the bitmap //
    //                if (align == TabAlignment.Bottom || align == TabAlignment.Top)
    //                    bm = new Bitmap(tabRect.Right - tabRect.Left, xsize);
    //                else
    //                    bm = new Bitmap(xsize, tabRect.Right - tabRect.Left);

    //                Graphics gcl = Graphics.FromImage(bm);
    //                // clone the inner portion
    //                cl = _oTabHeaderBitmap.Clone(new Rectangle((state * width) + 2, 2, width - 4, _oTabHeaderBitmap.Height - 2), System.Drawing.Imaging.PixelFormat.DontCare);

    //                // draw to new bmp
    //                if (align == TabAlignment.Bottom || align == TabAlignment.Top)
    //                    gcl.DrawImage(cl, new Rectangle(2, 2, tabRect.Right - tabRect.Left, xsize));
    //                else
    //                    gcl.DrawImage(cl, new Rectangle(2, 2, xsize, tabRect.Right - tabRect.Left));

    //                // clone and draw the edges
    //                // left
    //                cl = _oTabHeaderBitmap.Clone(new Rectangle(state * width, 0, 2, _oTabHeaderBitmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);
    //                gcl.DrawImage(cl, new Rectangle(0, 0, 2, xsize));
    //                cl.Dispose();
    //                // top
    //                cl = _oTabHeaderBitmap.Clone(new Rectangle(state * width + 2, 0, width - 4, 2), System.Drawing.Imaging.PixelFormat.DontCare);
    //                gcl.DrawImage(cl, new Rectangle(2, 0, bm.Width - 4, 2));
    //                cl.Dispose();
    //                //right
    //                cl = _oTabHeaderBitmap.Clone(new Rectangle((state * width) + (width - 2), 0, 2, _oTabHeaderBitmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);
    //                gcl.DrawImage(cl, new Rectangle(bm.Width - 2, 0, 2, xsize));
    //                cl.Dispose();
    //                gcl.Dispose();
    //                Rectangle dstRect = new Rectangle();

    //                // set the base drawing coordinates //
    //                switch (align)
    //                {
    //                    case TabAlignment.Bottom:
    //                        dstRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top);
    //                        bm.RotateFlip(RotateFlipType.Rotate180FlipX);
    //                        if (state == 2)
    //                        {
    //                            dstRect.Height++;
    //                            dstRect.Y--;
    //                        }
    //                        break;
    //                    case TabAlignment.Left:
    //                        dstRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top);
    //                        bm.RotateFlip(RotateFlipType.Rotate90FlipX);
    //                        if (state == 2)
    //                            dstRect.Width++;
    //                        break;
    //                    case TabAlignment.Right:
    //                        dstRect = new Rectangle(tabRect.Left - 1, tabRect.Top, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top);
    //                        bm.RotateFlip(RotateFlipType.Rotate90FlipNone);
    //                        if (state == 2)
    //                        {
    //                            dstRect.Width++;
    //                            dstRect.X--;
    //                        }
    //                        break;
    //                    case TabAlignment.Top:
    //                        dstRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top);
    //                        if (state == 2)
    //                            dstRect.Height++;
    //                        break;
    //                }
    //                // draw the image to temp dc
    //                width = tabRect.Right - tabRect.Left;
    //                Rectangle srcRect = new Rectangle(0, 0, bm.Width, bm.Height);
    //                g.DrawImage(bm, dstRect, srcRect, GraphicsUnit.Pixel);
    //                bm.Dispose();
    //            }
    //            // custom draw //
    //            else
    //            {
    //                Color clBegin = TabGradientBegin;
    //                Color clEnd = TabGradientEnd;
    //                SendMessage(_hTabControlWnd, TCM_GETITEMRECT, i, ref tabRect);
    //                headerRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top);
    //                // gradient color assignment
    //                switch (align)
    //                {
    //                    case TabAlignment.Bottom:
    //                        headerRect.Y -= 2;
    //                        clBegin = TabGradientBegin;
    //                        clEnd = (state == 2) ? TabSelectedColor : TabGradientEnd;
    //                        break;
    //                    case TabAlignment.Left:
    //                        clBegin = TabGradientBegin;
    //                        clEnd = (state == 2) ? TabSelectedColor : TabGradientEnd;
    //                        break;
    //                    case TabAlignment.Right:
    //                        headerRect.X -= 2;
    //                        clEnd = (state == 2) ? TabSelectedColor : TabGradientEnd;
    //                        clBegin = TabGradientBegin;
    //                        break;
    //                    case TabAlignment.Top:
    //                        clBegin = TabGradientBegin;
    //                        clEnd = (state == 2) ? TabSelectedColor : TabGradientEnd;
    //                        break;
    //                }
    //                if (tab.Enabled == false)
    //                {
    //                    clBegin = Color.LightGray;
    //                    clEnd = Color.LightGray;
    //                }
    //                // draw the gradient
    //                fillRect = headerRect;
    //                fillRect.Inflate(-1, -1);
    //                fillRect.Width++;
    //                fillRect.Height++;
    //                drawBlendedGradient(g,
    //                    (align == TabAlignment.Bottom || align == TabAlignment.Top) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal,
    //                    clBegin,
    //                    (state == 1) ? TabFocusedColor : clEnd,
    //                    fillRect,
    //                    TabGradientBlend);
    //                if (state == 1)
    //                {
    //                    // selection mask
    //                    drawFocusedTab(g, headerRect, LinearGradientMode.Vertical);
    //                }
    //                else if (state == 2)
    //                {
    //                    // draw selected tab header frame
    //                    using (Pen darkPen = new Pen(TabBorderColor))
    //                        g.DrawRectangle(darkPen, headerRect);
    //                    // cover edge
    //                    switch (align)
    //                    {
    //                        case TabAlignment.Bottom:
    //                            using (Pen edgePen = new Pen(clBegin))
    //                                g.DrawLine(edgePen, new Point(headerRect.Left + 1, headerRect.Top), new Point(headerRect.Right - 1, headerRect.Top));
    //                            break;
    //                        case TabAlignment.Left:
    //                            using (Pen edgePen = new Pen(clBegin))
    //                                g.DrawLine(edgePen, new Point(headerRect.Right, headerRect.Top + 1), new Point(headerRect.Right, headerRect.Bottom - 1));
    //                            break;
    //                        case TabAlignment.Right:
    //                            using (Pen edgePen = new Pen(clBegin))
    //                                g.DrawLine(edgePen, new Point(headerRect.Left, headerRect.Top + 1), new Point(headerRect.Left, headerRect.Bottom - 1));
    //                            break;
    //                        case TabAlignment.Top:
    //                            using (Pen edgePen = new Pen(clBegin))
    //                                g.DrawLine(edgePen, new Point(headerRect.Left + 1, headerRect.Bottom), new Point(headerRect.Right - 1, headerRect.Bottom));
    //                            break;
    //                    }
    //                }
    //                else
    //                {
    //                    // frame inactive tabs
    //                    using (Pen darkPen = new Pen(Color.FromArgb(100, TabBorderColor)))
    //                        g.DrawRectangle(darkPen, headerRect);
    //                }
    //            }

    //            // draw icon //
    //            int hoffset = 4;
    //            int voffset = 4;
    //            if (tab.ImageList != null)
    //            {
    //                // calculate offsets and draw the icon
    //                int tabpageimageindex = tab.TabPages[i].ImageIndex; // fix: thanks Zhi Chen
    //                if (tabpageimageindex > -1)
    //                {
    //                    if (align == TabAlignment.Top || align == TabAlignment.Bottom)
    //                    {
    //                        voffset = ((tabRect.Bottom - tabRect.Top) - tab.ImageList.Images[tabpageimageindex].Size.Height) / 2;
    //                        hoffset = 4;
    //                        tab.ImageList.Draw(g, new Point(tabRect.Left + hoffset, tabRect.Top + voffset), tab.TabPages[tabpageimageindex].ImageIndex);
    //                        hoffset += tab.ImageList.Images[tabpageimageindex].Size.Width;
    //                    }
    //                    else if (align == TabAlignment.Right)
    //                    {
    //                        hoffset = ((tabRect.Right - tabRect.Left) - tab.ImageList.Images[tabpageimageindex].Size.Width) / 2;
    //                        voffset = 4;
    //                        tab.ImageList.Draw(g, new Point(tabRect.Left + hoffset, tabRect.Top + voffset), tab.TabPages[tabpageimageindex].ImageIndex);
    //                        voffset += tab.ImageList.Images[tabpageimageindex].Size.Height;
    //                    }
    //                    else if (align == TabAlignment.Left)
    //                    {
    //                        hoffset = ((tabRect.Right - tabRect.Left) - tab.ImageList.Images[tabpageimageindex].Size.Width) / 2;
    //                        voffset = (tab.ImageList.Images[i].Size.Height + 4);
    //                        tab.ImageList.Draw(g, new Point(tabRect.Left + hoffset, tabRect.Bottom - voffset), tab.TabPages[tabpageimageindex].ImageIndex);
    //                        voffset = tab.ImageList.Images[tabpageimageindex].Size.Height + 4;
    //                    }
    //                }
    //            }


    //            // draw text //
    //            // text offsets
    //            SizeF sz = g.MeasureString(tab.TabPages[i].Text, tab.Font);
    //            if (align == TabAlignment.Top || align == TabAlignment.Bottom)
    //                voffset = ((tabRect.Bottom - tabRect.Top) - (int)sz.Height) / 2;
    //            else
    //                hoffset = ((tabRect.Right - tabRect.Left) - (int)sz.Height) / 2;

    //            // text graphics
    //            Graphics gx = Graphics.FromHdcInternal(tempDc.Hdc);
    //            using (StringFormat sf = new StringFormat())
    //            {
    //                gx.SmoothingMode = SmoothingMode.AntiAlias;
    //                gx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
    //                sf.Alignment = StringAlignment.Near;
    //                sf.LineAlignment = StringAlignment.Near;
    //                // poition and format
    //                if (align == TabAlignment.Top || align == TabAlignment.Bottom)
    //                {
    //                    hoffset += tabRect.Left;
    //                    voffset += tabRect.Top;
    //                }
    //                else if (align == TabAlignment.Left)
    //                {
    //                    // create 'mirrored' text
    //                    // vertical text
    //                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
    //                    // create a new matrix and rotate
    //                    Matrix mt = new Matrix();
    //                    mt.Rotate(180f);
    //                    // adjust offsets
    //                    voffset += -tabRect.Bottom;
    //                    hoffset += -tabRect.Right;
    //                    // apply the transform
    //                    gx.Transform = mt;

    //                }
    //                else if (align == TabAlignment.Right)
    //                {
    //                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
    //                    hoffset += tabRect.Left;
    //                    voffset += tabRect.Top;
    //                }
    //                // rtl
    //                if (tab.RightToLeftLayout)
    //                    sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
    //                Color foreColor;
    //                if (state == 1)
    //                    foreColor = TabFocusedForeColor;
    //                else if (state == 2)
    //                    foreColor = TabSelectedForeColor;
    //                else
    //                    foreColor = TabForeColor;
    //                // draw the text
    //                using (Brush captionBrush = new SolidBrush(foreColor))
    //                    gx.DrawString(tab.TabPages[i].Text, tab.Font, captionBrush, new RectangleF(hoffset, voffset, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top), sf);
    //            }
    //            gx.Dispose();
    //        }

    //        g.Dispose();
    //        // draw the buffer to the control
    //        g = Graphics.FromHwnd(_hTabControlWnd);
    //        BitBlt(g.GetHdc(), 0, 0, ctlRect.Right, ctlRect.Bottom, tempDc.Hdc, 0, 0, 0xCC0020);
    //        g.ReleaseHdc();
    //        tempDc.Dispose();
    //    }
    //    #endregion

    //    #region Helpers
    //    private GraphicsPath createRoundRectanglePath(Graphics g, float X, float Y, float width, float height, float radius)
    //    {
    //        // create a path
    //        GraphicsPath pathBounds = new GraphicsPath();
    //        pathBounds.AddLine(X + radius, Y, X + width - (radius * 2), Y);
    //        pathBounds.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
    //        pathBounds.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
    //        pathBounds.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
    //        pathBounds.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
    //        pathBounds.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
    //        pathBounds.AddLine(X, Y + height - (radius * 2), X, Y + radius);
    //        pathBounds.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
    //        pathBounds.CloseFigure();
    //        return pathBounds;
    //    }

    //    private void drawBlendedGradient(Graphics g, LinearGradientMode mode, Color begin, Color end, Rectangle rc, Blend bp)
    //    {
    //        using (LinearGradientBrush hb = new LinearGradientBrush(
    //            rc,
    //            begin,
    //            end,
    //            mode))
    //        {
    //            hb.Blend = bp;
    //            g.FillRectangle(hb, rc);
    //        }
    //    }

    //    private bool Hovering(RECT tabHeader)
    //    {
    //        RECT windowRect = new RECT();
    //        Point pos = new Point();

    //        GetWindowRect(_hTabControlWnd, ref windowRect);
    //        OffsetRect(ref tabHeader, windowRect.Left, windowRect.Top);
    //        GetCursorPos(ref pos);
    //        if (PtInRect(ref tabHeader, pos))
    //            return true;
    //        return false;
    //    }
    //    #endregion

    //    #region ToolTip
    //    private TabPage overPage()
    //    {
    //        TabControl tab = (TabControl)Control.FromHandle(_hTabControlWnd);
    //        RECT tabRect = new RECT();
    //        if (tab != null)
    //        {
    //            for (int i = 0; i < tab.TabCount; i++)
    //            {
    //                SendMessage(_hTabControlWnd, TCM_GETITEMRECT, i, ref tabRect);
    //                if (Hovering(tabRect))
    //                    return tab.TabPages[i];
    //            }
    //        }
    //        return null;
    //    }

    //    private void toolTipStart(TabPage item)
    //    {
    //        if ((_cToolTip != null) && (ToolTipEnable))
    //        {
    //            if (item != _oLastFocusedPage)
    //            {
    //                toolTipStop();
    //                _oLastFocusedPage = item;
    //                _bToolTipShown = false;
    //            }
    //            else
    //            {
    //                if (_bToolTipShown)
    //                    return;
    //            }
    //            Rectangle bounds = new Rectangle();
    //            RECT tabRect = new RECT();
    //            if (_oToolTipText.ContainsKey(item))
    //            {
    //                string caption = _oToolTipText[item];
    //                string title = String.Empty;
    //                if (_oToolTipTitle.ContainsKey(item))
    //                    title = _oToolTipTitle[item];
    //                TabControl tab = (TabControl)Control.FromHandle(_hTabControlWnd);
    //                SendMessage(_hTabControlWnd, TCM_GETITEMRECT, tab.TabPages.IndexOf(item), ref tabRect);

    //                bounds.X = tabRect.Left + 10;
    //                bounds.Y = tabRect.Bottom + 10;
    //                bounds.Width = ToolTipMaximumLength;
    //                bounds.Height = 20;
    //                _cToolTip.UseIcon = ToolTipUseIcon;
    //                Bitmap bmp = null;
    //                if (ToolTipUseIcon)
    //                {
    //                    if (tab.ImageList != null && item.ImageIndex > -1)
    //                    {
    //                        Size imageSize = tab.ImageList.ImageSize;
    //                        bmp = new Bitmap(tab.ImageList.Images[item.ImageIndex], imageSize);
    //                    }
    //                }
    //                _cToolTip.Start(title, caption, bmp, bounds);
    //                _bToolTipShown = true;
    //            }
    //        }
    //    }

    //    private void toolTipStop()
    //    {
    //        if (_cToolTip != null)
    //            _cToolTip.Stop();
    //    }

    //    public void ToolTipTitle(TabPage item, string title)
    //    {
    //        if (!String.IsNullOrEmpty(title))
    //        {
    //            _oToolTipTitle.Add(item, title);
    //        }
    //    }

    //    public void UseCustomToolTips(TabControl tab)
    //    {
    //        tab.MouseMove += new MouseEventHandler(tab_MouseMove);
    //        tab.MouseLeave += new EventHandler(tab_MouseLeave);
    //        tab.MouseDown += new MouseEventHandler(tab_MouseDown);
    //        tab.ControlAdded += new ControlEventHandler(tab_ControlAdded);
    //        tab.ControlRemoved += new ControlEventHandler(tab_ControlRemoved);
    //        tab.HandleDestroyed += new EventHandler(tab_HandleDestroyed);
    //        tab.HandleCreated += new EventHandler(tab_HandleCreated);
    //        _oToolTipTitle.Clear();
    //        _oToolTipText.Clear();
    //        foreach (TabPage item in tab.TabPages)
    //        {
    //            if (!String.IsNullOrEmpty(item.ToolTipText))
    //            {
    //                _oToolTipText.Add(item, item.ToolTipText);
    //                item.ToolTipText = "";
    //            }
    //        }
    //        if (_oToolTipText.Count > 0)
    //        {
    //            _cToolTip = new cToolTip(tab.Handle);
    //            _cToolTip.TextRightToLeft = ToolTipRightToLeft;
    //            ToolTipEnable = true;
    //        }
    //    }
    //    #endregion
    //    #endregion

    //    #region WndProc
    //    protected override void WndProc(ref Message m)
    //    {
    //        PAINTSTRUCT ps = new PAINTSTRUCT();
    //        switch (m.Msg)
    //        {
    //            case WM_PAINT:
    //                if (!_bPainting)
    //                {
    //                    _bPainting = true;
    //                    // start painting engine
    //                    BeginPaint(m.HWnd, ref ps);
    //                    drawTabControl();
    //                    ValidateRect(m.HWnd, ref ps.rcPaint);
    //                    // done
    //                    EndPaint(m.HWnd, ref ps);
    //                    _bPainting = false;
    //                    m.Result = MSG_HANDLED;
    //                }
    //                else
    //                {
    //                    base.WndProc(ref m);
    //                }
    //                break;

    //            case WM_MOUSEMOVE:
    //                // only necessary if vertically aligned..
    //                drawTabControl();
    //                base.WndProc(ref m);
    //                break;

    //            case WM_MOUSELEAVE:
    //                drawTabControl();
    //                base.WndProc(ref m);
    //                break;

    //            default:
    //                base.WndProc(ref m);
    //                break;
    //        }
    //    }
    //    #endregion
    //}

    //#region ToolTip
    ///*[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    //internal class ToolTip : NativeWindow
    //{
    //    #region Constants
    //    // setwindowpos
    //    static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
    //    static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
    //    static readonly IntPtr HWND_TOP = new IntPtr(0);
    //    static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
    //    // size/move
    //    private const uint SWP_NOSIZE = 0x0001;
    //    private const uint SWP_NOMOVE = 0x0002;
    //    private const uint SWP_NOZORDER = 0x0004;
    //    private const uint SWP_NOREDRAW = 0x0008;
    //    private const uint SWP_NOACTIVATE = 0x0010;
    //    private const uint SWP_FRAMECHANGED = 0x0020;
    //    private const uint SWP_SHOWWINDOW = 0x0040;
    //    private const uint SWP_HIDEWINDOW = 0x0080;
    //    private const uint SWP_NOCOPYBITS = 0x0100;
    //    private const uint SWP_NOOWNERZORDER = 0x0200;
    //    private const uint SWP_NOSENDCHANGING = 0x0400;
    //    // styles
    //    private const int TTS_ALWAYSTIP = 0x01;
    //    private const int TTS_NOPREFIX = 0x02;
    //    private const int TTS_NOANIMATE = 0x10;
    //    private const int TTS_NOFADE = 0x20;
    //    private const int TTS_BALLOON = 0x40;
    //    private const int TTS_CLOSE = 0x80;
    //    private const int TTS_USEVISUALSTYLE = 0x100;
    //    // window messages
    //    private const int WM_NOTIFY = 0x4E;
    //    private const int WM_REFLECT = 0x2000;
    //    private const int WM_PAINT = 0xF;
    //    private const int WM_SIZE = 0x5;
    //    private const int WM_MOVE = 0x3;
    //    private const int WM_SETFONT = 0x30;
    //    private const int WM_GETFONT = 0x31;
    //    private const int WM_SHOWWINDOW = 0x18;
    //    private const int WM_MOUSEMOVE = 0x200;
    //    private const int WM_MOUSELEAVE = 0x2A3;
    //    private const int WM_LBUTTONDOWN = 0x201;
    //    private const int WM_LBUTTONUP = 0x202;
    //    private const int WM_LBUTTONDBLCLK = 0x203;
    //    private const int WM_RBUTTONDOWN = 0x204;
    //    private const int WM_RBUTTONUP = 0x205;
    //    private const int WM_RBUTTONDBLCLK = 0x206;
    //    private const int WM_MBUTTONDOWN = 0x207;
    //    private const int WM_MBUTTONUP = 0x208;
    //    private const int WM_MBUTTONDBLCLK = 0x209;
    //    private const int WM_MOUSEWHEEL = 0x20A;
    //    private const int WM_TIMER = 0x113;
    //    private const int WM_NCPAINT = 0x85;
    //    private const int WM_DESTROY = 0x2;
    //    private const int WM_SETFOCUS = 0x7;
    //    private const int WM_KILLFOCUS = 0x8;
    //    private const int WM_IME_NOTIFY = 0x282;
    //    private const int WM_IME_SETCONTEXT = 0x281;
    //    private const int WM_ACTIVATE = 0x6;
    //    private const int WM_NCACTIVATE = 0x86;
    //    private const int WM_STYLECHANGED = 0x7d;
    //    private const int WM_STYLECHANGING = 0x7c;
    //    private const int WM_WINDOWPOSCHANGING = 0x46;
    //    private const int WM_WINDOWPOSCHANGED = 0x47;
    //    private const int WM_NCCALCSIZE = 0x83;
    //    private const int WM_CTLCOLOR = 0x3d8d610;
    //    // window styles
    //    private const int GWL_STYLE = (-16);
    //    private const int GWL_EXSTYLE = (-20);
    //    private const int SS_OWNERDRAW = 0xD;
    //    private const int WS_OVERLAPPED = 0x0;
    //    private const int WS_TABSTOP = 0x10000;
    //    private const int WS_THICKFRAME = 0x40000;
    //    private const int WS_HSCROLL = 0x100000;
    //    private const int WS_VSCROLL = 0x200000;
    //    private const int WS_BORDER = 0x800000;
    //    private const int WS_CLIPCHILDREN = 0x2000000;
    //    private const int WS_CLIPSIBLINGS = 0x4000000;
    //    private const int WS_VISIBLE = 0x10000000;
    //    private const int WS_CHILD = 0x40000000;
    //    private const int WS_POPUP = -2147483648;
    //    // window extended styles
    //    private const int WS_EX_LTRREADING = 0x0;
    //    private const int WS_EX_LEFT = 0x0;
    //    private const int WS_EX_RIGHTSCROLLBAR = 0x0;
    //    private const int WS_EX_DLGMODALFRAME = 0x1;
    //    private const int WS_EX_NOPARENTNOTIFY = 0x4;
    //    private const int WS_EX_TOPMOST = 0x8;
    //    private const int WS_EX_ACCEPTFILES = 0x10;
    //    private const int WS_EX_TRANSPARENT = 0x20;
    //    private const int WS_EX_MDICHILD = 0x40;
    //    private const int WS_EX_TOOLWINDOW = 0x80;
    //    private const int WS_EX_WINDOWEDGE = 0x100;
    //    private const int WS_EX_CLIENTEDGE = 0x200;
    //    private const int WS_EX_CONTEXTHELP = 0x400;
    //    private const int WS_EX_RIGHT = 0x1000;
    //    private const int WS_EX_RTLREADING = 0x2000;
    //    private const int WS_EX_LEFTSCROLLBAR = 0x4000;
    //    private const int WS_EX_CONTROLPARENT = 0x10000;
    //    private const int WS_EX_STATICEDGE = 0x20000;
    //    private const int WS_EX_APPWINDOW = 0x40000;
    //    private const int WS_EX_NOACTIVATE = 0x8000000;
    //    private const int WS_EX_LAYERED = 0x80000;
    //    #endregion

    //    #region Structs
    //    [StructLayout(LayoutKind.Sequential)]
    //    private struct RECT
    //    {
    //        private RECT(int X, int Y, int Width, int Height)
    //        {
    //            this.Left = X;
    //            this.Top = Y;
    //            this.Right = Width;
    //            this.Bottom = Height;
    //        }
    //        internal int Left;
    //        internal int Top;
    //        internal int Right;
    //        internal int Bottom;
    //    }
    //    #endregion

    //    #region API
    //    [DllImport("user32.dll", SetLastError = true)]
    //    private static extern IntPtr CreateWindowEx(int exstyle, string lpClassName, string lpWindowName, int dwStyle,
    //        int x, int y, int nWidth, int nHeight, IntPtr hwndParent, IntPtr Menu, IntPtr hInstance, IntPtr lpParam);

    //    [DllImport("user32.dll")]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    private static extern bool DestroyWindow(IntPtr hWnd);

    //    [DllImport("user32.dll", SetLastError = false)]
    //    private static extern IntPtr GetDesktopWindow();

    //    [DllImport("user32.dll", ExactSpelling = true)]
    //    private static extern IntPtr SetTimer(IntPtr hWnd, int nIDEvent, uint uElapse, IntPtr lpTimerFunc);

    //    [DllImport("user32.dll", ExactSpelling = true)]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    private static extern bool KillTimer(IntPtr hWnd, uint uIDEvent);

    //    [DllImport("user32.dll")]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int x, int y, int cx, int cy, uint flags);

    //    [DllImport("user32.dll")]
    //    private static extern bool GetClientRect(IntPtr hWnd, ref RECT r);

    //    [DllImport("user32.dll")]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

    //    [DllImport("user32.dll")]
    //    private static extern int GetWindowLong(IntPtr hwnd, int nIndex);

    //    [DllImport("user32.dll")]
    //    private static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

    //    [DllImport("user32.dll")]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    private static extern bool GetCursorPos(ref Point lpPoint);

    //    [DllImport("user32.dll")]
    //    private static extern bool ScreenToClient(IntPtr hWnd, ref Point lpPoint);

    //    [DllImport("user32.dll")]
    //    private static extern IntPtr GetDC(IntPtr handle);

    //    [DllImport("user32.dll")]
    //    private static extern int ReleaseDC(IntPtr handle, IntPtr hdc);

    //    [DllImport("gdi32.dll")]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
    //    #endregion

    //    #region Fields
    //    private bool _timerActive = false;
    //    private bool _tipShowing = false;
    //    private bool _textRightToLeft = false;
    //    private bool _useIcon = false;
    //    private int _timerTick = 0;
    //    private int _delayTime = 1000;
    //    private int _visibleTime = 2000;
    //    private string _clientCaption = String.Empty;
    //    private string _clientTitle = String.Empty;
    //    private Color _foreColor = Color.Black;
    //    private Color _gradientBegin = Color.White;
    //    private Color _gradientEnd = Color.Silver;
    //    private IntPtr _hTipWnd = IntPtr.Zero;
    //    private IntPtr _hInstance = IntPtr.Zero;
    //    private IntPtr _hParentWnd = IntPtr.Zero;
    //    private Rectangle _clientBounds = new Rectangle();
    //    private Font _titleFont;
    //    private Font _captionFont;
    //    private Bitmap _clientImage = null;
    //    #endregion

    //    #region Constructor
    //    public ToolTip(IntPtr hParentWnd)
    //    {
    //        Type t = typeof(ToolTip);
    //        Module m = t.Module;
    //        _hInstance = Marshal.GetHINSTANCE(m);
    //        _hParentWnd = hParentWnd;
    //        // create window
    //        _hTipWnd = CreateWindowEx(WS_EX_TOPMOST | WS_EX_TOOLWINDOW,
    //            "STATIC", "",
    //            SS_OWNERDRAW | WS_CHILD | WS_CLIPSIBLINGS | WS_OVERLAPPED,
    //            0, 0,
    //            0, 0,
    //            GetDesktopWindow(),
    //            IntPtr.Zero, _hInstance, IntPtr.Zero);
    //        // set starting position
    //        SetWindowPos(_hTipWnd, HWND_TOP,
    //            0, 0,
    //            0, 0,
    //            SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE | SWP_NOOWNERZORDER);
    //        createFonts();
    //        this.AssignHandle(_hTipWnd);
    //    }
    //    #endregion

    //    #region Properties
    //    private Rectangle TipBounds
    //    {
    //        get { return _clientBounds; }
    //        set { _clientBounds = value; }
    //    }

    //    private string Caption
    //    {
    //        get { return _clientCaption; }
    //        set { _clientCaption = value; }
    //    }

    //    public int DelayTime
    //    {
    //        get { return _delayTime; }
    //        set { _delayTime = value; }
    //    }

    //    public Color ForeColor
    //    {
    //        get { return _foreColor; }
    //        set { _foreColor = value; }
    //    }

    //    public Color GradientBegin
    //    {
    //        get { return _gradientBegin; }
    //        set { _gradientBegin = value; }
    //    }

    //    public Color GradientEnd
    //    {
    //        get { return _gradientEnd; }
    //        set { _gradientEnd = value; }
    //    }

    //    public Bitmap ItemImage
    //    {
    //        get { return _clientImage; }
    //        set { _clientImage = value; }
    //    }

    //    public int MaximumLength
    //    {
    //        set { _clientBounds.Width = value; }
    //    }

    //    public bool TextRightToLeft
    //    {
    //        get { return _textRightToLeft; }
    //        set { _textRightToLeft = value; }
    //    }

    //    private string Title
    //    {
    //        get { return _clientTitle; }
    //        set { _clientTitle = value; }
    //    }

    //    public bool UseIcon
    //    {
    //        get { return _useIcon; }
    //        set { _useIcon = value; }
    //    }

    //    public int VisibleTime
    //    {
    //        get { return _visibleTime; }
    //        set { _visibleTime = value; }
    //    }
    //    #endregion

    //    #region Public Methods
    //    public void Start(string title, string caption, Bitmap image, Rectangle bounds)
    //    {
    //        if (_timerActive)
    //            Stop();
    //        destroyImage();
    //        Title = title;
    //        Caption = caption;
    //        ItemImage = image;
    //        TipBounds = bounds;
    //        SetTimer(_hTipWnd, 1, 100, IntPtr.Zero);
    //    }

    //    public void Stop()
    //    {
    //        // kill the timer
    //        KillTimer(_hTipWnd, 1);
    //        // hide the window
    //        showWindow(false);
    //        // reset properties
    //        Title = String.Empty;
    //        Caption = String.Empty;
    //        ItemImage = null;
    //        TipBounds = Rectangle.Empty;
    //        // reset timer values
    //        _timerTick = 0;
    //        _tipShowing = false;
    //        _timerActive = false;
    //    }

    //    public void Dispose()
    //    {
    //        if (_hTipWnd != IntPtr.Zero)
    //        {
    //            this.ReleaseHandle();
    //            destroyFonts();
    //            destroyImage();
    //            DestroyWindow(_hTipWnd);
    //            _hTipWnd = IntPtr.Zero;
    //        }
    //    }
    //    #endregion

    //    #region Internal Methods
    //    private Rectangle calculateSize()
    //    {
    //        SizeF textSize = new SizeF();
    //        SizeF titleSize = new SizeF();

    //        // calculate text
    //        if (!String.IsNullOrEmpty(Caption))
    //            textSize = calcTextSize(Caption, _captionFont, 0);
    //        // calc title
    //        if (!String.IsNullOrEmpty(Title))
    //            titleSize = calcTextSize(Title, _titleFont, 0);
    //        if (textSize.Width < titleSize.Width)
    //            textSize.Width = titleSize.Width;
    //        if (titleSize.Height > 0)
    //            textSize.Height += (titleSize.Height + 4);
    //        // calc icon
    //        if ((ItemImage != null) && (UseIcon))
    //        {
    //            textSize.Height += 8;
    //            textSize.Width += ItemImage.Size.Width + 8;
    //        }
    //        else
    //        {
    //            textSize.Height += 4;
    //            textSize.Width += 4;
    //        }
    //        Rectangle bounds = new Rectangle(0, 0, (int)textSize.Width, (int)textSize.Height);
    //        bounds.Inflate(4, 4);
    //        bounds.Offset(4, 4);
    //        return bounds;
    //    }

    //    private SizeF calcTextSize(string text, Font font, int width)
    //    {
    //        SizeF sF = new SizeF();
    //        IntPtr hdc = GetDC(_hTipWnd);
    //        Graphics g = Graphics.FromHdc(hdc);
    //        if (width > 0)
    //            sF = g.MeasureString(text, font, width);
    //        else
    //            sF = g.MeasureString(text, font);
    //        ReleaseDC(_hTipWnd, hdc);
    //        g.Dispose();
    //        return sF;
    //    }

    //    private void copyBackground(Graphics g)
    //    {
    //        RECT windowRect = new RECT();
    //        GetWindowRect(_hTipWnd, ref windowRect);
    //        g.CopyFromScreen(windowRect.Left, windowRect.Top, 0, 0, new Size(windowRect.Right - windowRect.Left, windowRect.Bottom - windowRect.Top), CopyPixelOperation.SourceCopy);
    //    }

    //    private void createFonts()
    //    {
    //        _titleFont = new Font("Tahoma", 8, FontStyle.Bold);
    //        _captionFont = new Font("Tahoma", 8, FontStyle.Regular);
    //    }

    //    private GraphicsPath createRoundRectanglePath(Graphics g, float X, float Y, float width, float height, float radius)
    //    {
    //        // create a path
    //        GraphicsPath pathBounds = new GraphicsPath();
    //        pathBounds.AddLine(X + radius, Y, X + width - (radius * 2), Y);
    //        pathBounds.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
    //        pathBounds.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
    //        pathBounds.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
    //        pathBounds.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
    //        pathBounds.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
    //        pathBounds.AddLine(X, Y + height - (radius * 2), X, Y + radius);
    //        pathBounds.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
    //        pathBounds.CloseFigure();
    //        return pathBounds;
    //    }

    //    private void destroyFonts()
    //    {
    //        if (_titleFont != null)
    //            _titleFont.Dispose();
    //        if (_captionFont != null)
    //            _captionFont.Dispose();
    //    }

    //    private void destroyImage()
    //    {
    //        if (ItemImage != null)
    //            ItemImage.Dispose();
    //        ItemImage = null;
    //    }

    //    private void drawBackground(IntPtr hdc)
    //    {
    //        // create the graphics instance
    //        Graphics g = Graphics.FromHdc(hdc);
    //        // copy in the background to mimic transparency
    //        copyBackground(g);
    //        // create the shadow rect
    //        Rectangle shadowArea = new Rectangle(3, TipBounds.Height - 3, TipBounds.Width - 3, TipBounds.Height);
    //        // draw the bottom shadow
    //        using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
    //        {
    //            using (GraphicsPath shadowPath = createRoundRectanglePath(g, 4, TipBounds.Height - 4, TipBounds.Width - 4, TipBounds.Height, 1f))
    //            {
    //                using (LinearGradientBrush shadowBrush = new LinearGradientBrush(shadowArea, Color.FromArgb(100, 0x99, 0x99, 0x99), Color.FromArgb(60, 0x44, 0x44, 0x44), LinearGradientMode.Vertical))
    //                {
    //                    Blend blend = new Blend();
    //                    blend.Positions = new float[] { 0f, .3f, .6f, 1f };
    //                    blend.Factors = new float[] { 0f, .3f, .6f, .9f };
    //                    shadowBrush.Blend = blend;
    //                    g.FillPath(shadowBrush, shadowPath);
    //                }
    //            }
    //            // draw the right shadow
    //            using (GraphicsPath shadowPath = createRoundRectanglePath(g, TipBounds.Width - 4, 4, TipBounds.Width - 4, TipBounds.Height - 8, 1f))
    //            {
    //                using (LinearGradientBrush shadowBrush = new LinearGradientBrush(shadowArea, Color.FromArgb(100, 0x99, 0x99, 0x99), Color.FromArgb(60, 0x44, 0x44, 0x44), LinearGradientMode.Horizontal))
    //                {
    //                    Blend blend = new Blend();
    //                    blend.Positions = new float[] { 0f, .3f, .6f, 1f };
    //                    blend.Factors = new float[] { 0f, .3f, .6f, .9f };
    //                    shadowBrush.Blend = blend;
    //                    g.FillPath(shadowBrush, shadowPath);
    //                }
    //            }
    //            // adjust the bounds
    //            Rectangle fillBounds = new Rectangle(0, 0, TipBounds.Width - 4, TipBounds.Height - 4);
    //            using (GraphicsPath fillPath = createRoundRectanglePath(g, fillBounds.X, fillBounds.Y, fillBounds.Width, fillBounds.Height, 2f))
    //            {
    //                using (LinearGradientBrush shadowBrush = new LinearGradientBrush(shadowArea, GradientBegin, GradientEnd, LinearGradientMode.Vertical))
    //                {
    //                    // draw the frame
    //                    using (Pen fillPen = new Pen(Color.FromArgb(250, 0x44, 0x44, 0x44)))
    //                        g.DrawPath(fillPen, fillPath);
    //                    // fill the body
    //                    Blend blend = new Blend();
    //                    blend.Positions = new float[] { 0f, .4f, .6f, 1f };
    //                    blend.Factors = new float[] { 0f, .3f, .6f, .8f };
    //                    shadowBrush.Blend = blend;
    //                    g.FillPath(shadowBrush, fillPath);
    //                }
    //            }
    //        }
    //        g.Dispose();
    //    }

    //    private void drawCaption(IntPtr hdc)
    //    {
    //        Graphics g = Graphics.FromHdc(hdc);
    //        using (StringFormat sF = new StringFormat())
    //        {
    //            int vOffset;
    //            int hOffset;

    //            if ((ItemImage != null) && (UseIcon))
    //            {
    //                vOffset = ItemImage.Size.Width + 8;
    //                if (!String.IsNullOrEmpty(Title))
    //                    hOffset = (ItemImage.Size.Height / 2) + (_titleFont.Height);
    //                else
    //                    hOffset = (TipBounds.Height - ItemImage.Size.Height) / 2;
    //            }
    //            else if (!String.IsNullOrEmpty(Title))
    //            {
    //                vOffset = 4;
    //                hOffset = (_titleFont.Height + 8);
    //            }
    //            else
    //            {
    //                vOffset = 4;
    //                hOffset = 4;
    //            }

    //            sF.Alignment = StringAlignment.Near;
    //            sF.LineAlignment = StringAlignment.Near;
    //            if (TextRightToLeft)
    //                sF.FormatFlags = StringFormatFlags.DirectionRightToLeft;
    //            using (Brush captionBrush = new SolidBrush(ForeColor))
    //                g.DrawString(Caption, _captionFont, captionBrush, new RectangleF(vOffset, hOffset, TipBounds.Width - vOffset, TipBounds.Height - hOffset), sF);
    //        }
    //        g.Dispose();
    //    }

    //    private void drawIcon(IntPtr hdc)
    //    {
    //        if (ItemImage != null)
    //        {
    //            Graphics g = Graphics.FromHdc(hdc);
    //            g.DrawImage(ItemImage, new Point(4, 4));
    //            g.Dispose();
    //        }
    //    }

    //    private void drawTitle(IntPtr hdc)
    //    {
    //        Graphics g = Graphics.FromHdc(hdc);
    //        using (StringFormat sF = new StringFormat())
    //        {
    //            int vOffset;
    //            int hOffset;

    //            if ((ItemImage != null) && (UseIcon))
    //            {
    //                vOffset = ItemImage.Size.Width + 8;
    //                hOffset = (ItemImage.Size.Height / 2) + 2;
    //            }
    //            else
    //            {
    //                vOffset = 4;
    //                hOffset = 12;
    //            }

    //            sF.Alignment = StringAlignment.Near;
    //            sF.LineAlignment = StringAlignment.Center;
    //            sF.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
    //            sF.FormatFlags = StringFormatFlags.NoWrap;

    //            if (TextRightToLeft)
    //                sF.FormatFlags = StringFormatFlags.DirectionRightToLeft;
    //            using (Brush titleBrush = new SolidBrush(ForeColor))
    //                g.DrawString(Title, _titleFont, titleBrush, new PointF(vOffset, hOffset), sF);
    //        }
    //        g.Dispose();
    //    }

    //    private void positionWindow()
    //    {
    //        if (_hTipWnd != IntPtr.Zero)
    //        {
    //            // offset with screen position
    //            RECT windowRect = new RECT();
    //            GetWindowRect(_hParentWnd, ref windowRect);
    //            windowRect.Left += TipBounds.X;
    //            windowRect.Top += TipBounds.Y;
    //            // position the window
    //            SetWindowPos(_hTipWnd, HWND_TOPMOST, windowRect.Left, windowRect.Top, TipBounds.Width, TipBounds.Height, SWP_SHOWWINDOW | SWP_NOACTIVATE);
    //        }
    //    }

    //    private void renderTip()
    //    {
    //        if ((Caption != String.Empty) && (TipBounds != Rectangle.Empty))
    //        {
    //            // create the canvas
    //            _clientBounds.Height = 50;
    //            Rectangle bounds = calculateSize();
    //            bounds.X = TipBounds.X;
    //            bounds.Y = TipBounds.Y;
    //            TipBounds = bounds;
    //            cStoreDc drawDc = new cStoreDc();
    //            drawDc.Width = TipBounds.Width;
    //            drawDc.Height = TipBounds.Height;
    //            positionWindow();
    //            // show the window
    //            showWindow(true);
    //            // draw the background to the temp dc
    //            drawBackground(drawDc.Hdc);
    //            // draw image and text
    //            if ((ItemImage != null) && (UseIcon))
    //                drawIcon(drawDc.Hdc);
    //            if (Title != String.Empty)
    //                drawTitle(drawDc.Hdc);
    //            drawCaption(drawDc.Hdc);
    //            // draw the tempdc to the window
    //            IntPtr hdc = GetDC(_hTipWnd);
    //            BitBlt(hdc, 0, 0, TipBounds.Width, TipBounds.Height, drawDc.Hdc, 0, 0, 0xCC0020);
    //            ReleaseDC(_hTipWnd, hdc);
    //            // cleanup
    //            drawDc.Dispose();
    //        }
    //    }

    //    private void showWindow(bool show)
    //    {
    //        if (show)
    //            SetWindowPos(_hTipWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_SHOWWINDOW | SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE);
    //        else
    //            SetWindowPos(_hTipWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_HIDEWINDOW | SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE);
    //    }
    //    #endregion

    //    #region WndProc
    //    protected override void WndProc(ref Message m)
    //    {
    //        switch (m.Msg)
    //        {
    //            case WM_TIMER:
    //                _timerTick++;
    //                if (_timerTick > (DelayTime / 100))
    //                {
    //                    if (!_tipShowing)
    //                    {
    //                        _tipShowing = true;
    //                        renderTip();
    //                    }
    //                }
    //                if (_timerTick > ((DelayTime + VisibleTime) / 100))
    //                    Stop();
    //                base.WndProc(ref m);
    //                break;

    //            default:
    //                base.WndProc(ref m);
    //                break;
    //        }
    //    }
    //    #endregion
    //}*/
    //#endregion
}
