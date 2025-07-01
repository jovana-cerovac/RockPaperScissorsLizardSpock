namespace ChoiceAPI.Core.Domain;

public class ScissorsChoice : Choice
{
    public override int Id => 3;

    public override string Name => "Scissors";

    public override bool BeatsOtherChoice(Choice other) => other is PaperChoice or LizardChoice;
}