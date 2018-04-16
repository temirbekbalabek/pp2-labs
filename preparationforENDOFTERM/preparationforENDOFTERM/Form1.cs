using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace preparationforENDOFTERM
{
    public partial class Form1 : Form
    {
        int k;
        Graphics g;
        Bitmap bmp;
        Point prev, cur;
        Pen pen;
        bool clicked;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);
            clicked = false;
            pen = new Pen(Color.Black);
            k = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            k = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            k = 2;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            k = 3;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            prev = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
            if (k == 2)
            {
                int x = Math.Min(prev.X, e.X);
                int y = Math.Min(prev.Y, e.Y);
                int w = Math.Abs(prev.X - e.X);
                int h = Math.Abs(prev.Y - e.Y);
                g.DrawRectangle(pen, x, y, w, h);
            }
            if (k == 3)
            {
                g.DrawEllipse(pen, prev.X, prev.Y, e.X - prev.X, e.Y - prev.Y);
            }
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (clicked)
            {
                if (k == 2)
                {
                    int x = Math.Min(prev.X, cur.X);
                    int y = Math.Min(prev.Y, cur.Y);
                    int w = Math.Abs(prev.X - cur.X);
                    int h = Math.Abs(prev.Y - cur.Y);
                    e.Graphics.DrawRectangle(pen, x, y, w, h);
                }
                if (k == 3)
                {
                    e.Graphics.DrawEllipse(pen, prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.Y);
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            cur = e.Location;
            if (clicked)
            {
                if (k == 1)
                {
                    g.DrawLine(pen, prev.X, prev.Y, cur.X, cur.Y);
                    prev = cur;
                }
                pictureBox1.Refresh();
            }
        }
    }
}
