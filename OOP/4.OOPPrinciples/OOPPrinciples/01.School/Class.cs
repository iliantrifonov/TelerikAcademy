using System;
using System.Collections.Generic;

namespace _01.School
{
    public class Class
    {
        private string identifier;
        private HashSet<Student> students;
        private HashSet<Teacher> teachers;

        public Class(HashSet<Student> students, HashSet<Teacher> teachers, string identifier)
        {
            this.Teachers = teachers;
            this.ID = identifier;
            this.Students = students;
        }

        public string ID
        {
            get
            {
                return this.identifier;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length <= 3)
                {
                    throw new ArgumentException("The lenght of the identifier {0} is too short, null or empty", value);
                }
                this.identifier = value;
            }
        }

        public HashSet<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The set of students cannot be null value");
                }
                this.students = value;
            }
        }

        public HashSet<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The set of teachers cannot be null value");
                }
                this.teachers = value;
            }
        }
    }
}