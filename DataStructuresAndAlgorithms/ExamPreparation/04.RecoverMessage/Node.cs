namespace _04.RecoverMessage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Node :IComparable<Node>
    {
        public Node(char symbol)
        {
            this.Symbol = symbol;
            this.Parents = new HashSet<Node>();
            this.Children = new HashSet<Node>();
        }

        public char Symbol { get; set; }

        public HashSet<Node> Parents { get; set; }

        public HashSet<Node> Children { get; set; }

        public int CompareTo(Node other)
        {
            return this.Symbol.CompareTo(other.Symbol);
        }

        public override bool Equals(object obj)
        {
           var other = obj as Node;
           return this.Symbol.Equals(other.Symbol);
        }

        public override int GetHashCode()
        {
            return this.Symbol.GetHashCode();
        }
    }
}
