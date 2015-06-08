namespace _03.TreesAndTraversals
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Node<T>
    {
        private IList<Node<T>> children;

        public Node(T value)
        {
            this.Value = value;
            this.children = new List<Node<T>>();
        }

        public T Value { get; set; }

        public bool HasParent { get; set; }

        public IList<Node<T>> Children
        {
            get
            {
                return new ReadOnlyCollection<Node<T>>(this.children);
            }
        }

        public void AddChild(Node<T> child)
        {
            child.HasParent = true;
            this.children.Add(child);
        }

        public Node<T> GetNode(int index)
        {
            return this.children[index];
        }
    }
}
