using Questionnaire.Blazor.Models.Questions;
using System.Collections.Generic;

namespace Questionnaire.Blazor.Models
{
    public class QuestionnaireModel
    {
        public int Id { get; set; }

        public List<QuestionModel> Questions { get; set; }

        public string DisplayName { get; set; }

        public List<string> Options { get; set; }
    }
}
