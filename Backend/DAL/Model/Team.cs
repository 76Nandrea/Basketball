using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.DAL.Model
{
    public class Team
    {
        public int TeamId { get; set; }

        [Required]
        [MaxLength(25)]
        public string TeamName { get; set; }

        // kapcsolat a playerhez
        [JsonIgnore]
        public virtual ICollection<Player> Players { get; set; } = new List<Player>();

        //kapcsolat a Gamehez
        public virtual List<Game> Games { get; set; } = new List<Game>();
    }
}
