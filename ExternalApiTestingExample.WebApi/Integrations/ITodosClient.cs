using ExternalApiTestingExample.WebApi.Dtos;

namespace ExternalApiTestingExample.WebApi.Integrations;

public interface ITodosClient
{
    Task<TodoItemDto[]?> GetTodosAsync(CancellationToken cancellationToken);
}