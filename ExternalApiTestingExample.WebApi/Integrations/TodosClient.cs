using ExternalApiTestingExample.WebApi.Dtos;

namespace ExternalApiTestingExample.WebApi.Integrations;

public class TodosClient : ITodosClient
{
    private readonly HttpClient _client;

    public TodosClient(HttpClient client)
    {
        _client = client;
    }
    
    public Task<TodoItemDto[]?> GetTodosAsync(CancellationToken cancellationToken)
    {
        return _client.GetFromJsonAsync<TodoItemDto[]>("/todos", cancellationToken);
    }
}