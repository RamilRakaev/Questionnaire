namespace Questionnaire.Blazor.Models
{
    public class AnswerModel
    {
        public AnswerModel()
        {

        }

        public AnswerModel(long userId, int questionnaireId)
        {
            UserId = userId;
            QuestionnaireId = questionnaireId;
        }

        public int Id { get; set; }

        public int QuestionnaireId { get; set; }
        public long UserId { get; set; }

        public string Value { get; set; }
    }
}
