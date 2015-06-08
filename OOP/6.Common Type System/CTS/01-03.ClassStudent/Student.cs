namespace _01_03.ClassStudent
{
    using System;

    //1.Define a class Student, which contains data about a student – first, middle and last name, SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty. Use an enumeration for the specialties, universities and faculties. Override the standard methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
    //2.Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's fields into a new object of type Student.
    //3.Implement the  IComparable<Student> interface to compare students by names (as first criteria, in lexicographic order) and by social security number (as second criteria, in increasing order).

    public class Student : ICloneable, IComparable<Student>
    {
        public Student(string firstName, string middleName, string lastName, string socialSecNum, string address, string phone, string email, string course, Specialty speciality, University university, Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SocialSecNumber = socialSecNum;
            this.PernamenentAddress = address;
            this.MobilePhone = phone;
            this.Email = email;
            this.Course = course;
            this.Speciality = speciality;
            this.University = university;
            this.Faculty = faculty;
        }

        public string Course { get; set; }

        public string Email { get; set; }

        public Faculty Faculty { get; set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string MiddleName { get; private set; }

        public string MobilePhone { get; set; }

        public string PernamenentAddress { get; set; }

        public string SocialSecNumber { get; private set; }

        public Specialty Speciality { get; set; }

        public University University { get; set; }

        public static bool operator !=(Student stOne, Student stTwo)
        {
            if (stOne.Equals(stTwo))
            {
                return false;
            }
            return true;
        }

        public static bool operator ==(Student stOne, Student stTwo)
        {
            if (stOne.Equals(stTwo))
            {
                return true;
            }
            return false;
        }

        public Student Clone()
        {
            string firstName = this.FirstName;
            string middleName = this.MiddleName;
            string lastName = this.LastName;
            string socialSecNumber = this.SocialSecNumber;
            string pernamenentAddress = this.PernamenentAddress;
            string mobilePhone = this.MobilePhone;
            string email = this.Email;
            string course = this.Course;
            Specialty speciality = this.Speciality;
            University university = this.University;
            Faculty faculty = this.Faculty;
            Student cloned = new Student(firstName, middleName, lastName, socialSecNumber, pernamenentAddress, mobilePhone, email, course, speciality, university, faculty);
            return cloned;
        }

        public int CompareTo(Student st)
        {
            if (this.LastName != st.LastName)
            {
                return (String.Compare(this.LastName, st.LastName));
            }
            if (this.FirstName != st.FirstName)
            {
                return (String.Compare(this.FirstName, st.FirstName));
            }
            if (this.SocialSecNumber != st.SocialSecNumber)
            {
                return (this.SocialSecNumber.CompareTo(st.SocialSecNumber));
            }
            return 0;
        }

        public override bool Equals(object obj)
        {
            Student stud = obj as Student;
            if (stud == null || stud.SocialSecNumber != this.SocialSecNumber)
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return this.SocialSecNumber.GetHashCode() ^ this.PernamenentAddress.GetHashCode();
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public override string ToString()
        {
            return string.Format("Name: {0} {1} {2}, Address: {3}, Mobile phone number: {4}, Email: {5}", this.FirstName, this.MiddleName, this.LastName, this.PernamenentAddress, this.MobilePhone, this.Email);
        }
    }
}