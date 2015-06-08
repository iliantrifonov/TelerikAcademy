namespace _04.ClassPerson
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Person someGuy = new Person("Ivancho");
            Person someOtherGuy = new Person("Peshkata", 28);
            Console.WriteLine(someGuy);
            Console.WriteLine(someOtherGuy);
        }
    }
}