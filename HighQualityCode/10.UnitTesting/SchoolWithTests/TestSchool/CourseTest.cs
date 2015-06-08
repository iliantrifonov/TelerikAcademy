namespace TestSchool
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void CourseConstructorTestName()
        {
            string name = "Javascript";
            Course course = new Course(name);
            Assert.AreEqual(course.Name, "Javascript");
        }

        [TestMethod]
        public void CourseConstructorTestListStudents()
        {
            string name = "Javascript";
            Student maria = new Student("Maria Petrova", 12345);
            Course course = new Course(name);
            course.AddStudent(maria);
            Assert.IsTrue(course.Students.Contains(maria));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameTestNullValue()
        {
            string name = null;
            Course newCourse = new Course(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameTestEmptyString()
        {
            string name = string.Empty;
            Course newCourse = new Course(name);
        }

        [TestMethod]
        public void AddStudentTestOneStudent()
        {
            string name = "Javascript";
            Course course = new Course(name);
            Student maria = new Student("Ivo Petrov", 11111);
            course.AddStudent(maria);
            Assert.IsTrue(course.Students.Count == 1);
        }

        [TestMethod]
        public void AddStudentTestTwoStudents()
        {
            string name = "Javascript";
            Course course = new Course(name);
            Student maria = new Student("Maria Petrova", 11111);
            Student petar = new Student("Petur", 22222);
            course.AddStudent(maria);
            course.AddStudent(petar);
            Assert.IsTrue(course.Students.Count == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudentTestSameStudentTwoTimes()
        {
            string name = "Javascript";
            Course course = new Course(name);
            Student maria = new Student("Maria", 1111);
            course.AddStudent(maria);
            course.AddStudent(maria);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void AddStudentTestMoreThanMaximumStudents()
        {
            string name = "Javascript";
            Course course = new Course(name);

            for (int i = 0; i < 30; i++)
            {
                course.AddStudent(new Student(i.ToString(), 10000 + i));
            }
        }

        [TestMethod]
        public void RemoveStudentTest()
        {
            string name = "Javascript";
            Course course = new Course(name);
            Student maria = new Student("Maria", 11111);
            Student petar = new Student("Petar", 22222);
            course.AddStudent(maria);
            course.AddStudent(petar);
            course.RemoveStudent(petar);
            Assert.IsTrue(course.Students.Count == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonExistingStudentTest()
        {
            string name = "Javascript";
            Course course = new Course(name);
            Student maria = new Student("Maria", 11111);
            course.RemoveStudent(maria);
        }
    }
}