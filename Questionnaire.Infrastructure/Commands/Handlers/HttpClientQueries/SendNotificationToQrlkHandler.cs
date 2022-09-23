using MediatR;
using Microsoft.Extensions.Options;
using Questionnaire.Infrastructure.Commands.Requests.HttpClient;
using Questionnaire.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Questionnaire.Infrastructure.Models.Options;

namespace Questionnaire.Infrastructure.Commands.Handlers.HttpClientQueries
{
    public class SendNotificationToQrlkHandler : IRequestHandler<SendNotificationToQrlkCommand, bool>
    {
        private readonly QrlkOptions _qrlkOptions;

        public SendNotificationToQrlkHandler(IOptions<QrlkOptions> qrlkOptions)
        {
            _qrlkOptions = qrlkOptions.Value;
        }

        public Task<bool> Handle(SendNotificationToQrlkCommand request, CancellationToken cancellationToken)
        {
            HttpClient client = new();
            throw new NotImplementedException();
        }

        public static ByteArrayContent CreateContent(NotificationToQrlk notification, string token)
        {
            var myContent = JsonSerializer.Serialize(notification);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            byteContent.Headers.Add("ApiKey", token);

            return byteContent;
        }
    }
}
