using System.ComponentModel.DataAnnotations;

namespace DbBrainRing.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public bool IsCorrect { get; set; }
    }
}
