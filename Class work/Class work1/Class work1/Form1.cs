using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class_work1
{
    public partial class Form1 : Form
    {
        double fn = 0,sn=0,result=0;
        string operators;
        public Form1()
        {
            InitializeComponent();
        }

        private void operators_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            fn = double.Parse(textBox1.Text);
            sn = double.Parse(textBox2.Text);
            operators = btn.Text;
            if (operators == "*")
            {
                result = fn * sn;
            }
            if (operators == "+")
            {
                result = fn + sn;
            }
            if (operators == "-")
            {
                result = fn - sn;
            }
            label1.Text = result.ToString();
        }
    }
}
