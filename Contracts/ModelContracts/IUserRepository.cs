using Entities.Models;

namespace Contracts.ModelContracts;
public interface IUserRepository
{
    Task<int> Register(User user, string password);

    Task<bool> UserExist(string email, bool trackChanges);
}
