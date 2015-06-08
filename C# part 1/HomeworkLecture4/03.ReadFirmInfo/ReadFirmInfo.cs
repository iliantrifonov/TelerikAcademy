using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ReadFirmInfo
{
    class ReadFirmInfo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert the name of the firm :");
            string firmName = Console.ReadLine();
            Console.WriteLine("Insert the address of the firm :");
            string firmAddress = Console.ReadLine();
            Console.WriteLine("Insert the telephone of the firm :");
            int firmTel = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert the fax of the firm :");
            int firmFax = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert the website of the firm :");
            string firmWeb = Console.ReadLine();
            Console.WriteLine("Insert the first name of the manager of the firm :");
            string firstName = Console.ReadLine();
            Console.WriteLine("Insert the surname of the manager of the firm :");
            string surName = Console.ReadLine();
            Console.WriteLine("Insert the age of the manager :");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert the telephone of the manager :");
            int manTel = int.Parse(Console.ReadLine());
            Console.WriteLine(@"Company name : {0}
Company Address: {1}
Company phone number : {2}
Company fax : {3}
Company web site : {4}
Manager :  {5} {6}, aged {7}
Manager telephone number : {8} ", firmName, firmAddress, firmTel, firmFax, firmWeb, firstName, surName, age, manTel);
        }
    }
}
