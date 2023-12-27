using TestTask.Infrastructure.Dtos;

namespace TestTask.Infrastructure.Services;

public interface IEntityService
{
    Task<EntityDto?> GetById(Guid id);

    Task Create(EntityDto entity);
}
