namespace GameAPI.Core.Contracts;

public class PlayResponse(string results, int player, int computer)
{
    public string Results { get; } = results;
    public int Player { get; } = player;
    public int Computer { get; } = computer;
}