using System.Collections.Generic;

namespace _09To16.ClassStudentsLINQLambda
{
    //9.Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber. Create a List<Student> with sample students. Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.
    //16.* Create a class Group with properties GroupNumber and DepartmentName. Introduce a property Group in the Student class. Extract all students from "Mathematics" department. Use the Join operator.

    public class Student
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Student(string firstName, string lastName, int facultyNum, string phoneNum, string email, List<int> marks, int groupNumber)
            : this(firstName, lastName)
        {
            this.FacultyNumber = facultyNum;
            this.PhoneNumber = phoneNum;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }

        public Student(string firstName, string lastName, int facultyNum, string phoneNum, string email, List<int> marks, int groupNumber, Group group)
            : this(firstName, lastName, facultyNum, phoneNum, email, marks, groupNumber)
        {
            this.Group = group;
        }

        public string Email { get; set; }

        public int FacultyNumber { get; set; }

        public string FirstName { get; set; }

        public Group Group { get; set; }

        public int GroupNumber { get; set; }

        public string LastName { get; set; }

        public List<int> Marks { get; set; }

        public string PhoneNumber { get; set; }

        public string GetMarks()
        {
            return string.Join(", ", Marks);
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " FN: " + FacultyNumber + " Phone: " + PhoneNumber + " Email: " + Email + " Group: " + GroupNumber + " Marks: " + GetMarks() + Group;
        }
    }
}