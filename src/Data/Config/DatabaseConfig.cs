#nullable disable
namespace API.Data.Cosmere.Config;

public class DatabaseConfig
{
    public string Host { get; set; }
    public string User { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
}