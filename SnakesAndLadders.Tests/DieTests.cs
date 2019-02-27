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
            var die = new `Die();

            for (var i = 0; i < 100; i++)
            {
                var rollResult = die.Roll();

                Assert.InRange(rollResult, 1, 6);
            }
        }
    }

    public class GameTests
    {
        public class MockDie : Die
        {

        }

        /// Given the player rolls a 4
        /// When they move their token
        /// Then the token should move 4 spaces
        [Fact]
        public void When_Player_Rolls_4_Token_Moves_By_4()
        {
            var player = new Player();
            var board = new Board();
            var game = new Game(board, new MockDie(4));
            game.Begin(player);

            var oldPosition = board.GetPosition(player.Token);
            game.NextTurn();
            var newPosition = board.GetPosition(player.Token);

            Assert.Equal(4, newPosition - oldPosition);
        }


       /// Given the token is on square 97
       /// When the token is moved 3 spaces
       /// Then the token is on square 100
       /// And the player has won the game

       /// Given the token is on square 97
       /// When the token is moved 4 spaces
       /// Then the token is on square 97
       /// And the player has not won the game
    }

}