using Questionnaire.Domain.Entities.Identity;

namespace Questionnaire.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public string Value { get; set; }

        public int QuestionnaireId { get; set; }
        public Structure Questionnaire { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
