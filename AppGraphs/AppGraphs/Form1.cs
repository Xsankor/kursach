using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace AppGraphs
{
    public partial class Form1 : Form
    {
        Plane plane;
        Graph graph;

        Color selectedColor;
        List<int> Checked = new List<int>();

        public Form1()  
        {
            panel2 = new Panel();

            InitializeComponent();
            checkedListBox1.SetItemChecked(0, true);
            Checked.Add(0);

            plane = new Plane() { Parent = panel2, Dock = DockStyle.Fill };
            graph = new Graph() { Parent = plane,  Dock = DockStyle.Fill };
            plane.graphics = graph.CreateGraphics();

            plane.DrawPlane();
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
            plane.DrawPlane();
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
            plane.maxEdge = (int)numericUpDown1.Value;
            graph.maxSizeEdge = (int)numericUpDown1.Value;
            graph.minSizeEdge = -(int)numericUpDown1.Value;
            ReDraw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
            Checked.Clear();
            plane.graphics.Clear(Color.White);
            plane.DrawPlane();
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
