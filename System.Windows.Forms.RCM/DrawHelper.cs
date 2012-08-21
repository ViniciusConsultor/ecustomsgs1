using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;

namespace Niq.Msd.Common
{
    public class DrawHelper
    {
        public static void DrawDoubleBorder(Graphics graphics, Rectangle rectDrawing, Color borderColor1, Color borderColor2,
            Color colorFillFirst, Color colorFillSecond, int radiusConner, bool useFillColor = false)
        {
            //Trace.TraceInformation("Draw border button");

            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Rectangle notifyRect = rectDrawing;
            notifyRect.X += 1;
            notifyRect.Y += 1;
            notifyRect.Width -= 2;
            notifyRect.Height -= 2;
            Rectangle notifySecRect = new Rectangle(notifyRect.X + 1, notifyRect.Y + 1, notifyRect.Width - 2,
                                                    notifyRect.Height - 2);

            LinearGradientBrush notifySecBrush = new LinearGradientBrush(
                notifySecRect, colorFillFirst, colorFillSecond, LinearGradientMode.Vertical);

            #region Draw 1st border
            GraphicsPath gp = new GraphicsPath();
            int x = notifyRect.X; int y = notifyRect.Y;
            int width = notifyRect.Width;
            int height = notifyRect.Height;
            int radius = radiusConner;

            gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line ----------
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner - TR
            //gp.AddLine(x + width, y + radius *2, x + width, y + height - (radius * 2)); // Line	|
            gp.AddArc(x + width - 2 * radius, y + height - 2 * radius, 2 * radius, 2 * radius, 0, 90); // Corner	- BR
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line	-------------------
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner		-	BL
            gp.AddLine(x, y + height - radius, x, y + radius); // Line	|
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner	-	TL
            gp.CloseFigure();

            if (useFillColor)
                graphics.FillPath(notifySecBrush, gp);

            graphics.DrawPath(new Pen(borderColor1), gp);
            #endregion

            #region Draw 2nd border
            gp = new GraphicsPath();
            x = notifySecRect.X; y = notifySecRect.Y;
            width = notifySecRect.Width;
            height = notifySecRect.Height;

            gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line ----------
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner - TR
            //gp.AddLine(x + width, y + radius *2, x + width, y + height - (radius * 2)); // Line	|
            gp.AddArc(x + width - 2 * radius, y + height - 2 * radius, 2 * radius, 2 * radius, 0, 90); // Corner	- BR
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line	-------------------
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner		-	BL
            gp.AddLine(x, y + height - radius, x, y + radius); // Line	|
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner	-	TL
            gp.CloseFigure();
            
            graphics.DrawPath(new Pen(borderColor2), gp);
            #endregion

            gp.Dispose();
        }

        public static void DrawShapeWithoutBorder(Graphics graphics, Rectangle rectDrawing, 
            Color colorFillFirst, Color colorFillSecond, int radiusConner)
        {
            //Trace.TraceInformation("Draw border button");

            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Rectangle notifyRect = rectDrawing;
            notifyRect.X += 1;
            notifyRect.Y += 1;
            notifyRect.Width -= 2;
            notifyRect.Height -= 2;
            Rectangle notifySecRect = new Rectangle(notifyRect.X + 1, notifyRect.Y + 1, notifyRect.Width - 2,
                                                    notifyRect.Height - 2);

            LinearGradientBrush notifySecBrush = new LinearGradientBrush(
                notifySecRect, colorFillFirst, colorFillSecond, LinearGradientMode.Vertical);

            #region Draw 1st border
            GraphicsPath gp = new GraphicsPath();
            int x = notifyRect.X; int y = notifyRect.Y;
            int width = notifyRect.Width;
            int height = notifyRect.Height;
            int radius = radiusConner;

            gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line ----------
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner - TR
            //gp.AddLine(x + width, y + radius *2, x + width, y + height - (radius * 2)); // Line	|
            gp.AddArc(x + width - 2 * radius, y + height - 2 * radius, 2 * radius, 2 * radius, 0, 90); // Corner	- BR
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line	-------------------
            //gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner		-	BL
            gp.AddLine(x, y + height, x, y); // Line	|
            //gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner	-	TL
            gp.CloseFigure();

            //graphics.FillPath(notifyBrush, gp);
            //graphics.DrawPath(new Pen(borderColor1), gp);
            #endregion

            #region Draw 2nd border
            //gp = new GraphicsPath();
            //x = notifySecRect.X; y = notifySecRect.Y;
            //width = notifySecRect.Width;
            //height = notifySecRect.Height;

            //gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line ----------
            //gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner - TR
            ////gp.AddLine(x + width, y + radius *2, x + width, y + height - (radius * 2)); // Line	|
            //gp.AddArc(x + width - 2 * radius, y + height - 2 * radius, 2 * radius, 2 * radius, 0, 90); // Corner	- BR
            //gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line	-------------------
            //gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner		-	BL
            //gp.AddLine(x, y + height - radius, x, y + radius); // Line	|
            //gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner	-	TL
            //gp.CloseFigure();

            //if (useFillColor)
            //    graphics.FillPath(notifySecBrush, gp);
            //graphics.DrawPath(new Pen(borderColor2), gp);
            #endregion

            graphics.FillPath(notifySecBrush, gp);

            gp.Dispose();
        }


