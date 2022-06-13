using Shared.DataTransferObjects.User;

namespace Service.Contracts.ModelServiceContracts;

public interface IUserService
{
    /// <summary>
    /// Metod för att registrera användare
    /// </summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <param name="trackChanges"></param>
    /// <returns></returns>
    Task<UserDto> RegisterAsync(UserRegisterDto user, string password);

    Task DeleteUserAsync(int id, bool trackChanges);

    Task<bool> UserExistsAsync(string email, bool trackChanges);
}
