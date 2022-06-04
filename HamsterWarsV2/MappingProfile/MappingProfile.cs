using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.Hamster;
using Shared.DataTransferObjects.Match;

namespace HamsterWarsV2.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Hamster, HamsterDto>();
        CreateMap<Match, MatchDto>();
        CreateMap<HamsterForCreationDto, Hamster>();
        CreateMap<MatchForCreationDto, Match>();
        CreateMap<HamsterToUpdateDto, Hamster>();
        CreateMap<HamsterDto, List<Hamster>>();
        CreateMap<List<Hamster>, HamsterDto>();
    }
}
