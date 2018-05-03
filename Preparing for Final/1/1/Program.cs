using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace _1
{
    class Program
    {
        static int cnt = 1;
        static double x = 20, y = 15, r = 10;
        static void DrawNumber()
        {
            while (true)
            {
                int a = 1,angle=-60;
                for (int i = 1; i <= 12; i++)
                {
                    double x1 = x + r * Math.Cos((angle * Math.PI) / 180);
                    double y1 = y + r * Math.Sin((angle * Math.PI) / 180);
                    int x11 = Convert.ToInt32(x1);
                    int y11 = Convert.ToInt32(y1);
                    Console.SetCursorPosition(x11, y11);
                    if (cnt == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                        Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(a);
                    a++;
                    angle += 30;
                }
                if (cnt == 12)
                    cnt = 1;
                else
                    cnt++;
                Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(DrawNumber);
            thread.Start();

        }
    }
}
