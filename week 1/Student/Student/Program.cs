using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Program
    {
        class student
        {
            public string firstname,lastname;
            public float gpa;
            public student(string fname,string lname , float gpaa)
            {
                firstname = fname;
                lastname = lname;
                gpa = gpaa;
               
            }
            public override string ToString()
            {
                return "firstname = " + firstname + "\nlastname = " + lastname + "\ngpa = " + gpa;
            }


        }
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            float a = float.Parse(Console.ReadLine());
            student k = new student(s1,s2,a);
            
            Console.WriteLine(k);
            Console.ReadKey();


        }
    }
}
