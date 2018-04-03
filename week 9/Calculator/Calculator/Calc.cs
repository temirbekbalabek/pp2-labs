using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calc
    {
        public double fn = 0, sn = 0, result = 0, o1c = 0, oc = 0,tcntt;
        public string operation = "", operation1 = "", l = "", t = "", b = "", memory = "";
        public void Numbers(double o1, double o, double tcnt, string label, string textBox, string btn)
        {

          
        }
        public void calculate1(double a)
        {
            
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
            
        }

        public void calculate2(double o1,string label, string textBox, double a)
        {
            if (operation1 == "√")
            {
                result = Math.Sqrt(a);
                sn = result;
                textBox = result.ToString();
                label += "√(";
                label += a;
                label += ")";
                o1 = 1;
            }
            if (operation1 == "tan(x)")
            {
                result = Math.Tan((Math.PI * a) / 180);
                sn = result;
                textBox = result.ToString();
                label += "tan(";
                label += a;
                label += ")";
                o1 = 1;
            }
            if (operation1 == "sin(x)")
            {
                result = Math.Sin((Math.PI * a) / 180);
                sn = result;
                textBox = result.ToString();
                label += "sin(";
                label += a;
                label += ")";
                o1 = 1;
            }
            if (operation1 == "cos(x)")
            {
                result = Math.Cos((Math.PI * a) / 180);
                sn = result;
                textBox = result.ToString();
                label += "cos(";
                label += a;
                label += ")";
                o1 = 1;
            }
            if (operation1 == "x^2")
            {
                result = a * a;
                sn = result;
                textBox = result.ToString();
                label += a;
                label += "^2";
                o1 = 1;
            }
            if (operation1 == "1/x")
            {
                result = 1 / a;
                sn = result;
                textBox = result.ToString();
                label += "1/";
                label += a;
                o1 = 1;
            }
            if (operation1 == "+/─")
            {
                result = 0 - a;
                textBox = result.ToString();
                label = "";
            }
            o1c = o1;
            l = label;
            t = textBox;
        }
        public void Memory(string textBox)
        {
            if (operation == "MS")
            {
                memory = textBox;
            }
            if (operation == "MC")
            {
                memory = "0";
            }
            if (operation == "MR")
            {
                textBox = memory;
            }
            if (operation == "M+")
            {
                double m = double.Parse(textBox);
                double n = double.Parse(memory);
                memory = (n + m).ToString();
            }
            if (operation == "M-")
            {
                double m = double.Parse(textBox);
                double n = double.Parse(memory);
                memory = (n - m).ToString();
            }
            t = textBox;
            l = "";
        }
        public void Result()
        {
            if (operation == "×")
            {
                result = fn * sn;
            }
            if (operation == "x^y")
            {
                result = Math.Pow(fn, sn);
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
        }
        public void Clear(double o1, double o, double tcnt, string label, string textBox)
        {
            if (operation == "C")
            {
                textBox= "0";
                label = "";
                tcnt = 0;
                o1 = 0;
                o = 0;
                result = 0;
                fn = 0;
                sn = 0;
                operation = "";
                operation1 = "";
            }
            if (operation == "←")
            {
                if (o1c == 1)
                {
                    return;
                }
                string s1 = "", s2 = "";
                if (textBox == "0")
                {
                    return;
                }
                for (int i = 0; i < textBox.Length - 1; i++)
                {
                    s1 += textBox[i];
                }
                for (int i = 0; i < label.Length - 1; i++)
                {
                    s2 += textBox[i];
                }
                fn = 0;
                sn = 0;
                result = 0;
                if (s1 == "")
                {
                    textBox = "0";
                }
                else
                    textBox = s1;
                label = s2;
            }
            l = label;
            t = textBox;
            o1c = o1;
            oc = o;
            tcntt = tcnt;
        }
    }
}
