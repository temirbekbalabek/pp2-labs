using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Threading;
namespace Snake
{
    [Serializable]
    class Program
    {
        static Point point = new Point();
        static Food food = new Food();
        static Wall wall = new Wall();
        static Snake snake = new Snake();
        static int direction;
        static string username;
        static int k = 0;
        public static int n = 100;
        public static void Func()
        {
            while (k == 0)
            {
                if((food.location.x == snake.body[0].x && food.location.y == snake.body[0].y))
                {

                    wall.Level(wall, snake);
                    if (snake.body.Count > 1)
                        snake.body.Add(new Point(snake.body[snake.body.Count - 1].x, snake.body[snake.body.Count - 1].y));
                    else
                        snake.body.Add(new Point(5, 5));
                    food.SetRandomPosition(wall, snake);
                    food.Draw();
                }
                if (direction == 1)
                    snake.Move(0, 1);
                if (direction == 2)
                    snake.Move(0, -1);
                if (direction == 3)
                    snake.Move(1, 0);
                if (direction == 4)
                    snake.Move(-1, 0);
                if (snake.CollisionWithWall(snake, wall))
                {
                    snake.RecordSave(username, snake.body.Count);
                    k = 1;
                }
                snake.Draw();
                wall.wallpoint();
                wall.Draw();
                Thread.Sleep(n);
            }
        }


        static void Main(string[] args)
        {
            snake.RecordWrite();
            username = Console.ReadLine();
            Console.Clear();
            Console.CursorVisible = false;
            food.SetRandomPosition(wall, snake);
            food.Draw();
            Thread thread = new Thread(Func);
            thread.Start();
           while (true)
            {
                if (k == 1)
                {
                    Console.ReadKey();
                    return;
                }
                    ConsoleKeyInfo pk = Console.ReadKey();
                    if (pk.Key == ConsoleKey.S)
                    {
                        snake.F1();
                        wall.F1();
                    }
                    if (pk.Key == ConsoleKey.V)
                    {
                        Console.Clear();
                        snake = snake.F2();
                        wall = wall.F2();
                        k = 1;
                    Console.WriteLine(snake.body[0].x+ " " +snake.body[0].y);
                    Console.ReadKey();
                    }
                    if (pk.Key == ConsoleKey.UpArrow)
                        direction = 2;
                    if (pk.Key == ConsoleKey.DownArrow)
                        direction = 1;
                    if (pk.Key == ConsoleKey.LeftArrow)
                        direction = 4;
                    if (pk.Key == ConsoleKey.RightArrow)
                        direction = 3;
               
            }
        }
    }
}