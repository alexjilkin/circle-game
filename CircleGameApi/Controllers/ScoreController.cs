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
    public class ScoreController : ControllerBase
    {
        private readonly ILogger<ScoreController> _logger;

        public ScoreController(ILogger<ScoreController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<HighScore[]> Get()
        {
            this._logger.LogInformation("Get high score list");

            return await DB.Instance.GetSortedSet<HighScore>("score", -1);
        }

        [HttpGet]
        [Route("Max")]
        public async Task<HighScore> GetMax()
        {
            this._logger.LogInformation("Get max score");

            return await DB.Instance.GetHighestInSet<HighScore>("score");
        }
        [HttpGet]
        [Route("Median")]
        public async Task<int> GetMedian()
        {
            this._logger.LogInformation("Get median");

            HighScore[] scores = await DB.Instance.GetSortedSet<HighScore>("score", -1);
            return scores[(int)Math.Round(scores.Count() / 2.0)].score;
        }
        [HttpGet]
        [Route("Average")]
        public async Task<int> GetAverage()
        {
            this._logger.LogInformation("Get average");

            HighScore[] scores = await DB.Instance.GetSortedSet<HighScore>("score", -1);
            return scores.Sum(score => score.score) / scores.Count();

        }

        [HttpGet]
        [Route("Leaderboard")]
        public async Task<HighScore[]> GetLeadeboard()
        {
            this._logger.LogInformation("Get Leaderboard of 5");

            return await DB.Instance.GetSortedSet<HighScore>("score", 5);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(HighScore highScore)
        {
             this._logger.LogInformation("Set score for " + highScore.name);
            await DB.Instance.SortedSetAddAsync<HighScore>("score", highScore.score, highScore);

            return Ok();
        }
    }
}
