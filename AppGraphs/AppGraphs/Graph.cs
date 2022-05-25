using System;
using System.Windows.Forms;
using System.Drawing;

namespace AppGraphs
{
    public class Graph : Control
    {
        public double maxSizeEdge = 10, minSizeEdge = -10, step = 0.01;
        public double a = 2, b = 0, c = 2, d = 1;
        
        Point point;
        Nullable<Point> nullable;
        Point point_new = new Point();

        private Point GetPoints(double corX, double corY) 
        {
            point_new.X = (int)(corX * this.Size.Width / (2 * maxSizeEdge)) + this.Size.Width / 2;
            point_new.Y = (int)(corY * this.Size.Height / (2 * maxSizeEdge)) + this.Size.Height / 2;
            return point_new;
        }

        private void SetPoint(double pointX, double pointY, Graphics graphics, Pen pen) 
        {
            point = GetPoints(pointX, pointY);
            if (nullable != null) 
            {
                graphics.DrawLine(pen, nullable.Value, point);
            }
            nullable = point;
        }


        // Есть инверсия графика. Нужно исправить !!!!
        public void BuildGraph(int option, Color color)
        {
            double y;
            Pen pen = new Pen(color, 2);
            Graphics graphics = this.CreateGraphics();
            for (double x = maxSizeEdge; x >= minSizeEdge; x -= step)
            //for (double x = minSizeEdge; x <= maxSizeEdge; x += step)
            {
                x = Math.Round(x, 2);
                if (x == 0) continue;
                y = Math.Round(СalcFunction(x, option), 2);
                SetPoint(x, y, graphics, pen);
            }
            SetNullable();
            pen.Dispose();
        }

        private double СalcFunction(double x, int option = 0)
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

        private void SetNullable()
        {
            nullable = null;
        }
    }
}
