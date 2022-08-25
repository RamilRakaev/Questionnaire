using MediatR;
using Microsoft.AspNetCore.Identity;
using Questionnaire.Domain.Entities.Identity;
using Questionnaire.Infrastructure.Commands.Requests.Identity;

namespace Questionnaire.Infrastructure.Commands.Handlers.Identity
{
    public class RemoveUserHandler : IRequestHandler<RemoveUserCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RemoveUserHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            await _userManager.DeleteAsync(user);

            return Unit.Value;
        }
    }
}
