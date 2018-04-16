using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Asteroid
{
    public partial class Form1 : Form
    {
        public System.Drawing.Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Pen p = new Pen(Color.Black, 20);
            Rectangle main = new Rectangle(10, 10, 769, 501);
            g.DrawRectangle(p, main);
            SolidBrush brush = new SolidBrush(Color.Blue);
            g.FillRectangle(brush, main);
            p = new Pen(Color.White, 1);
            brush = new SolidBrush(Color.White);
            Rectangle[] ell =
            {
                new Rectangle(60,60,40,40),
                new Rectangle(520,300,40,40),
                new Rectangle(705,440,40,40),
                new Rectangle(725,200,40,40),
                new Rectangle(320,20,40,40),
                new Rectangle(460,80,40,40),
                new Rectangle(320,360,40,40),
                new Rectangle(100,400,40,40),
            };
            for (int i = 0; i < ell.Length; ++i)
            {
                g.FillEllipse(brush, ell[i]);
            }
            Point[] arr1 =
            {
                new Point(220,180),
                new Point(160,120),
                new Point(100,180),
            };
            p = new Pen(Color.Red, 10);
            brush = new SolidBrush(Color.Red);
            g.FillPolygon(brush, arr1);
            Point[] arr2 =
            {
                new Point(100,140),
                new Point(220,140),
                new Point(160,200),
            };
            g.FillPolygon(brush, arr2);
            Point[] arr3 =
           {
                new Point(240,320),
                new Point(200,360),
                new Point(280,360),
            };
            g.FillPolygon(brush, arr3);
            Point[] arr4 =
          {
                new Point(200,340),
                new Point(280,340),
                new Point(240,380),
            };
            g.FillPolygon(brush, arr4);
            Point[] arr5 =
           {
                new Point(540,120),
                new Point(520,160),
                new Point(560,160),
            };
            g.FillPolygon(brush, arr5);
            Point[] arr6 =
          {
                new Point(520,140),
                new Point(560,140),
                new Point(540,180),
            };
            g.FillPolygon(brush, arr6);
            Point[] arr7 =
          {
                new Point(500,380),
                new Point(440,440),
                new Point(560,440),
            };
            g.FillPolygon(brush, arr7);
            Point[] arr8 =
          {
                new Point(440,400),
                new Point(560,400),
                new Point(500,460),
            };
            g.FillPolygon(brush, arr8);
            Point[] mn =
            {
                new Point(380,200),
                new Point(420,220),
                new Point(420,280),
                new Point(380,300),
                new Point(340,280),
                new Point(340,220),
            };
            p = new Pen(Color.Yellow, 10);
            brush = new SolidBrush(Color.Yellow);
            g.DrawPolygon(p, mn);
            g.FillPolygon(brush, mn);
            Point[] str =
            {
                new Point(380,220),
                new Point(400,240),
                new Point(390,240),
                new Point(390,260),
                new Point(370,260),
                new Point(370,240),
                new Point(360,240),
            };
            p = new Pen(Color.Green, 10);
            brush = new SolidBrush(Color.Green);
            g.DrawPolygon(p, str);
            g.FillPolygon(brush, str);
            button1.Visible = false;
            Rectangle r = new Rectangle(340, 420, 75, 40);
            p = new Pen(Color.Blue, 10);
            brush = new SolidBrush(Color.Black);
            g.DrawRectangle(p, r);
            g.FillRectangle(brush, r);
        }
    }
}