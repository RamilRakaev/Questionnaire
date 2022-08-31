using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Blazor.Models.Questions
{
    public class OptionModel
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Не введено отображаемое имя")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Не введено имя в json")]
        public string JsonName { get; set; }
    }
}
