using System.Collections.Generic;

namespace Questionnaire.Blazor.Models.Questions
{
    public class QuestionBase
    {
        public int Id { get; set; }

        public virtual string QuestionType { get; set; }

        public string JsonName { get; set; }
        public string DisplayName { get; set; }

        public string DefaultValue { get; set; }

        public List<QuestionBase> SubQuestions { get; set; }
    }
}
