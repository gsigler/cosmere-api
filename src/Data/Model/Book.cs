using System.ComponentModel.DataAnnotations.Schema;

namespace API.Cosmere.Data.Model;

public class Book : IDbEntity
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string Title { get; set; } = null!;
    public List<Author> Authors { get; set; } = new List<Author>();
    public List<Illustrator> Illustrators { get; set; } = new List<Illustrator>();
    public DateTime PublicationDate { get; set; }
    public int Pages { get; set; }
    public int WordCount { get; set; }
    public List<Planet> Planets { get; set; } = new List<Planet>();

    public int? PrecededById { get; set; }
    public int? FollowedById { get; set; }
    [ForeignKey("FollowedById")]
    public Book? FollowedBy { get; set; }
    [ForeignKey("PrecededById")]
    public Book? PrecededBy { get; set; }


}
