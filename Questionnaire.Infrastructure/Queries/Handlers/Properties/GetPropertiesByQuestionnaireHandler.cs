using MediatR;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Queries.Requests.Properties;

namespace Questionnaire.Infrastructure.Queries.Handlers.Properties
{
    public class GetPropertiesByQuestionnaireHandler : IRequestHandler<GetPropertiesByQuestionnaireQuery, Property[]>
    {
        private readonly IRepository<Property> _propertyRepository;

        public GetPropertiesByQuestionnaireHandler(IRepository<Property> propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<Property[]> Handle(GetPropertiesByQuestionnaireQuery request, CancellationToken cancellationToken)
        {
            return await _propertyRepository.GetAllAsNoTracking()
                .Where(property => property.StructureId == request.StructureId)
                .Include(property => property.Options)
                .Include(property => property.CustomTypes)
                .ThenInclude(property => property.Properties)
                .ToArrayAsync(cancellationToken);
        }
    }
}
