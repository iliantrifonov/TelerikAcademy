namespace _03.AnimalHierarchy
{
    using System;
    using System.Collections.Generic;

    public abstract class Animal : ISound
    {
        private int age;
        private string sex;

        public Animal(string name, int age, string sex)
        {
            this.Age = age;
            this.Sex = sex;
            this.Name = name;
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age must be a positive number");
                }
                this.age = value;
            }
        }

        public string Name { get; set; }

        public string Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                if (value.ToLowerInvariant() != "male" && value.ToLowerInvariant() != "female")
                {
                    throw new ArgumentException("The sex of the animal can only be male or female");
                }
                this.sex = value;
            }
        }

        public static double AvarageAge(IEnumerable<Animal> animals)
        {
            int sum = 0;
            int count = 0;
            foreach (var animal in animals)
            {
                count++;
                sum += animal.Age;
            }
            return sum / count;
        }

        public virtual string MakeSound()
        {
            return "Not implimented sound";
        }
    }
}