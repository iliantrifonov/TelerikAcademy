namespace _02.ExtendIEnum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    //2.Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.
    public static class ExtensionClass
    {
        public static T Avarage<T>(this IEnumerable<T> collection)
        {
            dynamic sum = 0;
            dynamic counter = 0;
            foreach (var item in collection)
            {
                sum += item;
                counter++;
            }
            return sum / counter;
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            T currentMax = collection.First();
            foreach (var item in collection)
            {
                if (currentMax.CompareTo(item) < 0)
                {
                    currentMax = item;
                }
            }
            return currentMax;
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            T currentMin = collection.First();
            foreach (var item in collection)
            {
                if (currentMin.CompareTo(item) > 0)
                {
                    currentMin = item;
                }
            }
            return currentMin;
        }

        public static T Product<T>(this IEnumerable<T> collection)
        {
            dynamic product = 1;
            foreach (var item in collection)
            {
                product *= item;
                if (product == 0)
                {
                    break;
                }
            }
            return product;
        }

        public static T Sum<T>(this IEnumerable<T> collection)
        {
            dynamic sum = 0;
            foreach (var item in collection)
            {
                sum += item;
            }
            return sum;
        }
    }
}