using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();//сандарды оқу
            args = line.Split(' ');//әрбір санды бөліп жазу
            foreach (string s in args)
            {
                int b = int.Parse(s);//стриңнан интқа ауыстыру
                int k = 0;
                for (int i = 2; i < b; i++)
                { 
                    if (b % i == 0)
                        k++;
                }
                if (k == 0 && b != 1)
                    Console.WriteLine(b);//экранға шығару

            }
            Console.ReadKey();//жабылып қалмау үшін қолданылатын пауза
        }
    }
}
