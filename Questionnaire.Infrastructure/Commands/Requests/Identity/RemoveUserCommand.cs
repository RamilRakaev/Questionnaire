using MediatR;

namespace Questionnaire.Infrastructure.Commands.Requests.Identity
{
    public class RemoveUserCommand : IRequest
    {
        public RemoveUserCommand(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; private set; }
    }
}
