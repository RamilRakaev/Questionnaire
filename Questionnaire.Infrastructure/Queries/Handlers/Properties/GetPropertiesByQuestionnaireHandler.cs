using MediatR;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Queries.Requests.Properties;

namespace Questionnaire.Infrastructure.Queries.Handlers.Properties
{
    public class GetPropertiesByQuestionnaireHandler : IRequestHandler<GetPropertiesByQuestionnaireQuery, PropertyEntity[]>
    {
        private readonly IRepository<PropertyEntity> _propertyRepository;

        public GetPropertiesByQuestionnaireHandler(IRepository<PropertyEntity> propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<PropertyEntity[]> Handle(GetPropertiesByQuestionnaireQuery request, CancellationToken cancellationToken)
        {
            return await _propertyRepository.GetAllAsNoTracking()
                .Where(property => property.QuestionnaireId == request.QuestionnaireId)
                .ToArrayAsync(cancellationToken);
        }
    }
}
