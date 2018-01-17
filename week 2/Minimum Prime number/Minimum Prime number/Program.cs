using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Minimum_Prime_number
{
    class Program
    {
        public static bool isPal(int n) {
            int cnt = 0;
            for (int i = 2; i <= Math.Sqrt(n); i++) {
                if (n % i == 0)
                    cnt++;
            }
            if (cnt == 0)
                return true;
            return false;
        
        }
        static void Main(string[] args)
        {
            string line = File.ReadAllText(@"C:\Users\User\Desktop\pp2 labs\week 2\a.txt");
            args = line.Split();
            int minn = int.Parse(args[0]);
            foreach(string s in args)
            {
                int k = int.Parse(s);
                if (isPal(k))
                    minn = Math.Min(minn, k);

            }
            StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\pp2 labs\week 2\b.txt",true);
            sw.WriteLine(minn);
            sw.Close();
            //File.WriteAllLines(@"C:\Users\User\Desktop\pp2 labs\week 2\b.txt",minn.ToString());
        }
    }
}
