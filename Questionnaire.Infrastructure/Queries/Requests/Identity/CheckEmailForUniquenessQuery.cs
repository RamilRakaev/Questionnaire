using MediatR;

namespace Questionnaire.Infrastructure.Queries.Requests.Identity
{
    public class EmailIsBusyQuery : IRequest<bool>
    {
        public EmailIsBusyQuery(string email)
        {
            Email = email;
        }

        public string Email { get; private set; }
    }
}
