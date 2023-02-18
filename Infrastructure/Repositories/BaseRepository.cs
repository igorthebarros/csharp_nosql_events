using Domain.Interfaces;
using Infrastructure.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IMongoContext _context;
        protected IMongoCollection<T> _collection;
        public BaseRepository(IMongoContext mongoContext)
        {
            _context = mongoContext;
            _collection = _context.GetCollection<T>(typeof(T).Name);
        }

        public async Task<T> GetAsync(string id)
        {
            var objectId = new ObjectId(id);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", objectId);

            var result = await _collection.FindAsync<T>(filter).Result.FirstOrDefaultAsync();

            if (result == null)
                throw new Exception($"Database Error: Can not find object of ID: {id}");

            Console.WriteLine(result);
            return result;
        }

        public IEnumerable<T> GetAll(string sql)
        {
            throw new NotImplementedException();
        }

        public void Save(T person)
        {
            throw new NotImplementedException();
        }

        public void Update(T person)
        {
            throw new NotImplementedException();
        }
    }
}
