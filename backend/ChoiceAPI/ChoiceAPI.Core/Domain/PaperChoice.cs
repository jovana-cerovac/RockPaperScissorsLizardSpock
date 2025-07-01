namespace ChoiceAPI.Core.Domain;

public class PaperChoice : Choice
{
    public override int Id => 2;
    
    public override string Name => "Paper";

    public override bool BeatsOtherChoice(Choice other)
    {
        return other is RockChoice or SpockChoice;
    }
}