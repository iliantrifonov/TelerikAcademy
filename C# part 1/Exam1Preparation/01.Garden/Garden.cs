using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Garden
{
    class Garden
    {
        static void Main(string[] args)
        {
            int totalArea = 250;
            int tomatoSeeds = int.Parse(Console.ReadLine());
            int tomatoArea = int.Parse(Console.ReadLine());
            int cucumberSeeds = int.Parse(Console.ReadLine());
            int cucumberArea = int.Parse(Console.ReadLine());
            int potatoSeeds = int.Parse(Console.ReadLine());
            int potatoArea = int.Parse(Console.ReadLine());
            int carrotSeeds = int.Parse(Console.ReadLine());
            int carrotArea = int.Parse(Console.ReadLine());
            int cabbageSeeds = int.Parse(Console.ReadLine());
            int cabbageArea = int.Parse(Console.ReadLine());
            int beenSeeds = int.Parse(Console.ReadLine());;
            int beenArea = totalArea - tomatoArea - cucumberArea - potatoArea - carrotArea - cabbageArea;

            decimal tomatoCost = tomatoSeeds * 0.5m;
            decimal cucumberCost = cucumberSeeds * 0.4m;
            decimal potatoCost = potatoSeeds * 0.25m;
            decimal carrotCost = carrotSeeds * 0.6m;
            decimal cabbageCost = cabbageSeeds * 0.3m;
            decimal beenCost = beenSeeds * 0.4m;
            decimal totalCost = tomatoCost + cucumberCost + potatoCost + carrotCost + cabbageCost + beenCost;

            Console.WriteLine("Total costs: {0:0.00}", totalCost);
            if (beenArea > 0)
            {
                Console.WriteLine("Beans area: {0}", beenArea);
            }
            if (beenArea < 0)
            {
                Console.WriteLine("Insufficient area");
            }
            if (beenArea == 0)
            {
                Console.WriteLine("No area for beans");
            }
        }
    }
}
