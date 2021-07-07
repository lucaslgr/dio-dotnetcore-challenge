using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiGames.InputModel;
using ApiGames.ViewModel;

namespace ApiGames.Services
{
    public interface IGameService
    {
        Task<List<GameViewModel>> Get(int page, int qtd);

        Task<GameViewModel> Get(Guid id); 

        Task<GameViewModel> Insert(GameInputModel game);

        Task Update(Guid id, GameInputModel game);

        Task Update(Guid id, double price);

        Task Delete(Guid id);
    }
}