namespace _11.ImplimentLinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Implement the data structure linked list. Define a class ListItem<T> that has two fields: value (of type T) and NextItem (of type ListItem<T>). Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>(0);
            ListItem<int> listItem = list.FirstItem;
            ListItem<int> nextItem;

            for (int i = 1; i < 11; i++)
            {
                nextItem = new ListItem<int>(i);
                listItem.NextItem = nextItem;
                listItem = nextItem;
            }

            nextItem = list.FirstItem;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(nextItem.Value);
                nextItem = nextItem.NextItem;
            }
        }
    }
}
