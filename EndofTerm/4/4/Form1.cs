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
        int b = 2;
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            int a = trackBar1.Value;
            label1.Location = new Point(a, 100);
            label1.Font = new Font("Hello World",b);
            b++;
        }
    }
}
