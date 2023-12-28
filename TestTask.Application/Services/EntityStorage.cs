using System.Collections.Concurrent;
using TestTask.Domain.BusinessObjects;
using TestTask.Infrastructure.Services;

namespace TestTask.Application.Services;

public class EntityStorage : IEntityStorage
{
    private readonly ConcurrentDictionary<Guid, Entity> _entityStorage;

    public EntityStorage()
    {
        _entityStorage = new ConcurrentDictionary<Guid, Entity>();
    }

    public Entity? GetById(Guid id)
    {
        if (_entityStorage.TryGetValue(id, out var entity))
            return entity;

        return null;
    }

    public void Add(Entity entity)
    {
        _entityStorage.AddOrUpdate(entity.Id, entity, (key, oldvalue) => throw new InvalidOperationException("An entry with same key already exists."));
    }
}