        public static void DrawDoubleBorderWithArrow(Graphics graphics, Rectangle rectDrawing, Color borderColor1, Color borderColor2,
            Color colorFillFirst, Color colorFillSecond, int radiusConner, bool useFillColor = false)
        {
            try
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                Rectangle notifyRect = rectDrawing;
                notifyRect.X += 1;
                notifyRect.Y += 1;
                notifyRect.Width -= 10;
                notifyRect.Height -= 2;
                Rectangle notifySecRect = new Rectangle(notifyRect.X + 1, notifyRect.Y + 1, notifyRect.Width - 2,
                                                        notifyRect.Height - 2);

                LinearGradientBrush notifySecBrush = new LinearGradientBrush(
                    notifySecRect, colorFillFirst, colorFillSecond, LinearGradientMode.Vertical);

                #region Draw 1st border
                GraphicsPath gp = new GraphicsPath();
                int x = notifyRect.X; int y = notifyRect.Y;
                int width = notifyRect.Width;
                int height = notifyRect.Height;
                int radius = radiusConner;

                gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line ----------
                gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner - TR

                gp.AddLine(x + width, y + radius * 2, x + width, y + 20); // Line	|
                gp.AddLine(x + width, y + 20, x + width + 10, y + 30); // Line	\
                gp.AddLine(x + width + 10, y + 30, x + width, y + 40); // Line	/

                gp.AddLine(x + width, y + 40, x + width, y + height - 2 * radius); // Line	|

                gp.AddArc(x + width - 2 * radius, y + height - 2 * radius, 2 * radius, 2 * radius, 0, 90); // Corner	- BR
                gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line	-------------------
                gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner		-	BL
                gp.AddLine(x, y + height - radius, x, y + radius); // Line	|
                gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner	-	TL
                gp.CloseFigure();

                //graphics.FillPath(notifyBrush, gp);
                graphics.DrawPath(new Pen(borderColor1), gp);
                #endregion

                #region Draw 2nd border
                gp = new GraphicsPath();
                x = notifySecRect.X; y = notifySecRect.Y;
                width = notifySecRect.Width;
                height = notifySecRect.Height;

                gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line ----------
                gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner - TR

                gp.AddLine(x + width, y + radius * 2, x + width, y + 19); // Line	|
                gp.AddLine(x + width, y + 19, x + width + 10, y + 29); // Line	\
                gp.AddLine(x + width + 10, y + 29, x + width, y + 39); // Line	/

                gp.AddLine(x + width, y + 39, x + width, y + height - 2 * radius); // Line	|


                gp.AddArc(x + width - 2 * radius, y + height - 2 * radius, 2 * radius, 2 * radius, 0, 90); // Corner	- BR
                gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line	-------------------
                gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner		-	BL
                gp.AddLine(x, y + height - radius, x, y + radius); // Line	|
                gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner	-	TL
                gp.CloseFigure();

                if (useFillColor)
                    graphics.FillPath(notifySecBrush, gp);
                graphics.DrawPath(new Pen(borderColor2), gp);
                #endregion

                gp.Dispose();
            }
            catch (Exception exception)
            {

                throw exception;
            }


        }

