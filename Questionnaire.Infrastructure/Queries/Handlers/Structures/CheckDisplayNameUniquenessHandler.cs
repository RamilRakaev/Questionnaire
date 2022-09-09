using MediatR;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Queries.Requests.Structures;

namespace Questionnaire.Infrastructure.Queries.Handlers.Structures
{
    public class CheckDisplayNameUniquenessHandler : IRequestHandler<CheckDisplayNameUniquenessQuery, bool>
    {
        private readonly IRepository<Structure> _structureRepository;

        public CheckDisplayNameUniquenessHandler(IRepository<Structure> structureRepository)
        {
            _structureRepository = structureRepository;
        }

        public async Task<bool> Handle(CheckDisplayNameUniquenessQuery request, CancellationToken cancellationToken)
        {
            var containsDisplayName = await _structureRepository.GetAllAsNoTracking()
                .AnyAsync(structure => structure.DisplayName == request.DisplayName, cancellationToken);

            return containsDisplayName == false;
        }
    }
}
