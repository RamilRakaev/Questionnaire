using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Queries.Requests.Answers
{
    public class GetAnswersQuery : IRequest<List<Answer>>
    {
    }
}
