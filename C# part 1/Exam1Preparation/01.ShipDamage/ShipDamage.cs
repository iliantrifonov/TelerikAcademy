using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ShipDamage
{
    class ShipDamage
    {
        static void Main(string[] args)
        {
            int shipX1orig = int.Parse(Console.ReadLine());
            int sY1orig = int.Parse(Console.ReadLine());
            int shipX2orig = int.Parse(Console.ReadLine());
            int sY2orig = int.Parse(Console.ReadLine());
            int horizon = int.Parse(Console.ReadLine());
            int cX1orig = int.Parse(Console.ReadLine());
            int cY1orig = int.Parse(Console.ReadLine());
            int cX2orig = int.Parse(Console.ReadLine());
            int cY2orig = int.Parse(Console.ReadLine());
            int cX3orig = int.Parse(Console.ReadLine());
            int cY3orig = int.Parse(Console.ReadLine());

            int score = 0;

            int shipY1= sY1orig - horizon;
            int shipY2 = sY2orig - horizon;
            int cY1 = (cY1orig - horizon) * (-1);
            int cY2 = (cY2orig - horizon) * (-1);
            int cY3 = (cY3orig - horizon) * (-1);

            if (shipX1orig > shipX2orig)
            {
                int temp = shipX1orig;
                shipX1orig = shipX2orig;
                shipX2orig = temp;
            }
            if (shipY1 > shipY2)
            {
                int temp = shipY1;
                shipY1 = shipY2;
                shipY2 = temp;
            }
             //for C1
            if (cX1orig == shipX1orig || cX1orig == shipX2orig)
            {
                if (cY1 > shipY1 && cY1 < shipY2)
                {
                    score +=50;
                }
                else if (cY1 == shipY1 || cY1 == shipY2)
                {
                    score +=25;
                }
            }
            else if (cY1 == shipY1 || cY1 == shipY2)
            {
                if (cX1orig > shipX1orig && cX1orig < shipX2orig)
                {
                    score +=50;
                }
            }
            else if (cX1orig > shipX1orig && cX1orig < shipX2orig)
            {
                if (cY1 > shipY1 && cY1 < shipY2)
                {
                    score += 100;
                }
            }
            // for C2
            if (cX2orig == shipX1orig || cX2orig == shipX2orig)
            {
                if (cY2 > shipY1 && cY2 < shipY2)
                {
                    score += 50;
                }
                else if (cY2 == shipY1 || cY2 == shipY2)
                {
                    score += 25;
                }
            }
            else if (cY2 == shipY1 || cY2 == shipY2)
            {
                if (cX2orig > shipX1orig && cX2orig < shipX2orig)
                {
                    score += 50;
                }
            }
            else if (cX2orig > shipX1orig && cX2orig < shipX2orig)
            {
                if (cY2 > shipY1 && cY2 < shipY2)
                {
                    score += 100;
                }
            }
            // for C3
            if (cX3orig == shipX1orig || cX3orig == shipX2orig)
            {
                if (cY3 > shipY1 && cY3 < shipY2)
                {
                    score += 50;
                }
                else if (cY3 == shipY1 || cY3 == shipY2)
                {
                    score += 25;
                }
            }
            else if (cY3 == shipY1 || cY3 == shipY2)
            {
                if (cX3orig > shipX1orig && cX3orig < shipX2orig)
                {
                    score += 50;
                }
            }
            else if (cX3orig > shipX1orig && cX3orig < shipX2orig)
            {
                if (cY3 > shipY1 && cY3 < shipY2)
                {
                    score += 100;
                }
            }
            Console.WriteLine("{0}%", score);
        }
    }
}
