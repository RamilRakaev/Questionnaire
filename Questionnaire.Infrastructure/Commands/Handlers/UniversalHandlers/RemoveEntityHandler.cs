using MediatR;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Commands.Requests.UniversalCommands;

namespace Questionnaire.Infrastructure.Commands.Handlers.UniversalHandlers
{
    public class RemoveEntityHandler<T> : IRequestHandler<RemoveEntityCommand<T>> where T : BaseEntity
    {
        private readonly IRepository<T> _entityRepostory;

        public RemoveEntityHandler(IRepository<T> entityRepostory)
        {
            _entityRepostory = entityRepostory;
        }

        public async Task<Unit> Handle(RemoveEntityCommand<T> request, CancellationToken cancellationToken)
        {
            var entity = await _entityRepostory.GetAsync(request.EntityId, cancellationToken);
            if (entity == null)
            {
                throw new NullReferenceException("Entity was not found in the database");
            }
            await _entityRepostory.RemoveAsync(entity, cancellationToken);

            return Unit.Value;
        }
    }
}
