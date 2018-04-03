using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CALCULATOR : Form
    {
        public double tcnt = 0, operation1cnt = 0, operationcnt = 0;
        Calc calc = new Calc();
        public string s="";
        public CALCULATOR()
        {
            InitializeComponent();
        }
        
        private void numbers_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (textBox1.Text == "0")
            {
                textBox1.Text = "";
            }
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (textBox1.Text[i] == ',')
                    tcnt++;
            }
            if (tcnt > 0 && btn.Text == ",")
            {
                return;
            }
            else
            {
                if (operation1cnt == 1)
                {
                    textBox1.Text = "";
                    calc.result = 0;
                    calc.fn = 0;
                    calc.sn = 0;
                    label1.Text = "";
                }
                textBox1.Text += btn.Text;
            }
            operationcnt = 0;
            s += btn.Text;
        }

        private void operation_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (operationcnt == 1)
            {
                calc.operation = btn.Text;
                string j = "";
                for(int i = 0; i < label1.Text.Length-1; i++)
                {
                    j += label1.Text[i];
                }
                label1.Text = j;
                label1.Text += btn.Text;
                 return;
            }
            double a = double.Parse(textBox1.Text);
            calc.calculate1(a);

            tcnt = 0;
            operation1cnt = 0;
            textBox1.Text = "";
            calc.operation = btn.Text;
            label1.Text += s;
            s = "";
            label1.Text += btn.Text;
            operationcnt = 1;
        }

        private void operation1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            calc.operation1 = btn.Text;
            s="";
            double a = double.Parse(textBox1.Text);
            calc.calculate2(operation1cnt,label1.Text,textBox1.Text, a);
            label1.Text = calc.l;
            textBox1.Text = calc.t;
            operation1cnt = calc.o1c;
        }

        private void memory_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            calc.operation = btn.Text;
            calc.Memory(textBox1.Text);
            textBox1.Text = calc.t;
            label1.Text = calc.l;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            calc.operation = btn.Text;
            calc.Clear(operation1cnt, operationcnt, tcnt, label1.Text, textBox1.Text);
            operationcnt = calc.oc;
            operation1cnt = calc.o1c;
            tcnt = calc.tcntt;
            label1.Text = calc.l;
            textBox1.Text = calc.t;
            s = "";
        }
        private void result_Click(object sender, EventArgs e)
        {
            s = "";
            if(operation1cnt==0)
            calc.sn = double.Parse(textBox1.Text);
            calc.Result();
            label1.Text = "";
            calc.fn = calc.result;
            textBox1.Text = calc.result.ToString();
            operation1cnt = 1;
            operationcnt = 0;
        }
    }
}
