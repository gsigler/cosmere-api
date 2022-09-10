namespace API.Cosmere.Data.Model
{
    public interface IDbEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}