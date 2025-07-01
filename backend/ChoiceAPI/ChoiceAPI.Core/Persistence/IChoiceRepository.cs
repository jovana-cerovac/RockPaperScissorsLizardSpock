using ChoiceAPI.Core.Domain;
using CSharpFunctionalExtensions;

namespace ChoiceAPI.Core.Persistence;

public interface IChoiceRepository
{
    IEnumerable<Choice> GetAllChoices();

    Maybe<Choice> GetById(int id);

    Maybe<Choice> GetByName(string name);
}