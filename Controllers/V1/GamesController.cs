using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ApiGames.Exceptions;
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

        /// <summary>
        /// Buscar todos os jogos de forma paginada
        /// </summary>
        /// <remarks>
        /// Não é possível retornar os jogos sem paginação
        /// </remarks>
        /// <param name="page">Indica qual página está sendo consultada. Mínimo 1</param>
        /// <param name="quantity">Indica a quantidade de reistros por página. Mínimo 1 e máximo 50 e o padrão é 5</param>
        /// <response code="200">Retorna a lista de jogos</response>
        /// <response code="204">Caso não haja jogos</response>
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

        /// <summary>
        /// Buscar um jogo pelo seu Id
        /// </summary>
        /// <param name="gameID">Id do jogo buscado</param>
        /// <response code="200">Retorna o jogo filtrado</response>
        /// <response code="204">Caso não haja jogo com este id</response> 
        [HttpGet("{gameID:guid}")]
        public async Task<ActionResult<GameViewModel>> Get([FromRoute] Guid gameID)
        {
            var game = await _gameService.Get(gameID);

            if (game == null)
                return NoContent();

            return Ok(game);
        }

        /// <summary>
        /// Inserir um jogo no catálogo
        /// </summary>
        /// <param name="gameInputModel">Dados do jogo a ser inserido</param>
        /// <response code="200">Cao o jogo seja inserido com sucesso</response>
        /// <response code="422">Caso já exista um jogo com mesmo nome para a mesma produtora</response>   
        [HttpPost]
        public async Task<ActionResult<GameViewModel>> Insert([FromBody] GameInputModel gameInputModel)
        {
            try 
            {
                var game = await _gameService.Insert(gameInputModel);

                return Ok(game);
            }
            catch(GameIsAlreadyRegisteredException ex)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
            }
        }

        /// <summary>
        /// Atualizar um jogo no catálogo
        /// </summary>
        /// <param name="gameID">Id do jogo a ser atualizado</param>
        /// <param name="gameInputModel">Novos dados para atualizar o jogo indicado</param>
        /// <response code="200">Cao o jogo seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um jogo com este Id</response>
        [HttpPut("{gameID:guid}")]
        public async Task<ActionResult> Update([FromRoute] Guid gameID, [FromBody] GameInputModel gameInputModel)
        {
            try {
                await _gameService.Update(gameID, gameInputModel);
                return Ok();
            }
            catch (GameNotRegisteredException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }

        /// <summary>
        /// Atualizar o preço de um jogo
        /// </summary>
        /// <param name="gameID">Id do jogo a ser atualizado</param>
        /// <param name="price">Novo preço do jogo</param>
        /// <response code="200">Cao o preço seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um jogo com este Id</response>   
        [HttpPatch("{gameID:guid}/price/{price:double}")]
        public async Task<ActionResult> Update([FromRoute] Guid gameID, [FromRoute] double price)
        {
            try {
                await _gameService.Update(gameID, price);
                return Ok();
            }
            catch (GameNotRegisteredException ex)
            {
                return NotFound("Não existe esse jogo");
            }
        }

        /// <summary>
        /// Excluir um jogo
        /// </summary>
        /// <param name="gameID">Id do jogo a ser excluído</param>
        /// <response code="200">Cao o preço seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um jogo com este Id</response>   
        [HttpDelete("{gameID:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid gameID)
        {
            try
            {
                await _gameService.Delete(gameID);
                return Ok();
            }
            catch (GameNotRegisteredException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }
    }
}