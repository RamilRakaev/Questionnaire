using Microsoft.AspNetCore.Identity;

namespace Questionnaire.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser<long>
    {
        public int QrlkChatId { get; set; }
        public QrlkChat QrlkChat { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
