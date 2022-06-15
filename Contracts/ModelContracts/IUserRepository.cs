using Entities.Models;

namespace Contracts.ModelContracts;

public interface IUserRepository
{
    void RegisterUser(User user);

    void DeleteUser(User user);

    Task<bool> UserExist(string email, bool trackChanges);

    Task<User> GetUserByEmail(string email, bool trackChanges);
}
