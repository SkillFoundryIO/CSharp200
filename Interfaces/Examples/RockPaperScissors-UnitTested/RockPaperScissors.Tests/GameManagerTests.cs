using NUnit.Framework;
using RockPaperScissors.Tests.TestImplementations;
using RockPaperScissors.UI;

namespace RockPaperScissors.Tests
{
    public class GameManagerTests
    {
        [Test]
        public void RockBeatsScissors()
        {
            var gm = new GameManager(new AlwaysPicksRock(), new AlwaysPicksScissors());

            var result = gm.PlayRound();

            Assert.That(RoundResult.Player1Wins, Is.EqualTo(result));
            Assert.That(1, Is.EqualTo(gm.Wins));
            Assert.That(0, Is.EqualTo(gm.Losses));
            Assert.That(0, Is.EqualTo(gm.Ties));
        }

        [Test]
        public void PaperBeatsRock()
        {
            var gm = new GameManager(new AlwaysPicksRock(), new AlwaysPicksPaper());

            var result = gm.PlayRound();

            Assert.That(RoundResult.Player2Wins, Is.EqualTo(result));
            Assert.That(0, Is.EqualTo(gm.Wins));
            Assert.That(1, Is.EqualTo(gm.Losses));
            Assert.That(0, Is.EqualTo(gm.Ties));
        }

        [Test]
        public void ScissorsBeatsPaper()
        {
            var gm = new GameManager(new AlwaysPicksScissors(), new AlwaysPicksPaper());

            var result = gm.PlayRound();

            Assert.That(RoundResult.Player1Wins, Is.EqualTo(result));
            Assert.That(1, Is.EqualTo(gm.Wins));
            Assert.That(0, Is.EqualTo(gm.Losses));
            Assert.That(0, Is.EqualTo(gm.Ties));
        }

        [Test]
        public void CanTieRound()
        {
            var gm = new GameManager(new AlwaysPicksScissors(), new AlwaysPicksScissors());

            var result = gm.PlayRound();

            Assert.That(RoundResult.Tie, Is.EqualTo(result));
            Assert.That(0, Is.EqualTo(gm.Wins));
            Assert.That(0, Is.EqualTo(gm.Losses));
            Assert.That(1, Is.EqualTo(gm.Ties));
        }
    }
}
