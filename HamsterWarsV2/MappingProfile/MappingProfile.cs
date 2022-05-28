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
        
        //TODO Här bör en Mapping ligga så att en lista fylls med hamstrar.
        // Länk finns i dokumentet.

        CreateMap<HamsterForCreationDto, Hamster>();
        CreateMap<MatchForCreationDto, Match>();
        CreateMap<HamsterDto, List<Hamster>>();

        CreateMap<List<Hamster>, HamsterDto>();
    }
}
