using Backend.Validation;
using System.ComponentModel.DataAnnotations;

namespace Backend.DAL.Model
{
    public class Player
    {
        public int PlayerId { get; set; }

        [Required]
        public string FName { get; set; }

        [Required]
        public string LNAme { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [BDValidation]
        public DateTime BDay { get; set; }

        public string FullName => $"{FName} {LNAme}";

        public int Age => DateTime.Today.Year - BDay.Year - (DateTime.Today < BDay.AddYears(DateTime.Today.Year - BDay.Year) ? 1 : 0);

        public int TeamId { get; set; }

        public Team? Team { get; set; } // Itt van a Team objektum

    }
}
