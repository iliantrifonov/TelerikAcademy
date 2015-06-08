namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public class Teacher : Person, ICommentable
    {
        private HashSet<Discipline> disciplines;

        public Teacher(string fullName, HashSet<Discipline> disciplines)
            : base(fullName)
        {
            this.Disciplines = disciplines;
        }

        public string Comment { get; set; }

        public HashSet<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The set of disciplines cannot be null value");
                }
                this.disciplines = value;
            }
        }
    }
}