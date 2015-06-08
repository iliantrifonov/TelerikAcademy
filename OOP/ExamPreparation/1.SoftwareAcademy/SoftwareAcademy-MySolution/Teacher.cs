using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        private string name;
        private IList<ICourse> courses;

        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name of the teacher cannot be null or emprty");
                }
                this.name = value;
            }
        }

        public IList<ICourse> Courses
        {
            get { return new List<ICourse>(courses); }
        }

        public void AddCourse(ICourse course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Cannot add a null course value");
            }
            this.courses.Add(course);
        }

        public override string ToString()
        {
            //Teacher: Name=(teacher name); Courses=[(course names – comma separated)]
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Teacher: Name={0}", this.Name));
            if (this.Courses.Count != 0)
            {
                sb.Append(string.Format("; Courses=[{0}]", string.Join(", ", this.Courses.Select(x => x.Name))));
            }
            return sb.ToString();
        }
    }
}
