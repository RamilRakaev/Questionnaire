using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities.Identity;
using Questionnaire.Infrastructure.Queries.Requests.Identity;

namespace Questionnaire.Infrastructure.Queries.Handlers.Identity
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ApplicationUser[]>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetAllUsersHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<ApplicationUser[]> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return _userManager.Users.ToArrayAsync(cancellationToken);
        }
    }
}
