using Backend.DAL.Data;
using Backend.DAL.Model;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTO;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BasketballController : ControllerBase
    {

        private readonly MySQLDBContext _dbContext;

        public BasketballController(MySQLDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        //[HttpGet ("Player")]
        //public async Task<ActionResult<List<Player>>> GetAllPlayer()
        //{
        //    var player = await _dbContext.player
        //        .Include(t => t.Team)
        //        .ToListAsync();
        //    return Ok(player);
        //}


        //itt a DTOn keresztül megy
        [HttpGet("Player")]
        public async Task<ActionResult<List<PlayerDTO>>> GetAllPlayer()
        {
            var players = await _dbContext.player
                .Include(t => t.Team)
                .Select(p => new PlayerDTO
                {
                    PlayerId = p.PlayerId,
                    FName = p.FName,
                    LNAme = p.LNAme,
                    BDay = p.BDay,
                    TeamName = p.Team.TeamName,
                    TeamId = p.TeamId,
                })
                .OrderBy(t => t.FName)
                .ToListAsync();
            return Ok(players);

            //var players  = await _dbContext.player
            //    .Include(p => p.Team)  
            //    .ToListAsync();

            //var playerDTO = players.Adapt<List<PlayerDTO>>();
            ////foreach (var item in playerDTO)
            ////{
            ////    var player = players.FirstOrDefault(p => p.PlayerId == item.PlayerId);
            ////    if (player != null)
            ////    {
            ////        item.TeamName = player.Team?.TeamName;
            ////    }
            ////}
            //    return Ok(playerDTO);
        }




        //itt a modelen keresztül

        [HttpGet("Team")]
        public async Task<ActionResult<List<Team>>> GetAllTeam()
        {
            var team = await _dbContext.teams.ToListAsync();
            return Ok(team);
        }






        [HttpGet("Games")]
        public async Task<ActionResult<List<GameDTO>>> GetAllGames()
        {

            var games = await _dbContext.games
                .Include(p => p.Teams)
                .Select(p => new GameDTO
                {
                    GameId = p.GameId,
                    GameDate = p.GameDate,
                    Location = p.Location,
                    Teams = p.Teams.Select(t => t.TeamName).ToList()
                })
                .ToListAsync();
            return Ok(games);
        }

        [HttpGet("searchPlayer/{id}")]
        public async Task<ActionResult<UpdatePlayerDTO>> GetPlayerBYId(int id)
        {
            var player = await _dbContext.player
                .Include(t => t.Team)
                .Where(t => t.PlayerId == id)
                .FirstOrDefaultAsync();

            if (player == null)
            {
                return NotFound();
            }
            var playerDTO = player.Adapt<UpdatePlayerDTO>();
            return Ok(playerDTO);
        }



        [HttpGet("SearchP/{playerName}")]
        public async Task<ActionResult<List<PlayerDTO>>> SearchPlayer(string playerName)
        {
            var players = await _dbContext.player
                .Include(t => t.Team)
                .Where(p =>
                    p.FName.Contains(playerName) ||
                    p.LNAme.Contains(playerName))

                .Select(p => new PlayerDTO
                {
                    PlayerId = p.PlayerId,
                    FName = p.FName,
                    LNAme = p.LNAme,
                    BDay = p.BDay,
                    TeamName = p.Team!.TeamName
                })
                  .ToListAsync();
            if (!players.Any()) { return NotFound(); }
            return Ok(players);
        }
    }
}
