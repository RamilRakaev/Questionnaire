using MediatR;
using Microsoft.AspNetCore.Identity;
using Questionnaire.Domain.Entities.Identity;
using Questionnaire.Infrastructure.Commands.Requests.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Infrastructure.Commands.Handlers.Identity
{
    public class LoginHandler : IRequestHandler<LoginCommand>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginHandler(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                await _signInManager.SignOutAsync();
                var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, request.RememberMe, false);
            }

            return Unit.Value;
        }
    }
}
