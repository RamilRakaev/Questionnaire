using MediatR;

namespace Questionnaire.Infrastructure.Commands.Requests.Questionnaires
{
    public class RemoveQuestionnaireCommand : IRequest
    {
        public RemoveQuestionnaireCommand(int questionnaireId)
        {
            QuestionnaireId = questionnaireId;
        }

        public int QuestionnaireId { get; private set; }
    }
}
