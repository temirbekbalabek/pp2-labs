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
        public string operation = "", operation1 = "", l = "", t = "", b = "", memory = "",operation3="";
        bool iserror = false;
        public void Numbers(double o1, double o, double tcnt, string label, string textBox, string btn)
        {

          
        }
        public void calculate1(double a)
        {
            
            if (operation != "")
            {
                if (operation == "Mod")
                {
                    fn = fn % a;
                }
                if (operation == "x^y")
                {
                    fn = Math.Pow(fn, a);
                }
                if (operation == "x^(1/y)")
                {
                    fn = Math.Pow(fn, 1 / a);
                }
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
        public void Result()
        {
            if (operation == "Mod")
            {
                result = fn % sn;
            }
            if (operation == "×")
            {
                result = fn * sn;
            }
            if (operation == "x^y")
            {
                result = Math.Pow(fn, sn);
            }
            if (operation == "x^(1/y)")
            {
                result = Math.Pow(fn, 1 / sn);
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
            if (operation1 == "exp(x)")
            {
                result = Math.Exp(a);
                sn = result;
                textBox = result.ToString();
                label += "exp(";
                label += a;
                label += ")";
                o1 = 1;
            }
            if (operation1 == "10^x")
            {
                int ond = 1;
                for(int i = 0; i < a; i++)
                {
                    ond *= 10;
                }
                result = ond;
                sn = result;
                textBox = result.ToString();
                label += "10^";
                label += a;
                o1 = 1;
            }

            if (operation1 == "tan(x)")
            {
                if (a % 90 == 0 || a % 270 == 0)
                {
                    iserror = true;
                }
                else
                    result = Math.Tan((Math.PI * a) / 180);
                sn = result;
                if (iserror)
                    textBox = "Error";
                else
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
                if(a % 90==0 || a % 270==0)
                {
                    result = 0;
                }
                else
                result = Math.Cos((Math.PI * a) / 180);
                sn = result;
                textBox = result.ToString();
                label += "cos(";
                label += a;
                label += ")";
                o1 = 1;
            }
            if (operation1 == "!")
            {
                int kob = 1;
                for(int i = 1; i <=a; i++)
                {
                    kob *= i;
                }
                result = kob;
                sn = result;
                textBox = result.ToString();
                label +=a;
                label += "!";
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
            if (operation3 == "MS")
            {
                memory = textBox;
            }
            if (operation3 == "MC")
            {
                memory = "0";
            }
            if (operation3 == "MR")
            {
                textBox = memory;
            }
            if (operation3 == "M+")
            {
                double m = double.Parse(textBox);
                double n = double.Parse(memory);
                memory = (n + m).ToString();
            }
            if (operation3 == "M-")
            {
                double m = double.Parse(textBox);
                double n = double.Parse(memory);
                memory = (n - m).ToString();
            }
            t = textBox;
            l = "";
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
