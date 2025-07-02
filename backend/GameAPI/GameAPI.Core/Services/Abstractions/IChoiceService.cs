namespace GameAPI.Core.Services.Abstractions;

public interface IChoiceService
{
    Task<ChoiceResponse> GetChoiceByIdAsync(int id);
}

public class ChoiceResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}