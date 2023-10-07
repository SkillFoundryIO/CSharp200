using TicTacToe.UI.Interfaces;

public class ComputerRandomPlayer : IPlayer
{
    public string Symbol { get; set; }
    public bool IsHuman { get; private set; } = false;

    private readonly Random _random;

    public ComputerRandomPlayer()
    {
        _random = new Random();
    }

    public byte GetPlacementPosition()
    {
        int position = _random.Next(1, 10);
        return (byte)position;
    }
}
