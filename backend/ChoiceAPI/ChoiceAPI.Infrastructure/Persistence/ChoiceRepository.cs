using ChoiceAPI.Core.Domain;
using ChoiceAPI.Core.Persistence;

namespace ChoiceAPI.Infrastructure.Persistence;

public class ChoiceRepository : IChoiceRepository
{
    private static readonly List<Choice> Choices =
    [
        new RockChoice(),
        new PaperChoice(),
        new ScissorsChoice(),
        new LizardChoice(),
        new SpockChoice()
    ];

    public Task<IEnumerable<Choice>> GetAllChoicesAsync() => Task.FromResult<IEnumerable<Choice>>(Choices);

    public Task<Choice?> GetByIdAsync(int id) => Task.FromResult(Choices.FirstOrDefault(choice => choice.Id == id));

    public Task<int> GetTotalCountAsync() => Task.FromResult(Choices.Count);
}