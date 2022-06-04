using Entities.Models;

namespace Contracts.ModelContracts;

public interface IHamsterRepository
{
    /// <summary>
    /// Metod för att hämta alla hamstrar databasen
    /// </summary>
    /// <returns>Returnerar en lista av hamstrar om det finns något i databasen</returns>
    Task<IEnumerable<Hamster>> GetAllHamstersAsync(bool trackChanges);
    /// <summary>
    /// Metod för att hämta en specifik hamster ur databasen
    /// </summary>
    /// <param name="hamsterId">Id på det objekt som skall hämtas</param>
    /// <returns>Returnerar ett objekt om det finns i databasen</returns>
    Task<Hamster> GetHamsterAsync(int hamsterId, bool trackChanges);
    /// <summary>
    /// Metod för att skapa en hamster i databasen.
    /// </summary>
    /// <param name="hamster">Samling av information på den hamster som skall skapas.</param>
    void CreateHamster(Hamster hamster);
    /// <summary>
    /// Metod för att ta bort ett objekt ur databasen.
    /// </summary>
    /// <param name="hamster">Det objekt som skall tas bort</param>
    void DeleteHamster(Hamster hamster);
}
