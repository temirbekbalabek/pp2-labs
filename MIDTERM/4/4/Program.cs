using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
namespace _4
{
    class Program
    {
        static int k=1;
        public static ConsoleColor sign;
        static void F()
        {
            while (true)
            {

                    if(k==1 )
                    {
                    Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                    }
                    if(k==2)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.ForegroundColor= ConsoleColor.White;
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                    }

                    if (k==3)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                        Console.WriteLine("********");
                    }
                if (k % 3 == 0)
                {
                    k = 0;
                }

                Thread.Sleep(1000);
                Console.Clear();
                k++;
            }
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(F);
            thread.Start();
        }
    }
}
