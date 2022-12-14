#nullable disable
namespace API.Cosmere.Repository.DTO;

public class Book
{
    public int Id { get; set; }
    public string Url { get; set; }
    public string Title { get; set; }
    public List<string> Authors { get; set; }
    public List<string> Illustrators { get; set; }
    public DateTime PublicationDate { get; set; }
    public List<string> Planets { get; set; }
    public int Pages { get; set; }
    public int WordCount { get; set; }
    public string FollowedBy { get; set; }
    public string PrecededBy { get; set; }

}