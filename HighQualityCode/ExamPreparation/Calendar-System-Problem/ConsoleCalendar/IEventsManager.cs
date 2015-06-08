namespace ConsoleCalendar
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface that declares an event manager with add, delete and list functionality.
    /// </summary>
    public interface IEventsManager
    {
        /// <summary>
        /// Adds an event to the event manager.
        /// </summary>
        /// <param name="eventToAdd">The event that will be added.</param>
        void AddEvent(CalendarEvent eventToAdd);

        /// <summary>
        /// Removes all events with the title given. Returns the number of events deleted, or zero if none were deleted.
        /// </summary>
        /// <param name="title">Title to match the events by.</param>
        /// <returns>Returns the number of events deleted, or zero if none were deleted.</returns>
        int DeleteEventsByTitle(string title);

        /// <summary>
        /// Get a collection of events from the given date, with a count.
        /// </summary>
        /// <param name="date">Get a collection of events from this date.</param>
        /// <param name="count">The number of events that will be in the list. If the number is too large all matching events will be returned.</param>
        /// <returns>Returns a collection of <see cref="CalendarEvent"/> that matches the conditions.</returns>
        IEnumerable<CalendarEvent> ListEvents(DateTime date, int count);
    }
}