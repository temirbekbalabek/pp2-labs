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

namespace Clock
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen;
        double radius, angle1, angle2,angle3=-90, cnt = 0, cnt2=0;
        Point center, highest;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            pen = new Pen(Color.Red);
            radius = 35;
            angle1 = -90;
            angle2 = -90;
            center.X = 115;
            center.Y = 105;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            g.DrawEllipse(pen, 80, 70, 70, 70);
            string a = (center.X + radius * Math.Cos((angle1 * Math.PI) / 180)).ToString();
            float x1 = float.Parse(a);
            string b = (center.Y + radius * Math.Sin((angle1 * Math.PI) / 180)).ToString();
            float y1 = float.Parse(b);
            string c = (center.X + (radius - 5) * Math.Cos((angle2 * Math.PI) / 180)).ToString();
            float x2 = float.Parse(c);
            string d = (center.Y + (radius - 5) * Math.Sin((angle2 * Math.PI) / 180)).ToString();
            float y2 = float.Parse(d);
            string f = (center.X + (radius-10) * Math.Cos((angle3 * Math.PI) / 180)).ToString();
            float x3 = float.Parse(f);
            string h = (center.Y + (radius - 10) * Math.Sin((angle3 * Math.PI) / 180)).ToString();
            float y3 = float.Parse(h);
            g.DrawLine(pen, center.X, center.Y, x1, y1);
            g.DrawLine(new Pen(Color.Black), center.X, center.Y, x2, y2);
            g.DrawLine(new Pen(Color.Blue), center.X, center.Y, x3, y3);
            angle1 += 6;
            angle2 += 0.1;
            double an = 30 / 3600;
            angle3 += an;
        }
    }
}
