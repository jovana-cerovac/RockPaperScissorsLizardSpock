using ChoiceAPI.Core.Domain;
using ChoiceAPI.Core.Persistence;

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

    public Choice? GetById(int id) => Choices.FirstOrDefault(choice => choice.Id == id);

    public int GetTotalCount() => Choices.Count;
}