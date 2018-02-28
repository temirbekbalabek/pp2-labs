using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTERM1
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 1;
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                k *= 2;
            }
            Console.WriteLine(k);
            Console.ReadKey();
        }
    }
}
