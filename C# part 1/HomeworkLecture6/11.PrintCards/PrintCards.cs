﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PrintCards
{
    class PrintCards
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    switch (j)
                    {
                        case 1:
                            Console.Write("Ace of");
                            break;
                        case 2:
                            Console.Write("Two of");
                            break;
                        case 3:
                            Console.Write("Three of");
                            break;
                        case 4:
                            Console.Write("Four of");
                            break;
                        case 5:
                            Console.Write("Five of");
                            break;
                        case 6:
                            Console.Write("Six of");
                            break;
                        case 7:
                            Console.Write("Seven of");
                            break;
                        case 8:
                            Console.Write("Eight of");
                            break;
                        case 9:
                            Console.Write("Nine of");
                            break;
                        case 10:
                            Console.Write("Ten of");
                            break;
                        case 11:
                            Console.Write("Jack of");
                            break;
                        case 12:
                            Console.Write("Queen of");
                            break;
                        case 13:
                            Console.Write("King of");
                            break;
                        default:
                            Console.WriteLine(" ");
                            break;

                    }
                    switch (i)
                    {
                        case 1:
                            Console.WriteLine(" Spades");
                            break;
                        case 2:
                            Console.WriteLine(" Diamonds");
                            break;
                        case 3:
                            Console.WriteLine(" Hearts");
                            break;
                        case 4:
                            Console.WriteLine(" Clubs");
                            break;

                        default:
                            Console.WriteLine(" ");
                            break;
                    }
                }
            }
        }
    }
}
