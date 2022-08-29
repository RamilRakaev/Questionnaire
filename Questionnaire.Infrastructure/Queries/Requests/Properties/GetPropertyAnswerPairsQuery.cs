using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Queries.Requests.Properties
{
    public class GetPropertyAnswerPairsQuery : IRequest<Dictionary<Property, Answer>>
    {
        public GetPropertyAnswerPairsQuery(int structureId, int userId)
        {
            StructureId = structureId;
            UserId = userId;
        }

        public int StructureId { get; private set; }

        public int UserId { get; private set; }
    }
}
