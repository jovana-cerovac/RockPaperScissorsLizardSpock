using System.ComponentModel.DataAnnotations;

namespace GameAPI.Infrastructure.Settings;

public class ChoicesApiSettings
{
    public const string SectionName = "ApiSettings";

    [Required] public required string BaseAddress { get; init; }
}