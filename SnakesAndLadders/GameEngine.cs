using System.Collections.Generic;

namespace SnakesAndLadders.Tests
{
    public class GameEngine
    {
        private readonly Board _board;
        private readonly Die _die;

        private Player[] _players;
        private IEnumerator<Player> _playerTurnEnumerator;

        public GameEngine(Board board, Die die)
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