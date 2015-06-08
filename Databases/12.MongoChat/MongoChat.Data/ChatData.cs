namespace MongoChat.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using MongoChat.Model;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    public static class ChatData
    {
        // This is static because I want to keep an open connection durring the whole program ( as it is a chat )
        private static MongoCollection<Message> Messages { get; set; }
        
        public static IEnumerable<Message> GetTop100Messages()
        {
            if (Messages == null)
            {
                Initialize();
            }

            return Messages.AsQueryable<Message>().OrderBy(m => m.Date).Take(100);
        }

        public static void AddMessage(Message message)
        {
            if (Messages == null)
            {
                Initialize();
            }

            Messages.Insert(message);
        }

        private static void Initialize()
        {
            string mongoConnectionString = "mongodb://student:student@ds063789.mongolab.com:63789/mongochat";

            var client = new MongoClient(mongoConnectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("mongochat");

            Messages = database.GetCollection<Message>("messages");
        }
    }
}
