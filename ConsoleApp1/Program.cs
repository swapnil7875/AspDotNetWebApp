using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            childOfTemp obj = new childOfTemp();
            obj.Age = 50;
            obj.parentName = "parents";
            obj.ChlidAge = 5;
            obj.ChildName = "ChildN";
            obj.print();

            Poly add = new Poly();
            int a = 5;
            int b = 10;
            int c = 15;
            Console.WriteLine(add.method1( a,b));
            Console.WriteLine(add.method1(a, b, c));
            Console.ReadLine();
        }
    }
}
