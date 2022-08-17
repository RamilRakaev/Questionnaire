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
            await _entityRepostory.DeleteAsync(request.Entity, cancellationToken);
            return Unit.Value;
        }
    }
}
