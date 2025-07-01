using ChoiceAPI.Core.Domain;

namespace ChoiceAPI.Core.Contracts;

public class ChoiceResponse
{
    public int Id { get; }
    public string Name { get; }

    private ChoiceResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public static ChoiceResponse FromDomain(Choice choice)
    {
        return new ChoiceResponse(choice.Id, choice.Name);
    }
}