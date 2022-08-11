namespace Questionnaire.Blazor.Models.Questions
{
    public class EnumerationQuestion : QuestionBase
    {
        public string[] AllowedValues { get; set; }

        public override string QuestionType => QuestionTypes.Enumeration;
    }
}
