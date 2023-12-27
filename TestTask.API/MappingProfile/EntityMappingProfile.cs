using AutoMapper;
using TestTask.API.Models;
using TestTask.Infrastructure.Dtos;

namespace TestTask.API.MappingProfile;

public class EntityMappingProfile : Profile
{
    public EntityMappingProfile()
    {
        CreateMap<EntityModel, EntityDto>()
            .ReverseMap();
    }
}