using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class TeamDTO
    {
        public int TeamId { get; set; }
        public string? TeamName { get; set; }
    }
}
