using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Commands.Requests.Questionnaires
{
    public class CreateQuestionnaireCommand : IRequest
    {
        public CreateQuestionnaireCommand(QuestionnaireEntity questionnaire, PropertyEntity[] properties)
        {
            Questionnaire = questionnaire;
            Properties = properties;
        }

        public QuestionnaireEntity Questionnaire { get; private set; }

        public PropertyEntity[] Properties { get; private set; }
    }
}
