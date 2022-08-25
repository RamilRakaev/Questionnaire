using MediatR;
using Questionnaire.Domain.Entities.Identity;

namespace Questionnaire.Infrastructure.Commands.Requests.Identity
{
    public class CreateUserCommand : IRequest
    {
        public CreateUserCommand(ApplicationUser user, string password, string role)
        {
            User = user;
            Password = password;
            Role = role;
        }

        public ApplicationUser User { get; private set; }

        public string Password { get; private set; }

        public string Role { get; private set; }
    }
}
