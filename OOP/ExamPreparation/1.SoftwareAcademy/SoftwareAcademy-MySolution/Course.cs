using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public abstract class Course : ICourse
    {
        private string name;
        private IList<string> topics;

        public Course(string name, ITeacher teacher = null)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.topics = new List<string>();
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
                    throw new ArgumentNullException("The name of the course cannot be null or empty");
                }
                this.name = value;
            }
        }

        public IList<string> Topics
        {
            get { return new List<string>(this.topics); }
        }

        public ITeacher Teacher { get; set; }

        public void AddTopic(string topic)
        {
            if (string.IsNullOrEmpty(topic))
            {
                throw new ArgumentNullException("The topic cannot be null or empty");   
            }
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            //(course type): Name=(course name); Teacher=(teacher name); Topics=[(course topics – comma separated)]; Lab=(lab name – when applicable); Town=(town name – when applicable);
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0}: Name={1}; ", this.GetType().Name, this.Name));
            if (this.Teacher != null)
            {
                sb.Append(string.Format("Teacher={0}; ", this.Teacher.Name)); 
            }
            if (this.Topics.Count != 0)
            {
                sb.Append(string.Format("Topics=[{0}]; ", string.Join(", ", this.Topics))); 
            }
            return sb.ToString();
        } 
    }
}
