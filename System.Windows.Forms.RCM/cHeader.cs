namespace System.Windows.Forms.RCM
{
    #region Directives
    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Text;
    #endregion
 
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class cHeader : NativeWindow, IDisposable
    {
        #region Constants
        // misc
        private const int GWL_STYLE = (-16);
        private const int GWL_EXSTYLE = (-20);
        private const int WS_ENABLED = 0x02;
        private const int CLR_NONE = -1;
        private const int ILD_TRANSPARENT = 0x1;
        // mouse buttons
        private const int VK_LBUTTON = 0x1;
        private const int VK_RBUTTON = 0x2;
        private const int SM_SWAPBUTTON = 23;
        // theming
        private const int HP_HEADERSORTARROW = 4;
        private const int HSAS_SORTEDUP = 1;
        private const int HSAS_SORTEDDOWN = 2;

        // header flags
        private const int HDF_LEFT = 0x0000;
        private const int HDF_RIGHT = 0x0001;
        private const int HDF_CENTER = 0x0002;
        private const int HDF_JUSTIFYMASK = 0x0003;
        private const int HDF_RTLREADING = 4;
        private const int HDF_OWNERDRAW = 0x8000;
        private const int HDF_STRING = 0x4000;
        private const int HDF_BITMAP = 0x2000;
        private const int HDF_BITMAP_ON_RIGHT = 0x1000;
        private const int HDF_IMAGE = 0x0800;
        private const int HDF_SORTUP = 0x0400;
        private const int HDF_SORTDOWN = 0x0200;
        private const int HDF_CHECKBOX = 0x0040;
        private const int HDF_CHECKED = 0x0080;
        private const int HDF_FIXEDWIDTH = 0x0100;
        private const int HDF_SPLITBUTTON = 0x1000000;
        private const int HDFT_ISSTRING = 0x0000;
        private const int HDFT_ISNUMBER = 0x0001;
        private const int HDFT_ISDATE = 0x0002;
        private const int HDFT_HASNOVALUE = 0x8000;
        // header item
        private const int HDI_WIDTH = 0x0001;
        private const int HDI_HEIGHT = HDI_WIDTH;
        private const int HDI_TEXT = 0x0002;
        private const int HDI_FORMAT = 0x0004;
        private const int HDI_LPARAM = 0x0008;
        private const int HDI_BITMAP = 0x0010;
        private const int HDI_IMAGE = 0x0020;
        private const int HDI_DI_SETITEM = 0x0040;
        private const int HDI_ORDER = 0x0080;
        private const int HDI_FILTER = 0x0100;
        private const int HDI_STATE = 0x0200;
        private const int HDIS_FOCUSED = 0x00000001;
        // header messages  
        private const int HDIS_STATE = 0x8;
        private const int HDM_FIRST = 0x1200;
        private const int HDM_GETITEMCOUNT = (HDM_FIRST + 0);
        private const int HDM_INSERTITEMA = (HDM_FIRST + 1);
        private const int HDM_INSERTITEMW = (HDM_FIRST + 10);
        private const int HDM_DELETEITEM = (HDM_FIRST + 2);
        private const int HDM_GETITEMA = (HDM_FIRST + 3);
        private const int HDM_GETITEMW = (HDM_FIRST + 11);
        private const int HDM_SETITEMA = (HDM_FIRST + 4);
        private const int HDM_SETITEMW = (HDM_FIRST + 12);
        private const int HDM_LAYOUT = (HDM_FIRST + 5);
        private const int HDM_HITTEST = (HDM_FIRST + 6);
        private const int HDM_GETITEMRECT = (HDM_FIRST + 7);
        private const int HDM_SETIMAGELIST = (HDM_FIRST + 8);
        private const int HDM_GETIMAGELIST = (HDM_FIRST + 9);
        private const int HDM_ORDERTOINDEX = (HDM_FIRST + 15);
        private const int HDM_CREATEDRAGIMAGE = (HDM_FIRST + 16);
        private const int HDM_GETORDERARRAY = (HDM_FIRST + 17);
        private const int HDM_SETORDERARRAY = (HDM_FIRST + 18);
        private const int HDM_SETHOTDIVIDER = (HDM_FIRST + 19);
        private const int HDM_SETBITMAPMARGIN = (HDM_FIRST + 20);
        private const int HDM_GETBITMAPMARGIN = (HDM_FIRST + 21);
        private const int HDM_SETFILTERCHANGETIMEOUT = (HDM_FIRST + 22);
        private const int HDM_EDITFILTER = (HDM_FIRST + 23);
        private const int HDM_CLEARFILTER = (HDM_FIRST + 24);
        private const int HDM_GETITEMDROPDOWNRECT = (HDM_FIRST + 25);
        private const int HDM_GETOVERFLOWRECT = (HDM_FIRST + 26);
        private const int HDM_GETFOCUSEDITEM = (HDM_FIRST + 27);
        private const int HDM_SETFOCUSEDITEM = (HDM_FIRST + 28);
        // header notify
        private const int HDN_FIRST = -300;
        private const int HDN_LAST = -399;
        private const int HDN_ITEMCHANGINGA = (HDN_FIRST - 0);
        private const int HDN_ITEMCHANGINGW = (HDN_FIRST - 20);
        private const int HDN_ITEMCHANGEDA = (HDN_FIRST - 1);
        private const int HDN_ITEMCHANGEDW = (HDN_FIRST - 21);
        private const int HDN_ITEMCLICKA = (HDN_FIRST - 2);
        private const int HDN_ITEMCLICKW = (HDN_FIRST - 22);
        private const int HDN_ITEMDBLCLICKA = (HDN_FIRST - 3);
        private const int HDN_ITEMDBLCLICKW = (HDN_FIRST - 23);
        private const int HDN_DIVIDERDBLCLICKA = (HDN_FIRST - 5);
        private const int HDN_DIVIDERDBLCLICKW = (HDN_FIRST - 25);
        private const int HDN_BEGINTRACKA = (HDN_FIRST - 6);
        private const int HDN_BEGINTRACKW = (HDN_FIRST - 26);
        private const int HDN_ENDTRACKA = (HDN_FIRST - 7);
        private const int HDN_ENDTRACKW = (HDN_FIRST - 27);
        private const int HDN_TRACKA = (HDN_FIRST - 8);
        private const int HDN_TRACKW = (HDN_FIRST - 28);
        private const int HDN_GETDISPINFOA = (HDN_FIRST - 9);
        private const int HDN_GETDISPINFOW = (HDN_FIRST - 29);
        private const int HDN_BEGINDRAG = (HDN_FIRST - 10);
        private const int HDN_ENDDRAG = (HDN_FIRST - 11);
        private const int HDN_FILTERCHANGE = (HDN_FIRST - 12);
        private const int HDN_FILTERBTNCLICK = (HDN_FIRST - 13);
        private const int HDN_BEGINFILTEREDIT = (HDN_FIRST - 14);
        private const int HDN_ENDFILTEREDIT = (HDN_FIRST - 15);
        private const int HDN_ITEMSTATEICONCLICK = (HDN_FIRST - 16);
        private const int HDN_ITEMKEYDOWN = (HDN_FIRST - 17);
        private const int HDN_DROPDOWN = (HDN_FIRST - 18);
        private const int HDN_OVERFLOWCLICK = (HDN_FIRST - 19);
        // header styles
        private const int HDS_HORZ = 0x0000;
        private const int HDS_BUTTONS = 0x0002;
        private const int HDS_HOTTRACK = 0x0004;
        private const int HDS_HIDDEN = 0x0008;
        private const int HDS_DRAGDROP = 0x0040;
        private const int HDS_FULLDRAG = 0x0080;
        private const int HDS_FILTERBAR = 0x0100;
        private const int HDS_FLAT = 0x0200;
        private const int HDS_CHECKBOXES = 0x0400;
        private const int HDS_NOSIZING = 0x0800;
        private const int HDS_OVERFLOW = 0x1000;
        // window messages
        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_MOUSELEAVE = 0x2A3;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_MOUSEHOVER = 0x2A1;
        private const int WM_PAINT = 0xF;
        // message handler
        private static IntPtr MSG_HANDLED = new IntPtr(1);
        #endregion

        #region Enums
        private enum HITEST : int
        {
            HHT_NOWHERE = 0x0001,
            HHT_ONHEADER = 0x0002,
            HHT_ONDIVIDER = 0x0004,
            HHT_ONDIVOPEN = 0x0008,
            HHT_ONFILTER = 0x0010,
            HHT_ONFILTERBUTTON = 0x0020,
            HHT_ABOVE = 0x0100,
            HHT_BELOW = 0x0200,
            HHT_TORIGHT = 0x0400,
            HHT_TOLEFT = 0x0800,
            HHT_ONITEMSTATEICON = 0x1000,
            HHT_ONDROPDOWN = 0x2000,
            HHT_ONOVERFLOW = 0x4000
        }
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
        private struct HDITEM
        {
            internal int mask;
            internal int cxy;
            internal string pszText;
            internal IntPtr hbm;
            internal int cchTextMax;
            internal int fmt;
            internal IntPtr lParam;
            internal int iImage;
            internal int iOrder;
            internal uint type;
            internal IntPtr pvFilter;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct HDHITTESTINFO
        {
	        internal Point pt;
            internal HITEST flags;
	        internal int iItem;
        }
        #endregion

        #region API
        [DllImport("user32.dll")]
        private static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("user32.dll")]
        private static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr handle);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr handle, IntPtr hdc);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool StretchBlt(IntPtr hDest, int X, int Y, int nWidth, int nHeight, IntPtr hdcSrc,
        int sX, int sY, int nWidthSrc, int nHeightSrc, int dwRop);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage (IntPtr hwnd, int msg, int wParam, ref HDITEM lParam);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hwnd, int msg, int wParam, ref RECT lParam);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hwnd, int msg, int wParam, ref HDHITTESTINFO lParam);
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetClientRect(IntPtr hWnd, ref RECT r);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("user32.dll")]
        private static extern int ScreenToClient(IntPtr hwnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool PtInRect([In] ref RECT lprc, Point pt);

        [DllImport("user32.dll")]
        private static extern bool ValidateRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        private static extern int OffsetRect(ref RECT lpRect, int x, int y);

        [DllImport("uxtheme.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsAppThemed();

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr OpenThemeData(IntPtr hWnd, String classList);

        [DllImport("uxtheme.dll", ExactSpelling = true)]
        private static extern int DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId,
           int iStateId, ref RECT pRect, ref RECT pClipRect);

        [DllImport("uxtheme.dll", ExactSpelling = true)]
        private static extern int CloseThemeData(IntPtr hTheme);

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        private static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("comctl32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ImageList_DrawEx(IntPtr himl, int i, IntPtr hdcDst, int x, int y, int dx, int dy, int rgbBk, int rgbFg, int fStyle);

        [DllImport("comctl32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ImageList_GetIconSize(IntPtr himl, out int cx, out int cy);

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int smIndex);

        [DllImport("user32.dll")]
        private static extern short GetKeyState(int nVirtKey);
        #endregion

        #region Fields
        private bool _bPainting = false;
        private IntPtr _hHeaderWnd = IntPtr.Zero;
        private cStoreDc _cHeaderDc = new cStoreDc();
        private Bitmap _oHeaderBitmap;
        #endregion

        #region Constructor
        public cHeader(IntPtr hWnd, Bitmap skin)
        {
            if (hWnd == IntPtr.Zero)
                throw new Exception("The header handle is invalid.");
            if (skin == null)
                throw new Exception("The header image is invalid.");
            HeaderGraphic = skin;
            _hHeaderWnd = hWnd;
            this.AssignHandle(_hHeaderWnd);
        }
        #endregion

        #region Properties
        private int ColumnCount
        {
            get { return (SendMessage(_hHeaderWnd, HDM_GETITEMCOUNT, 0, 0)); }
        }

        /// <summary>
        /// Get/Set Header bitmap.
        /// </summary>
        public Bitmap HeaderGraphic
        {
            get { return _oHeaderBitmap; }
            set
            {
                _oHeaderBitmap = value;
                if (_cHeaderDc.Hdc != IntPtr.Zero)
                {
                    _cHeaderDc.Dispose();
                    _cHeaderDc = new cStoreDc();
                }
                _cHeaderDc.Width = _oHeaderBitmap.Width;
                _cHeaderDc.Height = _oHeaderBitmap.Height;
                SelectObject(_cHeaderDc.Hdc, _oHeaderBitmap.GetHbitmap());
            }
        }
        #endregion

        #region Methods
        private int columnAtIndex(int column)
        {
            HDITEM hd = new HDITEM();
            hd.mask = HDI_ORDER;
            for (int i = 0; i < ColumnCount; i++)
            {
                if (SendMessage(_hHeaderWnd, HDM_GETITEMA, column, ref hd) != IntPtr.Zero)
                    return hd.iOrder;
            }
            return 0;
        }

        private void drawHeader()
        {
            RECT tr = new RECT();
            RECT wr = new RECT();
            cStoreDc tempDc = new cStoreDc();
            int offset = 0;

            // set up the temp dc
            GetWindowRect(_hHeaderWnd, ref wr);
            OffsetRect(ref wr, -wr.Left, -wr.Top);
            tempDc.Height = wr.Bottom;
            tempDc.Width = wr.Right;

            int width = _cHeaderDc.Width / 4;

            for (int i = 0; i < ColumnCount; i++) 
            {
                if (!Enabled())
                {
                    offset = width * 3;
                }
                else if (i == focusedColumn())
                {
                    if (leftKeyPressed())
                        offset = width * 2;
                    else
                        offset = width;
                }
                else
                {
                    offset = 0;
                }
                SendMessage(_hHeaderWnd, HDM_GETITEMRECT, i, ref tr);
                using (StretchImage st = new StretchImage(_cHeaderDc.Hdc, tempDc.Hdc, new Rectangle(offset, 0, width, _cHeaderDc.Height), new Rectangle(tr.Left, tr.Top, tr.Right - tr.Left, tr.Bottom - tr.Top), 3, StretchModeEnum.STRETCH_HALFTONE)) { }
                // button, icon, sort arrows and text
                if (hasButton(i))
                    drawButton(tempDc.Hdc, i, tr);
                if (hasSort(i))
                    drawSortArrow(tempDc.Hdc, i, tr);
                if (hasIcon(i))
                    drawIcon(tempDc.Hdc, i, tr);
                drawText(tempDc.Hdc, i, tr);
            }
            // draw the end piece
            SendMessage(_hHeaderWnd, HDM_GETITEMRECT, columnAtIndex(ColumnCount - 1), ref tr);
            int left = tr.Right;
            GetWindowRect(_hHeaderWnd, ref tr);
            OffsetRect(ref tr, -tr.Left, -tr.Top);
            tr.Left = left;
            tr.Right += 10;
            using (StretchImage st = new StretchImage(_cHeaderDc.Hdc, tempDc.Hdc, new Rectangle(0, 0, (_cHeaderDc.Width / 3) - 2, _cHeaderDc.Height), new Rectangle(tr.Left, tr.Top, tr.Right - tr.Left + 2, tr.Bottom - tr.Top), 3, StretchModeEnum.STRETCH_HALFTONE)) { }
            // blit the temp dc
            IntPtr hdc = GetDC(_hHeaderWnd);
            BitBlt(hdc, 0, 0, wr.Right, wr.Bottom, tempDc.Hdc, 0, 0, 0xCC0020);
            ReleaseDC(_hHeaderWnd, hdc);
            tempDc.Dispose();
        }

        private bool leftKeyPressed()
        {
            if (mouseButtonsSwitched())
                return (GetKeyState(VK_RBUTTON) < 0);
            else
                return (GetKeyState(VK_LBUTTON) < 0);
        }

        private bool mouseButtonsSwitched()
        {
            return (GetSystemMetrics(SM_SWAPBUTTON) != 0);
        }

        private void drawButton(IntPtr hdc, int column, RECT tr)
        {
            HITEST state = columnState();
            if (state == HITEST.HHT_ONHEADER || state == HITEST.HHT_ONDROPDOWN)
            {
                // as with windows implementation, only draw if column is in focus
                if (column == focusedColumn())
                {
                    RECT br = new RECT();
                    int offset = _cHeaderDc.Width / 3;
                    Point pt = new Point();

                    // get the button size
                    SendMessage(_hHeaderWnd, HDM_GETITEMDROPDOWNRECT, column, ref br);
                    int height = br.Bottom - br.Top;
                    int width = br.Right - br.Left;
                    // fix for position bug?
                    br.Left = tr.Right - (width + 2);
                    br.Right = br.Left + width;
                    using (Graphics g = Graphics.FromHdc(hdc))
                    {
                        using (Pen borderPen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 0.5f))
                            g.DrawRectangle(borderPen, new Rectangle(br.Left, br.Top, width, height - 3));
                    }
                    GetCursorPos(ref pt);
                    ScreenToClient(_hHeaderWnd, ref pt);
                    // if selected shade the button
                    if (PtInRect(ref br, pt))
                        drawFocusedButton(hdc, new Rectangle(br.Left, br.Top, width, height - 3), LinearGradientMode.Vertical);
                    br.Left += (width - 5) / 2;
                    br.Bottom = br.Top + 6;
                    br.Top = (height / 2) - 3;
                    // draw the arrow
                    drawArrow(hdc, new Rectangle(br.Left, br.Top, 12, 6), true);
                }
            }
        }

        private void drawFocusedButton(IntPtr hdc, Rectangle bounds, LinearGradientMode gradient)
        {
            using (Graphics g = Graphics.FromHdc(hdc))
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
                        using (Pen borderPen = new Pen(Color.FromArgb(150, Color.SlateGray), 1f))
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
                        using (Pen borderPen = new Pen(Color.FromArgb(150, Color.DarkGray), 1.5f))
                            g.DrawPath(borderPen, buttonPath);

                        // create a thin gradient cover
                        using (LinearGradientBrush fillBrush = new LinearGradientBrush(
                            bounds,
                            Color.FromArgb(50, Color.White),
                            Color.FromArgb(50, Color.SlateGray),
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
        }

        private void drawSortArrow(IntPtr hdc, int column, RECT tr)
        {
            if (Environment.OSVersion.Version.Major > 5)
            {
                HDITEM hi = new HDITEM();
                hi.mask = HDI_FORMAT;
                SendMessage(_hHeaderWnd, HDM_GETITEMA, column, ref hi);
                int left = (tr.Right - tr.Left) / 2 - 4;
                Rectangle ar = new Rectangle(tr.Left + left, 0, 12, 6);
                if ((hi.fmt & (HDF_SORTDOWN)) == HDF_SORTDOWN)
                {
                    if (!drawThemeArrow(hdc, ar, true))
                        drawArrow(hdc, ar, true);
                }
                else
                {
                    if (!drawThemeArrow(hdc, ar, false))
                        drawArrow(hdc, ar, false);
                }
            }
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

        private bool drawThemeArrow(IntPtr hdc, Rectangle bounds, bool down)
        {
            if (IsAppThemed())
            {
                IntPtr hTheme = OpenThemeData(GetParent(_hHeaderWnd), "Header");
                if (hTheme != IntPtr.Zero)
                {
                    RECT tr = new RECT(bounds.Left, bounds.Top, bounds.Right, bounds.Bottom);
                    // draw part
                    DrawThemeBackground(hTheme, hdc, HP_HEADERSORTARROW, down ? HSAS_SORTEDDOWN : HSAS_SORTEDUP, ref tr, ref tr);
                    CloseThemeData(hTheme);
                    return true;
                }
            }
            return false;
        }

        private void drawArrow(IntPtr hdc, Rectangle bounds, bool down)
        {
            using (Graphics g = Graphics.FromHdc(hdc))
            {
                using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
                {
                    using (GraphicsPath gp = new GraphicsPath())
                    {
                        if (down)
                        {
                            // draw the frame
                            gp.AddLine(new Point(bounds.X, bounds.Top), new Point(bounds.X + 4, bounds.Top));
                            gp.AddLine(new Point(bounds.X, bounds.Top), new Point(bounds.X + 2, bounds.Top + 2));
                            gp.AddLine(new Point(bounds.X + 2, bounds.Top + 2), new Point(bounds.X + 4, bounds.Top));
                            gp.CloseFigure();
                        }
                        else
                        {
                            gp.AddLine(new Point(bounds.X, bounds.Top + 4), new Point(bounds.X + 4, bounds.Top + 4));
                            gp.AddLine(new Point(bounds.X, bounds.Top + 4), new Point(bounds.X + 2, bounds.Top + 2));
                            gp.AddLine(new Point(bounds.X + 4, bounds.Top + 4), new Point(bounds.X + 2, bounds.Top + 2));
                            gp.CloseFigure();
                        }
                        // draw border
                        using (Pen borderPen = new Pen(Color.FromArgb(240, Color.Black), 0.5f))
                            g.DrawPath(borderPen, gp);
                        // fill path
                        using (Brush backBrush = new SolidBrush(Color.SlateGray))
                            g.FillPath(backBrush, gp);
                    }
                }
            }
        }

        private void drawIcon(IntPtr hdc, int column, RECT tr)
        {
            IntPtr iml = (IntPtr)SendMessage(_hHeaderWnd, HDM_GETIMAGELIST, HDIS_STATE, 0);
            if (iml != IntPtr.Zero)
            {
                int cx = 0;
                int cy = 0;
                HDITEM hi = new HDITEM();
                ImageList_GetIconSize(iml, out cx, out cy);
                hi.mask = HDI_IMAGE;
                SendMessage(_hHeaderWnd, HDM_GETITEMA, column, ref hi);
                tr.Top = (tr.Bottom - cy) / 2;
                tr.Left += 4;
                ImageList_DrawEx(iml, hi.iImage, hdc, tr.Left, tr.Top, cx, cy, CLR_NONE, 0, ILD_TRANSPARENT);
            }
        }

        private void drawText(IntPtr hdc, int column, RECT tr)
        {
            HDITEM hi = new HDITEM();
            hi.mask = HDI_TEXT | HDI_FORMAT | HDI_IMAGE;
            hi.cchTextMax = 255;
            hi.pszText = new String('0', 255);
            SendMessage(_hHeaderWnd, HDM_GETITEMA, column, ref hi);

            if (String.IsNullOrEmpty(hi.pszText))
                return;

            string text = hi.pszText;

            using (Graphics g = Graphics.FromHdc(hdc))
            {
                using (StringFormat sf = new StringFormat())
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                    sf.Trimming = StringTrimming.EllipsisCharacter;
                    if ((hi.fmt & HDF_RIGHT) == HDF_RIGHT)
                    {
                        sf.Alignment = StringAlignment.Far;
                        sf.LineAlignment = StringAlignment.Center;
                    }
                    else if ((hi.fmt & HDF_CENTER) == HDF_CENTER)
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                    }
                    else
                    {
                        sf.Alignment = StringAlignment.Near;
                        sf.LineAlignment = StringAlignment.Center;
                    }
                    if ((hi.fmt & HDF_IMAGE) == HDF_IMAGE)
                        tr.Left += 18;

                    if ((hi.fmt & HDF_RTLREADING) == HDF_RTLREADING)
                        sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;

                    if (hasButton(column))
                        tr.Right -= 12;

                    Control ct = (ListView)Control.FromHandle(GetParent(_hHeaderWnd));
                    SizeF sz = g.MeasureString(text, ct.Font);
                    tr.Top = (tr.Bottom / 2) - (int)sz.Height;
                    tr.Bottom = tr.Top + (int)sz.Height;
                    // draw the text
                    using (Brush captionBrush = new SolidBrush(ct.ForeColor))
                        g.DrawString(text, ct.Font, captionBrush, new RectangleF(tr.Left, tr.Top + 5, tr.Right - tr.Left, tr.Bottom - tr.Top), sf);
                }
            }
        }

        private bool Enabled()
        {
            if ((GetWindowLong(_hHeaderWnd, GWL_STYLE) & WS_ENABLED) == WS_ENABLED)
                return true;
            return false;
        }

        private bool hasButton(int column)
        {
            if (Environment.OSVersion.Version.Major > 5)
            {
                HDITEM hi = new HDITEM();
                hi.mask = HDI_FORMAT;
                SendMessage(_hHeaderWnd, HDM_GETITEMA, columnAtIndex(column), ref hi);
                if ((hi.fmt & HDF_SPLITBUTTON) == HDF_SPLITBUTTON)
                    return true;
            }
            return false;
        }

        private bool hasIcon(int column)
        {
            HDITEM hi = new HDITEM();
            hi.mask = HDI_FORMAT;
            SendMessage(_hHeaderWnd, HDM_GETITEMA, column, ref hi);
            if ((hi.fmt & HDF_IMAGE) == HDF_IMAGE)
                return true;
            return false;
        }

        private bool hasSort(int column)
        {
            if (Environment.OSVersion.Version.Major > 5)
            {
                HDITEM hi = new HDITEM();
                hi.mask = HDI_FORMAT;
                SendMessage(_hHeaderWnd, HDM_GETITEMA, column, ref hi);
                if ((hi.fmt & (HDF_SORTUP | HDF_SORTDOWN)) > 0)
                    return true;
            }
            return false;
        }

        private HITEST columnState()
        {
            HDHITTESTINFO ht = new HDHITTESTINFO();
            GetCursorPos(ref ht.pt);
            ScreenToClient(_hHeaderWnd, ref ht.pt);
            SendMessage(_hHeaderWnd, HDM_HITTEST, 0, ref ht);

            if (ht.iItem != -1)
                return ht.flags;
            return HITEST.HHT_NOWHERE;
        }

        private int focusedColumn()
        {
            HDHITTESTINFO ht = new HDHITTESTINFO();
            GetCursorPos(ref ht.pt);
            ScreenToClient(_hHeaderWnd, ref ht.pt);
            SendMessage(_hHeaderWnd, HDM_HITTEST, 0, ref ht);
            return ht.iItem;
        }

        public void Dispose()
        {
            try
            {
                this.ReleaseHandle();
                if (_oHeaderBitmap != null) _oHeaderBitmap.Dispose();
                if (_cHeaderDc != null) _cHeaderDc.Dispose();
            }
            catch { }
            GC.SuppressFinalize(this);
        }
        #endregion

        #region WndProc
        protected override void WndProc(ref Message m)
        {
            PAINTSTRUCT ps = new PAINTSTRUCT();
            switch (m.Msg)
            {
                case WM_PAINT:
                    if (!_bPainting)
                    {
                        _bPainting = true;
                        // start painting engine
                        BeginPaint(m.HWnd, ref ps);
                        drawHeader();
                        ValidateRect(m.HWnd, ref ps.rcPaint);
                        // done
                        EndPaint(m.HWnd, ref ps);
                        _bPainting = false;
                        m.Result = MSG_HANDLED;
                    }
                    else
                    {
                        base.WndProc(ref m);
                    }
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion
    }
}
