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
           
            int index = 0;
            int cnt = 1;
            //Console.SetCursorPosition(10, 10);
            foreach (FileSystemInfo dd in d)
            {
                if (index == cursor)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    if (dd.GetType() == typeof(FileInfo))
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    if (dd.GetType() == typeof(DirectoryInfo))
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
                    Console.WriteLine("|"+cnt + ")" + dd+"|");
                    index++;
                    cnt++;
            }
        }
        static void Main(string[] args)
        {
            int cursor = 0;
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\User\Desktop\pp2 labs");
            DirectoryInfo b = new DirectoryInfo(@"C:\Users\User\Desktop\pp2 labs");
            FileSystemInfo[] fs = d.GetFileSystemInfos();
            Stack<int> stack = new Stack<int>();
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
                        StreamReader sr = new StreamReader(fs[cursor].FullName);
                        Console.Clear();
                        Console.WriteLine(sr.ReadToEnd());
                        Console.ReadKey();
                    }
                    else
                    {
                        d = new DirectoryInfo(fs[cursor].FullName);
                        stack.Push(cursor);
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
                    cursor = stack.Pop();
                    fs = d.GetFileSystemInfos();
                }
                S(fs, cursor);
            }
        }
    }
}