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

        // kapcsolat a playerhez - egy csapatnak több játékosa is van
        [JsonIgnore]
        public virtual ICollection<Player> Players { get; set; } = new List<Player>();

        //kapcsolat a Gamehez - egy meccsen több csapat is játszhat 
        public virtual List<Game> Games { get; set; } = new List<Game>();
    }
}
