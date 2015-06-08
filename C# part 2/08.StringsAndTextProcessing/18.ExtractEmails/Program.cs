using System;
using System.Text.RegularExpressions;

namespace _18.ExtractEmails
{
    //Write a program for extracting all email addresses from given text. All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.

    class Program
    {
        static void Main(string[] args)
        {
            string text = @"email  exa_mple@abv.bg or at text.text@yahoo.co.uk . This is not email: test@test. Neither is : something.@somthing-bg This also: @test.com. Neither this: a@a.b.";
            string[] arrayOfStrings = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < arrayOfStrings.Length; i++)
            {
                if (Regex.IsMatch(arrayOfStrings[i], @"[\w.]{2,20}@[\w]{2,20}[.]{1}[\w.]{2,6}"))
                {
                    Console.WriteLine("{0} is a valid email", arrayOfStrings[i]);
                }
            }
        }
    }
}
