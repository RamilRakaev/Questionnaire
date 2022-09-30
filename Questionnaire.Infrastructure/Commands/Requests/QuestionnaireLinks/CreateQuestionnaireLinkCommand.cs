using MediatR;
using Microsoft.AspNetCore.Http;

namespace Questionnaire.Infrastructure.Commands.Requests.QuestionnaireLinks
{
    public class CreateQuestionnaireLinkCommand : IRequest<string>
    {
        public CreateQuestionnaireLinkCommand(HttpRequest request, string pageAddress, int questionnaireId)
        {
            Request = request;
            PageAddress = pageAddress;
            QuestionnaireId = questionnaireId;
        }

        public HttpRequest Request { get; private set; }
        public string PageAddress { get; private set; }

        public int QuestionnaireId { get; private set; }
    }
}
