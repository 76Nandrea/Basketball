using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class GameDTO
    {
        public int GameId { get; set; }

      
        public string Location { get; set; }

      
        public DateTime GameDate { get; set; }

        public  List<string> Teams { get; set; } 
    }
}
