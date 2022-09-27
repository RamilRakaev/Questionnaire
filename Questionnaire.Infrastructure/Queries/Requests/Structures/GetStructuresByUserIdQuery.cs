using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Queries.Requests.Structures
{
    public class GetStructuresByUserIdQuery : IRequest<List<Structure>>
    {
        public GetStructuresByUserIdQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; private set; }
    }
}
