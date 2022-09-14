using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities.Identity;
using Questionnaire.Infrastructure.Commands.Requests.Identity;
using Questionnaire.Infrastructure.Conventions;
using Questionnaire.Infrastructure.Models;
using System.Security.Claims;

namespace Questionnaire.Infrastructure.Commands.Handlers.Identity
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, RequestResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateUserHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RequestResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            RequestResult queryResult = new();
            var containsUser = await _userManager.Users.AnyAsync(user => user.Email == request.User.Email, cancellationToken);

            if (containsUser)
            {
                queryResult.Message = "Эта почта уже занята";
                return queryResult;
            }

            request.User.UserName = request.User.Email;
            var userCreationResult = await _userManager.CreateAsync(request.User, request.Password);

            if (userCreationResult.Succeeded == false)
            {
                queryResult.Message = "Не удалось создать пользователя";
                return queryResult;
            }

            await _userManager.AddToRoleAsync(request.User, request.Role);

            Claim claim = new(RoleConstants.RoleClaim, request.Role);
            await _userManager.AddClaimAsync(request.User, claim);

            queryResult.Successed = true;
            queryResult.Message = "Аккаунт успешно создан";
            return queryResult;
        }
    }
}
