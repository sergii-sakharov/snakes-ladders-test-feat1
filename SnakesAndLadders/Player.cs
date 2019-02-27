namespace SnakesAndLadders.Tests
{
    public class Player
    {
        private readonly string _name;
        public Token Token { get; }

        public Player(string name)
        {
            _name = name;
            Token = new Token();
        }
    }
}