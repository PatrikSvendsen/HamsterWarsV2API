using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.Hamster;
using Shared.DataTransferObjects.Match;
using Shared.DataTransferObjects.User;

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

        CreateMap<UserDto, UserRegisterDto>();

        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();

        CreateMap<UserRegister, UserRegisterDto>();

        CreateMap<UserRegister, UserDto>();
        CreateMap<UserDto, UserRegister>();

        CreateMap<UserRegisterDto, UserRegister>();
    }
}
