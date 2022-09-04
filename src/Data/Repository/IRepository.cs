namespace API.Cosmere.Data.Model
{
    public interface IRepository<T> where T : class
    {
        public Task SaveAsync(T value);
        public Task<T?> GetAsync(int id);
        public Task<List<T>> ListAsync();
    }
}