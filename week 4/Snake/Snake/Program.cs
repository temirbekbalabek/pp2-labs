using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Snake snake = new Snake();
            while (true)
            {
                ConsoleKeyInfo pk = Console.ReadKey();
                if (pk.Key == ConsoleKey.UpArrow)
                    snake.Move(0, -1);
                if (pk.Key == ConsoleKey.DownArrow)
                    Move(0, 1);
                if (pk.Key == ConsoleKey.LeftArrow)
                    Move(-1, 0);
                if (pk.Key == ConsoleKey.RightArrow)
                    Move(1, 0);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        public int x, y;
        public Snake(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Move(int a, int b)
        {
            x += a;
            y += b;
        }
    }
}
