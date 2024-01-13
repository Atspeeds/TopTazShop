using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace TopTaz.Domain.VisitorAgg
{
    public class OnlineVisitor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string VisitorID { get; set; }
        public DateTime  CreationDate { get; set; }

        public OnlineVisitor(string visitorID)
        {
            VisitorID = visitorID;
            CreationDate = DateTime.Now;
        }
    }
}
