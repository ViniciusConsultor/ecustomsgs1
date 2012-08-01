using System.Drawing;

namespace ApplicationUtils.Utils
{
    public class ScreenCapture
    {
        /// <summary>
        ///  Create an image of the screen.
        /// </summary>
        /// <param name="SelectionRectangle">Screen relativ coordinates rectangle</param>
        /// <returns></returns>
        public static Image CaptureImage(Rectangle SelectionRectangle)
        {
            Bitmap bitmap = new Bitmap(SelectionRectangle.Width, SelectionRectangle.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(Point.Empty, Point.Empty, SelectionRectangle.Size);
            }
            return bitmap;
        }

        public static int CaptureSequence = 0;

        public static Image CaptureImage(Rectangle SelectionRectangle, Point screenPoint)
        {
            Bitmap bitmap = new Bitmap(SelectionRectangle.Width, SelectionRectangle.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(Point.Empty, Point.Empty, SelectionRectangle.Size);
                using (Pen pen = new Pen(Color.Red, 3))
                {
                    g.DrawEllipse(pen, screenPoint.X, screenPoint.Y, 10, 10);
                }
                g.DrawString(CaptureSequence.ToString(), GDIConstants.UIStandardBoldFont, Brushes.Red, screenPoint.X + 12, screenPoint.Y);
            }
            return bitmap;
        }
    }
}