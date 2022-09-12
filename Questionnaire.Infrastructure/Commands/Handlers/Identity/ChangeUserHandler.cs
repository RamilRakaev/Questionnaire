using MediatR;
using Microsoft.AspNetCore.Identity;
using Questionnaire.Domain.Entities.Identity;
using Questionnaire.Infrastructure.Commands.Requests.Identity;

namespace Questionnaire.Infrastructure.Commands.Handlers.Identity
{
    public class ChangeUserHandler : IRequestHandler<ChangeUserCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public ChangeUserHandler(UserManager<ApplicationUser> userManager, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        public async Task<Unit> Handle(ChangeUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.User.Id.ToString());

            user.Email = request.User.Email;
            if (request.Password != null)
            {
                user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);
            }

            await _userManager.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
