using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4
{
    public partial class Form1 : Form
    {
        int x, y, dx = 15, dy = 15;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (y == Height-40)
                dy = -1;
            if (x == Width-40)
                dx = -1;
            if (x == 0)
                dx = 1;
            if (y == 0)
                dy = 1;
            x += dx;
            y += dy;
                label1.Location = new Point(x, y);
        }
    }
}
