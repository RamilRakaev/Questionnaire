using Questionnaire.Blazor.Models.Questions;
using System.Collections.Generic;

namespace Questionnaire.Blazor.Models
{
    public class QuestionnaireModel
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }
        public string JsonName { get; set; }

        public AnswerModel[] Answers { get; set; }
        public QuestionModel Properties { get; set; }

        public Dictionary<QuestionModel, AnswerModel[]> QuestionAnswerPairs { get; set; }
    }
}
