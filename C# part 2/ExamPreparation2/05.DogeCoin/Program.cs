using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.DogeCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] sizeOfArr = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int numberOfCoins = int.Parse(Console.ReadLine());
            List<Coords> listOfCoords = new List<Coords>();
            for (int i = 0; i < numberOfCoins; i++)
            {
                input = Console.ReadLine();
                string[] coinCoords = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                listOfCoords.Add(new Coords(int.Parse(coinCoords[1]), int.Parse(coinCoords[0])));
            }
            int maxCount = 0;
            var sorted = listOfCoords.OrderBy( p => p.x).ThenBy(p => p.y);
            List<Coords> betterList = sorted.ToList<Coords>();

            for (int i = betterList.Count - 1; i >= 0; i--)
            {
                int placeholderI = i;
                int currentCount = 0;
                for (int k = betterList.Count - 1; k>= 0; k--)
                {
                    if (listOfCoords[i].x <= listOfCoords[k].x && listOfCoords[i].y <= listOfCoords[k].y)
                    {
                        currentCount++;
                    }
                    i = k;
                }
                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                }
                currentCount = 0;
                i = placeholderI;
            }
            Console.WriteLine(maxCount);
        }

        
    }

    public class Coords
    {
        public int x;
        public int y;
        public Coords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
