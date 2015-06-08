namespace ConsoleCalendar.Tests
{
    using System;
    using System.Linq;
    using ConsoleCalendar;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EventsManagerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullEvent()
        {
            var eventManager = new EventsManager();
            eventManager.AddEvent(null);
        }

        [TestMethod]
        public void AddSingleEvent()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "some title");
            eventManager.AddEvent(eventToAdd);

            Assert.AreEqual(1, eventManager.ListEvents(DateTime.MinValue, 10).Count());
        }

        [TestMethod]
        public void AddSameEventTwice()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "some title");
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd);

            Assert.AreEqual(2, eventManager.ListEvents(DateTime.MinValue, 10).Count());
        }

        [TestMethod]
        public void AddTwoDifferentEvents()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "some title");
            var eventToAdd2 = new CalendarEvent(date, "some other");
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd2);

            Assert.AreEqual(2, eventManager.ListEvents(DateTime.MinValue, 10).Count());
        }

        [TestMethod]
        public void AddManySameAndDifferentEvents()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "some title");
            var eventToAdd2 = new CalendarEvent(date, "some other");
            var eventToAdd3 = new CalendarEvent(date, "some other");
            var eventToAdd4 = new CalendarEvent(date, "some Other");
            var eventToAdd5 = new CalendarEvent(date, "S other");
            var eventToAdd6 = new CalendarEvent(date, "B other");
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd2);
            eventManager.AddEvent(eventToAdd3);
            eventManager.AddEvent(eventToAdd4);
            eventManager.AddEvent(eventToAdd4);
            eventManager.AddEvent(eventToAdd6);
            eventManager.AddEvent(eventToAdd5);
            eventManager.AddEvent(eventToAdd5);
            eventManager.AddEvent(eventToAdd5);
            eventManager.AddEvent(eventToAdd5);

            Assert.AreEqual(10, eventManager.ListEvents(DateTime.MinValue, 20).Count());
        }

        [TestMethod]
        public void DeleteManyMatchingDifferentCasings()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "some title");
            var eventToAdd2 = new CalendarEvent(date, "some other");
            var eventToAdd3 = new CalendarEvent(date, "some other");
            var eventToAdd4 = new CalendarEvent(date, "some Other");
            var eventToAdd5 = new CalendarEvent(date, "S other");
            var eventToAdd6 = new CalendarEvent(date, "B other");
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd2);
            eventManager.AddEvent(eventToAdd3);
            eventManager.AddEvent(eventToAdd4);
            eventManager.AddEvent(eventToAdd4);
            eventManager.AddEvent(eventToAdd6);
            eventManager.AddEvent(eventToAdd5);
            eventManager.AddEvent(eventToAdd5);
            eventManager.AddEvent(eventToAdd5);
            eventManager.AddEvent(eventToAdd5);

            var deletedCount = eventManager.DeleteEventsByTitle("some other");
            Assert.AreEqual(6, eventManager.ListEvents(DateTime.MinValue, 20).Count());
            Assert.AreEqual(4, deletedCount);
        }

        [TestMethod]
        public void DeleteSingle()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "some title");
            eventManager.AddEvent(eventToAdd);

            var deletedCount = eventManager.DeleteEventsByTitle("some title");
            Assert.AreEqual(0, eventManager.ListEvents(DateTime.MinValue, 10).Count());
            Assert.AreEqual(1, deletedCount);
        }

        [TestMethod]
        public void DeleteCaseInsensitive()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "some title");
            eventManager.AddEvent(eventToAdd);

            var deletedCount = eventManager.DeleteEventsByTitle("sOme TiTle");
            Assert.AreEqual(0, eventManager.ListEvents(DateTime.MinValue, 10).Count());
            Assert.AreEqual(1, deletedCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteNullTitle()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "some title");
            eventManager.AddEvent(eventToAdd);

            var deletedCount = eventManager.DeleteEventsByTitle(null);
        }

        [TestMethod]
        public void DeleteMoreCaseInsensitive()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "sOme title");
            var eventToAdd2 = new CalendarEvent(date, "some title");
            var eventToAdd3 = new CalendarEvent(date, "title");
            eventManager.AddEvent(eventToAdd2);
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd3);

            var deletedCount = eventManager.DeleteEventsByTitle("sOme TiTle");
            Assert.AreEqual(1, eventManager.ListEvents(DateTime.MinValue, 10).Count());
            Assert.AreEqual(4, deletedCount);
        }

        [TestMethod]
        public void ListManyEvents()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "sOme title");
            var eventToAdd2 = new CalendarEvent(date, "some title");
            var eventToAdd3 = new CalendarEvent(date, "title");
            eventManager.AddEvent(eventToAdd2);
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd3);

            Assert.AreEqual(5, eventManager.ListEvents(DateTime.MinValue, 10).Count());
        }

        [TestMethod]
        public void ListOneEventWithMoreCount()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "sOme title");
            eventManager.AddEvent(eventToAdd);

            Assert.AreEqual(1, eventManager.ListEvents(DateTime.MinValue, 10).Count());
        }

        [TestMethod]
        public void ListAllWithCountOne()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "sOme title");
            var eventToAdd2 = new CalendarEvent(date, "some title");
            var eventToAdd3 = new CalendarEvent(date, "title");
            eventManager.AddEvent(eventToAdd2);
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd3);

            Assert.AreEqual(1, eventManager.ListEvents(DateTime.MinValue, 1).Count());
        }

        [TestMethod]
        public void ListTwoWithCountOne()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "sOme title");
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd);

            Assert.AreEqual(1, eventManager.ListEvents(DateTime.MinValue, 1).Count());
        }

        [TestMethod]
        public void ListTwoWithCountTwo()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "sOme title");
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd);

            Assert.AreEqual(2, eventManager.ListEvents(DateTime.MinValue, 2).Count());
        }

        [TestMethod]
        public void ListTwoWithCountZero()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "sOme title");
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd);

            Assert.AreEqual(0, eventManager.ListEvents(DateTime.MinValue, 0).Count());
        }

        [TestMethod]
        public void ListSortTestByDate()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;
            var date2 = DateTime.Now;
            date2 = date2.AddYears(1);

            var eventToAdd = new CalendarEvent(date, "b", "b");
            var eventToAdd2 = new CalendarEvent(date2, "a", "a");
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd2);

            Assert.AreEqual(eventToAdd, eventManager.ListEvents(DateTime.MinValue, 100).First());
        }

        [TestMethod]
        public void ListSortTestByDateSwitchAdding()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;
            var date2 = DateTime.Now;
            date2 = date2.AddYears(1);

            var eventToAdd = new CalendarEvent(date, "b", "b");
            var eventToAdd2 = new CalendarEvent(date2, "a", "a");
            eventManager.AddEvent(eventToAdd2);
            eventManager.AddEvent(eventToAdd);

            Assert.AreEqual(eventToAdd, eventManager.ListEvents(DateTime.MinValue, 100).First());
        }

        [TestMethod]
        public void ListSortTestByDateThenTitle()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "a", "b");
            var eventToAdd2 = new CalendarEvent(date, "b", "a");
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd2);

            Assert.AreEqual(eventToAdd, eventManager.ListEvents(DateTime.MinValue, 100).First());
        }

        [TestMethod]
        public void ListSortTestByDateThenTitleSwitchAdding()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "a", "b");
            var eventToAdd2 = new CalendarEvent(date, "b", "a");
            eventManager.AddEvent(eventToAdd2);
            eventManager.AddEvent(eventToAdd);

            Assert.AreEqual(eventToAdd, eventManager.ListEvents(DateTime.MinValue, 100).First());
        }

        [TestMethod]
        public void ListSortTestByDateThenTitleThenByLocationDescending()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "a", "b");
            var eventToAdd2 = new CalendarEvent(date, "a", "a");
            eventManager.AddEvent(eventToAdd);
            eventManager.AddEvent(eventToAdd2);

            Assert.AreEqual(eventToAdd, eventManager.ListEvents(DateTime.MinValue, 100).First());
        }

        [TestMethod]
        public void ListSortTestByDateThenTitleThenByLocationDescendingSwitchAdding()
        {
            var eventManager = new EventsManager();
            var date = DateTime.Now;

            var eventToAdd = new CalendarEvent(date, "a", "b");
            var eventToAdd2 = new CalendarEvent(date, "a", "a");
            eventManager.AddEvent(eventToAdd2);
            eventManager.AddEvent(eventToAdd);

            Assert.AreEqual(eventToAdd, eventManager.ListEvents(DateTime.MinValue, 100).First());
        }
    }
}
