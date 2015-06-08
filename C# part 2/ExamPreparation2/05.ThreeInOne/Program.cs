using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ThreeInOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BlackJack(Console.ReadLine()));
            string cake = Console.ReadLine();
            int friends = int.Parse(Console.ReadLine());
            Console.WriteLine(CakeBites(cake,friends));
            Console.WriteLine(TimesToTransferGold( Console.ReadLine()));
        }

        public static int CakeBites(string a, int friends)
        {
            string[] nums = a.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] cakes = new int[nums.Length];
            for (int i = 0; i < cakes.Length; i++)
            {
                cakes[i] = int.Parse(nums[i]);
            }
            Array.Sort(cakes);
            friends++;
            int amountOfCake = 0;
            int index = cakes.Length - 1;
            while (index >= 0)
            {
                amountOfCake += cakes[index];
                index -= friends;
            }
            return amountOfCake;

        }

        public static int BlackJack(string a)
        {
            string[] nums = a.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] scores = new int[nums.Length];
            bool foundTwentyOne = false;
            for (int i = 0; i < nums.Length; i++)
            {
                int currentScore = int.Parse(nums[i]);
                if (currentScore > 21)
	            {
                    scores[i] = 0;
	            }
                else
                {
                    scores[i] = currentScore;
                }
                if (currentScore == 21 && foundTwentyOne)
                {
                    return -1;
                }
                else if (currentScore == 21)
                {
                    foundTwentyOne = true;
                }
            }
            int maxScore = 0;
            int index = -1;
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] > maxScore)
                {
                    maxScore = scores[i];
                    index = i;
                }
            }
            bool maxFound = false;
            for (int i = 0; i < scores.Length; i++)
            {
                if (maxFound && scores[i] == maxScore)
                {
                    return -1;
                }
                else if (scores[i] == maxScore)
                {
                    maxFound = true;
                }
            }
            return index;
        }

        public static int TimesToTransferGold(string a)
        {
            string[] nums = a.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] moneyPossesed = new int[3];
            int[] neededMoney = new int[3];
            for (int i = 0; i < 3; i++)
            {
                moneyPossesed[i] = int.Parse(nums[i]);
            }
            int index = 3;
            for (int i = 0; i < 3; i++, index++)
            {
                neededMoney[i] = int.Parse(nums[index]);
            }

            long sumOfPossesed = 0;
            for (int i = 0; i < moneyPossesed.Length; i++)
            {
                if (i != moneyPossesed.Length - 1)
                {
                    sumOfPossesed += moneyPossesed[i] * (long)Math.Pow(9, 2 - i);
                }
                else
                {
                    sumOfPossesed += moneyPossesed[i];
                }
            }
            long sumOfNeeded = 0;
            for (int i = 0; i < moneyPossesed.Length; i++)
            {
                if (i != moneyPossesed.Length - 1)
                {
                    sumOfNeeded += neededMoney[i] * (2 - i);
                }
                else
                {
                    sumOfNeeded += neededMoney[i];
                }
            }
            if (sumOfNeeded > sumOfPossesed)
            {
                return -1;
            }
            if (IsEnoughOfEach(moneyPossesed, neededMoney))
            {
                return 0;
            }
            int numberOfOperations = 0;
            int goldExtra = 0;
            int silverExtra = 0;
            int copperExtra = 0;
            int goldToSilver = 0;
            int silverToCopper = 0;
            goldExtra = moneyPossesed[0] - neededMoney[0];
            silverExtra = moneyPossesed[1] - neededMoney[1];
            copperExtra = moneyPossesed[2] - neededMoney[2];
            if (copperExtra < 0)
            {
                silverToCopper = Math.Abs(copperExtra) / 9;
                if (Math.Abs(copperExtra) % 9 != 0)
                {
                    silverToCopper++;
                }
                silverExtra -= silverToCopper;
                copperExtra += silverToCopper * 9;
                numberOfOperations += silverToCopper;
            }
            if (silverExtra < 0)
            {
                goldToSilver = Math.Abs(silverExtra) / 9;
                if (Math.Abs(silverExtra) % 9 != 0)
                {
                    goldToSilver++;
                }
                goldExtra -= goldToSilver;
                silverExtra += goldToSilver * 9;
                numberOfOperations += goldToSilver;
            }
            if (goldExtra >= 0 && silverExtra >= 0 && copperExtra >= 0)
            {
                return numberOfOperations;
            }
            numberOfOperations = 0;
            int silverToGold = 0;
            int copperToSilver = 0;
            goldExtra = moneyPossesed[0] - neededMoney[0];
            silverExtra = moneyPossesed[1] - neededMoney[1];
            copperExtra = moneyPossesed[2] - neededMoney[2];
            if (goldExtra < 0)
            {
                silverToGold = Math.Abs(goldExtra) * 11;
                silverExtra -= silverToGold;
                numberOfOperations += Math.Abs(goldExtra);
            }
            if (silverExtra < 0)
            {
                copperToSilver = Math.Abs(silverExtra) * 11;
                copperExtra -= copperToSilver;
                numberOfOperations += Math.Abs(silverExtra);
            }
            if (copperExtra < 0)
            {
                silverToCopper = Math.Abs(copperExtra) / 9;
                if (Math.Abs(copperExtra) % 9 != 0)
                {
                    silverToCopper++;
                }
                silverExtra -= silverToCopper;
                numberOfOperations += silverToCopper;
            }

            return numberOfOperations;
        }

        private static bool IsEnoughOfEach(int[] possesed, int[] needed)
        {
            for (int i = 0; i < possesed.Length; i++)
            {
                if (possesed[i] < needed[i])
	            {
                    return false;
	            }
            }
            return true;
        }
    }
}
