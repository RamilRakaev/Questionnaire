using MediatR;
using Questionnaire.Domain.Entities.Identity;

namespace Questionnaire.Infrastructure.Queries.Requests.Identity
{
    public class GetAllUsersQuery : IRequest<ApplicationUser[]>
    {
    }
}
