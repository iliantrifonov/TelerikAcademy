namespace _09To16.ClassStudentsLINQLambda
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    //9.Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber. Create a List<Student> with sample students. Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.
    //10.Implement the previous using the same query expressed with extension methods.
    //11.Extract all students that have email in abv.bg. Use string methods and LINQ
    //12.Extract all students with phones in Sofia. Use LINQ
    //13.Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.
    //14.Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods.
    //15.Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
    //16.* Create a class Group with properties GroupNumber and DepartmentName. Introduce a property Group in the Student class. Extract all students from "Mathematics" department. Use the Join operator.

    public class TestClass
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Ivan", "Ivanov", 111106, "0897222111", "ivancho@gmail.com", new List<int>() { 2, 3, 4, 6, 6 }, 1, new Group("123", "Mathematics")));
            students.Add(new Student("Petyr", "Petrov", 111205, "0897333111", "petrov@gmail.com", new List<int>() { 2, 2, 3, 3, 3 }, 2, new Group("222", "Textile?")));
            students.Add(new Student("Niki", "Nikitov", 111304, "02 988 88 88", "niki@abv.bg", new List<int>() { 5, 5, 4, 3, 3 }, 2, new Group("13323", "Software and technology")));
            students.Add(new Student("Eli", "Elhova", 111406, "0897344122", "eli@abv.bg", new List<int>() { 5, 5, 4, 4, 6 }, 3, new Group("111", "Engineering")));
            students.Add(new Student("Milka", "Milkova", 111506, "0897555122", "milcheto@gmail.com", new List<int>() { 6, 6, 6, 4, 6 }, 2, new Group("123", "Mathematics")));
            //09.Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.
            SelectStudentsGrp2(students);

            //10.Implement the previous using the same query expressed with extension methods.
            SelectStudentsGrp2ExtMethods(students);

            //11.Extract all students that have email in abv.bg. Use string methods and LINQ
            SelectMailsABV(students);

            //12.Extract all students with phones in Sofia. Use LINQ
            SelectPhonesInSofia(students);

            //13.Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.
            SelectExcelentMarks(students);

            //14.Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods.
            SelectTwoPoorMarks(students);

            //15.Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
            MarksOfStudentsIn2006(students);

            //16.* Create a class Group with properties GroupNumber and DepartmentName. Introduce a property Group in the Student class. Extract all students from "Mathematics" department. Use the Join operator.
            SelectMathDept(students);
        }

        private static void MarksOfStudentsIn2006(List<Student> students)
        {
            Console.WriteLine("Marks of the students that enrolled in 2006");
            var selectMarks = students.Where(st => (st.FacultyNumber.ToString())[4] == '0' && (st.FacultyNumber.ToString())[5] == '6').Select(st => st.GetMarks());
            foreach (var st in selectMarks)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine();
        }

        private static void SelectExcelentMarks(List<Student> students)
        {
            Console.WriteLine("All students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks, with LINQ");
            var studentsWithMarkSix =
                from st in students
                where st.Marks.Contains(6)
                select new { FullName = st.FirstName + " " + st.LastName, Marks = st.GetMarks() };
            foreach (var st in studentsWithMarkSix)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine();
        }

        private static void SelectMailsABV(List<Student> students)
        {
            Console.WriteLine("All students that have email in abv.bg with LINQ");
            var inAbv =
                from st in students
                where st.Email.Contains("@abv.bg")
                select st;
            foreach (var st in inAbv)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine();
        }

        private static void SelectMathDept(List<Student> students)
        {
            Console.WriteLine(@"All students from ""Mathematics"" department");
            Group[] grps = new Group[]
            {
                new Group("123", "Mathematics"),
                new Group("222", "Textile?"),
                new Group("13323", "Software and technology"),
                new Group("111", "Engineering")
            };
            var selectMath =
                from grp in grps
                join st in students on grp.DepartmentName equals st.Group.DepartmentName
                where grp.DepartmentName == "Mathematics"
                select new { Dep = st.Group.DepartmentName, Name = st.FirstName + " " + st.LastName };

            foreach (var st in selectMath)
            {
                Console.WriteLine(st.Name + " -> " + st.Dep);
            }
        }

        private static void SelectPhonesInSofia(List<Student> students)
        {
            Console.WriteLine("All students with phones in Sofia with LINQ");
            var studentsInSofia =
                from st in students
                where st.PhoneNumber.StartsWith("02")
                select st;
            foreach (var st in studentsInSofia)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine();
        }

        private static void SelectStudentsGrp2(List<Student> students)
        {
            Console.WriteLine("Selecting Select only the students that are from group number 2 with LINQ");
            var selected =
                from st in students
                where st.GroupNumber == 2
                orderby st.FirstName
                select st;
            foreach (var st in selected)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine();
        }

        private static void SelectStudentsGrp2ExtMethods(List<Student> students)
        {
            Console.WriteLine("Selecting Select only the students that are from group number 2 with extension methods");
            var selectedExtMethods = students.Where(st => st.GroupNumber == 2).OrderBy(st => st.FirstName);
            foreach (var st in selectedExtMethods)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine();
        }

        private static void SelectTwoPoorMarks(List<Student> students)
        {
            Console.WriteLine("All students that have two marks (2) into a new anonymous class that has properties – FullName and Marks, with LINQ");
            var studentsWithTwoMarksTwo = students.Where(st => st.Marks.Count(mark => mark == 2) == 2).Select(st => new { FullName = st.FirstName + " " + st.LastName, Marks = st.GetMarks() });
            foreach (var st in studentsWithTwoMarksTwo)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine();
        }
    }
}