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
        [Key]
        public int Id { get; set; }
        //Связь многие ко многим - у одной команды несколько игр, в одной игре учавствуют несколько команд
        //[Key, Column(Order = 0)]
        [Required]
        public Game Game { get; set; }
        //[Key, Column(Order = 1)]
        [Required]
        public Team Team { get; set; }
        //Набранные балы в одной игре соответствующей командой
        [Required]
        public int ValueCurrent { get; set; }
    }
}
