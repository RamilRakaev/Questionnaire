using MediatR;

namespace Questionnaire.Infrastructure.Commands.Requests.Identity
{
    public class LoginCommand : IRequest
    {
        public LoginCommand(string email, string password, bool rememberMe)
        {
            Email = email;
            Password = password;
            RememberMe = rememberMe;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }

        public bool RememberMe { get; private set; }
    }
}
