using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\MIDTERM\2\input.txt");
            string[] a = sr.ReadLine().Split();
            sr.Close();
            List<int> l =new List<int>();
            foreach(string s in a)
            {
                l.Add(int.Parse(s));
            }
            l.Sort();
            StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\MIDTERM\2\output.txt");
            sw.Write(l[1]);
            sw.Close();
        }
    }
}
