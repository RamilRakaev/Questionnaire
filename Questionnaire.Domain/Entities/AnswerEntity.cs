using Questionnaire.Domain.Entities.Identity;

namespace Questionnaire.Domain.Entities
{
    public class AnswerEntity : BaseEntity
    {
        public string Value { get; set; }

        public int QuestionnaireId { get; set; }
        public QuestionnaireEntity Questionnaire { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
