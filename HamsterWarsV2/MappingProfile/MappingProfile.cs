using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.Hamster;

namespace HamsterWarsV2.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Hamster, HamsterDto>();
    }
}
