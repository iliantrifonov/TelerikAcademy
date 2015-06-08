namespace _01.FriendsOfPesho
{
    using System;

    public class Connection : IComparable
    {
        public Connection(Node from, Node to, long distance)
        {
            this.From = from;
            this.To = to;
            this.Distance = distance;
        }

        public Node From { get; set; }

        public Node To { get; set; }

        public long Distance { get; set; }

        public int CompareTo(object obj)
        {
            var other = obj as Connection;

            return this.Distance.CompareTo(other.Distance);
        }
    }
}
