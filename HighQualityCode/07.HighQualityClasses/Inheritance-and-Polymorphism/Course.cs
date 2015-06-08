namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        public Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

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
                    throw new ArgumentException("The name of the course cannot be null or white space");
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name of the teacher cannot be null or white space");
                }

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Students cannot have a null value");
                }

                this.students = value;
            }
        }

        public void AddStudent(string studentName)
        {
            if (string.IsNullOrWhiteSpace(studentName))
            {
                throw new ArgumentException("The name of the student cannot be null or white space");
            }

            this.students.Add(studentName);
        }

        public void RemoveStudent(string studentName)
        {
            if (string.IsNullOrWhiteSpace(studentName))
            {
                throw new ArgumentException("The name of the student cannot be null or white space");
            }

            this.students.Remove(studentName);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { Name = ");
            result.Append(this.Name);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}