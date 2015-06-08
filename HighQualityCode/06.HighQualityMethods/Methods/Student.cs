namespace Methods
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate;
            DateTime secondDate;

            if (DateTime.TryParse(this.OtherInfo.Substring(this.OtherInfo.Length - 10), out firstDate) && DateTime.TryParse(other.OtherInfo.Substring(other.OtherInfo.Length - 10), out secondDate))
            {
                return firstDate < secondDate;
            }

            throw new ArgumentException("The property OtherInfo does not contain a valid DateTime string at the end");
        }
    }
}