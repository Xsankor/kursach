using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace AppGraphs
{
    public class Graph : Control
    {
        public double maxEdge = 10;

        Point point;
        public double a = 2, b = 0, c = 2, d = 1;
        Nullable<Point> nullable;

        Point point_new = new Point();

        public Point GetPoints(double corX, double corY) 
        {
            point_new.X = (int)(corX * this.Size.Width / (2 * maxEdge)) + this.Size.Width / 2;
            point_new.Y = (int)(corY * this.Size.Height / (2 * maxEdge)) + this.Size.Height / 2;
            return point_new;
        }

        public float YToPixels(double y)
        {
            return (float)(ChartArea.Height * (y - (-maxEdge)) / (maxEdge - (-maxEdge)));
        }

        public float XToPixels(double x)
        {
            return (float)(ChartArea.Width * (x - (-maxEdge)) / (maxEdge - (-maxEdge)));
        }

        public void SetPoint(double pointX, double pointY, Graphics graphics, Pen pen) 
        {
            point = GetPoints(pointX, pointY);
            if (nullable != null) 
            {
                graphics.DrawLine(pen, nullable.Value, point);
            }
            nullable = point;
        }

        public void BuildGraph(int option, Color color)
        {
            double y;
            Pen pen = new Pen(color, 2);
            Graphics graphics = this.CreateGraphics();
            for (double x = (-maxEdge); x <= maxEdge; x += 0.01)
            {
                x = Math.Round(x, 2);
                if (x == 0) continue;
                y = Math.Round(СalcFunction(x, option), 2);
                SetPoint(x, y, graphics, pen);
            }
            SetNullable();
        }

        public double СalcFunction(double x, int option = 0)
        {
            switch (option) 
            {
                case 0: return a * (x * x) + b * x + c; 
                case 1: return a * x + b;
                case 2: return a * (x * x * x) + b * (x * x) + c * x + d;
                case 3: return a / (x * x * x);
                case 4: return x * x * x;
                case 5: return Math.Pow(Math.Exp(1), x);
                case 6: return Math.Log(Math.Abs(x));
                case 7: return Math.Sin(x);
                case 8: return Math.Tan(x);
                case 9: return Math.Atan(x);
                default: return 1;
            }
        }

        public void SetNullable()
        {
            nullable = null;
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
