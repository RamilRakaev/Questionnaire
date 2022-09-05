using MediatR;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Queries.Requests.Structures;

namespace Questionnaire.Infrastructure.Queries.Handlers.Structures
{
    public class GetStructureHandler : IRequestHandler<GetStructureQuery, Structure?>
    {
        private readonly IRepository<Structure> _structureRepository;
        private readonly IRepository<Property> _propertyRepository;

        public GetStructureHandler(IRepository<Structure> structureRepository, IRepository<Property> propertyRepository)
        {
            _structureRepository = structureRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<Structure?> Handle(GetStructureQuery request, CancellationToken cancellationToken)
        {
            var structure = await _structureRepository.GetAsync(request.StructureId, cancellationToken);
            structure.Properties = await _propertyRepository.GetAllAsync()
                .Where(property => property.StructureId == request.StructureId)
                .Include(property => property.CustomType)
                    .ThenInclude(structure => structure.Properties)
                    .ThenInclude(property => property.Options)
                .ToListAsync(cancellationToken);

            return structure;
        }
    }
}
