namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string name, string teacherName, IList<string> students, string lab)
            : base(name, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name of the lab cannot be null or white space");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.Append("; Lab = ");
            result.Append(this.Lab);
            result.Append(" }");

            return result.ToString();
        }
    }
}