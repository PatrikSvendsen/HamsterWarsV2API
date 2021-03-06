using Contracts;
using Contracts.ModelContracts;
using Repository.ModelRepositories;

namespace Repository;
public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IHamsterRepository> _hamsterRepository;
    private readonly Lazy<IMatchRepository> _matchRepository;
    private readonly Lazy<IUserRepository> _userRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _hamsterRepository = new Lazy<IHamsterRepository>(() =>
        new HamsterRepository(repositoryContext));
        _matchRepository = new Lazy<IMatchRepository>(() =>
        new MatchRepository(repositoryContext));
        _userRepository = new Lazy<IUserRepository>(() =>
        new UserRepository(repositoryContext));
    }

    public IHamsterRepository Hamster => _hamsterRepository.Value;
    public IMatchRepository Match => _matchRepository.Value;
    public IUserRepository User => _userRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
