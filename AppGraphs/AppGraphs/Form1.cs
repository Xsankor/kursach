using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace AppGraphs
{
    public partial class Form1 : Form
    {
        Graph graph;
        Graphics graphics;
        Color selectedColor;
        List<int> Checked = new List<int>();

        double sizeEdges = 10;

        public Form1()  
        {
            panel2 = new Panel();

            InitializeComponent();
            checkedListBox1.SetItemChecked(0, true);
            Checked.Add(0);

            graph = new Graph() { Parent = panel2, Dock = DockStyle.Fill };
            graphics = graph.CreateGraphics();
            DrawD();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Checked.Clear();
            foreach (int item in checkedListBox1.CheckedIndices)
            {
                Checked.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReDraw();
        }

        private void ReDraw() 
        {
            DrawD();
            for (int i = 0; i < Checked.Count; ++i)
            {
                GetAllData(Checked[i]);
            }
        }

        private void GetAllData(int index) 
        {
            Color color = Color.Black;
            switch (index) 
            {
                case 0:
                {
                    graph.a = Convert.ToInt32(textBox3.Text);
                    graph.b = Convert.ToInt32(textBox4.Text);
                    graph.c = Convert.ToInt32(textBox5.Text);
                    color = pictureBox2.BackColor;
                }
                break;
                case 1: 
                {
                    graph.a = Convert.ToInt32(textBox2.Text);
                    graph.b = Convert.ToInt32(textBox1.Text);
                    color = pictureBox3.BackColor;
                }
                break;
                case 2: 
                {
                     graph.a = Convert.ToInt32(textBox8.Text);
                     graph.b = Convert.ToInt32(textBox7.Text);
                     graph.c = Convert.ToInt32(textBox6.Text);
                     graph.d = Convert.ToInt32(textBox9.Text);
                     color = pictureBox4.BackColor;
                }
                break;
                case 3:
                {
                    graph.a = Convert.ToInt32(textBox10.Text);
                    color = pictureBox5.BackColor;
                }
                break;
                case 4:
                {
                    color = pictureBox6.BackColor;
                }
                break;
                case 5:
                {
                    color = pictureBox7.BackColor;
                }
                break;
                case 6:
                {
                    color = pictureBox8.BackColor;
                }
                break;
                case 7:
                {
                    color = pictureBox9.BackColor;
                }
                break;
                case 8:
                {
                    color = pictureBox10.BackColor;
                }
                break;
                case 9:
                {
                    color = pictureBox11.BackColor;
                }
                break;
            }
            graph.BuildGraph(index, color);
        }


        // Также добавить ONCHANGE
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            graph.maxEdge = (int)numericUpDown1.Value;
            ReDraw();
        }

        private void DrawD() 
        {
            Rectangle rectangle = graph.ChartArea;
            double maxEdge = graph.maxEdge;

            graphics.Clear(Color.White);
            Pen pen_line = new Pen(Color.LightGray, 1);
            //Вертикальные линии
            for (int i = (int)(-maxEdge); i <= (int)maxEdge; ++i) 
            //for (int i = -panel1.Height / (5 * (int)maxEdge); i < panel1.Height / (5 * (int)maxEdge); ++i)
            {
                float X = graph.Left + graph.XToPixels(i);
                graphics.DrawLine(pen_line, X, rectangle.Bottom, X, rectangle.Top);
                //graphics.DrawLine(pen_line, panel1.Width / 2 + i * 5 * (int)maxEdge, panel1.Height / 2 - 2, panel1.Width / 2 + i * 5 * (int)maxEdge, panel1.Height / 2 + 2);
            }

            //Горизонтальные линии
            for (int i = (int)(-maxEdge); i <= (int)maxEdge; ++i) 
            //for (int i = -panel1.Width / (5 * (int)maxEdge); i < panel1.Width / (5 * (int)maxEdge); ++i)
            {
                float Y = graph.Bottom - graph.YToPixels(i);
                graphics.DrawLine(pen_line, rectangle.Left, Y, rectangle.Right, Y);
                //graphics.DrawLine(pen_line, panel1.Width / 2 - 2, panel1.Height / 2 - i * 5 * (int)maxEdge, panel1.Width / 2 + 2, panel1.Height / 2 - i * 5 * (int)maxEdge);
            }
            graphics.DrawLine(pen_line, rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Bottom);

            Pen pen_axis = new Pen(Color.Black, 1);
            //Вертикальная линия оси Х
            graphics.DrawLine(pen_axis, panel2.Size.Width / 2, 0, panel2.Size.Width / 2, panel2.Size.Height);

            //Горизонтальная линия оси Y
            graphics.DrawLine(pen_axis, 0, panel2.Size.Height / 2, panel2.Size.Width, panel2.Size.Height / 2);

            //Стрелка оси Y
            graphics.DrawLine(pen_axis, panel2.Size.Width / 2, 0, panel2.Size.Width / 2 - 5, 10);
            graphics.DrawLine(pen_axis, panel2.Size.Width / 2, 0, panel2.Size.Width / 2 + 5, 10);

            //Стрелка оси X
            graphics.DrawLine(pen_axis, panel2.Size.Width, panel2.Size.Height / 2, panel2.Size.Width - 10, panel2.Size.Height / 2 - 5);
            graphics.DrawLine(pen_axis, panel2.Size.Width, panel2.Size.Height / 2, panel2.Size.Width - 10, panel2.Size.Height / 2 + 5);

            //Границы осей
            Font font = new System.Drawing.Font("Arial", 10);
            //Центральная точка
            graphics.DrawString(((maxEdge + (-maxEdge)) / 2).ToString(), font, Brushes.Black, panel2.Size.Width / 2 - 15, panel2.Size.Height / 2 + 3);
            //X
            graphics.DrawString((-maxEdge).ToString(), font, Brushes.Black, 0, panel2.Size.Height / 2 + 3);
            graphics.DrawString(maxEdge.ToString(), font, Brushes.Black, panel2.Size.Width - 20, panel2.Size.Height / 2 + 5);
            //Y
            graphics.DrawString((-maxEdge).ToString(), font, Brushes.Black, panel2.Size.Width / 2 - 22, panel2.Size.Height - 20);
            graphics.DrawString(maxEdge.ToString(), font, Brushes.Black, panel2.Size.Width / 2 - 22, 3);
            //Имена осей 
            graphics.DrawString("Y", font, Brushes.Black, panel2.Size.Width / 2 + 5, 3);
            graphics.DrawString("X", font, Brushes.Black, panel2.Size.Width - 15, panel2.Size.Height / 2 - 20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
            Checked.Clear();
            graphics.Clear(Color.White);
            DrawD();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.BackColor = GetColor();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.BackColor = GetColor();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.BackColor = GetColor();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.BackColor = GetColor();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox6.BackColor = GetColor();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox7.BackColor = GetColor();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox8.BackColor = GetColor();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox9.BackColor = GetColor();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox10.BackColor = GetColor();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pictureBox11.BackColor = GetColor();
        }

        private Color GetColor() 
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog1.Color;
            }
            return selectedColor;
        }
    }
}
