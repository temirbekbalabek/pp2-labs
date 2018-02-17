using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Project_for_AskarAkshabayev
{
    class Products
    {
        public string name;
        public int price;
        public int quantity;
        public Products() { }
        public Products(string nname, int pprice, int qquantity)
        {
            name = nname;
            pprice = price;
            qquantity = quantity;
        }
    }
}
