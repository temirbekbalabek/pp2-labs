using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Project_for_AskarAkshabayev
{
    class Shop
    {
        public List<Products> list;
        public int ab;
        public Shop(){ }
        public void Shoplist(FileInfo f)
        {
            list = new List<Products>();
            StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\pp2 labs\Project for AskarAkshabayev\alltxtfiles\" + f.Name);
            int n = int.Parse(sr.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string s = sr.ReadLine();
                string[] s1 = s.Split();
                string name = s1[0];
                int price = int.Parse(s1[1]);
                int quantity = int.Parse(s1[2]);
                list.Add(new Products(name, price, quantity));
            }
            sr.Close();
        }
        public void Checking(FileInfo f, int cursor)
        {
            List<Products> list2 = new List<Products>();
            int cnt=0;
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].quantity > 1)
                    list2.Add(new Products(list[i].name, list[i].price, list[i].quantity));
                if (list[i].quantity < 1)
                {
                    cnt++;
                }
            }
            if (cnt > 0)
            {
                ab = 1;
            }
            list = list2;
            StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\pp2 labs\Project for AskarAkshabayev\alltxtfiles\" + f.Name);
            sw.WriteLine(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                sw.WriteLine(list[i].name + " " + list[i].price + " " + list[i].quantity);
            }
            sw.Close();
        }
        public void Buy(FileInfo f, int cursor)
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\pp2 labs\Project for AskarAkshabayev\alltxtfiles\" + f.Name);
            sw.WriteLine(list.Count);
            list[cursor].quantity--;
            for (int i = 0; i < list.Count; i++)
            {
                sw.WriteLine(list[i].name + " " + list[i].price + " " + list[i].quantity);
            }
            sw.Close();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Congratulations, you have successfully bought the product");
                Console.ReadKey();
        }
        public void Sell(string s, int a, FileInfo f)
        {
            int k = 0;
            StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\pp2 labs\Project for AskarAkshabayev\alltxtfiles\" + f.Name);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].name == s)
                {
                    k = 1;
                    list[i].quantity++;
                    break;
                }
            }
            if (k == 0)
            {
                sw.WriteLine(list.Count + 1);
                for(int i = 0; i < list.Count; i++)
                {
                    sw.WriteLine(list[i].name + " " + list[i].price + " " + list[i].quantity);
                }
                sw.WriteLine(s + " " + a + " " + 1);
            }
            else
            {
                sw.WriteLine(list.Count);
                for (int i = 0; i < list.Count; i++)
                {
                    sw.WriteLine(list[i].name + " " + list[i].price + " " + list[i].quantity);
                }
            }
            sw.Close();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("You have successfully sold the product!");
            Console.ReadKey();
        }
        public void Draw(int cursor)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            int index = 0;
            for(int i = 0; i < list.Count; i++)
            {
                if (index == cursor)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.WriteLine(list[i].name + " " + list[i].price + " " + list[i].quantity);
                index++;
            }
        }
    }
}
