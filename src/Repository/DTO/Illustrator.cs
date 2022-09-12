#nullable disable
namespace API.Cosmere.Repository.DTO;

public class Illustrator
{
    public string Url { get; set; }
    public string Name { get; set; } = null!;
    public List<string> Books { get; set; } = new List<string>();
}