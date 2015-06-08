namespace _01.StudentInformation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// A text file students.txt holds information about students and their courses.
    /// Using SortedDictionary<K,T> print the courses in alphabetical order and for each of them prints the students ordered by family and then by name.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var peopleByCourse = new SortedDictionary<string, List<Student>>();
            string path = "../../students.txt";
            ParseInput(path, peopleByCourse);

            foreach (var course in peopleByCourse.Keys)
            {
                var sortedPeople = peopleByCourse[course];
                sortedPeople.Sort();
                Console.Write(course + ": ");
                Console.WriteLine(string.Join(", ", sortedPeople));
            }
        }

        private static void ParseInput(string filename, SortedDictionary<string, List<Student>> studentsByCourse)
        {
            using (var sr = new StreamReader(filename))
            {
                string line;
                char[] delims = { '|', ' ' };

                do
                {
                    line = sr.ReadLine();
                    string[] parameters = line.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                    Student person = new Student(parameters[0], parameters[1]);
                    if (studentsByCourse.ContainsKey(parameters[2]))
                    {
                        List<Student> personList = studentsByCourse[parameters[2]];
                        personList.Add(person);
                    }
                    else
                    {
                        List<Student> personList = new List<Student>();
                        personList.Add(person);
                        studentsByCourse.Add(parameters[2], personList);
                    }
                }
                while (!sr.EndOfStream);
            }
        }
    }
}
