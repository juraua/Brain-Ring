using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBrainRing.Models
{
    public class Points
    {
        [Key, Column(Order = 0)]
        public int GameId { get; set; }
        [Key, Column(Order = 1)]
        public int TeamId { get; set; }
        [Required]
        public int Value { get; set; }
    }
}
