using MediatR;
using Questionnaire.Infrastructure.Models;

namespace Questionnaire.Infrastructure.Commands.Requests.Identity
{
    public class RemoveUserCommand : IRequest<RequestResult>
    {
        public RemoveUserCommand(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; private set; }
    }
}
