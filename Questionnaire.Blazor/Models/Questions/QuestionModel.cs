using Questionnaire.Blazor.Models.Questions.Tags;
using Questionnaire.Infrastructure.Conventions;
using System.Collections.Generic;

namespace Questionnaire.Blazor.Models.Questions
{
    public class QuestionModel
    {
        public int Id { get; set; }

        public int QuestionnaireId { get; set; }

        public string DisplayName { get; set; }
        public string JsonName { get; set; }
        public QuestionType QuestionType { get; set; }

        public List<string> Options { get; set; }

        public HtmlTag[] HtmlTags { get; set; }
    }
}
