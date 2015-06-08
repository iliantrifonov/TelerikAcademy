namespace ConsoleCalendar.Tests
{
    using System;
    using ConsoleCalendar;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ParseTests
    {
        [TestMethod]
        public void ParseAddCommandWithLocation()
        {
            var parser = new CommandParser();

            var command = parser.Parse("AddEvent 2012-01-21T20:00:00 | party Viki | home");
            Assert.AreEqual("AddEvent", command.CommandName);
            Assert.AreEqual("2012-01-21T20:00:00", command.Arguments[0]);
            Assert.AreEqual("party Viki", command.Arguments[1]);
            Assert.AreEqual("home", command.Arguments[2]);
            Assert.AreEqual(3, command.Arguments.Length);
        }

        [TestMethod]
        public void ParseAddCommandWithoutLocation()
        {
            var parser = new CommandParser();

            var command = parser.Parse("AddEvent 2012-01-21T20:00:00 | party Viki");
            Assert.AreEqual("AddEvent", command.CommandName);
            Assert.AreEqual("2012-01-21T20:00:00", command.Arguments[0]);
            Assert.AreEqual("party Viki", command.Arguments[1]);
            Assert.AreEqual(2, command.Arguments.Length);
        }

        [TestMethod]
        public void ParseListCommand()
        {
            var parser = new CommandParser();

            var command = parser.Parse("ListEvents 2012-03-07T08:00:00 | 2");
            Assert.AreEqual("ListEvents", command.CommandName);
            Assert.AreEqual("2012-03-07T08:00:00", command.Arguments[0]);
            Assert.AreEqual("2", command.Arguments[1]);
            Assert.AreEqual(2, command.Arguments.Length);
        }

        [TestMethod]
        public void DeleteCommand()
        {
            var parser = new CommandParser();

            var command = parser.Parse("DeleteEvents c# exam");
            Assert.AreEqual("DeleteEvents", command.CommandName);
            Assert.AreEqual("c# exam", command.Arguments[0]);
            Assert.AreEqual(1, command.Arguments.Length);
        }

        [TestMethod]
        public void ParseListCommandWithDifferentArgs()
        {
            var parser = new CommandParser();

            var command = parser.Parse("ListEvents 2013-11-27T08:30:25 | 25");
            Assert.AreEqual("ListEvents", command.CommandName);
            Assert.AreEqual("2013-11-27T08:30:25", command.Arguments[0]);
            Assert.AreEqual("25", command.Arguments[1]);
            Assert.AreEqual(2, command.Arguments.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseInvalidCommand()
        {
            var parser = new CommandParser();

            var command = parser.Parse("ListEvents,2013-11-27T08:30:25,25");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParseNullCommand()
        {
            var parser = new CommandParser();

            var command = parser.Parse(null);
        }
    }
}
