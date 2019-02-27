using System;
using System.Collections.Generic;

namespace SnakesAndLadders.Tests
{
    public class GameEngine
    {
        private readonly Board _board;
        private readonly Die _die;

        private Player[] _players;
        private Player _winner;
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

        public bool NextTurn()
        {
            if (_winner != null)
                return false;

            _playerTurnEnumerator.MoveNext();
            var currentToken = _playerTurnEnumerator.Current.Token;

            var dieRoll = _die.Roll();

            _board.MoveToken(currentToken, dieRoll);

            var hasWon = _board.GetPosition(currentToken) == Board.Size;
            _winner = _playerTurnEnumerator.Current;

            return !hasWon;
        }

        public Player GetWinner()
        {
            return _winner;
        }
    }
}