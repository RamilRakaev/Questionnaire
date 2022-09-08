using Questionnaire.Blazor.Models.Questions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Blazor.Models
{
    public class QuestionnaireModel
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Введите минимум один вопрос")]
        public List<QuestionModel> Questions { get; set; }

        public List<string> Options { get; set; }

        public List<QuestionAnswerModel> QuestionAnswers { get; set; }

        public Dictionary<AnswerModel, QuestionModel> QuestionsAnswers { get; set; }
    }
}
