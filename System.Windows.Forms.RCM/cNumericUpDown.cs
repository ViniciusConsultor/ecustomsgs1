namespace System.Windows.Forms.RCM
{
    #region Directives
    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Drawing;
    #endregion

    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class cNumericUpDown : NativeWindow, IDisposable
    {
        #region Constants
        // numeric styles
        private const int UDS_WRAP = 1;
        private const int UDS_SETBUDDYINT = 2;
        private const int UDS_ALIGNRIGHT = 4;
        private const int UDS_ALIGNLEFT = 8;
        private const int UDS_AUTOBUDDY = 16;
        private const int UDS_ARROWKEYS = 32;
        private const int UDS_HORZ = 64;
        private const int UDS_NOTHOUSANDS = 128;
        // numeric messages
        private const int WM_USER = 0x0400;
        private const int UDM_SETRANGE = (WM_USER+101);
        private const int UDM_GETRANGE = (WM_USER+102);
        private const int UDM_SETPOS = (WM_USER+103);
        private const int UDM_GETPOS = (WM_USER+104);
        private const int UDM_SETBUDDY = (WM_USER+105);
        private const int UDM_GETBUDDY = (WM_USER+106);
        private const int UDM_SETACCEL = (WM_USER+107);
        private const int UDM_GETACCEL = (WM_USER+108);
        private const int UDM_SETBASE = (WM_USER+109);
        private const int UDM_GETBASE = (WM_USER+110);
        // messages
        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_MOUSELEAVE = 0x2A3;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_MOUSEHOVER = 0x2A1;
        private const int WM_PAINT = 0xF;
        // mouse constants
        private const int SM_SWAPBUTTON = 23;
        private const int VK_LBUTTON = 0x1;
        private const int VK_RBUTTON = 0x2;
        // message handler
        private static IntPtr MSG_HANDLED = new IntPtr(1);
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
        #endregion

        #region API
        [DllImport("user32.dll")]
        private static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool StretchBlt(IntPtr hDest, int X, int Y, int nWidth, int nHeight, IntPtr hdcSrc,
        int sX, int sY, int nWidthSrc, int nHeightSrc, int dwRop);

        [DllImport("user32.dll")]
        private static extern bool ValidateRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool PtInRect([In] ref RECT lprc, Point pt);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT r);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetClientRect(IntPtr hWnd, ref RECT r);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("user32.dll")]
        private extern static int OffsetRect(ref RECT lpRect, int x, int y);

        [DllImport("user32.dll")]
        private static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int smIndex);

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hWnd, String pszSubAppName, String pszSubIdList);

        [DllImport("uxtheme.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool IsAppThemed();
        #endregion

        #region Fields
        private bool _bPainting = false;
        private IntPtr _hNumericUpDownWnd = IntPtr.Zero;
        private Bitmap _oNumericUpDownBitmap;
        #endregion

        #region Constructor
        public cNumericUpDown(IntPtr hWnd, Bitmap skin)
        {
            if (hWnd == IntPtr.Zero)
                throw new Exception("The combobox handle is invalid.");
            if (skin == null)
                throw new Exception("The combobox image is invalid.");
            NumericUpDown nb = (NumericUpDown)Control.FromHandle(hWnd);
            // skin the button only
            _hNumericUpDownWnd = nb.Controls[0].Handle;
            NumericUpDownGraphic = skin;
            if (Environment.OSVersion.Version.Major > 5)
            {
                if (IsAppThemed())
                    SetWindowTheme(_hNumericUpDownWnd, "", "");
            }
            this.AssignHandle(_hNumericUpDownWnd);
        }
        #endregion

        #region Properties
        private Bitmap NumericUpDownGraphic
        {
            get { return _oNumericUpDownBitmap; }
            set { _oNumericUpDownBitmap = value; }
        }
        #endregion

        #region Methods
        private void drawSpinButton()
        {
            int offset = _oNumericUpDownBitmap.Width / 2;
            int height = _oNumericUpDownBitmap.Height / 2;
            RECT buttonRect = new RECT();

            Graphics g = Graphics.FromHwnd(_hNumericUpDownWnd);
            GetClientRect(_hNumericUpDownWnd, ref buttonRect);

            if (overButton() && leftKeyPressed())
            {
                RECT windowRect = new RECT();
                Point cursorPoint = new Point();
                GetCursorPos(ref cursorPoint);
                GetWindowRect(_hNumericUpDownWnd, ref windowRect);
                cursorPoint.X -= windowRect.Left;
                cursorPoint.Y -= windowRect.Top;
                // top button
                if (cursorPoint.Y < (buttonRect.Bottom / 2))
                {
                    g.DrawImage(_oNumericUpDownBitmap, new Rectangle(0, 0, buttonRect.Right, buttonRect.Bottom / 2), new Rectangle(offset, 0, offset, height), GraphicsUnit.Pixel);
                    g.DrawImage(_oNumericUpDownBitmap, new Rectangle(0, buttonRect.Bottom / 2, buttonRect.Right, buttonRect.Bottom / 2), new Rectangle(0, height, offset, height), GraphicsUnit.Pixel);
                }
                // bottom button
                else
                {
                    g.DrawImage(_oNumericUpDownBitmap, new Rectangle(0, 0, buttonRect.Right, buttonRect.Bottom / 2), new Rectangle(0, 0, offset, height), GraphicsUnit.Pixel);
                    g.DrawImage(_oNumericUpDownBitmap, new Rectangle(0, buttonRect.Bottom / 2, buttonRect.Right, buttonRect.Bottom / 2), new Rectangle(offset, height, offset, height), GraphicsUnit.Pixel);
                }
            }
            else
            {
                g.DrawImage(_oNumericUpDownBitmap, new Rectangle(0, 0, buttonRect.Right, buttonRect.Bottom), new Rectangle(0, 0, offset, _oNumericUpDownBitmap.Height), GraphicsUnit.Pixel);
            }
        }

        private bool overButton()
        {
            RECT windowRect = new RECT();
            Point cursorPoint = new Point();

            GetCursorPos(ref cursorPoint);
            GetWindowRect(_hNumericUpDownWnd, ref windowRect);
            if (PtInRect(ref windowRect, cursorPoint))
                return true;

            return false;
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

        public void Dispose()
        {
            try
            {
                this.ReleaseHandle();
                if (_oNumericUpDownBitmap != null) _oNumericUpDownBitmap.Dispose();
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
                        drawSpinButton();
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
