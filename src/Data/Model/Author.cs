namespace API.Cosmere.Data.Model;

public class Author : IDbEntity
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string Name { get; set; } = null!;
    public List<Book> Books { get; set; } = new List<Book>();
}
