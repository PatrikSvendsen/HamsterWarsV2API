using Contracts.ModelContracts;
using Entities.Models;

namespace Repository.ModelRepositories;

public class MatchRepository : RepositoryBase<Match>, IMatchRepository
{
    public MatchRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }
}
