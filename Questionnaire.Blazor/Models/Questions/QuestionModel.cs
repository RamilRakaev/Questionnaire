using Questionnaire.Blazor.Models.Questions.Tags;
using System.Collections.Generic;

namespace Questionnaire.Blazor.Models.Questions
{
    public class QuestionModel
    {
        public int Id { get; set; }

        public int QuestionnaireId { get; set; }

        public QuestionnaireModel CustomTypeId { get; set; }
        public QuestionnaireModel CustomType { get; set; }

        public List<OptionModel> Options { get; set; }

        public string DisplayName { get; set; }
        public string JsonName { get; set; }

        public QuestionType QuestionType { get; set; }

        public HtmlTag[] HtmlTags { get; set; }
    }
}
