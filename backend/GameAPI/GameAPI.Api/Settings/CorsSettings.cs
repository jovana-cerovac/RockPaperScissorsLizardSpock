namespace GameAPI.Api.Settings;

public class CorsSettings
{
    public const string SectionName = "Cors";
    
    public string[] AllowedOrigins { get; set; }
}