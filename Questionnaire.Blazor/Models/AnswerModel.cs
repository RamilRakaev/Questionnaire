namespace Questionnaire.Blazor.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }

        public int QuestionnaireId { get; set; }
        public int UserId { get; set; }

        public string Value { get; set; }
    }
}
