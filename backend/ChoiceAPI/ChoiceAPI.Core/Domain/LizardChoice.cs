namespace ChoiceAPI.Core.Domain;

public class LizardChoice : Choice
{
    public override int Id => 4;

    public override string Name => "Lizard";

    public override bool BeatsOtherChoice(Choice other) => other is SpockChoice or PaperChoice;
}