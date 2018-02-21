using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Project_for_AskarAkshabayev
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Shop shop = new Shop();
            while (true)
            {
                DirectoryInfo d = new DirectoryInfo(@"C:\Users\User\Desktop\pp2 labs\Project for AskarAkshabayev\alltxtfiles");
                FileInfo[] f = d.GetFiles();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("if you want to see our shops, tap 1");
                Console.WriteLine("if you want to create another shop, tap 2");
                ConsoleKeyInfo pk = Console.ReadKey();

                if (pk.Key == ConsoleKey.NumPad1 || pk.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    for (int i = 0; i < f.Length; i++)
                    {
                        Console.WriteLine(f[i]);
                    }
                    int t=0;
                    string line = Console.ReadLine();
                    foreach(FileInfo ff in f)
                    {
                        if (ff.Name == line)
                        {
                            t = 1;
                            break;
                        }
                    }
                    if (t == 0)
                    {
                        Console.WriteLine("Unfortunately, we do not this kind of shop");
                        Console.ReadKey();
                        continue;
                    }
                        shop.nameoffiles = line;
                        Console.Clear();
                        shop.Shoplist();
                        shop.Draw();
                    Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine("If you want to buy something, tap B");
                        Console.WriteLine("if you want to sell something, tap S");
                        ConsoleKeyInfo pk1 = Console.ReadKey();
                        if (pk1.Key == ConsoleKey.B)
                        {
                            Console.Clear();
                            string nameofproduct = Console.ReadLine();
                            shop.Buy(nameofproduct);
                            shop.Checking();
                        }
                        if (pk1.Key == ConsoleKey.S)
                        {
                            Console.Clear();
                            string nameofproduct2 = Console.ReadLine();
                            int b = int.Parse(Console.ReadLine());
                            shop.Sell(nameofproduct2, b);
                        }
                    
                }
                if (pk.Key == ConsoleKey.NumPad2 || pk.Key==ConsoleKey.D2)
                {
                    Console.Clear();
                    string line2 = Console.ReadLine();
                    FileStream fs = new FileStream(@"C:\Users\User\Desktop\pp2 labs\Project for AskarAkshabayev\alltxtfiles\" + line2 + ".txt",FileMode.OpenOrCreate,FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("0");
                    sw.Close();
                }

            }          
        }
    }
}
