using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace Paint
{
    public partial class Form1 : Form
    {
        Queue<Point> q;
        bool clicked, iseraserclicked;
        int k = 0, thickness;
        Color l, r, fillcolor, initcolor;
        Graphics g;
        Bitmap bmp;
        Pen pen;
        Point prev, cur;
        string s ="Ellipse";
        public Form1()
        {
            InitializeComponent();
            iseraserclicked = false;
            l = Color.Black;
            r = Color.Black;
            q = new Queue<Point>();
            pen = new Pen(Color.Black);
            bmp = new Bitmap(pictureBox5.Width, pictureBox5.Height);
            pictureBox5.Image = bmp;
            g = Graphics.FromImage(bmp);
            clicked = false;
        }
        private void Check(int xp, int yp)
        {
            if(xp<0 || yp<0 || xp>=pictureBox5.Width || yp >= pictureBox5.Height)
            {
                return;
            }
            if (bmp.GetPixel(xp,yp)==initcolor)
            {
                bmp.SetPixel(xp, yp, fillcolor);
                q.Enqueue(new Point(xp, yp));
            }
        }
        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            prev = e.Location;
            if (iseraserclicked)
            {
                return;
            }
            if (MouseButtons == MouseButtons.Left)
            {
                pen.Color=l;
            }
            if (MouseButtons == MouseButtons.Right)
            {
                pen.Color=r;
            }
            if (k == 4)
            {
                fillcolor = colorDialog1.Color;
                initcolor = bmp.GetPixel(prev.X, prev.Y);
                q.Enqueue(new Point(e.X, e.Y));
                bmp.SetPixel(e.X, e.Y, fillcolor);
                while (q.Count > 0)
                {
                    Point curr = q.Dequeue();
                    Check(curr.X + 1, curr.Y);
                    Check(curr.X - 1, curr.Y);
                    Check(curr.X, curr.Y + 1);
                    Check(curr.X, curr.Y - 1);
                }

                pictureBox5.Refresh();
            }
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            cur = e.Location;
            if (clicked)
            {
                if (k == 2)
                {
                    g.DrawLine(pen, prev.X, prev.Y, cur.X, cur.Y);
                    prev = cur;
                }
                pictureBox5.Refresh();
            }
        }
        
        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            int x = Math.Min(prev.X, cur.X);
            int y = Math.Min(prev.Y, cur.Y);
            int w = Math.Abs(cur.X - prev.X);
            int h = Math.Abs(cur.Y - prev.Y);
            if (k == 0)
                g.DrawEllipse(pen, x, y, w, h);
            if (k == 1)
                g.DrawRectangle(pen, x, y, w, h);
            if (k == 3)
            {
                g.DrawLine(pen, x, Math.Max(prev.Y, cur.Y), Math.Max(prev.X, cur.X), Math.Max(prev.Y, cur.Y));
                g.DrawLine(pen, (prev.X + cur.X) / 2, y, Math.Max(prev.X, cur.X), Math.Max(prev.Y, cur.Y));
                g.DrawLine(pen, x, Math.Max(prev.Y, cur.Y), (prev.X + cur.X) / 2, Math.Min(prev.Y, cur.Y));
            }
            clicked = false;
            pictureBox5.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pictureBox5.BackColor = colorDialog1.Color;
            BackColor = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            r = colorDialog1.Color;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            l = colorDialog1.Color;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            iseraserclicked = false;
            k = 0;
            if (pen.Color == pictureBox5.BackColor)
            {
                pen.Color = Color.Black;
                pen.Width = thickness;
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            iseraserclicked = false;
            k = 1;
            if (pen.Color == pictureBox5.BackColor)
            {
                pen.Color = Color.Black;
                pen.Width = thickness;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            iseraserclicked = false;
            k = 2;
            if (pen.Color == pictureBox5.BackColor)
            {
                pen.Color = Color.Black;
                pen.Width = thickness;
            }
        }
        

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            pen.Width = 2;
            thickness = 2;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            k = 3;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Refresh();
                iseraserclicked = false;
                l = Color.Black;
                r = Color.Black;
                pen = new Pen(Color.Black);
                bmp = new Bitmap(openFileDialog1.FileName);
                pictureBox5.Image = bmp;
                g = Graphics.FromImage(bmp);
                clicked = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox5.Image.Save(saveFileDialog1.FileName);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            k = 4;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            pen.Width = 4;
            thickness = 4;
        }

        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen.Width = 6;
            thickness = 6;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            iseraserclicked = true;
            pen.Color = pictureBox5.BackColor;
            k = 2;
            pen.Width = 15;
        }

        private void pictureBox5_Paint(object sender, PaintEventArgs e)
        {
            if (clicked)
            {
                int x = Math.Min(prev.X, cur.X);
                int y = Math.Min(prev.Y, cur.Y);
                int w = Math.Abs(cur.X - prev.X);
                int h = Math.Abs(cur.Y - prev.Y);
                if (k == 0)
                    e.Graphics.DrawEllipse(pen, prev.X, prev.Y, cur.X-prev.X, cur.Y-prev.Y);
                if (k == 1)
                    e.Graphics.DrawRectangle(pen, x, y, w, h);
                if (k == 3)
                {
                    e.Graphics.DrawLine(pen, x, Math.Max(prev.Y, cur.Y), Math.Max(prev.X, cur.X), Math.Max(prev.Y, cur.Y));
                    e.Graphics.DrawLine(pen, (prev.X + cur.X) / 2, y,Math.Max(prev.X,cur.X),Math.Max(prev.Y,cur.Y));
                    e.Graphics.DrawLine(pen, x, Math.Max(prev.Y, cur.Y), (prev.X + cur.X) / 2, Math.Min(prev.Y, cur.Y));
                }
            }
        }


    }
}
