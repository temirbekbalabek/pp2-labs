﻿using System;
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
        bool isnumbersclicked = false;
        public string s="";
        public CALCULATOR()
        {
            InitializeComponent();
            textBox1.Text = "0";
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
            if(tcnt==0 && btn.Text == "," && isnumbersclicked == false)
            {
                textBox1.Text += "0";
                s += "0";
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
                   // calc.l = "";
                    label1.Text = "";
                    s = "";
                }
                textBox1.Text += btn.Text;
            }
            operationcnt = 0;
            s += btn.Text;
            isnumbersclicked = true;
        }

        private void operation_Click(object sender, EventArgs e)
        {
            isnumbersclicked = false;
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
            if (btn.Text == "x^y" || btn.Text == "x^(1/y)")
            {
                if (btn.Text == "x^y")
                {
                    label1.Text += "^";
                }
                if (btn.Text == "x^(1/y)")
                {
                    label1.Text += "^(1/";
                }
            }
            else
                label1.Text += btn.Text;
            operationcnt = 1;
        }

        private void operation1_Click(object sender, EventArgs e)
        {
            isnumbersclicked = false;
            Button btn = sender as Button;
            calc.operation1 = btn.Text;
            s="";
            double a = double.Parse(textBox1.Text);
            if (operation1cnt == 1)
            {
                label1.Text = "";
            }
            calc.calculate2(operation1cnt,label1.Text,textBox1.Text, a);
            label1.Text = calc.l;
            textBox1.Text = calc.t;
            operation1cnt = calc.o1c;
        }

        private void memory_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            calc.operation3 = btn.Text;
            calc.Memory(textBox1.Text);
            textBox1.Text = calc.t;
            label1.Text = calc.l;
            calc.operation3 = "";
        }

        private void CALCULATOR_Load(object sender, EventArgs e)
        {

        }

        private void clear_Click(object sender, EventArgs e)
        {
            isnumbersclicked = false;
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
            isnumbersclicked = false;
            s = "";
            if(operation1cnt==0)
            calc.sn = double.Parse(textBox1.Text);
            //label1.Text += calc.sn;
            calc.Result();
            calc.operation = "";
            label1.Text = "";
            calc.fn = calc.result;
            textBox1.Text = calc.result.ToString();
            operation1cnt = 1;
            operationcnt = 0;
        }
    }
}
