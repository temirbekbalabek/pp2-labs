using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
namespace Snake
{ [Serializable]
    public class point
    {
        public int x, y;
        public point() { }
        public point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}