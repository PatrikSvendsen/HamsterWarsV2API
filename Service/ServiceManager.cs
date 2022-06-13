using AutoMapper;
using Contracts;
using Service.Contracts;
using Service.Contracts.ModelServiceContracts;
using Service.ModelService;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IHamsterService> _hamsterService;
    private readonly Lazy<IMatchService> _matchService;
    private readonly Lazy<IUserService> _userService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger
        , IMapper mapper)
    {
        _hamsterService = new Lazy<IHamsterService>(() => new
        HamsterService(repositoryManager, logger, mapper));
        _matchService = new Lazy<IMatchService>(() => new
        MatchService(repositoryManager, logger, mapper));
        _userService = new Lazy<IUserService>(() => new
        UserService(repositoryManager, logger, mapper));
    }

    public IHamsterService HamsterService => _hamsterService.Value;
    public IMatchService MatchService => _matchService.Value;
    public IUserService UserService => _userService.Value;
}
