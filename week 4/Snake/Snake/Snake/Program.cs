using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        //enum Direction{Left, Right, Up, Down}
        static void Main(string[] args)
        {
            Snake snake = new Snake();
            Random r = new Random();

           // Console.SetCursorPosition(x, y);
            //Console.WriteLine("☺");
            while (true)
            {
                ConsoleKeyInfo pk = new ConsoleKeyInfo();
                if (pk.Key == ConsoleKey.UpArrow)
                    snake.Move(0, -1);
                if (pk.Key == ConsoleKey.DownArrow)
                    snake.Move(0, 1);
                if (pk.Key == ConsoleKey.LeftArrow)
                    snake.Move(-1, 0);
                if (pk.Key == ConsoleKey.RightArrow)
                    snake.Move(1, 0);
                Console.Clear();
                snake.Draw();
                //if(snake.body[0].x==a)
            }
        }
    }
}

