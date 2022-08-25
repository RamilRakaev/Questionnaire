using MediatR;
using Microsoft.AspNetCore.Identity;
using Questionnaire.Domain.Entities.Identity;
using Questionnaire.Infrastructure.Commands.Requests.Identity;

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

            return Unit.Value;
        }
    }
}
