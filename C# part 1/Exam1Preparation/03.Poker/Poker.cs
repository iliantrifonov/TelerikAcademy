using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Poker
{
    class Poker
    {
        static void Main(string[] args)
        {
            int[] cardArray = new int[5];
            for (int i = 0; i < cardArray.Length; i++)
            {
                string card = Console.ReadLine();
                switch (card)
                {
                    case "J":
                        cardArray[i] = 11;
                        break;
                    case "Q":
                        cardArray[i] = 12;
                        break;
                    case "K":
                        cardArray[i] = 13;
                        break;
                    case "A":
                        cardArray[i] = 1;
                        break;
                    default:
                        cardArray[i] = int.Parse(card);
                        break;
                }
            }
            Array.Sort(cardArray);
            bool foundOne = false;
            bool finishedFindingOne = false;
            int howManyFirstSame = 1;
            int secondHowManySame = 1;
            for (int i = 0; i < cardArray.Length; i++)
            {
                int firstCard = cardArray[i];
                int count = i + 1;
                while (count < cardArray.Length && firstCard == cardArray[count])
                {
                    foundOne = true;
                    if (finishedFindingOne)
                    {
                        secondHowManySame++;
                    }
                    else
                    {
                        howManyFirstSame++;
                    }
                    count++; 
                }
                if (foundOne)
                {
                    finishedFindingOne = true;
                }
                i = count - 1;
            }
            bool foundStraight = false;
            for (int i = 1; i < cardArray.Length; i++)
            {
                if (cardArray[i - 1] != cardArray[i] - 1)
                {
                    break;
                }
                if (i == 4)
                {
                    foundStraight = true;
                }
            }
            if (cardArray[0] == 1 && cardArray[1] == 10 && cardArray[2] == 11 && cardArray[3] == 12 && cardArray[4] == 13)
            {
                foundStraight = true;
            }

            if (foundStraight)
            {
                Console.WriteLine("Straight");
            }
            else if (foundOne)
            {
                if (howManyFirstSame == 2 && secondHowManySame == 2)
                {
                    Console.WriteLine("Two Pairs");
                }
                if ((howManyFirstSame == 2 && secondHowManySame == 3) || (howManyFirstSame == 3 && secondHowManySame == 2))
                {
                    Console.WriteLine("Full House");
                }
                if (secondHowManySame == 1)
                {
                    if (howManyFirstSame == 2)
                    {
                       Console.WriteLine("One Pair"); 
                    }
                    if (howManyFirstSame == 3)
                    {
                       Console.WriteLine("Three of a Kind"); 
                    }
                    if (howManyFirstSame == 4)
                    {
                        Console.WriteLine("Four of a Kind"); 
                    }
                    if (howManyFirstSame == 5)
                    {
                       Console.WriteLine("Impossible");  
                    }
                }
            }
            else
            {
                Console.WriteLine("Nothing");
            }
            

            //for (int i = 0; i < cardArray.Length; i++)
            //{
            //    Console.WriteLine(cardArray[i]);
            //}
        }
    }
}
