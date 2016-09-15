using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbBrainRing.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public virtual ICollection<Team> Teams { get; set; } 
    }
}
