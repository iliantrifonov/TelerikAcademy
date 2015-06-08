namespace _05.To07.ListImplimentation
{
    using System;
    public class TestLists
    {
        public static void Main(string[] args)
        {
            GenericList<int> numList = new GenericList<int>();
            for (int i = 0; i < 140; i++)
            {
                numList.Add(i);
            }
            Console.WriteLine("The item at position 3 is {0}", numList[3]);
            numList.InsertAt(0, -1);
            numList.RemoveAt(0);
            int max = numList.Max();
            int min = numList.Min();
            Console.WriteLine("Max is {0}, min is {1}", max, min);
            int index = numList.FindElement(22);
            Console.WriteLine("Element 22 is at position {0}", index);
            Console.WriteLine(numList.ToString());
            numList.Clear();
            Console.WriteLine(numList.ToString());
        }
    }
}
