
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02.TheSecretsOfNumbers
{
    class TheSecretsOfNumbers
    {
        static void Main(string[] args)
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());
            if (number < 0)
            {
                number *= -1;
            }
            BigInteger original = number;
            BigInteger specialSum = 0;
            int counter = 1;
            while (number != 0)
            {
                specialSum += (number % 10) * counter * counter;
                number /= 10;
                counter++;
                specialSum += (number % 10) * (number % 10) * (counter);
                number /= 10;
                counter++;
            }
            Console.WriteLine(specialSum);
            int alphaLenght = (int)(specialSum % 10);
            if (alphaLenght == 0)
            {
                Console.WriteLine("{0} has no secret alpha-sequence", original);
            }
            else
            {
                int startLetter = (int)(specialSum % 26);
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                StringBuilder alphaSequence = new StringBuilder();
                for (int i = 0; i < alphaLenght; i++)
                {
                    alphaSequence.Append(alphabet[startLetter]);
                    if (startLetter == 25)
                    {
                        startLetter = -1;
                    }
                    startLetter++;
                }
                Console.WriteLine(alphaSequence);
            }

        }
    }
}
