#nullable disable
namespace API.Cosmere.Data.Model;

public class Book : IDbEntity
{
    public int ID { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string Title { get; set; }
    public List<string> Author { get; set; }
    public List<string> Illustrator { get; set; }
    public DateTime PublicationDate { get; set; }
    public int Pages { get; set; }
    // public Book FollowedBy { get; set; }
    // public Book PrecededBy { get; set; }

}
