using System;

namespace _05.SortStringsByLenght
{
    class SortStringsByLenght
    {
        static void Main(string[] args)
        {
            //You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).
            string[] arrOfStrings= {"absdsa", "abbbs", "a", "aaa", "AA"};
            SortByLenght(arrOfStrings);
            foreach (var item in arrOfStrings)
            {
                Console.Write(item + " ");
            }
        }

        private static void SortByLenght(string[] array)//using selection sort
        {
            string[] resultArray = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int minNumber = int.MaxValue;
                int elementIndex = 0;
                for (int k = 0; k < array.Length; k++)
                {
                    if (array[k] == null)
                    {
                        continue;
                    }
                    if (array[k].Length < minNumber)
                    {
                        elementIndex = k;
                        minNumber = array[k].Length;
                    }
                }
                resultArray[i] = array[elementIndex];
                array[elementIndex] = null;
            }
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = resultArray[i];
            }
        }
    }
}
