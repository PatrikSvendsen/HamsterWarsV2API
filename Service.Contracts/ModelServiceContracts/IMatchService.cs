using Shared.DataTransferObjects.Match;

namespace Service.Contracts.ModelServiceContracts;

public interface IMatchService
{
    /// <summary>
    /// Metod som hämtar alla matcher. 
    /// </summary>
    /// <returns>Returnerar en lista av alla matcher. Returnerar NotFoundException om inga matcher finns.</returns>
    Task<IEnumerable<MatchDto>> GetMatchesAsync(bool trackChanges);
    /// <summary>
    /// Metod som hämtar en specifik match.
    /// </summary>
    /// <param name="matchId">Id på match som skall hämtas</param>
    /// <returns>Returnerar matchen om den finns annars en NotFoundException.</returns>
    Task<MatchDto> GetMatchAsync(int id, bool trackChanges);
    /// <summary>
    /// Metod som skapar en match utifrån objektet som kommer från clienten.
    /// </summary>
    /// <returns></returns>
    Task<MatchDto> CreateMatchAsync(MatchForCreationDto matchForCreationDto, bool trackChanges);
    /// <summary>
    /// Metod som tar bort en match.
    /// </summary>
    Task DeleteMatchAsync(int id, bool trackChanges);
    /// <summary>
    /// Metod som hämtar alla vunna matchar här hamsterId matchar.
    /// </summary>
    /// <param name="hamsterId">Id på den hamstern</param>
    /// <returns>Om det finns vunna matchar som returneras den i en lista.</returns>
    Task<IEnumerable<MatchDto>> GetAllHamsterMatchesAsync(int hamsterId, bool trackChanges);
}
