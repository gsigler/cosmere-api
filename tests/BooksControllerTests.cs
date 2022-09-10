using System.Text.Json;
using Shouldly;

public class BooksControllerTests : IClassFixture<TestingWebAppFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _jsonOptions;

    public BooksControllerTests(TestingWebAppFactory<Program> factory)
    {
        _client = factory.CreateClient();
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    [Fact]
    public async Task Books_ReturnsListOfBooks()
    {
        var response = await _client.GetAsync("/api/books");

        response.EnsureSuccessStatusCode();

        var books = JsonSerializer.Deserialize<List<API.Cosmere.Repository.DTO.Book>>(await response.Content.ReadAsStringAsync(), _jsonOptions);

        books.ShouldNotBeNull();
        books.ShouldNotBeEmpty();
    }

    [Fact]
    public async Task Books_WithId_ReturnsOneBook()
    {
        var response = await _client.GetAsync("/api/books/1");

        response.EnsureSuccessStatusCode();

        var book = JsonSerializer.Deserialize<API.Cosmere.Repository.DTO.Book>(await response.Content.ReadAsStringAsync(), _jsonOptions);

        book.ShouldNotBeNull();
        book.Title.ShouldBe("The Way of Kings");

    }
}