using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class University
    {   [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Education> Education { get; set; }
    }
}
