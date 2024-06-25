using RockPaperScissors.Interfaces;

namespace RockPaperScissors.Implementations;

public class RandomGetter : IChoiceGetter
{
    private static Random _random = new Random();

    public Choice GetChoice()
    {
        return (Choice)_random.Next(1, 4);
    }
}
