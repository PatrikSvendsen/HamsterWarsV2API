using Shared.DataTransferObjects.Match;

namespace Service.Contracts.ModelServiceContracts;

public interface IMatchService
{
    /// <summary>
    /// Metod som hämtar alla matcher. 
    /// </summary>
    /// <returns>Returnerar en lista av alla matcher. Returnerar NotFoundException om inga matcher finns.</returns>
    IEnumerable<MatchDto> GetMatches(bool trackChanges);
    /// <summary>
    /// Metod som hämtar en specifik match.
    /// </summary>
    /// <param name="matchId">Id på match som skall hämtas</param>
    /// <returns>Returnerar matchen om den finns annars en NotFoundException.</returns>
    MatchDto GetMatch(int id, bool trackChanges);
    /// <summary>
    /// Metod som skapar en match utifrån objektet som kommer från clienten.
    /// </summary>
    /// <returns></returns>
    MatchDto CreateMatch(MatchForCreationDto matchForCreationDto, bool trackChanges);
    /// <summary>
    /// Metod som tar bort en match.
    /// </summary>
    void DeleteMatch(int id, bool trackChanges);
}
