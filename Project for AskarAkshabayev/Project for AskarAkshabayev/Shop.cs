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
        public int cnt;
        public Shop()
        {
            list = new List<Products>();
            cnt = 1;
        }
        public void Shoplist()
        {
            StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\pp2 labs\week3\Labwork\Labwork\bin\Debug" + cnt + "Shop.txt");
            int n = int.Parse(sr.ReadLine());
            Products products = new Products();
            for (int i = 0; i < n; i++)
            {
                string s = sr.ReadLine();
                string[] s1 = s.Split();
                string name = s1[0];
                int price = int.Parse(s1[1]);
                int quantity = int.Parse(s1[2]);
                list.Add(new Products(name, price, quantity));
            }
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
