namespace _01.StudentInformation
{
    using System;
    using System.Linq;

    using System;
    public class Student : IComparable
    {
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string Course { get; set; }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }

                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(
                        );
                }

                this.lastName = value;
            }
        }
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Student other = obj as Student;

            if (other != null)
            {
                if (this.LastName.CompareTo(other.LastName) == 0)
                {
                    return this.FirstName.CompareTo(other.FirstName);
                }
                else
                {
                    return this.LastName.CompareTo(other.LastName);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public override string ToString()
        {
            return this.firstName + " " + this.lastName;
        }
    }
}
