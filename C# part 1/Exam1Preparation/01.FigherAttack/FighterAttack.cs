using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.FigherAttack
{
    class FighterAttack
    {
        static void Main(string[] args)
        {
            int plantX1orig = int.Parse(Console.ReadLine());
            int plantY1orig = int.Parse(Console.ReadLine());
            int plantX2orig = int.Parse(Console.ReadLine());
            int plantY2orig = int.Parse(Console.ReadLine());

            if (plantX1orig > plantX2orig)
            {
                int temp = plantX1orig;
                plantX1orig = plantX2orig;
                plantX2orig = temp;
            }
            if (plantY1orig > plantY2orig)
            {
                int temp = plantY1orig;
                plantY1orig = plantY2orig;
                plantY2orig = temp;
            }

            int fX = int.Parse(Console.ReadLine());
            int fy = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());

            int hit100 = fX + distance;
            int score = 0;

            if (hit100 >= plantX1orig && hit100 <= plantX2orig)
            {
                if (fy >= plantY1orig && fy <= plantY2orig)
                {
                    score += 100;
                }
            }
            if (hit100 + 1 >= plantX1orig && hit100 + 1 <= plantX2orig)
            {
                if (fy >= plantY1orig && fy <= plantY2orig)
                {
                    score += 75;
                }
            }
            if (hit100 >= plantX1orig && hit100 <= plantX2orig)
            {
                if (fy + 1>= plantY1orig && fy + 1<= plantY2orig)
                {
                    score += 50;
                }
            }
            if (hit100 >= plantX1orig && hit100 <= plantX2orig)
            {
                if (fy - 1 >= plantY1orig && fy - 1 <= plantY2orig)
                {
                    score += 50;
                }
            }
            Console.WriteLine("{0}%", score);
        }
    }
}
