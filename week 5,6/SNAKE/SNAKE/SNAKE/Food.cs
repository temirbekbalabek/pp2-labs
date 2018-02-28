using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Snake
{
    public class Food
    { 

        public ConsoleColor color;
        public char sign;
        public Point location;
        public Food()
        {
            color = ConsoleColor.Green;
            sign='@';
        }
        public void F1()
        {
            StreamWriter sw = new StreamWriter("data1.xml", false);
            XmlSerializer xs = new XmlSerializer(typeof(Food));
            xs.Serialize(sw, this);
            sw.Close();
        }
        public Food F2()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Food));
            FileStream fs = new FileStream("data1.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Food food = xs.Deserialize(fs) as Food;
            fs.Close();
            return food;
        }
        public void SetRandomPosition(Wall wall, Snake snake)
        {
            int x = new Random().Next(1, 25);
            int y = new Random().Next(1, 25);
            while (Checking(wall, snake, x, y))
            {
                x = new Random().Next(1, 25);
                y = new Random().Next(1, 25);
            }
            location =(new Point(x, y));
        }
        public bool Checking(Wall wall,Snake snake, int x, int y)
        {

            for (int i = 0; i < wall.asdf.Count; i++)
            {
                for (int j = 0; j < snake.body.Count; j++)
                {
                    if ((snake.body[j].x == x && snake.body[j].y == y) || (wall.asdf[i].x == x && wall.asdf[i].y == y))
                        return true;
                }
            }
            return false;
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(location.x, location.y);
            Console.Write(sign);
        }
    }
}
