using System.Text.Json.Serialization;

namespace GameAPI.Core.Contracts;

public class ChoiceResponse
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;
}