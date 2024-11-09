using Backend.DAL.Data;
using Backend.DAL.Model;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTO;

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
            //var players = await _dbContext.player
            //    .Include(t => t.Team)
            //    .Select(p => new PlayerDTO
            //    {
            //        PlayerId = p.PlayerId,
            //        FName = p.FName,
            //        LNAme = p.LNAme,
            //        BDay = p.BDay,
            //        TeamName = p.Team.TeamName,
            //        TeamId = p.TeamId,
            //    })
            //    .OrderBy(t => t.FName)
            //    .ToListAsync();
            //return Ok(players);

            var players  = await _dbContext.player
                .Include(p=>p.Team)
                .ToListAsync();

            var playerDTO = players.Adapt<List<PlayerDTO>>();
            return Ok(playerDTO);
        }

        //itt a modelen keresztül
      
        [HttpGet("Team")]
        public async Task<ActionResult<List<Team>>> GetAllTeam()
        {
            var team = await _dbContext.teams.ToListAsync();
            return Ok(team);
        }

    }
}
