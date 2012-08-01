using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ApplicationUtils.Utils
{
	/// <summary>
	/// Encapsulateas common GDI+ functions for custom shapes
	/// </summary>
	public class GDIHelper
	{
		public static void PaintCheckMark(Graphics g, Rectangle rect, float thickness, Color color)
		{
			using (Pen pen = new Pen(color, thickness))
			{
				g.DrawLine(pen,
				           rect.Left + rect.Width*.18f,
				           rect.Top + rect.Height/2 - 1,
				           rect.Left + rect.Width*.4f,
				           rect.Bottom - 1
					);
				g.DrawLine(pen,
				           rect.Left + rect.Width*.4f,
				           rect.Bottom - 1,
				           rect.Left + rect.Width*.9f,
				           rect.Top - 2
					);
			}
		}

		public static void PaindCircleWithUpArrows(Graphics g, Rectangle rect, float thickness, Color color)
		{
			using (Pen pen = new Pen(color, thickness))
			{
				g.DrawEllipse(pen, rect);
				rect.Inflate(1, 1);
				int x = rect.Width;
				int y = rect.Height;
				Point p1 = new Point();
				Point p2 = new Point();

				p1.X = (3*x)/8;
				p1.Y = y/2;
				p2.X = x/2;
				p2.Y = y/4;
				g.DrawLine(pen, p1, p2);


				p1.X = (5*x)/8;
				p1.Y = y/2;
				g.DrawLine(pen, p2, p1);

				p1.X = (3*x)/8;
				p1.Y = (3*y)/4;
				p2.X = x/2;
				p2.Y = y/2;
				g.DrawLine(pen, p1, p2);


				p1.X = (5*x)/8;
				p1.Y = 3*y/4;
				g.DrawLine(pen, p2, p1);
			}
		}

		public static GraphicsPath GetRectangleRegion(Rectangle rect)
		{
			GraphicsPath gp = new GraphicsPath();
			gp.StartFigure();
			gp.AddLine(rect.Left, rect.Top, rect.Right, rect.Top);
			gp.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom);
			gp.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
			gp.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top);
			gp.CloseFigure();
			return gp;
		}

		public static GraphicsPath GetCornerlessRectangleRegionFill(Rectangle rect, int drawOffset, bool roundLeft, bool roundRight)
		{
			int offset = 0;

			GraphicsPath gp = new GraphicsPath();
			gp.StartFigure();

			offset = roundRight ? drawOffset : 0;
			gp.AddLine(rect.Right - offset, rect.Top, rect.Right, rect.Top + offset);
			gp.AddLine(rect.Right, rect.Bottom - offset, rect.Right - offset - 1, rect.Bottom + 1);

			offset = roundLeft ? drawOffset : 0;
			gp.AddLine(rect.Left + offset + 1, rect.Bottom + 1, rect.Left, rect.Bottom - offset);
			gp.AddLine(rect.Left, rect.Top + offset, rect.Left + offset, rect.Top);

			gp.CloseFigure();
			return gp;
		}

		public static GraphicsPath GetCornerlessRectangleRegion(Rectangle rect, int drawOffset, bool roundLeft, bool roundRight)
		{
			int offset = 0;

			GraphicsPath gp = new GraphicsPath();
			gp.StartFigure();

			offset = roundRight ? drawOffset : 0;
			gp.AddLine(rect.Right - offset, rect.Top, rect.Right, rect.Top + offset);
			gp.AddLine(rect.Right, rect.Bottom - offset, rect.Right - offset, rect.Bottom);

			offset = roundLeft ? drawOffset : 0;
			gp.AddLine(rect.Left + offset, rect.Bottom, rect.Left, rect.Bottom - offset);
			gp.AddLine(rect.Left, rect.Top + offset, rect.Left + offset, rect.Top);

			gp.CloseFigure();
			return gp;
		}

		public static GraphicsPath GetRoundRectangleRegion(Rectangle rect, int offset)
		{
			GraphicsPath gp = new GraphicsPath();
			gp.StartFigure();
			gp.AddArc(rect.Left, rect.Top, offset, offset, 270, -90);
			gp.AddArc(rect.Left, rect.Bottom - offset, offset, offset, 180, -90);
			gp.AddArc(rect.Right - offset, rect.Bottom - offset, offset, offset, 90, -90);
			gp.AddArc(rect.Right - offset, rect.Top, offset, offset, 0, -90);
			gp.CloseFigure();
			return gp;
		}

		public static Region GetRoundRectangleRegion(Rectangle rect)
		{
			using (GraphicsPath gp = GetRoundRectangleRegion(rect, 15))
			{
				return new Region(gp);
			}
		}

		public static void PaintDiamond(Graphics g, int x, int y, Color color)
		{
			int xStart = x;
			GraphicsPath gp = new GraphicsPath();

			gp.StartFigure();
			gp.AddLine(xStart, y, xStart + 5, y + 5);
			gp.AddLine(xStart + 5, y + 5, xStart, y + 10);
			gp.AddLine(xStart, y + 10, xStart - 5, y + 5);
			gp.AddLine(xStart - 5, y + 5, xStart, y);
			gp.CloseFigure();
			Region region = new Region(gp);
			using (Brush brush = new SolidBrush(color))
				g.FillRegion(brush, region);
			Point[] points = new Point[] {new Point(xStart, y), new Point(xStart + 5, y + 5), new Point(xStart, y + 10), new Point(xStart - 5, y + 5)};
			g.DrawPolygon(Pens.Black, points);
		}

		public static void PaintDownArrow(Graphics g, int x, int y, int arrowBaseWidth, int arrowHeight, Color color, Color borderColor)
		{
			GraphicsPath gp = new GraphicsPath();

			gp.StartFigure();
			gp.AddLine(x - arrowBaseWidth/2, y, x + arrowBaseWidth/2, y);
			gp.AddLine(x + arrowBaseWidth/2, y, x, y + arrowHeight);
			gp.CloseFigure();
			Region region = new Region(gp);
			using (Brush brush = new SolidBrush(color))
				g.FillRegion(brush, region);
			Point[] points = new Point[] {new Point(x - arrowBaseWidth/2, y), new Point(x + arrowBaseWidth/2, y), new Point(x, y + arrowHeight)};
			using (Pen pen = new Pen(borderColor))
				g.DrawPolygon(pen, points);
		}

		public static void PaintRightArrow(Graphics g, int x, int y, int arrowBaseHeight, int arrowLength, Color color)
		{
			GraphicsPath gp = new GraphicsPath();

			gp.StartFigure();
			gp.AddLine(x, y, x, y + arrowBaseHeight);
			gp.AddLine(x, y + arrowBaseHeight, x + arrowLength, y + arrowBaseHeight/2);
			gp.CloseFigure();
			Region region = new Region(gp);
			using (Brush brush = new SolidBrush(color))
				g.FillRegion(brush, region);
		}

		public static void PaintUpTriangle(Graphics g, int x, int y, int arrowBaseWidth, int arrowHeight, Color color)
		{
			GraphicsPath gp = new GraphicsPath();

			gp.StartFigure();
			gp.AddLine(x, y + arrowHeight, x + arrowBaseWidth, y + arrowHeight);
			gp.AddLine(x + arrowBaseWidth, y + arrowHeight, x + arrowBaseWidth/2, y);
			gp.CloseFigure();

			using (Brush brush = new SolidBrush(color))
				g.FillPath(brush, gp);
		}

		public static float GetCenteredTextYPos(Graphics g, Rectangle drawRect, Font textFont)
		{
			float textHeight = g.MeasureString("H", textFont, 1000, StringFormat.GenericTypographic).Height;
			return drawRect.Y+(((float)drawRect.Height + 1) / 2 - textHeight / 2);
		}

		public static PointF GetCenteredTextPos(Graphics g, string text, float offset, Rectangle drawRect, Font textFont)
		{
			SizeF textSize = g.MeasureString(text, textFont, 1000, StringFormat.GenericTypographic);
			float textHeight = textSize.Height;
			float textWidth = textSize.Width;
			return new PointF((((float) drawRect.Width + 1 - offset)/2 - textWidth/2) + drawRect.Left, (((float) drawRect.Height + 1)/2 - textHeight/2) + drawRect.Top);
		}

		public static PointF GetLeftCenteredTextPos(Graphics g, string text, Rectangle drawRect, Font textFont)
		{
			SizeF textSize = g.MeasureString(text, textFont, 1000, StringFormat.GenericTypographic);
			float textHeight = textSize.Height;
			return new PointF(drawRect.Left, (((float) drawRect.Height + 1)/2 - textHeight/2) + drawRect.Top);
		}

		public static string FittedText(Graphics g, string text, Font font, int width)
		{
			SizeF layoutArea = new SizeF(width, font.GetHeight(g));
			StringFormat newStringFormat = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.MeasureTrailingSpaces);

			int linesFilled = 0;
			int charactersFitted = 0;

			g.MeasureString(text, font, layoutArea, newStringFormat, out charactersFitted, out linesFilled);
			
			if (text != null && charactersFitted < text.Length)
			{
				if (charactersFitted < 1)
					charactersFitted = 1;
				string fitText = text.Substring(0, charactersFitted - 1) + "…";
				return fitText;
			}

			return text;
		}

		public static string[] FittedTextWords(Graphics g, string text, Font font, int width)
		{
			if (text == "" || font == null || width < 0)
				return new string[] {""};

			int linesFilled = 0;
			int charactersFitted = 0;
			int minChars = 8;

			SizeF layoutArea = new SizeF(width, font.GetHeight(g));
			StringFormat newStringFormat = new StringFormat(StringFormatFlags.MeasureTrailingSpaces);

			ArrayList lines = new ArrayList();

			string textToFit = text;
			string lineText = "";
			while (true)
			{
				g.MeasureString(textToFit, font, layoutArea, newStringFormat, out charactersFitted, out linesFilled);

				if (textToFit.Length > charactersFitted)
				{
					int i = 0;
					bool enter = false;
					while (i < charactersFitted - 1)
					{
						string ch = textToFit.Substring(charactersFitted - i, 1);
						if (ch.IndexOfAny(StringHelper.WordsSeparator) > -1)
							break;
						if (ch == "\n")
						{
							enter = true;
							break;
						}
						i++;
					}

					if (i > charactersFitted - minChars)
					{
						i = 0;
					}
					charactersFitted -= i;
					lineText = textToFit.Substring(0, charactersFitted);
					if (lineText.Length > 1 && lineText.Substring(lineText.Length - 1, 1) == "\n")
					{
						lineText = textToFit.Substring(0, charactersFitted - 1);
						lines.Add(lineText);
						lines.Add("");
					}
					else
					{
						lines.Add(lineText);
					}
					if (enter)
						charactersFitted++;
					textToFit = textToFit.Substring(charactersFitted);
				}
				else
				{
					lines.Add(textToFit);
					break;
				}
			}

			string[] textWords = new string[lines.Count];
			for (int i = 0; i < lines.Count; i++)
				textWords[i] = ((string) lines[i]).TrimStart(' ');

			return textWords;
		}

		public static Rectangle GetRectInTextByCharIdx_(Graphics g, string text, Font font, int startIdx, int lastIdx)
		{
			StringFormat newStringFormat = new StringFormat(StringFormat.GenericTypographic);
			newStringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;

			string newText = text.Substring(0, startIdx);
			Size textSize = new Size(20, 20);
			int rectLeft = 0;
			if (newText != "")
			{
				//Size textSize=g.MeasureString(newText, font,1000, newStringFormat).ToSize();
				textSize = MeasureDisplayStringSize(newText, font);
				rectLeft = textSize.Width;
			}

			newText = text.Substring(0, lastIdx);
			int rectWidth = 0;
			if (newText != "")
			{
				//textSize=g.MeasureString(newText, font,1000, newStringFormat).ToSize();
				textSize = MeasureDisplayStringSize(newText, font);
				rectWidth = textSize.Width - rectLeft;
			}

			return new Rectangle(rectLeft, 0, rectWidth, textSize.Height);
		}

		public static Rectangle GetRectInTextByCharIdx(string text, Font font, int startIdx, int lastIdx)
		{
			StringFormat newStringFormat = new StringFormat(StringFormat.GenericTypographic);
			newStringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;

			string newText = text.Substring(0, startIdx);
			Size textSize = new Size(20, 20);
			int rectLeft = 0;
			if (newText != "")
			{
				//Size textSize=g.MeasureString(newText, font,1000, newStringFormat).ToSize();
				textSize = MeasureDisplayStringSize(newText, font);
				rectLeft = textSize.Width;
			}

			newText = text.Substring(0, lastIdx);
			int rectWidth = 0;
			if (newText != "")
			{
				//textSize=g.MeasureString(newText, font,1000, newStringFormat).ToSize();
				textSize = MeasureDisplayStringSize(newText, font);
				rectWidth = textSize.Width - rectLeft;
			}

			return new Rectangle(rectLeft, 0, rectWidth, textSize.Height);
		}



		public static Size MeasureDisplayStringSize(string text, Font font)
		{
			return TextRenderer.MeasureText(text, font);
		}

		public static Size MeasureDisplayStringSize_(Graphics graphics, string text, Font font)
		{
			if (graphics == null)
			{
				return new Size((int) (text.Length*font.Size), 15);
			}
			StringFormat format = new StringFormat(StringFormat.GenericTypographic);
			format.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;

			RectangleF rect = new RectangleF(0, 0, 2000, 1000);
			CharacterRange[] ranges = {new CharacterRange(0, text.Length)};
			 
			format.SetMeasurableCharacterRanges(ranges);

			if (text == "") text = " "; //otherwise it will crash on next statement

			Region[] regions= graphics.MeasureCharacterRanges(text, font, rect, format);
			rect = regions[0].GetBounds(graphics);
			foreach (Region region in regions)
			{
				region.Dispose();
			}
			return new Size((int) (rect.Right + 1.0f), (int) rect.Height);
		}

		public static GraphicsPath GetRoundLeftRightPath(Rectangle drawRect)
		{
			int offset = drawRect.Height;
			GraphicsPath gp = new GraphicsPath();
			gp.StartFigure();

			//2 round sides
			gp.AddArc(drawRect.Left, drawRect.Top, offset, drawRect.Height, 90, 180);
			gp.AddArc(drawRect.Right - offset, drawRect.Top, offset, drawRect.Height, -90, 180);

			gp.CloseFigure();

			return gp;
		}

		public static GraphicsPath GetRoundLeftPath(Rectangle drawRect)
		{
			Point p1, p2, p3, p4;
			p1 = p2 = p3 = p4 = drawRect.Location;
			p2.X += drawRect.Width;
			p3.X += drawRect.Width;
			p3.Y += drawRect.Height;
			p4.Y += drawRect.Height;

			int offset = drawRect.Height;
			GraphicsPath gp = new GraphicsPath();
			gp.StartFigure();

			//2 round sides
			gp.AddArc(drawRect.Left, drawRect.Top, offset, drawRect.Height, 90, 180);
//			gp.AddArc(drawRect.Right - offset, drawRect.Top, offset, drawRect.Height, -90, 180);
//			gp.AddLine(p1,p2) ;
			gp.AddLine(p2, p3);
//			gp.AddLine(p3,p4) ;


			gp.CloseFigure();

			return gp;
		}

		public static GraphicsPath GetRoundRightPath(Rectangle drawRect)
		{
			Point p1, p2, p3, p4;
			p1 = p2 = p3 = p4 = drawRect.Location;
			p2.X += drawRect.Width;
			p3.X += drawRect.Width;
			p3.Y += drawRect.Height;
			p4.Y += drawRect.Height;

			int offset = drawRect.Height;
			GraphicsPath gp = new GraphicsPath();
			gp.StartFigure();

			//2 round sides
//			gp.AddArc(drawRect.Left, drawRect.Top, offset, drawRect.Height, 90, 180);
			gp.AddArc(drawRect.Right - offset, drawRect.Top, offset, drawRect.Height, -90, 180);
			gp.AddLine(p4, p1);

			gp.CloseFigure();

			return gp;
		}

		protected static GraphicsPath getCrossArrowRegion(int x, int y, int h)
		{
			int lw = h/10;
			if (lw == 0) lw = 1;
			int th = 2*h/9;
			int tw = 2*h/9;
			int cx = x + h/2;
			int cy = y + h/2;

			GraphicsPath gp = new GraphicsPath();
			gp.StartFigure();
			gp.AddLine(cx, y,
			           cx + tw, y + th); //1-2
			gp.AddLine(cx + lw, y + th,
			           cx + lw, cy); //3-4
			gp.AddLine(cx - lw, cy,
			           cx - lw, y + th); //5-6
			gp.AddLine(cx - tw, y + th,
			           cx, y); //7-8
			gp.CloseFigure();

			return gp;
		}

		public static void DrawLeftRightArrow(Graphics g, Point location, int size)
		{
			int x = location.X;
			int y = location.Y;
			int h = size;
			Matrix transformMatrix = new Matrix();
			using(GraphicsPath gp = getCrossArrowRegion(x, y, h))
			{
				transformMatrix.RotateAt(90, new Point(x + h/2, y + h/2));
				gp.Transform(transformMatrix);

				g.FillPath(Brushes.White, gp);

				transformMatrix.RotateAt(90, new Point(x + h/2, y + h/2));
				gp.Transform(transformMatrix);

				g.FillPath(Brushes.White, gp);
			}
		}

		public static void DrawLeftArrows(Graphics g, Rectangle r, Pen pen)
		{
			int left = r.Left;
			int top = r.Top;
			int W = r.Width;
			int H = r.Height;
			g.DrawLine(pen, left + W/2, top, left, top + H/2);
			g.DrawLine(pen, left, top + H/2, left + W/2, top + H);
			g.DrawLine(pen, left + W, top, left + W/2, top + H/2);
			g.DrawLine(pen, left + W/2, top + H/2, left + W, top + H);
		}

		public static void DrawRightArrows(Graphics g, Rectangle r, Pen pen)
		{
			int left = r.Left;
			int top = r.Top;

			int W = r.Width;
			int H = r.Height;
			g.DrawLine(pen, left, top, left + W/2, top + H/2);
			g.DrawLine(pen, left + W/2, top + H/2, left, top + H);
			g.DrawLine(pen, left + W/2, top, left + W, top + H/2);
			g.DrawLine(pen, left + W, top + H/2, left + W/2, top + H);
		}


		public static void DrawDownArrows(Graphics g, Rectangle r, Pen pen)
		{
			int left = r.Left;
			int top = r.Top;

			int W = r.Width;
			int H = r.Height;
			g.DrawLine(pen, left, top, left + W/2, top + H/2);
			g.DrawLine(pen, left + W/2, top + H/2, left + W, top);
			g.DrawLine(pen, left, top + H/2, left + W/2, top + H);
			g.DrawLine(pen, left + W/2, top + H, left + W, top + H/2);
		}

		public static void DrawUpArrows(Graphics g, Rectangle r, Pen pen)
		{
			int left = r.Left;
			int top = r.Top;

			int W = r.Width;
			int H = r.Height;
			g.DrawLine(pen, left, top + H/2, left + W/2, top);
			g.DrawLine(pen, left + W/2, top, left + W, top + H/2);
			g.DrawLine(pen, left, top + H, left + W/2, top + H/2);
			g.DrawLine(pen, left + W/2, top + H/2, left + W, top + H);
		}

		public static void DrawCrossArrow(Graphics g, Rectangle drawRect)
		{
			int x = drawRect.Right - drawRect.Height;
			int y = drawRect.Top + 2;
			int h = drawRect.Height - 4;
			Matrix transformMatrix = new Matrix();
			using (SolidBrush brush = new SolidBrush(Color.White))
			{
				using (GraphicsPath gp = getCrossArrowRegion(x, y, h))
				{
					g.FillPath(brush, gp);

					transformMatrix.RotateAt(90, new Point(x + h/2, y + h/2));
					gp.Transform(transformMatrix);

					g.FillPath(brush, gp);

					transformMatrix.RotateAt(90, new Point(x + h/2, y + h/2));
					gp.Transform(transformMatrix);

					g.FillPath(brush, gp);

					transformMatrix.RotateAt(90, new Point(x + h/2, y + h/2));
					gp.Transform(transformMatrix);

					g.FillPath(brush, gp);
				}
			}
		}
	}
}