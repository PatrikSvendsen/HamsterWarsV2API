using Contracts.ModelContracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.ModelRepositories;

internal sealed class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public Task<int> Register(User user, string password)
    {

    }

    public async Task<bool> UserExist(string email, bool trackChanges) =>
        await FindByCondition(user => user.Email.ToLower().Equals(email.ToLower()), trackChanges).AnyAsync();
}
