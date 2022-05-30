using Contracts.ModelContracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.ModelRepositories;

internal sealed class MatchRepository : RepositoryBase<Match>, IMatchRepository
{
    public MatchRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public void CreateMatch(Match match) => Create(match);

    public void DeleteMatch(Match match) => Delete(match);

    public async Task<Match> GetMatchAsync(int matchId, bool trackChanges) =>
        await FindByCondition(m => m.Id.Equals(matchId), trackChanges)
        .SingleOrDefaultAsync();

    public async Task<IEnumerable<Match>> GetMatchesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(e => e.WinnerId)
        .ToListAsync();
}
