using Shared.DataTransferObjects.Match;

namespace Service.Contracts.ModelServiceContracts;

public interface IMatchService
{
    IEnumerable<MatchDto> GetMatches(bool trackChanges);
    MatchDto GetMatch(int matchId, bool trackChanges);
}
