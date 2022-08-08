using Questionnaire.Blazor.Interfaces;

namespace Questionnaire.Blazor.Models
{
    public class Question
    {
        public int Id { get; set; }

        public QuestionType QuestionType { get; set; }

        public string? JsonName { get; set; }
        public string? DisplayName { get; set; }

        public string? DefaultValue {get; set; }
    }
}