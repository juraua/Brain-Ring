using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbBrainRing.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Captain { get; set; }
        [Required]
        public string Information { get; set; }
        public int Points { get; set; }
        //Create list of members
        [NotMapped]
        public int Games { get; set; }

    }
}
