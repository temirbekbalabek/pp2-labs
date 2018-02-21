
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
    public class Snake
    {
        public List<Point> body;
        public string t;
        public int global;
        public int xx, yy;
        public Snake()
        {
            body = new List<Point>();
            body.Add(new Point(5,5));
            t = "Q";
            global = 0;
        }
        public void F1()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Snake));
            FileStream fs = new FileStream("d.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            xs.Serialize(fs, this);
            fs.Close();
        }
        public Snake F2()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Snake));
            FileStream fs = new FileStream("d.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Snake snake = xs.Deserialize(fs) as Snake;
            fs.Close();
            return snake;
        }

        public void Move(int x, int y)
        {
            int xx = body[0].x + x;
            int yy = body[0].y + y;
            if (body.Count > 1)
            {
                if (xx == body[1].x && yy == body[1].y)
                    return;
            }
            Console.SetCursorPosition(body[body.Count - 1].x, body[body.Count - 1].y);
            Console.WriteLine(" ");
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            
            body[0].x += x;
            body[0].y += y;
            if (body[0].x < 0)
                body[0].x = Console.WindowWidth - 1;
            if (body[0].x > Console.WindowWidth - 1)
                body[0].x = 0;
            if (body[0].y < 0)
                body[0].y = Console.WindowHeight - 1;
            if (body[0].y > Console.WindowHeight - 1)
                body[0].y = 0;
        }
        public void RecordWrite()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\pp2 labs\week 5,6\SNAKE\recorder.txt");
            Console.WriteLine("The recorder is " + sr.ReadLine() + "\nhis record is " + sr.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            sr.Close();
            Console.WriteLine("Please tell me your name below");
        }
        public void RecordSave( string username,int cnt)
        {
            Console.Clear();
            Console.WriteLine("!!!GAME OVER!!!");
            StreamReader ssr = new StreamReader(@"C:\Users\User\Desktop\pp2 labs\week 5,6\SNAKE\recorder.txt");
            string name = ssr.ReadLine();
            int oldRecord = int.Parse(ssr.ReadLine());
            ssr.Close();
            if (cnt > oldRecord)
            {
                StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\pp2 labs\week 5,6\SNAKE\recorder.txt");
                sw.Write(username);
                sw.WriteLine();
                sw.Write(cnt);
                sw.Close();
            }
            Console.ReadKey();
        }
        public bool CollisionWithWall(Snake snake, Wall wall)
        {
            for (int i = 1; i < snake.body.Count; i++)
            {
                for (int j = 0; j < wall.asdf.Count; j++)
                {
                    if ((snake.body[0].x == snake.body[i].x && snake.body[0].y == snake.body[i].y) || (snake.body[0].x == wall.asdf[j].x && snake.body[0].y == wall.asdf[j].y))
                        return true;
                }
            }
            return false;
        }
        public void Draw()
        {
            int index = 0;
            foreach (Point p in body)
            {
                if (index == 0)
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