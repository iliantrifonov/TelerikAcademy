namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const byte MaxStudentsInCourse = 29;

        private string name;

        public Course(string name)
        {
            this.Students = new HashSet<Student>();
            this.Name = name;
        }

        public ICollection<Student> Students { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must not be null or empty");
                }

                this.name = value;
            }
        }

        public void AddStudent(Student student)
        {
            bool studentFound = this.Students.Contains(student);

            if (studentFound)
            {
                throw new ArgumentException("The student has been added already!");
            }

            if (this.Students.Count + 1 > MaxStudentsInCourse)
            {
                throw new OverflowException("The course is full. No more students can be added!");
            }

            this.Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            bool studentFound = this.Students.Contains(student);

            if (!studentFound)
            {
                throw new ArgumentException("Student does not exist in this course");
            }

            this.Students.Remove(student);
        }
    }
}