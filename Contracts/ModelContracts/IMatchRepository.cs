using Entities.Models;

namespace Contracts.ModelContracts;

public interface IMatchRepository
{
    IEnumerable<Match> GetMatches(bool trackChanges);
    Match GetMatch(int matchId, bool trackChanges);
    void CreateMatch(Match match);
}
