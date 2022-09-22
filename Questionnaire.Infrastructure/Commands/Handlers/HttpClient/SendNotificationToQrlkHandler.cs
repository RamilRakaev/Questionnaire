using MediatR;
using Questionnaire.Infrastructure.Commands.Requests.HttpClient;
using Questionnaire.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Questionnaire.Infrastructure.Commands.Handlers.HttpClient
{
    public class SendNotificationToQrlkHandler : IRequestHandler<SendNotificationToQrlkCommand, bool>
    {
        public Task<bool> Handle(SendNotificationToQrlkCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public static ByteArrayContent CreateContent(NotificationToQrlk notification, string token)
        {
            var myContent = JsonSerializer.Serialize(notification);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            byteContent.Headers.Add("ApiKey", token);

            return byteContent;
        }
    }
}
