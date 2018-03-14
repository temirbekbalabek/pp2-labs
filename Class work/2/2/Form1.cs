using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    public partial class Form1 : Form
    {
        int c=100, b=100;
        public Form1()
        {
            InitializeComponent();
        }

        public int height { get; private set; }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int a = trackBar1.Value;
            button1.Location = new Point(a, 100);
            if(c>50 && b > 50)
            button1.Size = new Size(c--,b--);
        }
    }
}
