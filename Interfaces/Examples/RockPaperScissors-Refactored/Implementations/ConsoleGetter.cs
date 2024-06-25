using RockPaperScissors.Interfaces;

namespace RockPaperScissors.Implementations;

public class ConsoleGetter : IChoiceGetter
{
    public Choice GetChoice()
    {
        return ConsoleIO.GetUserChoice();
    }
}
