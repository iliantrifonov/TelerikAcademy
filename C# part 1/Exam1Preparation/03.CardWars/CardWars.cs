using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _03.CardWars
{
    class CardWars
    {
        static void Main(string[] args)
        {
            int numberOfHands = int.Parse(Console.ReadLine());
            BigInteger overallScore1 = 0;
            BigInteger overallScore2 = 0;
            int countWins1 = 0;
            int countWins2 = 0;
            bool drawX1 = false;
            bool drawX2 = false;
            for (int i = 0; i < numberOfHands; i++)
            {
                drawX1 = false;
                drawX2 = false;
                int handSum1 = 0;
                int handSum2 = 0;
                for (int i2 = 0; i2 < 2; i2++)
                {
                    for (int i3 = 0; i3 < 3; i3++)
                    {
                        string card = Console.ReadLine();
                        if (i2 == 0)
                        {
                            switch (card)
                            {
                                case "2":
                                    handSum1 += 10;
                                    break;
                                case "3":
                                    handSum1 += 9;
                                    break;
                                case "4":
                                    handSum1 += 8;
                                    break;
                                case "5":
                                    handSum1 += 7;
                                    break;
                                case "6":
                                    handSum1 += 6;
                                    break;
                                case "7":
                                    handSum1 += 5;
                                    break;
                                case "8":
                                    handSum1 += 4;
                                    break;
                                case "9":
                                    handSum1 += 3;
                                    break;
                                case "10":
                                    handSum1 += 2;
                                    break;
                                case "A":
                                    handSum1 += 1;
                                    break;
                                case "J":
                                    handSum1 += 11;
                                    break;
                                case "Q":
                                    handSum1 += 12;
                                    break;
                                case "K":
                                    handSum1 += 13;
                                    break;
                                case "Z":
                                    overallScore1 *= 2;
                                    break;
                                case "Y":
                                    overallScore1 -= 200;
                                    break;
                                case "X":
                                    drawX1 = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (i2 == 1)
                        {
                            switch (card)
                            {
                                case "2":
                                    handSum2 += 10;
                                    break;
                                case "3":
                                    handSum2 += 9;
                                    break;
                                case "4":
                                    handSum2 += 8;
                                    break;
                                case "5":
                                    handSum2 += 7;
                                    break;
                                case "6":
                                    handSum2 += 6;
                                    break;
                                case "7":
                                    handSum2 += 5;
                                    break;
                                case "8":
                                    handSum2 += 4;
                                    break;
                                case "9":
                                    handSum2 += 3;
                                    break;
                                case "10":
                                    handSum2 += 2;
                                    break;
                                case "A":
                                    handSum2 += 1;
                                    break;
                                case "J":
                                    handSum2 += 11;
                                    break;
                                case "Q":
                                    handSum2 += 12;
                                    break;
                                case "K":
                                    handSum2 += 13;
                                    break;
                                case "Z":
                                    overallScore2 *= 2;
                                    break;
                                case "Y":
                                    overallScore2 -= 200;
                                    break;
                                case "X":
                                    drawX2 = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                if (drawX1 && drawX2)
                {
                    overallScore1 += 50;
                    overallScore2 += 50;
                }
                else if (drawX1 && !drawX2)
                {
                    break;
                }
                else if (drawX2 && !drawX1)
                {
                    break;
                }
                if (handSum1 > handSum2)
                {
                    overallScore1 += handSum1;
                    countWins1++;
                }
                if (handSum2 > handSum1)
                {
                    overallScore2 += handSum2;
                    countWins2++;
                }
                drawX1 = false;
                drawX2 = false;
            }
            if (drawX1)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
            }
            else if (drawX2)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
            }
            else if (overallScore1 > overallScore2)
            {
                Console.WriteLine("First player wins!");
                Console.WriteLine("Score: {0}", overallScore1);
                Console.WriteLine("Games won: {0}", countWins1);
            }
            else if (overallScore1 < overallScore2)
            {
                Console.WriteLine("Second player wins!");
                Console.WriteLine("Score: {0}", overallScore2);
                Console.WriteLine("Games won: {0}", countWins2);
            }
            else
            {
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Score: {0}", overallScore1);
            }
        }
    }
}
