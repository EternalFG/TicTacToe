using TicTacToe.Model;

namespace TicTacToe.Services
{
    public interface IEngineService
    {
        Task<bool> CheckWinner(PlayerSymbol?[,] map);

    }

    public class EngineService : IEngineService
    {
        public Task<bool> CheckWinner(PlayerSymbol?[,] map) // map[х,y] y - высота
        {
            // горизонталь
            //if (CheckStraightHorizontalLine(map, 0, 2).Result || CheckStraightHorizontalLine(map, 1, 2).Result || CheckStraightHorizontalLine(map, 2, 2).Result)
            //{
            //    return Task.FromResult(true);
            //}

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

        //public Task<bool> CheckStraightHorizontalLine(PlayerSymbol?[,] map, int start, int end)
        //{
        //    int X = 0;
        //    int O = 0;

        //    for (int i = 0; i < map.GetLength(1); i++)
        //    {
        //        for (int j = 0; j < map.GetLength(0); j++)
        //        {
        //            if (map[start, j] == PlayerSymbol.O)
        //            {
        //                O++;
        //            }
        //            if (map[start, j] == PlayerSymbol.X)
        //            {
        //                X++;
        //            }
        //            if (map[start, j] == map[start, end])
        //            {
        //                break;
        //            }
        //        }
        //    }
        //    if (X == 3 || O == 3)
        //    {
        //        return Task.FromResult(true);
        //    }
        //    else
        //    {
        //        return Task.FromResult(false);
        //    }
        //}
    }
}
