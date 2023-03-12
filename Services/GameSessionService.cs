using TicTacToe.Model;

namespace TicTacToe.Services
{
    public interface IGameSessionService
    {
        Task<int> CreateSession(string player1, string player2);
        Task<int?> FindPlayerSession(string playerId);

        Task<(string,bool)> TryMove(int sessionId, string playerId, int x, int y);

        Task<PlayerSymbol?[,]> GetMap(int sessionId);
    }

    public class GameSessionService : IGameSessionService
    {
        private readonly IList<Session> _sessions = new List<Session>();
        private readonly IEngineService _engineService;

        public GameSessionService(IEngineService engineService)
        {
            _engineService = engineService;
        }
        
        public Task<int> CreateSession(string player1Id, string player2Id)
        {
            var session = new Session(_sessions.Count + 1);

            var player1 = new PlayerSession(player1Id, PlayerSymbol.X);
            var player2 = new PlayerSession(player2Id, PlayerSymbol.O);

            session.Player1 = player1;
            session.Player2 = player2;

            session.LastPlayedPlayer = player2.Id;

            _sessions.Add(session);
            return Task.FromResult(session.Id);
        }

        public Task<int?> FindPlayerSession(string playerId)
        {
            Session session = null;
            if ((session = _sessions.FirstOrDefault(s => s.Player1.Id == playerId || s.Player2.Id == playerId)) != null)
            {
                return Task.FromResult<int?>(session.Id);
            }
            return Task.FromResult<int?>(null);
        }


        private Session findSession(int sessionId) => _sessions.FirstOrDefault(s => s.Id == sessionId);
        private PlayerSession getPlayerSession(Session session, string playerId) => 
            session.Player1.Id == playerId 
            ? session.Player1 
            : session.Player2.Id == playerId 
                ? session.Player2 
                : null;

        public Task<(string, bool)> TryMove(int sessionId, string playerId, int x, int y)
        {
            var session = findSession(sessionId);
            if (session == null)
            {
                throw new Exception();
            }

            var player = getPlayerSession(session, playerId);
            if (session.LastPlayedPlayer != playerId)
            {
                if (session.map[x, y] == null)
                {
                    session.map[x, y] = player.Symbol;
                    session.LastPlayedPlayer = player.Id;
                    
                    var winner = _engineService.CheckWinner(session.map);
                    if (winner.Result)
                    {
                        _sessions.Remove(session);
                        return Task.FromResult((player.Symbol.ToString(), true));
                    }

                    return Task.FromResult((string.Empty, true));
                }
            }

            return Task.FromResult((string.Empty, false));
        }

        public Task<PlayerSymbol?[,]> GetMap(int sessionId)
        {
            var session = findSession(sessionId);
            if (session == null)
            {
                throw new Exception();
            }

            return Task.FromResult(session.map);
        }
    }
}
