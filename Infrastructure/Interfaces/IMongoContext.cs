using MongoDB.Driver;

namespace Infrastructure.Interfaces
{
    public interface IMongoContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
