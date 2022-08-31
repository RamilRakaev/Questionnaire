using MediatR;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Queries.Requests.Properties;

namespace Questionnaire.Infrastructure.Queries.Handlers.Properties
{
    public class GetPropertyAnswerPairsHandler : IRequestHandler<GetPropertyAnswerPairsQuery, Dictionary<Property, Answer>>
    {
        private readonly IRepository<Property> _propertyRepository;

        public GetPropertyAnswerPairsHandler(IRepository<Property> propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<Dictionary<Property, Answer>> Handle(GetPropertyAnswerPairsQuery request, CancellationToken cancellationToken)
        {
            var properties = await _propertyRepository.GetAllAsNoTracking()
                .Where(property => property.StructureId == request.StructureId)
                .Include(property => property.Options)
                .Include(property => property.CustomTypes)
                .ThenInclude(property => property.Properties)
                .ToArrayAsync(cancellationToken);

            Dictionary<Property, Answer> propertiesAnswers = properties
                .ToDictionary(
                    property => property,
                    property => new Answer()
                    {
                        StructureId = property.StructureId,
                        UserId = request.UserId,
                    });

            return propertiesAnswers;
        }
    }
}
