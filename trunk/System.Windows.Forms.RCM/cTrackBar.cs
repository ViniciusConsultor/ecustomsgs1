namespace System.Windows.Forms.RCM
{
    #region Directives
    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Drawing;
    #endregion

    public class cTrackBar : NativeWindow, IDisposable
    {
        #region Constants
        // mouse buttons
        private const int VK_LBUTTON = 0x1;
        private const int VK_RBUTTON = 0x2;
        private const int SM_SWAPBUTTON = 23;
        // messages
        private const int WM_USER = 0x0400;
        private const int WM_PAINT = 0xF;
        // trackbar messages
        private const int TBM_GETRANGEMIN	= (WM_USER+1);
        private const int TBM_GETRANGEMAX = (WM_USER+2);
        private const int TBM_GETTIC = (WM_USER+3);
        private const int TBM_SETTIC = (WM_USER+4);
        private const int TBM_SETPOS = (WM_USER+5);
        private const int TBM_SETRANGE	= (WM_USER+6);
        private const int TBM_SETRANGEMIN = (WM_USER+7);
        private const int TBM_SETRANGEMAX = (WM_USER+8);
        private const int TBM_CLEARTICS = (WM_USER+9);
        private const int TBM_SETSEL = (WM_USER+10);
        private const int TBM_SETSELSTART = (WM_USER+11);
        private const int TBM_SETSELEND = (WM_USER+12);
        private const int TBM_GETPTICS	= (WM_USER+14);
        private const int TBM_GETTICPOS = (WM_USER+15);
        private const int TBM_GETNUMTICS = (WM_USER+16);
        private const int TBM_GETSELSTART = (WM_USER+17);
        private const int TBM_GETSELEND = (WM_USER+18);
        private const int TBM_CLEARSEL	= (WM_USER+19);
        private const int TBM_SETTICFREQ = (WM_USER+20);
        private const int TBM_SETPAGESIZE = (WM_USER+21);
        private const int TBM_GETPAGESIZE = (WM_USER+22);
        private const int TBM_SETLINESIZE = (WM_USER+23);
        private const int TBM_GETLINESIZE = (WM_USER+24);
        private const int TBM_GETTHUMBRECT	= (WM_USER+25);
        private const int TBM_GETCHANNELRECT = (WM_USER+26);
        private const int TBM_SETTHUMBLENGTH = (WM_USER+27);
        private const int TBM_GETTHUMBLENGTH = (WM_USER+28);
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
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

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
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, ref RECT lParam);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

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
        private static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int smIndex);
        #endregion

        #region Fields
        private bool _bPainting = false;
        private IntPtr _hTrackBarWnd = IntPtr.Zero;
        private cStoreDc _cTrackDc = new cStoreDc();
        private cStoreDc _cThumbDc = new cStoreDc();
        private Bitmap _oTrackBitmap;
        private Bitmap _oThumbBitmap;
        #endregion

        #region Constructor
        public cTrackBar(IntPtr hWnd, Bitmap thumb, Bitmap track)
        {
            if (hWnd == IntPtr.Zero)
                throw new Exception("The trackbar handle is invalid.");
            if (thumb == null)
                throw new Exception("The trackbar arrow image is invalid.");
            if (track == null)
                throw new Exception("The trackbar track image is invalid.");
            ThumbGraphic = thumb;
            TrackGraphic = track;
            _hTrackBarWnd = hWnd;
            this.AssignHandle(hWnd);
        }
        #endregion

        #region Properties
        private Bitmap ThumbGraphic
        {
            get { return _oThumbBitmap; }
            set
            {
                _oThumbBitmap = value;
                if (_cThumbDc.Hdc != IntPtr.Zero)
                {
                    _cThumbDc.Dispose();
                    _cThumbDc = new cStoreDc();
                }
                _cThumbDc.Width = _oThumbBitmap.Width;
                _cThumbDc.Height = _oThumbBitmap.Height;
                SelectObject(_cThumbDc.Hdc, _oThumbBitmap.GetHbitmap());
            }
        }

        private Bitmap TrackGraphic
        {
            get { return _oTrackBitmap; }
            set
            {
                _oTrackBitmap = value;
                if (_cTrackDc.Hdc != IntPtr.Zero)
                {
                    _cTrackDc.Dispose();
                    _cTrackDc = new cStoreDc();
                }
                _cTrackDc.Width = _oTrackBitmap.Width;
                _cTrackDc.Height = _oTrackBitmap.Height;
                SelectObject(_cTrackDc.Hdc, _oTrackBitmap.GetHbitmap());
            }
        }
        #endregion

        #region Methods
        public void Dispose()
        {
            try
            {
                this.ReleaseHandle();
                if (_oThumbBitmap != null) _oThumbBitmap.Dispose();
                if (_cThumbDc != null) _cThumbDc.Dispose();
                if (_oTrackBitmap != null) _oTrackBitmap.Dispose();
                if (_cTrackDc != null) _cTrackDc.Dispose();
            }
            catch { }
            GC.SuppressFinalize(this);
        }

        private void drawTrackBar()
        {
            TrackBar tb = (TrackBar)Control.FromHandle(_hTrackBarWnd);
            int state = 0;
            int width = 0;
            int pos = 0;
            RECT trackRect = new RECT();
            RECT thumbRect = new RECT();
            RECT ctlRect = new RECT();
            cStoreDc tempDc = new cStoreDc();

            GetWindowRect(_hTrackBarWnd, ref ctlRect);
            OffsetRect(ref ctlRect, -ctlRect.Left, -ctlRect.Top);
            tempDc.Width = ctlRect.Right;
            tempDc.Height = ctlRect.Bottom;

            Graphics g = Graphics.FromHdc(tempDc.Hdc);

            SendMessage(_hTrackBarWnd, TBM_GETCHANNELRECT, 0, ref trackRect);
            SendMessage(_hTrackBarWnd, TBM_GETTHUMBRECT, 0, ref thumbRect);

            // get selected state
            if (!tb.Enabled)
            {
                state = 1;
            }
            else if (Hovering(thumbRect))
            {
                if (leftKeyPressed())
                    state = 2;
                else
                    state = 3;
            }
            else if (tb.Focused)
            {
                state = 2;
            }
            else
            {
                state = 0;
            }
            // draw the background
            using (Brush fillBrush = new SolidBrush(tb.BackColor))
                g.FillRectangle(fillBrush, tb.ClientRectangle);
            int ticks = SendMessage(_hTrackBarWnd, TBM_GETNUMTICS, 0, 0) - 1;


            if (tb.Orientation == Orientation.Horizontal)
            {
                if (tb.TickStyle == TickStyle.BottomRight)
                    pos = trackRect.Bottom + 13;
                else
                    pos = trackRect.Top - 15;

                // draw the ticks
                if (ticks > 0)
                {
                    for (int i = 0; i < ticks; i++)
                    {
                        int tX = SendMessage(_hTrackBarWnd, TBM_GETTICPOS, i, 0);
                        if (tX > 0)
                        {
                            using (Pen lightPen = new Pen(Color.FromKnownColor(KnownColor.ControlLight)))
                                g.DrawLine(lightPen, new Point(tX - 1, pos), new Point(tX - 1, pos + 2));
                            using (Pen darkPen = new Pen(Color.FromKnownColor(KnownColor.ControlDark)))
                                g.DrawLine(darkPen, new Point(tX, pos), new Point(tX, pos + 2));
                        }
                    }
                    // first tick
                    using (Pen lightPen = new Pen(Color.FromKnownColor(KnownColor.ControlLight)))
                        g.DrawLine(lightPen, new Point(trackRect.Left + 4, pos), new Point(trackRect.Left + 4, pos + 2));
                    using (Pen darkPen = new Pen(Color.FromKnownColor(KnownColor.ControlDark)))
                        g.DrawLine(darkPen, new Point(trackRect.Left + 5, pos), new Point(trackRect.Left + 5, pos + 2));
                    // last tick
                    using (Pen lightPen = new Pen(Color.FromKnownColor(KnownColor.ControlLight)))
                        g.DrawLine(lightPen, new Point(trackRect.Right - 6, pos), new Point(trackRect.Right - 6, pos + 2));
                    using (Pen darkPen = new Pen(Color.FromKnownColor(KnownColor.ControlDark)))
                        g.DrawLine(darkPen, new Point(trackRect.Right - 5, pos), new Point(trackRect.Right - 5, pos + 2));
                }
                width = ThumbGraphic.Width / 4;
                // draw the track and slider
                g.DrawImage(TrackGraphic, new Rectangle(trackRect.Left, trackRect.Top, trackRect.Right - trackRect.Left, trackRect.Bottom - trackRect.Top), new Rectangle(0, 0, TrackGraphic.Width, TrackGraphic.Height), GraphicsUnit.Pixel);
                g.DrawImage(ThumbGraphic, new Rectangle(thumbRect.Left, thumbRect.Top, thumbRect.Right - thumbRect.Left, thumbRect.Bottom - thumbRect.Top), new Rectangle(state * width, 0, width, ThumbGraphic.Height), GraphicsUnit.Pixel);
            }
            else
            {
                if (tb.TickStyle == TickStyle.BottomRight)
                    pos = trackRect.Bottom + 13;
                else
                    pos = trackRect.Top - 15;

                // draw the ticks
                if (ticks > 0)
                {
                    for (int i = 0; i < ticks; i++)
                    {
                        int tX = SendMessage(_hTrackBarWnd, TBM_GETTICPOS, i, 0);
                        if (tX > 0)
                        {
                            using (Pen lightPen = new Pen(Color.FromKnownColor(KnownColor.ControlLight)))
                                g.DrawLine(lightPen, new Point(pos + 2, tX - 1), new Point(pos, tX - 1));
                            using (Pen darkPen = new Pen(Color.FromKnownColor(KnownColor.ControlDark)))
                                g.DrawLine(darkPen, new Point(pos, tX), new Point(pos + 2, tX));
                        }
                    }
                    // first tick
                    using (Pen lightPen = new Pen(Color.FromKnownColor(KnownColor.ControlLight)))
                        g.DrawLine(lightPen, new Point(pos, trackRect.Left + 4), new Point(pos + 2, trackRect.Left + 4));
                    using (Pen darkPen = new Pen(Color.FromKnownColor(KnownColor.ControlDark)))
                        g.DrawLine(darkPen, new Point(pos, trackRect.Left + 5), new Point(pos + 2, trackRect.Left + 5));
                    // last tick
                    using (Pen lightPen = new Pen(Color.FromKnownColor(KnownColor.ControlLight)))
                        g.DrawLine(lightPen, new Point(pos, trackRect.Right - 6), new Point(pos + 2, trackRect.Right - 6));
                    using (Pen darkPen = new Pen(Color.FromKnownColor(KnownColor.ControlDark)))
                        g.DrawLine(darkPen, new Point(pos, trackRect.Right - 5), new Point(pos + 2, trackRect.Right - 5));
                }
                Bitmap trc = (Bitmap)_oTrackBitmap.Clone();
                trc.RotateFlip(RotateFlipType.Rotate90FlipNone);
                Bitmap ttb = (Bitmap)_oThumbBitmap.Clone();
                ttb.RotateFlip(RotateFlipType.Rotate90FlipNone);
                width = ttb.Height / 4;
                g.DrawImage(trc, new Rectangle(trackRect.Top, trackRect.Left, trackRect.Bottom - trackRect.Top, trackRect.Right - trackRect.Left), new Rectangle(0, 0, trc.Width, trc.Height), GraphicsUnit.Pixel);
                g.DrawImage(ttb, new Rectangle(thumbRect.Left, thumbRect.Top, thumbRect.Right - thumbRect.Left, thumbRect.Bottom - thumbRect.Top), new Rectangle(0, width * state, ttb.Width, width), GraphicsUnit.Pixel);
            }
            g.Dispose();
            g = Graphics.FromHwnd(_hTrackBarWnd);
            BitBlt(g.GetHdc(), 0, 0, ctlRect.Right, ctlRect.Bottom, tempDc.Hdc, 0, 0, 0xCC0020);
            g.ReleaseHdc();
            tempDc.Dispose();
            g.Dispose();
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

        private bool Hovering(RECT thumbRect)
        {
            RECT windowRect = new RECT();
            Point pos = new Point();

            GetWindowRect(_hTrackBarWnd, ref windowRect);
            OffsetRect(ref thumbRect, windowRect.Left, windowRect.Top);
            GetCursorPos(ref pos);
            if (PtInRect(ref thumbRect, pos))
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
                        drawTrackBar();
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
