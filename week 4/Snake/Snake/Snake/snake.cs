using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        public List<point> body;
        public string t;
        public int cnt;
        public Snake()
        {
            body = new List<point>();
            body.Add(new point(5, 5));
            t = "■";
        }
        public void Move(int x,int y)
        {
            if (cnt % 8 == 0)
            {
                body.Add(new point(0, 0));
            }
            for(int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i-1].x;
                body[i].y = body[i-1].y;
            }
            body[0].x += x;
            body[0].y += y;
            cnt++;
        }
        public void Draw()
        {
            int index = 0;
                foreach (point p in body)
                {
                if(index==0)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                    index++;
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(t);
                }
        }
    }
}