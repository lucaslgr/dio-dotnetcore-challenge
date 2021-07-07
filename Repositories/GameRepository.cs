using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiGames.Entities;

namespace ApiGames.Repositories
{
    class GameRepository : IGameRepository
    {   
        private static Dictionary<Guid, Game> games = new Dictionary<Guid, Game>()
        {
            { Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Game {Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Name = "Super Metoid", Producer = "Nintendo", Price = 200} },
            { Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Game {Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), Name = "Aladin", Producer = "Nintendo", Price = 100} },
            { Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), new Game {Id = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), Name = "Donkey Kong", Producer = "Nintendo", Price = 120} },
            { Guid.Parse("da033439-f352-4539-879f-515759312d53"), new Game {Id = Guid.Parse("da033439-f352-4539-879f-515759312d53"), Name = "Street Fighter V", Producer = "Capcom", Price = 120} },
            { Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), new Game {Id = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), Name = "Residente Evil", Producer = "Capcom", Price = 120} }
        };

        public Task<List<Game>> Get(int page, int quantity)
        {
            return Task.FromResult(games.Values.Skip((page - 1) * quantity).Take(quantity).ToList());
        }

        public Task<Game> Get(Guid id)
        {
            if(!games.ContainsKey(id))
                return Task.FromResult<Game>(null);
            return Task.FromResult(games[id]);
        }

        public Task<List<Game>> Get(string name, string producer)
        {
            return 
            Task.FromResult(games.Values.Where(
                game => game.Name.Equals(name) && game.Producer.Equals(producer)
                ).ToList());
        }

        public Task Insert(Game game)
        {
            games.Add(game.Id, game);
            return Task.CompletedTask;
        }

        public Task Update(Game game)
        {
           games[game.Id] = game;
           return Task.CompletedTask;
        }

        public Task Delete(Guid id)
        {
            games.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            
        }

    }
}