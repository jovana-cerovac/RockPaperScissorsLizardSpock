using System.Text.Json;
using GameAPI.Core.Contracts;
using GameAPI.Core.Exceptions;
using GameAPI.Core.Services.Abstractions;

namespace GameAPI.Infrastructure.Services;

public class ChoicesApiClient(HttpClient httpClient) : IChoicesApiClient
{
    public async Task<ChoiceResponse> GetChoiceByIdAsync(int id)
    {
        var response = await httpClient.GetAsync(id.ToString());
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<ChoiceResponse>(content);

        if (result == null)
        {
            throw new InvalidApiResponseException("Invalid response from the ChoiceAPI.");
        }

        return result;
    }

    public async Task<ChoiceResponse> GetRandomChoiceAsync()
    {
        var response = await httpClient.GetAsync("random-choice");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<ChoiceResponse>(content);

        if (result == null)
        {
            throw new InvalidApiResponseException("Invalid response from the ChoiceAPI.");
        }

        return result;
    }
}

