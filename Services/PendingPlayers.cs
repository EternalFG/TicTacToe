namespace TicTacToe.Services
{
    public interface IPendingPlayers
    {
        Task AddPlayerAsync(string id);
        Task<bool> CheckPlayerAsync(string id);
    }
    
    public class PendingPlayers : IPendingPlayers
    {
        private readonly IGameSessionService gameSessionService;
        public PendingPlayers(IGameSessionService gameSessionService)
        {
            this.gameSessionService = gameSessionService;
        }
        
        
        private readonly HashSet<string> _pendings = new HashSet<string>();


        public async Task AddPlayerAsync(string id)
        {
            _pendings.Add(id);

            if (_pendings.Count >= 2)
            {
                var player1 = _pendings.FirstOrDefault();
                _pendings.Remove(player1);
                var player2 = _pendings.LastOrDefault();
                _pendings.Remove(player2);

                await gameSessionService.CreateSession(player1, player2);
            }
        }

        public Task<bool> CheckPlayerAsync(string id)
        {
            return Task.FromResult(_pendings.FirstOrDefault(p => p == id) != null);
        }
    }
}
