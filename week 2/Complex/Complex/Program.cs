using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace Complex
{
    class Program
    {

        static void F1(Complex g1)
        {
            BinaryFormatter xs = new BinaryFormatter();
            FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            xs.Serialize(fs, g1);
            fs.Close();
        }
        static void F(Complex g1)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            FileStream fs = new FileStream("asdf.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            xs.Serialize(fs, g1);
            fs.Close();
        }
        static void F2()
        {

            BinaryFormatter xs = new BinaryFormatter();
            FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Complex g2 = xs.Deserialize(fs) as Complex;
            Console.WriteLine("The deserialized elements are: "+g2);
        }
        static void F3()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            FileStream fs = new FileStream("data.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Complex g2 = xs.Deserialize(fs) as Complex;
            Console.WriteLine("The deserialized elements are: " + g2);
        }


        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string[] b = a.Split(' ');
            List<int> c = new List<int>();
            foreach(string s in b)
            {
                string[] d = s.Split('/');
                c.Add(int.Parse(d[0]));
                c.Add(int.Parse(d[1]));
            }
            Complex e = new Complex(c[0], c[1]);
            Complex f = new Complex(c[2], c[3]);
            Complex g1 = e + f;
            Complex g2 = e - f;
            Complex g3 = e * f;
            Complex g4 = e / f;
            F1(g1);
            F2();
            F(g2);
            F3();
            Console.WriteLine("The sum of two elements is = "+g1);
            Console.WriteLine("The subtract of two elements is = "+g2);
            Console.WriteLine("The product of two elements is = "+g3);
            Console.WriteLine("The division of two elements is = "+g4);

            Console.ReadKey();
        }
    }
}
