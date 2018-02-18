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
        public string nameoffiles;
        public Shop(){ }
        public void Shoplist()
        {
            list = new List<Products>();
            StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\pp2 labs\Project for AskarAkshabayev\alltxtfiles\" + nameoffiles + ".txt");
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
        public void Checking()
        {
            List<Products> list2 = new List<Products>();
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].quantity > 1)
                    list2.Add(new Products(list[i].name, list[i].price, list[i].quantity));
            }
            list = list2;
        }
        public void Buy(string s)
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\pp2 labs\Project for AskarAkshabayev\alltxtfiles\" + nameoffiles + ".txt");
            sw.WriteLine(list.Count);
            int k = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (s == list[i].name)
                {
                    k = 1;
                    list[i].quantity--;
                }
                sw.WriteLine(list[i].name + " " + list[i].price + " " + list[i].quantity);
            }
            sw.Close();
            if (k == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry,unfortunately we do not have such kind of thing");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Congratulations,you have successfully bought the product");
            }
        }
        public void Sell(string s,int a)
        {
            int k = 0;
            StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\pp2 labs\Project for AskarAkshabayev\alltxtfiles\" + nameoffiles + ".txt");
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].name == s)
                {
                    k = 1;
                    list[i].quantity++;
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
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("You have successfully sold the product!");
        }
        public void Draw()
        {
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].name + " " + list[i].price + " " + list[i].quantity);
            }
        }
    }
}
