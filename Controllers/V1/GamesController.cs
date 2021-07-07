using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ApiGames.InputModel;
using ApiGames.Services;
using ApiGames.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiGames.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameViewModel>>> Get(
            [FromQuery, Range(1, int.MaxValue)] int page = 1,
            [FromQuery, Range(1, 50)] int quantity = 5
        )
        {
            var games = await _gameService.Get(1, 5);

            if (games.Count == 0)
                return NoContent();

            return Ok(games);
        }

        [HttpGet("{gameID:guid}")]
        public async Task<ActionResult<GameViewModel>> Get([FromRoute] Guid gameID)
        {
            var game = await _gameService.Get(gameID);

            if (game == null)
                return NoContent();

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<GameViewModel>> Insert([FromBody] GameInputModel gameInputModel)
        {
            try 
            {
                var game = await _gameService.Insert(gameInputModel);

                return Ok(game);
            }
            catch(Exception ex)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
            }
        }

        [HttpPut("{gameID:guid}")]
        public async Task<ActionResult> Update([FromRoute] Guid gameID, [FromBody] GameInputModel gameInputModel)
        {
            try {
                await _gameService.Update(gameID, gameInputModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Não existe este jogo");
            }
        }

        [HttpPatch("{gameID:guid}/price/{price:double}")]
        public async Task<ActionResult> Update([FromRoute] Guid gameID, [FromRoute] double price)
        {
            try {
                await _gameService.Update(gameID, price);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Não existe esse jogo");
            }
        }

        [HttpDelete("{gameID:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid gameID)
        {
            try
            {
                await _gameService.Delete(gameID);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Não existe este jogo");
            }
        }
    }
}