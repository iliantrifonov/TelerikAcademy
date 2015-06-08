namespace _01.School
{
    using System;

    public class Student : Person, ICommentable
    {
        private int classNumber;

        public Student(string fullName, int classNumber)
            : base(fullName)
        {
            this.ClassNumber = classNumber;
        }

        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The student number is invalid");
                }
                this.classNumber = value;
            }
        }

        public string Comment { get; set; }
    }
}