﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class UpdatePlayerDTO
    {
        public int PlayerId { get; set; }
        public string FName { get; set; }
        public string LNAme { get; set; }
        public DateTime BDay { get; set; }

        public int TeamId { get; set; }
    }
}
