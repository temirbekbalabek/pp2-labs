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
        public List<Point> asdf;
        public string a;
        public int cnt;
        public void F1()
        {
            StreamWriter sw = new StreamWriter("data2.xml", false);
            XmlSerializer xs = new XmlSerializer(typeof(Wall));
            xs.Serialize(sw, this);
            sw.Close();
        }
        public Wall F2()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Wall));
            FileStream fs = new FileStream("data2.xml", FileMode.Open, FileAccess.Read);
            Wall wall = xs.Deserialize(fs) as Wall;
            fs.Close();
            return wall;
        }
        public void wallpoint()
        {
            StreamReader sw = new StreamReader(@"C:\Users\User\Desktop\pp2 labs\week 5,6\SNAKE\" + cnt+".txt");
            asdf = new List<Point>();
            int mani = int.Parse(sw.ReadLine());
            for (int i = 0; i < mani; i++)
            {
                string line = sw.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    
                    if (line[j] == '*')
                    {
                        asdf.Add(new Point(j, i));
                    }
                }
            }
            sw.Close();
        }
        public Wall()
        {
            a = "*";
            asdf = new List<Point>();
        }
        
        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (Point p in asdf)
            {
                Console.SetCursorPosition(p.x,p.y);
                Console.WriteLine(a);
            }
           
        }
        public void Level(Wall wall,Snake snake)
        {
            if (snake.body.Count == 4)
            {
                Console.Clear();
                wall.cnt++;
                wall.wallpoint();
                int j1 = 5;
                for (int i = 0; i < snake.body.Count; i++)
                {
                    snake.body[i].x = j1;
                    snake.body[i].y = 15;
                    j1++;
                }
            }
            if (snake.body.Count == 8)
            {
                
                Console.Clear();
                wall.cnt++;
                wall.wallpoint();
                int j2 = 5;
                for (int i = 0; i < snake.body.Count; i++)
                {
                    snake.body[i].x = j2;
                    snake.body[i].y = 15;
                    j2++;
                }
            }
        }
    }
}
