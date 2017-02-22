using System.ComponentModel.DataAnnotations;

namespace DbBrainRing.Enums
{
    public enum QuestionType
    {
        [Display(Name = "Текстове поле")]
        Text,
        [Display(Name = "Кілька складових одної відповіді")]
        CheckBox,
        [Display(Name = "Кілька варіантів відповіді")]
        ComboBox
    }
}