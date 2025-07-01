using ChoiceAPI.Core.Domain;
using ChoiceAPI.Core.Persistence;
using CSharpFunctionalExtensions;

namespace ChoiceAPI.Infrastructure.Persistence;

public class ChoiceRepository : IChoiceRepository
{
    private static readonly List<Choice> Choices = new()
    {
        new RockChoice(),
        new PaperChoice(),
        new ScissorsChoice(),
        new LizardChoice(),
        new SpockChoice()
    };

    public IEnumerable<Choice> GetAllChoices() => Choices;

    public Maybe<Choice> GetById(int id)
    {
        return Choices.FirstOrDefault(choice => choice.Id == id);
    }

    public Maybe<Choice> GetByName(string name)
    {
        return Choices.FirstOrDefault(choice =>
            string.Equals(choice.Name, name, StringComparison.OrdinalIgnoreCase));
    }
}