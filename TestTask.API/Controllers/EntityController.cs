using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TestTask.Domain.Entity;

namespace TestTask.API.Controllers;

[ApiController]
[Route("entity")]
public class EntityController : ControllerBase
{
    private readonly IEntityService _entityService;

    public EntityController(IEntityService entityService)
    {
        _entityService = entityService;
    }

    [HttpGet("get")]
    [ProducesResponseType(typeof(int), 200)]
    public async Task<IActionResult> GetById([FromHeader] Guid entityId)
    {
        var result = await _entityService.GetById(entityId);
        
        if (result is null) { return NotFound(); }

        return Ok(result);
    }

    [HttpPost("post")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Create([FromBody] JsonElement body)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        var model = JsonSerializer.Deserialize<Entity>(body, options);

        var result =  await _entityService.Create(model);
        if (result) 
            return StatusCode(204);

        return BadRequest(result);
    }
}