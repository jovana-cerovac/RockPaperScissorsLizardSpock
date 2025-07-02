using System.Text.Json;
using ChoiceAPI.Core.Exceptions;
using ChoiceAPI.Core.Services.Abstractions;

namespace ChoiceAPI.Infrastructure.Services;

public class RandomNumberService(HttpClient httpClient) : IRandomNumberService
{
    private const int MinRandomNumber = 1;
    private const int MaxRandomNumber = 100;
    
    public async Task<int> GetRandomNumberAsync()
    {
        var response = await httpClient.GetAsync("random");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<RandomNumberResponse>(content);

        if (result == null || result.RandomNumber < MinRandomNumber || result.RandomNumber > MaxRandomNumber)
        {
            throw new InvalidApiResponseException("Invalid response from the random number API.");
        }

        return result.RandomNumber;
    }
}