namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Save(T person);
        void Update(T person);
        IEnumerable<T> GetAll(string sql);
        Task<T> GetAsync(string id);
    }
}
