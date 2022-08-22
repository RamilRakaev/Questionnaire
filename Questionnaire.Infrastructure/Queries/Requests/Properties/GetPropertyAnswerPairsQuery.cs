using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Queries.Requests.Properties
{
    public class GetPropertyAnswerPairsQuery : IRequest<Dictionary<PropertyEntity, AnswerEntity>>
    {
        public GetPropertyAnswerPairsQuery(int questionnaireId, int userId)
        {
            QuestionnaireId = questionnaireId;
            UserId = userId;
        }

        public int QuestionnaireId { get; private set; }

        public int UserId { get; private set; }
    }
}
