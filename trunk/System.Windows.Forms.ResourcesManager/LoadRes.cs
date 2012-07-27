using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.RCM;

namespace System.Windows.Forms.ResourcesManager
{
    public class LoadRes
    {
        public static void LoadControlImages( cRCM _cRcm, int index)
        {
            // skin controls in containers [tabcontrol]
            _cRcm.SkinChildControls = true;
            // fade graphic
            _cRcm.TransitionGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.fader;
            // use custom tooltips
            _cRcm.UseCustomTips = true;
            switch (index)
            {
                case 0:
                    //add control types
                    _cRcm.Add(ControlType.Button, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_command);
                    _cRcm.Add(ControlType.CheckBox, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_checkbox);
                    _cRcm.Add(ControlType.ComboBox, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_combo);
                    _cRcm.Add(ControlType.ListBox, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollHorzShaft, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollHorzArrow, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollHorzThumb, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollVertShaft, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollVertArrow, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollVertThumb);
                    _cRcm.Add(ControlType.ListView, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_header, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollHorzShaft, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollHorzArrow, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollHorzThumb, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollVertShaft, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollVertArrow, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollVertThumb);
                    _cRcm.Add(ControlType.ProgressBar, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_Progress);
                    _cRcm.Add(ControlType.NumericUpDown, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_spin);
                    _cRcm.Add(ControlType.RadioButton, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_radiobutton);
                    _cRcm.Add(ControlType.ScrollBar, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollHorzShaft, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollHorzArrow, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollHorzThumb, Orientation.Horizontal);
                    _cRcm.Add(ControlType.ScrollBar, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollVertShaft, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollVertArrow, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollVertThumb, Orientation.Vertical);
                    _cRcm.Add(ControlType.TabControl, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_blue_Tab);
                    _cRcm.Add(ControlType.TrackBar, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_thumb, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_Track);
                    _cRcm.Add(ControlType.TreeView, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollHorzShaft, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollHorzArrow, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollHorzThumb, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollVertShaft, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollVertArrow, System.Windows.Forms.ResourcesManager.Properties.Resources.vista_ScrollVertThumb);
                    break;

                case 1:
                    _cRcm.Add(ControlType.Button, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_command);
                    _cRcm.Add(ControlType.CheckBox, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_checkbox);
                    _cRcm.Add(ControlType.ComboBox, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_combo);
                    _cRcm.Add(ControlType.ListBox, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollHorzShaft, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollHorzArrow, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollHorzThumb, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollVertShaft, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollVertArrow, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollVertThumb);
                    _cRcm.Add(ControlType.ListView, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_header, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollHorzShaft, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollHorzArrow, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollHorzThumb, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollVertShaft, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollVertArrow, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollVertThumb);
                    _cRcm.Add(ControlType.ProgressBar, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_Progress);
                    _cRcm.Add(ControlType.NumericUpDown, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_spin);
                    _cRcm.Add(ControlType.RadioButton, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_radiobutton);
                    _cRcm.Add(ControlType.ScrollBar, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollHorzShaft, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollHorzArrow, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollHorzThumb, Orientation.Horizontal);
                    _cRcm.Add(ControlType.ScrollBar, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollVertShaft, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollVertArrow, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollVertThumb, Orientation.Vertical);
                    _cRcm.Add(ControlType.TabControl, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_Tab);
                    _cRcm.Add(ControlType.TrackBar, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_thumb, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_Track);
                    _cRcm.Add(ControlType.TreeView, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollHorzShaft, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollHorzArrow, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollHorzThumb, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollVertShaft, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollVertArrow, System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_ScrollVertThumb);
                    break;
            }
        }

        public static void LoadFrameImages(cRCM _cRcm, int index)
        {
            switch (index)
            {
                case 0:
                    _cRcm.LeftFrameGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vista_blue_FrameLeft;
                    _cRcm.RightFrameGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vista_blue_FrameRight;
                    _cRcm.CaptionBarGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vista_blue_FrameTop;
                    _cRcm.BottomFrameGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vista_blue_FrameBottom;
                    _cRcm.CloseButtonGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vista_blue_closebutton;
                    _cRcm.MaximizeButtonGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vista_blue_maxbutton;
                    _cRcm.RestoreButtonGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vista_blue_restorebutton;
                    _cRcm.MinimizeButtonGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vista_blue_minbutton;
                    _cRcm.HelpButtonGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vista_blue_helpbutton;
                    _cRcm.ForeColor = System.Drawing.Color.FromArgb(21, 66, 139);
                    break;
                case 1:
                    _cRcm.LeftFrameGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vista_FrameLeft;
                    _cRcm.RightFrameGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vista_FrameRight;
                    _cRcm.CaptionBarGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vista_FrameTop;
                    _cRcm.BottomFrameGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vista_FrameBottom;
                    _cRcm.CloseButtonGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vista_closebutton;
                    _cRcm.MaximizeButtonGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vista_maxbutton;
                    _cRcm.RestoreButtonGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vista_restorebutton;
                    _cRcm.MinimizeButtonGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vista_minbutton;
                    break;

                case 2:
                    _cRcm.LeftFrameGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_FrameLeft;
                    _cRcm.RightFrameGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_FrameRight;
                    _cRcm.CaptionBarGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_FrameTop;
                    _cRcm.BottomFrameGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_FrameBottom;
                    _cRcm.CloseButtonGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_closebutton;
                    _cRcm.MaximizeButtonGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_maxbutton;
                    _cRcm.RestoreButtonGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_restorebutton;
                    _cRcm.MinimizeButtonGraphic = System.Windows.Forms.ResourcesManager.Properties.Resources.vienna_minbutton;
                    break;
            }
        }
    }
}
