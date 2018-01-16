using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Minimum_and_Maximum
{
    class Program
    {
        static void Main(string[] args)
        {
                string text = File.ReadAllText(@"C:\Users\User\Desktop\pp2 labs\a.txt");
                args = text.Split();
                int minn = int.Parse(args[0]), maxx = int.Parse(args[0]);
                foreach (string s in args)
                {
                    int k = int.Parse(s);
                    minn = Math.Min(minn, k);
                    maxx = Math.Max(maxx, k);
                }
            Console.WriteLine("the minimum number is");
                Console.WriteLine(minn);
            Console.WriteLine("the maximum number is");
                Console.WriteLine(maxx);
                Console.ReadKey();
            }
        }
    }
