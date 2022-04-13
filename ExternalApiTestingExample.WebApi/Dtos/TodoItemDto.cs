using System.Text.Json.Serialization;

namespace ExternalApiTestingExample.WebApi.Dtos;

// ReSharper disable once ClassNeverInstantiated.Global
public class TodoItemDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = null!;

    [JsonPropertyName("completed")]
    public bool IsCompleted { get; set; }

    [JsonPropertyName("userId")]
    public int UserId { get; set; }
}