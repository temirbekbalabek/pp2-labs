using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    class Program
    {
        class Circle
        {
            double r,a,d,c;
            public Circle(double r)
            {
                this.r = r;
                findArea();
                findDiameter();
                findCircumference();
            }
            public void findArea()
            {
                a = Math.PI * r * r;
            }
            public void findDiameter()
            {
                d = 2 * r;
            }
            public void findCircumference()
            {
                c = 2 * Math.PI * r;
            }
            public override string ToString()
            {
                return "Area = "+a+"\nDiameter = "+d+"\nCircumference = "+c;
            }
        }
        static void Main(string[] args)
        {
            double k = double.Parse(Console.ReadLine());
            Circle c = new Circle(k);
            Console.WriteLine(c);
            Console.ReadKey();
        }
    }
}
