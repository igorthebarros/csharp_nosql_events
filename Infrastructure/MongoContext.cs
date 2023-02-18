using Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure
{
    public class MongoContext : IMongoContext
    {
        private IMongoDatabase _database { get; set; } 
        private IMongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; private set; }

        public MongoContext(IOptions<MongoSettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionURI);
            _database = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            var collection = _database.GetCollection<T>(name);

            if (collection == null)
                return null;

            return collection;
        }
    }
}
