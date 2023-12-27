using System.Collections.Concurrent;

namespace TestTask.Domain.Entity;

public class EntityService : IEntityService
{
    private ConcurrentDictionary<Guid, Entity> _entities = new ConcurrentDictionary<Guid, Entity>();
    public async Task<Entity> GetById(Guid entityId)
    {
        return await Task.Run(() => _entities.GetValueOrDefault(entityId));
    }

    public async Task<bool> Create(Entity entity)
    {
        if (_entities.ContainsKey(entity.Id))
            return false;

        _entities.TryAdd(entity.Id, entity);
        return true;
    }
}