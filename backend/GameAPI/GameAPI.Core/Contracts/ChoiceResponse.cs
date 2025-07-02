using System.Text.Json.Serialization;

namespace GameAPI.Core.Contracts;

public class ChoiceResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]

    public string Name { get; set; } = string.Empty;
}