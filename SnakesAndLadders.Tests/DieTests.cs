using Xunit;

namespace SnakesAndLadders.Tests
{
    public class DieTests
    {
        /// Given the game is started
        /// When the player rolls a die
        /// Then the result should be between 1-6 inclusive
        [Fact]
        public void DiceCanProduceRolls_1_to_6()
        {
            var die = new Die();

            for (var i = 0; i < 100; i++)
            {
                var rollResult = die.Roll();

                Assert.InRange(rollResult, 1, 6);
            }
        }
    }
}