namespace Questionnaire.Domain.Entities
{
    public class QuestionnaireLink : BaseEntity
    {
        public string BaseAddress { get; set; }
        public string PageAddress { get; set; }

        public int QuestionnaireId { get; set; }
        public string Token { get; set; }

        public DateTime DateOfCreation { get; set; }
    }
}
