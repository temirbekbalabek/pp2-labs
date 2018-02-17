using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_for_AskarAkshabayev
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("if want to see the list of 1 shop tap 1");
            Console.WriteLine("if want to see the list of 2 shop tap 2");
            Console.WriteLine("if want to see the list of 3 shop tap 3");
            Shop shop = new Shop();
            ConsoleKeyInfo pk = Console.ReadKey();
            if (pk.Key == ConsoleKey.D1)
                shop.cnt=1;
            if (pk.Key == ConsoleKey.D2)
                shop.cnt=2;
            if (pk.Key == ConsoleKey.D3)
                shop.cnt = 3;
            shop.Shoplist();
            shop.Draw();
        }
    }
}
