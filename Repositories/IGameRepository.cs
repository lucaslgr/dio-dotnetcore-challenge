using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiGames.Repositories
{
    public interface IGameRepository
    {
        Task<List<Game>> Get(int page, int quantity);

        Task<Game> Get(Guid id);

        Task<List<Game>> Get(string name, string producer);

        Task Insert(Game game);

        Task Update(Game game);

        Task Delete(Guid id);
    }
}