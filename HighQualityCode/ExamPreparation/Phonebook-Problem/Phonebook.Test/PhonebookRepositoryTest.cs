namespace Phonebook.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ConsolePhonebook;
    using System.Collections.Generic;

    [TestClass]
    public class PhonebookRepositoryTest
    {
        [TestMethod]
        public void AddNewName()
        {
            var repo = new PhonebookRepository();
            var actual = repo.AddPhone("name", new string[] { "+3590" });
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void AddExistingName()
        {
            var repo = new PhonebookRepository();
            repo.AddPhone("name", new string[] { "+35901" });
            var actual = repo.AddPhone("name", new string[] { "+3590" });
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddNoPhones()
        {
            var repo = new PhonebookRepository();
            var actual = repo.AddPhone("name", new string[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddElevenPhones()
        {
            var repo = new PhonebookRepository();
            var actual = repo.AddPhone("name", new string[] { "+3591", "+3592", "+3593", "+3594", "+3595", "+3596", "+3597", "+3598", "+3599", "+35910", "+35911" });
        }

        [TestMethod]
        public void AddOnePhone()
        {
            var repo = new PhonebookRepository();
            var actual = repo.AddPhone("name", new string[] { "+3591" });
        }

        [TestMethod]
        public void Add10Phones()
        {
            var repo = new PhonebookRepository();
            var actual = repo.AddPhone("name", new string[] { "+3591", "+3592", "+3593", "+3594", "+3595", "+3596", "+3597", "+3598", "+3599", "+35910" });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddBadShortName()
        {
            var repo = new PhonebookRepository();
            var actual = repo.AddPhone("", new string[] { "+3591" });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddBadLongtName()
        {
            string name = new string('c', 201);
            var repo = new PhonebookRepository();
            var actual = repo.AddPhone(name, new string[] { "+3591" });
        }

        [TestMethod]
        public void Add200SymbolName()
        {
            string name = new string('c', 200);
            var repo = new PhonebookRepository();
            var actual = repo.AddPhone(name, new string[] { "+3591" });
        }

        [TestMethod]
        public void Add1SymbolName()
        {
            string name = new string('c', 1);
            var repo = new PhonebookRepository();
            var actual = repo.AddPhone(name, new string[] { "+3591" });
        }

        [TestMethod]
        public void Change1Phone()
        {
            string name = "name";
            string oldPhone = "+3591";
            string newPhone = "+3592";
            var repo = new PhonebookRepository();
            repo.AddPhone(name, new string[] { oldPhone });
            int count = repo.ChangePhone(oldPhone, newPhone);
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Change2Phones()
        {
            string name = "name";
            string oldPhone = "+3591";
            string nameTwo = "name2";
            string newPhone = "+3592";
            var repo = new PhonebookRepository();
            repo.AddPhone(name, new string[] { oldPhone });
            repo.AddPhone(nameTwo, new string[] { oldPhone });
            int count = repo.ChangePhone(oldPhone, newPhone);
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void ChangeSamePhones()
        {
            string name = "name";
            string oldPhone = "+3591";
            string nameTwo = "nameTwo";
            string newPhone = "+3591";
            var repo = new PhonebookRepository();
            repo.AddPhone(name, new string[] { oldPhone });
            repo.AddPhone(nameTwo, new string[] { oldPhone });
            int count = repo.ChangePhone(oldPhone, newPhone);
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void ListOneEntry()
        {
            string name = "name";
            string phone = "+3591";
            var entry = new PhonebookEntry();
            entry.Name = name;
            entry.PhoneNumbers = new SortedSet<string>(new string[] { phone });
            PhonebookEntry[] expected = new PhonebookEntry[] { entry };
            var repo = new PhonebookRepository();
            repo.AddPhone(name, new string[] { phone });
            var actualEntries = repo.ListEntries(0, 1);
            Assert.AreEqual(0, expected[0].CompareTo(actualEntries[0]));
        }

        [TestMethod]
        public void ListSecondEntry()
        {
            string name = "name";
            string phone = "+3591";
            var entry = new PhonebookEntry();
            entry.Name = name;
            entry.PhoneNumbers = new SortedSet<string>(new string[] { phone });
            PhonebookEntry[] expected = new PhonebookEntry[] { entry };
            var repo = new PhonebookRepository();
            repo.AddPhone("hello", new string[] { phone });
            repo.AddPhone(name, new string[] { phone });
            var actualEntries = repo.ListEntries(1, 1);
            Assert.AreEqual(0, expected[0].CompareTo(actualEntries[0]));
        }

        [TestMethod]
        public void ListTwoEntries()
        {
            string name = "name";
            string phone = "+3591";
            var entry = new PhonebookEntry();
            entry.Name = name;
            entry.PhoneNumbers = new SortedSet<string>(new string[] { phone });
            PhonebookEntry[] expected = new PhonebookEntry[] { entry };
            var repo = new PhonebookRepository();
            repo.AddPhone("hello", new string[] { phone });
            repo.AddPhone(name, new string[] { phone });
            var actualEntries = repo.ListEntries(0, 2);
            Assert.AreEqual(2, actualEntries.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListTooManyEntries()
        {
            string name = "name";
            string phone = "+3591";
            var entry = new PhonebookEntry();
            entry.Name = name;
            entry.PhoneNumbers = new SortedSet<string>(new string[] { phone });
            PhonebookEntry[] expected = new PhonebookEntry[] { entry };
            var repo = new PhonebookRepository();
            repo.AddPhone("hello", new string[] { phone });
            repo.AddPhone(name, new string[] { phone });
            var actualEntries = repo.ListEntries(0, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListFromIndexLessThan0()
        {
            string name = "name";
            string phone = "+3591";
            var entry = new PhonebookEntry();
            entry.Name = name;
            entry.PhoneNumbers = new SortedSet<string>(new string[] { phone });
            PhonebookEntry[] expected = new PhonebookEntry[] { entry };
            var repo = new PhonebookRepository();
            repo.AddPhone("hello", new string[] { phone });
            repo.AddPhone(name, new string[] { phone });
            var actualEntries = repo.ListEntries(-1, 1);
        }

        [TestMethod]
        public void RemoveExisting()
        {
            string name = "b";
            string phone = "+3591";
            var repo = new PhonebookRepository();
            repo.AddPhone(name, new string[] { phone + "1" });
            repo.AddPhone("a", new string[] { phone });
            repo.Remove(phone);
            var actualEntries = repo.ListEntries(0, 1);
            Assert.AreEqual(name, actualEntries[0].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveNonExisting()
        {
            string name = "b";
            string phone = "+3591";
            var repo = new PhonebookRepository();
            repo.AddPhone(name, new string[] { phone + "1" });
            repo.AddPhone("a", new string[] { phone });
            repo.Remove("+3591234");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonCanonicalNumberExisting()
        {
            string name = "b";
            string phone = "+3591";
            var repo = new PhonebookRepository();
            repo.AddPhone(name, new string[] { phone + "1" });
            repo.AddPhone("a", new string[] { phone });
            repo.Remove("003591");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonCanonicalNumberWithSymbolExisting()
        {
            string name = "b";
            string phone = "+3591";
            var repo = new PhonebookRepository();
            repo.AddPhone(name, new string[] { phone + "1" });
            repo.AddPhone("a", new string[] { phone });
            repo.Remove("+(3591)");
        }
    }
}
