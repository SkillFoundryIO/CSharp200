using RockPaperScissors.UI.Interfaces;

namespace RockPaperScissors.UI;

public class GameManager
{
    public int Wins { get; private set; }
    public int Losses { get; private set; }
    public int Ties { get; private set; }

    private IChoiceGetter _p1ChoiceGetter;
    private IChoiceGetter _p2ChoiceGetter;

    public Choice Player1Choice { get; private set; }
    public Choice Player2Choice { get; private set; }

    public GameManager(IChoiceGetter p1, IChoiceGetter p2)
    {
        _p1ChoiceGetter = p1;
        _p2ChoiceGetter = p2;
    }

    public RoundResult PlayRound()
    {
        Player1Choice = _p1ChoiceGetter.GetChoice();
        Player2Choice = _p2ChoiceGetter.GetChoice();

        if (Player1Choice == Player2Choice)
        {
            Ties++;
            return RoundResult.Tie;
        }
        else if ((Player1Choice == Choice.Rock && Player2Choice == Choice.Scissors) ||
                 (Player1Choice == Choice.Paper && Player2Choice == Choice.Rock) ||
                 (Player1Choice == Choice.Scissors && Player2Choice == Choice.Paper))
        {
            Wins++;
            return RoundResult.Player1Wins;
        }
        else
        {
            Losses++;
            return RoundResult.Player2Wins;
        }
    }
}
