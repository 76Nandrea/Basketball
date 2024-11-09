using Microsoft.EntityFrameworkCore;
using Backend.DAL.Model;

namespace Backend.DAL.Data
{
    public class MySQLDBContext : DbContext
    {
        public MySQLDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Game> games { get; set; }
        public DbSet<Team> teams { get; set; }

        public DbSet<Player> player { get; set; }

    }
}
