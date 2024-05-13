using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CapitalPlacementProject.Enums
{
    public class Enum
    {
        public enum QuestionType
        {
            [Display(Name = "Date")]
            Date = 1,
            [Display(Name = "Multiple Choice")]
            MultipleChoice = 2,
            [Display(Name = "Yes/No")]
            YesNo = 3,
            [Display(Name = "Paragraph")]
            Paragraph = 4,
            [Display(Name = "Number")]
            Number = 5
        }
    }
}
