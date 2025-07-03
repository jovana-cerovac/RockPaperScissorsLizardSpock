using System.ComponentModel.DataAnnotations;

namespace ChoiceAPI.Infrastructure.Settings;

public class RandomApiSettings
{
    public const string SectionName = "ApiSettings";

    [Required] public required string BaseAddress { get; init; }
}