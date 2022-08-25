using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities.Identity;
using Questionnaire.Infrastructure.Queries.Requests.Identity;

namespace Questionnaire.Infrastructure.Queries.Handlers.Identity
{
    public class EmailIsBusyHandler : IRequestHandler<EmailIsBusyQuery, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public EmailIsBusyHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<bool> Handle(EmailIsBusyQuery request, CancellationToken cancellationToken)
        {
            return _userManager.Users.AnyAsync(user => user.Email == request.Email, cancellationToken);
        }
    }
}
