using System;

namespace PersonClass
{
    public class Person
    {
        public Sex Sex { get; private set; }

        private string name;

        private uint age;

        public Person(string name, uint age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
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
                    throw new ArgumentException("Invalid name");
                }

                this.name = value;
            }
        }

        public uint Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value > 150)
                {
                    throw new ArgumentException("Invalid age");
                }

                this.age = value;
            }
        }
    }
}