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
    }
}
