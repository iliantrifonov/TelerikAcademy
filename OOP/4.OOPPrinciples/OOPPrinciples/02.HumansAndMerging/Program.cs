namespace _02.HumansAndMerging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    //Define abstract class Human with first name and last name. Define new class Student which is derived from Human and has new field – grade. Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay and method MoneyPerHour() that returns money earned by hour by the worker. Define the proper constructors and properties for this hierarchy. Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method). Initialize a list of 10 workers and sort them by money per hour in descending order. Merge the lists and sort them by first name and last name.

    public class Program
    {
        public static void Main(string[] args)
        {
            var students = new List<Student>();
            students.Add(new Student("Vasil", "Ivankov", 6));
            students.Add(new Student("Ivan", "Ivankov", 2));
            students.Add(new Student("Ivan", "Vasilev", 3));
            students.Add(new Student("Hristo", "Ivankov", 4));
            students.Add(new Student("Ivan", "Minkov", 6));
            students.Add(new Student("Milka", "Ivankov", 6));
            students.Add(new Student("Ivan", "Milkov", 4));
            students.Add(new Student("Doncho", "Ivankov", 5));
            students.Add(new Student("Ivan", "Donev", 6));
            students.Add(new Student("Anastasiq", "Ivankova", 5));
            var studentsOrdered = students.OrderBy(x => x.Grade);
            var workers = new List<Worker>();
            workers.Add(new Worker("Vasil", "Petrov", 220.85m, 8m));
            workers.Add(new Worker("Ivan", "Petrov", 130.85m, 8m));
            workers.Add(new Worker("Petur", "Petrov", 160.85m, 8m));
            workers.Add(new Worker("Petur", "Trifonov", 124.85m, 8m));
            workers.Add(new Worker("Petur", "Ninov", 120.85m, 8m));
            workers.Add(new Worker("Desi", "Ivanova", 420.85m, 8m));
            workers.Add(new Worker("Ilko", "Petrov", 422.85m, 8m));
            workers.Add(new Worker("Petur", "Lazarov", 130.85m, 8m));
            workers.Add(new Worker("Samuil", "Petrov", 320.85m, 8m));
            workers.Add(new Worker("Petur", "Samuilov", 150.85m, 8m));
            var sortedStudents = students.OrderBy(x => x.Grade).ToList();
            var sortedWorkers = workers.OrderByDescending(x => x.MoneyPerHour()).ToList();
            System.Console.WriteLine("Sorted students by grade:");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
            Console.WriteLine("Sorted workers by money per hour:");
            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine(worker);
            }
            Console.WriteLine();
            Console.WriteLine("Merged and sorted by first then last name");
            var merged = sortedWorkers.Concat<Human>(sortedStudents);
            var sortMerged = merged.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
            foreach (var human in sortMerged)
            {
                Console.WriteLine(human);
            }
        }
    }
}