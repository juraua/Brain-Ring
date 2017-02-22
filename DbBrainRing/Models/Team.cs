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
        public string Description { get; set; }
        //Набранные балы за все игры
        public int AllPoints { get; set; }
        //Кол-во сыгранных игр (выбрать с таблицы Points все записи с текущей командой и присвоить Count записей - реализовать при выводе Статистики)
        //[NotMapped]
        public int GamesCount { get; set; }

    }
}
