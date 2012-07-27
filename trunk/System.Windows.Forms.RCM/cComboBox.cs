namespace System.Windows.Forms.RCM
{
    #region Directives
    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Drawing;
    using System.Text;
    #endregion

    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class cComboBox : NativeWindow, IDisposable
    {
        #region Constants
        // messages
        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_MOUSELEAVE = 0x2A3;
        private const int WM_PAINT = 0xF;
        private const int WM_NCMOUSEMOVE = 0xA0;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_RBUTTONDOWN = 0x204;
        // combobox messages
        private const int CB_GETCOMBOBOXINFO = 0x164;
        // message handler
        private static IntPtr MSG_HANDLED = new IntPtr(1);
        #endregion

        #region Enums
        private enum COMBOBOXSTYLESTATES
        {
            CBXS_NORMAL = 1,
            CBXS_HOT = 2,
            CBXS_PRESSED = 3,
            CBXS_DISABLED = 4,
        };

        private enum ComboBoxButtonState
        {
            STATE_SYSTEM_NONE = 0,
            STATE_SYSTEM_INVISIBLE = 0x00008000,
            STATE_SYSTEM_PRESSED = 0x00000008
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
        private struct COMBOBOXINFO
        {
            internal Int32 cbSize;
            internal RECT rcItem;
            internal RECT rcButton;
            internal ComboBoxButtonState buttonState;
            internal IntPtr hwndCombo;
            internal IntPtr hwndEdit;
            internal IntPtr hwndList;
        }
        #endregion

        #region API
        [DllImport("user32.dll")]
        private static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ValidateRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool StretchBlt(IntPtr hDest, int X, int Y, int nWidth, int nHeight, IntPtr hdcSrc,
        int sX, int sY, int nWidthSrc, int nHeightSrc, int dwRop);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr handle);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr handle, IntPtr hdc);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, ref COMBOBOXINFO lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        private extern static int OffsetRect(ref RECT lpRect, int x, int y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool PtInRect([In] ref RECT lprc, Point pt);
        #endregion

        #region Fields
        private bool _bPainting = false;
        private bool _bMoved = false;
        private bool _bFading = false;
        private IntPtr _hComboWnd = IntPtr.Zero;
        private cStoreDc _cComboboxDc = new cStoreDc();
        private Bitmap _oComboboxBitmap;
        private Bitmap _oMask;
        #endregion

        #region Constructor
        public cComboBox(IntPtr hWnd, Bitmap skin, Bitmap fader)
        {
            if (hWnd == IntPtr.Zero)
                throw new Exception("The combobox handle is invalid.");
            if (skin == null)
                throw new Exception("The combobox image is invalid.");
            ComboboxGraphic = skin;
            _hComboWnd = hWnd;
            this.AssignHandle(_hComboWnd);
            if (fader != null)
                TransitionGraphic = fader;
        }

        public void Dispose()
        {
            try
            {
                this.ReleaseHandle();
                if (_oComboboxBitmap != null) _oComboboxBitmap.Dispose();
                if (_cComboboxDc != null) _cComboboxDc.Dispose();
                //if (_oMask != null) _oMask.Dispose();
            }
            catch { }
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get/Set Combobox bitmap.
        /// </summary>
        public Bitmap ComboboxGraphic
        {
            get { return _oComboboxBitmap; }
            set
            {
                _oComboboxBitmap = value;
                if (_cComboboxDc.Hdc != IntPtr.Zero)
                {
                    _cComboboxDc.Dispose();
                    _cComboboxDc = new cStoreDc();
                }
                _cComboboxDc.Width = _oComboboxBitmap.Width;
                _cComboboxDc.Height = _oComboboxBitmap.Height;
                SelectObject(_cComboboxDc.Hdc, _oComboboxBitmap.GetHbitmap());

            }
        }


        /// <summary>
        /// Fader graphic
        /// </summary>
        private Bitmap TransitionGraphic
        {
            get { return _oMask; }
            set { _oMask = value; }
        }
        #endregion

        #region Methods
        private void drawCombo()
        {
            int offset = 0;
            int width = _oComboboxBitmap.Width / 4;
            RECT tr = new RECT();
            GetWindowRect(_hComboWnd, ref tr);
            OffsetRect(ref tr, -tr.Left, -tr.Top);
            Rectangle cr = new Rectangle(0, 0, tr.Right, tr.Bottom);
            ComboBox cb = (ComboBox)Control.FromHandle(_hComboWnd);

            // get button size
            tr = comboButton();
            // backfill and border
            using (Graphics g = Graphics.FromHwnd(_hComboWnd))
            {
                using (Brush flatBrush = new SolidBrush(cb.Enabled ? Color.White : Color.FromKnownColor(KnownColor.InactiveBorder)))
                    g.FillRectangle(flatBrush, cr);
                cr.Height--;
                cr.Width--;
                using (Pen borderPen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 0.5f))
                {
                    g.DrawLine(borderPen, cr.X, cr.Y + 1, cr.X, cr.Height);
                    g.DrawLine(borderPen, cr.X, cr.Height, cr.Width, cr.Height);
                }
                using (Pen borderPen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 0.5f))
                {
                    g.DrawLine(borderPen, cr.X, cr.Y, cr.Width, cr.Y);
                    g.DrawLine(borderPen, cr.Width, cr.Y, cr.Width, cr.Height - 1);
                }
            }
            if (!cb.Enabled)
            {
                offset = width * 3;
            }
            else
            {
                if (cb.DroppedDown)
                    offset = width * 1;
                else if (cb.Focused || _bMoved)
                    offset = width * 2;
                else
                    offset = 0;
            }
            // draw the image
            IntPtr hdc = GetDC(_hComboWnd);
            using (StretchImage si = new StretchImage(_cComboboxDc.Hdc, hdc, new Rectangle(offset, 0, width, _cComboboxDc.Height), new Rectangle(tr.Left, tr.Top, tr.Right - tr.Left, tr.Bottom - tr.Top), 2, StretchModeEnum.STRETCH_HALFTONE)) { }
            ReleaseDC(_hComboWnd, hdc);
        }

        private RECT comboButton()
        {
            int width = _oComboboxBitmap.Width / 4;
            COMBOBOXINFO cbi = new COMBOBOXINFO();
            RECT tr = new RECT();

            // get button size
            cbi.cbSize = Marshal.SizeOf(cbi);
            if (SendMessage(_hComboWnd, CB_GETCOMBOBOXINFO, 0, ref cbi) != 0)
            {
                tr = cbi.rcButton;
            }
            else
            {
                ComboBox cb = (ComboBox)Control.FromHandle(_hComboWnd);
                tr = new RECT(cb.ClientRectangle.Width - width, 1, width, cb.ClientRectangle.Height - 2);
            }
            return tr;
        }

        private bool overButton()
        {
            RECT wr = new RECT();
            Point pos = new Point();

            GetWindowRect(_hComboWnd, ref wr);
            RECT tr = comboButton();
            OffsetRect(ref tr, wr.Left, wr.Top);
            GetCursorPos(ref pos);
            if (PtInRect(ref tr, pos))
                return true;
            return false;
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
                        if (!_bFading)
                        drawCombo();
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

                case WM_MOUSEMOVE:
                    if (!_bMoved)
                    {
                        if (TransitionGraphic != null)
                        {
                            RECT tr = comboButton();
                            _bFading = true;
                            cTransition ts = new cTransition(m.HWnd, IntPtr.Zero, TransitionGraphic, new Rectangle(tr.Left, tr.Top, tr.Right - tr.Left, tr.Bottom - tr.Top));
                        }
                    }
                    if (overButton())
                        _bMoved = true;
                    base.WndProc(ref m);
                    break;

                case WM_MOUSELEAVE:
                    _bMoved = false;
                    _bFading = false;
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
