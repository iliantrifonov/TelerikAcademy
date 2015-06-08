using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.CheckThirdDigit
{
    class CheckThirdDigit
    {
        static void Main(string[] args)
        {
            int num = 1723;
            string strNum = num.ToString();
            if (strNum[strNum.Length - 3] == '7') // the brackets access it like an array, .Lenght gives me the lenght of the string so I go back with the necessary number of digits, it will give an exeption if the number has less than 3 digits
            {
                Console.WriteLine("Third digit is 7");
            }
            else
            {
                Console.WriteLine("Third digit is not 7");

            }
        }
    }
}
