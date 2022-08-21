using MediatR;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Commands.Requests.UniversalCommands;

namespace Questionnaire.Infrastructure.Commands.Handlers.UniversalHandlers
{
    public class CreateOrChangeEntityHandler<T> : IRequestHandler<CreateOrChangeEntityCommand<T>> where T : BaseEntity
    {
        private readonly IRepository<T> _entityRepository;

        public CreateOrChangeEntityHandler(IRepository<T> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<Unit> Handle(CreateOrChangeEntityCommand<T> request, CancellationToken cancellationToken)
        {
            var entity = await _entityRepository.GetAllAsNoTracking()
                .FirstOrDefaultAsync(entity => entity.Id == request.Entity.Id, cancellationToken);

            if (entity == null)
            {
                await _entityRepository.AddAsync(request.Entity, cancellationToken);
            }
            else
            {
                request.Entity.Id = entity.Id;
                await _entityRepository.UpdateAsync(request.Entity, cancellationToken);
            }

            return Unit.Value;
        }
    }
}
