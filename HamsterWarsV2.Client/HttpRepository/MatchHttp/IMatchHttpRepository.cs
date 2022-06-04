using Shared.DataTransferObjects.Match;

namespace HamsterWarsV2.Client.HttpRepository.MatchHttp;

public interface IMatchHttpRepository
{

    /// <summary>
    /// Metod för att hämta alla matcher
    /// </summary>
    /// <returns>Returnerar en lista med alla matcher.</returns>
    Task<List<MatchDto>> GetMatches();
    /// <summary>
    /// Metod för att hämta specific match via Id
    /// </summary>
    /// <returns>Returnerar en match om Id matchar</returns>
    Task<MatchDto> GetMatch(int id);
    /// <summary>
    /// Metod för att ta bort en match
    /// </summary>
    Task DeleteMatch(int id);
    /// <summary>
    /// Metod för att skapa en match.
    /// </summary>
    Task CreateMatch(MatchForCreationDto matchForCreationDto);
    /// <summary>
    /// Metod för att hämta alla matcher där hamster id matchar WinnerId.
    /// </summary>
    Task<List<MatchDto>> GetHamsterMatches(int hamsterId);
}
