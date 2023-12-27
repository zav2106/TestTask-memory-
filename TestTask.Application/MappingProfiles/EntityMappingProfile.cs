using AutoMapper;
using TestTask.Domain.BusinessObjects;
using TestTask.Infrastructure.Dtos;

namespace TestTask.Application.MappingProfiles;

public class EntityMappingProfile : Profile
{
    public EntityMappingProfile()
    {
        CreateMap<Entity, EntityDto>()
            .ReverseMap();
    }
}