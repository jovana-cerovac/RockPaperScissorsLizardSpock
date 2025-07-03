using ChoiceAPI.Core.Domain;

namespace ChoiceAPI.Core.Persistence;

public interface IChoiceRepository
{
    Task<IEnumerable<Choice>> GetAllChoicesAsync();

    Task<Choice?> GetByIdAsync(int id);

    Task<int> GetTotalCountAsync();
}