using MongoDB.Driver;

namespace TopTaz.Application.ContextACL
{
    public interface IMongoServiceConnection<TEntity>
    {
        IMongoCollection<TEntity> GetConnection(string connection = "VisitorDb");
    }
}
