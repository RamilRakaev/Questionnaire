using MediatR;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Queries.Requests.Properties;

namespace Questionnaire.Infrastructure.Queries.Handlers.Properties
{
    public class GetPropertyAnswerPairsHandler : IRequestHandler<GetPropertyAnswerPairsQuery, Dictionary<PropertyEntity, AnswerEntity>>
    {
        private readonly IRepository<PropertyEntity> _propertyRepository;

        public GetPropertyAnswerPairsHandler(IRepository<PropertyEntity> propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<Dictionary<PropertyEntity, AnswerEntity>> Handle(GetPropertyAnswerPairsQuery request, CancellationToken cancellationToken)
        {
            var properties = _propertyRepository.GetAllAsNoTracking().Where(property => property.QuestionnaireId == request.QuestionnaireId);

            Dictionary<PropertyEntity, AnswerEntity> pairs = await properties
                .ToDictionaryAsync(
                    property => property,
                    property => new AnswerEntity()
                    {
                        QuestionnaireId = property.QuestionnaireId,
                        UserId = request.UserId,
                    },
                    cancellationToken);

            return pairs;
        }
    }
}
