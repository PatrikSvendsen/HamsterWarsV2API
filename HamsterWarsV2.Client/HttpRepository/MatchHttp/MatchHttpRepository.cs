using System.Text;
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

    public async Task CreateMatch(MatchForCreationDto matchForCreationDto)
    {
        var match = JsonSerializer.Serialize(matchForCreationDto);
        var requestContent = new StringContent(match, Encoding.UTF8, "application/json");
        var result = await _http.PostAsync("/matches", requestContent);
        
        var content = await result.Content.ReadAsStringAsync();
        if (result.IsSuccessStatusCode == false)
        {
            throw new ApplicationException(content);
        }

        var createdMatch = JsonSerializer.Deserialize<MatchDto>(content, _options);
    }

    public async Task DeleteMatch(int id)
    {
        var result = await _http.DeleteAsync($"/matches/{id}");
        var content = await result.Content.ReadAsStringAsync();
        if (result.IsSuccessStatusCode == false)
        {
            throw new ApplicationException(content);
        }
    }

    public async Task<List<MatchDto>> GetHamsterMatches(int hamsterId)
    {
        var result = await _http.GetAsync($"/matchWinners/{hamsterId}");
        var content = await result.Content.ReadAsStringAsync();

        if (result.IsSuccessStatusCode == false)
        {
            throw new ApplicationException(content);
        }

        var matches = JsonSerializer.Deserialize<List<MatchDto>>(content, _options);
        return matches;
    }

    public async Task<MatchDto> GetMatch(int id)
    {
        var result = await _http.GetAsync($"/matches/{id}");
        var content = await result.Content.ReadAsStringAsync();
        if (result.IsSuccessStatusCode == false)
        {
            throw new ApplicationException(content);
        }

        var match = JsonSerializer.Deserialize<MatchDto>(content, _options);
        return match;
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
