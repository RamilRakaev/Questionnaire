using Microsoft.AspNetCore.Identity;

namespace Questionnaire.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public AnswerEntity[] Answers { get; set; }
    }
}
