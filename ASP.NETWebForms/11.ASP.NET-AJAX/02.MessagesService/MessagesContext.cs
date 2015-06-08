namespace _02.MessagesService
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MessagesContext : DbContext
    {
        public MessagesContext()
            : base("name=Messages")
        {
        }

        public virtual DbSet<Message> Messages { get; set; }
    }
}