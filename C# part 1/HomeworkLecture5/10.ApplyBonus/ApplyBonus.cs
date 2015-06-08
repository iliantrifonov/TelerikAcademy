using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.ApplyBonus
{
    class ApplyBonus
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number between 1 and 9");
            string num = Console.ReadLine();
            switch (num)
            {
                case "1":
                    Console.WriteLine(1 * 10);
                    break;
                case "2":
                    Console.WriteLine(2 * 10);
                    break;
                case "3":
                    Console.WriteLine(3 * 10);
                    break;
                case "4":
                    Console.WriteLine(4 * 100);
                    break;
                case "5":
                    Console.WriteLine(5 * 100);
                    break;
                case "6":
                    Console.WriteLine(6 * 100);
                    break;
                case "7":
                    Console.WriteLine(7 * 1000);
                    break;
                case "8":
                    Console.WriteLine(8 * 1000);
                    break;
                case "9":
                    Console.WriteLine(9 * 1000);
                    break;
                default:
                    Console.WriteLine("You have entered an incorrect value");
                    break;
            }
        }
    }
}
