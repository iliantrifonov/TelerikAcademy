namespace MongoChat.Model
{
    using System;
    using System.Linq;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Message
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public User User { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }
    }
}
