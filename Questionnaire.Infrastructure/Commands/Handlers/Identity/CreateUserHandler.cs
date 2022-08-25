using MediatR;
using Microsoft.AspNetCore.Identity;
using Questionnaire.Domain.Entities.Identity;
using Questionnaire.Infrastructure.Commands.Requests.Identity;

namespace Questionnaire.Infrastructure.Commands.Handlers.Identity
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public CreateUserHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.User.UserName = request.User.Email;
            await _userManager.CreateAsync(request.User, request.Password);

            ApplicationRole role = new()
            {
                Name = request.Role,
            };

            await _roleManager.CreateAsync(role);
            await _userManager.AddToRoleAsync(request.User, request.Role);

            return Unit.Value;
        }
    }
}
