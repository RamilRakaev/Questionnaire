using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Queries.Requests.Properties
{
    public class GetPropertiesByQuestionnaireQuery : IRequest<PropertyEntity[]>
    {
        public GetPropertiesByQuestionnaireQuery(int questionnaireId)
        {
            QuestionnaireId = questionnaireId;
        }

        public int QuestionnaireId { get; private set; }
    }
}
