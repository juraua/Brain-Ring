using System.ComponentModel.DataAnnotations;

namespace DbBrainRing.Enums
{
    //public class EnumTypes
    //{
    public enum RoundType
        {
            [Display(Name = "Основний")]
            Main,
            [Display(Name = "Спринт")]
            Sprint,
            [Display(Name = "Головоломки")]
            BrainTeasers,
            [Display(Name = "Категорії")]
            Cathegories,
            [Display(Name = "Поєдинок капітанів")]
            CaptainBattle
        }

    //}
}
