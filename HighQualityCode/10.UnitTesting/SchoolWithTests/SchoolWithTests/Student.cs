namespace School
{
    using System;

    public class Student
    {
        private int studentNumber;
        private string name;

        public Student(string name, int studentNumber)
        {
            this.Name = name;
            this.StudentNumber = studentNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name can not be empty or null");
                }

                this.name = value;
            }
        }

        public int StudentNumber
        {
            get
            {
                return this.studentNumber;
            }

            set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentException("StudentNumber must be between between 10000 and 99999");
                }

                this.studentNumber = value;
            }
        }
    }
}