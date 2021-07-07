using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiGames.Entities;

namespace ApiGames.Repositories
{
    class GameRepository : IGameRepository
    {   
        private static Dictionary<Guid, Game> games = new Dictionary<Guid, Game>()
        {
            { Guid.Parse("a1"), new Game {Id = Guid.Parse("a1"), Name = "Super Metoid", Producer = "Nintendo", Price = 200} },
            { Guid.Parse("b1"), new Game {Id = Guid.Parse("b1"), Name = "Aladin", Producer = "Nintendo", Price = 100} },
            { Guid.Parse("c1"), new Game {Id = Guid.Parse("c1"), Name = "Donkey Kong", Producer = "Nintendo", Price = 120} },
            { Guid.Parse("d1"), new Game {Id = Guid.Parse("d1"), Name = "Street Fighter V", Producer = "Capcom", Price = 120} },
            { Guid.Parse("e1"), new Game {Id = Guid.Parse("e1"), Name = "Residente Evil", Producer = "Capcom", Price = 120} }
        };

        public Task<List<Game>> Get(int page, int quantity)
        {
            return Task.FromResult(games.Values.Skip((page - 1) * quantity).Take(quantity).ToList());
        }

        public Task<Game> Get(Guid id)
        {
            if(!games.ContainKey(id))
                return null;
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