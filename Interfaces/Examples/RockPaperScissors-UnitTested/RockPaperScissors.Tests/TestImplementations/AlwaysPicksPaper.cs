using RockPaperScissors.UI.Interfaces;
using RockPaperScissors.UI;

namespace RockPaperScissors.Tests.TestImplementations;

public class AlwaysPicksPaper : IChoiceGetter
{
    public Choice GetChoice()
    {
        return Choice.Paper;
    }
}
