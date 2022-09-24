using MediatR;

namespace Questionnaire.Infrastructure.Commands.Requests.HttpClientRequests
{
    public class SendNotificationToQrlkCommand : IRequest<bool>
    {
        public SendNotificationToQrlkCommand(int answerId)
        {
            AnswerId = answerId;
        }

        public int AnswerId { get; private set; }
    }
}
