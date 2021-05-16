using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CommonClasses;

namespace CircleGameApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HighScoreController : ControllerBase
    {
        private readonly ILogger<HighScoreController> _logger;

        public HighScoreController(ILogger<HighScoreController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<HighScore> Get()
        {
            this._logger.LogInformation("Get HighScore");

            return await DB.Instace.GetObjectAsync<HighScore>("score");
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(HighScore highScore)
        {
             this._logger.LogInformation("Set score for " + highScore.name);
            await DB.Instace.SetObjectAsync<HighScore>("score", highScore);

            return Ok();
        }
    }
}
