using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ExternalApiTestingExample.WebApi.Dtos;

namespace ExternalApiTestingExample.Tests.GetTodos;

public class FakeTodosClientHandler : HttpMessageHandler
{
    private HttpStatusCode _statusCode = HttpStatusCode.OK;
    private HttpContent? _responseContent;
    
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = new HttpResponseMessage(_statusCode)
        {
            Content = _responseContent
        };
        
        return Task.FromResult(response);
    }

    public FakeTodosClientHandler WithTodosResponse(IEnumerable<TodoItemDto> todos)
    {
        _statusCode = HttpStatusCode.OK;
        _responseContent = new StringContent(JsonSerializer.Serialize(todos));
        return this;
    }
}