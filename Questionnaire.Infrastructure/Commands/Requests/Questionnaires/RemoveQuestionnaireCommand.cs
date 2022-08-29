using MediatR;

namespace Questionnaire.Infrastructure.Commands.Requests.Questionnaires
{
    public class RemoveQuestionnaireCommand : IRequest
    {
        public RemoveQuestionnaireCommand(int structureId)
        {
            StructureId = structureId;
        }

        public int StructureId { get; private set; }
    }
}
