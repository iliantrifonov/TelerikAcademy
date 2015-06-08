using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02.MessagesService
{
    public class Message
    {
        public string Username { get; set; }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DatePublished { get; set; }
    }
}