using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rectangle
{
    class Program
    {
        class Rectangle
        {
            double w, h,area,perimeter;
            public Rectangle(double a, double b)
            {
                w = a;
                h = b;
                FindArea();
                FindPerimeter();
            }
            public void FindArea()
            {
                area = w * h;
            }
            public void FindPerimeter()
            {
                perimeter = (2*w +2* h);
            }
            public override string ToString()
            {
                return "area = "+area+"\nperimeter = "+perimeter;
            }
        }
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            Rectangle c = new Rectangle(a, b);
            Console.WriteLine(c);
            Console.ReadKey();

        }
    }
}
