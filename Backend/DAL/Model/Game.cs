using System.ComponentModel.DataAnnotations;

namespace Backend.DAL.Model
{
    public class Game
    {
        public int GameId { get; set; }

        [Required]
        [MaxLength(25)]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime GameDate { get; set; }


        //kapcsolat a Teamhez - egy csapat többször is játszhat 
        public virtual List<Team> Teams { get; set; } = new List<Team>();
    }
}
