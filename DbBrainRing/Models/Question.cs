using System;
using System.Collections.Generic;
using DbBrainRing.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbBrainRing.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public virtual Theme Theme { get; set; }
        [Required]
        public RoundType Round { get; set; }
        public QuestionType QuestionType { get; set; }
        //public String Category { get; set; }
        public virtual Category Category { get; set; }
        [Required]
        public string Content { get; set; }
        
        //Можливість кількох варіантів відповіді (лише одна з них true)
        [Required]
        public virtual ICollection<Answer> Answers { get; set; }

        [Required]
        public int Points { get; set; }
        [NotMapped]
        public int RandomNumber { get; set; }
    }

}
