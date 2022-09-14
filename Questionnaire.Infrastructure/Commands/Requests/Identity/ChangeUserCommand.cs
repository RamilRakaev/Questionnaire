using MediatR;
using Questionnaire.Domain.Entities.Identity;
using Questionnaire.Infrastructure.Models;

namespace Questionnaire.Infrastructure.Commands.Requests.Identity
{
    public class ChangeUserCommand : IRequest<RequestResult>
    {
        public ChangeUserCommand(ApplicationUser user, string password)
        {
            User = user;
            Password = password;
        }

        public ApplicationUser User { get; private set; }

        public string Password { get; private set; }
    }
}
