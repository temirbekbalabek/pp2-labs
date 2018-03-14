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
        double fn = 0, sn = 0, result=0;
        public int cnt = 0;
        string operation="";
        public CALCULATOR()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numbers.Text = "1";
            button2.Text = "2";
            button3.Text = "3";
            button4.Text = "4";
            button5.Text = "5";
            button6.Text = "6";
            button7.Text = "7";
            button8.Text = "8";
            button9.Text = "9";
            button10.Text = "0";
            button11.Text = "+/─";
            button12.Text = ",";
            button13.Text = "/";
            button14.Text = "×";
            button15.Text = "─";
            button16.Text = "+";
            button17.Text = "=";
            button18.Text = "CE";
            button19.Text = "C";
            button20.Text = "←";
            button21.Text = "%";
            button22.Text = "√";
            button23.Text = "x^2";
            button24.Text = "1/x";

        }
        private void numbers_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            textBox1.Text += btn.Text;
            label1.Text += btn.Text;
        }

        private void operation_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            double a = double.Parse(textBox1.Text);
            if (operation != "")
            {
                if (operation == "×")
                {
                    fn = fn * a;       
                }
                if (operation == "/")
                {
                    fn = fn / a;
                }
                if (operation == "─")
                {
                    fn = fn - a;
                }
                if (operation == "+")
                {
                    fn = fn + a;
                }
            }
            else
            fn = a;

            textBox1.Text = "";
            operation = btn.Text;
            if (operation == "√")
            {
                result = Math.Sqrt(a);
                textBox1.Text = result.ToString();
                label1.Text = "";
                return;
            }
            if (operation == "x^2")
            {
                result = a*a;
                textBox1.Text = result.ToString();
                label1.Text = "";
                return;
            }
            if (operation == "1/x")
            {
                result = 1 / a;
                textBox1.Text = result.ToString();
                label1.Text = "";
                return;
            }
            if (operation == "+/─")
            {
                result = 0 - a;
                textBox1.Text = result.ToString();
                label1.Text = "";
                return;
            }
            label1.Text += btn.Text;
        }
        private void clear_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            operation = btn.Text;
            if (operation == "C")
            {
                textBox1.Text = "";
                label1.Text = "";
                fn = 0;
                sn = 0;
                operation = "";
            }
            if (operation == "←")
            {
                string s1 = "",s2="";
                for (int i = 0; i < textBox1.Text.Length - 1; i++)
                {
                    s1 += textBox1.Text[i];
                }
                for (int i = 0; i < label1.Text.Length - 1; i++)
                {
                    s2 += textBox1.Text[i];
                }
                fn = 0;
                sn = 0;
                result = 0;
                textBox1.Text = s1;
                label1.Text = s2;
            }
        }
        private void result_Click(object sender, EventArgs e)
        {
            sn = double.Parse(textBox1.Text);
            if (operation == "×")
            {
                result = fn * sn;
            }
            if (operation == "/")
            {
                result = fn / sn;
            }
            if (operation == "─")
            {
                result = fn - sn;
            }
            if (operation == "+")
            {
                result = fn + sn;
            }
            textBox1.Text = result.ToString();
            operation = "";
        }
    }
}
