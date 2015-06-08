using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.NeuronMapping
{
    class NeuronMapping
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string num = Console.ReadLine();
                if (num == "-1")
                {
                    break;
                }
                uint number = uint.Parse(num);
                uint result = 0;
                
                for (int i = 1; i < 32; i++)
                {
                    if ((((number >> i) & 1) == 0) && ((((number >> i - 1) & 1) == 1) || (((result >> i - 1) & 1) == 1)) && ((number >> i) != 0))
                    {
                        result = ((uint)1 << i) | result;
                    }
                }
                Console.WriteLine(result);
            }
        }
    }
}
