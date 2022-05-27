using Contracts.ModelContracts;
using Entities.Models;

namespace Repository.ModelRepositories;

internal sealed class MatchRepository : RepositoryBase<Match>, IMatchRepository
{
    public MatchRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }
}
