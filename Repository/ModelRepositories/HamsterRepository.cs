using Contracts.ModelContracts;
using Entities.Models;

namespace Repository.ModelRepositories;

public class HamsterRepository : RepositoryBase<Hamster>, IHamsterRepository
{
    public HamsterRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }
}
