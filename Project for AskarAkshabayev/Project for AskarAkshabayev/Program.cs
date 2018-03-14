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
            int cursor1 = 0;
            int cursor2 = 0;
            //int n = 0;
            while (true)
            {
                cursor1 = 0;
                DirectoryInfo d = new DirectoryInfo(@"C:\Users\User\Desktop\pp2 labs\Project for AskarAkshabayev\alltxtfiles");
                FileInfo[] f = d.GetFiles();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("if you want to see our shops, tap 1");
                Console.WriteLine("if you want to create another shop, tap 2");
                ConsoleKeyInfo pk = Console.ReadKey();
                if (pk.Key == ConsoleKey.Escape)
                {
                    Console.ReadKey();
                    return;
                }
                if (pk.Key == ConsoleKey.NumPad1 || pk.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    shop.FileDrawer(f,cursor1);
                    while (true)
                    {
                        ConsoleKeyInfo pk2 = Console.ReadKey();
                        Console.Clear();
                        if (pk2.Key == ConsoleKey.UpArrow)
                        {
                            cursor1--;
                            if (cursor1 == -1)
                                cursor1 = f.Length-1;
                        }
                        if (pk2.Key == ConsoleKey.DownArrow)
                        {
                            cursor1 = (cursor1 + 1) % f.Length;
                        }
                        shop.FileDrawer(f, cursor1);
                        if (pk2.Key == ConsoleKey.Escape)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        }
                        if (pk2.Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                            shop.Shoplist(f[cursor1]);
                            int k = 0;
                            shop.Draw(k);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nIf you want to buy something, tap any product");
                            Console.WriteLine("if you want to sell something, tap S");
                            cursor2 = 0;
                            while (true)
                            {
                                ConsoleKeyInfo pk3 = Console.ReadKey();
                                if (pk3.Key == ConsoleKey.UpArrow)
                                {
                                    cursor2--;
                                    if (cursor2 == -1)
                                        cursor2 = shop.list.Count - 1;
                                }
                                if (pk3.Key == ConsoleKey.DownArrow)
                                {
                                    cursor2 = (cursor2 + 1) % shop.list.Count;
                                }
                                if (pk3.Key == ConsoleKey.Enter)
                                {
                                    Console.Clear();
                                    shop.Buy(f[cursor1], cursor2);
                                    shop.Checking(f[cursor1], cursor2);
                                    if (shop.ab == 1)
                                        cursor2 = 0;
                                }
                                if (pk3.Key == ConsoleKey.Escape)
                                {
                                    Console.Clear();
                                    shop.FileDrawer(f, cursor1);
                                    break;
                                }
                                Console.Clear();
                                shop.Shoplist(f[cursor1]);
                                shop.Draw(cursor2);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\nIf you want to buy something, tap any product");
                                Console.WriteLine("if you want to sell something, tap S");
                                if (pk3.Key == ConsoleKey.S)
                                {
                                    Console.Clear();
                                    string nameofproduct2 = Console.ReadLine();
                                    int b = int.Parse(Console.ReadLine());
                                    shop.Sell(nameofproduct2, b, f[cursor1]);
                                    Console.Clear();
                                    shop.Shoplist(f[cursor1]);
                                    shop.Draw(cursor2);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\nIf you want to buy something, tap any product");
                                    Console.WriteLine("if you want to sell something, tap S");
                                }
                            }
                        }
                        
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
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You have successfully created a new shop, called " + line2);
                    Console.ReadKey();
                }

            }          
        }
    }
}
