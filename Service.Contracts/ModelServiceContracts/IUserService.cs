using Shared.DataTransferObjects.User;

namespace Service.Contracts.ModelServiceContracts;

public interface IUserService
{

    /// <summary>
    /// Metod för att registrera användare.
    /// </summary>
    /// <param name="userRegister">Användare som skall registreras</param>
    /// <param name="password">Lösenord för användaren</param>
    Task<UserDto> RegisterAsync(UserRegisterDto userRegister, string password);
    /// <summary>
    /// Metod för att ta bort användare, skickar frågan vidare till repositorylagret
    /// </summary>
    Task DeleteUserAsync(string email, bool trackChanges);
    /// <summary>
    /// Metod för att hämta en specifik användare
    /// </summary>
    /// <param name="email">Email på den användare som skall hämtas</param>
    /// <param name="trackChanges"></param>
    Task<UserDto> GetUserByEmailAsync(string email, bool trackChanges);
    /// <summary>
    /// Metod för att kontrollera inloggningen. Kollar om användaren finns, är en admin och att lösenordet är korrekt.
    /// </summary>
    /// <param name="userLogin">Användaren som vill logga in</param>
    /// <returns>Returnerar true om användaren är OK att få logga in</returns>
    Task<bool> LoginAsync(UserLoginDto userLogin, bool trackChanges);

}
