using MediatR;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Queries.Requests.Structures;

namespace Questionnaire.Infrastructure.Queries.Handlers.Structures
{
    public class GetStructureHandler : IRequestHandler<GetStructureQuery, Structure>
    {
        private readonly IRepository<Structure> _structureRepository;
        private readonly IRepository<Property> _propertyRepository;

        public GetStructureHandler(IRepository<Structure> structureRepository, IRepository<Property> propertyRepository)
        {
            _structureRepository = structureRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<Structure> Handle(GetStructureQuery request, CancellationToken cancellationToken)
        {
            var structure = await _structureRepository.GetAsync(request.StructureId, cancellationToken);
            structure.Properties = await GetProperties(request.StructureId, cancellationToken);

            return structure;
        }

        private async Task<List<Property>> GetProperties(int structureId, CancellationToken cancellationToken)
        {
            var properties = await _propertyRepository.GetAllAsNoTracking()
                .Where(property => property.StructureId == structureId).
                ToListAsync(cancellationToken);

            foreach (var property in properties.Where(property => property.PropertyType == PropertyType.Custom))
            {
                property.CustomType = await _structureRepository.GetAsync(property.CustomTypeId.Value, cancellationToken);
                property.CustomType.Properties = await GetProperties(property.CustomTypeId.Value, cancellationToken);
            }

            return properties;
        }
    }
}
