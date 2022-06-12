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

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger
        , IMapper mapper)
    {
        _hamsterService = new Lazy<IHamsterService>(() => new
        HamsterService(repositoryManager, logger, mapper));
        _matchService = new Lazy<IMatchService>(() => new
        MatchService(repositoryManager, logger, mapper));
    }

    public IHamsterService HamsterService => _hamsterService.Value;
    public IMatchService MatchService => _matchService.Value;

}
