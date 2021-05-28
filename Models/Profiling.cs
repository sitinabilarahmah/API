﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Profiling
    {   [Key]
        public int NIK { get; set; }
        public virtual Account Account { get; set; }
        public virtual Education Education { get; set; }
        
    }
}