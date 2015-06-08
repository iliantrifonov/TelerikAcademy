namespace _04.ClassPerson
{
    using System;

    //Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value. Override ToString() to display the information of a person and if age is not specified – to say so. Write a program to test this functionality

    public class Person
    {
        private int? age;
        private string name;

        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person(string name)
            : this(name, null)
        {
        }

        public int? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value > 140)
                {
                    throw new ArgumentException("The age is not valid, use values under 140");
                }
                this.age = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 2 || value.Length > 30)
                {
                    throw new ArgumentException("The name is not valid");
                }
                this.name = value;
            }
        }

        public override string ToString()
        {
            if (this.Age == null)
            {
                return String.Format("Name: {0}, the age is not specified", this.Name);
            }
            return String.Format("Name: {0}, Age: {1}", this.Name, this.Age);
        }
    }
}