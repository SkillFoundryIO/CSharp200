using RockPaperScissors.UI.Interfaces;
using RockPaperScissors.UI;

namespace RockPaperScissors.Tests.TestImplementations;

public class AlwaysPicksRock : IChoiceGetter
{
    public Choice GetChoice()
    {
        return Choice.Rock;
    }
}
