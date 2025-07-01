namespace ChoiceAPI.Core.Domain;

public class SpockChoice : Choice
{
    public override int Id => 5;
    
    public override string Name => "Spock";

    public override bool BeatsOtherChoice(Choice other)
    {
        return other is ScissorsChoice or RockChoice;
    }
}