using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AppGraphs
{
    public class Plane : Control
    {
        float X, Y;

        public double maxEdge = 10;
        public double minEdge = -10;
        public Graphics graphics { get; set; }
        public void DrawPlane()
        {
            Rectangle rectangle = ChartArea;
            graphics.Clear(Color.White);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.PixelOffsetMode = PixelOffsetMode.Half;
            Pen pen_line = new Pen(Color.LightGray, 1);
            //Вертикальные линии
            for (int i = (int)minEdge; i <= (int)maxEdge; ++i)
            {
                X = rectangle.Left + XToPixels(i);
                graphics.DrawLine(pen_line, X, rectangle.Bottom, X, rectangle.Top);
            }

            //Горизонтальные линии
            for (int i = (int)minEdge; i <= (int)maxEdge; ++i)
            {
                Y = rectangle.Bottom - YToPixels(i);
                graphics.DrawLine(pen_line, rectangle.Left, Y, rectangle.Right, Y);
            }
            graphics.DrawLine(pen_line, rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Bottom);

            Pen pen_axis = new Pen(Color.Black, 1);
            
            //Вертикальная линия оси Y
            graphics.DrawLine(pen_axis, this.Size.Width / 2, 0, rectangle.Size.Width / 2, rectangle.Right);

            //Горизонтальная линия оси X
            graphics.DrawLine(pen_axis, 0, rectangle.Size.Height / 2, rectangle.Size.Width, rectangle.Size.Height / 2);

            //Стрелка оси Y
            graphics.DrawLine(pen_axis, rectangle.Size.Width / 2, 0, rectangle.Size.Width / 2 - 5, 10);
            graphics.DrawLine(pen_axis, rectangle.Size.Width / 2, 0, rectangle.Size.Width / 2 + 5, 10);

            //Стрелка оси X
            graphics.DrawLine(pen_axis, rectangle.Size.Width, rectangle.Size.Height / 2, rectangle.Size.Width - 10, rectangle.Size.Height / 2 - 5);
            graphics.DrawLine(pen_axis, rectangle.Size.Width, rectangle.Size.Height / 2, rectangle.Size.Width - 10, rectangle.Size.Height / 2 + 5);

            Font font = new System.Drawing.Font("Arial", 10);
            
            //Центральная точка
            graphics.DrawString(((maxEdge + minEdge) / 2).ToString(), font, Brushes.Black, rectangle.Size.Width / 2 - 15, rectangle.Size.Height / 2 + 3);
            
            //X
            graphics.DrawString(minEdge.ToString(), font, Brushes.Black, 0, rectangle.Size.Height / 2 + 3);
            graphics.DrawString(maxEdge.ToString(), font, Brushes.Black, rectangle.Size.Width - 20, rectangle.Size.Height / 2 + 5);
            
            //Y
            graphics.DrawString(minEdge.ToString(), font, Brushes.Black, rectangle.Size.Width / 2 - 22, rectangle.Size.Height - 20);
            graphics.DrawString(maxEdge.ToString(), font, Brushes.Black, rectangle.Size.Width / 2 - 22, 3);
            
            //Имена осей 
            graphics.DrawString("Y", font, Brushes.Black, rectangle.Size.Width / 2 + 5, 3);
            graphics.DrawString("X", font, Brushes.Black, rectangle.Size.Width - 15, rectangle.Size.Height / 2 - 20);

            pen_line.Dispose();
            pen_axis.Dispose();
        }

        public float YToPixels(double y)
        {
            return (float)(ChartArea.Height * (y - minEdge) / (maxEdge - minEdge));
        }

        public float XToPixels(double x)
        {
            return (float)(ChartArea.Width * (x - minEdge) / (maxEdge - minEdge));
        }

        public Rectangle ChartArea
        {
            get
            {
                var rect = ClientRectangle;
                rect.Inflate(-1, -1);
                return rect;
            }
        }
    }
}
