using RockPaperScissors.UI;
using RockPaperScissors.UI.Interfaces;

namespace RockPaperScissors.Tests.TestImplementations;

public class AlwaysPicksScissors : IChoiceGetter
{
    public Choice GetChoice()
    {
        return Choice.Scissors;
    }
}
