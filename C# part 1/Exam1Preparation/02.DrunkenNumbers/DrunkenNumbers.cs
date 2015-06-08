using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DrunkenNumbers
{
    class DrunkenNumbers
    {
        static void Main(string[] args)
        {
            int numberOfRounds = int.Parse(Console.ReadLine());
            int mitkoBeer = 0;
            int vladkoBeer = 0;
            for (int i = 0; i < numberOfRounds; i++)
            {
                int drunkenNum = int.Parse(Console.ReadLine());
                if (drunkenNum < 0)
                {
                    drunkenNum *= -1;
                }
                string strDrunkNum = drunkenNum.ToString();
                if (strDrunkNum.Length % 2 == 0)
                {
                    for (int k = 0; k < strDrunkNum.Length / 2; k++)
                    {
                        mitkoBeer += int.Parse(strDrunkNum[k].ToString());
                    }
                    for (int k = strDrunkNum.Length / 2; k < strDrunkNum.Length; k++)
                    {
                        vladkoBeer += int.Parse(strDrunkNum[k].ToString());
                    }
                }
                else
                {
                    for (int k = 0; k <= strDrunkNum.Length / 2; k++)
                    {
                        mitkoBeer += int.Parse(strDrunkNum[k].ToString());
                    }
                    for (int k = strDrunkNum.Length / 2; k < strDrunkNum.Length; k++)
                    {
                        vladkoBeer += int.Parse(strDrunkNum[k].ToString());
                    }
                }
            }
            if (vladkoBeer == mitkoBeer)
            {
                Console.WriteLine("No {0}", vladkoBeer + mitkoBeer); 
            }
            if (vladkoBeer > mitkoBeer)
            {
                Console.WriteLine("V {0}", vladkoBeer - mitkoBeer);
            }
            if (vladkoBeer < mitkoBeer)
            {
                Console.WriteLine("M {0}", mitkoBeer - vladkoBeer);
            }
        }
    }
}
