using Entities.Models;

namespace Contracts.ModelContracts;

public interface IUserRepository
{
    /// <summary>
    /// Metod för att registrera användare
    /// </summary>
    /// <param name="user">Den användare som skall registreras</param>
    void RegisterUser(User user);
    /// <summary>
    /// Metod för att ta bort användare
    /// </summary>
    /// <param name="user">Den användare som skall tas bort</param>
    void DeleteUser(User user);
    /// <summary>
    /// Metod för att hämta en specifik användare
    /// </summary>
    /// <param name="email">Email på den användare som sakk hämtas</param>
    /// <returns></returns>
    Task<User> GetUserByEmail(string email, bool trackChanges);
}
