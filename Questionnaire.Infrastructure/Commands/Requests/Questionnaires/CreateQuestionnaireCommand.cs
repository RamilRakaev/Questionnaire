using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Commands.Requests.Questionnaires
{
    public class CreateQuestionnaireCommand : IRequest
    {
        public CreateQuestionnaireCommand(Structure questionnaire, IEnumerable<Property> properties)
        {
            Questionnaire = questionnaire;
            Properties = properties;
        }

        public Structure Questionnaire { get; private set; }

        public IEnumerable<Property> Properties { get; private set; }
    }
}
