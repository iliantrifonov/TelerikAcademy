using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.IntDoubleOrString
{
    class IntDoubleOrString
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 for int, 2 for double 3 for string");
            int userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    Console.Write("Please enter an int value:");
                    int num = int.Parse(Console.ReadLine());
                    Console.WriteLine(num + 1);
                    break;
                case 2:
                    Console.Write("Please enter a double value:");
                    double numDouble = double.Parse(Console.ReadLine());
                    Console.WriteLine(numDouble + 1);
                    break;
                case 3:
                    Console.Write("Please enter a string value:");
                    string str = Console.ReadLine();
                    Console.WriteLine(str + "*");
                    break;
                default:
                    break;
            }
        }
    }
}
