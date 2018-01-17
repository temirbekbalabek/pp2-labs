using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class complex
    {
        int a, b;
        public complex(int _a, int _b)
        {
            a = _a;
            b = _b;
        }
        public static int lcmm(int e, int f)
        {
            int gcd=-1, lcm;
            for (int i = Math.Min(e, f); i >= 1; i--)
            {
                if (Math.Max(e, f) % i == 0 && Math.Min(e, f) % i == 0)
                {
                    gcd = i;
                    break;
                }
            }
            lcm = (e * f) / (gcd);
            return lcm;
        }
        public static complex operator +(complex x, complex y)
        {
            int lcm = lcmm(x.b, y.b);
            int alymy = (lcm * x.a) / x.b + (lcm * y.a) / y.b;
            int bolymy = lcm;
            int gcd = (alymy * bolymy) / lcmm(alymy, bolymy);
            complex g = new complex(alymy / gcd, bolymy / gcd);
            return g;
        }
        public static complex operator *(complex x, complex y)
        {
            int alymy = x.a * y.a;
            int bolymy = x.b * y.b;
            int gcd = (alymy * bolymy) / lcmm(alymy, bolymy);
            complex g = new complex(alymy/gcd, bolymy/gcd);
            return g;
        }
        public static complex operator /(complex x, complex y)
        {
            int alymy = x.a * y.b;
            int bolymy = x.b * y.a;
            int gcd = (alymy * bolymy) / lcmm(alymy, bolymy);
            complex g = new complex(alymy / gcd, bolymy / gcd);
            return g;
        }
        public static complex operator -(complex x, complex y)
        {
            int lcm = lcmm(x.b, y.b);
            int alymy = (lcm * x.a) / x.b - (lcm * y.a) / y.b;
            int bolymy = lcm;
            int gcd = (alymy * bolymy) / lcmm(alymy, bolymy);
            complex g = new complex(alymy / gcd, bolymy / gcd);
            return g;
        }

        public override string ToString()
        {
            return a + "/" + b;
        }

    }
}
