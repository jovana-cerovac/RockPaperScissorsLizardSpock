using System.Text.Json;
using GameAPI.Core.Services.Abstractions;

namespace GameAPI.Infrastructure.Services;

public class ChoiceService(HttpClient httpClient) : IChoiceService
{
    public async Task<ChoiceResponse> GetChoiceByIdAsync(int id)
    {
        var response = await httpClient.GetAsync(id.ToString());
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<ChoiceResponse>(content);

        if (result == null)
        {
            throw new InvalidOperationException("Invalid response from the random number API.");
        }

        return result;
    }
}

