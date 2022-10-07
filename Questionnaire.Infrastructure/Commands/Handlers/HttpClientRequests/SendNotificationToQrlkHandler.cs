using MediatR;
using Questionnaire.Conventions.Qrlk;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Commands.Requests.HttpClientRequests;
using Questionnaire.Infrastructure.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Questionnaire.Infrastructure.Commands.Handlers.HttpClientRequests
{
    public class SendNotificationToQrlkHandler : IRequestHandler<SendNotificationToQrlkCommand, bool>
    {
        private readonly IRepository<QrlkChat> _chatRepository;
        private readonly IRepository<Answer> _answerRepository;

        public SendNotificationToQrlkHandler(IRepository<QrlkChat> chatRepository, IRepository<Answer> answerRepository)
        {
            _chatRepository = chatRepository;
            _answerRepository = answerRepository;
        }

        public async Task<bool> Handle(SendNotificationToQrlkCommand request, CancellationToken cancellationToken)
        {
            HttpClient client = new()
            {
                BaseAddress = new Uri(QrlkHttpClientConstants.BaseAddress),
            };

            var chat = await _chatRepository.GetAsync(request.ChatId, cancellationToken);
            var answer = await _answerRepository.GetAsync(request.AnswerId, cancellationToken);

            var jsonAnswers = JsonSerializer.Deserialize<List<JsonAnswer>>(answer.Value);

            NotificationToQrlk notification = new()
            {
                Title = chat.Title,
                Data = PrepareAnswersToSentOnQrlk(jsonAnswers),
                Tags = chat.Tags.ToArray(),
            };

            var result = await client.PostAsync(
                QrlkHttpClientConstants.NotifyRequestUri,
                CreateContent(notification, chat.Token),
                cancellationToken);

            client.Dispose();

            return result.IsSuccessStatusCode;
        }

        private static object PrepareAnswersToSentOnQrlk(List<JsonAnswer> jsonAnswers)
        {
            Dictionary<string, object> answersToSending = new();

            foreach (var jsonAnswer in jsonAnswers)
            {
                if (jsonAnswer.Answers != null && jsonAnswer.Answers.Count > 0)
                {
                    answersToSending.Add(jsonAnswer.Name, PrepareAnswersToSentOnQrlk(jsonAnswer.Answers));
                }
                else
                {
                    answersToSending.Add(jsonAnswer.Name, jsonAnswer.Value);
                }
            }

            return answersToSending;
        }

        private static ByteArrayContent CreateContent(NotificationToQrlk notification, string token)
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
