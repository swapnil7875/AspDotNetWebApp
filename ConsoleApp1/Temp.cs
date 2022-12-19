using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // INHERITANCE
     class  Temp
    {
        public int Age;
        public string parentName;
    }

    class childOfTemp : Temp
    {
        public int ChlidAge;
        public string ChildName;

        public void print()
        {
            Console.WriteLine("Parent age is:" + Age);
            Console.WriteLine("Child age is:" + ChlidAge);
        }


    }

    // polymorphism
    public class Poly
    {
        public int method1(int a, int b)                //methods call as per there number of input parameter
        {
            return a + b;
        }
        public int method1(int a, int b, int c)
        {
            return a + b + c;
        }
    }

}
