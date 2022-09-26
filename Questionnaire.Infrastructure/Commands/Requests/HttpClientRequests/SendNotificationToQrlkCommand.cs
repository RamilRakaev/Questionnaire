using MediatR;

namespace Questionnaire.Infrastructure.Commands.Requests.HttpClientRequests
{
    public class SendNotificationToQrlkCommand : IRequest<bool>
    {
        public SendNotificationToQrlkCommand(int answerId, int chatId)
        {
            AnswerId = answerId;
            ChatId = chatId;
        }

        public int AnswerId { get; private set; }

        public int ChatId { get; private set; }
    }
}
