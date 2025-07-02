namespace GameAPI.Core.Contracts;

public class PlayResponse
{
    public string Results { get; }
    public int Player { get; }
    public int Computer { get; }
    
    public PlayResponse(string results, int player, int computer)
    {
        Results = results;
        Player = player;
        Computer = computer;
    }
}