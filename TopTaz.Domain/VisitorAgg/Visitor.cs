using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTaz.Domain.VisitorAgg
{
    public class Visitor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string Ip { get; set; }
        public string CurrentLink { get; set; }
        public string ReferrerLink { get; set; }
        public string Method { get; set; }
        public string Protocol { get; set; }
        public string PhysicalPath { get; set; }
        public VisitorVersion Browser { get; set; }
        public VisitorVersion OperationSystem { get; set; }
        public Device Device { get; set; }
        public string VisitorId { get; set; }
        public DateTime Time { get; set; }
        
        public Visitor(string ip, string currentLink, string referrerLink, string method, 
            string protocol, string physicalPath,
            VisitorVersion browser, VisitorVersion operationSystem, Device device,string visitorId)
        {
            Ip = ip;
            CurrentLink = currentLink;
            ReferrerLink = referrerLink;
            Method = method;
            Protocol = protocol;
            PhysicalPath = physicalPath;
            Browser = browser;
            OperationSystem = operationSystem;
            Device = device;
            Time = DateTime.Now;
            VisitorId = visitorId;

        }

        public Visitor()
        {
        }
    }
}
