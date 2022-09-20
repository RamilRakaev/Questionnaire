using MediatR;
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
            return Task.FromResult(_structureRepository
                .GetAllAsNoTracking()
                .ToDictionary(structure => structure.DisplayName, structure => structure.Id));
        }
    }
}
