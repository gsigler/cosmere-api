#nullable disable
namespace API.Cosmere.Repository.DTO;

public class Shard
{
    public int Id { get; set; }
    public string Url { get; set; }
    public string Name { get; set; }
    public string Vessel { get; set; }
    public List<string> Slivers { get; set; }
    public List<string> Magics { get; set; }
    public List<string> Books { get; set; }
    public List<string> Planets { get; set; }

}