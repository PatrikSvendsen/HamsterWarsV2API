using Contracts.ModelContracts;
using Entities.Models;

namespace Repository.ModelRepositories;

internal sealed class MatchRepository : RepositoryBase<Match>, IMatchRepository
{
    public MatchRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public void CreateMatch(Match match) => Create(match);

    public Match GetMatch(int matchId, bool trackChanges) =>
        FindByCondition(m => m.Id.Equals(matchId), trackChanges)
        .SingleOrDefault();

    public IEnumerable<Match> GetMatches(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(e => e.WinnerId)
        .ToList();
}
