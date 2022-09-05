namespace API.Cosmere.Data.Model
{
    public interface IDbEntity
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}