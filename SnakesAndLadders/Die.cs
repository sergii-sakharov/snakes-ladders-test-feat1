using System;

namespace SnakesAndLadders.Tests
{
    public class Die
    {
        public const int DieSize = 6;
        private readonly Random _random;

        public Die()
        {
            _random = new Random();
        }

        public virtual int Roll()
        {
            return _random.Next(1, DieSize);
        }
    }
}