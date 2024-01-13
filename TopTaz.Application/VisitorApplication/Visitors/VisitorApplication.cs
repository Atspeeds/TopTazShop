using MongoDB.Driver;
using TopTaz.Application.ContextACL;
using TopTaz.Application.VisitorApplication.Dtos;
using TopTaz.Domain.VisitorAgg;

namespace TopTaz.Application.VisitorApplication.Visitors
{
    public class VisitorApplication : IVisitorApplication
    {
        private readonly IMongoServiceConnection<Visitor> _serviceConnection;
        private readonly IMongoCollection<Visitor> _collection;
        public VisitorApplication(IMongoServiceConnection<Visitor> serviceConnection)
        {
            _serviceConnection = serviceConnection;
            _collection = _serviceConnection.GetConnection();

        }

        public bool Create(CreateVisit command)
        {
            var Browser = new VisitorVersion(command.OperationSystem.Family,
                           command.OperationSystem.Version);

            var OperationSystem = new VisitorVersion(command.Browser.Family,
                             command.Browser.Version);

            var device = new Device(command.Device.Brand, command.Device.Family,
                command.Device.Model, command.Device.IsSpider);

            var visitor = new Visitor(command.Ip, command.CurrentLink, command.ReferrerLink,
                command.Method, command.Protocol, command.PhysicalPath,
                    Browser, OperationSystem, device, command.VisitorId);

            var resualt = _collection.InsertOneAsync(visitor);

            if (resualt.IsCompletedSuccessfully)
                return true;

            return false;
        }
    }
}
