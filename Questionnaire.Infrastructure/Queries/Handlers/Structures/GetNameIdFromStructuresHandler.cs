using MediatR;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Queries.Requests.Structures;

namespace Questionnaire.Infrastructure.Queries.Handlers.Structures
{
    public class GetNameIdFromStructuresHandler : IRequestHandler<GetNameIdFromStructuresQuery, Dictionary<string, int>>
    {
        private readonly IRepository<Structure> _structureRepository;

        public GetNameIdFromStructuresHandler(IRepository<Structure> structureRepository)
        {
            _structureRepository = structureRepository;
        }

        public Task<Dictionary<string, int>> Handle(GetNameIdFromStructuresQuery request, CancellationToken cancellationToken)
        {
            return _structureRepository.GetAllAsNoTracking()
                .ToDictionaryAsync(structure => structure.DisplayName, structure => structure.Id, cancellationToken);
        }
    }
}
