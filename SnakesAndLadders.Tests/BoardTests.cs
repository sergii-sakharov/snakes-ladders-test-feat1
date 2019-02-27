using System;
using System.Collections.Generic;
using Xunit;

namespace SnakesAndLadders.Tests
{
    public class BoardTests
    {
        [Fact]
        public void PlayerRegistered_ShouldBeOnPosition1()
        {
            var player = new Player("name");
            var board = new Board();

            board.RegisterPlayer(player);
            var position = board.GetPosition(player);

            Assert.Equal(1, position);
        }

        [Fact]
        public void RegisteringPlayerTwice_WouldThrowException()
        {
            var player = new Player(null);
            var board = new Board();

            board.RegisterPlayer(player);

            Assert.Throws<ArgumentException>(nameof(player), () => board.RegisterPlayer(player));
        }
    }

    public class Board
    {
        private IDictionary<Guid, int> _playerPositionMap;
        public const int Size = 100;
        private const int StartPosition = 1;

        public Board()
        {
            _playerPositionMap = new Dictionary<Guid, int>();
        }

        public void RegisterPlayer(Player player)
        {
            if(_playerPositionMap.ContainsKey(player.Id))
                throw new ArgumentException("Player with this Id is already on the board", nameof(player));

            _playerPositionMap.Add(player.Id, StartPosition);
        }

        public int GetPosition(Player player)
        {
            if(!_playerPositionMap.ContainsKey(player.Id))
                throw new ArgumentException("Player is not on the board", nameof(player));

            return _playerPositionMap[player.Id];
        }
    }
}
