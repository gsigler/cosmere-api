#nullable disable
namespace API.Cosmere.Data.Model;
public class Realm : IDbEntity
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string Name { get; set; }

}
