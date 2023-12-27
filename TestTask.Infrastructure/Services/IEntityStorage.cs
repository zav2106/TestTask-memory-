using TestTask.Domain.BusinessObjects;

namespace TestTask.Infrastructure.Services;

public interface IEntityStorage
{
    Entity? GetById(Guid id);

    void Add(Entity entity);
}
