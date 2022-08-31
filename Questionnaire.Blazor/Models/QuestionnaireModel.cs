using Questionnaire.Blazor.Models.Questions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Questionnaire.Blazor.Models
{
    public class QuestionnaireModel
    {
        public int Id { get; set; }

        public int? ParentQuestionId { get; set; }

        [Required(ErrorMessage = "Не введено имя")]
        public string DisplayName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Введите минимум один вопрос")]
        public List<QuestionModel> Questions { get; set; }

        public List<string> Options { get; set; }
    }
}
