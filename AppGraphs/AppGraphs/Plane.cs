using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AppGraphs
{
    public class Plane : Control
    {
        public double maxEdge = 10;
        public Graphics graphics { get; set; }
        public void DrawPlane()
        {
            Rectangle rectangle = ChartArea;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);
            Pen pen_line = new Pen(Color.LightGray, 1);
            //Вертикальные линии
            for (int i = (int)(-maxEdge); i <= (int)maxEdge; ++i)
            //for (int i = -panel1.Height / (5 * (int)maxEdge); i < panel1.Height / (5 * (int)maxEdge); ++i)
            {
                float X = rectangle.Left + XToPixelsPlane(i);
                graphics.DrawLine(pen_line, X, rectangle.Bottom, X, rectangle.Top);
                //graphics.DrawLine(pen_line, panel1.Width / 2 + i * 5 * (int)maxEdge, panel1.Height / 2 - 2, panel1.Width / 2 + i * 5 * (int)maxEdge, panel1.Height / 2 + 2);
            }

            //Горизонтальные линии
            for (int i = (int)(-maxEdge); i <= (int)maxEdge; ++i)
            //for (int i = -panel1.Width / (5 * (int)maxEdge); i < panel1.Width / (5 * (int)maxEdge); ++i)
            {
                float Y = rectangle.Bottom - YToPixelsPlane(i);
                graphics.DrawLine(pen_line, rectangle.Left, Y, rectangle.Right, Y);
                //graphics.DrawLine(pen_line, panel1.Width / 2 - 2, panel1.Height / 2 - i * 5 * (int)maxEdge, panel1.Width / 2 + 2, panel1.Height / 2 - i * 5 * (int)maxEdge);
            }
            graphics.DrawLine(pen_line, rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Bottom);

            Pen pen_axis = new Pen(Color.Black, 1);
            //Вертикальная линия оси Х
            graphics.DrawLine(pen_axis, this.Size.Width / 2, 0, rectangle.Size.Width / 2, rectangle.Size.Height);

            //Горизонтальная линия оси Y
            graphics.DrawLine(pen_axis, 0, rectangle.Size.Height / 2, rectangle.Size.Width, rectangle.Size.Height / 2);

            //Стрелка оси Y
            graphics.DrawLine(pen_axis, rectangle.Size.Width / 2, 0, rectangle.Size.Width / 2 - 5, 10);
            graphics.DrawLine(pen_axis, rectangle.Size.Width / 2, 0, rectangle.Size.Width / 2 + 5, 10);

            //Стрелка оси X
            graphics.DrawLine(pen_axis, rectangle.Size.Width, rectangle.Size.Height / 2, rectangle.Size.Width - 10, rectangle.Size.Height / 2 - 5);
            graphics.DrawLine(pen_axis, rectangle.Size.Width, rectangle.Size.Height / 2, rectangle.Size.Width - 10, rectangle.Size.Height / 2 + 5);

            //Границы осей
            Font font = new System.Drawing.Font("Arial", 10);
            //Центральная точка
            graphics.DrawString(((maxEdge + (-maxEdge)) / 2).ToString(), font, Brushes.Black, rectangle.Size.Width / 2 - 15, rectangle.Size.Height / 2 + 3);
            //X
            graphics.DrawString((-maxEdge).ToString(), font, Brushes.Black, 0, rectangle.Size.Height / 2 + 3);
            graphics.DrawString(maxEdge.ToString(), font, Brushes.Black, rectangle.Size.Width - 20, rectangle.Size.Height / 2 + 5);
            //Y
            graphics.DrawString((-maxEdge).ToString(), font, Brushes.Black, rectangle.Size.Width / 2 - 22, rectangle.Size.Height - 20);
            graphics.DrawString(maxEdge.ToString(), font, Brushes.Black, rectangle.Size.Width / 2 - 22, 3);
            //Имена осей 
            graphics.DrawString("Y", font, Brushes.Black, rectangle.Size.Width / 2 + 5, 3);
            graphics.DrawString("X", font, Brushes.Black, rectangle.Size.Width - 15, rectangle.Size.Height / 2 - 20);

            pen_line.Dispose();
            pen_axis.Dispose();
        }

        public float YToPixelsPlane(double y)
        {
            return (float)(ChartArea.Height * (y - (-maxEdge)) / (maxEdge - (-maxEdge)));
        }

        public float XToPixelsPlane(double x)
        {
            return (float)(ChartArea.Width * (x - (-maxEdge)) / (maxEdge - (-maxEdge)));
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
