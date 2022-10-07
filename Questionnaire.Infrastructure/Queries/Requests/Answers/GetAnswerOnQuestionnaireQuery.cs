using MediatR;
using Questionnaire.Infrastructure.Models;

namespace Questionnaire.Infrastructure.Queries.Requests.Answers
{
    public class GetAnswerOnQuestionnaireQuery : IRequest<List<JsonAnswer>>
    {
        public GetAnswerOnQuestionnaireQuery(int answerId)
        {
            AnswerId = answerId;
        }

        public int AnswerId { get; private set; }
    }
}
