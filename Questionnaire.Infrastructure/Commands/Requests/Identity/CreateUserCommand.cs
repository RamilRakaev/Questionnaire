using MediatR;
using Questionnaire.Domain.Entities.Identity;
using Questionnaire.Infrastructure.Models;

namespace Questionnaire.Infrastructure.Commands.Requests.Identity
{
    public class CreateUserCommand : IRequest<RequestResult>
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
