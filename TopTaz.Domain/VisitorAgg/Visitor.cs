using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTaz.Domain.VisitorAgg
{
    public class Visitor
    {
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

        public Visitor(string Id,string ip, string currentLink, string referrerLink, string method, 
            string protocol, string physicalPath,
            VisitorVersion browser, VisitorVersion operationSystem, Device device)
        {
            ID = Id;
            Ip = ip;
            CurrentLink = currentLink;
            ReferrerLink = referrerLink;
            Method = method;
            Protocol = protocol;
            PhysicalPath = physicalPath;
            Browser = browser;
            OperationSystem = operationSystem;
            Device = device;
        }

        public Visitor()
        {
        }
    }
}
