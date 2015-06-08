namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void StudentConstructorTestName()
        {
            string name = "Maria";
            int uniqueNumber = 11111;
            Student student = new Student(name, uniqueNumber);
            Assert.AreEqual(student.Name, "Maria");
        }

        [TestMethod]
        public void StudentConstructorTestStudentNumber()
        {
            string name = "Maria";
            int uniqueNumber = 11111;
            Student student = new Student(name, uniqueNumber);
            Assert.AreEqual(student.StudentNumber, 11111);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameTestNullValue()
        {
            string name = null;
            int studentNumber = 12345;
            Student student = new Student(name, studentNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameTestEmptyString()
        {
            string name = string.Empty;
            int studentNum = 12345;
            Student student = new Student(name, studentNum);
        }

        [TestMethod]
        public void StudentNumberTestStartValue()
        {
            string name = "Maria";
            int studentNum = 10000;
            Student student = new Student(name, studentNum);
            Assert.IsTrue(studentNum >= 10000 && studentNum <= 99999);
        }

        [TestMethod]
        public void StudentNumberTestEndValue()
        {
            string name = "Maria";
            int studentNum = 99999;
            Student student = new Student(name, studentNum);
            Assert.IsTrue(studentNum >= 10000 && studentNum <= 99999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentNumberTestStartValueMinusOne()
        {
            string name = "Maria";
            int studentNum = 10000 - 1;
            Student student = new Student(name, studentNum);
            Assert.IsTrue(studentNum >= 10000 && studentNum <= 99999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentNumberTestEndValuePlusOne()
        {
            string name = "Maria Petrova";
            int studentNum = 99999 + 1;
            Student student = new Student(name, studentNum);
            Assert.IsTrue(studentNum >= 10000 && studentNum <= 99999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentNumberTestZero()
        {
            string name = "Ivo";
            int studentNum = 0;
            Student student = new Student(name, studentNum);
            Assert.IsTrue(studentNum >= 10000 && studentNum <= 99999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentNumberTestIntMaxValue()
        {
            string name = "Ivo";
            int studentNum = int.MaxValue;
            Student student = new Student(name, studentNum);
            Assert.IsTrue(studentNum >= 10000 && studentNum <= 99999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentNumberTestNegativeValue()
        {
            string name = "Maria Petrova";
            int studentNumber = -11111;
            Student student = new Student(name, studentNumber);
            Assert.IsTrue(studentNumber >= 10000 && studentNumber <= 99999);
        }
    }
}