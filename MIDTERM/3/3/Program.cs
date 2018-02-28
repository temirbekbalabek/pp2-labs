using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\");
            FileInfo[] f = d.GetFiles();
            int k = 0;
            foreach(FileInfo ff in f)
            {
                StreamReader sr = new StreamReader(ff.FullName);
               

            }
        }
    }
}
