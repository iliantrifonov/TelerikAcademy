using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.GreedyDwarf
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] arrayOfValley = ConvertStringToArrOfInt(input);
            int numberOfArrays = int.Parse(Console.ReadLine());
            List<int[]> listOfJumps = new List<int[]>();
            for (int i = 0; i < numberOfArrays; i++)
            {
                input = Console.ReadLine();
                listOfJumps.Add(ConvertStringToArrOfInt(input));
            }

            int maxNumberOfCoins = int.MinValue;

            int[] copyArr = new int[arrayOfValley.Length];
            
            for (int i = 0; i < numberOfArrays; i++)
            {
                for (int z = 0; z < arrayOfValley.Length; z++)
                {
                    copyArr[z] = arrayOfValley[z];
                }
                int currentCoins = 0;
                int index = 0;
                for (int k = 0; k < listOfJumps[i].Length; k++)
                {
                    if (index < 0 || index > copyArr.Length -1 || copyArr[index] == int.MinValue)
                    {
                        break;
                    }
                    currentCoins += copyArr[index];
                    copyArr[index] = int.MinValue;
                    index += listOfJumps[i][k];
                    if (k == listOfJumps[i].Length - 1)
                    {
                        k = -1;
                    }
                }
                if (currentCoins > maxNumberOfCoins)
                {
                    maxNumberOfCoins = currentCoins;
                }
            }
            Console.WriteLine(maxNumberOfCoins);
        }

        private static int[] ConvertStringToArrOfInt(string numbersString) 
        {
            string[] arrayToWalkOnAsString = numbersString.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] arrayToWalkOnInt = new int[arrayToWalkOnAsString.Length];
            for (int i = 0; i < arrayToWalkOnAsString.Length; i++)
            {
                arrayToWalkOnInt[i] = int.Parse(arrayToWalkOnAsString[i]);
            }
            return arrayToWalkOnInt;
        }
    }
}
