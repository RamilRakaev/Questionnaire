using MediatR;

namespace Questionnaire.Infrastructure.Queries.Requests.Structures
{
    public class GetNameIdFromStructuresQuery : IRequest<Dictionary<string, int>>
    {
    }
}
