namespace _01.FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Node : IComparable<Node>
    {
        public Node(int name)
        {
            this.Name = name;
        }

        public int Name { get; set; }

        public long DjikstraDistance { get; set; }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Node;
            if (other == null)
            {
                return false;
            }

            return this.Name.Equals(other.Name);
        }

        public int CompareTo(Node other)
        {
            if (this.DjikstraDistance.CompareTo(other.DjikstraDistance) == 0)
            {
                return this.Name.CompareTo(other.Name);
            }
            return this.DjikstraDistance.CompareTo(other.DjikstraDistance);
        }
    }
}
