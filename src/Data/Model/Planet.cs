#nullable disable
namespace API.Cosmere.Data.Model;

public class Planet : IDbEntity
{
    public int ID { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string Name { get; set; }
}
