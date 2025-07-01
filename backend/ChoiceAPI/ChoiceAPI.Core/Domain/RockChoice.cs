namespace ChoiceAPI.Core.Domain;

public class RockChoice : Choice
{
    public override int Id => 1;
    
    public override string Name => "Rock";

    public override bool BeatsOtherChoice(Choice other)
    {
        return other is ScissorsChoice or LizardChoice;
    }
}