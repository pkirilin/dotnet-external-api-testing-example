using ExternalApiTestingExample.WebApi.Dtos;

namespace ExternalApiTestingExample.WebApi.Integrations;

public class TodosClient : ITodosClient
{
    public Task<TodoItemDto[]> GetTodosAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}