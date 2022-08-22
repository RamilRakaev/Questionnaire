using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Commands.Requests.Questionnaires
{
    public class CreateQuestionnaireCommand : IRequest
    {
        public CreateQuestionnaireCommand(QuestionnaireEntity questionnaire, IEnumerable<PropertyEntity> properties)
        {
            Questionnaire = questionnaire;
            Properties = properties;
        }

        public QuestionnaireEntity Questionnaire { get; private set; }

        public IEnumerable<PropertyEntity> Properties { get; private set; }
    }
}
