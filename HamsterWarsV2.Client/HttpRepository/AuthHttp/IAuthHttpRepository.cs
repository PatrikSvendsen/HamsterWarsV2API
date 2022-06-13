namespace HamsterWarsV2.Client.HttpRepository.AuthHttp;

public interface IAuthHttpRepository
{
    Task<UserRegisterDto> RegisterUser(UserRegisterDto userRegisterDto);
}
