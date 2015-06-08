using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.ExchangeMoreBits
{
    class ExchangeMoreBits
    {
        static void Main(string[] args)
        {
            uint num = 32;
            int p = 3;
            int k = 4;
            int q = 24;
            int? bitLow;
            int? bitHigh;
            for (int i = p; i < p + k; i++)
            {
                //checking bits of the higher and lower bits, and "remembering" them
                if (((num >> i) & 1) == 1)
                {
                    bitLow = 1;
                }
                else
                {
                    bitLow = 0;
                }
                if (((num >> q) & 1) == 1)
                {
                    bitHigh = 1;
                }
                else
                {
                    bitHigh = 0;
                }
                //exchanging bits with of the higher bitthe correct "remembered" value
                if (bitLow == 1)
                {
                    num = ((uint)1 << q) | num;
                }
                else if (bitLow == 0)
                {
                    num = (~((uint)1 << q) & num);
                }
                //exchanging bits with of the lower bitthe correct "remembered" value
                if (bitHigh == 1)
                {
                    num = ((uint)1 << i) | num;
                }
                else if (bitHigh == 0)
                {
                    num = (~((uint)1 << i) & num);
                }
                q++;
            }
            Console.WriteLine(num);
        }
    }
}
