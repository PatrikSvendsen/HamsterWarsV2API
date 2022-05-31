using Shared.DataTransferObjects.Match;

namespace HamsterWarsV2.Client.HttpRepository.MatchHttp;

public interface IMatchHttpRepository
{
    Task<List<MatchDto>> GetMatches();
    Task<MatchDto> GetMatch(int id);
    Task DeleteMatch(int id);
    Task CreateMatch(MatchForCreationDto matchForCreationDto);
}
