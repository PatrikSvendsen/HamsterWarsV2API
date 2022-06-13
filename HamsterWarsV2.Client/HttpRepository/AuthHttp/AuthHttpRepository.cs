using System.Text;
using System.Text.Json;

namespace HamsterWarsV2.Client.HttpRepository.AuthHttp;

public class AuthHttpRepository : IAuthHttpRepository
{

    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _options;
    public AuthHttpRepository(HttpClient http)
    {
        _http = http;
        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
    }

    public async Task<UserRegisterDto> RegisterUser(UserRegisterDto userRegisterDto)
    {
        var user = JsonSerializer.Serialize(userRegisterDto);
        var requestContent = new StringContent(user, Encoding.UTF8,
            "application/json");
        var response = await _http.PostAsync("/register", requestContent);

        var content = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode == false)
        {
            throw new ApplicationException(content);
        }

        var registeredUser = JsonSerializer.Deserialize<UserRegisterDto>(content);
        return registeredUser;
    }
}
