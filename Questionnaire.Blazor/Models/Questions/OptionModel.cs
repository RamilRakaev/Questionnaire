namespace Questionnaire.Blazor.Models.Questions
{
    public class OptionModel
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string DisplayName { get; set; }
        public string JsonName { get; set; }
    }
}
