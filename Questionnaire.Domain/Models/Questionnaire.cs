namespace Questionnaire.Domain.Models
{
    public class Questionnaire
    {
        public string? JsonName { get; set; }
        public string? DisplayName { get; set; }

        public List<Question> Questions { get; set; } = new();
    }
}
