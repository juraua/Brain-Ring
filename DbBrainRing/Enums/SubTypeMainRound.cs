using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBrainRing.Enums
{
    public enum SubTypeMainRound
    {
        [Display(Name = "Без типу")]
        WithoutType,
        [Display(Name = "Швидкий пошук")]
        QuickSearch,
        [Display(Name = "Розминка")]
        WarmUp,
        [Display(Name = "Комбіновані запитання")]
        Combined,
        [Display(Name = "В пошуках скарбу")]
        Treasure
    }
}
