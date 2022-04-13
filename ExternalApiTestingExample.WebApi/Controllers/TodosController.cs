using ExternalApiTestingExample.WebApi.Integrations;
using Microsoft.AspNetCore.Mvc;

namespace ExternalApiTestingExample.WebApi.Controllers;

[ApiController]
[Route("todos")]
public class TodosController : ControllerBase
{
    private readonly ITodosClient _todosClient;

    public TodosController(ITodosClient todosClient)
    {
        _todosClient = todosClient;
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos(CancellationToken cancellationToken)
    {
        var todos = await _todosClient.GetTodosAsync(cancellationToken);
        
        return Ok(todos);
    }
}
