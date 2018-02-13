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
        public Snake(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Move(int a,int b)
        {
            x += a;
            y += b;
        }
    }
}
