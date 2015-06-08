using System;

namespace PersonClass
{
    public class Run
    {
        public static void Main()
        {
            var person = new Person("Ivancho", 10, Sex.Male);
            Console.WriteLine(person.Name);
        }
    }
}