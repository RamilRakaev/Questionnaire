using MediatR;
using Microsoft.AspNetCore.Identity;
using Questionnaire.Domain.Entities.Identity;
using Questionnaire.Infrastructure.Commands.Requests.Identity;
using Questionnaire.Infrastructure.Conventions;
using System.Security.Claims;

namespace Questionnaire.Infrastructure.Commands.Handlers.Identity
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateUserHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.User.UserName = request.User.Email;
            await _userManager.CreateAsync(request.User, request.Password);

            await _userManager.AddToRoleAsync(request.User, request.Role);

            Claim claim = new(RoleConstants.RoleClaim, request.Role);
            await _userManager.AddClaimAsync(request.User, claim);

            return Unit.Value;
        }
    }
}
