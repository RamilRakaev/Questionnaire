using Questionnaire.Domain.Entities.Identity;

namespace Questionnaire.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public int StructureId { get; set; }
        public Structure Questionnaire { get; set; }

        public long UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string Value { get; set; }
    }
}
