using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Entities.Identity;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Queries.Requests.Structures;

namespace Questionnaire.Infrastructure.Queries.Handlers.Structures
{
    public class GetStructuresByUserIdHandler : IRequestHandler<GetStructuresByUserIdQuery, List<Structure>>
    {
        private readonly IRepository<Answer> _answerRepository;
        private readonly IRepository<Structure> _structureRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetStructuresByUserIdHandler(IRepository<Answer> answerRepository, IRepository<Structure> structureRepository,
            UserManager<ApplicationUser> userManager)
        {
            _answerRepository = answerRepository;
            _structureRepository = structureRepository;
            _userManager = userManager;
        }

        public async Task<List<Structure>> Handle(GetStructuresByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userId = (await _userManager.FindByNameAsync(request.UserName)).Id;

            var structureIds = await _answerRepository.GetAllAsNoTracking()
                .Where(answer => answer.UserId == userId)
                .Select(answer => answer.StructureId)
                .ToArrayAsync(cancellationToken);

            return await _structureRepository.GetAllAsNoTracking()
                .Where(structure => structureIds.Contains(structure.Id))
                .ToListAsync(cancellationToken);
        }
    }
}
