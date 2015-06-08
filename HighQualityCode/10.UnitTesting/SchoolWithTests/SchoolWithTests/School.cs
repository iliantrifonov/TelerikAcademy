namespace School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        public School()
        {
            this.Courses = new HashSet<Course>();
            this.Students = new Dictionary<int, Student>();
        }

        public ICollection<Course> Courses { get; set; }

        public IDictionary<int, Student> Students { get; set; }

        public void AddCourse(Course course)
        {
            if (this.Courses.Contains(course))
            {
                throw new ArgumentException("The course already exists and cannot be added again");
            }

            this.Courses.Add(course);
        }

        public void AddStudent(Student student)
        {
            if (this.Students.ContainsKey(student.StudentNumber))
            {
                throw new ArgumentException("A student with this number already exists");
            }

            this.Students.Add(student.StudentNumber, student);
        }
    }
}