        public static void DrawDoubleBorderWithArrow2(Graphics graphics, Rectangle rectDrawing, Color borderColor1, Color borderColor2,
            Color colorFillFirst, Color colorFillSecond, int radiusConner, bool useFillColor = false)
        {
            try
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                Rectangle notifyRect = rectDrawing;
                notifyRect.X += 1;
                notifyRect.Y += 1;
                notifyRect.Width -= 10;
                notifyRect.Height -= 2;
                Rectangle notifySecRect = new Rectangle(notifyRect.X + 1, notifyRect.Y + 1, notifyRect.Width - 2,
                                                        notifyRect.Height - 2);

                LinearGradientBrush notifySecBrush = new LinearGradientBrush(
                    notifySecRect, colorFillFirst, colorFillSecond, LinearGradientMode.Vertical);

                #region Draw 1st border
                GraphicsPath gp = new GraphicsPath();
                int x = notifyRect.X; int y = notifyRect.Y;
                int width = notifyRect.Width;
                int height = notifyRect.Height;
                int radius = radiusConner;

                gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line ----------
                gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner - TR

                gp.AddLine(x + width, y + radius * 2, x + width, y + 23); // Line	|
                gp.AddLine(x + width, y + 23, x + width + 6, y + 32); // Line	\
                gp.AddLine(x + width + 6, y + 32, x + width, y + 38); // Line	/

                gp.AddLine(x + width, y + 38, x + width, y + height - 2 * radius); // Line	|

                gp.AddArc(x + width - 2 * radius, y + height - 2 * radius, 2 * radius, 2 * radius, 0, 90); // Corner	- BR
                gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line	-------------------
                gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner		-	BL
                gp.AddLine(x, y + height - radius, x, y + radius); // Line	|
                gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner	-	TL
                gp.CloseFigure();

                //graphics.FillPath(notifyBrush, gp);
                graphics.DrawPath(new Pen(borderColor1), gp);
                #endregion

                #region Draw 2nd border
                gp = new GraphicsPath();
                x = notifySecRect.X; y = notifySecRect.Y;
                width = notifySecRect.Width;
                height = notifySecRect.Height;

                gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line ----------
                gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner - TR

                gp.AddLine(x + width, y + radius * 2, x + width, y + 22); // Line	|
                gp.AddLine(x + width, y + 22, x + width + 6, y + 31); // Line	\
                gp.AddLine(x + width + 6, y + 31, x + width, y + 37); // Line	/

                gp.AddLine(x + width, y + 37, x + width, y + height - 2 * radius); // Line	|


                gp.AddArc(x + width - 2 * radius, y + height - 2 * radius, 2 * radius, 2 * radius, 0, 90); // Corner	- BR
                gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line	-------------------
                gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner		-	BL
                gp.AddLine(x, y + height - radius, x, y + radius); // Line	|
                gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner	-	TL
                gp.CloseFigure();

                if (useFillColor)
                    graphics.FillPath(notifySecBrush, gp);
                graphics.DrawPath(new Pen(borderColor2), gp);
                #endregion

                gp.Dispose();
            }
            catch (Exception exception)
            {

                throw exception;
            }


        }

        public static void DrawString(Graphics graphics, Point startPoint, Font font, Color color, string drawString)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            SizeF size = graphics.MeasureString(drawString, font);

            RectangleF rectangle = new RectangleF(startPoint, size);

            graphics.DrawString(drawString, font, new SolidBrush(color), rectangle);
        }

        public static void DrawStringLabel(Graphics graphics, Rectangle rectangle, Font font, Color color, string drawString, StringAlignment alignment)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            StringFormat sf = new StringFormat();
            sf.Alignment = alignment;
            sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
            sf.HotkeyPrefix = HotkeyPrefix.Show;
            sf.Trimming = StringTrimming.Character;
            sf.LineAlignment = StringAlignment.Center;

            graphics.DrawString(drawString, font, new SolidBrush(color), rectangle, sf);
        }

        public static void DrawStringLabel(Graphics graphics, Rectangle rectangle, Font font, Color color, string drawString, StringFormat sf)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.DrawString(drawString, font, new SolidBrush(color), rectangle, sf);
        }

        public static PointF GetPointDrawOfString(Graphics graphics, Rectangle rectangle, Font font, string drawString)
        {

            SizeF size = graphics.MeasureString(drawString, font);

            float X = (float)Math.Ceiling(rectangle.X + (rectangle.Width - size.Width) / 2);
            float Y = (float)Math.Ceiling(rectangle.Y + (rectangle.Height - size.Height) / 2);

            return new PointF(X, Y);
        }

        public static void DrawCircle(Graphics graphics, Rectangle circleRectagle, Color borderColor, Color fillColor)
        {

        }

        public static void DrawImage(Graphics graphics, Image image, Rectangle rectangle)
        {
            graphics.DrawImage(image, rectangle);
        }

        public static void DrawImage(Graphics graphics, Image image, Point startPoint)
        {
            Rectangle rect = new Rectangle(startPoint.X, startPoint.Y, image.Width, image.Height);
            graphics.DrawImage(image, rect);
        }

        public static void DrawLine(Graphics graphics, Point point, Point point1, Color borderFirst, Color borderSecond)
        {
            int w = 1;
            Point p1 = new Point(point.X, point.Y + w);
            Point p2 = new Point(point1.X, point1.Y + w);
            graphics.DrawLine(new Pen(borderSecond, (float)w), p1, p1);
            graphics.DrawLine(new Pen(borderFirst, (float)w), point, point1);
        }

        public static void DrawButtonWithoutBorder(Graphics graphics, Rectangle bounds, string text, Font font, Color fillColor, Color textColor)
        {
            graphics.FillRectangle(new SolidBrush(fillColor), bounds);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
            sf.LineAlignment = StringAlignment.Center;
            graphics.DrawString(text, font, new SolidBrush(textColor), bounds, sf);
        }

        public static void FillRectange(Graphics graphics, Rectangle bounds, Color fillColor)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.FillRectangle(new SolidBrush(fillColor), bounds);
        }

        public static Size MeasureString(Graphics graphics, Font font, string str)
        {
            SizeF sizeF = graphics.MeasureString(str, font);

            Size size = new Size((int)Math.Ceiling(sizeF.Width), (int)Math.Ceiling(sizeF.Height));

            return size;
        }
        
    }
}
