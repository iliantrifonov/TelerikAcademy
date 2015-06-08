using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.ExchangeBits
{
    class ExchangeBits
    {
        static void Main(string[] args)
        {
            uint num = 32;
            int startNum = 3;
            int numberOfExchangedBits = 3;
            int largerStartNum = 24;
            int? bitLow;
            int? bitHigh;
            for (int i = startNum; i < startNum + numberOfExchangedBits; i++)
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
                if (((num >> largerStartNum) & 1) == 1)
                {
                    bitHigh = 1;
                }
                else
                {
                    bitHigh = 0;
                }
                //exchanging bits with of the higher bitthe correct "remembered" value
                if ( bitLow == 1 )
                {
                    num = ((uint)1 << largerStartNum) | num;
                }
                else if ( bitLow == 0 )
                {
                    num = (~((uint)1 << largerStartNum) & num);
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
                largerStartNum++;
            }
            Console.WriteLine(num);
        }
    }
}
