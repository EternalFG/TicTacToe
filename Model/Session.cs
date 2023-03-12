namespace TicTacToe.Model
{
    public class Session
    {
        public int Id { get; }
        public PlayerSession Player1 { get; set; }
        public PlayerSession Player2 { get; set; }

        public string LastPlayedPlayer;


        public PlayerSymbol?[,] map = new PlayerSymbol?[3, 3];

        public Session(int id)
        {
            Id = id;
        }


    }

    public class PlayerSession
    {
        public PlayerSession(string id, PlayerSymbol symbol)
        {
            Id = id;
            Symbol = symbol;
        }

        public string Id { get; }
        public PlayerSymbol Symbol { get; }
    }

    public enum PlayerSymbol
    {
        X,
        O
    }
}
