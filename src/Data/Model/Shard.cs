namespace API.Cosmere.Data.Model;

public class Shard : IDbEntity
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string Name { get; set; } = null!;
}
