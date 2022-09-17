#nullable disable
namespace API.Cosmere.Repository.DTO;

public class Planet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public List<string> Books { get; set; }
}