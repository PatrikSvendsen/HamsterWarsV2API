using Entities.Models;

namespace Contracts.ModelContracts;

public interface IMatchRepository
{
    /// <summary>
    /// Metod för att hämta alla matcher från databasen
    /// </summary>
    /// <returns>En Lista av alla matcher i form av IEnumerable</returns>
    IEnumerable<Match> GetMatches(bool trackChanges);
    /// <summary>
    /// Metod för att hämta en specifik match från databasen.
    /// </summary>
    /// <param name="matchId">Specifikt id på matchen som skall hämtas. </param>
    /// <returns>Ett objekt som representerar den match som matchar id.</returns>
    Match GetMatch(int matchId, bool trackChanges);
    /// <summary>
    /// Metod som skapar ett opjekt i databasen utifrån inkommande.
    /// </summary>
    /// <param name="match">Det objekt som skall skapas i databasen</param>
    void CreateMatch(Match match);
    /// <summary>
    /// Metod för att ta bort specifik match i databasen
    /// </summary>
    void DeleteMatch(Match match);
}
