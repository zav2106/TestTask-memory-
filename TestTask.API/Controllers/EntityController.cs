using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TestTask.API.Models;
using TestTask.Application.Services;
using TestTask.Infrastructure.Dtos;
using TestTask.Infrastructure.Services;

namespace TestTask.API.Controllers;

[ApiController]
public class EntityController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IEntityService _entityService;

    public EntityController(IMapper mapper, IEntityService entityService)
    {
        _entityService = entityService;
        _mapper = mapper;
    }


    [HttpGet("[controller]")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var dto = await _entityService.GetById(id);

        if (dto == null)
        {
            return NotFound();
        }

        return new JsonResult(_mapper.Map<EntityModel>(dto));
    }

    [HttpPost("[controller]/{entityJson}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Create(string entityJson)
    {
        var model = JsonSerializer.Deserialize<EntityModel>(entityJson, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        var dto = _mapper.Map<EntityDto>(model);

        await _entityService.Create(dto);

        return Ok();
    }
}