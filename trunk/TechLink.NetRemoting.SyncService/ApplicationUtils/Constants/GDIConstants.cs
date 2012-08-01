using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ApplicationUtils.Constants
{
	public static class GDIConstants
	{
		public static readonly Color MainSelectionColor = Color.FromArgb(114, 136, 171);
		public static readonly Color MouseOverColor = Color.FromArgb(179, 185, 195);
		public static readonly Color InactiveElementsColor = Color.FromArgb(215, 219, 224);
		public static readonly Color ButtonBackColor = Color.FromArgb(234, 238, 241);

		private static Color emptyInactiveColor = Color.DimGray;
		private static Color emptyActiveColor = Color.DimGray;

		public static Color PrymarySystemColor = Color.Red;


		public static Color EmptyInactiveColor
		{
			get
			{
				return emptyInactiveColor;
			}
			set
			{
				emptyInactiveColor = value;
				emptyInactiveBrush = new SolidBrush(emptyInactiveColor);
				emptyInactivePen = new Pen(emptyInactiveColor);
			}
		}

		public static Color EmptyActiveColor
		{
			get
			{
				return emptyActiveColor;
			}
			set
			{
				emptyActiveColor = value;
			}
		}

		public static readonly Font UIPicoFont = new Font("Tahoma", 6.25F);
		public static readonly Font uISmallFont = new Font("Tahoma", 8.25F);
		public static readonly Font uIStandardFont = new Font("Tahoma", 8.5F);
		public static readonly Font uIStandardBoldFont = new Font("Tahoma", 8.5F, FontStyle.Bold);
		public static readonly Font uIStandardItalicFont = new Font("Tahoma", 8.5F, FontStyle.Italic);
		public static readonly Font uIStandardBoldItalicFont = new Font("Tahoma", 8.5F, FontStyle.Bold | FontStyle.Italic);
		public static readonly Font uIStandardStrikeOutFont = new Font("Tahoma", 8.5F, FontStyle.Strikeout);
		public static readonly Font userDataStandardFont = new Font("Tahoma", 8.5F);
		public static readonly Font userDataBigFont = new Font("Tahoma", 14F);
		public static readonly Font uIMediumBoldFont = new Font("Arial Black", 11.5F);
		public static readonly Font uIMediumBoldItalicFont = new Font("Arial", 11.5F, FontStyle.Bold | FontStyle.Italic);
		public static readonly Font titleFormatFont = new Font("Tahoma", 10.5F, FontStyle.Bold);
		public static readonly Font titleFormatBigFont = new Font("Tahoma", 12F, FontStyle.Bold);
		public static readonly Font uISansSerifFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
		public static readonly Font uIStandardFontUnderLine = new Font("Tahoma", 8.5F, FontStyle.Underline);

		public static readonly Color ProcessPastColor = Color.LightGray;
		public static readonly Color ProcessPastSelectedColor = Color.Gray;
		public static readonly Color ProcessPresentColor = Color.FromArgb(111, 148, 185);
		public static readonly Color ProcessPresentSelectedColor = Color.FromArgb(66, 101, 136);

		public static readonly Color GenericHelpSelectionColor = Color.FromArgb(132, 109, 131);
		public static readonly Color GoalDefinitionAlternateColor = Color.FromArgb(229, 174, 226);

		public static readonly Color InvertedForeColor = Color.White;
		public static readonly Color InvertedBackColor = Color.Black;


		public static readonly Font uIListItemFont = new Font("Microsoft Sans Serif", 8.25F);


		public static Font UIListItemFont
		{
			get
			{
				return uIListItemFont;
			}
		}

		public static Font UISmallFont
		{
			get
			{
				return uISmallFont;
			}
		}

		public static Font UIStandardFont
		{
			get
			{
				return uIStandardFont;
			}
		}

		public static Font UIStandardBoldFont
		{
			get
			{
				return uIStandardBoldFont;
			}
		}

		public static Font UIStandardItalicFont
		{
			get
			{
				return uIStandardItalicFont;
			}
		}

		public static Font UIStandardBoldItalicFont
		{
			get
			{
				return uIStandardBoldItalicFont;
			}
		}

		public static Font UIStandardStrikeOutFont
		{
			get
			{
				return uIStandardStrikeOutFont;
			}
		}

		public static Font UserDataStandardFont
		{
			get
			{
				return userDataStandardFont;
			}
		}

		public static Font UserDataBigFont
		{
			get
			{
				return userDataBigFont;
			}
		}

		public static Font UIMediumBoldFont
		{
			get
			{
				return uIMediumBoldFont;
			}
		}

		public static Font UIMediumBoldItalicFont
		{
			get
			{
				return uIMediumBoldItalicFont;
			}
		}

		public static Font TitleFormatFont
		{
			get
			{
				return titleFormatFont;
			}
		}

		public static Font TitleFormatBigFont
		{
			get
			{
				return titleFormatBigFont;
			}
		}

		public static Font UISansSerifFont
		{
			get
			{
				return uISansSerifFont;
			}
		}

		public static Font UIStandardFontUnderLine
		{
			get
			{
				return uIStandardFontUnderLine;
			}
		}

		#region --- SimpleTextBox ---

		public static readonly Color SimpleTextBoxNormalForeColor = Color.Black;
		public static readonly Color SimpleTextBoxNormalBackColor = Color.White;
		public static readonly Color SimpleTextBoxNormalBorderColor = Color.White;
		public static readonly Color SimpleTextBoxEditingForeColor = Color.Black;
		public static readonly Color SimpleTextBoxEditingBackColor = Color.White;
		public static readonly Color SimpleTextBoxEditingBorderColor = Color.White;
		public static readonly Color SimpleTextBoxEmptyForeColor = MainSelectionColor;
		public static readonly Color SimpleTextBoxEmptyBackColor = MouseOverColor;
		public static readonly Color SimpleTextBoxEmptyBorderColor = InactiveElementsColor;

		#endregion --- SimpleTextBox ---

		public static Pen emptyInactivePen = Pens.DimGray;
		public static Brush emptyInactiveBrush = Brushes.DimGray;


		public static Pen EmptyInactivePen
		{
			get
			{
				return emptyInactivePen;
			}
		}

		public static Brush EmptyInactiveBrush
		{
			get
			{
				return emptyInactiveBrush;
			}
		}


		public static readonly Color DiagramRelationshipSelectedColor = Color.Blue;
	}
}
