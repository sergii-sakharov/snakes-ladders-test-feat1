using Xunit;

namespace SnakesAndLadders.Tests
{
    public class GameEngineTests
    {
        private class MockDie : Die
        {
            private readonly int _rollOverride;

            public MockDie(int rollOverride) => _rollOverride = rollOverride;

            public override int Roll() => _rollOverride;
        }

        /// Given the player rolls a 4
        /// When they move their token
        /// Then the token should move 4 spaces
        [Fact]
        public void When_Player_Rolls_4_Token_Moves_By_4()
        {
            var player = new Player("name");
            var board = new Board();
            var game = new GameEngine(board, new MockDie(4));
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