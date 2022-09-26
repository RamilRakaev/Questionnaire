using Questionnaire.Domain.Entities.Identity;

namespace Questionnaire.Domain.Entities
{
    public class QrlkChat : BaseEntity
    {
        public long UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string Title { get; set; }

        public List<string> Tags { get; set; }

        public string Token { get; set; }
    }
}
