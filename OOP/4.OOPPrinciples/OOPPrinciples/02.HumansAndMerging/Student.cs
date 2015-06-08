namespace _02.HumansAndMerging
{
    using System;

    public class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if (value <= 1)
                {
                    throw new ArgumentException("The grade cannot be lower than 2");
                }
                this.grade = value;
            }
        }

        public override string ToString()
        {
            return "Sudent: " + base.FirstName + " " + base.LastName + " with grade: " + this.Grade;
        }
    }
}