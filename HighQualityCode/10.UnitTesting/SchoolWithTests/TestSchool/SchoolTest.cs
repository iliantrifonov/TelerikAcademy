namespace TestSchool
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void SchoolConstructorTest()
        {
            School school = new School();
            Assert.IsNotNull(school);
        }

        [TestMethod]
        public void AddCourseTest()
        {
            Course javascript = new Course("Javascript");
            School school = new School();
            school.AddCourse(javascript);
            Assert.AreEqual(1, school.Courses.Count);
        }

        [TestMethod]
        public void AddOneStudentTest()
        {
            School school = new School();
            school.AddStudent(new Student("Ivo", 11111));
            Assert.IsTrue(school.Students.Count == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddExistingStudentTest()
        {
            School school = new School();
            school.AddStudent(new Student("Ivo", 11111));
            school.AddStudent(new Student("Maria", 11111));
            Assert.IsTrue(school.Students.Count == 1);
        }

        [TestMethod]
        public void Add1000StudentsTest()
        {
            School school = new School();
            for (int i = 0; i < 1000; i++)
            { 
                school.AddStudent(new Student(i.ToString(), 11111 + i));
            }

            Assert.IsTrue(school.Students.Count == 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudentThatHasANumberThatExistsTest()
        {
            School school = new School();
            school.AddStudent(new Student("Ivo", 11111));
            school.AddStudent(new Student("Ivo", 11111));
        }
    }
}