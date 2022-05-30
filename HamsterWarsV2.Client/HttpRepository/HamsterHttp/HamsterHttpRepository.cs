using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Shared.DataTransferObjects.Hamster;

namespace HamsterWarsV2.Client.HttpRepository.HamsterHttp;

public class HamsterHttpRepository : IHamsterHttpRepository
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _options;

    public HamsterHttpRepository(HttpClient http)
    {
        _http = http;
        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
    }

    public async Task<HamsterDto> CreateHamster(HamsterForCreationDto hamsterForCreationDto)
    {
        var hamster = JsonSerializer.Serialize(hamsterForCreationDto);
        var requestContent = new StringContent(hamster, Encoding.UTF8, "application/json");
        var response = await _http.PostAsync("/hamsters", requestContent);

        var content = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode == false)
        {
            throw new ApplicationException(content);
        }
        var createdHamster = JsonSerializer.Deserialize<HamsterDto>(content, _options);
        return createdHamster;
    }

    public async Task<HamsterDto> UpdateHamster(HamsterDto hamsterDto)
    {
        var hamster = JsonSerializer.Serialize(hamsterDto);
        var requestContent = new StringContent(hamster, Encoding.UTF8 , "application/json");
        var response = await _http.PutAsync("/hamsters", requestContent);
        var content = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode == false)
        {
            throw new ApplicationException(content);
        }
        var updatedHamster = JsonSerializer.Deserialize<HamsterDto>(content, _options);
        return updatedHamster;
    }

    public async Task DeleteHamster(int id)
    {
        var result = await _http.DeleteAsync($"/hamsters/{id}");
        var content = await result.Content.ReadAsStringAsync();
        if (result.IsSuccessStatusCode == false)
        {
            throw new ApplicationException(content);
        }
    }

    public async Task<HamsterDto> GetHamster(int id)
    {
        var result = await _http.GetAsync($"/hamsters/{id}");
        var content = await result.Content.ReadAsStringAsync();
        if (result.IsSuccessStatusCode == false)
        {
            throw new ApplicationException(content);
        }
        var hamster = JsonSerializer.Deserialize<HamsterDto>(content, _options);
        return hamster;
    }

    public async Task<List<HamsterDto>> GetHamsters()
    {
        var result = await _http.GetAsync("/hamsters");
        var content = await result.Content.ReadAsStringAsync();
        if (result.IsSuccessStatusCode == false)
        {
            throw new ApplicationException(content);
        }
        var hamsters = JsonSerializer.Deserialize<List<HamsterDto>>(content, _options);
        return hamsters;
    }

    public async Task<HamsterDto> GetRandomHamster()
    {
        var result = await _http.GetAsync("/hamsters/random");
        var content = await result.Content.ReadAsStringAsync();
        if (result.IsSuccessStatusCode == false)
        {
            throw new ApplicationException(content);
        }
        var randomHamster = JsonSerializer.Deserialize<HamsterDto>(content, _options);
        return randomHamster;
    }
}
