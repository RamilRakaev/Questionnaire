using MediatR;
using Microsoft.AspNetCore.Identity;
using Questionnaire.Domain.Entities.Identity;
using Questionnaire.Infrastructure.Commands.Requests.Identity;
using Questionnaire.Infrastructure.Models;

namespace Questionnaire.Infrastructure.Commands.Handlers.Identity
{
    public class RemoveUserHandler : IRequestHandler<RemoveUserCommand, RequestResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RemoveUserHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RequestResult> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            var result = await _userManager.DeleteAsync(user);

            RequestResult requestResult = new();

            if (result.Succeeded)
            {
                requestResult.Successed = true;
                requestResult.Message = "Пользователь удалён";
            }
            else
            {
                requestResult.Message = "При удалении произошла ошибка";
            }

            return requestResult;
        }
    }
}
