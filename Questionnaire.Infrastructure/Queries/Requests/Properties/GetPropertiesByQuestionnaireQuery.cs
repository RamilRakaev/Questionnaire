using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Queries.Requests.Properties
{
    public class GetPropertiesByQuestionnaireQuery : IRequest<Property[]>
    {
        public GetPropertiesByQuestionnaireQuery(int structureId)
        {
            StructureId = structureId;
        }

        public int StructureId { get; private set; }
    }
}
