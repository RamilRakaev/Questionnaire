using MediatR;
using Microsoft.AspNetCore.Identity;
using Questionnaire.Domain.Entities.Identity;
using Questionnaire.Infrastructure.Commands.Requests.Identity;
using Questionnaire.Infrastructure.Models;

namespace Questionnaire.Infrastructure.Commands.Handlers.Identity
{
    public class ChangeUserHandler : IRequestHandler<ChangeUserCommand, RequestResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public ChangeUserHandler(UserManager<ApplicationUser> userManager, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        public async Task<RequestResult> Handle(ChangeUserCommand request, CancellationToken cancellationToken)
        {
            RequestResult requestResult = new();
            var user = await _userManager.FindByIdAsync(request.User.Id.ToString());

            user.Email = request.User.Email;

            if (request.Password == null)
            {
                requestResult.Message = "Пустой пароль";
                return requestResult;
            }

            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                requestResult.Successed = true;
                requestResult.Message = "Пароль пользователя успешно изменён";
            }
            else
            {
                requestResult.Message = "Ошибка при изменении пароля";
            }

            return requestResult;
        }
    }
}
