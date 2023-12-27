using AutoMapper;
using TestTask.Domain.BusinessObjects;
using TestTask.Infrastructure.Dtos;
using TestTask.Infrastructure.Services;

namespace TestTask.Application.Services;

public class EntityService : IEntityService
{
    private readonly IMapper _mapper;
    private readonly IEntityStorage _entityStorage;

    public EntityService(IMapper mapper, IEntityStorage entityStorage)
    {
        _mapper = mapper;
        _entityStorage = entityStorage;
    }

    public async Task<EntityDto> GetById(Guid id)
    {
        var entity = _entityStorage.GetById(id);

        var dto = _mapper.Map<EntityDto>(entity);

        return await Task.FromResult(dto);
    }

    public async Task Create(EntityDto dto)
    {
        var entity = _mapper.Map<Entity>(dto);

        _entityStorage.Add(entity);

        await Task.CompletedTask;
    }
}