using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace EnumConstant.Constant
{
	public class ColorsTable
	{
		public static Color TextBoxBackGround = Color.FromArgb(234, 234, 234);
		public static Color TextBoxHelperEmphasiseBackGround = Color.FromArgb(255, 255, 192);
		public static Color TextBoxHelperLowEmphasiseBackGround = Color.FromArgb(255, 224, 192);
		public static Color TextBoxHelperBackGround = Color.FromArgb(224, 224, 224);
		public static Color TextBoxHelperForeColor = Color.FromArgb(223, 223, 223);
		public static Color TextBoxHelperForeColorValue = Color.Black;
		public static Color TextBoxForeColorValue = Color.Black;


		#region used for Form
		public static Color LabelDefaultForeColor = Color.Black;
		public static Color LabelDefaultBackgroundColor = Color.White;
		public static Color ButtonBorderColor = Color.Silver;
		public static Color ButtonDefaultBgColor = Color.White;
		public static Color ButtonMouseDownBgColor = Color.Silver;
		public static Color ButtonMouseOverBgColor = Color.FromArgb(224,224,224);

		public static Font LabelDefaultFont
		{
			get
			{
				Font font = new Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel);
				return font;
			}
		}

		public static Font LabelEmphasiseFont
		{
			get
			{
				Font font = new Font("Tahoma", 11, FontStyle.Bold, GraphicsUnit.Pixel);
				return font;
			}
		}

		public static Font LabelEmphasiseBigFont
		{
			get
			{
				Font font = new Font("Tahoma", 14, FontStyle.Bold, GraphicsUnit.Pixel);
				return font;
			}
		}
		#endregion


		public static Font SellingGridFont
		{
			get
			{
				Font font = new Font("Tahoma", 10, FontStyle.Bold, GraphicsUnit.Pixel);
				return font;
			}
		}

		public static Font ButtonDefaultFont

		{
			get
			{
				Font font = new Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel);
				return font;
			}
		}
	}
}
