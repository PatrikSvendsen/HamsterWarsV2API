using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.Hamster;
using Shared.DataTransferObjects.Match;

namespace HamsterWarsV2.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Hamster, Shared.DataTransferObjects.Hamster.MatchDto>();
        CreateMap<Match, Shared.DataTransferObjects.Match.MatchDto>();
    }
}
