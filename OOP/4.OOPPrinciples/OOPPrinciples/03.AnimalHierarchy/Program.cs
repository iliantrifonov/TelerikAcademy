namespace _03.AnimalHierarchy
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var dogs = new Dog[] { new Dog("Sharo", 3, "male"), new Dog("Rex", 5, "male") };
            var frogs = new Frog[] { new Frog("Forggier", 2, "Male"), new Frog("Icefrog", 12, "male") };
            var cats = new Cat[] { new Cat("Mialcho", 1, "Male"), new Cat("Smurtfka", 4, "female") };
            var kittens = new Kitten[] { new Kitten("Kotence", 4), new Kitten("Macko", 7) };
            var tomcats = new Tomcat[] { new Tomcat("Dangerous", 7), new Tomcat("Noshten prilep", 15) };

            var collectionOfAnimals = new List<Animal[]>();
            collectionOfAnimals.Add(dogs);
            collectionOfAnimals.Add(frogs);
            collectionOfAnimals.Add(cats);
            collectionOfAnimals.Add(kittens);
            collectionOfAnimals.Add(tomcats);
            foreach (var animals in collectionOfAnimals)
            {
                Console.WriteLine("The avarage age of {0} is {1}", animals.GetType(), Animal.AvarageAge(animals));
            }
        }
    }
}