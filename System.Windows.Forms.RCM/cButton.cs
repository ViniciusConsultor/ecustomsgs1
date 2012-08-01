namespace System.Windows.Forms.RCM
{
    #region Directives
    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Drawing;
    using System.Text;
        using System.Collections.Generic;
    #endregion

    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class cButton : IDisposable
    {
        #region Constants
        // drawtext
        private const int DT_TOP = 0x0;
        private const int DT_LEFT = 0x0;
        private const int DT_CENTER = 0x1;
        private const int DT_RIGHT = 0x2;
        private const int DT_VCENTER = 0x4;
        private const int DT_BOTTOM = 0x8;
        private const int DT_WORDBREAK = 0x10;
        private const int DT_SINGLELINE = 0x20;
        private const int DT_EXPANDTABS = 0x40;
        private const int DT_TABSTOP = 0x80;
        private const int DT_NOCLIP = 0x100;
        private const int DT_EXTERNALLEADING = 0x200;
        private const int DT_CALCRECT = 0x400;
        private const int DT_NOPREFIX = 0x800;
        private const int DT_INTERNAL = 0x1000;
        private const int DT_EDITCONTROL = 0x2000;
        private const int DT_PATH_ELLIPSIS = 0x4000;
        private const int DT_END_ELLIPSIS = 0x8000;
        private const int DT_MODIFYSTRING = 0x10000;
        private const int DT_RTLREADING = 0x20000;
        private const int DT_WORD_ELLIPSIS = 0x40000;
        // mouse buttons
        private const int VK_LBUTTON = 0x1;
        private const int VK_RBUTTON = 0x2;
        private const int SM_SWAPBUTTON = 23;
        // button messages
        private const int BM_TRANSPARENT = 0x1;
        private const int BM_GETCHECK = 0xF0;
        private const int BM_SETCHECK = 0xF1;
        private const int BM_GETSTATE = 0xF2;
        private const int BM_SETSTATE = 0xF3;
        private const int BM_SETSTYLE = 0xF4;
        private const int BM_CLICK = 0xF5;
        private const int BM_GETIMAGE = 0xF6;
        private const int BM_SETIMAGE = 0xF7;
        #endregion

        #region Enums
        private enum BUTTONPARTS : int
        {
            BP_UNKNOWN = 0,
            BP_PUSHBUTTON = 1,
            BP_RADIOBUTTON = 2,
            BP_CHECKBOX = 3,
            BP_GROUPBOX = 4,
            BP_USERBUTTON = 5,
            BP_COMMANDLINK = 6,
            BP_COMMANDLINKGLYPH = 7,
        };

        private enum PUSHBUTTONSTATES : int
        {
            PBS_NORMAL = 1,
            PBS_HOT = 2,
            PBS_PRESSED = 3,
            PBS_DISABLED = 4,
            PBS_DEFAULTED = 5,
            PBS_DEFAULTED_ANIMATING = 6,
        };

        private enum RADIOBUTTONSTATES : int
        {
            RBS_UNCHECKEDNORMAL = 1,
            RBS_UNCHECKEDHOT = 2,
            RBS_UNCHECKEDPRESSED = 3,
            RBS_UNCHECKEDDISABLED = 4,
            RBS_CHECKEDNORMAL = 5,
            RBS_CHECKEDHOT = 6,
            RBS_CHECKEDPRESSED = 7,
            RBS_CHECKEDDISABLED = 8,
        };

        private enum CHECKBOXSTATES : int
        {
            CBS_UNCHECKEDNORMAL = 1,
            CBS_UNCHECKEDHOT = 2,
            CBS_UNCHECKEDPRESSED = 3,
            CBS_UNCHECKEDDISABLED = 4,
            CBS_CHECKEDNORMAL = 5,
            CBS_CHECKEDHOT = 6,
            CBS_CHECKEDPRESSED = 7,
            CBS_CHECKEDDISABLED = 8,
            CBS_MIXEDNORMAL = 9,
            CBS_MIXEDHOT = 10,
            CBS_MIXEDPRESSED = 11,
            CBS_MIXEDDISABLED = 12,
            CBS_IMPLICITNORMAL = 13,
            CBS_IMPLICITHOT = 14,
            CBS_IMPLICITPRESSED = 15,
            CBS_IMPLICITDISABLED = 16,
            CBS_EXCLUDEDNORMAL = 17,
            CBS_EXCLUDEDHOT = 18,
            CBS_EXCLUDEDPRESSED = 19,
            CBS_EXCLUDEDDISABLED = 20,
        };

        private enum GROUPBOXSTATES : int
        {
            GBS_NORMAL = 1,
            GBS_DISABLED = 2,
        };

        private enum COMMANDLINKSTATES : int
        {
            CMDLS_NORMAL = 1,
            CMDLS_HOT = 2,
            CMDLS_PRESSED = 3,
            CMDLS_DISABLED = 4,
            CMDLS_DEFAULTED = 5,
            CMDLS_DEFAULTED_ANIMATING = 6,
        };

        private enum COMMANDLINKGLYPHSTATES : int
        {
            CMDLGS_NORMAL = 1,
            CMDLGS_HOT = 2,
            CMDLGS_PRESSED = 3,
            CMDLGS_DISABLED = 4,
            CMDLGS_DEFAULTED = 5,
        };

        private enum ILD_FLAGS : int {
            ILD_NORMAL = 0x00000000,
            ILD_TRANSPARENT = 0x00000001,
            ILD_BLEND25 = 0x00000002,
            ILD_FOCUS = 0x00000002,
            ILD_BLEND50 = 0x00000004,
            ILD_SELECTED = 0x00000004,
            ILD_BLEND = 0x00000004,
            ILD_MASK = 0x00000010,
            ILD_IMAGE = 0x00000020,
            ILD_ROP = 0x00000040,
            ILD_OVERLAYMASK = 0x00000F00,
            ILD_PRESERVEALPHA = 0x00001000,
            ILD_SCALE = 0x00002000,
            ILD_DPISCALE = 0x00004000,
            ILD_ASYNC = 0x00008000
        }

        private enum IMAGE_TYPES : int {
            IMAGE_BITMAP = 0,
            IMAGE_ICON = 1,
            IMAGE_CURSOR = 2
        }

        private enum COLOR_DEPTH : int {
            ILC_COLOR = 0x0,
            ILC_MASK = 0x1,
            ILC_COLOR4 = 0x4,
            ILC_COLOR8 = 0x8,
            ILC_COLOR16 = 0x10,
            ILC_COLOR24 = 0x18,
            ILC_COLOR32 = 0x20,
        }
        #endregion

        #region Structs
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT {
            internal RECT(int X, int Y, int Width, int Height) {
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
        private struct BUTTON_IMAGELIST {
            internal IntPtr himl;
            internal RECT margin;
            internal uint uAlign;
        }
        #endregion

        #region API
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref BUTTON_IMAGELIST lParam);

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

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowEnabled(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetFocus();

        [DllImport("user32.dll")]
        private static extern IntPtr GetProp(IntPtr hWnd, string lpString);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetProp(IntPtr hWnd, string lpString, IntPtr hData);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetClientRect(IntPtr hWnd, ref RECT r);

        [DllImport("gdi32.dll")]
        private static extern int GetPixel(IntPtr hdc, int x, int y);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateSolidBrush(int crColor);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject(IntPtr hObject);

        [DllImport("user32.dll")]
        private static extern int FillRect(IntPtr hDC, [In] ref RECT lprc, IntPtr hbr);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("user32.dll")]
        private extern static int OffsetRect(ref RECT lpRect, int x, int y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool PtInRect([In] ref RECT lprc, Point pt);

        [DllImport("user32.dll")]
        private static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int smIndex);
        #endregion

        #region Fields
        private IntPtr _hParentWnd = IntPtr.Zero;
        private Color _oTransparentColor = Color.Magenta;
        private Bitmap _oTransitionMask;
        private Bitmap _oCheckboxBitmap;
        private Bitmap _oPushbuttonBitmap;
        private cStoreDc _cPushbuttonDc = new cStoreDc();
        private Bitmap _oRadiobuttonBitmap;
        private ImageList _oCheckboxIml;
        private ImageList _oRadiobuttonIml;
        #endregion

        #region Constructor
        /// <summary>
        /// Entry Point.
        /// </summary>
        /// <param name="parentWnd">The parent handle.</param>
        public cButton(IntPtr parentWnd)
        {
            if (parentWnd == IntPtr.Zero)
                throw new Exception("The parent handle is invalid.");
            _hParentWnd = parentWnd;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get/Set the Checkbox bitmap.
        /// </summary>
        public Bitmap CheckboxGraphic
        {
            get { return _oCheckboxBitmap; }
            set
            {
                _oCheckboxBitmap = value;
                initCheckboxIml(_oCheckboxBitmap.Width / 12, _oCheckboxBitmap.Height);
                checkboxAddImages();
            }
        }

        /// <summary>
        /// Get/Set the Pushbutton bitmap.
        /// </summary>
        public Bitmap PushbuttonGraphic
        {
            get { return _oPushbuttonBitmap; }
            set
            {
                _oPushbuttonBitmap = value;
                if (_cPushbuttonDc.Hdc != IntPtr.Zero)
                {
                    _cPushbuttonDc.Dispose();
                    _cPushbuttonDc = new cStoreDc();
                }
                _cPushbuttonDc.Width = _oPushbuttonBitmap.Width;
                _cPushbuttonDc.Height = _oPushbuttonBitmap.Height;
                SelectObject(_cPushbuttonDc.Hdc, _oPushbuttonBitmap.GetHbitmap());

            }
        }

        /// <summary>
        /// Get/Set the Radiobutton bitmap.
        /// </summary>
        public Bitmap RadiobuttonGraphic
        {
            get { return _oRadiobuttonBitmap; }
            set
            {
                _oRadiobuttonBitmap = value;
                initRadiobuttonIml(_oRadiobuttonBitmap.Width / 8, _oRadiobuttonBitmap.Height);
                radiobuttonAddImages();
            }
        }

        /// <summary>
        /// Fader graphic
        /// </summary>
        public Bitmap TransitionGraphic
        {
            get { return _oTransitionMask; }
            set { _oTransitionMask = value; }
        }

        private bool skinCheckbox
        {
            get { return (_oCheckboxIml != null); }
        }

        private bool skinPushbutton
        {
            get { return (_cPushbuttonDc.Hdc != IntPtr.Zero); }
        }

        private bool skinRadiobutton
        {
            get { return (_oRadiobuttonIml != null); }
        }

        private int TransparentColor(IntPtr hdc)
        {
            return GetPixel(hdc, 1, 1);
        }
        #endregion

        #region Events
        private void ctl_Paint(object sender, PaintEventArgs e)
        {
            Control ct = (Control)sender;
            BUTTONPARTS bt = controlType(ct.Handle);
            int state = 0;

            if ((bt == BUTTONPARTS.BP_CHECKBOX) && (skinCheckbox))
            {
                state = (int)checkButtonState(sender) - 1;
                RECT cr = new RECT();
                GetClientRect(ct.Handle, ref cr);
                drawCheckbox(e.Graphics, cr, state);
            }
            else if ((bt == BUTTONPARTS.BP_RADIOBUTTON) && (skinRadiobutton))
            {
                state = (int)radioButtonState(sender) - 1;
                RECT cr = new RECT();
                GetClientRect(ct.Handle, ref cr);
                drawRadiobutton(e.Graphics, cr, state);
            }
            else if ((bt == BUTTONPARTS.BP_PUSHBUTTON) && (skinPushbutton))
            {
                state = (int)pushButtonState(sender) - 1;
                drawPushbutton(sender, e.Graphics, state);
            }
        }


        private void ctl_MouseEnter(object sender, EventArgs e)
        {
            if (TransitionGraphic != null)
            {
                Control ct = (Control)sender;
                cTransition ts = new cTransition(ct.Handle, IntPtr.Zero, _oTransitionMask, ct.ClientRectangle);
            }
        }
        #endregion

        #region Methods
        #region Public
        public void Add(IntPtr handle)
        {
            // store the control type
            SetProp(handle, "style", (IntPtr)buttonStyle(handle));
        }

        public void Remove(IntPtr handle)
        {
            SetProp(handle, "style", (IntPtr)BUTTONPARTS.BP_UNKNOWN);
        }
        #endregion

        #region Helpers
        private BUTTONPARTS buttonStyle(IntPtr handle)
        {
            String name = String.Empty;
            Control ctl = Control.FromHandle(handle);
            Type t = ctl.GetType();
            name = t.Name.ToLower();

            if (name.Contains("radio"))
            {
                ctl.Paint += new PaintEventHandler(ctl_Paint);
                return BUTTONPARTS.BP_RADIOBUTTON;
            }
            if (name.Contains("checkbox"))
            {
                ctl.Paint += new PaintEventHandler(ctl_Paint);
                return BUTTONPARTS.BP_CHECKBOX;
            }
            if (name.Contains("button"))
            {
                ctl.Paint += new PaintEventHandler(ctl_Paint);
                ctl.MouseEnter += new EventHandler(ctl_MouseEnter);
                return BUTTONPARTS.BP_PUSHBUTTON;
            }
            else
                return BUTTONPARTS.BP_UNKNOWN;
        }

        private void checkboxAddImages()
        {
            int width = _oCheckboxBitmap.Height;
            _oCheckboxIml.ImageSize = new Size(width, width);
            _oCheckboxIml.ColorDepth = ColorDepth.Depth32Bit;
            for (int i = 0; i < 12; i++)
            {
                Bitmap bc = _oCheckboxBitmap.Clone(new Rectangle(new Point(i * width, 0), new Size(width, width)), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                _oCheckboxIml.Images.Add(bc);
            }
        }

        private CHECKBOXSTATES checkButtonState(object sender)
        {
            CheckBox chk = (CheckBox)sender;

            if (!chk.Enabled)
            {
                if (chk.CheckState == CheckState.Indeterminate)
                    return CHECKBOXSTATES.CBS_MIXEDDISABLED;
                else if (chk.Checked == true)
                    return CHECKBOXSTATES.CBS_CHECKEDDISABLED;
                else
                    return CHECKBOXSTATES.CBS_UNCHECKEDDISABLED;
            }
            else if (chk.CheckState == CheckState.Checked)
            {
                if ((Pressed()) && (Hovering(chk.Handle)))
                    return CHECKBOXSTATES.CBS_CHECKEDPRESSED;
                if ((Focused(chk.Handle)) || (Hovering(chk.Handle)))
                    return CHECKBOXSTATES.CBS_CHECKEDHOT;
                else
                    return CHECKBOXSTATES.CBS_CHECKEDNORMAL;
            }
            if (chk.CheckState == CheckState.Indeterminate)
            {
                if ((Pressed()) && (Hovering(chk.Handle)))
                    return CHECKBOXSTATES.CBS_MIXEDPRESSED;
                if ((Focused(chk.Handle)) || (Hovering(chk.Handle)))
                    return CHECKBOXSTATES.CBS_MIXEDHOT;
                else
                    return CHECKBOXSTATES.CBS_MIXEDNORMAL;
            }
            if (chk.CheckState == CheckState.Unchecked)
            {
                if ((Pressed()) && (Hovering(chk.Handle)))
                    return CHECKBOXSTATES.CBS_UNCHECKEDPRESSED;
                if ((Focused(chk.Handle)) || (Hovering(chk.Handle)))
                    return CHECKBOXSTATES.CBS_UNCHECKEDHOT;
                else
                    return CHECKBOXSTATES.CBS_UNCHECKEDNORMAL;
            }
            return CHECKBOXSTATES.CBS_UNCHECKEDNORMAL;
        }

        private bool Checked(IntPtr handle)
        {
            return (SendMessage(handle, BM_GETSTATE, IntPtr.Zero, IntPtr.Zero) != 0);
        }

        private BUTTONPARTS controlType(IntPtr handle)
        {
            return (BUTTONPARTS)GetProp(handle, "style");
        }

        public void Dispose()
        {
            try
            {
                //destroyCheckboxIml();
                //destroyRadiobuttonIml();
                // ?wtf? ?fix me?
                //if (_oCheckboxBitmap != null)
                //    _oCheckboxBitmap.Dispose();
                //if (_oRadiobuttonBitmap != null)
                //    _oRadiobuttonBitmap.Dispose();
                //if (_oTransitionMask != null) _oTransitionMask.Dispose();
                //if (_oPushbuttonBitmap != null) _oPushbuttonBitmap.Dispose();
                if (_cPushbuttonDc != null) _cPushbuttonDc.Dispose();
            }
            catch { }
            GC.SuppressFinalize(this);
        }

        private void destroyCheckboxIml()
        {
            if (_oCheckboxIml != null)
            {
                _oCheckboxIml.Images.Clear();
                _oCheckboxIml.Dispose();
            }
        }

        private void destroyRadiobuttonIml()
        {
            if (_oRadiobuttonIml != null)
            {
                _oRadiobuttonIml.Images.Clear();
                _oRadiobuttonIml.Dispose();
            }
        }

        private bool Enabled(IntPtr handle)
        {
            return (IsWindowEnabled(handle));
        }

        private bool Focused(IntPtr handle)
        {
            return (GetFocus() == handle);
        }

        private IntPtr getImage(object sender)
        {
            IntPtr pimg = IntPtr.Zero;
            Button pb = (Button)sender;
            Bitmap bp = (Bitmap)pb.Image;
            if (bp != null)
                pimg = bp.GetHbitmap();
            return pimg;
        }

        private bool Hovering(IntPtr handle)
        {
            RECT tr = new RECT();
            RECT wr = new RECT();
            Point pos = new Point();

            GetClientRect(handle, ref tr);
            GetWindowRect(handle, ref wr);
            OffsetRect(ref tr, wr.Left, wr.Top);
            GetCursorPos(ref pos);
            if (PtInRect(ref tr, pos))
                return true;
            return false;
        }

        private void initCheckboxIml(int width, int height)
        {
            destroyCheckboxIml();
            _oCheckboxIml = new ImageList();
            _oCheckboxIml.TransparentColor = System.Drawing.Color.FromArgb(255, 0, 255);
            _oCheckboxIml.ImageSize = new Size(width, height);
        }

        private void initRadiobuttonIml(int width, int height)
        {
            destroyRadiobuttonIml();
            _oRadiobuttonIml = new ImageList();
            _oRadiobuttonIml.TransparentColor = System.Drawing.Color.FromArgb(255, 0, 255);
            _oRadiobuttonIml.ImageSize = new Size(width, height);
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

        private bool Pressed()
        {
            return (leftKeyPressed());
        }

        private int pushButtonFontFormat(object sender)
        {
            Button pb = (Button)sender;
            int style = 0;
            // text alignment
            if (pb.TextAlign == ContentAlignment.BottomLeft)
                style = DT_LEFT | DT_BOTTOM;
            else if (pb.TextAlign == ContentAlignment.BottomCenter)
                style = DT_CENTER | DT_BOTTOM;
            else if (pb.TextAlign == ContentAlignment.BottomRight)
                style = DT_RIGHT | DT_BOTTOM;

            else if (pb.TextAlign == ContentAlignment.MiddleLeft)
                style = DT_LEFT | DT_VCENTER;
            else if (pb.TextAlign == ContentAlignment.MiddleCenter)
                style = DT_CENTER | DT_VCENTER;
            else if (pb.TextAlign == ContentAlignment.MiddleRight)
                style = DT_RIGHT | DT_VCENTER;

            else if (pb.TextAlign == ContentAlignment.TopLeft)
                style = DT_LEFT | DT_TOP;
            else if (pb.TextAlign == ContentAlignment.TopCenter)
                style = DT_CENTER | DT_TOP;
            else if (pb.TextAlign == ContentAlignment.TopRight)
                style = DT_RIGHT | DT_TOP;
            if (pb.RightToLeft == RightToLeft.Yes)
                style += DT_RTLREADING;
            return style;
        }

        private PUSHBUTTONSTATES pushButtonState(object sender)
        {
            Button pb = (Button)sender;

            if (!pb.Enabled)
            {
                return PUSHBUTTONSTATES.PBS_DISABLED;
            }
            else
            {
                if (Pressed() && Focused(pb.Handle))
                    return PUSHBUTTONSTATES.PBS_PRESSED;
                else if (Focused(pb.Handle))
                    return PUSHBUTTONSTATES.PBS_DEFAULTED;
                else if (Hovering(pb.Handle))
                    return PUSHBUTTONSTATES.PBS_HOT;
                else
                    return PUSHBUTTONSTATES.PBS_NORMAL;
            }
        }

        private void radiobuttonAddImages()
        {
            int width = _oRadiobuttonBitmap.Height;
            _oRadiobuttonIml.ImageSize = new Size(width, width);
            _oRadiobuttonIml.ColorDepth = ColorDepth.Depth32Bit;
            for (int i = 0; i < 8; i++)
            {
                Bitmap bc = _oRadiobuttonBitmap.Clone(new Rectangle(new Point(i * width, 0), new Size(width, width)), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                _oRadiobuttonIml.Images.Add(bc);
            }
        }

        private RADIOBUTTONSTATES radioButtonState(object sender)
        {
            RadioButton rdb = (RadioButton)sender;

            if (!rdb.Enabled)
            {
                if (rdb.Checked == true)
                    return RADIOBUTTONSTATES.RBS_CHECKEDDISABLED;
                else
                    return RADIOBUTTONSTATES.RBS_UNCHECKEDDISABLED;
            }
            else
            {
                if (rdb.Checked == true)
                {
                    if ((Pressed()) && (Hovering(rdb.Handle)))
                        return RADIOBUTTONSTATES.RBS_CHECKEDPRESSED;
                    if ((Focused(rdb.Handle)) || (Hovering(rdb.Handle)))
                        return RADIOBUTTONSTATES.RBS_CHECKEDHOT;
                    else
                        return RADIOBUTTONSTATES.RBS_CHECKEDNORMAL;
                }
                else
                {
                    if ((Pressed()) && (Hovering(rdb.Handle)))
                        return RADIOBUTTONSTATES.RBS_CHECKEDPRESSED;
                    else if ((Focused(rdb.Handle)) || (Hovering(rdb.Handle)))
                        return RADIOBUTTONSTATES.RBS_UNCHECKEDHOT;
                    else
                        return RADIOBUTTONSTATES.RBS_UNCHECKEDNORMAL;
                }
            }
        }

        private bool Visible(IntPtr handle)
        {
            return (IsWindowVisible(handle));
        }
        #endregion

        #region Graphics
        private void drawCheckbox(Graphics g, RECT bounds, int state)
        {
            int height = _oCheckboxBitmap.Height;
            
            // horizontal offset
            int offset = (bounds.Bottom - height) / 2;
            RECT picRect = new RECT(0, 0, 16, 16);
            IntPtr hdc = g.GetHdc();
            IntPtr hbrush = CreateSolidBrush(GetPixel(hdc, 0, 0));
            FillRect(hdc, ref picRect, hbrush);
            g.ReleaseHdc();
            DeleteObject(hbrush);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            _oCheckboxIml.Draw(g, 1, offset, height, height, state);
        }

        private void drawPushbutton(object sender, Graphics g, int state)
        {
            int width = _oPushbuttonBitmap.Width / 5;
            int offset = state * width;
            IntPtr hdc = g.GetHdc();
            Button btn = (Button)sender;
            RECT bounds = new RECT(0, 0, btn.Width, btn.Height);

            // back fill
            IntPtr hbrush = CreateSolidBrush(GetPixel(hdc, 0, 0));
            FillRect(hdc, ref bounds, hbrush);
            DeleteObject(hbrush);
            using (StretchMode mode = new StretchMode(hdc, StretchModeEnum.STRETCH_HALFTONE))
            {
                // blit the corners: top left
                BitBlt(hdc, 0, 0, 4, 4, _cPushbuttonDc.Hdc, offset, 0, 0xCC0020);
                // bottom left
                BitBlt(hdc, 0, bounds.Bottom - 4, 4, 4, _cPushbuttonDc.Hdc, offset, _cPushbuttonDc.Height - 4, 0xCC0020);
                // top right
                BitBlt(hdc, bounds.Right - 4, 0, 4, 4, _cPushbuttonDc.Hdc, (offset + width) - 4, 0, 0xCC0020);
                // bottom right
                BitBlt(hdc, bounds.Right - 4, bounds.Bottom - 4, 4, 4, _cPushbuttonDc.Hdc, (offset + width) - 4, _cPushbuttonDc.Height - 4, 0xCC0020);
                // fill in the sides: left
                StretchBlt(hdc, 0, 4, 4, bounds.Bottom - 8, _cPushbuttonDc.Hdc, offset, 4, 4, _cPushbuttonDc.Height - 8, 0xCC0020);
                // right
                StretchBlt(hdc, bounds.Right - 4, 4, 4, bounds.Bottom - 8, _cPushbuttonDc.Hdc, (offset + width) - 4, 4, 4, _cPushbuttonDc.Height - 8, 0xCC0020);
                // top
                StretchBlt(hdc, 4, 0, bounds.Right - 8, 4, _cPushbuttonDc.Hdc, offset + 4, 0, width - 8, 4, 0xCC0020);
                // bottom
                StretchBlt(hdc, 4, bounds.Bottom - 4, bounds.Right - 8, 4, _cPushbuttonDc.Hdc, offset + 4, _cPushbuttonDc.Height - 4, width - 8, 4, 0xCC0020);
                // draw the center
                StretchBlt(hdc, 4, 4, bounds.Right - 8, bounds.Bottom - 8, _cPushbuttonDc.Hdc, offset + 4, 4, width - 8, _cPushbuttonDc.Height - 8, 0xCC0020);
            }
            g.ReleaseHdc();

            // draw the image
            if (btn.Image != null)
            {
                int imgwidth = btn.Image.Width;
                int imgheight = btn.Image.Height;
                // image alignment: bottom
                if (btn.ImageAlign == ContentAlignment.BottomCenter)
                    g.DrawImage(btn.Image, new Point((bounds.Right - (imgwidth + 4)) / 2, bounds.Bottom - (imgheight + 4)));
                else if (btn.ImageAlign == ContentAlignment.BottomLeft)
                    g.DrawImage(btn.Image, new Point(4, bounds.Bottom - (imgheight + 4)));
                else if (btn.ImageAlign == ContentAlignment.BottomRight)
                    g.DrawImage(btn.Image, new Point(bounds.Right - (imgwidth + 4), bounds.Bottom - (imgheight + 4)));
                //middle
                else if (btn.ImageAlign == ContentAlignment.MiddleCenter)
                    g.DrawImage(btn.Image, new Point((bounds.Right - (imgwidth + 4)) / 2, (bounds.Bottom - (imgheight + 4)) / 2));
                else if (btn.ImageAlign == ContentAlignment.MiddleLeft)
                    g.DrawImage(btn.Image, new Point(4, (bounds.Bottom - (imgheight + 4)) / 2));
                else if (btn.ImageAlign == ContentAlignment.MiddleRight)
                    g.DrawImage(btn.Image, new Point(bounds.Right - (imgwidth + 4), (bounds.Bottom - (imgheight + 4)) / 2));
                // top
                else if (btn.ImageAlign == ContentAlignment.TopCenter)
                    g.DrawImage(btn.Image, new Point((bounds.Right - (imgwidth + 4)) / 2, 4));
                else if (btn.ImageAlign == ContentAlignment.TopLeft)
                    g.DrawImage(btn.Image, new Point(4, 4));
                else if (btn.ImageAlign == ContentAlignment.TopRight)
                    g.DrawImage(btn.Image, new Point(bounds.Right - (imgwidth + 4), 4));
            }

            // draw the text
            using (StringFormat sf = new StringFormat())
            {
                sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
                sf.FormatFlags = StringFormatFlags.NoWrap;
                // text alignment: bottom
                if (btn.TextAlign == ContentAlignment.BottomCenter)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Far;
                }
                else if (btn.TextAlign == ContentAlignment.BottomLeft)
                {
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Far;
                }
                else if (btn.TextAlign == ContentAlignment.BottomRight)
                {
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Far;
                }
                // middle
                else if (btn.TextAlign == ContentAlignment.MiddleCenter)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                }
                else if (btn.TextAlign == ContentAlignment.MiddleLeft)
                {
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Center;
                }
                else if (btn.TextAlign == ContentAlignment.MiddleRight)
                {
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Center;
                }
                // top
                else if (btn.TextAlign == ContentAlignment.TopCenter)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;
                }
                else if (btn.TextAlign == ContentAlignment.TopLeft)
                {
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                }
                else if (btn.TextAlign == ContentAlignment.TopRight)
                {
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Near;
                }

                if (btn.RightToLeft == RightToLeft.Yes)
                    sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;

                Brush ht = new SolidBrush(btn.ForeColor);
                g.DrawString(btn.Text, btn.Font, ht, new RectangleF(0, 0, bounds.Right - 4, bounds.Bottom - 4), sf);
                ht.Dispose();
            }
        }

        private void drawRadiobutton(Graphics g, RECT bounds, int state)
        {
            int height = _oRadiobuttonBitmap.Height;
            // horizontal offset
            int offset = (bounds.Bottom - height) / 2;
            RECT picRect = new RECT(0, 0, 16, 16);
            IntPtr hdc = g.GetHdc();
            IntPtr hbrush = CreateSolidBrush(GetPixel(hdc, 0, 0));

            FillRect(hdc, ref picRect, hbrush);
            g.ReleaseHdc();
            DeleteObject(hbrush);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            _oRadiobuttonIml.Draw(g, 1, offset, height, height, state);
        }
        #endregion
        #endregion
    }
}
