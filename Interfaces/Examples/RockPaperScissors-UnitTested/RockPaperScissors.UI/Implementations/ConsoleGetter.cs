using RockPaperScissors.UI.Interfaces;

namespace RockPaperScissors.UI.Implementations;

public class ConsoleGetter : IChoiceGetter
{
    public Choice GetChoice()
    {
        return ConsoleIO.GetUserChoice();
    }
}
