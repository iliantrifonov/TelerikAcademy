using System;

namespace _02.ReverseString
{
    //Write a program that reads a string, reverses it and prints the result at the console.
    //Example: "sample"  "elpmas".

    class ReverseString
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string for reversing: ");
            string word = Console.ReadLine();
            char[] strArr = word.ToCharArray();
            Array.Reverse(strArr);
            Console.WriteLine(strArr);
        }
    }
}
