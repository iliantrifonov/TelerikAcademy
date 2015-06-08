namespace _11.ImplimentLinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LinkedList<T>
    {
        ListItem<T> firstItem;

        public LinkedList(T value)
        {
            firstItem = new ListItem<T>();
            FirstItem.Value = value;
        }

        public ListItem<T> FirstItem
        {
            get
            {
                return this.firstItem;
            }
        }
    }
}
