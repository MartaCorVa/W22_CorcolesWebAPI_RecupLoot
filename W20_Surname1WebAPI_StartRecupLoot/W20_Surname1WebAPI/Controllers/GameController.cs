using Dapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using W20_Surname1WebAPI.Models;
using W22_CorcolesWebAPI.Models;

namespace W22_CorcolesWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Game")]
    public class GameController : ApiController
    {
        // POST api/Game/InsertNewGame
        [HttpPost]
        [Route("InsertNewGame")]
        public IHttpActionResult InsertNewGame(GameModel game)
        {
            using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
            {                  
                string sql = "INSERT INTO dbo.Game(Id, IdPlayer, RemainingLoot, TopLoots, LastLoots) " +
                    $"VALUES('{game.Id}','{game.IdPlayer}',{game.RemainingLoot},'{game.TopLoots}','{game.LastLoots}')";
                try
                {
                    cnn.Execute(sql);
                }
                catch (Exception ex)
                {
                    return BadRequest("Error inserting new game in database: " + ex.Message);
                }

                return Ok();
            }
        }

        // GET api/Game/InfoAllGame
        [HttpGet]
        [Route("InfoAllGame")]
        public GameModel InfoAllGame()
        {
            string authenticatedAspNetUserId = RequestContext.Principal.Identity.GetUserId();
            using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
            {
                string sql = $"SELECT Id, IdPlayer, RemainingLoot, TopLoots, LastLoots FROM dbo.Game " +
                    $"WHERE Id LIKE '{authenticatedAspNetUserId}'"; ;
                var games = cnn.Query<GameModel>(sql).FirstOrDefault();
                return games;
            }
        }

        // POST api/Game/UpdateLoot
        [HttpPost]
        [Route("UpdateLoot")]
        public IHttpActionResult UpdateLoot(int newLoot)
        {
            using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
            {
                string sql = $"UPDATE dbo.Game SET RemainingLoot={newLoot}";
                try
                {
                    cnn.Execute(sql);
                }
                catch (Exception ex)
                {
                    return BadRequest("Error updating loot in database: " + ex.Message);
                }

                return Ok();
            }
        }

    }
}
