using Questionnaire.Blazor.Models.Questions;
using Questionnaire.Blazor.Models.Questions.Tags;
using System.Collections.Generic;

namespace Questionnaire.Blazor.Models
{
    public class QuestionAnswerModel
    {
        public QuestionModel Question { get; set; }

        public AnswerModel Answer { get; set; }

        public List<QuestionAnswerModel> QuestionAnswers { get; set; }

        public List<HtmlTag> HtmlTags { get; set; }
    }
}
