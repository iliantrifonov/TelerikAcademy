using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.HowManyTimesIsASubstringInAString
{
    //Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
    //    Example: The target substring is "in". The text is as follows:
    //The result is: 9.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string :");
            string text = Console.ReadLine();
            //string key = "in";
            //string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            Console.WriteLine("Enter target substring: ");
            string key = Console.ReadLine(); 
            Console.WriteLine("The amount of occurenses is: ");
            Console.WriteLine(Regex.Matches(text, key, RegexOptions.IgnoreCase).Count);
        }

    }
}
