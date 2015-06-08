using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _19.ExtractDates
{
    //Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. Display them in the standard date format for Canada.

    class Program
    {
        static void Main(string[] args)
        {
            string text = @"Today on 12.11.1988 something happened that changed the events on 05.02.2011. Краен срок: 23:59 часа на 31.01.2013.
 Видео - 22.01.2013.
 Видео - 23 януари 2013 - Наков.
 Видео - 23.01.2013 - Наков.
 Краен срок: 23:59 часа на 03.02.2013."; 

            foreach (var item in Regex.Matches(text, @"\w+\.\w+\.\w+")) // There are still some things that are not working 100%, like it counts a month "00" as valid.. there are regex-es that will do this better.
            {
                Console.WriteLine("{0}", item, CultureInfo.GetCultureInfo("en-CA"));
            }
        }
    }
}
