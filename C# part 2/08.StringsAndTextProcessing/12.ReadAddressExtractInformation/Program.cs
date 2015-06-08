using System;
using System.Text.RegularExpressions;

namespace _12.ReadAddressExtractInformation
{
    //Write a program that parses an URL address given in the format://and extracts from it the [protocol], [server] and [resource] elements. For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
    //[protocol] = "http"
    //[server] = "www.devbg.org"
    //[resource] = "/forum/index.php"

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Enter address in ""[protocol]://[server]/[resource]"" format:");
            string address = Console.ReadLine();
            //string address = "http://www.devbg.org/forum/index.php";
            var fragments = Regex.Match(address, "(.*)://(.*?)(/.*)").Groups;
            Console.WriteLine("Protocol:");
            Console.WriteLine(fragments[1]);
            Console.WriteLine("Server:");
            Console.WriteLine(fragments[2]);
            Console.WriteLine("Resourse:");
            Console.WriteLine(fragments[3]);
        }
    }
}
