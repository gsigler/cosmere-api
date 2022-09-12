#nullable disable
namespace API.Cosmere.Data.Model;

public class Person : IDbEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}