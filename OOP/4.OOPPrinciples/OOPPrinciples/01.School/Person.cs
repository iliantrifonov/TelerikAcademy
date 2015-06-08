namespace _01.School
{
    using System;

    public abstract class Person
    {
        private string fullName;

        public Person(string FullName)
        {
            this.FullName = FullName;
        }

        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException(string.Format("The lenght of the name {0} is too short", value));
                }
                this.fullName = value;
            }
        }
    }
}