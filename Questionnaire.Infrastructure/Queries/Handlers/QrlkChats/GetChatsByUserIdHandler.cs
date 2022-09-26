using MediatR;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Queries.Requests.QrlkChats;

namespace Questionnaire.Infrastructure.Queries.Handlers.QrlkChats
{
    public class GetChatsByUserIdHandler : IRequestHandler<GetChatsByUserIdQuery, QrlkChat[]>
    {
        private readonly IRepository<QrlkChat> _chatRepository;

        public GetChatsByUserIdHandler(IRepository<QrlkChat> chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public Task<QrlkChat[]> Handle(GetChatsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return _chatRepository.GetAllAsNoTracking()
                .Where(chat => chat.UserId == request.UserId)
                .ToArrayAsync(cancellationToken);
        }
    }
}
