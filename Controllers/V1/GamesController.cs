using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiGames.InputModel;
using ApiGames.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiGames.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class GamesController: ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<GameViewModel>>> Get()
        {
            return Ok();
        }

        [HttpGet("{gameID:guid}")]
        public async Task<ActionResult<GameViewModel>> Get(Guid gameID)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<GameViewModel>> Insert(GameInputModel game)
        {
            return Ok();
        }

        [HttpPut("{gameID:guid}")]
        public async Task<ActionResult<GameViewModel>> Update(Guid gameID, GameInputModel game)
        {
            return Ok();
        }

        [HttpPatch("{gameID:guid}/price/{price:double}")]
        public async Task<ActionResult<GameViewModel>> Update(Guid gameID, double price)
        {
            return Ok();
        }

        [HttpDelete("{gameID:guid}")]
        public async Task<ActionResult<GameViewModel>> Delete(Guid gameID)
        {
            return Ok();
        }
    }
}