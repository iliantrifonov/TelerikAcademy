namespace _18.ExtractStudentsByGrpName
{
    public class Student
    {
        public Student(string firstName, string lastName, string groupName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.GroupName = groupName;
        }

        public string FirstName { get; set; }

        public string GroupName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}