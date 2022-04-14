using System.Net.Http.Json;
using System.Threading;
using ExternalApiTestingExample.WebApi.Dtos;
using FluentAssertions;
using Xunit;

namespace ExternalApiTestingExample.Tests.GetTodos;

public class GetTodosTests
{
    private readonly CustomWebApplicationFactory _factory = new();

    [Fact]
    public async void Fetches_todos_from_external_resource_and_returns_them_back_to_client()
    {
        var todosFromExternalResource = new []
        {
            new TodoItemDto { Id = 1, Title = "first", IsCompleted = true, UserId = 1 },
            new TodoItemDto { Id = 2, Title = "second", IsCompleted = false, UserId = 1 },
            new TodoItemDto { Id = 3, Title = "third", IsCompleted = true, UserId = 2 },
        };

        var client = _factory
            .UseFakeTodosClient(_ => _.WithTodosResponse(todosFromExternalResource))
            .CreateClient();

        var todos = await client.GetFromJsonAsync<TodoItemDto[]>("/todos", CancellationToken.None);
        
        todos.Should().BeEquivalentTo(todosFromExternalResource);
    }
}