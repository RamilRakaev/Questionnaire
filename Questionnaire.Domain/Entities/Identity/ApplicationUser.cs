using Microsoft.AspNetCore.Identity;

namespace Questionnaire.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser<long>
    {
        public List<Answer> Answers { get; set; }
    }
}
