namespace ConsoleCalendar
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class EventsManager : IEventsManager
    {
        private MultiDictionary<string, CalendarEvent> eventByTitle;
        private OrderedMultiDictionary<DateTime, CalendarEvent> eventByDate;

        public EventsManager()
        {
            this.eventByDate = new OrderedMultiDictionary<DateTime, CalendarEvent>(true);
            this.eventByTitle = new MultiDictionary<string, CalendarEvent>(true);
        }

        public void AddEvent(CalendarEvent eventToAdd)
        {
            if (eventToAdd == null)
            {
                throw new ArgumentNullException("Event that will be added must not be null");
            }

            string eventTitleLowerCase = eventToAdd.Title.ToLowerInvariant();
            this.eventByTitle.Add(eventTitleLowerCase, eventToAdd);
            this.eventByDate.Add(eventToAdd.Date, eventToAdd);
        }

        public int DeleteEventsByTitle(string title)
        {
            if (title == null)
            {
                throw new ArgumentNullException("Title must not be null");
            }

            string titleForComparison = title.ToLowerInvariant();
            var eventsToDelete = this.eventByTitle[titleForComparison];
            int deletedEventsCount = eventsToDelete.Count;

            foreach (var currentEvent in eventsToDelete)
            {
                this.eventByDate.Remove(currentEvent.Date, currentEvent);
            }

            this.eventByTitle.Remove(titleForComparison);

            return deletedEventsCount;
        }

        public IEnumerable<CalendarEvent> ListEvents(DateTime date, int count)
        {
            var eventsFromDate = from e in this.eventByDate.RangeFrom(date, true).Values
                                 select e;
            var events = eventsFromDate.Take(count).OrderBy(e => e.Date).ThenBy(e => e.Title).ThenByDescending(e => e.Location);
            return events;
        }
    }
}