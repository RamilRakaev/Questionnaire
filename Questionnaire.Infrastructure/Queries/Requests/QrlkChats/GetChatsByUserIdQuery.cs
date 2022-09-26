using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Queries.Requests.QrlkChats
{
    public class GetChatsByUserIdQuery : IRequest<QrlkChat[]>
    {
        public GetChatsByUserIdQuery(long userId)
        {
            UserId = userId;
        }

        public long UserId { get; private set; }
    }
}
