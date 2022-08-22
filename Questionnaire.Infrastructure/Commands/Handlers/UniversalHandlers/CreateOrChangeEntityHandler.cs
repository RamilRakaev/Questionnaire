using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Commands.Requests.UniversalCommands;

namespace Questionnaire.Infrastructure.Commands.Handlers.UniversalHandlers
{
    public class CreateOrChangeEntityHandler<T> : IRequestHandler<CreateOrChangeEntityCommand<T>> where T : BaseEntity
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public CreateOrChangeEntityHandler(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task<Unit> Handle(CreateOrChangeEntityCommand<T> request, CancellationToken cancellationToken)
        {
            var entityRepository = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<IRepository<T>>();
            
            var entity = await entityRepository.GetAllAsNoTracking()
                .FirstOrDefaultAsync(entity => entity.Id == request.Entity.Id, cancellationToken);

            if (entity == null)
            {
                await entityRepository.AddAsync(request.Entity, cancellationToken);
            }
            else
            {
                request.Entity.Id = entity.Id;
                await entityRepository.UpdateAsync(request.Entity, cancellationToken);
            }

            return Unit.Value;
        }
    }
}
