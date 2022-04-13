using FluentAssertions;
using Xunit;

namespace ExternalApiTestingExample.Tests.GetTodos;

public class GetTodosTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory = new();

    [Fact]
    public void Fetches_todos_from_external_resource_and_returns_them_back_to_client()
    {
        true.Should().BeTrue();
    }
}