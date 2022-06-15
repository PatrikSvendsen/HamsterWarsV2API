namespace HamsterWarsV2.Client.HttpRepository.AuthHttp;

public interface IAuthHttpRepository
{
    /// <summary>
    /// Metod för att skicka frågan till servern om att skapa en användare
    /// </summary>
    /// <param name="userRegisterDto">Användare som skall skapas</param>
    Task<UserRegisterDto> RegisterUser(UserRegisterDto userRegisterDto);

    /// <summary>
    /// Metod för att ta hand om inloggningen
    /// </summary>
    /// <param name="userLoginDto">Användare som logga in</param>
    Task<string> LoginUser(UserLoginDto userLoginDto);
}
