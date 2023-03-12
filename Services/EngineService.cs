using TicTacToe.Model;

namespace TicTacToe.Services
{
    public interface IEngineService
    {
        Task<bool> CheckWinner(PlayerSymbol?[,] map);

    }

    public class EngineService : IEngineService
    {
        public Task<bool> CheckWinner(PlayerSymbol?[,] map)
        {
            // горизонталь

            if (map[0,0] == PlayerSymbol.O && map[1,0] == PlayerSymbol.O && map[2,0] == PlayerSymbol.O)
            {
                return Task.FromResult(true);
            }
            if (map[0,1] == PlayerSymbol.O && map[1,1] == PlayerSymbol.O && map[2,1] == PlayerSymbol.O)
            {
                return Task.FromResult(true);
            }
            if (map[0,2] == PlayerSymbol.O && map[1,2] == PlayerSymbol.O && map[2,2] == PlayerSymbol.O)
            {
                return Task.FromResult(true);
            }
            if (map[0, 0] == PlayerSymbol.X && map[1, 0] == PlayerSymbol.X && map[2, 0] == PlayerSymbol.X)
            {
                return Task.FromResult(true);
            }
            if (map[0, 1] == PlayerSymbol.X && map[1, 1] == PlayerSymbol.X && map[2, 1] == PlayerSymbol.X)
            {
                return Task.FromResult(true);
            }
            if (map[0, 2] == PlayerSymbol.X && map[1, 2] == PlayerSymbol.X && map[2, 2] == PlayerSymbol.X)
            {
                return Task.FromResult(true);
            }

            // вертикаль
            if (map[0, 0] == PlayerSymbol.O && map[0, 1] == PlayerSymbol.O && map[0, 2] == PlayerSymbol.O)
            {
                return Task.FromResult(true);
            }
            if (map[1, 0] == PlayerSymbol.O && map[1, 1] == PlayerSymbol.O && map[1, 2] == PlayerSymbol.O)
            {
                return Task.FromResult(true);
            }
            if (map[2, 0] == PlayerSymbol.O && map[2, 1] == PlayerSymbol.O && map[2, 2] == PlayerSymbol.O)
            {
                return Task.FromResult(true);
            }
            if (map[0, 0] == PlayerSymbol.X && map[0, 1] == PlayerSymbol.X && map[0, 2] == PlayerSymbol.X)
            {
                return Task.FromResult(true);
            }
            if (map[1, 0] == PlayerSymbol.X && map[1, 1] == PlayerSymbol.X && map[1, 2] == PlayerSymbol.X)
            {
                return Task.FromResult(true);
            }
            if (map[2, 0] == PlayerSymbol.X && map[2, 1] == PlayerSymbol.X && map[2, 2] == PlayerSymbol.X)
            {
                return Task.FromResult(true);
            }


            // Диагональ
            if (map[0, 0] == PlayerSymbol.O && map[1, 1] == PlayerSymbol.O && map[2, 2] == PlayerSymbol.O)
            {
                return Task.FromResult(true);
            }
            if (map[2, 0] == PlayerSymbol.O && map[1, 1] == PlayerSymbol.O && map[2, 0] == PlayerSymbol.O)
            {
                return Task.FromResult(true);
            }
            if (map[0, 0] == PlayerSymbol.X && map[1, 1] == PlayerSymbol.X && map[2, 2] == PlayerSymbol.X)
            {
                return Task.FromResult(true);
            }
            if (map[2, 0] == PlayerSymbol.X && map[1, 1] == PlayerSymbol.X && map[2, 0] == PlayerSymbol.X)
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }


    }
}
