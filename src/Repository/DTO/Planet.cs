#nullable disable
namespace API.Cosmere.Repository.DTO;

public class Planet
{
    public string Name { get; set; }
    public string Url { get; set; }
    public List<string> Books { get; set; }
}