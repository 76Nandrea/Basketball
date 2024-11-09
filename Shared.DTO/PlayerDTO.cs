using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
     public class PlayerDTO
    {
        public int PlayerId { get; set; }
        public string FName { get; set; }
        public string LNAme { get; set; }
        public DateTime BDay { get; set; } 

        public string FullName => $"{FName} {LNAme}";

        public int Age => DateTime.Today.Year - BDay.Year - (DateTime.Today < BDay.AddYears(DateTime.Today.Year - BDay.Year) ? 1 : 0);

        public int TeamId { get; set; }
        public string? TeamName { get; set; } 
    }
}
