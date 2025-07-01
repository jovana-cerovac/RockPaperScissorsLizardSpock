using ChoiceAPI.Core.Domain;

namespace ChoiceAPI.Core.Persistence;

public interface IChoiceRepository
{
    IEnumerable<Choice> GetAllChoices();

    Choice? GetById(int id);

    int GetTotalCount();
}