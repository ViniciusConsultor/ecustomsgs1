namespace System.Windows.Forms.RCM
{
    #region Directives
    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Drawing;
    using System.Reflection;
    using System.Drawing.Drawing2D;
    #endregion

    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class cToolTip : NativeWindow
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
        private bool _bTimerActive = false;
        private bool _bTipShowing = false;
        private bool _bTextRightToLeft = false;
        private bool _bUseIcon = false;
        private int _iTimerTick = 0;
        private int _iDelayTime = 1000;
        private int _iVisibleTime = 2000;
        private string _sClientCaption = String.Empty;
        private string _sClientTitle = String.Empty;
        private Color _oForeColor = Color.Black;
        private Color _oGradientBegin = Color.White;
        private Color _oGradientEnd = Color.Silver;
        private IntPtr _hTipWnd = IntPtr.Zero;
        private IntPtr _hInstance = IntPtr.Zero;
        private IntPtr _hParentWnd = IntPtr.Zero;
        private Rectangle _tClientBounds = new Rectangle();
        private Font _oTitleFont;
        private Font _oCaptionFont;
        private Bitmap _oClientImage = null;
        #endregion

        #region Constructor
        public cToolTip(IntPtr hParentWnd)
        {
            Type t = typeof(cToolTip);
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
            get { return _tClientBounds; }
            set { _tClientBounds = value; }
        }

        private string Caption
        {
            get { return _sClientCaption; }
            set { _sClientCaption = value; }
        }

        public int DelayTime
        {
            get { return _iDelayTime; }
            set { _iDelayTime = value; }
        }

        public Color ForeColor
        {
            get { return _oForeColor; }
            set { _oForeColor = value; }
        }

        public Color GradientBegin
        {
            get { return _oGradientBegin; }
            set { _oGradientBegin = value; }
        }

        public Color GradientEnd
        {
            get { return _oGradientEnd; }
            set { _oGradientEnd = value; }
        }

        public Bitmap ItemImage
        {
            get { return _oClientImage; }
            set { _oClientImage = value; }
        }

        public int MaximumLength
        {
            set { _tClientBounds.Width = value; }
        }

        public bool TextRightToLeft
        {
            get { return _bTextRightToLeft; }
            set { _bTextRightToLeft = value; }
        }

        private string Title
        {
            get { return _sClientTitle; }
            set { _sClientTitle = value; }
        }

        public bool UseIcon
        {
            get { return _bUseIcon; }
            set { _bUseIcon = value; }
        }

        public int VisibleTime
        {
            get { return _iVisibleTime; }
            set { _iVisibleTime = value; }
        }
        #endregion

        #region Public Methods
        public void Start(string title, string caption, Bitmap image, Rectangle bounds)
        {
            if (_bTimerActive)
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
            _iTimerTick = 0;
            _bTipShowing = false;
            _bTimerActive = false;
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
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Internal Methods
        private Rectangle calculateSize()
        {
            SizeF textSize = new SizeF();
            SizeF titleSize = new SizeF();

            // calculate text
            if (!String.IsNullOrEmpty(Caption))
                textSize = calcTextSize(Caption, _oCaptionFont, 0);
            // calc title
            if (!String.IsNullOrEmpty(Title))
                titleSize = calcTextSize(Title, _oTitleFont, 0);
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
            _oTitleFont = new Font("Tahoma", 8, FontStyle.Bold);
            _oCaptionFont = new Font("Tahoma", 8, FontStyle.Regular);
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
            if (_oTitleFont != null)
                _oTitleFont.Dispose();
            if (_oCaptionFont != null)
                _oCaptionFont.Dispose();
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
                        hOffset = (ItemImage.Size.Height / 2) + (_oTitleFont.Height);
                    else
                        hOffset = (TipBounds.Height - ItemImage.Size.Height) / 2;
                }
                else if (!String.IsNullOrEmpty(Title))
                {
                    vOffset = 4;
                    hOffset = (_oTitleFont.Height + 8);
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
                    g.DrawString(Caption, _oCaptionFont, captionBrush, new RectangleF(vOffset, hOffset, TipBounds.Width - vOffset, TipBounds.Height - hOffset), sF);
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
                    g.DrawString(Title, _oTitleFont, titleBrush, new PointF(vOffset, hOffset), sF);
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
                _tClientBounds.Height = 50;
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
                    _iTimerTick++;
                    if (_iTimerTick > (DelayTime / 100))
                    {
                        if (!_bTipShowing)
                        {
                            _bTipShowing = true;
                            renderTip();
                        }
                    }
                    if (_iTimerTick > ((DelayTime + VisibleTime) / 100))
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
}
