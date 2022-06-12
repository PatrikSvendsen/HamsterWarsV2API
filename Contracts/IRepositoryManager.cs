using Contracts.ModelContracts;

namespace Contracts;

public interface IRepositoryManager
{
    IHamsterRepository Hamster { get; }
    IMatchRepository Match { get; }
    IUserRepository User { get; }
    Task SaveAsync();
}
