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
            TextBox[] arrayTextBox = { textBox1, textBox3, textBox4, textBox5, textBox2, 
                                       textBox1, textBox8, textBox7, textBox6, textBox9, textBox10 };

            Array.ForEach(arrayTextBox, tb => tb.KeyPress += TB_KeyPress);

            PictureBox[] arrayPictureBoxes = { pictureBox2, pictureBox3, pictureBox4, pictureBox5,
                                               pictureBox6, pictureBox7, pictureBox8, pictureBox9,
                                               pictureBox10, pictureBox11 };

            Array.ForEach(arrayPictureBoxes, pb => pb.Click += PB_Click);
        }

        private void PB_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            pictureBox.BackColor = GetColor();
        }

        private void TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 45) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
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
                    graph.a = Convert.ToDouble(textBox3.Text);
                    graph.b = Convert.ToDouble(textBox4.Text);
                    graph.c = Convert.ToDouble(textBox5.Text);

                    color = pictureBox2.BackColor;
                }
                break;
                case 1: 
                {
                    graph.a = Convert.ToDouble(textBox2.Text);
                    graph.b = Convert.ToDouble(textBox1.Text);

                    color = pictureBox3.BackColor;
                }
                break;
                case 2: 
                {
                    graph.a = Convert.ToDouble(textBox8.Text);
                    graph.b = Convert.ToDouble(textBox7.Text);
                    graph.c = Convert.ToDouble(textBox6.Text);
                    graph.d = Convert.ToDouble(textBox9.Text);

                    color = pictureBox4.BackColor;
                }
                break;
                case 3:
                {
                    graph.a = Convert.ToDouble(textBox10.Text);

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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == numericUpDown1.Value)
            {
                numericUpDown2.Value--;
            }

            plane.maxEdge       = (int)numericUpDown1.Value;
            graph.maxSizeEdge   = (int)numericUpDown1.Value;
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

        private Color GetColor() 
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog1.Color;
            }
            return selectedColor;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            TrackBar trackBar = sender as TrackBar;
            double num = (double)trackBar.Value;
            num = (num / 100);
            if (num == 0 || num == 1) return;
            graph.step      = num;
            label12.Text    = num.ToString();
            ReDraw();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == numericUpDown1.Value) 
            {
                numericUpDown1.Value++;
            }
            plane.minEdge       = (int)numericUpDown2.Value;
            graph.minSizeEdge   = (int)numericUpDown2.Value;
            ReDraw();
        }
    }
}
