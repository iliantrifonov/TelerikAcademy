using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Sheets
{
    class Sheets
    {
        static void Main(string[] args)
        {
            int numberOfA10 = int.Parse(Console.ReadLine());
            int a10 = 1;
            bool a10bool = false;
            int a9 = a10 * 2;
            bool a9bool = false;
            int a8 = a9 * 2;
            bool a8bool = false;
            int a7 = a8 * 2;
            bool a7bool = false;
            int a6 = a7 * 2;
            bool a6bool = false;
            int a5 = a6 * 2;
            bool a5bool = false;
            int a4 = a5 * 2;
            bool a4bool = false;
            int a3 = a4 * 2;
            bool a3bool = false;
            int a2 = a3 * 2;
            bool a2bool = false;
            int a1 = a2 * 2;
            bool a1bool = false;
            int a0 = a1 * 2;
            bool a0bool = false;

            if (numberOfA10 >= a0)
            {
                a0bool = true;
                numberOfA10 -= a0;
            }
            if (numberOfA10 >= a1)
            {
                a1bool = true;
                numberOfA10 -= a1;
            }
            if (numberOfA10 >= a2)
            {
                a2bool = true;
                numberOfA10 -= a2;
            }
            if (numberOfA10 >= a3)
            {
                a3bool = true;
                numberOfA10 -= a3;
            }
            if (numberOfA10 >= a4)
            {
                a4bool = true;
                numberOfA10 -= a4;
            }
            if (numberOfA10 >= a5)
            {
                a5bool = true;
                numberOfA10 -= a5;
            }
            if (numberOfA10 >= a6)
            {
                a6bool = true;
                numberOfA10 -= a6;
            }
            if (numberOfA10 >= a7)
            {
                a7bool = true;
                numberOfA10 -= a7;
            }
            if (numberOfA10 >= a8)
            {
                a8bool = true;
                numberOfA10 -= a8;
            }
            if (numberOfA10 >= a9)
            {
                a9bool = true;
                numberOfA10 -= a9;
            }
            if (numberOfA10 >= a10)
            {
                a10bool = true;
                numberOfA10 -= a10;
            }

            if (!a0bool)
            {
                Console.WriteLine("A0");
            }
            if (!a1bool)
            {
                Console.WriteLine("A1");
            }
            if (!a2bool)
            {
                Console.WriteLine("A2");
            }
            if (!a3bool)
            {
                Console.WriteLine("A3");
            }
            if (!a4bool)
            {
                Console.WriteLine("A4");
            }
            if (!a5bool)
            {
                Console.WriteLine("A5");
            }
            if (!a6bool)
            {
                Console.WriteLine("A6");
            }
            if (!a7bool)
            {
                Console.WriteLine("A7");
            }
            if (!a8bool)
            {
                Console.WriteLine("A8");
            }
            if (!a9bool)
            {
                Console.WriteLine("A9");
            }
            if (!a10bool)
            {
                Console.WriteLine("A10");
            }
        }
    }
}
