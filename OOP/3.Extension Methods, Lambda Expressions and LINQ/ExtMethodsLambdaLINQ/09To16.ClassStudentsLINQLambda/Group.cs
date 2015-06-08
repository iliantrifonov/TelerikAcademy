namespace _09To16.ClassStudentsLINQLambda
{
    //16.* Create a class Group with properties GroupNumber and DepartmentName. Introduce a property Group in the Student class. Extract all students from "Mathematics" department. Use the Join operator.

    public class Group
    {
        public Group(string groupNumber, string DeptName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = DeptName;
        }

        public string DepartmentName { get; set; }

        public string GroupNumber { get; set; }

        public override string ToString()
        {
            return " Group number : " + GroupNumber + " Department: " + DepartmentName;
        }
    }
}