namespace API.Cosmere.Repository;

public interface IRepository<T>
{
    public Task SaveAsync(T value);
    public Task<T?> GetAsync(int id);
    public Task<List<T>> ListAsync();
}
