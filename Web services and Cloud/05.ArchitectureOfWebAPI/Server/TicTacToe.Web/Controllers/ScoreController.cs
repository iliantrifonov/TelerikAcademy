using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicTacToe.Data;
using TicTacToe.Models;

namespace TicTacToe.Web.Controllers
{
    public class ScoreController : BaseApiController
    {
        public ScoreController(ITicTacToeData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetTopScores()
        {
            var scores = this.data.Users.All().OrderByDescending(GetRank).Select(c => new
            {
                User = c.Email,
                Score = GetRank(c),
                Wins = c.Wins,
            });

            return Ok(scores);
        }

        [HttpGet]
        public IHttpActionResult GetTopScores(int count)
        {
            var scores = this.data.Users.All()
                .OrderByDescending(GetRank)
                .Take(count)
                .Select(c => new
                {
                    User = c.Email,
                    Score = GetRank(c),
                    Wins = c.Wins,
                });

            return Ok(scores);
        }

        private static int GetRank(User user)
        {
            return 3 * user.Wins;
        }
    }
}
