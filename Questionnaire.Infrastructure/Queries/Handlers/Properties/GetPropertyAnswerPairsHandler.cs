using MediatR;
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

        public Task<Dictionary<PropertyEntity, AnswerEntity>> Handle(GetPropertyAnswerPairsQuery request, CancellationToken cancellationToken)
        {
            var properties = _propertyRepository.GetAllAsNoTracking().Where(property => property.QuestionnaireId == request.QuestionnaireId);
            Dictionary<PropertyEntity, AnswerEntity> pairs = new();

            foreach (var property in properties)
            {
                pairs.Add(property, new()
                {
                    QuestionnaireId = property.QuestionnaireId,
                    UserId = request.UserId,
                });
            }

            return Task.FromResult(pairs);
        }
    }
}
