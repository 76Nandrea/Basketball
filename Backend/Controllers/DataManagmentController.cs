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
    public class DataManagmentController : ControllerBase
    {
        private readonly MySQLDBContext _dbContext;

        public DataManagmentController(MySQLDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("AddPlayer")]
        public async Task<ActionResult<List<PlayerDTO>>> AddPlayer([FromBody] PlayerDTO playerdto)
        {
            var player = playerdto.Adapt<Player>();
            _dbContext.player.Add(player);
            await _dbContext.SaveChangesAsync();

            var players = await _dbContext.player
                .Include(p => p.Team)
                .ToListAsync();

            var playerDtos = players.Adapt<List<PlayerDTO>>();
            return Ok(playerDtos);
        }




        [HttpDelete("DeleteTeam/{TeamId}")]
        public async Task<ActionResult<List<Team>>> DeleteTeam(int TeamId)
        {
            var deleteTeam = await _dbContext.teams.FindAsync(TeamId);
            if (deleteTeam == null)
            {
                return NotFound("Nincs ilyen csapat");
            }
            _dbContext.teams.Remove(deleteTeam);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.teams.ToListAsync());
        }


        [HttpPatch("PlayerPatch/{Id}")]
        public async Task<ActionResult<List<UpdatePlayerDTO>>> UpdatePlayer(int Id, [FromBody] UpdatePlayerDTO updateplayerdto)
        {
            var selectPlayer =await _dbContext.player.FindAsync(Id);
            if (selectPlayer == null) 
            {
                return NotFound("A játékos nem található")
;           }

            selectPlayer.FName = updateplayerdto.FName;
            selectPlayer.LNAme = updateplayerdto.LNAme;
            selectPlayer.BDay =  updateplayerdto.BDay;
            selectPlayer.TeamId = updateplayerdto.TeamId;

            await _dbContext.SaveChangesAsync();

            var players = await _dbContext.player.Include(t => t.Team).ToListAsync();
            var playerDTO =players.Adapt<List<UpdatePlayerDTO>>();

            return Ok(playerDTO);
        }

    }
}
