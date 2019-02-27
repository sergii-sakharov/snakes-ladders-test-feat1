using System;
using Xunit;

namespace SnakesAndLadders.Tests
{
    public class BoardTests
    {
        /// <summary>
        /// Given the game is started
        /// When the token is placed on the board
        /// Then the token is on square 1
        /// </summary>
        [Fact]
        public void PlayerRegistered_ShouldBeOnPosition1()
        {
            var token = new Token();
            var board = new Board();

            board.RegisterToken(token);
            var position = board.GetPosition(token);

            Assert.Equal(1, position);
        }

        /// <summary>
        /// Given the token is on square 1
        /// When the token is moved 3 spaces
        /// Then the token is on square 4
        /// </summary>
        [Fact]
        public void MovingToken_Will_OffsetItsPosition()
        {
            var token = new Token();
            var board = new Board();

            board.RegisterToken(token);
            var initPosition = board.GetPosition(token);
            board.MoveToken(token, 3);
            var newPosition = board.GetPosition(token);

            Assert.Equal(1, initPosition);
            Assert.Equal(4, newPosition);
        }

        /// <summary>
        /// Given the token is on square 1
        /// When the token is moved 3 spaces
        /// And then it is moved 4 spaces
        /// Then the token is on square 8
        /// </summary>
        [Fact]
        public void MovingTokenTwice_Will_OffsetItsPosition()
        {
            var token = new Token();
            var board = new Board();

            board.RegisterToken(token);
            var initPosition = board.GetPosition(token);
            board.MoveToken(token, 3);
            board.MoveToken(token, 4);
            var newPosition = board.GetPosition(token);

            Assert.Equal(1, initPosition);
            Assert.Equal(8, newPosition);
        }

        [Fact]
        public void RegisteringPlayerTwice_WouldThrowException()
        {
            var token = new Token();
            var board = new Board();

            board.RegisterToken(token);

            Assert.Throws<ArgumentException>(nameof(token), () => board.RegisterToken(token));
        }
    }
}
