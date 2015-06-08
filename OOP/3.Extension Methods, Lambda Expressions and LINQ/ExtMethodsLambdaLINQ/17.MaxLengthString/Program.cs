namespace _17.MaxLengthString
{
    using System;
    using System.Linq;

    //Write a program to return the string with maximum length from an array of strings. Use LINQ.
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] strings = new string[] { "dsa", "sdada", "a", "tsa", "the longest possible string here" };

            //here we sort, take all , then take first.. should not be very fast
            string longestString =
                (
                from str in strings
                orderby str.Length
                select strings.Last()
                ).FirstOrDefault();
            //here we find the largest lenght, this should be a bit faster
            var longest =
                (
                from text in strings
                where text.Length == strings.Max(tx => tx.Length)
                select text
                ).FirstOrDefault();

            Console.WriteLine(longest);
            Console.WriteLine(longestString);
        }
    }
}