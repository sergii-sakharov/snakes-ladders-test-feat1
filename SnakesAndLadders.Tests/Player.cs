using System;

namespace SnakesAndLadders.Tests
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; }
    }
}