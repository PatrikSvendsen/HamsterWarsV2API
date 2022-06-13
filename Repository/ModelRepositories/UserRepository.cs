
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

    public void RegisterUser(User user) => Create(user);

    public void DeleteUser(User user) => Delete(user);

    public async Task<bool> UserExist(string email, bool trackChanges) =>
        await FindByCondition(user => user.Email.ToLower().Equals(email.ToLower()), trackChanges).AnyAsync();




}
