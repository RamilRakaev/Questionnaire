namespace Questionnaire.Blazor.Models.Questions
{
    public abstract class QuestionBase
    {
        public int Id { get; set; }

        public abstract string QuestionType { get; }

        public string JsonName { get; set; }
        public string DisplayName { get; set; }

        public string DefaultValue { get; set; }
    }
}
