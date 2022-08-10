using Questionnaire.Blazor.Models.Questions;
using System.Collections.Generic;

namespace Questionnaire.Blazor.Models
{
    public class QuestionnaireModel
    {
        public string? JsonName { get; set; }
        public string? DisplayName { get; set; }

        public List<TextQuestion> Questions { get; set; } = new();
    }
}
