using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
namespace Snake
{
    [Serializable]
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\SNAKE\recorder.txt");
            Console.WriteLine("The recorder is " + sr.ReadLine() + "\nhis record is " + sr.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            sr.Close();
            Console.WriteLine("Please tell me your name below");
            string username =Console.ReadLine();
            Console.Clear();
            Console.WriteLine("then tap the uparrow to start");
            Snake snake = new Snake();
            Random r = new Random();
            Wall wall = new Wall();
            int cnt = 0;
            int a = r.Next(1, 25);
            int b = r.Next(1, 25);
            wall.wallpoint();
            Console.CursorVisible = false;
            while (wall.Checking(a, b))
            {
                a = r.Next(1, 25);
                b = r.Next(1, 25);
            }
            Console.SetCursorPosition(17, 1);
            while (true)
            {
                while (!(a == snake.body[0].x && b == snake.body[0].y))
                {
                    if (snake.CollisionWall(snake,wall))
                    {
                        snake.Record(username, cnt);
                                return;
                    }
                    ConsoleKeyInfo pk = Console.ReadKey();
                    if (pk.Key == ConsoleKey.S)
                    {
                        snake.F1(snake);
                        wall.F1(wall);
                    }
                    if (pk.Key == ConsoleKey.V)
                    {
                        Console.Clear();
                        snake = snake.F2();
                        wall = wall.F2();
                        snake.Draw();
                    }
                    if (pk.Key == ConsoleKey.UpArrow)
                        snake.Move(0, -1);
                    if (pk.Key == ConsoleKey.DownArrow)
                        snake.Move(0, 1);
                    if (pk.Key == ConsoleKey.LeftArrow)
                        snake.Move(-1, 0);
                    if (pk.Key == ConsoleKey.RightArrow)
                        snake.Move(1, 0);
                    Console.SetCursorPosition(a, b);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("0");
                    snake.Draw();
                    wall.Draw();
                }
                cnt++;
                if (snake.body.Count == 4)
                {
                    Console.Clear();
                    wall.cnt++;
                    wall.wallpoint();
                }
                if (snake.body.Count == 8)
                {
                    Console.Clear();
                    wall.cnt++;
                    wall.wallpoint();
                }
                if (snake.body.Count == 12)
                {
                    Console.Clear();
                    wall.cnt++;
                    wall.wallpoint();
                }
                snake.body.Add(new point(a+1, b+1));
                a = r.Next(1, 25);
                b = r.Next(1, 25);
                while (wall.Checking(a, b))
                {
                    a = r.Next(1, 25);
                    b = r.Next(1, 25);
                }
            }
        }
    }
}