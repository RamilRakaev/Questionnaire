using Microsoft.AspNetCore.Identity;

namespace Questionnaire.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser<long>
    {
        public List<QrlkChat> QrlkChats { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
