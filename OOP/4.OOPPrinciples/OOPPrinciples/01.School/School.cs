namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private List<Class> classes;

        public School(List<Class> classes)
        {
            this.Classes = classes;
        }

        public List<Class> Classes
        {
            get
            {
                return this.classes;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Classes cannot have a null value");
                }
                this.classes = value;
            }
        }
    }
}