using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Queries.Requests.Structures
{
    public class GetStructureQuery : IRequest<Structure?>
    {
        public GetStructureQuery(int structureId)
        {
            StructureId = structureId;
        }

        public int StructureId { get; private set; }
    }
}
