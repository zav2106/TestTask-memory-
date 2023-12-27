namespace TestTask.Domain.Entity;

public interface IEntityService
{
    Task<Entity> GetById(Guid EntityId);

    Task<bool> Create(Entity entity);
}
