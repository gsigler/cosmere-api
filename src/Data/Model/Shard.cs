#nullable disable
namespace API.Cosmere.Data.Model;

public class Shard : IDbEntity
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string Name { get; set; } = null!;
    public Person Vessel { get; set; }
    public ICollection<Person> Slivers { get; set; }
    public ICollection<Magic> Magics { get; set; }
    public ICollection<Book> Books { get; set; }
    public ICollection<Planet> Planets { get; set; }

}
