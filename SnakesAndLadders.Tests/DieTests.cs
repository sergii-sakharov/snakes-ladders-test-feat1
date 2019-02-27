using System.Collections.Generic;
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

    public class GameTests
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

    public class Game
    {
        private readonly Board _board;
        private readonly Die _die;

        private Player[] _players;
        private IEnumerator<Player> _playerTurnEnumerator;

        public Game(Board board, Die die)
        {
            _board = board;
            _die = die;
        }

        public void Begin(params Player[] players)
        {
            _players = players;

            _board.Clear();
            foreach (var player in players)
            {
                _board.RegisterToken(player.Token);
            }

            _playerTurnEnumerator = PlayerRotator().GetEnumerator();
        }

        public IEnumerable<Player> PlayerRotator()
        {
            while (true)
            {
                foreach (var player in _players)
                {
                    yield return player;
                }
            }
        }

        public void NextTurn()
        {
            _playerTurnEnumerator.MoveNext();
            var currentPlayer = _playerTurnEnumerator.Current;

            var dieRoll = _die.Roll();

            _board.MoveToken(currentPlayer.Token, dieRoll);
        }
    }
}