namespace ChoiceAPI.Core.Services.Abstractions;

public interface IRandomNumberService
{
    Task<int> GetRandomNumberAsync();
}