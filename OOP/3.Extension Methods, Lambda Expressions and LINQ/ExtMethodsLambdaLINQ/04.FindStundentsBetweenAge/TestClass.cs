namespace _04.FindStundentsBetweenAge
{
    using _03.FirstBeforeLast;
    using System;
    using System.Linq;

    public class TestClass
    {
        //4.Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
        //5.Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order. Rewrite the same with LINQ.
        public static void Main(string[] args)
        {
            Student[] arrOfStundents = new Student[7];
            arrOfStundents[0] = new Student("Ivan", "Andonov", 19);
            arrOfStundents[1] = new Student("Andon", "Zafirov", 24);
            arrOfStundents[2] = new Student("Andon", "Bonev", 18);
            arrOfStundents[3] = new Student("Andon", "Petrov", 24);
            arrOfStundents[4] = new Student("Andon", "Andonov", 18);
            arrOfStundents[5] = new Student("Kaloqn", "Andonov", 25);
            arrOfStundents[6] = new Student("Boris", "Zafirov", 7);
            //4.
            Console.WriteLine("Selected between 18-24");
            var result =
                from st in arrOfStundents
                where st.Age >= 18 && st.Age <= 24
                select st;
            foreach (var student in result)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            //5.
            var orderByLambda = arrOfStundents.OrderByDescending(st => st.FirstName).ThenByDescending(st => st.LastName);
            Console.WriteLine("Ordered by Lambda:");
            foreach (var student in orderByLambda)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            var orderByLINQ =
                from st in arrOfStundents
                orderby st.FirstName descending
                orderby st.LastName descending
                select st;
            Console.WriteLine("Ordered by LINQ:");
            foreach (var student in orderByLambda)
            {
                Console.WriteLine(student);
            }
        }
    }
}