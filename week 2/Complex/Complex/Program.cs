using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string[] b = a.Split(' ');
            List<int> c = new List<int>();
            foreach(string s in b)
            {
                string[] d = s.Split('/');
                c.Add(int.Parse(d[0]));
                c.Add(int.Parse(d[1]));
            }
            complex e = new complex(c[0], c[1]);
            complex f = new complex(c[2], c[3]);
            complex g1 = e + f;
            complex g2 = e - f;
            complex g3 = e * f;
            complex g4 = e / f;
            
            Console.WriteLine("the sum of two elements is = "+g1);
            Console.WriteLine("the subtract of two elements is = "+g2);
            Console.WriteLine("the product of two elements is = "+g3);
            Console.WriteLine("the division of two elements is = "+g4);

            Console.ReadKey();
        }
    }
}
