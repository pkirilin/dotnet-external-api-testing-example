using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading;
using ExternalApiTestingExample.WebApi.Dtos;
using FluentAssertions;
using Xunit;

namespace ExternalApiTestingExample.Tests.GetTodos;

public class GetTodosTests
{
    private readonly CustomWebApplicationFactory _factory = new();

    private static IEnumerable<TodoItemDto> TodosFromExternalResource => new[]
    {
        new TodoItemDto { Id = 1, Title = "first", IsCompleted = true, UserId = 1 },
        new TodoItemDto { Id = 2, Title = "second", IsCompleted = false, UserId = 1 },
        new TodoItemDto { Id = 3, Title = "third", IsCompleted = true, UserId = 2 }
    };

    [Fact]
    public async void Gets_all_todos_from_external_resource()
    {
        var client = _factory
            .UseFakeTodosClient(_ => _.WithTodosResponse(TodosFromExternalResource))
            .CreateClient();

        var todos = await client.GetFromJsonAsync<TodoItemDto[]>("/todos", CancellationToken.None);
        
        todos.Should().BeEquivalentTo(TodosFromExternalResource);
    }

    [Fact]
    public async void Gets_completed_todos_from_external_resource()
    {
        var client = _factory
            .UseFakeTodosClient(_ => _.WithTodosResponse(TodosFromExternalResource))
            .CreateClient();

        var todos = await client.GetFromJsonAsync<TodoItemDto[]>("/todos/completed", CancellationToken.None);
        
        todos.Should().BeEquivalentTo(new []
        {
            new TodoItemDto { Id = 1, Title = "first", IsCompleted = true, UserId = 1 },
            new TodoItemDto { Id = 3, Title = "third", IsCompleted = true, UserId = 2 }
        });
    }
}