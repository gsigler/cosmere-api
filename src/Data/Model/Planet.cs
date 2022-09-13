#nullable disable
namespace API.Cosmere.Data.Model;

public class Planet : IDbEntity
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string Name { get; set; }
    public System System { get; set; }
    public List<Book> Books { get; set; }
    public List<Shard> Shards { get; set; }
}
