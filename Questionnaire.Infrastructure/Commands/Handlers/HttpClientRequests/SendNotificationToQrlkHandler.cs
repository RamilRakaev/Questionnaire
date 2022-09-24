using MediatR;
using Microsoft.AspNetCore.Identity;
using Questionnaire.Conventions.Qrlk;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Entities.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public SendNotificationToQrlkHandler(IRepository<QrlkChat> chatRepository, IRepository<Answer> answerRepository, UserManager<ApplicationUser> userManager)
        {
            _chatRepository = chatRepository;
            _answerRepository = answerRepository;
            _userManager = userManager;
        }

        public async Task<bool> Handle(SendNotificationToQrlkCommand request, CancellationToken cancellationToken)
        {
            HttpClient client = new()
            {
                BaseAddress = new Uri(QrlkHttpClientConstants.BaseAddress),
            };
            var answer = await _answerRepository.GetAsync(request.AnswerId, cancellationToken);
            var user = await _userManager.FindByIdAsync(answer.UserId.ToString());
            var chat = await _chatRepository.GetAsync(user.QrlkChatId, cancellationToken);

            NotificationToQrlk notification = new()
            {
                Title = chat.Title,
                Data = answer.Value,
                Tags = chat.Tags.ToArray(),
            };

            var result = await client.PostAsync(
                QrlkHttpClientConstants.NotifyRequestUri,
                CreateContent(notification, chat.Token),
                cancellationToken);

            client.Dispose();

            return result.IsSuccessStatusCode;
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
