using System.Text.Json.Serialization;

namespace ChoiceAPI.Infrastructure.Services;

public class RandomNumberResponse
{
    [JsonPropertyName("random_number")]
    public int RandomNumber { get; set; }
}