using System.Text.Json;

namespace HamsterWarsV2.Client.HttpRepository.MatchHttp;

public class MatchHttpRepository : IMatchHttpRepository
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _options;

    public MatchHttpRepository(HttpClient http)
    {
        _http = http;
        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
    }

    public Task<MatchDto> CreateMatch(MatchForCreationDto matchForCreationDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMatch(int id)
    {
        throw new NotImplementedException();
    }

    public Task<MatchDto> GetMatch(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<MatchDto>> GetMatches()
    {
        var result = await _http.GetAsync("matches");
        var content = await result.Content.ReadAsStringAsync();
        if (result.IsSuccessStatusCode == false)
        {
            throw new ApplicationException(content);
        }
        var matches = JsonSerializer.Deserialize<List<MatchDto>>(content, _options);
        return matches;
    }
}
