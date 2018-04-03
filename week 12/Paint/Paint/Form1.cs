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
        bool clicked;
        int k = 0;
        Graphics g;
        Bitmap bmp;
        Pen pen;
        Point prev, cur;
        string s ="Ellipse";
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black);
            bmp = new Bitmap(pictureBox5.Width, pictureBox5.Height);
            pictureBox5.Image = bmp;
            g = Graphics.FromImage(bmp);
            clicked = false;
        }
       
        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            prev = e.Location;
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
            clicked = false;
            pictureBox5.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            BackColor = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pen = new Pen(colorDialog1.Color);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pen = new Pen(Color.Black);
            k = 0;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            k = 1;
            pen = new Pen(Color.Black);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            k = 2;
            pen = new Pen(Color.Black);
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
            }
        }


    }
}
