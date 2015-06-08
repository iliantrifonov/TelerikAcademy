namespace _01.Frames
{
    using System;

    public class Frame : IComparable<Frame>
    {
        public Frame(int first, int second)
        {
            this.First = first;
            this.Second = second;
        }

        public Frame(string firstAndSecond)
        {
            var split = firstAndSecond.Split(new[] { '(', ')', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            this.First = int.Parse(split[0]);
            this.Second = int.Parse(split[1]);
        }

        public int First { get; set; }

        public int Second { get; set; }

        public override bool Equals(object obj)
        {
            var otherObj = obj as Frame;

            if (otherObj == null)
            {
                return false;
            }

            if (this.First == otherObj.First && this.Second == otherObj.Second)
            {
                return true;
            }

            return false;
        }

        public int CompareTo(Frame other)
        {
            if (this.First == other.First)
            {
                if (this.Second == other.Second)
                {
                    return 0;
                }
                else if (this.Second > other.Second)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else if (this.First > other.First)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.First, this.Second);
        }

        public void SwapFirstAndSecond()
        {
            if (this.First == this.Second)
            {
                return;
            }

            int temp = this.First;
            this.First = this.Second;
            this.Second = temp;
        }
    }
}