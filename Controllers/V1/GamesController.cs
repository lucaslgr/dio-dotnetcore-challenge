using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiGames.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class GamesController: ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<object>>> Get()
        {
            return Ok();
        }

        [HttpGet("{gameID:guid}")]
        public async Task<ActionResult<object>> Get(Guid gameID)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<object>> Insert(object game)
        {
            return Ok();
        }

        [HttpPut("{gameID:guid}")]
        public async Task<ActionResult<object>> Update(Guid gameID, object game)
        {
            return Ok();
        }

        [HttpPatch("{gameID:guid}/price/{price:double}")]
        public async Task<ActionResult<object>> Update(Guid gameID, double price)
        {
            return Ok();
        }

        [HttpDelete("{gameID:guid}")]
        public async Task<ActionResult<object>> Delete(Guid gameID)
        {
            return Ok();
        }
    }
}