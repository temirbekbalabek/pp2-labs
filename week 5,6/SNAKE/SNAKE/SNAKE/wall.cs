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
   public class Wall
    {
        public List<point> asdf;
        public string a;
        public int cnt;
        public void F1(Wall wall)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Wall));
            FileStream fs = new FileStream("data2.xml", FileMode.Truncate, FileAccess.ReadWrite);
            xs.Serialize(fs, wall);
            fs.Close();
        }
        public Wall F2()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Wall));
            FileStream fs = new FileStream("data2.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Wall wall = xs.Deserialize(fs) as Wall;
            fs.Close();
            return wall;
        }
        public void wallpoint()
        {
            StreamReader sw = new StreamReader(@"C: \Users\User\Desktop\SNAKE\"+cnt+".txt");
            asdf = new List<point>();
            int mani = int.Parse(sw.ReadLine());
            for (int i = 0; i < mani; i++)
            {
                string line = sw.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    
                    if (line[j] == '*')
                    {
                        asdf.Add(new point(j, i));
                    }
                }
            }
            sw.Close();
        }
        public Wall()
        {
            a = "*";
            asdf = new List<point>();
        }
        public bool Checking(int x, int y)
        {
            Snake snake = new Snake();
            for (int i = 0; i < asdf.Count; i++)
            {
               for(int j=0; j < snake.body.Count; j++)
                {
                    if ((snake.body[j].x == x && snake.body[j].y == y) || (asdf[i].x == x && asdf[i].y == y))
                        return true;
                }
            }
            return false;
        }
        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (point p in asdf)
            {
                Console.SetCursorPosition(p.x,p.y);
                Console.WriteLine(a);
            }
           
        }
    }
}
