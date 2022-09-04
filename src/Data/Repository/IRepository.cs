namespace API.Cosmere.Data.Model
{
    public interface IRepository<T> where T : class
    {
        public void Save(T value);
        public List<T> List();
    }
}