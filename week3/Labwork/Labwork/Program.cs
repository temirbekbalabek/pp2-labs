using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp3
{
    class Program
    {
        public static void S(FileSystemInfo[] d, int cursor)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            int index = 0;
            foreach (FileSystemInfo dd in d)
            {

                if (index == cursor)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine(dd);
                index++;
            }

        }
        static void Main(string[] args)
        {
            int cursor = 0;
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\User\Desktop\pp2 labs");

            DirectoryInfo b = new DirectoryInfo(@"C:\Users\User\Desktop\pp2 labs");
            FileSystemInfo[] fs = d.GetFileSystemInfos();
            S(fs, cursor);
            while (true)
            {
                ConsoleKeyInfo pk = Console.ReadKey();
                if (pk.Key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor < 0)
                        cursor = fs.Length - 1;
                }
                if (pk.Key == ConsoleKey.DownArrow)
                    cursor = (cursor + 1) % fs.Length;
                if (pk.Key == ConsoleKey.Enter)
                {
                    if (fs[cursor].GetType() != typeof(DirectoryInfo))
                    {
                        string text = File.ReadAllText(fs[cursor].FullName);
                        Console.Clear();
                        Console.WriteLine(text);
                        Console.ReadKey();
                    }
                    else
                    {
                        d = new DirectoryInfo(fs[cursor].FullName);
                        cursor = 0;
                        fs = d.GetFileSystemInfos();
                    }
                }
                if (pk.Key == ConsoleKey.Escape)
                {
                    if (d.FullName == b.FullName)
                        return;
                    Console.Clear();
                    d = d.Parent;
                    fs = d.GetFileSystemInfos();
                    cursor = 0;
                }
                S(fs, cursor);
            }
        }
    }
}