using MongoDB.Driver;
using System.Linq;
using TopTaz.Application.ContextACL;
using TopTaz.Domain.VisitorAgg;

namespace TopTaz.Application.VisitorApplication.VisitorOnline
{
    public class VisitorOnlineApplication : IVisitorOnlineApplication
    {
        private readonly IMongoServiceConnection<OnlineVisitor> _serviceConnection;
        private readonly IMongoCollection<OnlineVisitor> _collection;

        public VisitorOnlineApplication(IMongoServiceConnection<OnlineVisitor> serviceConnection)
        {
            _serviceConnection = serviceConnection;
            _collection = _serviceConnection.GetConnection();
        }

        public bool Connected(string visitorId)
        {
            try
            {
                var exist = _collection.Find(x => x.VisitorID == visitorId).Any();
                if (!exist)
                    _collection.InsertOne(new OnlineVisitor(visitorId));

                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Disconnected(string visitorId)
        {
            var res = _collection.DeleteOne(p => p.VisitorID == visitorId);
            return res.IsAcknowledged;
        }

        public long GetCountOnline()
        {
            return _collection.AsQueryable().Count();
        }

    }
}
