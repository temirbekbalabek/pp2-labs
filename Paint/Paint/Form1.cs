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



namespace GraphicsExample_Paint

{

    public partial class Form1 : Form

    {

        Bitmap bmp;

        Graphics bmpGraphics;

        bool clicked;

        int tool = 0; // 0 - pen, 1 - rectangle

        Point prev, cur;



        public Form1()

        {

            InitializeComponent();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            pictureBox1.Image = bmp;

            bmpGraphics = Graphics.FromImage(bmp);

            clicked = false;

        }



        private void button1_Click(object sender, EventArgs e)

        {

            Button btn = sender as Button;

            if (btn.Text == "pen")

                tool = 0;

            else

                tool = 1;

        }



        private void pictureBox1_Paint(object sender, PaintEventArgs e)

        {

            if (tool == 1)

            {

                e.Graphics.DrawRectangle(new Pen(Color.Blue), prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.Y);

            }

        }



        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)

        {

            clicked = true;

            prev = e.Location;

        }



        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)

        {

            clicked = false;

            if (tool == 1)

            {

                bmpGraphics.DrawRectangle(new Pen(Color.Red), prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.Y);

                //pictureBox1.Refresh();

            }

        }



        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)

        {

            cur = e.Location;

            if (clicked)

            {

                if (tool == 0)

                {

                    bmpGraphics.DrawLine(new Pen(Color.Black), prev.X, prev.Y, cur.X, cur.Y);

                    prev = cur;

                }

                //pictureBox1.Refresh();

            }

        }



        private void button3_Click(object sender, EventArgs e)

        {

            pictureBox1.Refresh();

        }



    }

}