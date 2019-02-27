using System;
using System.Collections.Generic;

namespace SnakesAndLadders.Tests
{
    public class Board
    {
        private readonly IDictionary<Guid, int> _tokenPositionMap;
        public const int Size = 100;
        private const int StartPosition = 1;

        public Board()
        {
            _tokenPositionMap = new Dictionary<Guid, int>();
        }

        public void RegisterToken(Token token)
        {
            if(_tokenPositionMap.ContainsKey(token.Id))
                throw new ArgumentException("Token with this Id is already on the board", nameof(token));

            _tokenPositionMap.Add(token.Id, StartPosition);
        }

        public int GetPosition(Token token)
        {
            if(!_tokenPositionMap.ContainsKey(token.Id))
                throw new ArgumentException("Token is not on the board", nameof(token));

            return _tokenPositionMap[token.Id];
        }

        public void MoveToken(Token token, int numberOfSteps)
        {
            if (!_tokenPositionMap.ContainsKey(token.Id))
                throw new ArgumentException("Token is not on the board", nameof(token));

            _tokenPositionMap[token.Id] += numberOfSteps;

            if (_tokenPositionMap[token.Id] >= Size)
                _tokenPositionMap[token.Id] = Size;
        }

        public void Clear()
        {
            _tokenPositionMap.Clear();
        }
    }
}