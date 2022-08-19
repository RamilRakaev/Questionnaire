using Questionnaire.Blazor.Models.Questions.Tags;
using System.Collections.Generic;

namespace Questionnaire.Blazor.Models.Questions
{
    public class QuestionModel
    {
        public QuestionModel()
        {

        }

        public int Id { get; set; }
        public int QuestionnaireId { get; set; }
        public QuestionnaireModel Questionnaire { get; set; }

        public HtmlTag[] HtmlTags { get; set; }

        public string JsonName { get; set; }
        public string DisplayName { get; set; }
        public string QuestionType { get; set; }

        public QuestionModel[] SubQuestions { get; set; }
        public AnswerModel[] Answers { get; set; }
    }
}
